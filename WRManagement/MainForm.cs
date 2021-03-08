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
        /// 数据库帮助类
        /// </summary>
        private AccessHelper accessHelper;
        /// <summary>
        /// 当前编辑数据的类型
        /// </summary>
        private CurrentDataType currentDataType;
        /// <summary>
        /// 是否触发DataGridView的SelectionChanged事件
        /// </summary>
        private bool fireSelectionChanged = true;
        /// <summary>
        /// ini文件帮助类
        /// </summary>
        private IniHelper iniHelper;

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
            accessHelper = new AccessHelper(CommonData.DBPath);
            iniHelper = new IniHelper(CommonData.ConfigFilePath);
            BindDict();
        }

        private void BindDict()
        {
            List<string> dictList = new List<string>() { "", "用户", "项目", "分支" };
            comboBoxDict.DataSource = dictList;

            BindUserDict();
            BindProjectDict();
            BindBranchDict();
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
            string currentUserID = iniHelper.Read("Common", "CurrentUserID");
            if (currentUserID.NotNullOrWhiteSpace())
            {
                comboBoxCurrentUser.SelectedItem = users.FirstOrDefault(u => u.ID.ToString() == currentUserID);
            }
            else
            {
                string a = string.Empty;
                string currentUserName = string.Empty;
                currentUserName = iniHelper.Read("Common", "CurrentUserName");
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
            string currentProjectID = iniHelper.Read("Common", "CurrentProjectID");
            if (currentProjectID.NotNullOrWhiteSpace())
            {
                comboBoxCurrentProject.SelectedItem = projects.FirstOrDefault(u => u.ID.ToString() == currentProjectID);
            }
            else
            {
                //comboBoxCurrentProject.Text= iniHelper.Read("Common", "CurrentProjectName");
                string currentProjectName = iniHelper.Read("Common", "CurrentProjectName");
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
            string currentBranchID = iniHelper.Read("Common", "CurrentBranchID");
            if (currentBranchID.NotNullOrWhiteSpace())
            {
                comboBoxCurrentBranch.SelectedItem = branches.FirstOrDefault(u => u.ID.ToString() == currentBranchID);
            }
            else
            {
                string currentBranchName = iniHelper.Read("Common", "CurrentBranchName");
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
            string sql = "select count(*) from Branch where ProjectID = " + projectID + " and Name = '" + branchName + "'";
            int i = -1;
            if (int.TryParse(accessHelper.ExecuteScalar(sql).ToString(), out i) && i > 0)
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
            string sql = string.Empty;
            if (currentDataType == CurrentDataType.User)
            {
                sql = "insert into [User] (Name) values ('" + textBoxItemName.Text.Trim() + "')";
            }
            else if (currentDataType == CurrentDataType.Project)
            {
                sql = "insert into Project (Name) values ('" + textBoxItemName.Text.Trim() + "')";
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
                if(BranchExists(projectID, textBoxItemName.Text.Trim()))
                {
                    MessageBox.Show("项目中已存在同名分支", "提示");
                    return;
                }
                sql = "insert into Branch (Name, [Memo], ProjectID) values ('" + textBoxItemName.Text.Trim() + "', '" + textBoxMemo.Text.Trim() + "', " + projectID + ")";
            }
            if (!string.IsNullOrWhiteSpace(sql))
                accessHelper.ExecuteNonQuery(sql);
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
            string sql = string.Empty;
            if (currentDataType == CurrentDataType.User)
            {
                sql = string.Format("update [User] set Name = '{0}' where ID = {1}", textBoxItemName.Text.Trim(), textBoxItemName.Tag.ToString());
            }
            else if (currentDataType == CurrentDataType.Project)
            {
                sql = string.Format("update Project set Name = '{0}' where ID = {1}", textBoxItemName.Text.Trim(), textBoxItemName.Tag.ToString());
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
                sql = string.Format("update Branch set Name = '{0}', [Memo] = '{1}', ProjectID = {2} where ID = {3}", textBoxItemName.Text.Trim(), textBoxMemo.Text.Trim(), projectID, textBoxItemName.Tag.ToString());
            }
            if (!string.IsNullOrWhiteSpace(sql))
                accessHelper.ExecuteNonQuery(sql);
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
            string sql = string.Empty;
            if (currentDataType == CurrentDataType.User)
            {
                sql = "delete from [User] where ID = " + textBoxItemName.Tag.ToString();
            }
            else if (currentDataType == CurrentDataType.Project)
            {
                sql = "delete from Project where ID = " + textBoxItemName.Tag.ToString();
            }
            else if (currentDataType == CurrentDataType.Branch)
            {
                sql = "delete from Branch where ID = " + textBoxItemName.Tag.ToString();
            }
            if (!string.IsNullOrWhiteSpace(sql))
                accessHelper.ExecuteNonQuery(sql);
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
            //if (iniHelper == null)
            //    iniHelper = new IniHelper(CommonData.ConfigFilePath);
            iniHelper.Write("Common", "CurrentUserID", currentUser.ID.ToString());
            iniHelper.Write("Common", "CurrentUserName", currentUser.Name);
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
            //if (iniHelper == null)
            //    iniHelper = new IniHelper(CommonData.ConfigFilePath);
            if (currentProject == null)
            {
                iniHelper.Write("Common", "CurrentProjectID", string.Empty);
                iniHelper.Write("Common", "CurrentProjectName", string.Empty);
                currentBranch = null;
            }
            else
            {
                iniHelper.Write("Common", "CurrentProjectID", currentProject.ID.ToString());
                iniHelper.Write("Common", "CurrentProjectName", currentProject.Name);
            }
            if (currentBranch == null)
            {
                iniHelper.Write("Common", "CurrentBranchID", string.Empty);
                iniHelper.Write("Common", "CurrentBranchName", string.Empty);
            }
            else
            {
                iniHelper.Write("Common", "CurrentBranchID", currentBranch.ID.ToString());
                iniHelper.Write("Common", "CurrentBranchName", currentBranch.Name);
            }
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
    }
}
