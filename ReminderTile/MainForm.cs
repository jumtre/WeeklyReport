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
        private readonly Timer mouseCheckTimer = new Timer();
        private readonly Timer fadeTimer = new Timer();
        private double targetOpacity = 0.5;

        public MainForm()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;

            // ==================== 可调整参数 ====================
            // 鼠标离开窗体后的透明度。
            // 取值范围：0.0 ~ 1.0
            // 0.0 = 完全透明
            // 0.5 = 50% 透明度
            // 1.0 = 完全不透明
            this.Opacity = 0.5;

            // 鼠标位置检测间隔，单位：毫秒。
            // 这个 Timer 只在鼠标位于窗体内时运行，
            // 用来判断鼠标是否已经真正离开整个窗体。
            //
            // 数值越小：离开窗体后的响应越快，但检测频率越高。
            // 数值越大：检测频率越低，但离开后的响应会有一定延迟。
            //
            // 推荐：30 ~ 100
            // 50ms 通常是响应速度和检测频率之间比较合适的值。
            mouseCheckTimer.Interval = 50;

            // 渐变动画刷新间隔，单位：毫秒。
            //
            // 数值越小：动画刷新越频繁，视觉上越平滑。
            // 数值越大：动画刷新频率越低，可能出现明显的逐级变化。
            //
            // 推荐：15 ~ 30
            // 一般不建议通过大幅增加 Interval 来降低动画速度，
            // 应主要通过 easing 调整动画快慢。
            fadeTimer.Interval = 15;
            // ==================================================

            mouseCheckTimer.Tick += MouseCheckTimer_Tick;
            fadeTimer.Tick += FadeTimer_Tick;

            // 给窗体以及所有现有子控件统一注册 MouseEnter。
            RegisterMouseEnter(this);

            //XScrollBar scrollBar = new XScrollBar();
            //richTextBoxContent.ScrollBars = scrollBar;
        }

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
        private void panelBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                formPoint.X = -e.X;
                formPoint.Y = -e.Y;
            }
        }

        private void panelBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point position = Control.MousePosition;
                position.Offset(formPoint.X, formPoint.Y - (richTextBoxContent.Height + richTextBoxContent.Location.Y + richTextBoxContent.Margin.Top));
                this.DesktopLocation = position;
            }
        }

        private void panelBar_MouseUp(object sender, MouseEventArgs e)
        {
            //panelBar_MouseMove(sender, e);
        }

        private void panelBar_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.SizeAll;
        }

        private void panelBar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
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
            // Timer 没有运行，说明鼠标之前位于整个窗体外。
            // 因此只有真正从窗体外进入时才进行处理，
            // 在各个子控件之间移动不会重复启动动画。
            if (!mouseCheckTimer.Enabled)
            {
                // 开始监测鼠标什么时候真正离开整个窗体。
                mouseCheckTimer.Start();

                // 渐变到完全不透明。
                FadeTo(1.0);
            }
        }

        /// <summary>
        /// 检查鼠标是否真正离开了整个窗体
        /// </summary>
        private void MouseCheckTimer_Tick(object sender, EventArgs e)
        {
            // Bounds 是整个窗体在屏幕上的矩形范围。
            // 因此无论鼠标当前位于 Form、Panel、Button、Label
            // 还是其他子控件上，只要仍在 Bounds 内，就认为没有离开窗体。
            if (this.Bounds.Contains(Cursor.Position))
            {
                return;
            }

            // 鼠标已经真正离开整个窗体，不再需要继续检测。
            mouseCheckTimer.Stop();

            // 渐变到 50% 透明度。
            FadeTo(0.5);
        }

        /// <summary>
        /// 置目标透明度，并启动渐变动画。
        /// </summary>
        private void FadeTo(double opacity)
        {
            targetOpacity = opacity;

            // 如果当前已经是目标透明度，就不需要启动 Timer
            if (Math.Abs(this.Opacity - targetOpacity) < 0.001)
            {
                this.Opacity = targetOpacity;
                return;
            }

            // fadeTimer 只在实际需要执行渐变时运行。
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
            // ==================== 可调整参数 ====================

            // 缓动系数，是控制动画速度最主要的参数。
            //
            // 每次 Tick 移动“当前透明度与目标透明度之间剩余距离”的这个比例。
            //
            // 数值越大：渐变越快。
            // 数值越小：渐变越慢、越柔和。
            //
            // 推荐范围：
            // 0.05 = 比较慢，渐变效果非常明显
            // 0.08 = 较慢且自然（推荐）
            // 0.10 = 中等速度
            // 0.15 = 较快
            // 0.20 = 很快
            //
            // 原来使用 0.20，变化太快，所以这里调整为 0.08。
            const double easing = 0.08;

            // 判断“已经到达目标透明度”的误差范围。
            //
            // Ease-Out 是按剩余距离的比例逐渐逼近目标值，
            // 理论上会无限接近目标值而不会精确等于目标值，
            // 所以需要设置一个足够小的误差范围来结束动画。
            //
            // 数值越小：动画尾部持续时间越长。
            // 数值越大：越早结束动画并直接设置为目标值。
            //
            // 推荐：0.003 ~ 0.01
            const double minDifference = 0.005;

            // ==================================================

            // 计算目标透明度与当前透明度之间还剩多少距离。
            double difference = targetOpacity - this.Opacity;

            // 已经非常接近目标透明度，直接设置最终值并停止 Timer。
            if (Math.Abs(difference) <= minDifference)
            {
                this.Opacity = targetOpacity;
                fadeTimer.Stop();
                return;
            }

            // 每次移动剩余距离的一部分。
            //
            // 例如 easing = 0.08：
            // 当前 0.50，目标 1.00：
            // 第一次增加 (1.00 - 0.50) × 0.08
            //
            // 随着越来越接近目标值，每次变化量也会越来越小，
            // 从而形成“开始较快、接近目标时逐渐减速”的 Ease-Out 效果。
            this.Opacity += difference * easing;
        }
    }
}
