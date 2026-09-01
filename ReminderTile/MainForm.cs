using Common;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using XControls;

namespace ReminderTile
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 窗体当前贴在哪个屏幕边缘。
        /// None 表示当前没有进入自动贴边隐藏模式。
        /// </summary>
        private enum DockSide
        {
            None,
            Left,
            Right,
            Top,
            Bottom
        }

        /// <summary>
        /// 是否启用透明度效果。
        /// true：鼠标进入窗体后变为完全不透明；鼠标离开窗体后降低透明度。
        /// false：始终保持完全不透明。
        /// </summary>
        private bool EnableOpacityEffect = false;

        /// <summary>
        /// 是否启用自动贴边隐藏。
        /// true：当用户把窗体拖出屏幕真实外边缘达到指定距离后，自动进入贴边隐藏模式。
        /// false：窗体完全自由移动，不会自动贴边隐藏。
        /// </summary>
        private bool EnableAutoHideDock = false;

        // ============================================================
        // 透明度效果参数
        // ============================================================

        /// <summary>
        /// 鼠标进入窗体后的透明度。
        /// 1.0 = 完全不透明。
        /// </summary>
        private const double ActiveOpacity = 1.0;

        /// <summary>
        /// 鼠标离开窗体后的透明度。
        /// 取值范围：0.0 ~ 1.0
        /// 例如：0.5 = 50% 透明度。
        /// 数值越小，鼠标离开后窗体越透明。
        /// </summary>
        private const double InactiveOpacity = 0.5;

        /// <summary>
        /// 透明度 Ease-Out 缓动系数。
        /// 每次 Tick 都移动“当前透明度与目标透明度之间剩余距离”的这个比例。
        /// 数值越小：动画越慢、越柔和、效果越明显。
        /// 数值越大：动画越快。
        /// 推荐：
        /// 0.05 = 很慢
        /// 0.08 = 较慢且自然
        /// 0.10 = 中等
        /// 0.15 = 较快
        /// 0.20 = 很快
        ///
        /// 之前觉得 0.20 太快，所以这里使用 0.08。
        /// </summary>
        private const double FadeEasing = 0.08;

        /// <summary>
        /// 判断透明度动画已经完成的误差范围。
        /// Ease-Out 理论上会无限逼近目标值，因此必须设置一个最小误差来结束动画。
        /// 数值越小：动画尾部持续越久。
        /// 推荐：0.003 ~ 0.01
        /// </summary>
        private const double FadeMinDifference = 0.005;


        // ============================================================
        // 自动贴边参数
        // ============================================================

        /// <summary>
        /// 用户需要把窗体拖出屏幕多少像素才认为用户有“贴边隐藏”的意图。
        /// 例如设置为 10：只有窗体至少有 10px 超出屏幕真实外边缘，才进入自动贴边模式。
        /// 正常在屏幕内部拖动不会触发。
        /// </summary>
        private const int DockTriggerDistance = 10;

        /// <summary>
        /// 自动贴边窗体展开以后，与当前显示器工作区域边缘保留的距离。
        /// 例如设置为 8：窗体展开以后，四周至少保留 8px 空白。
        /// 这样即使窗体是在屏幕角落进行停靠，展开以后也不会有任何一部分跑到屏幕外或另一块显示器中。
        /// 推荐：5 ~ 15
        /// </summary>
        private const int DockShowMargin = 8;

        /// <summary>
        /// 用户从自动贴边窗体的正常展开位置，向屏幕内部拖动多少像素后解除贴边状态。
        /// 由于窗体展开后已经通过 DockShowMargin 与屏幕边缘留有一定空白，用户只要开始明显地向屏幕内部拖动，就可以认为用户希望取消贴边。
        /// 推荐：1 ~ 5
        /// 设置为 1：只要向屏幕内部拖动至少 1px，就解除贴边。
        /// </summary>
        private const int UndockDragDistance = 1;

        /// <summary>
        /// 自动隐藏后，仍然留在屏幕上的宽度 / 高度。
        /// 左右贴边时表示可见宽度；上下贴边时表示可见高度。
        /// 越小：隐藏越彻底，但鼠标越难重新触发。
        /// 推荐：5 ~ 20
        /// </summary>
        private const int HiddenVisibleSize = 10;

        /// <summary>
        /// 窗体滑动动画的 Ease-Out 缓动系数。
        /// 数值越小：滑动越慢、越柔和。
        /// 数值越大：滑动越快。
        /// 推荐：
        /// 0.05 = 很慢
        /// 0.08 = 较慢且效果明显
        /// 0.10 = 中等
        /// 0.15 = 较快
        /// </summary>
        private const double SlideEasing = 0.08;

        /// <summary>
        /// 距离滑动目标位置多少像素以内，就认为动画已经完成。
        /// Ease-Out 会无限逼近目标位置，因此需要一个最小距离来结束动画。
        /// 推荐：1 ~ 3
        /// </summary>
        private const int SlideMinDistance = 2;


        // ============================================================
        // Timer
        // ============================================================

        /// <summary>
        /// 用于判断鼠标是否已经真正离开整个窗体。
        /// 注意：它不是一直运行。
        /// 只有鼠标位于窗体内，并且当前至少有一个功能需要判断鼠标离开时才会运行。
        /// 鼠标离开后立即停止。
        /// </summary>
        private readonly Timer mouseCheckTimer = new Timer();

        /// <summary>
        /// 透明度渐变动画 Timer。
        /// 只在透明度实际发生变化时运行，达到目标透明度后立即停止。
        /// </summary>
        private readonly Timer fadeTimer = new Timer();

        /// <summary>
        /// 自动贴边滑动动画 Timer。
        /// 只在吸附、隐藏、展开动画期间运行，到达目标位置以后立即停止。
        /// </summary>
        private readonly Timer slideTimer = new Timer();


        // ============================================================
        // 透明度状态
        // ============================================================

        /// <summary>
        /// 当前透明度动画的目标透明度。
        /// </summary>
        private double targetOpacity = ActiveOpacity;


        // ============================================================
        // 自动贴边状态
        // ============================================================

        /// <summary>
        /// 当前贴边方向。
        /// None：当前处于普通自由移动模式。
        /// Left / Right / Top / Bottom：当前已经进入自动贴边隐藏模式。
        /// </summary>
        private DockSide dockSide = DockSide.None;

        /// <summary>
        /// 当前自动贴边所对应的显示器。
        /// 进入贴边模式以后会记录下来，后续隐藏和展开都基于这个显示器计算。
        /// </summary>
        private Screen dockScreen = null;

        /// <summary>
        /// 当前滑动动画的目标位置。
        /// </summary>
        private Point targetLocation;

        /// <summary>
        /// 当前窗体是否已经处于隐藏状态。
        /// true：窗体绝大部分已经滑出屏幕，只留下 HiddenVisibleSize 像素
        /// false：窗体完整显示。
        /// </summary>
        private bool isHidden = false;

        public MainForm()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;

            // 使用string.Equals进行比较，简化三元条件运算，而且避免 Read() 万一返回 null 时 ToLower() 抛异常
            EnableAutoHideDock = string.Equals(CommonData.IniHelper.Read("ReminderTile", "AutoHide"), "true", StringComparison.OrdinalIgnoreCase);
            EnableOpacityEffect = string.Equals(CommonData.IniHelper.Read("ReminderTile", "OpacityEffect"), "true", StringComparison.OrdinalIgnoreCase);

            // ==================== 可调整参数 ====================
            // ==================== 鼠标检测参数 ====================
            // 鼠标位置检测间隔，单位：毫秒。
            // 这个 Timer 只在鼠标位于窗体内时运行，用来判断鼠标是否已经真正离开整个窗体。只在有必要时运行。
            //
            // 数值越小：离开窗体后的响应越快，但检测频率越高。
            // 数值越大：检测频率越低，但离开后的响应会有一定延迟。
            //
            // 推荐：30 ~ 100
            // 50ms 通常是响应速度和检测频率之间比较合适的值。
            mouseCheckTimer.Interval = 50;
            mouseCheckTimer.Tick += MouseCheckTimer_Tick;
            // ====================================================

            // ==================== 透明度参数 ====================
            // 透明度渐变动画刷新间隔，单位：毫秒。
            //
            // 数值越小：动画刷新越频繁，视觉上越平滑。
            // 数值越大：动画刷新频率越低，可能出现明显的逐级变化。
            //
            // 推荐：15 ~ 30
            // 一般不建议通过大幅增加 Interval 来降低动画速度，应主要通过 easing 调整动画快慢。
            fadeTimer.Interval = 15;
            fadeTimer.Tick += FadeTimer_Tick;
            // ==================================================

            // ==================== 滑动动画参数 ====================
            // 贴边隐藏/显示动画刷新间隔。
            // 推荐保持在 15 ~ 20ms 左右。
            // 动画速度主要通过 SlideEasing 控制。
            slideTimer.Interval = 15;
            slideTimer.Tick += SlideTimer_Tick;
            // ====================================================


            // ========================================================
            // 鼠标进入事件
            // ========================================================

            // 因为无边框窗体里面可能铺满 Panel、Button、Label、UserControl 等子控件，Form 自己的 MouseEnter 并不能可靠表示“鼠标进入整个窗体”。
            // 因此递归给 Form 和所有现有子控件注册同一个 MouseEnter 事件。
            RegisterMouseEnter(this);

            // ========================================================
            // 初始透明度
            // ========================================================

            // 如果启用了透明度效果，根据启动时鼠标是否位于有效窗体范围内确定透明度。
            // 如果没有启用，则始终保持 1.0。
            if (EnableOpacityEffect)
                this.Opacity = IsMouseInActiveArea() ? ActiveOpacity : InactiveOpacity;
            else
                this.Opacity = ActiveOpacity;

            // WinForms 有一种情况：鼠标按下以后拖动过程中，控件失去鼠标捕获，MouseUp 不一定按照预想的流程发生。因此可以给 panelBar 再增加一个 MouseCaptureChanged
            panelBar.MouseCaptureChanged += panelBar_MouseCaptureChanged;

            // 跨屏幕拖动时，如果窗体的 DPI 不同，为了让混合 DPI 更稳，可以考虑加一个 DpiChanged 处理。
            // 当前项目基于 .NET Framework 4.5，不启用 DpiChanged 处理。如果以后升级到支持 Per-Monitor DPI / DpiChanged 的框架版本，可以结合文件末尾保留的参考代码重新评估是否启用。
            //this.DpiChanged += MainForm_DpiChanged;

            //XScrollBar scrollBar = new XScrollBar();
            //richTextBoxContent.ScrollBars = scrollBar;
        }

        /// <summary>
        /// 当前是否正在通过 panelBar 拖动窗体。
        /// 这个状态明确表示“用户正在主动移动窗体”，从而可以和 slideTimer 等程序内部移动窗体的行为完全区分。
        /// </summary>
        private bool isUserDragging = false;

        /// <summary>
        /// 窗体位置
        /// </summary>
        private Point formPoint = new Point();
        /// <summary>
        /// 提醒事项字典
        /// </summary>
        private Dictionary<int, Reminder> reminderDict;
        /// <summary>
        /// 当前提醒事项的序号
        /// </summary>
        private int currentIndex = -1;
        /// <summary>
        /// 正在新增
        /// </summary>
        private bool isAdding = false;
        /// <summary>
        /// 原始内容
        /// </summary>
        private string originalContent = string.Empty;

        #region 针对设置

        /// <summary>
        /// 正在进行设置
        /// </summary>
        public bool IsSetting { get; set; } = false;

        /// <summary>
        /// 钉住(置顶)
        /// </summary>
        public bool SettingTopMost { get; set; } = false;

        /// <summary>
        /// 背景色
        /// </summary>
        public Color SettingBackColor { get; set; }
        /// <summary>
        /// 启动位置（相对屏幕右上角）
        /// </summary>
        public Point SettingStartPosition { get; set; }
        #endregion

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                string strTopMost = CommonData.IniHelper.Read("ReminderTile", "TopMost");
                //未配置或配置为true，则置顶
                if (string.IsNullOrWhiteSpace(strTopMost) || strTopMost.Trim().ToLower() == "true")
                    buttonTop.PerformClick();
            }
            catch
            {
                //如果读取配置失败，默认置顶
                buttonTop.PerformClick();
            }
            try
            {
                string strBackColor = CommonData.IniHelper.Read("ReminderTile", "BackColor");
                int intBackColor;
                if (!string.IsNullOrWhiteSpace(strBackColor) && int.TryParse(strBackColor, out intBackColor))
                    richTextBoxContent.BackColor = Color.FromArgb(intBackColor);
            }
            catch { }
            int startPositionRight = 33, startPositionTop = 30;
            try
            {
                string strStartPosition = CommonData.IniHelper.Read("ReminderTile", "StartPosition");
                if (!string.IsNullOrWhiteSpace(strStartPosition) && strStartPosition.Contains(","))
                {
                    string[] positionArray = strStartPosition.Split(',');
                    int.TryParse(positionArray[0], out startPositionRight);
                    int.TryParse(positionArray[1], out startPositionTop);
                }
            }
            catch { }
            //注意，如果有"SizeChanged"事件，先"-="避免触发事件，然后在finally中"+="避免出现异常后丢失事件
            //this.SizeChanged -= MainForm_SizeChanged;
            try
            {
                string strSize = CommonData.IniHelper.Read("ReminderTile", "Size");
                if (!string.IsNullOrWhiteSpace(strSize) && strSize.Contains(","))
                {
                    string[] sizeArray = strSize.Split(',');
                    int width, height;
                    if (int.TryParse(sizeArray[0], out width) && int.TryParse(sizeArray[1], out height))
                    {
                        //容错，避免数据设置太大或太小出现显示问题
                        //程序初次显示在主屏，所以这里用Screen.PrimaryScreen就行了 //获取当前屏幕对象 Screen CurrentScreen = Screen.FromControl(this);
                        if (width < 100)
                            width = 100;
                        else if (width > Screen.PrimaryScreen.WorkingArea.Width - startPositionRight)
                            width = Screen.PrimaryScreen.WorkingArea.Width - startPositionRight;
                        if (height < 60)
                            height = 60;
                        else if (height > Screen.PrimaryScreen.WorkingArea.Height - startPositionTop)
                            height = Screen.PrimaryScreen.WorkingArea.Height - startPositionTop;
                        this.Size = new Size(width, height);
                    }
                    //默认设置有值，这里可以不需要
                    //else
                    //    this.Size = new Size(330, 200);
                }
            }
            catch { }
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - startPositionRight - this.Width, startPositionTop);

            formPoint = this.Location;
            richTextBoxContent.BackColorChanged -= richTextBoxContent_BackColorChanged;
            richTextBoxContent_BackColorChanged(sender, e);
            richTextBoxContent.BackColorChanged += richTextBoxContent_BackColorChanged;
            toolTipInfo.SetToolTip(buttonRefresh, "刷新(Ctrl+R)");
            toolTipInfo.SetToolTip(buttonPrevious, "上一个(Ctrl+←)");
            toolTipInfo.SetToolTip(buttonNext, "下一个(Ctrl+→)");
            toolTipInfo.SetToolTip(buttonAdd, "新增(Ctrl+N)");
            toolTipInfo.SetToolTip(buttonSave, "保存(Ctrl+S)");
            toolTipInfo.SetToolTip(buttonDelete, "完成/删除(Ctrl+D)");
            toolTipInfo.SetToolTip(buttonTop, this.TopMost ? "拔出(Ctrl+↑)" : "钉住(Ctrl+↓)");
            toolTipInfo.SetToolTip(buttonColor, "颜色(Ctrl+L)");
            toolTipInfo.SetToolTip(buttonClose, "关闭(Ctrl+W)");

            if (IsSetting)
            {
                buttonRefresh.Enabled = false;
                buttonPrevious.Enabled = false;
                buttonNext.Enabled = false;
                buttonAdd.Enabled = false;
                buttonSave.Enabled = false;
                buttonDelete.Enabled = false;
                richTextBoxContent.ReadOnly = true;
                richTextBoxContent.Text = "可以设置是否钉住（置顶）、背景颜色、位置。" + Environment.NewLine + "设置完后关闭窗体进行保存。";
                notifyIconNofity.Visible = false;
            }
            else
            {
                //buttonTop.PerformClick();//默认置顶//改为从配置文件读取

                GetReminderList();
                //if (reminderDict?.Count > 0)
                //    BindReminder(0);
            }
        }

        #region 窗体移动
        /// <summary>
        /// 开始通过 panelBar 拖动窗体。
        /// </summary>
        private void panelBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            // 如果当前还处于隐藏状态，先直接结束隐藏状态。
            // 用户已经主动按住拖动条准备移动窗体，此时不应该再播放自动展开动画。
            if (EnableAutoHideDock && dockSide != DockSide.None && isHidden)
            {
                slideTimer.Stop();
                Point location = GetDockShownLocation(dockScreen, dockSide, this.Location);
                this.Location = location;
                isHidden = false;
            }
            else
            {
                // 停止可能仍在执行的吸附 / 展开动画。
                slideTimer.Stop();
            }

            formPoint.X = -e.X;
            formPoint.Y = -e.Y;

            isUserDragging = true;
        }

        /// <summary>
        /// 用户通过 panelBar 拖动窗体。
        /// </summary>
        private void panelBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || !isUserDragging)
                return;

            // 1. 按照原来的方式移动窗体
            Point position = Control.MousePosition;
            position.Offset(formPoint.X, formPoint.Y - (richTextBoxContent.Height + richTextBoxContent.Location.Y + richTextBoxContent.Margin.Top));
            this.DesktopLocation = position;

            // 2. 自动贴边功能关闭时，后续所有贴边判断都不执行
            if (!EnableAutoHideDock)
                return;

            // 3. 获取鼠标当前真正所在的显示器
            // 用户通过 panelBar 拖动时，鼠标所在显示器就是当前用户操作的目标显示器。
            Screen currentScreen = Screen.FromPoint(Control.MousePosition);

            // 4. 如果当前处于贴边模式，但鼠标已经拖到了另一块显示器，必须立即退出旧显示器的贴边状态
            if (dockSide != DockSide.None && dockScreen != null && currentScreen.DeviceName != dockScreen.DeviceName)
            {
                // 已经贴边的窗体被直接拖到另一块显示器，原来的 dockScreen / dockSide 已经失效，立即退出旧显示器的贴边模式。
                // 当前仍然处于用户拖动过程中，不立即在新显示器执行自动贴边。
                // 等用户松开鼠标后，panelBar_MouseUp 会根据新显示器重新执行CheckAutoDock()。
                ExitDockMode();
                return;
            }

            // 5. 当前已经处于贴边模式
            if (dockSide != DockSide.None)
            {
                // 已经贴边的窗体展开后，用户只要向屏幕内部拖动 UndockDragDistance，就立即解除贴边。
                // 这个判断需要在 MouseMove 中实时执行，因为我们希望用户一开始往屏幕内部拖，窗体就立即恢复普通自由拖动状态。
                CheckExitDockMode();
            }
        }

        /// <summary>
        /// 用户结束通过 panelBar 拖动窗体。
        /// </summary>
        private void panelBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            // 鼠标释放后，用户主动拖动状态结束。
            isUserDragging = false;
            if (!EnableAutoHideDock)
                return;

            // ========================================================
            // 根据用户拖动结束时的最终位置确认贴边状态
            // ========================================================
            // 普通自由悬浮状态下，拖动过程中不执行自动贴边，只有用户释放鼠标以后，才根据窗体最终位置判断是否已经超出某个真实屏幕边缘 DockTriggerDistance。
            // 这样可以保证拖动过程中窗体完全由鼠标控制，不会因为 slideTimer 同时修改 Location 而产生抖动。
            // 如果当前本来就处于贴边模式，则再做一次最终的解除贴边判断。
            if (dockSide == DockSide.None)
            {
                // 当前是普通模式，根据最终位置判断是否进入自动贴边模式。
                CheckAutoDock();
            }
            else
            {
                // 当前仍处于贴边模式，最终确认一次是否应该解除贴边。
                CheckExitDockMode();
            }
        }

        /// <summary>
        /// 鼠标进入拖动区域时显示移动光标。
        /// </summary>
        private void panelBar_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.SizeAll;
        }

        /// <summary>
        /// 鼠标离开拖动区域时恢复默认光标。
        /// </summary>
        private void panelBar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// panelBar 丢失鼠标捕获时，强制结束用户拖动状态。
        /// 防止某些特殊情况下 MouseUp 没有正常到达 panelBar，导致 isUserDragging 一直保持 true。
        /// </summary>
        private void panelBar_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (panelBar.Capture)
            {
                return;
            }

            bool wasDragging = isUserDragging;
            isUserDragging = false;
            // 如果确实是在拖动过程中意外丢失鼠标捕获，做一次最终的贴边状态确认。
            if (wasDragging && EnableAutoHideDock)
            {
                if (dockSide == DockSide.None)
                {
                    CheckAutoDock();
                }
                else
                {
                    CheckExitDockMode();
                }
            }
        }
        #endregion

        private void buttonTop_Click(object sender, EventArgs e)
        {
            if (this.TopMost)
            {
                this.TopMost = false;
                buttonTop.Text = "↓";
                toolTipInfo.SetToolTip(buttonTop, "钉住(Ctrl+↓)");
                ToolStripMenuItemTop.Text = "钉住(置顶)";
            }
            else
            {
                this.TopMost = true;
                buttonTop.Text = "↑";
                toolTipInfo.SetToolTip(buttonTop, "拔出(Ctrl+↑)");
                ToolStripMenuItemTop.Text = "拔出(取消置顶)";
            }
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBoxContent.BackColor = colorDialog.Color;
            }
        }

        private void richTextBoxContent_BackColorChanged(object sender, EventArgs e)
        {
            this.BackColor = richTextBoxContent.BackColor;
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button)
                    ctrl.BackColor = richTextBoxContent.BackColor;
            }
        }

        /// <summary>
        /// 获取提醒事项列表
        /// </summary>
        /// <param name="autoBind">是否自动绑定到控件，默认是</param>
        private void GetReminderList(bool autoBind = true)
        {
            if (reminderDict == null)
                reminderDict = new Dictionary<int, Reminder>();
            else if (reminderDict.Count > 0)
                reminderDict.Clear();
            string sql = "select r.ID, r.Content, r.Status, t.ID as ToDoID, t.ProjectID, p.Name as ProjectName, t.BranchID, b.Name as BranchName, t.RelatedID, t.Priority, t.Severity, t.Title, t.Content as ToDoContent, t.[Memo], t.UserID, u.Name as UserName, t.PlannedStartTime, t.PlannedEndTime, t.PlannedHours, t.PlannedDays, t.Status as ToDoStatus, t.FinishTime, t.FinishUserID, uf.Name as FinishUserName from ((((Reminder r left join ToDo t on r.ToDoID = t.ID) left join Project p on t.ProjectID = p.ID) left join Branch b on t.BranchID = b.ID) left join [User] u on t.UserID = u.ID) left join [User] uf on t.FinishUserID = uf.ID where r.Status = 0 order by r.ID desc";
            DataTable dt = CommonData.SQLiteHelper.GetDataTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    Reminder reminder = new Reminder
                    {
                        ID = DataConvert.ToDecimal(row["ID"]),
                        Content = DataConvert.ToString(row["Content"]),
                        Status = DataConvert.ToNullableInt(row["Status"])
                    };
                    decimal? toDoID = DataConvert.ToNullableDecimal(row["ToDoID"]);
                    if (toDoID.HasValue)
                    {
                        reminder.ToDo = new ToDo
                        {
                            ID = DataConvert.ToDecimal(row["ToDoID"]),
                            RelatedID = DataConvert.ToString(row["RelatedID"]),
                            Priority = (EnumToDoPriority?)DataConvert.ToEnum<EnumToDoPriority>(row["Priority"]),
                            Severity = (EnumToDoSeverity?)DataConvert.ToEnum<EnumToDoSeverity>(row["Severity"]),
                            Title = DataConvert.ToString(row["Title"]),
                            Content = DataConvert.ToString(row["ToDoContent"]),
                            Memo = DataConvert.ToString(row["Memo"]),
                            PlannedStartTime = DataConvert.ToNullableDateTime(row["PlannedStartTime"]),
                            PlannedEndTime = DataConvert.ToNullableDateTime(row["PlannedEndTime"]),
                            PlannedHours = DataConvert.ToNullableDecimal(row["PlannedHours"]),
                            PlannedDays = DataConvert.ToNullableDecimal(row["PlannedDays"]),
                            Status = (EnumToDoStatus?)DataConvert.ToEnum<EnumToDoStatus>(row["ToDoStatus"]),
                            FinishTime = DataConvert.ToNullableDateTime(row["FinishTime"]),
                        };
                        int projectID = DataConvert.ToInt(row["ProjectID"]);
                        string projectName = DataConvert.ToString(row["ProjectName"]);
                        if (projectID > 0 || !string.IsNullOrWhiteSpace(projectName))
                            reminder.ToDo.Project = new Project() { ID = projectID, Name = projectName };
                        int branchID = DataConvert.ToInt(row["BranchID"]);
                        string branchName = DataConvert.ToString(row["BranchName"]);
                        if (branchID > 0 || !string.IsNullOrWhiteSpace(branchName))
                            reminder.ToDo.Branch = new Branch() { ID = branchID, Name = branchName };//, Project = toDo.Project
                        int userID = DataConvert.ToInt(row["UserID"]);
                        string userName = DataConvert.ToString(row["UserName"]);
                        if (userID > 0 || !string.IsNullOrWhiteSpace(userName))
                            reminder.ToDo.User = new User() { ID = userID, Name = userName };
                        int finishUserID = DataConvert.ToInt(row["FinishUserID"]);
                        string finishUserName = DataConvert.ToString(row["FinishUserName"]);
                        if (finishUserID > 0 || !string.IsNullOrWhiteSpace(finishUserName))
                            reminder.ToDo.FinishUser = new User() { ID = finishUserID, Name = finishUserName };
                    }
                    reminderDict.Add(i, reminder);
                }
            }
            if (autoBind)
                BindReminder(0);
        }

        private void BindReminder(int index = 0)
        {
            richTextBoxContent.TextChanged -= richTextBoxContent_TextChanged;
            try
            {
                richTextBoxContent.Text = string.Empty;
                originalContent = string.Empty;
                richTextBoxContent.Tag = null;
                if (index < 0 || index >= reminderDict?.Count)
                {
                    isAdding = true;
                    return;
                }
                Reminder reminder = reminderDict[index];
                if (reminder == null)
                    return;
                richTextBoxContent.Text = reminder.Content;
                originalContent = reminder.Content;
                richTextBoxContent.Tag = reminder;
                currentIndex = index;
                isAdding = false;
                if (reminder.ToDo?.ID > 0 && richTextBoxContent.Text.Contains("延期时长："))
                {
                    //简单判断，只找最前面的对应文字，如果对应文字有多个，后面的可能是正常内容
                    richTextBoxContent.Select(richTextBoxContent.Text.IndexOf("延期时长："), "延期时长：".Length);
                    richTextBoxContent.SelectionColor = Color.Red;
                    richTextBoxContent.Select(0, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "提醒事项绑定出错" + Environment.NewLine + ex.Message, "绑定出错");
            }
            finally
            {
                richTextBoxContent.TextChanged += richTextBoxContent_TextChanged;
            }
        }

        private void reminderChangedToSave()
        {
            if (richTextBoxContent.Text == originalContent)
            {
                setSaveButtonColorByContentChanged(false);
                return;
            }
            if (MessageBox.Show(this, "内容已变更，是否保存？", "待办事项", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk) != DialogResult.Yes)
            {
                return;
            }
            buttonSave.PerformClick();
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            reminderChangedToSave();
            if (reminderDict?.Count == 0)
                return;
            int index = currentIndex;
            if (currentIndex == 0)
                index = reminderDict.Count - 1;
            else
                index = currentIndex - 1;
            BindReminder(index);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            reminderChangedToSave();
            if (reminderDict?.Count == 0)
                return;
            int index = currentIndex;
            if (currentIndex == reminderDict.Count - 1)
                index = 0;
            else
                index = currentIndex + 1;
            BindReminder(index);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            reminderChangedToSave();
            BindReminder(-1);
            isAdding = true;
        }

        private void setSaveButtonColorByContentChanged(bool contentChanged = true)
        {
            if (contentChanged)
            {
                if (buttonSave.ForeColor != Color.Red)
                    buttonSave.ForeColor = Color.Red;
            }
            else
            {
                if (buttonSave.ForeColor != SystemColors.ControlText)
                    buttonSave.ForeColor = SystemColors.ControlText;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (isAdding)
            {
                SqlParams paramDict = new SqlParams();
                paramDict.Add("Content", richTextBoxContent.Text);
                paramDict.Add("Status", 0);
                decimal id = CommonData.SQLiteHelper.InsertAndReturnNewIdentity("Reminder", paramDict);
                setSaveButtonColorByContentChanged(false);
                isAdding = false;
                originalContent = richTextBoxContent.Text;
                int index = reminderDict.Count;
                Reminder reminder = new Reminder() { ID = id, Content = richTextBoxContent.Text, Status = 0 };
                reminderDict.Add(index, reminder);
                richTextBoxContent.Tag = reminder;
                currentIndex = index;
            }
            else
            {
                if (richTextBoxContent.Text == originalContent)
                {
                    setSaveButtonColorByContentChanged(false);
                    return;
                }
                if (richTextBoxContent.Tag == null || !(richTextBoxContent.Tag is Reminder reminder) || reminder == null || reminder.ID <= 0)
                {
                    MessageBox.Show("数据错误。", "提示");
                    return;
                }
                //decimal id;
                //if (!decimal.TryParse(richTextBoxContent.Tag.ToString(), out id))
                //{
                //    MessageBox.Show("数据错误，ID错误。", "提示");
                //    return;
                //}
                SqlParams setParamDict = new SqlParams();
                setParamDict.Add("Content", richTextBoxContent.Text);
                SqlParams whereParamDict = new SqlParams();
                //whereParamDict.Add("ID", id);
                whereParamDict.Add("ID", reminder.ID); 
                CommonData.SQLiteHelper.Update("Reminder", setParamDict, whereParamDict);
                setSaveButtonColorByContentChanged(false);
                originalContent = richTextBoxContent.Text;
                //KeyValuePair<int, Reminder> pair = reminderDict.FirstOrDefault(r => r.Value.ID == id);
                KeyValuePair<int, Reminder> pair = reminderDict.FirstOrDefault(r => r.Value.ID == reminder.ID);
                if (pair.Value != null)
                    pair.Value.Content = richTextBoxContent.Text;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "确认完成/删除此事项？", "待办事项", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk) != DialogResult.Yes)
                return;
            reminderChangedToSave();
            if (isAdding)
                BindReminder(-1);
            else
            {
                if (richTextBoxContent.Tag == null || !(richTextBoxContent.Tag is Reminder reminder) || reminder == null || reminder.ID <= 0)
                {
                    MessageBox.Show("数据错误。", "提示");
                    return;
                }
                //decimal id;
                //if (!decimal.TryParse(richTextBoxContent.Tag.ToString(), out id))
                //{
                //    MessageBox.Show("数据错误，ID错误。", "提示");
                //    return;
                //}
                SqlParams setParamDict = new SqlParams();
                setParamDict.Add("Status", 1);
                SqlParams whereParamDict = new SqlParams();
                //whereParamDict.Add("ID", id);
                whereParamDict.Add("ID", reminder.ID);
                CommonData.SQLiteHelper.Update("Reminder", setParamDict, whereParamDict);
                reminderDict.Remove(currentIndex);
                Dictionary<int, Reminder> newDict = new Dictionary<int, Reminder>();
                foreach (KeyValuePair<int, Reminder> pair in reminderDict)
                {
                    if (pair.Key >= currentIndex)
                        newDict.Add(pair.Key - 1, pair.Value);
                    else
                        newDict.Add(pair.Key, pair.Value);
                }
                reminderDict.Clear();
                reminderDict = newDict;
                if (currentIndex == 0)
                    currentIndex = reminderDict.Count - 1;
                else
                    currentIndex--;
                BindReminder(currentIndex);
                //if (reminder.ToDo != null && reminder.ToDo.ID > 0)
                //    MessageBox.Show("如有需要，请手动在待办事项程序中修改状态。", "提示");
                if (reminder.ToDo == null || reminder.ToDo.ID <= 0)
                    return;
                if (MessageBox.Show(this, "待办事项是否已完成？" + Environment.NewLine + "若选择【是】，会更新待办事项状态为【已完成】。", "待办事项", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk) != DialogResult.Yes)
                    return;
                ToDoList.ToDoCommon.ToDoDone(reminder.ToDo, this);
            }
        }

        private void notifyIconNofity_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //if (this.Visible)
            //{
            //    //notifyIconNofity.Visible = true;
            //    this.Hide();
            //}
            //else
            //{
            //    this.Show();
            //    this.Activate();
            //}
            this.Show();
            this.Activate();
        }

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            //this.Close();
            //this.Dispose();
            notifyIconNofity.Visible = false;
            System.Environment.Exit(0);
        }

        private void ToolStripMenuItemTop_Click(object sender, EventArgs e)
        {
            buttonTop.PerformClick();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsSetting)
            {
                this.SettingTopMost = this.TopMost;
                this.SettingBackColor = richTextBoxContent.BackColor;
                this.SettingStartPosition = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Right, this.Location.Y);
                notifyIconNofity.Visible = false;
            }
            else if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                //notifyIconNofity.Visible = true;
                this.Hide();
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            reminderChangedToSave();
            //List<Reminder> reminders = reminderDict.Values.ToList();
            //reminders.IndexOf();
            //reminders.FindIndex();
            Reminder originalReminder = null;
            if (richTextBoxContent.Tag != null && richTextBoxContent.Tag is Reminder)
                originalReminder = richTextBoxContent.Tag as Reminder;
            GetReminderList(false);
            int index = 0;
            if (originalReminder != null && reminderDict?.Count > 0 && originalReminder.ID > 0)
            {
                foreach (KeyValuePair<int, Reminder> pair in reminderDict)
                {
                    if (pair.Value != null && pair.Value.ID == originalReminder.ID)
                    {
                        index = pair.Key;
                        break;
                    }
                }
            }
            BindReminder(index);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (IsSetting)
                return;
            if (reminderDict == null || reminderDict.Count == 0)
            {
                string tileCommand = CommonData.IniHelper.Read("ReminderTile", "StartupCommandWhenNoItem");
                if (!tileCommand.IsNullOrWhiteSpace())
                {
                    switch (tileCommand.ToLower())
                    {
                        case "hide":
                            buttonClose.PerformClick();
                            break;
                        case "exit":
                            //Application.Exit();
                            ToolStripMenuItemExit_Click(sender, e);
                            break;
                        case "nocommand":
                        default:
                            break;
                    }
                }
            }
        }

        private void richTextBoxContent_Leave(object sender, EventArgs e)
        {
            //reminderChangedToSave();
        }

        private void richTextBoxContent_TextChanged(object sender, EventArgs e)
        {
            setSaveButtonColorByContentChanged();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            //注意需设置窗体KeyPreview属性为True，避免焦点落到子控件后不触发此事件
            if (e.KeyCode == Keys.R && e.Control)//刷新
            {
                buttonRefresh.PerformClick();
                e.Handled = true;//不再触发KeyPress事件
            }
            else if (e.KeyCode == Keys.Left && e.Control)//上一个
            {
                buttonPrevious.PerformClick();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Right && e.Control)//下一个
            {
                buttonNext.PerformClick();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.N && e.Control)//新增
            {
                buttonAdd.PerformClick();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.S && e.Control)//保存
            {
                buttonSave.PerformClick();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.D && e.Control)//完成/删除
            {
                buttonDelete.PerformClick();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up && e.Control)//拔出(取消置顶)
            {
                if (this.TopMost)
                {
                    buttonTop.PerformClick();
                    e.Handled = true;
                }
            }
            else if (e.KeyCode == Keys.Down && e.Control)//钉住(置顶)
            {
                if (!this.TopMost)
                {
                    buttonTop.PerformClick();
                    e.Handled = true;
                }
            }
            else if (e.KeyCode == Keys.L && e.Control)//颜色
            {
                buttonColor.PerformClick();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.W && e.Control)//关闭
            {
                buttonClose.PerformClick();
                e.Handled = true;
            }
        }

        // ============================================================
        // 鼠标进入处理
        // ============================================================

        /// <summary>
        /// 递归给窗体及其所有子控件注册 MouseEnter 事件。
        /// 这样即使子控件铺满整个无边框窗体，也能检测到鼠标进入。
        /// </summary>
        private void RegisterMouseEnter(Control parent)
        {
            parent.MouseEnter += Control_MouseEnter;

            foreach (Control control in parent.Controls)
            {
                RegisterMouseEnter(control);
            }
        }

        /// <summary>
        /// 鼠标进入窗体或任意子控件
        /// </summary>
        private void Control_MouseEnter(object sender, EventArgs e)
        {
            // 如果已经进入自动贴边模式，并且当前处于隐藏状态，则优先把窗体滑出来。
            if (EnableAutoHideDock && dockSide != DockSide.None && isHidden)
            {
                ShowDockWindow();
            }


            // 如果启用了透明度效果，鼠标进入以后恢复完全不透明。
            // 即使当前正处于淡出过程中，修改 targetOpacity 后动画也会自然反向。
            if (EnableOpacityEffect)
            {
                FadeTo(ActiveOpacity);
            }


            // 只要当前有某个功能需要知道鼠标何时离开，就启动 mouseCheckTimer。
            // Timer 已经运行时不会重复启动。
            if (NeedMouseLeaveCheck() && !mouseCheckTimer.Enabled)
            {
                mouseCheckTimer.Start();
            }
        }

        // ============================================================
        // 鼠标离开检测
        // ============================================================

        /// <summary>
        /// 判断当前是否有必要监控鼠标离开。
        /// </summary>
        private bool NeedMouseLeaveCheck()
        {
            // 透明度功能开启：需要知道鼠标什么时候离开。
            if (EnableOpacityEffect)
            {
                return true;
            }

            // 自动贴边功能虽然开启，但只有真正进入贴边模式以后，才需要检测鼠标离开。
            if (EnableAutoHideDock && dockSide != DockSide.None && !isHidden)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 检查鼠标是否真正离开了整个窗体
        /// </summary>
        private void MouseCheckTimer_Tick(object sender, EventArgs e)
        {
            // 用户正在主动拖动窗体时，不执行鼠标离开逻辑。
            // 特别是在不同 DPI 的显示器之间拖动时，WinForms 可能调整窗体位置 / 尺寸，某一个瞬间 Cursor.Position 可能暂时不落在新的 Bounds 内。
            // 此时绝不能把它误认为真正的“鼠标离开窗体”，否则可能在用户拖动过程中触发透明度降低或自动隐藏。
            if (isUserDragging)
            {
                return;
            }

            // 判断鼠标是否仍然位于窗体的有效悬停区域。
            // 普通状态：只包括窗体 Bounds。
            // 自动贴边状态：还包括窗体与屏幕边缘之间 DockShowMargin 的空白区域。
            if (IsMouseInActiveArea())
            {
                return;
            }

            // 鼠标已经真正离开窗体的有效区域，立即停止检测，防止窗体外长期进行无意义轮询。
            mouseCheckTimer.Stop();

            // ========================================================
            // 自动贴边隐藏优先
            // ========================================================
            // 如果：
            // 1. 自动隐藏功能已开启；
            // 2. 当前已经进入贴边模式；
            // 3. 当前窗体仍然完整显示；
            // 那么鼠标离开后优先执行贴边隐藏。
            // 此时不再同时降低透明度，避免“一边滑走一边变透明”导致视觉效果过度。
            if (EnableAutoHideDock && dockSide != DockSide.None && !isHidden)
            {
                // 如果透明度之前不是 1.0，在隐藏前恢复到正常透明度。
                // 这样隐藏后露出来的 10px 不会本身还是半透明的。
                if (EnableOpacityEffect)
                {
                    FadeTo(ActiveOpacity);
                }
                HideDockWindow();
                return;
            }


            // ========================================================
            // 普通状态下执行透明度降低
            // ========================================================
            // 没有进入贴边隐藏模式时，如果启用了透明度效果，鼠标离开后降低透明度。
            if (EnableOpacityEffect)
            {
                FadeTo(InactiveOpacity);
            }
        }

        // ============================================================
        // 透明度动画
        // ============================================================

        /// <summary>
        /// 设置目标透明度，并启动渐变动画。
        /// </summary>
        private void FadeTo(double opacity)
        {
            if (!EnableOpacityEffect)
            {
                return;
            }

            targetOpacity = opacity;

            // 如果已经非常接近目标透明度，就直接设置最终值。没有必要启动 Timer。
            if (Math.Abs(this.Opacity - targetOpacity) <= FadeMinDifference)
            {
                this.Opacity = targetOpacity;
                fadeTimer.Stop();
                return;
            }

            // fadeTimer 只在真正发生透明度动画时运行。
            if (!fadeTimer.Enabled)
            {
                fadeTimer.Start();
            }
        }

        /// <summary>
        /// 使用 Ease-Out 方式进行透明度渐变
        /// </summary>
        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            double difference = targetOpacity - this.Opacity;

            // 已经足够接近目标透明度，直接设置最终值并结束动画。
            if (Math.Abs(difference) <= FadeMinDifference)
            {
                this.Opacity = targetOpacity;
                fadeTimer.Stop();
                return;
            }

            // 每次移动剩余距离的一部分。
            // 例如：当前：0.50，目标：1.00，FadeEasing：0.08
            // 第一次：(1.00 - 0.50) × 0.08
            // 随着越来越接近目标，每次变化量越来越小。
            // 因此形成：开始较快→逐渐减速→平滑到达目标 的 Ease-Out 效果。
            this.Opacity += difference * FadeEasing;
        }

        // ============================================================
        // 用户拖动窗体后的自动贴边判断
        // ============================================================

        /// <summary>
        /// 判断用户是否把窗体拖出某个显示器的真实外边缘。
        /// </summary>
        private void CheckAutoDock()
        {
            if (!EnableAutoHideDock)
            {
                return;
            }

            // ========================================================
            // 获取当前用户正在操作的显示器
            // ========================================================
            // 这里不能使用：Screen.FromRectangle(this.Bounds)
            // 因为跨屏拖动过程中，窗体可能同时横跨两个显示器。
            // FromRectangle 会根据窗体主要位于哪一个显示器来选择 Screen，这会产生一个问题：
            // 例如：
            //          副屏
            //     ┌───────────┐
            //     │             │
            //     └───────────┘
            //          主屏
            //     ┌───────────┐
            //     │             │
            //     └───────────┘
            // 用户把窗体从主屏向上拖到副屏时，即使鼠标已经进入副屏，只要窗体大部分还在主屏，FromRectangle 仍然可能返回主屏。
            // 这样就会把“进入副屏”错误判断成“超出主屏顶部”，从而触发主屏顶部自动停靠。
            // 对于本程序来说，用户是通过 panelBar 拖动窗体的，因此鼠标所在的显示器最能代表：“用户当前正在把窗体拖向哪一个显示器”。
            // 所以这里使用 Screen.FromPoint(Control.MousePosition)。
            // 当鼠标进入副屏以后，后续所有贴边判断立即切换到副屏。
            Screen screen = Screen.FromPoint(Control.MousePosition);

            // WorkingArea 用于计算真正允许窗体显示的工作区域。它会自动排除任务栏等区域。
            // 注意：多屏幕之间是否相邻，不使用 WorkingArea 判断，而是在 IsRealOuterEdge() 中使用 Screen.Bounds。
            Rectangle area = screen.WorkingArea;

            // ========================================================
            // 计算窗体超出当前显示器四个方向多少像素
            // ========================================================
            int overflowLeft = area.Left - this.Left;
            int overflowRight = this.Right - area.Right;
            int overflowTop = area.Top - this.Top;
            int overflowBottom = this.Bottom - area.Bottom;

            // 只有超出达到 DockTriggerDistance，才认为用户确实想进行自动贴边。
            bool triggerLeft = overflowLeft >= DockTriggerDistance;
            bool triggerRight = overflowRight >= DockTriggerDistance;
            bool triggerTop = overflowTop >= DockTriggerDistance;
            bool triggerBottom = overflowBottom >= DockTriggerDistance;


            // 当前窗体没有任何一条边超出当前显示器达到触发距离。
            // 说明用户只是正常在这个显示器内部拖动，不执行任何贴边逻辑。
            if (!triggerLeft && !triggerRight && !triggerTop && !triggerBottom)
            {
                return;
            }

            // ========================================================
            // 多屏幕真实外边缘判断
            // ========================================================
            // 这里非常重要。
            // 窗体虽然可能超出了当前显示器，但超出的方向不一定是真正的桌面边缘。
            // 例如如下布局：
            //        副屏
            // ┌─────────────┐
            // └─────────────┘
            //        主屏
            // ┌─────────────┐
            // └─────────────┘
            // 主屏顶部和副屏底部属于两个显示器之间的内部边界。
            // 用户从主屏向上拖：这是跨屏
            // 而不是：主屏顶部停靠。
            // 因此必须排除这些多屏内部边界。
            if (triggerLeft && !IsRealOuterEdge(screen, DockSide.Left))
            {
                triggerLeft = false;
            }
            if (triggerRight && !IsRealOuterEdge(screen, DockSide.Right))
            {
                triggerRight = false;
            }
            if (triggerTop && !IsRealOuterEdge(screen, DockSide.Top))
            {
                triggerTop = false;
            }
            if (triggerBottom && !IsRealOuterEdge(screen, DockSide.Bottom))
            {
                triggerBottom = false;
            }

            // 排除多屏内部边界以后，如果已经没有任何方向符合条件，说明这只是正常的跨显示器拖动。
            if (!triggerLeft && !triggerRight && !triggerTop && !triggerBottom)
            {
                return;
            }

            // ========================================================
            // 如果同时触发两个方向，选择超出最多的方向
            // ========================================================
            // 用户拖到屏幕角落时，可能同时超出两个方向。
            // 例如：左侧超出：20px，顶部超出：35px，此时认为用户更倾向于顶部贴边。
            DockSide side = DockSide.None;
            int maxOverflow = -1;
            if (triggerLeft && overflowLeft > maxOverflow)
            {
                side = DockSide.Left;
                maxOverflow = overflowLeft;
            }
            if (triggerRight && overflowRight > maxOverflow)
            {
                side = DockSide.Right;
                maxOverflow = overflowRight;
            }
            if (triggerTop && overflowTop > maxOverflow)
            {
                side = DockSide.Top;
                maxOverflow = overflowTop;
            }
            if (triggerBottom && overflowBottom > maxOverflow)
            {
                side = DockSide.Bottom;
                maxOverflow = overflowBottom;
            }
            if (side != DockSide.None)
            {
                // CheckAutoDock() 只在用户结束拖动后调用，满足贴边条件时正式进入自动贴边模式。
                EnterDockMode(screen, side);
            }
        }

        /// <summary>
        /// 检查用户是否正在主动把已经贴边展开的窗体向屏幕内部拖动。
        /// 当窗体相对于正常贴边展开位置向屏幕内部移动达到 UndockDragDistance 后，自动解除贴边隐藏模式，恢复普通自由悬浮状态。
        /// 注意：UndockDragDistance 表示的是“从正常贴边展开位置继续向屏幕内部拖动的距离”，而不是“窗体边缘与屏幕边缘之间的总距离”。
        /// 例如：DockShowMargin = 8，UndockDragDistance = 1，右侧贴边窗体完整展开后，窗体右边缘距离屏幕右边缘为 8px；用户再向左拖动 1px，使这个距离变成 9px，即认为用户有解除贴边的意图。
        /// </summary>
        private void CheckExitDockMode()
        {
            // 自动贴边功能关闭，或者当前本来就没有处于贴边模式，不需要处理。
            if (!EnableAutoHideDock || dockSide == DockSide.None || dockScreen == null)
            {
                return;
            }
            // 窗体处于隐藏状态时不允许解除贴边。
            // 正常情况下鼠标进入隐藏窗体露出的区域以后，ShowDockWindow() 会先把窗体完整展开，用户之后才能通过 panelBar 拖动窗体。
            if (isHidden)
            {
                return;
            }

            Rectangle area = dockScreen.WorkingArea;
            bool shouldExit = false;

            switch (dockSide)
            {
                case DockSide.Left:
                    // 左侧贴边正常展开位置：Left = area.Left + DockShowMargin，用户向右拖动 UndockDragDistance 像素后即解除贴边。
                    shouldExit = this.Left >= area.Left + DockShowMargin + UndockDragDistance;
                    break;
                case DockSide.Right:
                    // 右侧贴边正常展开位置：Right = area.Right - DockShowMargin，用户向左拖动 UndockDragDistance 像素后即解除贴边。
                    shouldExit = this.Right <= area.Right - DockShowMargin - UndockDragDistance;
                    break;
                case DockSide.Top:
                    // 顶部贴边正常展开位置：Top = area.Top + DockShowMargin，用户向下拖动后解除贴边。
                    shouldExit = this.Top >= area.Top + DockShowMargin + UndockDragDistance;
                    break;
                case DockSide.Bottom:
                    // 底部贴边正常展开位置：Bottom = area.Bottom - DockShowMargin，用户向上拖动后解除贴边。
                    shouldExit = this.Bottom <= area.Bottom - DockShowMargin - UndockDragDistance;
                    break;
            }
            if (shouldExit)
            {
                ExitDockMode();
            }
        }

        /// <summary>
        /// 退出自动贴边隐藏模式，恢复为普通自由悬浮窗。
        /// 非常重要：
        /// 这里不修改窗体 Location。
        /// 用户把窗体拖到哪里，解除贴边以后就继续停留在哪里。
        /// 因此整个操作对用户来说不会发生跳动。
        /// </summary>
        private void ExitDockMode()
        {
            // ========================================================
            // 停止可能还存在的滑动动画
            // ========================================================
            slideTimer.Stop();

            // ========================================================
            // 清除自动贴边状态
            // ========================================================
            // DockSide.None 就表示：当前已经重新回到普通自由悬浮模式。
            dockSide = DockSide.None;
            dockScreen = null;
            isHidden = false;

            // ========================================================
            // 恢复普通透明度逻辑
            // ========================================================
            if (EnableOpacityEffect)
            {
                // 此时用户仍然正在通过 panelBar 拖动窗体，所以鼠标位于窗体内部。因此保持完全不透明。
                // 等用户之后真正把鼠标移出整个窗体，原来的 MouseCheckTimer 会负责：ActiveOpacity → InactiveOpacity
                FadeTo(ActiveOpacity);
            }

            // ========================================================
            // 恢复普通鼠标离开检测
            // ========================================================
            // 如果启用了透明度功能，普通悬浮状态仍然需要知道鼠标什么时候离开。
            UpdateMouseCheckTimer();
        }

        /// <summary>
        /// 判断鼠标当前是否仍然位于窗体的有效悬停区域内。
        /// 普通自由悬浮状态：只判断鼠标是否位于窗体 Bounds 内。
        /// 自动贴边展开状态：除了窗体 Bounds 本身，还把窗体与所停靠屏幕边缘之间的空白区域也认为属于有效悬停区域。
        /// 这是因为窗体展开后会通过 DockShowMargin 与屏幕边缘保持一定距离。
        /// 如果鼠标停留在屏幕最边缘，严格判断 this.Bounds 会认为鼠标已经离开窗体，从而导致：展开 → 鼠标不在 Bounds → 隐藏 → MouseEnter → 展开 不断循环，表现为窗体左右 / 上下跳动。
        /// </summary>
        private bool IsMouseInActiveArea()
        {
            Point mousePosition = Cursor.Position;

            // ========================================================
            // 普通自由悬浮状态
            // ========================================================
            // 普通状态或者当前已经隐藏时，只按窗体自身 Bounds 判断。
            // 隐藏状态下窗体本身仍有 HiddenVisibleSize 像素位于屏幕内，MouseEnter 就依靠这部分触发重新展开。
            if (!EnableAutoHideDock || dockSide == DockSide.None || dockScreen == null || isHidden)
            {
                return this.Bounds.Contains(mousePosition);
            }

            // ========================================================
            // 自动贴边状态
            // ========================================================
            // 只有自动贴边且完整展开时，才把窗体与屏幕边缘之间的 DockShowMargin 也视为有效悬停区域。
            Rectangle activeArea = this.Bounds;
            Rectangle screenArea = dockScreen.WorkingArea;

            switch (dockSide)
            {
                case DockSide.Left:
                    // 左侧停靠：
                    // 屏幕左边缘
                    // │
                    // │ DockShowMargin ┌──────────┐
                    // │<--           ->│    窗体     │
                    // 把窗体左边缘到屏幕左边缘之间的区域也加入有效悬停范围。
                    activeArea = Rectangle.FromLTRB(screenArea.Left, activeArea.Top, activeArea.Right, activeArea.Bottom);
                    break;
                case DockSide.Right:
                    // 右侧停靠：
                    // ┌──────────┐ DockShowMargin │
                    // │    窗体     │<--           ->│
                    //                     │ 屏幕右边缘
                    // 把窗体右边缘到屏幕右边缘之间的区域也加入有效悬停范围。
                    activeArea = Rectangle.FromLTRB(activeArea.Left, activeArea.Top, screenArea.Right, activeArea.Bottom);
                    break;
                case DockSide.Top:
                    // 顶部停靠：把窗体顶部到屏幕顶部之间的空白区域加入有效悬停范围。
                    activeArea = Rectangle.FromLTRB(activeArea.Left, screenArea.Top, activeArea.Right, activeArea.Bottom);
                    break;
                case DockSide.Bottom:
                    // 底部停靠：把窗体底部到屏幕底部之间的空白区域加入有效悬停范围。
                    activeArea = Rectangle.FromLTRB(activeArea.Left, activeArea.Top, activeArea.Right, screenArea.Bottom);
                    break;
            }
            return activeArea.Contains(mousePosition);
        }

        // ============================================================
        // 多屏幕真实外边缘判断
        // ============================================================

        /// <summary>
        /// 判断指定显示器的某个边缘，是否是整个多屏桌面的真实外边缘。
        ///
        /// 注意：
        ///
        /// 这里使用 Screen.Bounds，而不是 WorkingArea。
        ///
        /// Bounds 表示显示器本身在虚拟桌面中的实际区域，
        /// 适合判断多个显示器之间的位置关系。
        ///
        /// WorkingArea 会受到任务栏等桌面保留区域影响，
        /// 不适合用于判断显示器之间是否真正相邻。
        ///
        /// WorkingArea 应该只用于后续计算窗体真正的停靠位置。
        /// </summary>
        private bool IsRealOuterEdge(Screen currentScreen, DockSide side)
        {
            Rectangle current = currentScreen.Bounds;
            foreach (Screen otherScreen in Screen.AllScreens)
            {
                if (otherScreen.DeviceName == currentScreen.DeviceName)
                {
                    continue;
                }
                Rectangle other = otherScreen.Bounds;
                switch (side)
                {
                    case DockSide.Left:
                        // 当前屏幕左边存在另一个显示器，并且两个显示器在垂直方向存在重叠，那么当前屏幕的左侧就不是整个桌面的真实外边缘。
                        // 例如：
                        // ┌───────┐┌───────┐
                        // │ 屏幕 2  ││ 屏幕 1  │
                        // └───────┘└───────┘
                        //            ↑
                        //         内部边界
                        if (other.Right <= current.Left && HasVerticalOverlap(current, other))
                        {
                            // 判断两个屏幕是否真正相邻。
                            // 使用 DockTriggerDistance 作为少量坐标误差容忍值。
                            if (other.Right >= current.Left - DockTriggerDistance)
                            {
                                return false;
                            }
                        }
                        break;
                    case DockSide.Right:
                        // 当前屏幕右边存在另一个显示器。
                        if (other.Left >= current.Right && HasVerticalOverlap(current, other))
                        {
                            if (other.Left <= current.Right + DockTriggerDistance)
                            {
                                return false;
                            }
                        }
                        break;
                    case DockSide.Top:
                        // 当前屏幕上方存在另一个显示器。
                        // 例如：
                        //      副屏
                        // ┌───────────┐
                        // └───────────┘
                        //      主屏
                        // ┌───────────┐
                        // └───────────┘
                        // 所以主屏顶部不是“真实外边缘”，从主屏向上拖应该允许正常进入副屏。
                        if (other.Bottom <= current.Top && HasHorizontalOverlap(current, other))
                        {
                            if (other.Bottom >= current.Top - DockTriggerDistance)
                            {
                                return false;
                            }
                        }
                        break;
                    case DockSide.Bottom:
                        // 当前屏幕下方存在另一个显示器。
                        if (other.Top >= current.Bottom && HasHorizontalOverlap(current, other))
                        {
                            if (other.Top <= current.Bottom + DockTriggerDistance)
                            {
                                return false;
                            }
                        }
                        break;
                }
            }
            // 没有找到与该方向相邻的其他显示器，说明这个方向确实是整个虚拟桌面的真实外边缘。
            return true;
        }

        /// <summary>
        /// 判断两个屏幕在垂直方向是否存在重叠。
        /// </summary>
        private bool HasVerticalOverlap(Rectangle a, Rectangle b)
        {
            return a.Top < b.Bottom && a.Bottom > b.Top;
        }

        /// <summary>
        /// 判断两个屏幕在水平方向是否存在重叠。
        /// </summary>
        private bool HasHorizontalOverlap(Rectangle a, Rectangle b)
        {
            return a.Left < b.Right && a.Right > b.Left;
        }


        // ============================================================
        // 进入自动贴边模式
        // ============================================================

        /// <summary>
        /// 用户已经明确把窗体拖出了屏幕外边缘，正式进入自动贴边隐藏模式。
        /// </summary>
        private void EnterDockMode(Screen screen, DockSide side)
        {
            // 记录进入自动贴边模式时所属的显示器和方向。后续隐藏 / 展开都以这个显示器为基础。
            dockScreen = screen;
            dockSide = side;
            isHidden = false;

            // 统一通过 GetDockShownLocation() 计算当前显示器上的完整展开位置。
            // 这样即使用户是在屏幕角落触发停靠，窗体也一定会完整位于当前显示器内部。
            Point location = GetDockShownLocation(dockScreen, dockSide, this.Location);

            // ========================================================
            // 进入贴边模式后保持完全不透明
            // ========================================================
            // 之后主要通过滑出屏幕来减少遮挡，所以不再同时使用半透明状态。
            if (EnableOpacityEffect)
            {
                FadeTo(ActiveOpacity);
            }

            // 平滑移动到正确的完整显示位置。
            StartSlide(location);

            // 进入贴边模式以后，开始等待鼠标真正离开窗体。
            if (!mouseCheckTimer.Enabled)
            {
                mouseCheckTimer.Start();
            }
        }

        // ============================================================
        // 自动隐藏
        // ============================================================

        /// <summary>
        /// 根据当前贴边方向，把窗体绝大部分滑出当前显示器。
        /// 隐藏时只留下 HiddenVisibleSize 像素，同时保证另一方向仍然位于当前显示器有效范围内。
        /// </summary>
        private void HideDockWindow()
        {
            if (!EnableAutoHideDock || dockScreen == null || dockSide == DockSide.None)
            {
                return;
            }
            Rectangle area = dockScreen.WorkingArea;
            // 先获得一个合法的完整展开位置。
            // 这样可以先修正因为：DPI 变化、屏幕切换、用户拖到角落导致的另一轴越界。
            Point location = GetDockShownLocation(dockScreen, dockSide, this.Location);

            switch (dockSide)
            {
                case DockSide.Left:
                    // 左侧隐藏：窗体移动到屏幕左侧之外，只保留 HiddenVisibleSize 像素。
                    // 注意隐藏位置不使用 DockShowMargin，因为 HiddenVisibleSize 就是需要真正留在屏幕边缘用于重新触发 MouseEnter 的部分。
                    location.X = area.Left - this.Width + HiddenVisibleSize;
                    break;
                case DockSide.Right:
                    // 右侧隐藏：窗体左边移动到屏幕右边缘前 HiddenVisibleSize 像素的位置。
                    location.X = area.Right - HiddenVisibleSize;
                    break;
                case DockSide.Top:
                    location.Y = area.Top - this.Height + HiddenVisibleSize;
                    break;
                case DockSide.Bottom:
                    location.Y = area.Bottom - HiddenVisibleSize;
                    break;
            }
            isHidden = true;
            StartSlide(location);
        }


        // ============================================================
        // 自动展开
        // ============================================================

        /// <summary>
        /// 根据指定显示器、贴边方向以及希望保持的位置，计算窗体“完整展开”时最终应该位于的位置。
        /// 这个方法保证：
        /// 1. 窗体完整位于指定显示器的 WorkingArea 内；
        /// 2. 窗体四周与屏幕边缘至少保留 DockShowMargin；
        /// 3. 在贴边方向上按照对应方向排列；
        /// 4. 在另一方向上尽量保持用户原来的位置，但如果超出屏幕则自动限制回来。
        /// 这样可以解决角落停靠以后，展开时部分窗体跑到另一块显示器或屏幕外的问题。
        /// </summary>
        private Point GetDockShownLocation(Screen screen, DockSide side, Point preferredLocation)
        {
            Rectangle area = screen.WorkingArea;

            // 计算窗体完整显示时允许的 X / Y 范围。
            // 四周保留 DockShowMargin。
            int minX = area.Left + DockShowMargin;
            int minY = area.Top + DockShowMargin;
            int maxX = area.Right - this.Width - DockShowMargin;
            int maxY = area.Bottom - this.Height - DockShowMargin;

            // 极端情况下窗体可能比显示器工作区域还大。
            // 防止 max < min 导致 Clamp 参数异常。
            // 正常情况下这里不会发生，但加入保护以后逻辑更加完整。
            if (maxX < minX)
            {
                maxX = minX;
            }
            if (maxY < minY)
            {
                maxY = minY;
            }

            Point location = preferredLocation;

            switch (side)
            {
                case DockSide.Left:
                    // 左侧贴边：
                    // X 固定在屏幕左侧，并保留 DockShowMargin。
                    // Y 尽量保持当前值，但绝不允许超出当前显示器。
                    location.X = minX;
                    location.Y = Clamp(preferredLocation.Y, minY, maxY);
                    break;
                case DockSide.Right:
                    // 右侧贴边：
                    // 窗体右边缘距离屏幕右边缘 DockShowMargin。
                    location.X = maxX;
                    location.Y = Clamp(preferredLocation.Y, minY, maxY);
                    break;
                case DockSide.Top:
                    // 顶部贴边：
                    // Y 固定在顶部。
                    // X 必须限制在当前显示器内部，防止靠近左上 / 右上角时跨到另一块屏幕。
                    location.Y = minY;
                    location.X = Clamp(preferredLocation.X, minX, maxX);
                    break;
                case DockSide.Bottom:
                    location.Y = maxY;
                    location.X = Clamp(preferredLocation.X, minX, maxX);
                    break;
            }

            return location;
        }

        /// <summary>
        /// 鼠标进入隐藏后露出的区域时，把窗体完整滑回当前停靠显示器。
        /// 展开以后保证整个窗体完全位于 dockScreen 内，不允许任何部分跨到其他显示器或屏幕外。
        /// </summary>
        private void ShowDockWindow()
        {
            if (!EnableAutoHideDock || dockScreen == null || dockSide == DockSide.None)
            {
                return;
            }

            // 特别注意：
            // 当前 this.Location 很可能是隐藏状态的位置，例如右侧隐藏时 X 已经位于屏幕外。
            // GetDockShownLocation() 会：
            // 1. 根据 dockSide 重新计算停靠轴；
            // 2. 对另一轴做 Clamp；
            // 3. 确保窗体完整位于 dockScreen；
            // 4. 四周保留 DockShowMargin。
            Point location = GetDockShownLocation(dockScreen, dockSide, this.Location);

            isHidden = false;

            // 展开时恢复完全不透明。
            if (EnableOpacityEffect)
            {
                FadeTo(ActiveOpacity);
            }
            StartSlide(location);
        }


        // ============================================================
        // 滑动动画
        // ============================================================

        /// <summary>
        /// 设置滑动目标位置，并启动动画。
        /// </summary>
        private void StartSlide(Point location)
        {
            targetLocation = location;

            if (this.Location == targetLocation)
            {
                slideTimer.Stop();
                return;
            }

            if (!slideTimer.Enabled)
            {
                slideTimer.Start();
            }
        }

        /// <summary>
        /// 使用 Ease-Out 平滑移动窗体。
        /// </summary>
        private void SlideTimer_Tick(object sender, EventArgs e)
        {
            int differenceX = targetLocation.X - this.Left;
            int differenceY = targetLocation.Y - this.Top;

            bool xFinished = Math.Abs(differenceX) <= SlideMinDistance;
            bool yFinished = Math.Abs(differenceY) <= SlideMinDistance;

            // X 和 Y 都已经非常接近目标位置。
            if (xFinished && yFinished)
            {
                this.Location = targetLocation;
                slideTimer.Stop();
                return;
            }

            int moveX = 0;
            int moveY = 0;

            if (!xFinished)
            {
                // 每次移动剩余距离的一部分。
                moveX = (int)Math.Round(differenceX * SlideEasing);

                // 防止整数取整以后变成 0，导致永远到不了目标位置。
                if (moveX == 0)
                {
                    moveX = differenceX > 0 ? 1 : -1;
                }
            }
            if (!yFinished)
            {
                moveY = (int)Math.Round(differenceY * SlideEasing);

                if (moveY == 0)
                {
                    moveY = differenceY > 0 ? 1 : -1;
                }
            }
            // 一次性修改 Location，避免分别修改 Left / Top 造成两次位置更新。
            this.Location = new Point(this.Left + moveX, this.Top + moveY);
        }


        // ============================================================
        // 运行时修改配置
        // ============================================================

        /// <summary>
        /// 动态启用或关闭透明度效果。
        /// 如果配置是在程序启动时读取，也可以直接给 EnableOpacityEffect 赋值。
        /// 如果运行过程中允许修改，推荐调用这个方法。
        /// </summary>
        private void SetOpacityEffectEnabled(bool enabled)
        {
            EnableOpacityEffect = enabled;

            if (!enabled)
            {
                // 关闭透明度效果以后：停止动画，立即恢复完全不透明。
                fadeTimer.Stop();
                targetOpacity = ActiveOpacity;
                this.Opacity = ActiveOpacity;
            }
            else
            {
                // 如果当前处于自动贴边模式，保持完全不透明。
                // 否则根据鼠标当前位置决定透明度。
                if (dockSide != DockSide.None)
                {
                    FadeTo(ActiveOpacity);
                }
                else if (IsMouseInActiveArea())
                {
                    // 鼠标当前位于有效悬停区域，恢复完全不透明。
                    FadeTo(ActiveOpacity);
                }
                else
                {
                    FadeTo(InactiveOpacity);
                }
            }

            UpdateMouseCheckTimer();
        }

        /// <summary>
        /// 动态启用或关闭自动贴边隐藏功能。
        /// </summary>
        private void SetAutoHideDockEnabled(bool enabled)
        {
            if (EnableAutoHideDock == enabled)
            {
                return;
            }
             
            EnableAutoHideDock = enabled;

            if (!enabled)
            {
                // 如果关闭功能时窗体正处于自动贴边模式，必须先把窗体完整恢复到所属显示器内部。
                if (dockScreen != null && dockSide != DockSide.None)
                {
                    // 停止正在执行的隐藏 / 展开动画，防止 Timer 后续继续修改 Location。
                    slideTimer.Stop();

                    // 统一使用 GetDockShownLocation() 计算完整显示位置。
                    // 这样可以保证：
                    // 1. 窗体完整位于 dockScreen 内；
                    // 2. 不会跨到其他显示器；
                    // 3. 保留 DockShowMargin；
                    // 4. 另一轴也会自动进行边界限制。
                    Point location = GetDockShownLocation(dockScreen, dockSide, this.Location);

                    // 关闭自动隐藏时直接恢复，不执行缓动动画，使状态立即回到普通模式。
                    this.Location = location;
                }

                // 清除所有自动贴边状态。
                dockSide = DockSide.None;
                dockScreen = null;
                isHidden = false;
            }

            UpdateMouseCheckTimer();
        }

        /// <summary>
        /// 根据当前配置状态，判断 mouseCheckTimer 是否还需要继续运行。
        /// </summary>
        private void UpdateMouseCheckTimer()
        {
            if (!NeedMouseLeaveCheck())
            {
                mouseCheckTimer.Stop();
                return;
            }

            // 只有鼠标当前确实位于有效窗体区域内，才有必要开始等待 MouseLeave。
            if (IsMouseInActiveArea() && !mouseCheckTimer.Enabled)
            {
                mouseCheckTimer.Start();
            }
        }


        // ============================================================
        // 辅助方法
        // ============================================================

        /// <summary>
        /// 把 value 限制在 min ~ max 范围内。
        /// </summary>
        private int Clamp(int value, int min, int max)
        {
            if (value < min)
            {
                return min;
            }
            if (value > max)
            {
                return max;
            }
            return value;
        }

        /*
         * ============================================================
         * DPI 变化处理（当前版本暂不启用）
         * ============================================================
         * 当前项目基于 .NET Framework 4.5，暂不使用 Form.DpiChanged 相关处理，因此下面代码仅作为以后升级到支持 Per-Monitor DPI 的框架版本时的参考实现保留。
         * 当前版本的多显示器 / 不同 DPI 显示器拖动主要通过以下逻辑处理：
         * 1. Screen.FromPoint(Control.MousePosition) 根据鼠标位置确定用户当前正在操作的显示器；
         * 2. 已贴边窗体跨到其他显示器时，通过 ExitDockMode() 清除旧显示器的贴边状态；
         * 3. 用户松开鼠标以后，CheckAutoDock() 根据当前显示器重新判断是否进入贴边模式；
         * 4. GetDockShownLocation() 根据当前显示器的 WorkingArea 重新计算合法的展开位置。
         * 因此目前的自动贴边功能不依赖 DpiChanged 事件。
         *
         * 如果以后项目升级到支持 Per-Monitor DPI / DpiChanged 的框架版本，并且需要在 DPI 改变时主动修正已经贴边窗体的位置，可以重新评估并启用下面的处理。
         *
         * 注意：
         * 升级框架后不要直接取消注释就认为一定正确，应结合届时的 AutoScaleMode、DPI Awareness 配置以及Windows 的 Per-Monitor DPI 行为重新测试。
         * ============================================================
         */
        ///// <summary>
        ///// 窗体从不同 DPI 的显示器之间移动时触发。
        ///// 例如：下方显示器 125% → 上方显示器 100%，WinForms 可能根据新的 DPI 自动调整窗体尺寸。
        ///// 如果当前仍然处于贴边状态，原来的动画目标位置可能已经基于旧 Width / Height 计算，所以需要停止旧动画并重新计算。
        ///// </summary>
        //private void MainForm_DpiChanged(object sender, DpiChangedEventArgs e)
        //{
        //    // 当前没有处于自动贴边状态，不需要做任何事情。
        //    if (!EnableAutoHideDock || dockSide == DockSide.None || dockScreen == null)
        //    {
        //        return;
        //    }

        //    // DPI 改变以后，原来的 targetLocation 很可能已经失效。
        //    slideTimer.Stop();

        //    // 如果当前隐藏：根据新的窗体尺寸重新计算隐藏位置。
        //    // 如果当前展开：根据新的窗体尺寸重新计算完整显示位置。
        //    if (isHidden)
        //    {
        //        HideDockWindow();
        //    }
        //    else
        //    {
        //        ShowDockWindow();
        //    }
        //}
    }
}
