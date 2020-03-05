﻿using Common;
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
    public partial class MainForm : Form
    {
        /// <summary>
        /// 是否显示右侧信息栏
        /// </summary>
        private bool infoShowing = true;
        /// <summary>
        /// 右侧信息栏显示文本
        /// </summary>
        private string infoShowingText = string.Empty;
        /// <summary>
        /// 右侧信息栏隐藏文本
        /// </summary>
        private string infoHidingText = string.Empty;
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

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                infoShowingText += ">" + Environment.NewLine + Environment.NewLine;
                infoHidingText += "<" + Environment.NewLine + Environment.NewLine;
            }
            infoShowingText += ">";
            infoHidingText += "<";
            if (infoShowing)
                labelHideInfo.Text = infoShowingText;
            else
                labelHideInfo.Text = infoHidingText;
            comboBoxSearchProject.SelectedIndexChanged -= comboBoxSearchProject_SelectedIndexChanged;
            comboBoxSearchBranch.SelectedIndexChanged -= comboBoxSearchBranch_SelectedIndexChanged;
            CommonFunc.BindProjectListToComboBox(comboBoxSearchProject, null, true);
            CommonFunc.BindBranchListToComboBox(comboBoxSearchBranch, null, true);
            comboBoxSearchProject.SelectedIndexChanged += comboBoxSearchProject_SelectedIndexChanged;
            comboBoxSearchBranch.SelectedIndexChanged += comboBoxSearchBranch_SelectedIndexChanged;
            CommonFunc.BindToDoStatusListToComboBox(comboBoxSearchStatus, null, true);
            comboBoxSearchStatus.SelectedValue = EnumToDoStatus.Planning;
            CommonFunc.GetWeekDateTime(ref weekStartTime, ref weekEndTime);
            dateTimePickerSearchPlannedStartFrom.Value = weekStartTime;
            dateTimePickerSearchPlannedStartTo.Value = weekEndTime;
            dateTimePickerSearchPlannedEndFrom.Value = weekStartTime;
            dateTimePickerSearchPlannedEndTo.Value = weekEndTime;
            dateTimePickerSearchPlannedStartFrom.Checked = false;
            dateTimePickerSearchPlannedStartTo.Checked = false;
            dateTimePickerSearchPlannedEndFrom.Checked = false;
            dateTimePickerSearchPlannedEndTo.Checked = false;
            comboBoxOperateProject.SelectedIndexChanged -= comboBoxOperateProject_SelectedIndexChanged;
            comboBoxOperateBranch.SelectedIndexChanged -= comboBoxOperateBranch_SelectedIndexChanged;
            CommonFunc.BindProjectListToComboBox(comboBoxOperateProject, null, true);
            CommonFunc.BindBranchListToComboBox(comboBoxOperateBranch, null, true);
            comboBoxOperateProject.SelectedIndexChanged += comboBoxOperateProject_SelectedIndexChanged;
            comboBoxOperateBranch.SelectedIndexChanged += comboBoxOperateBranch_SelectedIndexChanged;
            CommonFunc.BindToDoPriorityListToComboBox(comboBoxOperatePriority, null, true);
            CommonFunc.BindToDoSeverityListToComboBox(comboBoxOperateSeverity, null, true);
            CommonFunc.BindToDoStatusListToComboBox(comboBoxOperateStatus, null, true);
            InitOperateControls();
        }

        private void ShowInfo(bool show = true)
        {
            if (infoShowing == show)
                return;
            if (show)
            {
                groupBoxDataOperation.Text = "数据/操作";
                groupBoxDataOperation.Width = 305;
                labelHideInfo.Text = infoShowingText;
                infoShowing = true;
                dataGridViewToDoList_SelectionChanged(null, null);
            }
            else
            {
                groupBoxDataOperation.Text = string.Empty;
                groupBoxDataOperation.Width = labelHideInfo.Left + labelHideInfo.Width;
                labelHideInfo.Text = infoHidingText;
                infoShowing = false;
            }
        }

        private void labelHideInfo_Click(object sender, EventArgs e)
        {
            ShowInfo(!infoShowing);
        }

        private void dateTimePickerOperatePlannedTime_ValueChanged(object sender, EventArgs e)
        {
            if (!dateTimePickerOperatePlannedStartTime.Checked || !dateTimePickerOperatePlannedEndTime.Checked)
                return;
            numericUpDownOperatePlannedHours.ValueChanged -= numericUpDownOperatePlannedTime_ValueChanged;
            numericUpDownOperatePlannedDays.ValueChanged -= numericUpDownOperatePlannedTime_ValueChanged;
            decimal hours = (decimal)DateTimeManger.DateDiff(DateInterval.Hour, dateTimePickerOperatePlannedStartTime.Value, dateTimePickerOperatePlannedEndTime.Value);
            numericUpDownOperatePlannedHours.Value = hours >= numericUpDownOperatePlannedHours.Minimum && hours <= numericUpDownOperatePlannedHours.Maximum ? hours : 0;
            decimal days = (decimal)DateTimeManger.DateDiff(DateInterval.Day, dateTimePickerOperatePlannedStartTime.Value, dateTimePickerOperatePlannedEndTime.Value);
            numericUpDownOperatePlannedDays.Value = days >= numericUpDownOperatePlannedDays.Minimum && days <= numericUpDownOperatePlannedDays.Maximum ? days : 0;
            numericUpDownOperatePlannedHours.ValueChanged += numericUpDownOperatePlannedTime_ValueChanged;
            numericUpDownOperatePlannedDays.ValueChanged += numericUpDownOperatePlannedTime_ValueChanged;
        }

        private void numericUpDownOperatePlannedTime_ValueChanged(object sender, EventArgs e)
        {
            if (sender == numericUpDownOperatePlannedHours)
            {
                dateTimePickerOperatePlannedEndTime.ValueChanged -= dateTimePickerOperatePlannedTime_ValueChanged;
                dateTimePickerOperatePlannedEndTime.Value = dateTimePickerOperatePlannedStartTime.Value.AddHours((double)numericUpDownOperatePlannedHours.Value);
                dateTimePickerOperatePlannedEndTime.ValueChanged += dateTimePickerOperatePlannedTime_ValueChanged;
                numericUpDownOperatePlannedDays.ValueChanged -= numericUpDownOperatePlannedTime_ValueChanged;
                numericUpDownOperatePlannedDays.Value = numericUpDownOperatePlannedHours.Value / 24;
                numericUpDownOperatePlannedDays.ValueChanged += numericUpDownOperatePlannedTime_ValueChanged;
            }
            else if (sender == numericUpDownOperatePlannedDays)
            {
                dateTimePickerOperatePlannedEndTime.ValueChanged -= dateTimePickerOperatePlannedTime_ValueChanged;
                dateTimePickerOperatePlannedEndTime.Value = dateTimePickerOperatePlannedStartTime.Value.AddDays((double)numericUpDownOperatePlannedDays.Value);
                dateTimePickerOperatePlannedEndTime.ValueChanged += dateTimePickerOperatePlannedTime_ValueChanged;
                numericUpDownOperatePlannedHours.ValueChanged -= numericUpDownOperatePlannedTime_ValueChanged;
                numericUpDownOperatePlannedHours.Value = numericUpDownOperatePlannedDays.Value * 24;
                numericUpDownOperatePlannedHours.ValueChanged += numericUpDownOperatePlannedTime_ValueChanged;
            }
        }

        private void GetToDoList()
        {
            if (toDoListAll != null && toDoListAll.Count > 0)
                toDoListAll.Clear();
            StringBuilder sql = new StringBuilder("select t.ID, t.ProjectID, p.Name as ProjectName, t.BranchID, b.Name as BranchName, t.Priority, t.Severity, t.Title, t.Content, t.[Memo], t.UserID, u.Name as UserName, t.PlannedStartTime, t.PlannedEndTime, t.PlannedHours, t.PlannedDays, t.Status, t.FinishTime, t.FinishUserID, uf.Name as FinishUserName from (((ToDo t left join Project p on t.ProjectID = p.ID) left join Branch b on t.BranchID = b.ID) left join [User] u on t.UserID = u.ID) left join [User] uf on t.FinishUserID = uf.ID where 1 = 1");
            if (comboBoxSearchProject.SelectedItem is Project project && project.ID != CommonData.ItemAllValue)
                sql.Append(" and t.ProjectID = " + project.ID);
            if (comboBoxSearchBranch.SelectedItem is Branch branch && branch.ID != CommonData.ItemAllValue)
                sql.Append(" and t.BranchID = " + branch.ID);
            if (!string.IsNullOrWhiteSpace(textBoxSearchTitle.Text.Trim()))
                sql.Append(" and t.Title like '%" + textBoxSearchTitle.Text.Trim() + "%'");
            if (!string.IsNullOrWhiteSpace(textBoxSearchContent.Text.Trim()))
                sql.Append(" and t.Content like '%" + textBoxSearchContent.Text.Trim() + "%'");
            if (comboBoxSearchStatus.SelectedItem is ToDoStatus status && status.ID != CommonData.ItemAllValue)
                sql.Append(" and t.Status = " + (int)status.Status);
            if (dateTimePickerSearchPlannedStartFrom.Checked)
                sql.Append(" and t.PlannedStartTime >= #" + dateTimePickerSearchPlannedStartFrom.Value.ToString(CommonData.DateTimeMinuteFormat + ":00") + "#");
            if (dateTimePickerSearchPlannedStartTo.Checked)
                sql.Append(" and t.PlannedStartTime <= #" + dateTimePickerSearchPlannedStartTo.Value.ToString(CommonData.DateTimeMinuteFormat + ":59") + "#");
            if (dateTimePickerSearchPlannedEndFrom.Checked)
                sql.Append(" and t.PlannedEndTime >= #" + dateTimePickerSearchPlannedEndFrom.Value.ToString(CommonData.DateTimeMinuteFormat + ":00") + "#");
            if (dateTimePickerSearchPlannedEndTo.Checked)
                sql.Append(" and t.PlannedEndTime <= #" + dateTimePickerSearchPlannedEndTo.Value.ToString(CommonData.DateTimeMinuteFormat + ":59") + "#");
            sql.Append(" order by t.Priority, t.Severity, t.PlannedEndTime");

            if (toDoListAll == null)
                toDoListAll = new List<ToDo>();
            else if (toDoListAll.Count > 0)
                toDoListAll.Clear();
            toDoListAll.Clear();
            DataTable dt = CommonData.AccessHelper.GetDataTable(sql.ToString());
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
                row.Tag = todo;
            }
            dataGridViewToDoList.ClearSelection();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            GetToDoList();
        }

        private void InitOperateControls()
        {
            comboBoxOperateProject.SelectedValue = CommonData.ItemAllValue;
            comboBoxOperateBranch.SelectedValue = CommonData.ItemAllValue;
            comboBoxOperatePriority.SelectedValue = EnumToDoPriority.Normal;
            comboBoxOperateSeverity.SelectedValue = EnumToDoSeverity.Minor;
            dateTimePickerOperatePlannedStartTime.Checked = false;
            dateTimePickerOperatePlannedEndTime.Checked = false;
            dateTimePickerOperatePlannedStartTime.ValueChanged -= dateTimePickerOperatePlannedTime_ValueChanged;
            dateTimePickerOperatePlannedEndTime.ValueChanged -= dateTimePickerOperatePlannedTime_ValueChanged;
            DateTime now = DateTime.Now;
            dateTimePickerOperatePlannedStartTime.Value = now.Date.AddHours(now.Hour).AddMinutes(now.Minute);
            dateTimePickerOperatePlannedEndTime.Value = dateTimePickerOperatePlannedStartTime.Value.AddDays(1);
            dateTimePickerOperatePlannedStartTime.ValueChanged += dateTimePickerOperatePlannedTime_ValueChanged;
            dateTimePickerOperatePlannedEndTime.ValueChanged += dateTimePickerOperatePlannedTime_ValueChanged;
            numericUpDownOperatePlannedHours.ValueChanged -= numericUpDownOperatePlannedTime_ValueChanged;
            numericUpDownOperatePlannedDays.ValueChanged -= numericUpDownOperatePlannedTime_ValueChanged;
            numericUpDownOperatePlannedHours.Value = 24;
            numericUpDownOperatePlannedDays.Value = 1;
            numericUpDownOperatePlannedHours.ValueChanged += numericUpDownOperatePlannedTime_ValueChanged;
            numericUpDownOperatePlannedDays.ValueChanged += numericUpDownOperatePlannedTime_ValueChanged;
            textBoxOperateTitle.Text = string.Empty;
            richTextBoxOperateContent.Text = string.Empty;
            richTextBoxOperateMemo.Text = string.Empty;
            comboBoxOperateStatus.SelectedValue = EnumToDoStatus.Planning;
        }

        private void dataGridViewToDoList_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewToDoList.SelectedRows.Count != 1)
                return;
            InitOperateControls();
            DataGridViewRow row = dataGridViewToDoList.SelectedRows[0];
            if (!(row.Tag is ToDo todo))
                return;
            //选中项目后，自动打开右侧信息栏并赋值
            ShowInfo();
            comboBoxOperateProject.SelectedValue = todo.Project.ID;
            if (todo.Branch != null && todo.Branch.ID > 0)
                comboBoxOperateBranch.SelectedValue = todo.Branch.ID;
            else
                comboBoxOperateBranch.SelectedValue = CommonData.ItemAllValue;
            comboBoxOperatePriority.SelectedValue = todo.Priority;
            comboBoxOperateSeverity.SelectedValue = todo.Severity;
            if (todo.PlannedStartTime.HasValue)
            {
                dateTimePickerOperatePlannedStartTime.ValueChanged -= dateTimePickerOperatePlannedTime_ValueChanged;
                dateTimePickerOperatePlannedStartTime.Value = todo.PlannedStartTime.Value;
                dateTimePickerOperatePlannedStartTime.ValueChanged += dateTimePickerOperatePlannedTime_ValueChanged;
            }
            else
                dateTimePickerOperatePlannedStartTime.Checked = false;
            if (todo.PlannedEndTime.HasValue)
            {
                dateTimePickerOperatePlannedEndTime.ValueChanged -= dateTimePickerOperatePlannedTime_ValueChanged;
                dateTimePickerOperatePlannedEndTime.Value = todo.PlannedEndTime.Value;
                dateTimePickerOperatePlannedEndTime.ValueChanged += dateTimePickerOperatePlannedTime_ValueChanged;
            }
            else
                dateTimePickerOperatePlannedEndTime.Checked = false;
            if (todo.PlannedHours.HasValue)
            {
                numericUpDownOperatePlannedHours.ValueChanged -= numericUpDownOperatePlannedTime_ValueChanged;
                numericUpDownOperatePlannedHours.Value = todo.PlannedHours.Value;
                numericUpDownOperatePlannedHours.ValueChanged += numericUpDownOperatePlannedTime_ValueChanged;
            }
            else
                numericUpDownOperatePlannedHours.Value = 0;
            if (todo.PlannedDays.HasValue)
            {
                numericUpDownOperatePlannedDays.ValueChanged -= numericUpDownOperatePlannedTime_ValueChanged;
                numericUpDownOperatePlannedDays.Value = todo.PlannedDays.Value;
                numericUpDownOperatePlannedDays.ValueChanged += numericUpDownOperatePlannedTime_ValueChanged;
            }
            textBoxOperateTitle.Text = todo.Title;
            richTextBoxOperateContent.Text = todo.Content;
            richTextBoxOperateMemo.Text = todo.Memo;
            comboBoxOperateStatus.SelectedValue = todo.Status;
        }

        private ToDo GetToDoFromOperateControls()
        {
            ToDo toDo= new ToDo()
            {
                //ID = 0,
                Content = richTextBoxOperateContent.Text.Trim(),
                //FinishTime
                //FinishUser
                Memo = richTextBoxOperateMemo.Text.Trim(),
                PlannedDays = numericUpDownOperatePlannedDays.Value,
                PlannedHours = numericUpDownOperatePlannedHours.Value,
                Title = textBoxOperateTitle.Text.Trim(),
                //User = CommonData.CurrentUser
            };
            if (comboBoxOperateProject.SelectedItem is Project && comboBoxOperateProject.SelectedValue is int && (int)comboBoxOperateProject.SelectedValue != CommonData.ItemAllValue)
                toDo.Project = (Project)comboBoxOperateProject.SelectedItem;
            if (comboBoxOperateProject.SelectedItem is Project && comboBoxOperateProject.SelectedValue is int && (int)comboBoxOperateProject.SelectedValue != CommonData.ItemAllValue)
                toDo.Branch = (Branch)comboBoxOperateBranch.SelectedItem;
            if (comboBoxOperatePriority.SelectedItem is ToDoPriority && comboBoxOperatePriority.SelectedValue is EnumToDoPriority && ((ToDoPriority)comboBoxOperatePriority.SelectedItem).ID != CommonData.ItemAllValue)
                toDo.Priority = (EnumToDoPriority)comboBoxOperatePriority.SelectedValue;
            if (comboBoxOperateSeverity.SelectedItem is ToDoSeverity && comboBoxOperateSeverity.SelectedValue is EnumToDoSeverity && ((ToDoSeverity)comboBoxOperateSeverity.SelectedItem).ID != CommonData.ItemAllValue)
                toDo.Severity = (EnumToDoSeverity)comboBoxOperateSeverity.SelectedValue;
            if (comboBoxOperateStatus.SelectedItem is ToDoStatus && comboBoxOperateStatus.SelectedValue is EnumToDoStatus && ((ToDoStatus)comboBoxOperateStatus.SelectedItem).ID != CommonData.ItemAllValue)
                toDo.Status = (EnumToDoStatus)comboBoxOperateStatus.SelectedValue;
            if (dateTimePickerOperatePlannedStartTime.Checked)
                toDo.PlannedStartTime = dateTimePickerOperatePlannedStartTime.Value;
            if (dateTimePickerOperatePlannedEndTime.Checked)
                toDo.PlannedEndTime = dateTimePickerOperatePlannedEndTime.Value;
            return toDo;
        }

        private DialogResult ShowMessageAskRefresh()
        {
            DialogResult dialogResult = MessageBox.Show("操作完成，是否刷新列表？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                InitOperateControls();
                GetToDoList();
            }
            return dialogResult;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxOperateTitle.Text))
            {
                MessageBox.Show("标题不能为空", "提示");
                return;
            }
            StringBuilder fields = new StringBuilder("Title");
            StringBuilder values = new StringBuilder(DataConvert.ToAccessStringValue(textBoxOperateTitle));
            if (comboBoxOperateProject.SelectedItem is Project && comboBoxOperateProject.SelectedValue is int && (int)comboBoxOperateProject.SelectedValue != CommonData.ItemAllValue)
            {
                fields.Append(", ProjectID");
                values.Append(", " + DataConvert.ToAccessIntValue(comboBoxOperateProject));
            }
            if (comboBoxOperateBranch.SelectedItem is Branch && comboBoxOperateBranch.SelectedValue is int && (int)comboBoxOperateBranch.SelectedValue != CommonData.ItemAllValue)
            {
                fields.Append(", BranchID");
                values.Append(", " + DataConvert.ToAccessIntValue(comboBoxOperateBranch));
            }
            if (comboBoxOperatePriority.SelectedItem is ToDoPriority && comboBoxOperatePriority.SelectedValue is EnumToDoPriority && ((ToDoPriority)comboBoxOperatePriority.SelectedItem).ID != CommonData.ItemAllValue)
            {
                fields.Append(", Priority");
                //values.Append("," + (int)(EnumToDoPriority)comboBoxOperatePriority.SelectedValue);
                values.Append(", " + (int)comboBoxOperatePriority.SelectedValue);
            }
            if (comboBoxOperateSeverity.SelectedItem is ToDoSeverity && comboBoxOperateSeverity.SelectedValue is EnumToDoSeverity && ((ToDoSeverity)comboBoxOperateSeverity.SelectedItem).ID != CommonData.ItemAllValue)
            {
                fields.Append(", Severity");
                values.Append(", " + (int)comboBoxOperateSeverity.SelectedValue);
            }
            if (dateTimePickerOperatePlannedStartTime.Checked)
            {
                fields.Append(", PlannedStartTime");
                values.Append(", " + DataConvert.ToAccessDateTimeValue(dateTimePickerOperatePlannedStartTime));
            }
            if (dateTimePickerOperatePlannedEndTime.Checked)
            {
                fields.Append(", PlannedEndTime");
                values.Append(", " + DataConvert.ToAccessDateTimeValue(dateTimePickerOperatePlannedEndTime));
            }
            fields.Append(", PlannedHours");
            values.Append(", " + DataConvert.ToAccessDecimalValue(numericUpDownOperatePlannedHours));
            fields.Append(", PlannedDays");
            values.Append(", " + DataConvert.ToAccessDecimalValue(numericUpDownOperatePlannedDays));
            if (!string.IsNullOrWhiteSpace(richTextBoxOperateContent.Text))
            {
                fields.Append(", Content");
                values.Append(", " + DataConvert.ToAccessStringValue(richTextBoxOperateContent));
            }
            if (!string.IsNullOrWhiteSpace(richTextBoxOperateMemo.Text))
            {
                fields.Append(", [Memo]");
                values.Append(", " + DataConvert.ToAccessStringValue(richTextBoxOperateMemo));
            }
            fields.Append(", UserID");
            values.Append(", " + CommonData.CurrentUser.ID);
            if (comboBoxOperateStatus.SelectedItem is ToDoStatus && comboBoxOperateStatus.SelectedValue is EnumToDoStatus && ((ToDoStatus)comboBoxOperateStatus.SelectedItem).ID != CommonData.ItemAllValue)
            {
                fields.Append(", Status");
                values.Append(", " + (int)comboBoxOperateStatus.SelectedValue);
            }
            //fields.Append(",FinishTime");
            //fields.Append(",FinishUserID");
            string sql = "insert into ToDo (" + fields.ToString() + ") values (" + values.ToString() + ")";
            CommonData.AccessHelper.ExecuteNonQuery(sql);
            richTextBoxOperateContent.Text = string.Empty;
            ShowMessageAskRefresh();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewToDoList.SelectedRows.Count != 1)
            {
                MessageBox.Show("选中一行后再修改", "提示");
                return;
            }
            if (!(dataGridViewToDoList.SelectedRows[0].Tag is ToDo toDoOriginal) || toDoOriginal.ID <= 0)
            {
                MessageBox.Show("待办事项数据错误", "提示");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxOperateTitle.Text))
            {
                MessageBox.Show("标题不能为空", "提示");
                return;
            }
            ToDo toDoOperate = GetToDoFromOperateControls();
            StringBuilder sets = new StringBuilder("Title = " + DataConvert.ToAccessStringValue(toDoOperate.Title));
            sets.Append(", ProjectID = " + (toDoOperate.Project.ID != CommonData.ItemAllValue ? toDoOperate.Project.ID.ToString() : "null"));
            sets.Append(", BranchID = " + (toDoOperate.Branch != null && toDoOperate.Branch.ID != CommonData.ItemAllValue ? toDoOperate.Branch.ID.ToString() : "null"));
            sets.Append(", Priority = " + (toDoOperate.Priority.HasValue ? ((int)toDoOperate.Priority.Value).ToString() : "null"));
            sets.Append(", Severity = " + (toDoOperate.Severity.HasValue ? ((int)toDoOperate.Severity.Value).ToString() : "null"));
            sets.Append(", Content = " + DataConvert.ToAccessStringValue(toDoOperate.Content));
            sets.Append(", [Memo] = " + DataConvert.ToAccessStringValue(toDoOperate.Memo));
            sets.Append(", UserID = " + CommonData.CurrentUser.ID);
            sets.Append(", PlannedStartTime = " + DataConvert.ToAccessDateTimeValue(toDoOperate.PlannedStartTime));
            sets.Append(", PlannedEndTime = " + DataConvert.ToAccessDateTimeValue(toDoOperate.PlannedEndTime));
            sets.Append(", PlannedHours = " + DataConvert.ToAccessDecimalValue(toDoOperate.PlannedHours));
            sets.Append(", PlannedDays = " + DataConvert.ToAccessDecimalValue(toDoOperate.PlannedDays));
            sets.Append(", Status = " + (toDoOperate.Status.HasValue ? ((int)toDoOperate.Status.Value).ToString() : "null"));
            //sets.Append(", FinishTime = ");
            //sets.Append(", FinishUserID = ");
            CommonData.AccessHelper.ExecuteNonQuery("update ToDo set " + sets.ToString() + " where ID = " + toDoOriginal.ID);
            ShowMessageAskRefresh();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewToDoList.SelectedRows.Count != 1)
            {
                MessageBox.Show("选中一行后再删除", "提示");
                return;
            }
            if (!(dataGridViewToDoList.SelectedRows[0].Tag is ToDo toDo) || toDo.ID <= 0)
            {
                MessageBox.Show("待办事项数据错误", "提示");
                return;
            }
            CommonData.AccessHelper.ExecuteNonQuery("delete from ToDo where ID = " + toDo.ID);
            //MessageBox.Show("删除完成", "提示");
            ShowMessageAskRefresh();
        }

        private void buttonWorking_Click(object sender, EventArgs e)
        {
            if (dataGridViewToDoList.SelectedRows.Count != 1)
            {
                MessageBox.Show("选中一行后再设置", "提示");
                return;
            }
            if (!(dataGridViewToDoList.SelectedRows[0].Tag is ToDo toDo) || toDo.ID <= 0)
            {
                MessageBox.Show("待办事项数据错误", "提示");
                return;
            }
            int i = CommonData.AccessHelper.ExecuteNonQuery("update ToDo set Status = " + (int)EnumToDoStatus.Working + " where ID = " + toDo.ID);
            //因为更新后有修改界面的逻辑，所以先判断是否更新成功，未更新成功就提示。避免更新失败后还是更新界面，导致界面显示与实际数据不同
            if (i == 0)
            {
                MessageBox.Show("更新失败", "提示");
                return;
            }
            if (ShowMessageAskRefresh() == DialogResult.No)
            {
                foreach (DataGridViewRow row in dataGridViewToDoList.Rows)
                {
                    if (row.Tag is ToDo)
                    {
                        ToDo toDoRow = row.Tag as ToDo;
                        if (toDoRow.ID == toDo.ID)
                        {
                            row.Cells[ColumnDone.Index].Value = "indeterminate";
                            break;
                        }
                    }
                }
            }
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            if (dataGridViewToDoList.SelectedRows.Count != 1)
            {
                MessageBox.Show("选中一行后再设置", "提示");
                return;
            }
            if (!(dataGridViewToDoList.SelectedRows[0].Tag is ToDo toDo) || toDo.ID <= 0)
            {
                MessageBox.Show("待办事项数据错误", "提示");
                return;
            }
            ToDoDone(toDo);
        }

        private void ToDoDone(ToDo toDo)
        {
            if (toDo == null || toDo.ID <= 0)
            {
                MessageBox.Show("待办事项数据错误", "提示");
                return;
            }
            DateTime now = DateTime.Now;
            int i = CommonData.AccessHelper.ExecuteNonQuery("update ToDo set Status = " + (int)EnumToDoStatus.Done + ", FinishTime = " + DataConvert.ToAccessDateTimeValue(now) + ", FinishUserID = " + CommonData.CurrentUser.ID + " where ID = " + toDo.ID);
            //因为更新后有修改界面的逻辑，所以先判断是否更新成功，未更新成功就提示。避免更新失败后还是更新界面，导致界面显示与实际数据不同
            if (i == 0)
            {
                MessageBox.Show("更新失败", "提示");
                return;
            }
            toDo.Status = EnumToDoStatus.Done;
            toDo.FinishTime = now;
            toDo.FinishUser = CommonData.CurrentUser;
            if (ShowMessageAskRefresh() == DialogResult.No)
            {
                foreach (DataGridViewRow row in dataGridViewToDoList.Rows)
                {
                    if (row.Tag is ToDo)
                    {
                        ToDo toDoRow = row.Tag as ToDo;
                        if (toDoRow.ID == toDo.ID)
                        {
                            row.Cells[ColumnDone.Index].Value = "true";
                            break;
                        }
                    }
                }
            }
            AddToReport(toDo);
        }

        private void AddToReport(ToDo toDo)
        {
            if (toDo == null)
                return;
            if (MessageBox.Show("是否新增到个人周报中？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                AddToReport add = new AddToReport(toDo);
                add.Show();
            }
        }

        private void dataGridViewToDoList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ColumnDone.Index)
            {
                ToDo toDo = dataGridViewToDoList.Rows[e.RowIndex].Tag as ToDo;
                if (toDo == null)
                    return;
                if (!toDo.Status.HasValue || toDo.Status.Value == EnumToDoStatus.Planning || toDo.Status.Value == EnumToDoStatus.Working)
                {
                    ToDoDone(toDo);
                }
            }
        }

        private void comboBoxSearchProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSearchProject.SelectedItem is Project project && project.ID != CommonData.ItemAllValue)
            {
                comboBoxSearchBranch.SelectedIndexChanged -= comboBoxSearchBranch_SelectedIndexChanged;
                CommonFunc.BindBranchListToComboBoxByProjectID(comboBoxSearchBranch, project.ID, null, true);
                comboBoxSearchBranch.SelectedIndexChanged += comboBoxSearchBranch_SelectedIndexChanged;
            }
        }

        private void comboBoxOperateProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOperateProject.SelectedItem is Project project && project.ID != CommonData.ItemAllValue)
            {
                comboBoxOperateBranch.SelectedIndexChanged -= comboBoxOperateBranch_SelectedIndexChanged;
                CommonFunc.BindBranchListToComboBoxByProjectID(comboBoxOperateBranch, project.ID, null, true);
                comboBoxOperateBranch.SelectedIndexChanged += comboBoxOperateBranch_SelectedIndexChanged;
            }
        }

        private void comboBoxSearchBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSearchBranch.SelectedItem is Branch branch && branch.Project != null && branch.Project.ID != CommonData.ItemAllValue)
            {
                comboBoxSearchProject.SelectedIndexChanged -= comboBoxSearchProject_SelectedIndexChanged;
                comboBoxSearchProject.SelectedValue = branch.Project.ID;
                comboBoxSearchProject.SelectedIndexChanged += comboBoxSearchProject_SelectedIndexChanged;
            }
        }

        private void comboBoxOperateBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOperateBranch.SelectedItem is Branch branch && branch.Project != null && branch.Project.ID != CommonData.ItemAllValue)
            {
                comboBoxOperateProject.SelectedIndexChanged -= comboBoxOperateProject_SelectedIndexChanged;
                comboBoxOperateProject.SelectedValue = branch.Project.ID;
                comboBoxOperateProject.SelectedIndexChanged += comboBoxOperateProject_SelectedIndexChanged;
            }
        }
    }
}
