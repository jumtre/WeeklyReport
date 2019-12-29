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
            Project
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
        /// 是否触发DataGridView的SelectionChanged时间
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
            BindDict();
        }

        private void BindDict()
        {
            List<string> dictList = new List<string>() { "", "用户", "项目" };
            comboBoxDict.DataSource = dictList;

            BindUserDict();
        }

        private void BindUserDict(bool lazyLoad = true)
        {
            CommonFunc.BindUserListToComboBox(comboBoxCurrentUser, null, false, lazyLoad);
        }

        private void BindUserList(List<User> list = null)
        {
            fireSelectionChanged = false;
            dataGridViewShow.Rows.Clear();
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

        private void RefreshData()
        {
            if (currentDataType == CurrentDataType.User)
            {
                BindUserList();
                BindUserDict(false);
            }
            else if (currentDataType == CurrentDataType.Project)
                BindProjectList();
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
            if (!string.IsNullOrWhiteSpace(sql))
                accessHelper.ExecuteNonQuery(sql);
            textBoxItemName.Text = string.Empty;
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
            if (iniHelper == null)
                iniHelper = new IniHelper(CommonData.ConfigFilePath);
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

            //todo 文件锁定状态下的备份
            //using
            //FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            //StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
            if (checkBoxBackupDatabase.Checked)
                File.Copy(CommonData.DBPath, Path.Combine(backupPath, CommonData.DBFileName));
            if (checkBoxBackupConfigFile.Checked)
                File.Copy(CommonData.ConfigFilePath, Path.Combine(backupPath, CommonData.ConfigFileName));

            buttonBackup.Enabled = true;
            this.Cursor = Cursors.Default;
        }
    }
}
