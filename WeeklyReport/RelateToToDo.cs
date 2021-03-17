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

namespace WeeklyReport
{
    public partial class RelateToToDo : Form
    {
        /// <summary>
        /// 本周开始时间
        /// </summary>
        private DateTime weekStartTime;
        /// <summary>
        /// 本周结束时间
        /// </summary>
        private DateTime weekEndTime;
        /// <summary>
        /// 所有待办事项
        /// </summary>
        private List<ToDo> toDoListAll;
        /// <summary>
        /// 要关联到待办事项的报告所在项目ID
        /// </summary>
        private int relatedProjectID;
        /// <summary>
        /// 要关联到待办事项的报告所在分支ID
        /// </summary>
        private int relatedBranchID;
        /// <summary>
        /// 要关联到待办事项的报告ID
        /// </summary>
        private Report relatedReport;

        public RelateToToDo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 把报告关联到待办事项
        /// </summary>
        /// <param name="projectID">要关联到待办事项的报告所在项目ID</param>
        /// <param name="branchID">要关联到待办事项的报告所在分支ID</param>
        /// <param name="report">要关联到待办事项的报告信息</param>
        public RelateToToDo(int projectID, int branchID, Report report) : this()
        {
            relatedProjectID = projectID;
            relatedBranchID = branchID;
            relatedReport = report;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RelateToToDo_Load(object sender, EventArgs e)
        {
            comboBoxSearchProject.SelectedIndexChanged -= comboBoxSearchProject_SelectedIndexChanged;
            comboBoxSearchBranch.SelectedIndexChanged -= comboBoxSearchBranch_SelectedIndexChanged;
            CommonFunc.BindProjectListToComboBox(comboBoxSearchProject, null, true);
            if (relatedProjectID != CommonData.ItemNullValue)
                comboBoxSearchProject.SelectedValue = relatedProjectID;
            else if (CommonData.CurrentProject != null && CommonData.CurrentProject.ID != CommonData.ItemNullValue && CommonData.CurrentProject.ID != CommonData.ItemAllValue)
                comboBoxSearchProject.SelectedValue = CommonData.CurrentProject.ID;
            CommonFunc.BindBranchListToComboBox(comboBoxSearchBranch, null, true);
            if (relatedBranchID != CommonData.ItemNullValue)
                comboBoxSearchBranch.SelectedValue = relatedBranchID;
            else if (CommonData.CurrentBranch != null && CommonData.CurrentBranch.ID != CommonData.ItemNullValue && CommonData.CurrentBranch.ID != CommonData.ItemAllValue)
                comboBoxSearchBranch.SelectedValue = CommonData.CurrentBranch.ID;
            comboBoxSearchProject.SelectedIndexChanged += comboBoxSearchProject_SelectedIndexChanged;
            comboBoxSearchBranch.SelectedIndexChanged += comboBoxSearchBranch_SelectedIndexChanged;
            List<ToDoStatus> toDoList = CommonFunc.GetToDoStatusListForSearch();
            toDoList.Add(CommonData.toDoStatusNotDone);
            CommonFunc.BindToDoStatusListToComboBox(comboBoxSearchStatus, toDoList, true);
            comboBoxSearchStatus.SelectedValue = EnumToDoStatus.Done;
            CommonFunc.GetWeekDateTime(ref weekStartTime, ref weekEndTime);
            dateTimePickerSearchFisnishTimeFrom.Value = weekStartTime;
            dateTimePickerSearchFinishTimeTo.Value = weekEndTime;
            dateTimePickerSearchFisnishTimeFrom.Checked = false;
            dateTimePickerSearchFinishTimeTo.Checked = false;
            CommonFunc.BindUserListToComboBox(comboBoxSearchFinishUser, null, true);
            if (CommonData.CurrentUser != null && CommonData.CurrentUser.ID != CommonData.ItemNullValue && CommonData.CurrentUser.ID != CommonData.ItemAllValue)
                comboBoxSearchFinishUser.SelectedValue = CommonData.CurrentUser.ID;
        }

        private void GetToDoList()
        {
            if (toDoListAll != null && toDoListAll.Count > 0)
                toDoListAll.Clear();
            StringBuilder sql = new StringBuilder("select t.ID, t.ProjectID, p.Name as ProjectName, t.BranchID, b.Name as BranchName, t.RelatedID, t.Priority, t.Severity, t.Title, t.Content, t.[Memo], t.UserID, u.Name as UserName, t.PlannedStartTime, t.PlannedEndTime, t.PlannedHours, t.PlannedDays, t.Status, t.FinishTime, t.FinishUserID, uf.Name as FinishUserName from (((ToDo t left join Project p on t.ProjectID = p.ID) left join Branch b on t.BranchID = b.ID) left join [User] u on t.UserID = u.ID) left join [User] uf on t.FinishUserID = uf.ID where 1 = 1");
            //Dictionary<string, object> paramDict = new Dictionary<string, object>();
            SqlParams paramDict = new SqlParams();
            if (comboBoxSearchProject.SelectedItem is Project project && project.ID != CommonData.ItemAllValue)
            {
                //sql.Append(" and t.ProjectID = @ProjectID");
                //paramDict.Add("ProjectID", project.ID);
                sql.Append(paramDict.AddToWhere("ProjectID", project.ID, "t"));
            }
            if (comboBoxSearchBranch.SelectedItem is Branch branch && branch.ID != CommonData.ItemAllValue)
            {
                //sql.Append(" and t.BranchID = @BranchID");
                //paramDict.Add("BranchID", branch.ID);
                sql.Append(paramDict.AddToWhere("BranchID", branch.ID, "t"));
            }
            if (!string.IsNullOrWhiteSpace(textBoxSearchTitle.Text.Trim()))
            {
                //sql.Append(" and t.Title like @Title");
                //paramDict.Add("Title", "%" + textBoxSearchTitle.Text.Trim() + "%");
                sql.Append(paramDict.AddLikeToWhere("Title", textBoxSearchTitle, "t"));
            }
            if (!string.IsNullOrWhiteSpace(textBoxSearchContent.Text.Trim()))
            {
                //sql.Append(" and t.Content like @Content");
                //paramDict.Add("Content", "%" + textBoxSearchContent.Text.Trim() + "%");
                sql.Append(paramDict.AddLikeToWhere("Content", textBoxSearchContent, "t"));
            }
            if (textBoxSearchRelatedID.Text.NotNullOrWhiteSpace())
            {
                //sql.Append(" and t.RelatedID = @RelatedID");
                //paramDict.Add("RelatedID", textBoxSearchRelatedID.Text.Trim());
                sql.Append(paramDict.AddToWhere("RelatedID", textBoxSearchRelatedID, "t"));
            }
            if (comboBoxSearchStatus.SelectedItem is ToDoStatus status && status.ID != CommonData.ItemAllValue)
            {
                if (status.ID == CommonData.toDoStatusNotDoneID)
                {
                    //sql.Append(" and (t.Status = @Status1 or t.Status = @Status2)");
                    //paramDict.Add("Status1", (int)EnumToDoStatus.Planning);
                    //paramDict.Add("Status2", (int)EnumToDoStatus.Working);
                    List<object> paramValueList = new List<object>() { (int)EnumToDoStatus.Planning, (int)EnumToDoStatus.Working };
                    sql.Append(paramDict.AddToWhere("Status", paramValueList, "t"));
                }
                else
                {
                    //sql.Append(" and t.Status = @Status");
                    //paramDict.Add("Status", (int)status.Status);
                    sql.Append(paramDict.AddToWhere("Status", (int)status.Status, "t"));
                }
            }
            if (dateTimePickerSearchFisnishTimeFrom.Checked)
            {
                //sql.Append(" and t.FinishTime >= @FinishTimeStart");
                //paramDict.Add("FinishTimeStart", DataConvert.ToDateTimeValue(dateTimePickerSearchFisnishTimeFrom, 0, 0));
                sql.Append(paramDict.AddToWhere("FinishTime", ">=", "FinishTimeStart", DataConvert.ToDateTimeValue(dateTimePickerSearchFisnishTimeFrom, 0, 0), "t"));
            }
            if (dateTimePickerSearchFinishTimeTo.Checked)
            {
                //sql.Append(" and t.FinishTime <= @FinishTimeEnd");
                //paramDict.Add("FinishTimeEnd", DataConvert.ToDateTimeValue(dateTimePickerSearchFinishTimeTo, 59, 59));
                sql.Append(paramDict.AddToWhere("FinishTime", "<=", "FinishTimeEnd", DataConvert.ToDateTimeValue(dateTimePickerSearchFinishTimeTo, 59, 59), "t"));
            }
            if (comboBoxSearchFinishUser.SelectedItem is User user && user.ID != CommonData.ItemAllValue)
            {
                //sql.Append(" and t.FinishUserID = @FinishUserID");
                //paramDict.Add("FinishUserID", user.ID);
                sql.Append(paramDict.AddToWhere("FinishUserID", user.ID, "t"));
            }
            sql.Append(" order by t.FinishTime desc");

            if (toDoListAll == null)
                toDoListAll = new List<ToDo>();
            else if (toDoListAll.Count > 0)
                toDoListAll.Clear();
            toDoListAll.Clear();
            DataTable dt = CommonData.AccessHelper.GetDataTable(sql.ToString(), paramDict);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ToDo toDo = new ToDo
                    {
                        ID = DataConvert.ToDecimal(row["ID"]),
                        //Project = new Project()
                        //{
                        //    ID = DataConvert.ToInt(row["ProjectID"]),
                        //    Name = DataConvert.ToString(row["ProjectName"])
                        //},
                        RelatedID = DataConvert.ToString(row["RelatedID"]),
                        Priority = (EnumToDoPriority?)DataConvert.ToEnum<EnumToDoPriority>(row["Priority"]),
                        Severity = (EnumToDoSeverity?)DataConvert.ToEnum<EnumToDoSeverity>(row["Severity"]),
                        Title = DataConvert.ToString(row["Title"]),
                        Content = DataConvert.ToString(row["Content"]),
                        Memo = DataConvert.ToString(row["Memo"]),
                        //User = new User()
                        //{
                        //    ID = DataConvert.ToInt(row["UserID"]),
                        //    Name = DataConvert.ToString(row["UserName"])
                        //},
                        PlannedStartTime = DataConvert.ToNullableDateTime(row["PlannedStartTime"]),
                        PlannedEndTime = DataConvert.ToNullableDateTime(row["PlannedEndTime"]),
                        PlannedHours = DataConvert.ToNullableDecimal(row["PlannedHours"]),
                        PlannedDays = DataConvert.ToNullableDecimal(row["PlannedDays"]),
                        Status = (EnumToDoStatus?)DataConvert.ToEnum<EnumToDoStatus>(row["Status"]),
                        FinishTime = DataConvert.ToNullableDateTime(row["FinishTime"]),
                        //FinishUser = new User()
                        //{
                        //    ID = DataConvert.ToInt(row["FinishUserID"]),
                        //    Name = DataConvert.ToString(row["FinishUserName"])
                        //}
                    };
                    int projectID = DataConvert.ToInt(row["ProjectID"]);
                    string projectName = DataConvert.ToString(row["ProjectName"]);
                    if (projectID > 0 || !string.IsNullOrWhiteSpace(projectName))
                        toDo.Project = new Project() { ID = projectID, Name = projectName };
                    int branchID = DataConvert.ToInt(row["BranchID"]);
                    string branchName = DataConvert.ToString(row["BranchName"]);
                    if (branchID > 0 || !string.IsNullOrWhiteSpace(branchName))
                        toDo.Branch = new Branch() { ID = branchID, Name = branchName };//, Project = toDo.Project
                    int userID = DataConvert.ToInt(row["UserID"]);
                    string userName = DataConvert.ToString(row["UserName"]);
                    if (userID > 0 || !string.IsNullOrWhiteSpace(userName))
                        toDo.User = new User() { ID = userID, Name = userName };
                    int finishUserID = DataConvert.ToInt(row["FinishUserID"]);
                    string finishUserName = DataConvert.ToString(row["FinishUserName"]);
                    if (finishUserID > 0 || !string.IsNullOrWhiteSpace(finishUserName))
                        toDo.FinishUser = new User() { ID = finishUserID, Name = finishUserName };
                    toDoListAll.Add(toDo);
                }
            }
            BindToDoList();
        }

        private void BindToDoList()
        {
            dataGridViewToDoList.Rows.Clear();
            if (toDoListAll == null || toDoListAll.Count == 0)
                return;
            foreach (ToDo todo in toDoListAll)
            {
                int index = dataGridViewToDoList.Rows.Add();
                DataGridViewRow row = dataGridViewToDoList.Rows[index];
                if (todo.Status.HasValue)
                {
                    switch (todo.Status.Value)
                    {
                        case EnumToDoStatus.Planning:
                            row.Cells[ColumnDone.Index].Value = "false";
                            break;
                        case EnumToDoStatus.Working:
                            row.Cells[ColumnDone.Index].Value = "indeterminate";
                            break;
                        case EnumToDoStatus.Done:
                            row.Cells[ColumnDone.Index].Value = "true";
                            break;
                        default:
                            row.Cells[ColumnDone.Index].Value = "false";
                            break;
                    }
                }
                row.Cells[ColumnDone.Index].Tag = todo.Status;
                row.Cells[ColumnOrderNo.Index].Value = index + 1;
                if (todo.Project != null)
                {
                    row.Cells[ColumnProject.Index].Value = todo.Project.Name;
                    row.Cells[ColumnProject.Index].Tag = todo.Project;
                }
                if (todo.Branch != null)
                {
                    row.Cells[ColumnBranch.Index].Value = todo.Branch.Name;
                    row.Cells[ColumnBranch.Index].Tag = todo.Branch;
                }
                row.Cells[ColumnTitle.Index].Value = todo.Title;
                if (todo.Priority.HasValue)
                {
                    row.Cells[ColumnPriority.Index].Value = CommonFunc.GetDescription(todo.Priority);
                    row.Cells[ColumnPriority.Index].Tag = todo.Priority;
                }
                if (todo.Severity.HasValue)
                {
                    row.Cells[ColumnSeverity.Index].Value = CommonFunc.GetDescription(todo.Severity);
                    row.Cells[ColumnSeverity.Index].Tag = todo.Severity;
                }
                if (todo.PlannedEndTime.HasValue)
                {
                    row.Cells[ColumnPlannedEndTime.Index].Value = todo.PlannedEndTime.Value.ToString(CommonData.DateTimeMinuteFormat);
                    row.Cells[ColumnPlannedEndTime.Index].Tag = todo.PlannedEndTime.Value;
                }
                if (todo.User != null)
                {
                    row.Cells[ColumnAssignedTo.Index].Value = todo.User.Name;
                    row.Cells[ColumnAssignedTo.Index].Tag = todo.User;
                }
                row.Tag = todo;
            }
            dataGridViewToDoList.ClearSelection();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            GetToDoList();
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

        private void buttonSearchToday_Click(object sender, EventArgs e)
        {
            dateTimePickerSearchFisnishTimeFrom.Value = DateTime.Now.Date;
            dateTimePickerSearchFinishTimeTo.Value = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
            dateTimePickerSearchFisnishTimeFrom.Checked = true;
            dateTimePickerSearchFinishTimeTo.Checked = true;
        }

        private void buttonSearchYesterday_Click(object sender, EventArgs e)
        {
            dateTimePickerSearchFisnishTimeFrom.Value = DateTime.Now.Date.AddDays(-1);
            dateTimePickerSearchFinishTimeTo.Value = DateTime.Now.Date.AddSeconds(-1);
            dateTimePickerSearchFisnishTimeFrom.Checked = true;
            dateTimePickerSearchFinishTimeTo.Checked = true;
        }

        private void buttonSearchTomorrow_Click(object sender, EventArgs e)
        {
            dateTimePickerSearchFisnishTimeFrom.Value = DateTime.Now.Date.AddDays(1);
            dateTimePickerSearchFinishTimeTo.Value = DateTime.Now.Date.AddDays(2).AddSeconds(-1);
            dateTimePickerSearchFisnishTimeFrom.Checked = true;
            dateTimePickerSearchFinishTimeTo.Checked = true;
        }

        private void buttonSearchThisWeek_Click(object sender, EventArgs e)
        {
            DateTime dtThisWeekStart = CommonFunc.GetWeekStartDate();
            dateTimePickerSearchFisnishTimeFrom.Value = dtThisWeekStart;
            dateTimePickerSearchFinishTimeTo.Value = dtThisWeekStart.AddDays(6).AddHours(23).AddMinutes(59).AddSeconds(59);
            dateTimePickerSearchFisnishTimeFrom.Checked = true;
            dateTimePickerSearchFinishTimeTo.Checked = true;
        }

        private void buttonSearchLastWeek_Click(object sender, EventArgs e)
        {
            DateTime dtThisWeekStart = CommonFunc.GetWeekStartDate();
            dateTimePickerSearchFisnishTimeFrom.Value = dtThisWeekStart.AddDays(-7);
            dateTimePickerSearchFinishTimeTo.Value = dtThisWeekStart.AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59);
            dateTimePickerSearchFisnishTimeFrom.Checked = true;
            dateTimePickerSearchFinishTimeTo.Checked = true;
        }

        private void buttonSearchNextWeek_Click(object sender, EventArgs e)
        {
            DateTime dtThisWeekStart = CommonFunc.GetWeekStartDate();
            dateTimePickerSearchFisnishTimeFrom.Value = dtThisWeekStart.AddDays(7);
            dateTimePickerSearchFinishTimeTo.Value = dtThisWeekStart.AddDays(13).AddHours(23).AddMinutes(59).AddSeconds(59);
            dateTimePickerSearchFisnishTimeFrom.Checked = true;
            dateTimePickerSearchFinishTimeTo.Checked = true;
        }

        private void buttonRelate_Click(object sender, EventArgs e)
        {
            if (dataGridViewToDoList.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选中一条项目", "提示");
                return;
            }
            if (dataGridViewToDoList.SelectedRows[0].Tag is ToDo toDo && toDo != null)
            {
                relatedReport.ToDoID = toDo.ID;
                //string sql = "update Report set ToDoID = @ToDoID where ID = @ID";
                //Dictionary<string, object> paramDict = new Dictionary<string, object>();
                //paramDict.Add("ToDoID", relatedReport.ToDoID);
                //paramDict.Add("ID", relatedReport.ID);
                //CommonData.AccessHelper.ExecuteNonQuery(sql, paramDict);
                CommonData.AccessHelper.Update("Report", "ToDoID", relatedReport.ToDoID, "ID", relatedReport.ID);
                this.Close();
            }
            else
            {
                MessageBox.Show("选中的项目有误", "提示");
                return;
            }
        }

        private void comboBoxSearchStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSearchStatus.SelectedItem is ToDoStatus status && status.Status != EnumToDoStatus.Done)
            {
                comboBoxSearchFinishUser.SelectedValue = CommonData.ItemAllValue;
                dateTimePickerSearchFisnishTimeFrom.Checked = false;
                dateTimePickerSearchFinishTimeTo.Checked = false;
            }
        }
    }
}
