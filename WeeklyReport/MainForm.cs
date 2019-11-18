using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Model;

namespace WeeklyReport
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 所有报告
        /// </summary>
        private List<Report> reportAll;
        /// <summary>
        /// 数据库帮助类
        /// </summary>
        private AccessHelper accessHelper;
        /// <summary>
        /// ini文件帮助类
        /// </summary>
        private IniHelper iniHelper;
        /// <summary>
        /// 当前用户ID
        /// </summary>
        private int currentUserID;

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
                return;
            }
            iniHelper = new IniHelper(CommonData.IniFilePath);
            string currentUserIDStr = iniHelper.Read("Common", "CurrentUserID");
            if (!int.TryParse(currentUserIDStr, out currentUserID))
            {
                MessageBox.Show("配置文件中没有当前用户的设置，请先运行管理工具设置当前用户。", "提示");
                this.Close();
                return;
            }
            accessHelper = new AccessHelper(CommonData.DBPath);
            DateTime now = DateTime.Now;
            DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;
            int nDayOfWeek = (int)dayOfWeek;
            if (dayOfWeek == DayOfWeek.Sunday)
                nDayOfWeek = 7;
            dateTimePickerSearchFrom.Value = now.AddDays(-(nDayOfWeek - 1)).Date;
            dateTimePickerSearchTo.Value = dateTimePickerSearchFrom.Value.Date.AddDays(6).Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            BindDict();
        }

        private void BindDict()
        {
            List<Project> projectList = new List<Project>();
            Project projectAll = new Project
            {
                ID = 0,
                Name = "（全部）"
            };
            projectList.Add(projectAll);
            DataTable dtProject = accessHelper.GetDataTable("select ID, Name from Project");
            if (dtProject != null && dtProject.Rows.Count > 0)
            {
                foreach (DataRow row in dtProject.Rows)
                {
                    Project project = new Project()
                    {
                        ID = DataConvert.ToInt(row["ID"]),
                        Name = DataConvert.ToString(row["Name"])
                    };
                    projectList.Add(project);
                }
            }
            comboBoxSearchProject.DataSource = projectList;
            comboBoxSearchProject.ValueMember = "ID";
            comboBoxSearchProject.DisplayMember = "Name";
            comboBoxAddProject.DataSource = new List<Project>(projectList);
            comboBoxAddProject.ValueMember = "ID";
            comboBoxAddProject.DisplayMember = "Name";
        }

        private void GetReport()
        {
            if (reportAll != null && reportAll.Count > 0)
                reportAll.Clear();
            StringBuilder sql = new StringBuilder("select r.ID,r.UserID,u.Name as UserName,r.ProjectID,p.Name as ProjectName,r.Content,r.FinishTime from (Report r left join [User] u on r.UserID=u.ID) left join Project p on r.ProjectID=p.ID where 1=1");
            if (dateTimePickerSearchFrom.Checked)
                sql.Append(" and r.FinishTime >= #" + dateTimePickerSearchFrom.Value.ToString(CommonData.DateFormat + " 00:00:00") + "#");
            if (dateTimePickerSearchTo.Checked)
                sql.Append(" and r.FinishTime <= #" + dateTimePickerSearchTo.Value.ToString(CommonData.DateFormat + " 23:59:59") + "#");
            if (comboBoxSearchProject.SelectedItem is Project project && project.ID > 0)
                sql.Append(" and r.ProjectID = " + comboBoxSearchProject.SelectedValue);
            if (!string.IsNullOrWhiteSpace(textBoxKeyWord.Text.Trim()))
                sql.Append(" and r.Content like '%" + textBoxKeyWord.Text.Trim() + "%'");
            sql.Append(" order by r.FinishTime,r.ID");

            if (reportAll == null)
                reportAll = new List<Report>();
            else if (reportAll.Count > 0)
                reportAll.Clear();
            reportAll.Clear();
            DataTable dt = accessHelper.GetDataTable(sql.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Report report = new Report
                    {
                        ID = DataConvert.ToDecimal(row["ID"]),
                        User = new User()
                        {
                            ID = DataConvert.ToInt(row["UserID"]),
                            Name = DataConvert.ToString(row["UserName"])
                        },
                        Project = new Project()
                        {
                            ID = DataConvert.ToInt(row["ProjectID"]),
                            Name = DataConvert.ToString(row["ProjectName"])
                        },
                        Content = DataConvert.ToString(row["Content"]),
                        FinishTime = DataConvert.ToDateTime(row["FinishTime"])
                    };
                    reportAll.Add(report);
                }
            }
            BindReport();
        }

        private void BindReport()
        {
            dataGridViewShow.Rows.Clear();
            if (reportAll == null || reportAll.Count == 0)
                return;
            foreach (Report report in reportAll)
            {
                int index = dataGridViewShow.Rows.Add();
                DataGridViewRow row = dataGridViewShow.Rows[index];
                row.Cells[ColumnSortNo.Index].Value = index + 1;
                row.Cells[ColumnProject.Index].Value = report.Project.Name;
                row.Cells[ColumnProject.Index].Tag = report.Project.ID;
                row.Cells[ColumnContent.Index].Value = report.Content;
                row.Cells[ColumnFinishTime.Index].Value = report.FinishTime;
                row.Tag = report;
            }
            dataGridViewShow.ClearSelection();
        }

        private void ClearAddControls()
        {
            comboBoxAddProject.SelectedValue = 0;
            dateTimePickerAddFinishTime.Checked = false;
            richTextBoxAddContent.Text = string.Empty;
        }

        private void dataGridViewShow_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewShow.SelectedRows.Count != 1)
                return;
            ClearAddControls();
            DataGridViewRow row = dataGridViewShow.SelectedRows[0];
            if (!(row.Tag is Report report))
                return;
            comboBoxAddProject.SelectedValue = report.Project.ID;
            if (report.FinishTime > DateTime.MinValue)
            {
                dateTimePickerAddFinishTime.Value = report.FinishTime;
                dateTimePickerAddFinishTime.Checked = true;
            }
            richTextBoxAddContent.Text = report.Content;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            GetReport();
        }

        private void ShowMessageAskRefresh()
        {
            if (MessageBox.Show("操作完成，是否刷新列表？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                ClearAddControls();
                GetReport();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!(comboBoxAddProject.SelectedItem is Project project) || project.ID <= 0)
            {
                MessageBox.Show("项目不能为空", "提示");
                return;
            }
            if (string.IsNullOrWhiteSpace(richTextBoxAddContent.Text))
            {
                MessageBox.Show("内容不能为空", "提示");
                return;
            }
            string fileds = "UserID, ProjectID, Content";
            string valuesFormat = "{0}, {1}, '{2}'";
            string values = string.Empty;
            if (dateTimePickerAddFinishTime.Checked && dateTimePickerAddFinishTime.Value > DateTime.MinValue)
            {
                fileds += ", FinishTime";
                valuesFormat += ", #{3}#";
                values = string.Format(valuesFormat, currentUserID, project.ID, richTextBoxAddContent.Text.Trim(), dateTimePickerAddFinishTime.Value.ToString(CommonData.DateTimeFormat));
            }
            else
            {
                values = string.Format(valuesFormat, currentUserID, project.ID, richTextBoxAddContent.Text.Trim());
            }
            string sql = "insert into Report (" + fileds + ") values (" + values + ")";
            accessHelper.ExecuteNonQuery(sql);
            richTextBoxAddContent.Text = string.Empty;
            ShowMessageAskRefresh();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewShow.SelectedRows.Count != 1)
            {
                MessageBox.Show("选中一行后再修改", "提示");
                return;
            }
            if (!(dataGridViewShow.SelectedRows[0].Tag is Report report) || report.ID <= 0)
            {
                MessageBox.Show("报告数据错误", "提示");
                return;
            }
            if (!(comboBoxAddProject.SelectedItem is Project project) || project.ID <= 0)
            {
                MessageBox.Show("项目不能为空", "提示");
                return;
            }
            if (string.IsNullOrWhiteSpace(richTextBoxAddContent.Text))
            {
                MessageBox.Show("内容不能为空", "提示");
                return;
            }
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("update Report set ProjectID = {0}, Content = '{1}'", project.ID, richTextBoxAddContent.Text.Trim());
            if (dateTimePickerAddFinishTime.Checked && dateTimePickerAddFinishTime.Value > DateTime.MinValue)
            {
                sql.AppendFormat(", FinishTime = #{0}#", dateTimePickerAddFinishTime.Value.ToString(CommonData.DateTimeFormat));
            }
            sql.AppendFormat(" where ID = {0}", report.ID);
            accessHelper.ExecuteNonQuery(sql.ToString());
            //MessageBox.Show("修改完成", "提示");
            ShowMessageAskRefresh();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewShow.SelectedRows.Count != 1)
            {
                MessageBox.Show("选中一行后再删除", "提示");
                return;
            }
            if (!(dataGridViewShow.SelectedRows[0].Tag is Report report) || report.ID <= 0)
            {
                MessageBox.Show("报告数据错误", "提示");
                return;
            }
            accessHelper.ExecuteNonQuery("delete from Report where ID = " + report.ID);
            //MessageBox.Show("删除完成", "提示");
            ShowMessageAskRefresh();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            GetReport();
            if (reportAll == null || reportAll.Count == 0)
            {
                MessageBox.Show("没有可以导出的报告", "提示");
                return;
            }
            string reportType = "周";
            if (dateTimePickerSearchFrom.Value.Day == 1 && dateTimePickerSearchTo.Value - dateTimePickerSearchFrom.Value > new TimeSpan(7, 0, 0, 0))
                reportType = "月";
            ExportForm export = new ExportForm(reportAll, reportType);
            export.ShowDialog();
        }

        private void buttonDateTimeNow_Click(object sender, EventArgs e)
        {
            dateTimePickerAddFinishTime.Value = DateTime.Now;
            dateTimePickerAddFinishTime.Checked = true;
        }
    }
}
