using Model;
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

namespace ToDoList
{
    public partial class ExportForm : Form
    {
        private List<ToDo> todoList;
        private DateTime? plannedTimeStartFrom;
        private DateTime? plannedTimeStartTo;
        private DateTime? plannedTimeEndFrom;
        private DateTime? plannedTimeEndTo;

        public ExportForm()
        {
            InitializeComponent();
        }

        public ExportForm(List<ToDo> todos, DateTime? plannedStartFrom, DateTime? plannedStartTo, DateTime? plannedEndFrom, DateTime? plannedEndTo)
        {
            InitializeComponent();
            todoList = todos;
            plannedTimeStartFrom = plannedStartFrom;
            plannedTimeStartTo = plannedStartTo;
            plannedTimeEndFrom = plannedEndFrom;
            plannedTimeEndTo = plannedEndTo;
        }

        private void ExportForm_Load(object sender, EventArgs e)
        {
            if (todoList == null || todoList.Count == 0)
            {
                MessageBox.Show("没有可以导出的事项", "提示");
                this.Close();
                return;
            }
            IEnumerable<ToDo> todos = todoList.OrderBy(r => r.FinishTime).ThenBy(r => r.ID);
            Dictionary<User, List<ToDo>> todoDict = new Dictionary<User, List<ToDo>>();
            List<User> users = new List<User>();
            User user = null;
            foreach (ToDo todo in todos)
            {
                if (user == null || user.ID != todo.User.ID)
                {
                    if (users.Count > 0 && users.Exists(p => p.ID == todo.User.ID))
                        user = users.FirstOrDefault(p => p.ID == todo.User.ID);
                    else
                    {
                        user = todo.User;
                        users.Add(user);
                    }
                }
                if (todoDict.ContainsKey(user))
                    todoDict[user].Add(todo);
                else
                    todoDict.Add(user, new List<ToDo> { todo});
            }
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine("本"+ reportType + "工作：");
            if (plannedTimeStartFrom.HasValue || plannedTimeStartTo.HasValue)
                sb.AppendLine("计划开始时间：" + (plannedTimeStartFrom.HasValue ? plannedTimeStartFrom.Value.ToString(Common.CommonData.DateTimeFormat) : "null") + " ～ " + (plannedTimeStartTo.HasValue ? plannedTimeStartTo.Value.ToString(Common.CommonData.DateTimeFormat) : "null"));
            if (plannedTimeEndFrom.HasValue || plannedTimeEndTo.HasValue)
                sb.AppendLine("计划结束时间：" + (plannedTimeEndFrom.HasValue ? plannedTimeEndFrom.Value.ToString(Common.CommonData.DateTimeFormat) : "null") + " ～ " + (plannedTimeEndTo.HasValue ? plannedTimeEndTo.Value.ToString(Common.CommonData.DateTimeFormat) : "null"));
            //sb.AppendLine("本"+ reportType + "工作：");
            if (sb.Length > 0)
                sb.AppendLine();
            int index = 1;
            foreach (KeyValuePair<User, List<ToDo>> pair in todoDict)
            {
                sb.AppendLine(pair.Key.Name + "：");
                index = 1;
                foreach (ToDo todo in pair.Value)
                {
                    string relatedID = string.Empty;
                    string done = string.Empty;
                    if (!string.IsNullOrWhiteSpace(todo.RelatedID))
                        relatedID = "    " + relatedID;
                    if (todo.Status.HasValue && todo.Status.Value == EnumToDoStatus.Done)
                        done = "    √";
                    sb.AppendLine((index++) + "、" + todo.Title + relatedID + done);
                    //if (report.Title.Contains("\n") || report.Title.Contains(Environment.NewLine))
                    //{
                    //    List<string> titleList = report.Title.Replace(Environment.NewLine, "\n").Split("\n".ToCharArray()).ToList();
                    //    //如果用Environment.NewLine来Split，会有空字符串加到List
                    //    //while (titleList.Contains(string.Empty))
                    //    //{
                    //    //    titleList.Remove(string.Empty);
                    //    //}
                    //    foreach (string title in titleList)
                    //    {
                    //        sb.AppendLine((index++) + "、" + title + relatedID + done);
                    //    }
                    //}
                    //else
                    //{
                    //    sb.AppendLine((index++) + "、" + report.Title);
                    //}
                }
                sb.AppendLine();
            }
            //sb.AppendLine();
            //sb.AppendLine("下"+ reportType + "计划：");
            richTextBoxContent.TextChanged -= richTextBoxContent_TextChanged;
            richTextBoxContent.Text = sb.ToString().TrimEnd();
            richTextBoxContent.TextChanged += richTextBoxContent_TextChanged;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "文本文件|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    sw.Write(richTextBoxContent.Text);
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
                this.Close();
            }
        }

        private void Reorder()
        {
            if (richTextBoxContent.Lines.Length <= 1)
                return;
            int integerLength = 1;
            int orderNo = 1;
            StringBuilder sb = new StringBuilder();
            foreach (string str in richTextBoxContent.Lines)
            {
                if (str.Length == 0)
                {
                    sb.AppendLine();
                    continue;
                }
                //if (Common.Validator.IsInteger(str))//如果内容全部是数字，这个内容实际上应该就没有意义，所以就不对这种内容做特殊处理了，否则还会影响性能
                //{

                //}
                //else if (Common.Validator.IsInteger(str.Substring(0, 1)))
                if (Common.Validator.IsInteger(str.Substring(0, 1)))
                {
                    integerLength++;
                    if (str.Length >= integerLength)
                    {
                        while (integerLength <= str.Length && Common.Validator.IsInteger(str.Substring(0, integerLength)))
                        {
                            integerLength++;
                        }
                        sb.AppendLine(orderNo.ToString() + str.Substring(integerLength - 1));
                    }
                    else
                    {
                        sb.AppendLine(orderNo.ToString());
                    }
                    integerLength = 1;
                    orderNo++;
                }
                else
                {
                    integerLength = 1;
                    orderNo = 1;
                    sb.AppendLine(str);
                }
            }
            richTextBoxContent.Text = sb.ToString();
        }

        private void buttonReorder_Click(object sender, EventArgs e)
        {
            Reorder();
        }

        private void richTextBoxContent_TextChanged(object sender, EventArgs e)
        {
            if (checkBoxAutoReorder.Checked)
                Reorder();
        }
    }
}
