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
            comboBoxSearchProject.SelectedIndexChanged -= comboBoxSearchProject_SelectedIndexChanged;
            comboBoxOperateProject.SelectedIndexChanged -= comboBoxOperateProject_SelectedIndexChanged;
            comboBoxSearchBranch.SelectedIndexChanged -= comboBoxSearchBranch_SelectedIndexChanged;
            comboBoxOperateBranch.SelectedIndexChanged -= comboBoxOperateBranch_SelectedIndexChanged;
            CommonFunc.BindProjectListToComboBox(comboBoxSearchProject, null, true);
            CommonFunc.BindProjectListToComboBox(comboBoxOperateProject, null, true);
            if (CommonData.CurrentProject != null && CommonData.CurrentProject.ID != CommonData.ItemNullValue && CommonData.CurrentProject.ID != CommonData.ItemAllValue)
            {
                comboBoxOperateProject.SelectedValue = CommonData.CurrentProject.ID;
                if (CommonData.ApplyCurrentProjectAndBranchToSearch)
                    comboBoxSearchProject.SelectedValue = CommonData.CurrentProject.ID;
            }
            CommonFunc.BindBranchListToComboBox(comboBoxSearchBranch, null, true);
            CommonFunc.BindBranchListToComboBox(comboBoxOperateBranch, null, true);
            if (CommonData.CurrentBranch != null && CommonData.CurrentBranch.ID != CommonData.ItemNullValue && CommonData.CurrentBranch.ID != CommonData.ItemAllValue)
            {
                comboBoxOperateBranch.SelectedValue = CommonData.CurrentBranch.ID;
                if (CommonData.ApplyCurrentProjectAndBranchToSearch)
                    comboBoxSearchBranch.SelectedValue = CommonData.CurrentBranch.ID;
            }
            comboBoxSearchProject.SelectedIndexChanged += comboBoxSearchProject_SelectedIndexChanged;
            comboBoxOperateProject.SelectedIndexChanged += comboBoxOperateProject_SelectedIndexChanged;
            comboBoxSearchBranch.SelectedIndexChanged += comboBoxSearchBranch_SelectedIndexChanged;
            comboBoxOperateBranch.SelectedIndexChanged += comboBoxOperateBranch_SelectedIndexChanged;
        }

        private void GetReport()
        {
            if (reportAll != null && reportAll.Count > 0)
                reportAll.Clear();
            StringBuilder sql = new StringBuilder("select r.ID, r.UserID, u.Name as UserName, r.ProjectID, p.Name as ProjectName, r.BranchID, b.Name as BranchName, r.RelatedID, r.Content, r.FinishTime, r.Source, r.ToDoID from ((Report r left join [User] u on r.UserID = u.ID) left join Project p on r.ProjectID = p.ID) left join Branch b on r.BranchID = b.ID where 1 = 1");
            SqlParams paramDict = new SqlParams();
            if (dateTimePickerSearchFrom.Checked)
            {
                sql.Append(paramDict.AddToWhere("FinishTime", ">=", "FinishTimeStart", DataConvert.ToDateTimeValue(dateTimePickerSearchFrom, 0, 0, 0), "r"));
            }
            if (dateTimePickerSearchTo.Checked)
            {
                sql.Append(paramDict.AddToWhere("FinishTime", "<=", "FinishTimeEnd", DataConvert.ToDateTimeValue(dateTimePickerSearchTo, 23, 59, 59), "r"));
            }
            if (comboBoxSearchProject.SelectedItem is Project project && project.ID != CommonData.ItemAllValue)
            {
                sql.Append(paramDict.AddToWhere("ProjectID", comboBoxSearchProject.SelectedValue, "r"));
            }
            if (comboBoxSearchBranch.SelectedItem is Branch branch && branch.ID != CommonData.ItemAllValue)
            {
                sql.Append(paramDict.AddToWhere("BranchID", comboBoxSearchBranch.SelectedValue, "r"));
            }
            if (!string.IsNullOrWhiteSpace(textBoxSearchRelatedID.Text))
            {
                sql.Append(paramDict.AddToWhere("RelatedID", textBoxSearchRelatedID, "r"));
            }
            if (!string.IsNullOrWhiteSpace(textBoxKeyWord.Text))
            {
                sql.Append(paramDict.AddLikeToWhere("Content", textBoxKeyWord, "r"));
            }
            sql.Append(" order by r.FinishTime, r.ID");

            if (reportAll == null)
                reportAll = new List<Report>();
            else if (reportAll.Count > 0)
                reportAll.Clear();
            reportAll.Clear();
            DataTable dt = CommonData.AccessHelper.GetDataTable(sql.ToString(), paramDict);
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
                        Branch = new Branch()
                        {
                            ID = DataConvert.ToInt(row["BranchID"]),
                            Name = DataConvert.ToString(row["BranchName"])
                        },
                        RelatedID = DataConvert.ToString(row["RelatedID"]),
                        Content = DataConvert.ToString(row["Content"]),
                        FinishTime = DataConvert.ToDateTime(row["FinishTime"]),
                        Source = (EnumReportSource?)DataConvert.ToEnum<EnumReportSource>(row["Source"]),
                        ToDoID = DataConvert.ToNullableDecimal(row["ToDoID"])
                    };
                    reportAll.Add(report);
                }
            }
            BindReport();
        }

        private void BindReport()
        {
            dataGridViewShow.SelectionChanged -= dataGridViewShow_SelectionChanged;
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
                if (report.Branch != null)
                {
                    row.Cells[ColumnBranch.Index].Value = report.Branch.Name;
                    row.Cells[ColumnBranch.Index].Tag = report.Branch;
                }
                row.Cells[ColumnContent.Index].Value = report.Content;
                row.Cells[ColumnFinishTime.Index].Value = report.FinishTime;
                row.Tag = report;
            }
            dataGridViewShow.ClearSelection();
            dataGridViewShow.SelectionChanged += dataGridViewShow_SelectionChanged;
        }

        private void ClearOperateControls()
        {
            if (CommonData.CurrentProject != null && CommonData.CurrentProject.ID != CommonData.ItemNullValue && CommonData.CurrentProject.ID != CommonData.ItemAllValue)
                comboBoxOperateProject.SelectedValue = CommonData.CurrentProject.ID;
            else
                comboBoxOperateProject.SelectedValue = CommonData.ItemAllValue;
            if (CommonData.CurrentBranch != null && CommonData.CurrentBranch.ID != CommonData.ItemNullValue && CommonData.CurrentBranch.ID != CommonData.ItemAllValue)
                comboBoxOperateBranch.SelectedValue = CommonData.CurrentBranch.ID;
            else
                comboBoxOperateBranch.SelectedValue = CommonData.ItemAllValue;
            dateTimePickerOperateFinishTime.Checked = false;
            textBoxOperateRelatedID.Text = string.Empty;
            richTextBoxOperateContent.Text = string.Empty;
            richTextBoxOperateContent.Tag = null;
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
            if (report.Branch != null && report.Branch.ID > 0)
                comboBoxOperateBranch.SelectedValue = report.Branch.ID;
            else
                comboBoxOperateBranch.SelectedValue = CommonData.ItemAllValue;
            if (report.FinishTime > DateTime.MinValue)
            {
                dateTimePickerOperateFinishTime.Value = report.FinishTime;
                dateTimePickerOperateFinishTime.Checked = true;
            }
            textBoxOperateRelatedID.Text = report.RelatedID;
            richTextBoxOperateContent.Text = report.Content;
            richTextBoxOperateContent.Tag = report;
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
            SqlParams paramDict = new SqlParams();
            paramDict.Add("UserID", CommonData.CurrentUser.ID);
            paramDict.Add("ProjectID", project.ID);
            paramDict.Add("Content", richTextBoxOperateContent.Text.Trim());
            paramDict.Add("Source", (int)EnumReportSource.Manual);
            if (dateTimePickerOperateFinishTime.Checked && dateTimePickerOperateFinishTime.Value > DateTime.MinValue)
            {
                paramDict.Add("FinishTime", dateTimePickerOperateFinishTime.Value);
            }
            if (comboBoxOperateBranch.SelectedItem is Branch branch && branch.ID != CommonData.ItemAllValue)
            {
                paramDict.Add("BranchID", comboBoxOperateBranch.SelectedValue);
            }
            if (!string.IsNullOrWhiteSpace(textBoxOperateRelatedID.Text))
            {
                paramDict.Add("RelatedID", textBoxOperateRelatedID.Text.Trim());
            }
            CommonData.AccessHelper.Insert("Report", paramDict);
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
            SqlParams setParamDict = new SqlParams();
            setParamDict.Add("ProjectID", project.ID);
            setParamDict.Add("RelatedID", string.IsNullOrWhiteSpace(textBoxOperateRelatedID.Text) ? null : textBoxOperateRelatedID.Text.Trim());
            setParamDict.Add("Content", richTextBoxOperateContent.Text.Trim());
            SqlParams whereParamDict = new SqlParams();
            if (dateTimePickerOperateFinishTime.Checked && dateTimePickerOperateFinishTime.Value > DateTime.MinValue)
            {
                setParamDict.Add("FinishTime", dateTimePickerOperateFinishTime.Value);
            }
            if (comboBoxOperateBranch.SelectedItem is Branch branch)
            {
                if (branch.ID == CommonData.ItemAllValue)
                    setParamDict.Add("BranchID", null);
                else
                    setParamDict.Add("BranchID", comboBoxOperateBranch.SelectedValue);
            }
            whereParamDict.Add("ID", report.ID);
            CommonData.AccessHelper.Update("Report", setParamDict, whereParamDict);
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
            CommonData.AccessHelper.Delete("Report", "ID", report.ID);
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

        private void comboBoxSearchProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            Project project = null;
            if (comboBoxSearchProject.SelectedItem is Project)
                project = comboBoxSearchProject.SelectedItem as Project;
            comboBoxSearchBranch.SelectedIndexChanged -= comboBoxSearchBranch_SelectedIndexChanged;
            if (project != null && project.ID != CommonData.ItemAllValue)
                CommonFunc.BindBranchListToComboBoxByProjectID(comboBoxSearchBranch, project.ID, null, true);
            else
                CommonFunc.BindBranchListToComboBox(comboBoxSearchBranch, null, true);
            comboBoxSearchBranch.SelectedIndexChanged += comboBoxSearchBranch_SelectedIndexChanged;
        }

        private void comboBoxOperateProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            Project project = null;
            if (comboBoxOperateProject.SelectedItem is Project)
                project = comboBoxOperateProject.SelectedItem as Project;
            comboBoxOperateBranch.SelectedIndexChanged -= comboBoxOperateBranch_SelectedIndexChanged;
            if (project != null && project.ID != CommonData.ItemAllValue)
                CommonFunc.BindBranchListToComboBoxByProjectID(comboBoxOperateBranch, project.ID, null, true);
            else
                CommonFunc.BindBranchListToComboBox(comboBoxOperateBranch, null, true);
            comboBoxOperateBranch.SelectedIndexChanged += comboBoxOperateBranch_SelectedIndexChanged;
        }

        private void comboBoxSearchBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSearchBranch.SelectedItem is Branch branch && branch.Project != null && branch.Project.ID != CommonData.ItemAllValue)
            {
                if (comboBoxSearchProject.SelectedValue.ToString() != branch.Project.ID.ToString())
                {
                    comboBoxSearchBranch.SelectedIndexChanged -= comboBoxSearchBranch_SelectedIndexChanged;
                    CommonFunc.BindBranchListToComboBoxByProjectID(comboBoxSearchBranch, branch.Project.ID, null, true);
                    comboBoxSearchBranch.SelectedValue = branch.ID;
                    comboBoxSearchBranch.SelectedIndexChanged += comboBoxSearchBranch_SelectedIndexChanged;

                    comboBoxSearchProject.SelectedIndexChanged -= comboBoxSearchProject_SelectedIndexChanged;
                    comboBoxSearchProject.SelectedValue = branch.Project.ID;
                    comboBoxSearchProject.SelectedIndexChanged += comboBoxSearchProject_SelectedIndexChanged;
                }
            }
        }

        private void comboBoxOperateBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOperateBranch.SelectedItem is Branch branch && branch.Project != null && branch.Project.ID != CommonData.ItemAllValue)
            {
                if (comboBoxOperateProject.SelectedValue.ToString() != branch.Project.ID.ToString())
                {
                    comboBoxOperateBranch.SelectedIndexChanged -= comboBoxSearchBranch_SelectedIndexChanged;
                    CommonFunc.BindBranchListToComboBoxByProjectID(comboBoxOperateBranch, branch.Project.ID, null, true);
                    comboBoxOperateBranch.SelectedValue = branch.ID;
                    comboBoxOperateBranch.SelectedIndexChanged += comboBoxSearchBranch_SelectedIndexChanged;

                    comboBoxOperateProject.SelectedIndexChanged -= comboBoxOperateProject_SelectedIndexChanged;
                    comboBoxOperateProject.SelectedValue = branch.Project.ID;
                    comboBoxOperateProject.SelectedIndexChanged += comboBoxOperateProject_SelectedIndexChanged;
                }
            }
        }

        private void buttonLastWeek_Click(object sender, EventArgs e)
        {
            DateTime dtLastWeekStart = DateTime.Now;
            DateTime dtLastWeekEnd = DateTime.Now;
            CommonFunc.GetWeekDateTime(ref dtLastWeekStart, ref dtLastWeekEnd);
            dtLastWeekStart = dtLastWeekStart.AddDays(-7);
            dtLastWeekEnd = dtLastWeekEnd.AddDays(-7);
            dateTimePickerSearchFrom.Value = dtLastWeekStart;
            dateTimePickerSearchTo.Value = dtLastWeekEnd;
            dateTimePickerSearchFrom.Checked = true;
            dateTimePickerSearchTo.Checked = true;
        }

        private void buttonThisWeek_Click(object sender, EventArgs e)
        {
            DateTime dtThisWeekStart = DateTime.Now;
            DateTime dtThisWeekEnd = DateTime.Now;
            CommonFunc.GetWeekDateTime(ref dtThisWeekStart, ref dtThisWeekEnd);
            dateTimePickerSearchFrom.Value = dtThisWeekStart;
            dateTimePickerSearchTo.Value = dtThisWeekEnd;
            dateTimePickerSearchFrom.Checked = true;
            dateTimePickerSearchTo.Checked = true;
        }

        private void dataGridViewShow_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == ColumnFinishTime.Index)
            {
                DateTime dt = DateTime.MinValue;
                if (DateTime.TryParse(e.Value?.ToString(), out dt))
                    e.Value = dt.ToString(CommonData.DateTimeFormat);
            }
        }

        private void buttonRelateToToDo_Click(object sender, EventArgs e)
        {
            if (richTextBoxOperateContent.Tag == null || !(richTextBoxOperateContent.Tag is Report report) || report == null || report.ID == CommonData.ItemNullValue || report.ID == CommonData.ItemAllValue)
            {
                MessageBox.Show("没有选择报告或报告数据错误", "提示");
                return;
            }

            int projectID = CommonData.ItemAllValue, branchID = CommonData.ItemAllValue;
            if (report.ToDoID.HasValue && report.ToDoID.Value != CommonData.ItemNullValue && report.ToDoID.Value != CommonData.ItemAllValue)
            {
                string sql = "select Title from ToDo where ID = @ID";
                SqlParams paramDict = new SqlParams();
                paramDict.Add("ID", report.ToDoID.Value);
                object result = CommonData.AccessHelper.ExecuteScalar(sql, paramDict);
                if (result != null)
                {
                    if (DialogResult.No == MessageBox.Show("已关联【" + result.ToString() + "】，是否重新关联？", "提示", MessageBoxButtons.YesNo))
                        return;
                }
            }
            if (comboBoxOperateProject.SelectedValue != null)
                int.TryParse(comboBoxOperateProject.SelectedValue.ToString(), out projectID);
            if (comboBoxOperateBranch.SelectedValue != null)
                int.TryParse(comboBoxOperateBranch.SelectedValue.ToString(), out branchID);
            RelateToToDo relate = new RelateToToDo(projectID, branchID, report);
            relate.ShowDialog();
        }
    }
}
