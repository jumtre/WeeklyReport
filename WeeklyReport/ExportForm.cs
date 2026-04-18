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

namespace WeeklyReport
{
    public partial class ExportForm : Form
    {
        private List<Report> reportList;
        private string reportType = "周";
        public ExportForm()
        {
            InitializeComponent();
        }

        public ExportForm(List<Report> reports, string reporttype = "周")
        {
            InitializeComponent();
            reportList = reports;
            reportType = reporttype;
        }

        private void ExportForm_Load(object sender, EventArgs e)
        {
            if (reportList == null || reportList.Count == 0)
            {
                MessageBox.Show("没有可以导出的报告", "提示");
                this.Close();
                return;
            }
            IEnumerable<Report> reports = reportList.OrderBy(r => r.FinishTime).ThenBy(r => r.ID);
            Dictionary<Project, Dictionary<Branch, List<Report>>> reportDict = new Dictionary<Project, Dictionary<Branch, List<Report>>>();
            List<Project> projects = new List<Project>();
            List<Branch> branches = new List<Branch>();
            Project project = null;
            Branch branch = null;
            Branch emptyBrach = new Branch()
            {
                ID = -1,
                Name = string.Empty
            };
            foreach (Report report in reports)
            {
                if (project == null || project.ID != report.Project.ID)
                {
                    if (projects.Count > 0)
                    {
                        project = projects.FirstOrDefault(p => p.ID == report.Project.ID);
                        if (project == null)
                        {
                            project = report.Project;
                            projects.Add(project);
                        }
                    }
                    else
                    {
                        project = report.Project;
                        projects.Add(project);
                    }
                }
                if (report.Branch != null && report.Branch.ID >= 0)
                {
                    if (branch == null || branch.ID != report.Branch.ID)
                    {
                        if (branches.Count > 0)
                        {
                            branch = branches.FirstOrDefault(b => b.ID == report.Branch.ID);
                            if (branch == null)
                            {
                                branch = report.Branch;
                                branches.Add(branch);
                            }
                        }
                        else
                        {
                            branch = report.Branch;
                            branches.Add(branch);
                        }
                    }
                }
                else
                {
                    branch = emptyBrach;
                }
                if (reportDict.ContainsKey(project))
                {
                    if (reportDict[project].ContainsKey(branch))
                        reportDict[project][branch].Add(report);
                    else
                        reportDict[project].Add(branch, new List<Report> { report });
                }
                else
                {
                    Dictionary<Branch, List<Report>> d = new Dictionary<Branch, List<Report>>();
                    d.Add(branch, new List<Report> { report });
                    reportDict.Add(project, d);
                }
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("本"+ reportType + "工作：");
            int index = 1;
            foreach (KeyValuePair<Project, Dictionary<Branch, List<Report>>> projectPair in reportDict)
            {
                foreach (KeyValuePair<Branch, List<Report>> branchPair in reportDict[projectPair.Key])
                {
                    sb.AppendLine(projectPair.Key.Name + (string.IsNullOrWhiteSpace(branchPair.Key.Name) ? string.Empty : ("-" + branchPair.Key.Name)) + "：");
                    index = 1;
                    foreach (Report report in branchPair.Value)
                    {
                        if (report.Content.Contains("\n") || report.Content.Contains(Environment.NewLine))
                        {
                            List<string> contentList = report.Content.Replace(Environment.NewLine, "\n").Split("\n".ToCharArray()).ToList();
                            //如果用Environment.NewLine来Split，会有空字符串加到List
                            //while (contentList.Contains(string.Empty))
                            //{
                            //    contentList.Remove(string.Empty);
                            //}
                            foreach (string content in contentList)
                            {
                                sb.AppendLine((index++) + "、" + content);
                            }
                        }
                        else
                        {
                            sb.AppendLine((index++) + "、" + report.Content);
                        }
                    }
                    sb.AppendLine();
                }
            }
            sb.AppendLine();
            sb.AppendLine("下"+ reportType + "计划：");
            richTextBoxContent.TextChanged -= richTextBoxContent_TextChanged;
            richTextBoxContent.Text = sb.ToString();
            richTextBoxContent.TextChanged += richTextBoxContent_TextChanged;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "文本文件|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //File.WriteAllText(sfd.FileName, richTextBoxContent.Text);
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
            richTextBoxContent.Text = sb.ToString().TrimEnd(Environment.NewLine.ToCharArray());
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
