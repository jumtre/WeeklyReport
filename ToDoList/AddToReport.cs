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
            CommonFunc.BindProjectListToComboBox(comboBoxOperateProject, null, true);
            if (toDo.Project != null && toDo.Project.ID != CommonData.ItemAllValue)
                comboBoxOperateProject.SelectedValue = toDo.Project.ID;
            else
                comboBoxOperateProject.SelectedValue = CommonData.ItemAllValue;
            dateTimePickerFinishTime.Value = toDo.FinishTime.HasValue ? toDo.FinishTime.Value : DateTime.Now;
            richTextBoxOperateContent.Text = toDo.Title + (string.IsNullOrWhiteSpace(toDo.Content) ? string.Empty : "：" + toDo.Content);
        }

        private void buttonDateTimeNow_Click(object sender, EventArgs e)
        {
            dateTimePickerFinishTime.Value = DateTime.Now;
            dateTimePickerFinishTime.Checked = true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!(comboBoxOperateProject.SelectedItem is Project project) || project.ID <= 0)
            {
                MessageBox.Show("项目不能为空", "提示");
                return;
            }
            if (string.IsNullOrWhiteSpace(richTextBoxOperateContent.Text))
            {
                MessageBox.Show("内容不能为空", "提示");
                return;
            }
            string fields = "UserID, ProjectID, Content, Source, ToDoID";
            string values = CommonData.CurrentUser.ID + ", " + project.ID + ", " + "'" + richTextBoxOperateContent.Text.Trim() + "', " + (int)EnumReportSource.Todo + ", " + toDo.ID;
            if (dateTimePickerFinishTime.Checked && dateTimePickerFinishTime.Value > DateTime.MinValue)
            {
                fields += ", FinishTime";
                values += ", #" + dateTimePickerFinishTime.Value.ToString(CommonData.DateTimeFormat) + "#";
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
    }
}
