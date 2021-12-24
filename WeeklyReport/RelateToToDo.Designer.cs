namespace WeeklyReport
{
    partial class RelateToToDo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RelateToToDo));
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonRelate = new System.Windows.Forms.Button();
            this.groupBoxToDoList = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewToDoList = new System.Windows.Forms.DataGridView();
            this.ColumnDone = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAssignedTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPriority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSeverity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPlannedEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSearchProject = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSearchTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSearchContent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxSearchStatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePickerSearchFisnishTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePickerSearchFinishTimeTo = new System.Windows.Forms.DateTimePicker();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.comboBoxSearchBranch = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.textBoxSearchRelatedID = new System.Windows.Forms.TextBox();
            this.buttonSearchToday = new System.Windows.Forms.Button();
            this.buttonSearchYesterday = new System.Windows.Forms.Button();
            this.buttonSearchTomorrow = new System.Windows.Forms.Button();
            this.buttonSearchThisWeek = new System.Windows.Forms.Button();
            this.buttonSearchLastWeek = new System.Windows.Forms.Button();
            this.buttonSearchNextWeek = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.comboBoxSearchFinishUser = new System.Windows.Forms.ComboBox();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.panelButtons.SuspendLayout();
            this.groupBoxToDoList.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewToDoList)).BeginInit();
            this.groupBoxSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.buttonClose);
            this.panelButtons.Controls.Add(this.buttonRelate);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 498);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(857, 38);
            this.panelButtons.TabIndex = 2;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(467, 9);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "关闭";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonRelate
            // 
            this.buttonRelate.Location = new System.Drawing.Point(282, 9);
            this.buttonRelate.Name = "buttonRelate";
            this.buttonRelate.Size = new System.Drawing.Size(75, 23);
            this.buttonRelate.TabIndex = 0;
            this.buttonRelate.Text = "关联";
            this.buttonRelate.UseVisualStyleBackColor = true;
            this.buttonRelate.Click += new System.EventHandler(this.buttonRelate_Click);
            // 
            // groupBoxToDoList
            // 
            this.groupBoxToDoList.Controls.Add(this.panel2);
            this.groupBoxToDoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxToDoList.Location = new System.Drawing.Point(0, 107);
            this.groupBoxToDoList.Name = "groupBoxToDoList";
            this.groupBoxToDoList.Size = new System.Drawing.Size(857, 391);
            this.groupBoxToDoList.TabIndex = 7;
            this.groupBoxToDoList.TabStop = false;
            this.groupBoxToDoList.Text = "待办列表";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewToDoList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(851, 371);
            this.panel2.TabIndex = 7;
            // 
            // dataGridViewToDoList
            // 
            this.dataGridViewToDoList.AllowUserToAddRows = false;
            this.dataGridViewToDoList.AllowUserToDeleteRows = false;
            this.dataGridViewToDoList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewToDoList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDone,
            this.ColumnOrderNo,
            this.ColumnProject,
            this.ColumnBranch,
            this.ColumnTitle,
            this.ColumnAssignedTo,
            this.ColumnPriority,
            this.ColumnSeverity,
            this.ColumnPlannedEndTime});
            this.dataGridViewToDoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewToDoList.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewToDoList.MultiSelect = false;
            this.dataGridViewToDoList.Name = "dataGridViewToDoList";
            this.dataGridViewToDoList.ReadOnly = true;
            this.dataGridViewToDoList.RowHeadersVisible = false;
            this.dataGridViewToDoList.RowTemplate.Height = 23;
            this.dataGridViewToDoList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewToDoList.Size = new System.Drawing.Size(851, 371);
            this.dataGridViewToDoList.TabIndex = 0;
            // 
            // ColumnDone
            // 
            this.ColumnDone.FalseValue = "false";
            this.ColumnDone.HeaderText = "完成";
            this.ColumnDone.IndeterminateValue = "indeterminate";
            this.ColumnDone.Name = "ColumnDone";
            this.ColumnDone.ReadOnly = true;
            this.ColumnDone.ThreeState = true;
            this.ColumnDone.TrueValue = "true";
            this.ColumnDone.Width = 40;
            // 
            // ColumnOrderNo
            // 
            this.ColumnOrderNo.HeaderText = "序号";
            this.ColumnOrderNo.Name = "ColumnOrderNo";
            this.ColumnOrderNo.ReadOnly = true;
            this.ColumnOrderNo.Width = 52;
            // 
            // ColumnProject
            // 
            this.ColumnProject.HeaderText = "项目";
            this.ColumnProject.Name = "ColumnProject";
            this.ColumnProject.ReadOnly = true;
            // 
            // ColumnBranch
            // 
            this.ColumnBranch.HeaderText = "分支";
            this.ColumnBranch.Name = "ColumnBranch";
            this.ColumnBranch.ReadOnly = true;
            // 
            // ColumnTitle
            // 
            this.ColumnTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnTitle.HeaderText = "标题";
            this.ColumnTitle.MinimumWidth = 150;
            this.ColumnTitle.Name = "ColumnTitle";
            this.ColumnTitle.ReadOnly = true;
            // 
            // ColumnAssignedTo
            // 
            this.ColumnAssignedTo.HeaderText = "指派给";
            this.ColumnAssignedTo.Name = "ColumnAssignedTo";
            this.ColumnAssignedTo.ReadOnly = true;
            this.ColumnAssignedTo.Width = 75;
            // 
            // ColumnPriority
            // 
            this.ColumnPriority.HeaderText = "优先级";
            this.ColumnPriority.Name = "ColumnPriority";
            this.ColumnPriority.ReadOnly = true;
            this.ColumnPriority.Width = 70;
            // 
            // ColumnSeverity
            // 
            this.ColumnSeverity.HeaderText = "严重度";
            this.ColumnSeverity.Name = "ColumnSeverity";
            this.ColumnSeverity.ReadOnly = true;
            this.ColumnSeverity.Width = 70;
            // 
            // ColumnPlannedEndTime
            // 
            this.ColumnPlannedEndTime.HeaderText = "计划结束时间";
            this.ColumnPlannedEndTime.Name = "ColumnPlannedEndTime";
            this.ColumnPlannedEndTime.ReadOnly = true;
            this.ColumnPlannedEndTime.Width = 120;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "项目：";
            // 
            // comboBoxSearchProject
            // 
            this.comboBoxSearchProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchProject.FormattingEnabled = true;
            this.comboBoxSearchProject.Location = new System.Drawing.Point(59, 20);
            this.comboBoxSearchProject.Name = "comboBoxSearchProject";
            this.comboBoxSearchProject.Size = new System.Drawing.Size(248, 20);
            this.comboBoxSearchProject.TabIndex = 1;
            this.comboBoxSearchProject.SelectedIndexChanged += new System.EventHandler(this.comboBoxSearchProject_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "标题：";
            // 
            // textBoxSearchTitle
            // 
            this.textBoxSearchTitle.Location = new System.Drawing.Point(59, 46);
            this.textBoxSearchTitle.Name = "textBoxSearchTitle";
            this.textBoxSearchTitle.Size = new System.Drawing.Size(248, 21);
            this.textBoxSearchTitle.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(315, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "内容：";
            // 
            // textBoxSearchContent
            // 
            this.textBoxSearchContent.Location = new System.Drawing.Point(356, 46);
            this.textBoxSearchContent.Name = "textBoxSearchContent";
            this.textBoxSearchContent.Size = new System.Drawing.Size(165, 21);
            this.textBoxSearchContent.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(529, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "状  态：";
            // 
            // comboBoxSearchStatus
            // 
            this.comboBoxSearchStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchStatus.FormattingEnabled = true;
            this.comboBoxSearchStatus.Location = new System.Drawing.Point(582, 20);
            this.comboBoxSearchStatus.Name = "comboBoxSearchStatus";
            this.comboBoxSearchStatus.Size = new System.Drawing.Size(106, 20);
            this.comboBoxSearchStatus.TabIndex = 5;
            this.comboBoxSearchStatus.SelectedIndexChanged += new System.EventHandler(this.comboBoxSearchStatus_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "完成时间：";
            // 
            // dateTimePickerSearchFisnishTimeFrom
            // 
            this.dateTimePickerSearchFisnishTimeFrom.CustomFormat = "yyyy年MM月dd日 HH时";
            this.dateTimePickerSearchFisnishTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerSearchFisnishTimeFrom.Location = new System.Drawing.Point(83, 73);
            this.dateTimePickerSearchFisnishTimeFrom.Name = "dateTimePickerSearchFisnishTimeFrom";
            this.dateTimePickerSearchFisnishTimeFrom.ShowCheckBox = true;
            this.dateTimePickerSearchFisnishTimeFrom.Size = new System.Drawing.Size(170, 21);
            this.dateTimePickerSearchFisnishTimeFrom.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(259, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "～";
            // 
            // dateTimePickerSearchFinishTimeTo
            // 
            this.dateTimePickerSearchFinishTimeTo.CustomFormat = "yyyy年MM月dd日 HH时";
            this.dateTimePickerSearchFinishTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerSearchFinishTimeTo.Location = new System.Drawing.Point(282, 73);
            this.dateTimePickerSearchFinishTimeTo.Name = "dateTimePickerSearchFinishTimeTo";
            this.dateTimePickerSearchFinishTimeTo.ShowCheckBox = true;
            this.dateTimePickerSearchFinishTimeTo.Size = new System.Drawing.Size(170, 21);
            this.dateTimePickerSearchFinishTimeTo.TabIndex = 17;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(699, 45);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(143, 50);
            this.buttonSearch.TabIndex = 18;
            this.buttonSearch.Text = "查   询";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(315, 23);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(41, 12);
            this.label23.TabIndex = 2;
            this.label23.Text = "分支：";
            // 
            // comboBoxSearchBranch
            // 
            this.comboBoxSearchBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchBranch.FormattingEnabled = true;
            this.comboBoxSearchBranch.Location = new System.Drawing.Point(356, 20);
            this.comboBoxSearchBranch.Name = "comboBoxSearchBranch";
            this.comboBoxSearchBranch.Size = new System.Drawing.Size(165, 20);
            this.comboBoxSearchBranch.TabIndex = 3;
            this.comboBoxSearchBranch.SelectedIndexChanged += new System.EventHandler(this.comboBoxSearchBranch_SelectedIndexChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(529, 50);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(53, 12);
            this.label25.TabIndex = 12;
            this.label25.Text = "关联ID：";
            // 
            // textBoxSearchRelatedID
            // 
            this.textBoxSearchRelatedID.Location = new System.Drawing.Point(582, 46);
            this.textBoxSearchRelatedID.Name = "textBoxSearchRelatedID";
            this.textBoxSearchRelatedID.Size = new System.Drawing.Size(106, 21);
            this.textBoxSearchRelatedID.TabIndex = 13;
            // 
            // buttonSearchToday
            // 
            this.buttonSearchToday.Location = new System.Drawing.Point(466, 72);
            this.buttonSearchToday.Name = "buttonSearchToday";
            this.buttonSearchToday.Size = new System.Drawing.Size(38, 23);
            this.buttonSearchToday.TabIndex = 19;
            this.buttonSearchToday.Text = "今日";
            this.buttonSearchToday.UseVisualStyleBackColor = true;
            this.buttonSearchToday.Click += new System.EventHandler(this.buttonSearchToday_Click);
            // 
            // buttonSearchYesterday
            // 
            this.buttonSearchYesterday.Location = new System.Drawing.Point(503, 72);
            this.buttonSearchYesterday.Name = "buttonSearchYesterday";
            this.buttonSearchYesterday.Size = new System.Drawing.Size(38, 23);
            this.buttonSearchYesterday.TabIndex = 20;
            this.buttonSearchYesterday.Text = "昨日";
            this.buttonSearchYesterday.UseVisualStyleBackColor = true;
            this.buttonSearchYesterday.Click += new System.EventHandler(this.buttonSearchYesterday_Click);
            // 
            // buttonSearchTomorrow
            // 
            this.buttonSearchTomorrow.Location = new System.Drawing.Point(540, 72);
            this.buttonSearchTomorrow.Name = "buttonSearchTomorrow";
            this.buttonSearchTomorrow.Size = new System.Drawing.Size(38, 23);
            this.buttonSearchTomorrow.TabIndex = 21;
            this.buttonSearchTomorrow.Text = "明日";
            this.buttonSearchTomorrow.UseVisualStyleBackColor = true;
            this.buttonSearchTomorrow.Click += new System.EventHandler(this.buttonSearchTomorrow_Click);
            // 
            // buttonSearchThisWeek
            // 
            this.buttonSearchThisWeek.Location = new System.Drawing.Point(577, 72);
            this.buttonSearchThisWeek.Name = "buttonSearchThisWeek";
            this.buttonSearchThisWeek.Size = new System.Drawing.Size(38, 23);
            this.buttonSearchThisWeek.TabIndex = 22;
            this.buttonSearchThisWeek.Text = "本周";
            this.buttonSearchThisWeek.UseVisualStyleBackColor = true;
            this.buttonSearchThisWeek.Click += new System.EventHandler(this.buttonSearchThisWeek_Click);
            // 
            // buttonSearchLastWeek
            // 
            this.buttonSearchLastWeek.Location = new System.Drawing.Point(614, 72);
            this.buttonSearchLastWeek.Name = "buttonSearchLastWeek";
            this.buttonSearchLastWeek.Size = new System.Drawing.Size(38, 23);
            this.buttonSearchLastWeek.TabIndex = 23;
            this.buttonSearchLastWeek.Text = "上周";
            this.buttonSearchLastWeek.UseVisualStyleBackColor = true;
            this.buttonSearchLastWeek.Click += new System.EventHandler(this.buttonSearchLastWeek_Click);
            // 
            // buttonSearchNextWeek
            // 
            this.buttonSearchNextWeek.Location = new System.Drawing.Point(651, 72);
            this.buttonSearchNextWeek.Name = "buttonSearchNextWeek";
            this.buttonSearchNextWeek.Size = new System.Drawing.Size(38, 23);
            this.buttonSearchNextWeek.TabIndex = 24;
            this.buttonSearchNextWeek.Text = "下周";
            this.buttonSearchNextWeek.UseVisualStyleBackColor = true;
            this.buttonSearchNextWeek.Click += new System.EventHandler(this.buttonSearchNextWeek_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(697, 23);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(53, 12);
            this.label28.TabIndex = 6;
            this.label28.Text = "完成人：";
            // 
            // comboBoxSearchFinishUser
            // 
            this.comboBoxSearchFinishUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchFinishUser.FormattingEnabled = true;
            this.comboBoxSearchFinishUser.Location = new System.Drawing.Point(750, 20);
            this.comboBoxSearchFinishUser.Name = "comboBoxSearchFinishUser";
            this.comboBoxSearchFinishUser.Size = new System.Drawing.Size(91, 20);
            this.comboBoxSearchFinishUser.TabIndex = 7;
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Controls.Add(this.comboBoxSearchFinishUser);
            this.groupBoxSearch.Controls.Add(this.label28);
            this.groupBoxSearch.Controls.Add(this.buttonSearchNextWeek);
            this.groupBoxSearch.Controls.Add(this.buttonSearchLastWeek);
            this.groupBoxSearch.Controls.Add(this.buttonSearchThisWeek);
            this.groupBoxSearch.Controls.Add(this.buttonSearchTomorrow);
            this.groupBoxSearch.Controls.Add(this.buttonSearchYesterday);
            this.groupBoxSearch.Controls.Add(this.buttonSearchToday);
            this.groupBoxSearch.Controls.Add(this.textBoxSearchRelatedID);
            this.groupBoxSearch.Controls.Add(this.label25);
            this.groupBoxSearch.Controls.Add(this.comboBoxSearchBranch);
            this.groupBoxSearch.Controls.Add(this.label23);
            this.groupBoxSearch.Controls.Add(this.buttonSearch);
            this.groupBoxSearch.Controls.Add(this.dateTimePickerSearchFinishTimeTo);
            this.groupBoxSearch.Controls.Add(this.label7);
            this.groupBoxSearch.Controls.Add(this.dateTimePickerSearchFisnishTimeFrom);
            this.groupBoxSearch.Controls.Add(this.label8);
            this.groupBoxSearch.Controls.Add(this.comboBoxSearchStatus);
            this.groupBoxSearch.Controls.Add(this.label4);
            this.groupBoxSearch.Controls.Add(this.textBoxSearchContent);
            this.groupBoxSearch.Controls.Add(this.label3);
            this.groupBoxSearch.Controls.Add(this.textBoxSearchTitle);
            this.groupBoxSearch.Controls.Add(this.label2);
            this.groupBoxSearch.Controls.Add(this.comboBoxSearchProject);
            this.groupBoxSearch.Controls.Add(this.label1);
            this.groupBoxSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxSearch.Location = new System.Drawing.Point(0, 0);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(857, 107);
            this.groupBoxSearch.TabIndex = 1;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "查询";
            // 
            // RelateToToDo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(857, 536);
            this.Controls.Add(this.groupBoxToDoList);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.groupBoxSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RelateToToDo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "关联待办项";
            this.Load += new System.EventHandler(this.RelateToToDo_Load);
            this.panelButtons.ResumeLayout(false);
            this.groupBoxToDoList.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewToDoList)).EndInit();
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.GroupBox groupBoxToDoList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewToDoList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnDone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProject;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAssignedTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPriority;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSeverity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPlannedEndTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxSearchProject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSearchTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSearchContent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxSearchStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePickerSearchFisnishTimeFrom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePickerSearchFinishTimeTo;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox comboBoxSearchBranch;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox textBoxSearchRelatedID;
        private System.Windows.Forms.Button buttonSearchToday;
        private System.Windows.Forms.Button buttonSearchYesterday;
        private System.Windows.Forms.Button buttonSearchTomorrow;
        private System.Windows.Forms.Button buttonSearchThisWeek;
        private System.Windows.Forms.Button buttonSearchLastWeek;
        private System.Windows.Forms.Button buttonSearchNextWeek;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox comboBoxSearchFinishUser;
        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonRelate;
    }
}