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

namespace ReminderTile
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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
            try
            {
                string strStartPosition = CommonData.IniHelper.Read("ReminderTile", "StartPosition");
                if (!string.IsNullOrWhiteSpace(strStartPosition) && strStartPosition.Contains(","))
                {
                    string[] positionArray = strStartPosition.Split(',');
                    int x, y;
                    if (int.TryParse(positionArray[0], out x) && int.TryParse(positionArray[1], out y))
                        this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - x - this.Width, y);
                    else
                        this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width - 10, 20); //从配置读取到的值错误，则设置默认位置
                }
                else
                {
                    //没有配置或配置格式错误，则设置默认位置
                    this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width - 10, 20);
                }
            }
            catch
            {
                //如果读取配置失败，设置默认位置
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width - 10, 20);
            }
            formPoint = this.Location;
            richTextBoxContent.BackColorChanged -= richTextBoxContent_BackColorChanged;
            richTextBoxContent_BackColorChanged(sender, e);
            richTextBoxContent.BackColorChanged += richTextBoxContent_BackColorChanged;
            toolTipInfo.SetToolTip(buttonRefresh, "刷新");
            toolTipInfo.SetToolTip(buttonPrevious, "上一个");
            toolTipInfo.SetToolTip(buttonNext, "下一个");
            toolTipInfo.SetToolTip(buttonAdd, "新增");
            toolTipInfo.SetToolTip(buttonSave, "保存");
            toolTipInfo.SetToolTip(buttonDelete, "删除");
            toolTipInfo.SetToolTip(buttonTop, this.TopMost ? "拔出(取消置顶)" : "钉住(置顶)");
            toolTipInfo.SetToolTip(buttonColor, "颜色");
            toolTipInfo.SetToolTip(buttonClose, "关闭");

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
                toolTipInfo.SetToolTip(buttonTop, "钉住(置顶)");
                ToolStripMenuItemTop.Text = "钉住(置顶)";
            }
            else
            {
                this.TopMost = true;
                buttonTop.Text = "↑";
                toolTipInfo.SetToolTip(buttonTop, "拔出(取消置顶)");
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
            DataTable dt = CommonData.AccessHelper.GetDataTable(sql);
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

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
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
            BindReminder(-1);
            isAdding = true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (isAdding)
            {
                SqlParams paramDict = new SqlParams();
                paramDict.Add("Content", richTextBoxContent.Text);
                paramDict.Add("Status", 0);
                decimal id = CommonData.AccessHelper.InsertAndReturnNewIdentity("Reminder", paramDict);
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
                    return;
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
                CommonData.AccessHelper.Update("Reminder", setParamDict, whereParamDict);
                originalContent = richTextBoxContent.Text;
                //KeyValuePair<int, Reminder> pair = reminderDict.FirstOrDefault(r => r.Value.ID == id);
                KeyValuePair<int, Reminder> pair = reminderDict.FirstOrDefault(r => r.Value.ID == reminder.ID);
                if (pair.Value != null)
                    pair.Value.Content = richTextBoxContent.Text;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
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
                CommonData.AccessHelper.Update("Reminder", setParamDict, whereParamDict);
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
                if (reminder.ToDo != null && reminder.ToDo.ID > 0)
                    MessageBox.Show("如有需要，请手动在待办事项程序中修改状态。", "提示");
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
    }
}
