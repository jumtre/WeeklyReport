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

namespace ToDoList
{
    public partial class AddToReport : Form
    {
        private ToDo toDo;

        public AddToReport()
        {
            InitializeComponent();
        }

        public AddToReport(ToDo toDoAdd)
        {
            InitializeComponent();
            toDo = toDoAdd;
        }

        private void AddToReport_Load(object sender, EventArgs e)
        {
            if (toDo == null)
            {
                MessageBox.Show("要添加的待办事项数据错误。", "提示");
                this.Close();
            }
            comboBoxProject.SelectedIndexChanged -= comboBoxProject_SelectedIndexChanged;
            comboBoxBranch.SelectedIndexChanged -= comboBoxBranch_SelectedIndexChanged;
            CommonFunc.BindProjectListToComboBox(comboBoxProject, null, true);
            CommonFunc.BindBranchListToComboBox(comboBoxBranch, null, true);
            comboBoxProject.SelectedIndexChanged += comboBoxProject_SelectedIndexChanged;
            comboBoxBranch.SelectedIndexChanged += comboBoxBranch_SelectedIndexChanged;
            if (toDo.Project != null && toDo.Project.ID != CommonData.ItemAllValue)
                comboBoxProject.SelectedValue = toDo.Project.ID;
            else
                comboBoxProject.SelectedValue = CommonData.ItemAllValue;
            if (toDo.Branch != null && toDo.Branch.ID != CommonData.ItemAllValue)
                comboBoxBranch.SelectedValue = toDo.Branch.ID;
            else
                comboBoxBranch.SelectedValue = CommonData.ItemAllValue;
            textBoxRelatedID.Text = toDo.RelatedID;
            dateTimePickerFinishTime.Value = toDo.FinishTime.HasValue ? toDo.FinishTime.Value : DateTime.Now;
            richTextBoxContent.Text = toDo.Title + (string.IsNullOrWhiteSpace(toDo.Content) ? string.Empty : "：" + toDo.Content);
        }

        private void buttonDateTimeNow_Click(object sender, EventArgs e)
        {
            dateTimePickerFinishTime.Value = DateTime.Now;
            dateTimePickerFinishTime.Checked = true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!(comboBoxProject.SelectedItem is Project project) || project.ID <= 0)
            {
                MessageBox.Show("项目不能为空", "提示");
                return;
            }
            if (string.IsNullOrWhiteSpace(richTextBoxContent.Text))
            {
                MessageBox.Show("内容不能为空", "提示");
                return;
            }
            string fields = "UserID, ProjectID, Content, Source, ToDoID";
            string values = CommonData.CurrentUser.ID + ", " + project.ID + ", " + "'" + richTextBoxContent.Text.Trim() + "', " + (int)EnumReportSource.Todo + ", " + toDo.ID;
            if (dateTimePickerFinishTime.Checked && dateTimePickerFinishTime.Value > DateTime.MinValue)
            {
                fields += ", FinishTime";
                values += ", " + DataConvert.ToAccessDateTimeValue(dateTimePickerFinishTime);
            }
            if (comboBoxBranch.SelectedItem is Branch branch && branch.ID != CommonData.ItemAllValue)
            {
                fields += ", BranchID";
                values += ", " + branch.ID;
            }
            if (textBoxRelatedID.Text.NotNullOrWhiteSpace())
            {
                fields += ", RelatedID";
                values += ", " + DataConvert.ToAccessStringValue(textBoxRelatedID);
            }
            string sql = "insert into Report (" + fields + ") values (" + values + ")";
            int i = CommonData.AccessHelper.ExecuteNonQuery(sql);
            //避免新增失败后用户不知道，此处进行提醒
            if (i > 0)
                this.Close();
            else
                MessageBox.Show("新增失败", "提示");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProject.SelectedItem is Project project && project.ID != CommonData.ItemAllValue)
            {
                comboBoxBranch.SelectedIndexChanged -= comboBoxBranch_SelectedIndexChanged;
                CommonFunc.BindBranchListToComboBoxByProjectID(comboBoxBranch, project.ID, null, true);
                comboBoxBranch.SelectedIndexChanged += comboBoxBranch_SelectedIndexChanged;
            }
        }

        private void comboBoxBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBranch.SelectedItem is Branch branch && branch.Project != null && branch.Project.ID != CommonData.ItemAllValue)
            {
                comboBoxProject.SelectedIndexChanged -= comboBoxProject_SelectedIndexChanged;
                comboBoxProject.SelectedValue = branch.Project.ID;
                comboBoxProject.SelectedIndexChanged += comboBoxProject_SelectedIndexChanged;
            }
        }
    }
}
