using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Model;

namespace WRManagement
{
    public partial class MainForm : Form
    {
        private enum CurrentDataType
        {
            None,
            User,
            Project,
            Branch
        }
        /// <summary>
        /// 当前编辑数据的类型
        /// </summary>
        private CurrentDataType currentDataType;
        /// <summary>
        /// 是否触发DataGridView的SelectionChanged事件
        /// </summary>
        private bool fireSelectionChanged = true;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!File.Exists(CommonData.DBPath))
            {
                MessageBox.Show("数据库文件未找到。", "提示");
                this.Close();
            }
            BindDict();
            FileInfo fileInfoWeeklyReport = new FileInfo(Path.Combine(CommonData.ApplicationPath, "WeeklyReport.exe"));
            checkBoxWeeklyReportAutoStartup.CheckedChanged -= checkBoxWeeklyReportAutoStartup_CheckedChanged;
            checkBoxWeeklyReportAutoStartup.Checked = CommonFunc.IsStartup(fileInfoWeeklyReport);
            checkBoxWeeklyReportAutoStartup.CheckedChanged += checkBoxWeeklyReportAutoStartup_CheckedChanged;
            FileInfo fileInfoTodoList = new FileInfo(Path.Combine(CommonData.ApplicationPath, "ToDoList.exe"));
            checkBoxTodoListAutoStartup.CheckedChanged -= checkBoxTodoListAutoStartup_CheckedChanged;
            checkBoxTodoListAutoStartup.Checked = CommonFunc.IsStartup(fileInfoTodoList);
            checkBoxTodoListAutoStartup.CheckedChanged += checkBoxTodoListAutoStartup_CheckedChanged;
            FileInfo fileInfoReminderTile = new FileInfo(Path.Combine(CommonData.ApplicationPath, "ReminderTile.exe"));
            checkBoxReminderTileAutoStartup.CheckedChanged -= checkBoxReminderTileAutoStartup_CheckedChanged;
            checkBoxReminderTileAutoStartup.Checked = CommonFunc.IsStartup(fileInfoReminderTile);
            checkBoxReminderTileAutoStartup.CheckedChanged += checkBoxReminderTileAutoStartup_CheckedChanged;
        }

        private void BindDict()
        {
            List<string> dictList = new List<string>() { "", "用户", "项目", "分支" };
            comboBoxDict.DataSource = dictList;

            BindUserDict();
            BindProjectDict();
            BindBranchDict();
            checkBoxApplyCurrentProjectAndBranchToSearch.Checked = CommonData.IniHelper.Read("Common", "ApplyCurrentProjectAndBranchToSearch").ToLower() == "true" ? true : false;
        }

        private void BindUserDict(bool lazyLoad = true)
        {
            CommonFunc.BindUserListToComboBox(comboBoxCurrentUser, null, false, lazyLoad);
            List<User> users = comboBoxCurrentUser.DataSource as List<User>;
            if (users == null)
            {
                MessageBox.Show("绑定的当前用户数据源错误", "提示");
                return;
            }
            string currentUserID = CommonData.IniHelper.Read("Common", "CurrentUserID");
            if (currentUserID.NotNullOrWhiteSpace())
            {
                comboBoxCurrentUser.SelectedItem = users.FirstOrDefault(u => u.ID.ToString() == currentUserID);
            }
            else
            {
                string a = string.Empty;
                string currentUserName = string.Empty;
                currentUserName = CommonData.IniHelper.Read("Common", "CurrentUserName");
                if (currentUserName.NotNullOrWhiteSpace())
                    comboBoxCurrentUser.SelectedItem = users.FirstOrDefault(u => u.Name == currentUserName);
            }
        }

        private void BindProjectDict(bool lazyLoad = true)
        {
            comboBoxProject.SelectedIndexChanged -= comboBoxProject_SelectedIndexChanged;
            CommonFunc.BindProjectListToComboBox(comboBoxProject, null, false, lazyLoad);
            comboBoxProject.SelectedIndexChanged += comboBoxProject_SelectedIndexChanged;
            comboBoxCurrentProject.SelectedIndexChanged -= comboBoxCurrentProject_SelectedIndexChanged;
            CommonFunc.BindProjectListToComboBox(comboBoxCurrentProject, null, false, lazyLoad, true);
            List<Project> projects = comboBoxCurrentProject.DataSource as List<Project>;
            if (projects == null)
            {
                MessageBox.Show("绑定的当前项目数据源错误", "提示");
                return;
            }
            string currentProjectID = CommonData.IniHelper.Read("Common", "CurrentProjectID");
            if (currentProjectID.NotNullOrWhiteSpace())
            {
                comboBoxCurrentProject.SelectedItem = projects.FirstOrDefault(u => u.ID.ToString() == currentProjectID);
            }
            else
            {
                //comboBoxCurrentProject.Text= CommonData.IniHelper.Read("Common", "CurrentProjectName");
                string currentProjectName = CommonData.IniHelper.Read("Common", "CurrentProjectName");
                //comboBoxCurrentProject.Text = currentProjectName;
                if (currentProjectName.NotNullOrWhiteSpace())
                    comboBoxCurrentProject.SelectedItem = projects.FirstOrDefault(u => u.Name == currentProjectName);
            }
            comboBoxCurrentProject.SelectedIndexChanged += comboBoxCurrentProject_SelectedIndexChanged;
        }

        private void BindBranchDict(bool lazyLoad = true)
        {
            comboBoxCurrentBranch.SelectedIndexChanged -= comboBoxCurrentBranch_SelectedIndexChanged;
            CommonFunc.BindBranchListToComboBox(comboBoxCurrentBranch, null, false, lazyLoad, true);
            List<Branch> branches = comboBoxCurrentBranch.DataSource as List<Branch>;
            if (branches == null)
            {
                MessageBox.Show("绑定的当前分支数据源错误", "提示");
                return;
            }
            string currentBranchID = CommonData.IniHelper.Read("Common", "CurrentBranchID");
            if (currentBranchID.NotNullOrWhiteSpace())
            {
                comboBoxCurrentBranch.SelectedItem = branches.FirstOrDefault(u => u.ID.ToString() == currentBranchID);
            }
            else
            {
                string currentBranchName = CommonData.IniHelper.Read("Common", "CurrentBranchName");
                if (currentBranchName.NotNullOrWhiteSpace())
                    comboBoxCurrentBranch.SelectedItem = branches.FirstOrDefault(u => u.Name == currentBranchName);
            }
            comboBoxCurrentBranch.SelectedIndexChanged += comboBoxCurrentBranch_SelectedIndexChanged;
        }

        private void BindUserList(List<User> list = null)
        {
            fireSelectionChanged = false;
            dataGridViewShow.Rows.Clear();
            ColumnProjectName.Visible = false;
            ColumnMemo.Visible = false;
            if (list == null)
                list = CommonFunc.GetUserList(false);
            if (list == null || list.Count == 0)
                return;
            foreach (User user in list)
            {
                int index = dataGridViewShow.Rows.Add();
                DataGridViewRow row = dataGridViewShow.Rows[index];
                row.Cells[ColumnSortNo.Index].Value = index + 1;
                row.Cells[ColumnID.Index].Value = user.ID;
                row.Cells[ColumnName.Index].Value = user.Name;
                row.Tag = user;
            }
            dataGridViewShow.ClearSelection();
            fireSelectionChanged = true;
        }

        private void BindProjectList(List<Project> list = null)
        {
            fireSelectionChanged = false;
            dataGridViewShow.Rows.Clear();
            ColumnProjectName.Visible = false;
            ColumnMemo.Visible = false;
            if (list == null)
                list = CommonFunc.GetProjectList(false);
            if (list == null || list.Count == 0)
                return;
            foreach (Project project in list)
            {
                int index = dataGridViewShow.Rows.Add();
                DataGridViewRow row = dataGridViewShow.Rows[index];
                row.Cells[ColumnSortNo.Index].Value = index + 1;
                row.Cells[ColumnID.Index].Value = project.ID;
                row.Cells[ColumnName.Index].Value = project.Name;
                row.Tag = project;
            }
            dataGridViewShow.ClearSelection();
            fireSelectionChanged = true;
        }

        private void BindBranchList(List<Branch> list = null)
        {
            fireSelectionChanged = false;
            dataGridViewShow.Rows.Clear();
            ColumnProjectName.Visible = true;
            ColumnMemo.Visible = true;
            if (list == null)
            {
                //if (comboBoxProject.SelectedItem is Project project && project.ID != CommonData.ItemAllValue)
                //    list = CommonFunc.GetBranchListByProjectID(project.ID, false);
                //else
                    list = CommonFunc.GetBranchList(false);
            }
            if (list == null || list.Count == 0)
                return;
            foreach (Branch branch in list)
            {
                int index = dataGridViewShow.Rows.Add();
                DataGridViewRow row = dataGridViewShow.Rows[index];
                row.Cells[ColumnSortNo.Index].Value = index + 1;
                row.Cells[ColumnID.Index].Value = branch.ID;
                row.Cells[ColumnName.Index].Value = branch.Name;
                row.Cells[ColumnProjectName.Index].Value = branch.Project?.Name;
                row.Cells[ColumnProjectName.Index].Tag = branch.Project;
                row.Cells[ColumnMemo.Index].Value = branch.Memo;
                row.Tag = branch;
            }
            dataGridViewShow.ClearSelection();
            fireSelectionChanged = true;
        }

        private void RefreshData()
        {
            if (currentDataType == CurrentDataType.User)
            {
                BindUserList();
                BindUserDict(false);
            }
            else if (currentDataType == CurrentDataType.Project)
            {
                BindProjectList();
                BindProjectDict(false);
            }
            else if (currentDataType == CurrentDataType.Branch)
                BindBranchList();
        }

        private void comboBoxDict_SelectedIndexChanged(object sender, EventArgs e)
        {
            fireSelectionChanged = false;
            //dataGridViewShow.SelectionChanged -= dataGridViewShow_SelectionChanged;
            dataGridViewShow.Rows.Clear();
            textBoxItemName.Text = string.Empty;
            textBoxItemName.Tag = null;
            currentDataType = CurrentDataType.None;
            if (comboBoxDict.SelectedValue?.ToString() == "用户")
                currentDataType = CurrentDataType.User;
            else if (comboBoxDict.SelectedValue?.ToString() == "项目")
                currentDataType = CurrentDataType.Project;
            else if (comboBoxDict.SelectedValue?.ToString() == "分支")
                currentDataType = CurrentDataType.Branch;
            RefreshData();
            //dataGridViewShow.SelectionChanged += dataGridViewShow_SelectionChanged;
            fireSelectionChanged = true;
        }

        private void dataGridViewShow_SelectionChanged(object sender, EventArgs e)
        {
            if (!fireSelectionChanged)
                return;
            textBoxItemName.Text = string.Empty;
            textBoxItemName.Tag = null;
            if (dataGridViewShow.SelectedRows.Count == 0)
                return;
            switch (dataGridViewShow.SelectedRows[0].Tag?.GetType().Name)
            {
                case "User":
                    currentDataType = CurrentDataType.User;
                    User user = dataGridViewShow.SelectedRows[0].Tag as User;
                    if (user != null)
                    {
                        textBoxItemName.Text = user.Name;
                        textBoxItemName.Tag = user.ID;
                    }
                    break;
                case "Project":
                    currentDataType = CurrentDataType.Project;
                    Project project = dataGridViewShow.SelectedRows[0].Tag as Project;
                    if (project != null)
                    {
                        textBoxItemName.Text = project.Name;
                        textBoxItemName.Tag = project.ID;
                    }
                    break;
                case "Branch":
                    currentDataType = CurrentDataType.Branch;
                    Branch branch = dataGridViewShow.SelectedRows[0].Tag as Branch;
                    if (branch != null)
                    {
                        textBoxItemName.Text = branch.Name;
                        textBoxItemName.Tag = branch.ID;
                        textBoxMemo.Text = branch.Memo;
                        if (branch.Project != null)
                            comboBoxProject.SelectedValue = branch.Project.ID;
                        else
                            comboBoxProject.SelectedIndex = -1;
                    }
                    break;
                default:
                    currentDataType = CurrentDataType.None;
                    break;
            }
        }

        private bool CheckDataType()
        {
            if (currentDataType == CurrentDataType.None)
            {
                if (comboBoxDict.SelectedValue?.ToString() == "用户")
                    currentDataType = CurrentDataType.User;
                else if (comboBoxDict.SelectedValue?.ToString() == "项目")
                    currentDataType = CurrentDataType.Project;
                else if (comboBoxDict.SelectedValue?.ToString() == "分支")
                    currentDataType = CurrentDataType.Branch;
            }
            if (currentDataType == CurrentDataType.None)
            {
                MessageBox.Show("未选择要操作的数据的类型", "提示");
                return false;
            }
            return true;
        }

        private void ShowMessageAskRefresh()
        {
            if (MessageBox.Show("操作完成，是否刷新列表？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                textBoxItemName.Text = string.Empty;
                textBoxItemName.Tag = null;
                RefreshData();
            }
        }

        private bool BranchExists(int projectID, string branchName)
        {
            string sql = "select count(*) from Branch where ProjectID = @ProjectID and Name = @Name";
            SqlParams paramDict = new SqlParams();
            paramDict.Add("ProjectID", projectID);
            paramDict.Add("Name", branchName);
            int i = -1;
            if (int.TryParse(CommonData.AccessHelper.ExecuteScalar(sql, paramDict).ToString(), out i) && i > 0)
                return true;
            else
                return false;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!CheckDataType())
                return;
            if (string.IsNullOrWhiteSpace(textBoxItemName.Text))
            {
                MessageBox.Show("名称不能为空", "提示");
                return;
            }
            string table = string.Empty;
            SqlParams paramDict = new SqlParams();
            if (currentDataType == CurrentDataType.User)
            {
                table = "[User]";
                paramDict.Add("Name", textBoxItemName.Text.Trim());
            }
            else if (currentDataType == CurrentDataType.Project)
            {
                table = "Project";
                paramDict.Add("Name", textBoxItemName.Text.Trim());
            }
            else if (currentDataType == CurrentDataType.Branch)
            {
                int projectID;
                if (comboBoxProject.SelectedItem is Project project && project.ID != CommonData.ItemAllValue)
                    projectID = project.ID;
                else
                {
                    MessageBox.Show("项目不能为空", "提示");
                    return;
                }
                if (BranchExists(projectID, textBoxItemName.Text.Trim()))
                {
                    MessageBox.Show("项目中已存在同名分支", "提示");
                    return;
                }
                table = "Branch";
                paramDict.Add("Name", textBoxItemName.Text.Trim());
                paramDict.Add("[Memo]", textBoxMemo.Text.Trim());
                paramDict.Add("ProjectID", projectID);
            }
            if (table.NotNullOrWhiteSpace() && paramDict.Count > 0)
                CommonData.AccessHelper.Insert(table, paramDict);
            textBoxItemName.Text = string.Empty;
            textBoxMemo.Text = string.Empty;
            ShowMessageAskRefresh();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (!CheckDataType())
                return;
            if (string.IsNullOrWhiteSpace(textBoxItemName.Text))
            {
                MessageBox.Show("名称不能为空", "提示");
                return;
            }
            if (textBoxItemName.Tag == null || string.IsNullOrWhiteSpace(textBoxItemName.Tag.ToString()))
            {
                MessageBox.Show("数据错误，请重新选择要修改的数据后重试", "提示");
                return;
            }
            string table = string.Empty;
            SqlParams setParamDict = new SqlParams();
            SqlParams whereParamDict = new SqlParams();
            if (currentDataType == CurrentDataType.User)
            {
                table = "[User]";
                setParamDict.Add("Name", textBoxItemName.Text.Trim());
                whereParamDict.Add("ID", textBoxItemName.Tag);
            }
            else if (currentDataType == CurrentDataType.Project)
            {
                table = "Project";
                setParamDict.Add("Name", textBoxItemName.Text.Trim());
                whereParamDict.Add("ID", textBoxItemName.Tag);
            }
            else if (currentDataType == CurrentDataType.Branch)
            {
                int projectID;
                if (comboBoxProject.SelectedItem is Project project && project.ID != CommonData.ItemAllValue)
                    projectID = project.ID;
                else
                {
                    MessageBox.Show("项目不能为空", "提示");
                    return;
                }
                //if (BranchExists(projectID, textBoxItemName.Text.Trim()))
                //{
                //    MessageBox.Show("项目中已存在同名分支", "提示");
                //    return;
                //}
                table = "Branch";
                setParamDict.Add("Name", textBoxItemName.Text.Trim());
                setParamDict.Add("Memo", textBoxMemo.Text.Trim());
                setParamDict.Add("ProjectID", projectID);
                whereParamDict.Add("ID", textBoxItemName.Tag);
            }
            if (table.NotNullOrWhiteSpace() && setParamDict.Count > 0 && whereParamDict.Count > 0)
                CommonData.AccessHelper.Update(table, setParamDict, whereParamDict);
            ShowMessageAskRefresh();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!CheckDataType())
                return;
            if (textBoxItemName.Tag == null || string.IsNullOrWhiteSpace(textBoxItemName.Tag.ToString()))
            {
                MessageBox.Show("数据错误，请重新选择要修改的数据后重试", "提示");
                return;
            }
            string table = string.Empty;
            SqlParams paramDict = new SqlParams();
            if (currentDataType == CurrentDataType.User)
            {
                table = "[User]";
            }
            else if (currentDataType == CurrentDataType.Project)
            {
                table = "Project";
            }
            else if (currentDataType == CurrentDataType.Branch)
            {
                table = "Branch";
            }
            if (table.NotNullOrWhiteSpace())
            {
                paramDict.Add("ID", textBoxItemName.Tag);
                CommonData.AccessHelper.Delete(table, paramDict);
            }
            ShowMessageAskRefresh();
        }

        private void buttonSetCurrentUser_Click(object sender, EventArgs e)
        {
            if (comboBoxCurrentUser.SelectedItem == null)
            {
                MessageBox.Show("未选择用户", "提示");
                return;
            }
            User currentUser = comboBoxCurrentUser.SelectedItem as User;
            if (currentUser == null)
            {
                MessageBox.Show("数据错误，请重新打开程序再试", "提示");
                return;
            }
            CommonData.IniHelper.Write("Common", "CurrentUserID", currentUser.ID.ToString());
            CommonData.IniHelper.Write("Common", "CurrentUserName", currentUser.Name);
        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            if (!checkBoxBackupDatabase.Checked && !checkBoxBackupConfigFile.Checked)
            {
                MessageBox.Show("请至少选择数据库和配置文件中的一项", "提示");
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            buttonBackup.Enabled = false;
            string backupPath = Path.Combine(CommonData.BackupPath, DateTime.Now.ToString(CommonData.DateTimeDetailFormat));
            if (!Directory.Exists(backupPath))
                Directory.CreateDirectory(backupPath);

            //todo 文件锁定状态下的备份，文件较大时的备份
            //using
            //FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            //StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
            if (checkBoxBackupDatabase.Checked)
                File.Copy(CommonData.DBPath, Path.Combine(backupPath, CommonData.DBFileName));
            if (checkBoxBackupConfigFile.Checked)
                File.Copy(CommonData.ConfigFilePath, Path.Combine(backupPath, CommonData.ConfigFileName));
            MessageBox.Show("备份完成", "提示");

            buttonBackup.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        private void comboBoxProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BindBranchList();
        }

        private void buttonSetCurrentProjectAndBranch_Click(object sender, EventArgs e)
        {
            Project currentProject = comboBoxCurrentProject.SelectedItem as Project;
            Branch currentBranch = comboBoxCurrentBranch.SelectedItem as Branch;
            if (currentProject == null)
            {
                CommonData.IniHelper.Write("Common", "CurrentProjectID", string.Empty);
                CommonData.IniHelper.Write("Common", "CurrentProjectName", string.Empty);
                currentBranch = null;
            }
            else
            {
                CommonData.IniHelper.Write("Common", "CurrentProjectID", currentProject.ID.ToString());
                CommonData.IniHelper.Write("Common", "CurrentProjectName", currentProject.Name);
            }
            if (currentBranch == null)
            {
                CommonData.IniHelper.Write("Common", "CurrentBranchID", string.Empty);
                CommonData.IniHelper.Write("Common", "CurrentBranchName", string.Empty);
            }
            else
            {
                CommonData.IniHelper.Write("Common", "CurrentBranchID", currentBranch.ID.ToString());
                CommonData.IniHelper.Write("Common", "CurrentBranchName", currentBranch.Name);
            }
            CommonData.IniHelper.Write("Common", "ApplyCurrentProjectAndBranchToSearch", checkBoxApplyCurrentProjectAndBranchToSearch.Checked ? "true" : "false");
        }

        private void comboBoxCurrentProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            Project project = null;
            if (comboBoxCurrentProject.SelectedItem is Project)
                project = comboBoxCurrentProject.SelectedItem as Project;
            comboBoxCurrentBranch.SelectedIndexChanged -= comboBoxCurrentBranch_SelectedIndexChanged;
            if (project != null && project.ID != CommonData.ItemNullValue)
                CommonFunc.BindBranchListToComboBoxByProjectID(comboBoxCurrentBranch, project.ID, null, true, true, true);
            else
                CommonFunc.BindBranchListToComboBox(comboBoxCurrentBranch, null, false, true, true);
            comboBoxCurrentBranch.SelectedIndexChanged += comboBoxCurrentBranch_SelectedIndexChanged;
        }

        private void comboBoxCurrentBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCurrentBranch.SelectedItem is Branch branch && branch.Project != null && branch.Project.ID != CommonData.ItemNullValue)
            {
                if (comboBoxCurrentProject.SelectedValue.ToString() != branch.Project.ID.ToString())
                {
                    comboBoxCurrentBranch.SelectedIndexChanged -= comboBoxCurrentBranch_SelectedIndexChanged;
                    CommonFunc.BindBranchListToComboBoxByProjectID(comboBoxCurrentBranch, branch.Project.ID, null, true, true, true);
                    comboBoxCurrentBranch.SelectedValue = branch.ID;
                    comboBoxCurrentBranch.SelectedIndexChanged += comboBoxCurrentBranch_SelectedIndexChanged;

                    comboBoxCurrentProject.SelectedIndexChanged -= comboBoxCurrentProject_SelectedIndexChanged;
                    comboBoxCurrentProject.SelectedValue = branch.Project.ID;
                    comboBoxCurrentProject.SelectedIndexChanged += comboBoxCurrentProject_SelectedIndexChanged;
                }
            }
        }

        private void checkBoxWeeklyReportAutoStartup_CheckedChanged(object sender, EventArgs e)
        {
            FileInfo fileInfo = new FileInfo(Path.Combine(CommonData.ApplicationPath, "WeeklyReport.exe"));
            if (!CommonFunc.SetStartup(fileInfo, checkBoxWeeklyReportAutoStartup.Checked, null, "个人周报"))
            {
                MessageBox.Show("设置失败", "提示");
                checkBoxWeeklyReportAutoStartup.CheckedChanged -= checkBoxWeeklyReportAutoStartup_CheckedChanged;
                checkBoxWeeklyReportAutoStartup.Checked = !checkBoxWeeklyReportAutoStartup.Checked;
                checkBoxWeeklyReportAutoStartup.CheckedChanged += checkBoxWeeklyReportAutoStartup_CheckedChanged;
            }
        }

        private void checkBoxTodoListAutoStartup_CheckedChanged(object sender, EventArgs e)
        {
            FileInfo fileInfo = new FileInfo(Path.Combine(CommonData.ApplicationPath, "ToDoList.exe"));
            if (!CommonFunc.SetStartup(fileInfo, checkBoxTodoListAutoStartup.Checked, null, "待办事项"))
            {
                MessageBox.Show("设置失败", "提示");
                checkBoxTodoListAutoStartup.CheckedChanged -= checkBoxTodoListAutoStartup_CheckedChanged;
                checkBoxTodoListAutoStartup.Checked = !checkBoxTodoListAutoStartup.Checked;
                checkBoxTodoListAutoStartup.CheckedChanged += checkBoxTodoListAutoStartup_CheckedChanged;
            }
        }

        private void checkBoxReminderTileAutoStartup_CheckedChanged(object sender, EventArgs e)
        {
            FileInfo fileInfo = new FileInfo(Path.Combine(CommonData.ApplicationPath, "ReminderTile.exe"));
            if (!CommonFunc.SetStartup(fileInfo, checkBoxReminderTileAutoStartup.Checked, null, "提醒磁贴"))
            {
                MessageBox.Show("设置失败", "提示");
                checkBoxReminderTileAutoStartup.CheckedChanged -= checkBoxReminderTileAutoStartup_CheckedChanged;
                checkBoxReminderTileAutoStartup.Checked = !checkBoxReminderTileAutoStartup.Checked;
                checkBoxReminderTileAutoStartup.CheckedChanged += checkBoxReminderTileAutoStartup_CheckedChanged;
            }
        }

        private void buttonSetReminderTile_Click(object sender, EventArgs e)
        {
            ReminderTile.MainForm reminderTile = new ReminderTile.MainForm();
            reminderTile.IsSetting = true;
            reminderTile.ShowDialog(this);

            CommonData.IniHelper.Write("ReminderTile", "TopMost", reminderTile.SettingTopMost.ToString());
            CommonData.IniHelper.Write("ReminderTile", "BackColor", reminderTile.SettingBackColor.ToArgb().ToString());
            CommonData.IniHelper.Write("ReminderTile", "StartPosition", reminderTile.SettingStartPosition.X.ToString() + "," + reminderTile.SettingStartPosition.Y.ToString());
            //reminderTile.Close();
            reminderTile.Dispose();
            reminderTile = null;
        }
    }
}
