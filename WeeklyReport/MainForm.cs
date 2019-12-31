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
            try
            {
                CommonFunc.GetCurrentUser();
            }
            catch (Exception ex)
            {
                if (ex is CommonInfoException)
                    MessageBox.Show(ex.Message, "提示");
                this.Close();
                return;
            }
            DateTime dtWeekStart = DateTime.Now;
            DateTime dtWeekEnd = DateTime.Now;
            CommonFunc.GetWeekDateTime(ref dtWeekStart, ref dtWeekEnd);
            dateTimePickerSearchFrom.Value = dtWeekStart;
            dateTimePickerSearchTo.Value = dtWeekEnd;
            BindDict();
        }

        private void BindDict()
        {
            //List<Project> projectList = CommonFunc.GetProjectListForSearch();
            //CommonFunc.BindProjectListToComboBox(comboBoxSearchProject, projectList, true);
            //CommonFunc.BindProjectListToComboBox(comboBoxOperateProject, new List<Project>(projectList), true);
            CommonFunc.BindProjectListToComboBox(comboBoxSearchProject, null, true);
            CommonFunc.BindProjectListToComboBox(comboBoxOperateProject, null, true);
        }

        private void GetReport()
        {
            if (reportAll != null && reportAll.Count > 0)
                reportAll.Clear();
            StringBuilder sql = new StringBuilder("select r.ID, r.UserID, u.Name as UserName, r.ProjectID, p.Name as ProjectName, r.Content, r.FinishTime, r.Source from (Report r left join [User] u on r.UserID=u.ID) left join Project p on r.ProjectID=p.ID where 1=1");
            if (dateTimePickerSearchFrom.Checked)
                sql.Append(" and r.FinishTime >= #" + dateTimePickerSearchFrom.Value.ToString(CommonData.DateFormat + " 00:00:00") + "#");
            if (dateTimePickerSearchTo.Checked)
                sql.Append(" and r.FinishTime <= #" + dateTimePickerSearchTo.Value.ToString(CommonData.DateFormat + " 23:59:59") + "#");
            if (comboBoxSearchProject.SelectedItem is Project project && project.ID != CommonData.ItemAllValue)
                sql.Append(" and r.ProjectID = " + comboBoxSearchProject.SelectedValue);
            if (!string.IsNullOrWhiteSpace(textBoxKeyWord.Text.Trim()))
                sql.Append(" and r.Content like '%" + textBoxKeyWord.Text.Trim() + "%'");
            sql.Append(" order by r.FinishTime,r.ID");

            if (reportAll == null)
                reportAll = new List<Report>();
            else if (reportAll.Count > 0)
                reportAll.Clear();
            reportAll.Clear();
            DataTable dt = CommonData.AccessHelper.GetDataTable(sql.ToString());
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
                        FinishTime = DataConvert.ToDateTime(row["FinishTime"]),
                        Source = (EnumReportSource?)DataConvert.ToEnum<EnumReportSource>(row["Source"])
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

        private void ClearOperateControls()
        {
            comboBoxOperateProject.SelectedValue = CommonData.ItemAllValue;
            dateTimePickerOperateFinishTime.Checked = false;
            richTextBoxOperateContent.Text = string.Empty;
        }

        private void dataGridViewShow_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewShow.SelectedRows.Count != 1)
                return;
            ClearOperateControls();
            DataGridViewRow row = dataGridViewShow.SelectedRows[0];
            if (!(row.Tag is Report report))
                return;
            comboBoxOperateProject.SelectedValue = report.Project.ID;
            if (report.FinishTime > DateTime.MinValue)
            {
                dateTimePickerOperateFinishTime.Value = report.FinishTime;
                dateTimePickerOperateFinishTime.Checked = true;
            }
            richTextBoxOperateContent.Text = report.Content;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            GetReport();
        }

        private void ShowMessageAskRefresh()
        {
            if (MessageBox.Show("操作完成，是否刷新列表？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                ClearOperateControls();
                GetReport();
            }
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
            string fields = "UserID, ProjectID, Content, Source";
            string values = CommonData.CurrentUser.ID + ", " + project.ID + ", " + "'" + richTextBoxOperateContent.Text.Trim() + "', " + (int)EnumReportSource.Manual;
            if (dateTimePickerOperateFinishTime.Checked && dateTimePickerOperateFinishTime.Value > DateTime.MinValue)
            {
                fields += ", FinishTime";
                values += ", #" + dateTimePickerOperateFinishTime.Value.ToString(CommonData.DateTimeFormat) + "#";
            }
            string sql = "insert into Report (" + fields + ") values (" + values + ")";
            CommonData.AccessHelper.ExecuteNonQuery(sql);
            richTextBoxOperateContent.Text = string.Empty;
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
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("update Report set ProjectID = {0}, Content = '{1}'", project.ID, richTextBoxOperateContent.Text.Trim());
            if (dateTimePickerOperateFinishTime.Checked && dateTimePickerOperateFinishTime.Value > DateTime.MinValue)
            {
                sql.AppendFormat(", FinishTime = #{0}#", dateTimePickerOperateFinishTime.Value.ToString(CommonData.DateTimeFormat));
            }
            sql.AppendFormat(" where ID = {0}", report.ID);
            CommonData.AccessHelper.ExecuteNonQuery(sql.ToString());
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
            CommonData.AccessHelper.ExecuteNonQuery("delete from Report where ID = " + report.ID);
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
            if ((dateTimePickerSearchFrom.Value.Day == 1 && dateTimePickerSearchTo.Value - dateTimePickerSearchFrom.Value > new TimeSpan(7, 0, 0, 0))
                || (long)DateTimeManger.DateDiff(DateInterval.Month, dateTimePickerSearchFrom.Value, dateTimePickerSearchTo.Value) == 1)
                reportType = "月";
            ExportForm export = new ExportForm(reportAll, reportType);
            //export.ShowDialog();
            //export.Show(this);
            export.Show();
        }

        private void buttonDateTimeNow_Click(object sender, EventArgs e)
        {
            dateTimePickerOperateFinishTime.Value = DateTime.Now;
            dateTimePickerOperateFinishTime.Checked = true;
        }
    }
}
