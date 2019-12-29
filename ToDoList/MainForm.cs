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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private bool infoShowing = true;
        private string infoShowingText = string.Empty;
        private string infoHidingText = string.Empty;
        private DateTime weekStartTime;
        private DateTime weekEndTime;

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
            CommonFunc.BindProjectListToComboBox(comboBoxSearchProject, null, true);
            CommonFunc.BindToDoStatusListToComboBox(comboBoxSearchStatus, null, true);
            comboBoxSearchStatus.SelectedValue = EnumToDoStatus.Planning;
            CommonFunc.GetWeekDateTime(ref weekStartTime, ref weekEndTime);
            dateTimePickerSearchPlannedStartFrom.Value = weekStartTime;
            dateTimePickerSearchPlannedStartTo.Value = weekStartTime;
            dateTimePickerSearchPlannedEndFrom.Value = weekEndTime;
            dateTimePickerSearchPlannedEndTo.Value = weekEndTime;
            dateTimePickerSearchPlannedStartFrom.Checked = false;
            dateTimePickerSearchPlannedStartTo.Checked = false;
            dateTimePickerSearchPlannedEndFrom.Checked = false;
            dateTimePickerSearchPlannedEndTo.Checked = false;
            CommonFunc.BindProjectListToComboBox(comboBoxOperateProject, null, true);
            CommonFunc.BindToDoPriorityListToComboBox(comboBoxOperatePriority, null, true);
            comboBoxOperatePriority.SelectedValue = EnumToDoPriority.Normal;
            CommonFunc.BindToDoSeverityListToComboBox(comboBoxOperateSeverity, null, true);
            comboBoxOperateSeverity.SelectedValue = EnumToDoSeverity.Minor;
            dateTimePickerOperatePlannedStartFrom.ValueChanged -= dateTimePickerOperatePlannedTime_ValueChanged;
            dateTimePickerOperatePlannedStartTo.ValueChanged -= dateTimePickerOperatePlannedTime_ValueChanged;
            DateTime now = DateTime.Now;
            dateTimePickerOperatePlannedStartFrom.Value = now.Date.AddHours(now.Hour).AddMinutes(now.Minute);
            dateTimePickerOperatePlannedStartTo.Value = dateTimePickerOperatePlannedStartFrom.Value.AddDays(1);
            dateTimePickerOperatePlannedStartFrom.ValueChanged += dateTimePickerOperatePlannedTime_ValueChanged;
            dateTimePickerOperatePlannedStartTo.ValueChanged += dateTimePickerOperatePlannedTime_ValueChanged;
            numericUpDownOperatePlannedHours.ValueChanged -= numericUpDownOperatePlannedTime_ValueChanged;
            numericUpDownOperatePlannedDays.ValueChanged -= numericUpDownOperatePlannedTime_ValueChanged;
            numericUpDownOperatePlannedHours.Value = 24;
            numericUpDownOperatePlannedDays.Value = 1;
            numericUpDownOperatePlannedHours.ValueChanged += numericUpDownOperatePlannedTime_ValueChanged;
            numericUpDownOperatePlannedDays.ValueChanged += numericUpDownOperatePlannedTime_ValueChanged;
            CommonFunc.BindToDoStatusListToComboBox(comboBoxOperateStatus, null, true);
            comboBoxOperateStatus.SelectedValue = EnumToDoStatus.Planning;
        }

        private void labelHideInfo_Click(object sender, EventArgs e)
        {
            if (infoShowing)
            {
                groupBoxDataOperation.Text = string.Empty;
                groupBoxDataOperation.Width = labelHideInfo.Left + labelHideInfo.Width;
                labelHideInfo.Text = infoHidingText;
                infoShowing = false;
            }
            else
            {
                groupBoxDataOperation.Text = "数据/操作";
                groupBoxDataOperation.Width = 305;
                labelHideInfo.Text = infoShowingText;
                infoShowing = true;
            }
        }

        private void dateTimePickerOperatePlannedTime_ValueChanged(object sender, EventArgs e)
        {
            if (!dateTimePickerOperatePlannedStartFrom.Checked || !dateTimePickerOperatePlannedStartTo.Checked)
                return;
            numericUpDownOperatePlannedHours.ValueChanged -= numericUpDownOperatePlannedTime_ValueChanged;
            numericUpDownOperatePlannedDays.ValueChanged -= numericUpDownOperatePlannedTime_ValueChanged;
            decimal hours = (decimal)DateTimeManger.DateDiff(DateInterval.Hour, dateTimePickerOperatePlannedStartFrom.Value, dateTimePickerOperatePlannedStartTo.Value);
            numericUpDownOperatePlannedHours.Value = hours >= numericUpDownOperatePlannedHours.Minimum && hours <= numericUpDownOperatePlannedHours.Maximum ? hours : 0;
            decimal days = (decimal)DateTimeManger.DateDiff(DateInterval.Day, dateTimePickerOperatePlannedStartFrom.Value, dateTimePickerOperatePlannedStartTo.Value);
            numericUpDownOperatePlannedDays.Value = days >= numericUpDownOperatePlannedDays.Minimum && days <= numericUpDownOperatePlannedDays.Maximum ? days : 0;
            numericUpDownOperatePlannedHours.ValueChanged += numericUpDownOperatePlannedTime_ValueChanged;
            numericUpDownOperatePlannedDays.ValueChanged += numericUpDownOperatePlannedTime_ValueChanged;
        }

        private void numericUpDownOperatePlannedTime_ValueChanged(object sender, EventArgs e)
        {
            if (sender == numericUpDownOperatePlannedHours)
            {
                dateTimePickerOperatePlannedStartTo.ValueChanged -= dateTimePickerOperatePlannedTime_ValueChanged;
                dateTimePickerOperatePlannedStartTo.Value = dateTimePickerOperatePlannedStartFrom.Value.AddHours((double)numericUpDownOperatePlannedHours.Value);
                dateTimePickerOperatePlannedStartTo.ValueChanged += dateTimePickerOperatePlannedTime_ValueChanged;
                numericUpDownOperatePlannedDays.ValueChanged -= numericUpDownOperatePlannedTime_ValueChanged;
                numericUpDownOperatePlannedDays.Value = numericUpDownOperatePlannedHours.Value / 24;
                numericUpDownOperatePlannedDays.ValueChanged += numericUpDownOperatePlannedTime_ValueChanged;
            }
            else if (sender == numericUpDownOperatePlannedDays)
            {
                dateTimePickerOperatePlannedStartTo.ValueChanged -= dateTimePickerOperatePlannedTime_ValueChanged;
                dateTimePickerOperatePlannedStartTo.Value = dateTimePickerOperatePlannedStartFrom.Value.AddDays((double)numericUpDownOperatePlannedDays.Value);
                dateTimePickerOperatePlannedStartTo.ValueChanged += dateTimePickerOperatePlannedTime_ValueChanged;
                numericUpDownOperatePlannedHours.ValueChanged -= numericUpDownOperatePlannedTime_ValueChanged;
                numericUpDownOperatePlannedHours.Value = numericUpDownOperatePlannedDays.Value * 24;
                numericUpDownOperatePlannedHours.ValueChanged += numericUpDownOperatePlannedTime_ValueChanged;
            }
        }
    }
}
