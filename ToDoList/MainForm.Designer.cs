namespace ToDoList
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.comboBoxSearchAssignedTo = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.buttonSearchNextWeek = new System.Windows.Forms.Button();
            this.buttonSearchLastWeek = new System.Windows.Forms.Button();
            this.buttonSearchThisWeek = new System.Windows.Forms.Button();
            this.buttonSearchTomorrow = new System.Windows.Forms.Button();
            this.buttonSearchYesterday = new System.Windows.Forms.Button();
            this.buttonSearchToday = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.textBoxSearchRelatedID = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.comboBoxSearchBranch = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.dateTimePickerSearchPlannedEndTo = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerSearchPlannedEndFrom = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePickerSearchPlannedStartTo = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePickerSearchPlannedStartFrom = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxSearchStatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSearchContent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSearchTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxSearchProject = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.groupBoxToDoList = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewToDoList = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelHideInfo = new System.Windows.Forms.Label();
            this.groupBoxDataOperation = new System.Windows.Forms.GroupBox();
            this.checkBoxAddToReminder = new System.Windows.Forms.CheckBox();
            this.buttonCancelled = new System.Windows.Forms.Button();
            this.buttonOperateNextWeek = new System.Windows.Forms.Button();
            this.buttonOperateLastWeek = new System.Windows.Forms.Button();
            this.buttonOperateThisWeek = new System.Windows.Forms.Button();
            this.buttonOperateTomorrow = new System.Windows.Forms.Button();
            this.buttonOperateYesterday = new System.Windows.Forms.Button();
            this.buttonOperateToday = new System.Windows.Forms.Button();
            this.comboBoxOperateAssignedTo = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.splitContainerContentAndMemo = new System.Windows.Forms.SplitContainer();
            this.richTextBoxOperateContent = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.richTextBoxOperateMemo = new System.Windows.Forms.RichTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBoxOperateRelatedID = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.comboBoxOperateBranch = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.buttonWorking = new System.Windows.Forms.Button();
            this.buttonDone = new System.Windows.Forms.Button();
            this.comboBoxOperateStatus = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.numericUpDownOperatePlannedDays = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.numericUpDownOperatePlannedHours = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxOperateTitle = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dateTimePickerOperatePlannedEndTime = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBoxOperateSeverity = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBoxOperatePriority = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.dateTimePickerOperatePlannedStartTime = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxOperateProject = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.toolTipInfo = new System.Windows.Forms.ToolTip(this.components);
            this.ColumnDone = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAssignedTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPriority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSeverity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPlannedEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxSearch.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.groupBoxToDoList.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewToDoList)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBoxDataOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerContentAndMemo)).BeginInit();
            this.splitContainerContentAndMemo.Panel1.SuspendLayout();
            this.splitContainerContentAndMemo.Panel2.SuspendLayout();
            this.splitContainerContentAndMemo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOperatePlannedDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOperatePlannedHours)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Controls.Add(this.comboBoxSearchAssignedTo);
            this.groupBoxSearch.Controls.Add(this.label28);
            this.groupBoxSearch.Controls.Add(this.buttonSearchNextWeek);
            this.groupBoxSearch.Controls.Add(this.buttonSearchLastWeek);
            this.groupBoxSearch.Controls.Add(this.buttonSearchThisWeek);
            this.groupBoxSearch.Controls.Add(this.buttonSearchTomorrow);
            this.groupBoxSearch.Controls.Add(this.buttonSearchYesterday);
            this.groupBoxSearch.Controls.Add(this.buttonSearchToday);
            this.groupBoxSearch.Controls.Add(this.buttonExport);
            this.groupBoxSearch.Controls.Add(this.label26);
            this.groupBoxSearch.Controls.Add(this.textBoxSearchRelatedID);
            this.groupBoxSearch.Controls.Add(this.label25);
            this.groupBoxSearch.Controls.Add(this.comboBoxSearchBranch);
            this.groupBoxSearch.Controls.Add(this.label23);
            this.groupBoxSearch.Controls.Add(this.buttonSearch);
            this.groupBoxSearch.Controls.Add(this.dateTimePickerSearchPlannedEndTo);
            this.groupBoxSearch.Controls.Add(this.label5);
            this.groupBoxSearch.Controls.Add(this.dateTimePickerSearchPlannedEndFrom);
            this.groupBoxSearch.Controls.Add(this.label6);
            this.groupBoxSearch.Controls.Add(this.dateTimePickerSearchPlannedStartTo);
            this.groupBoxSearch.Controls.Add(this.label7);
            this.groupBoxSearch.Controls.Add(this.dateTimePickerSearchPlannedStartFrom);
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
            this.groupBoxSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxSearch.Size = new System.Drawing.Size(1387, 192);
            this.groupBoxSearch.TabIndex = 0;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "查询";
            // 
            // comboBoxSearchAssignedTo
            // 
            this.comboBoxSearchAssignedTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchAssignedTo.FormattingEnabled = true;
            this.comboBoxSearchAssignedTo.Location = new System.Drawing.Point(1000, 25);
            this.comboBoxSearchAssignedTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxSearchAssignedTo.Name = "comboBoxSearchAssignedTo";
            this.comboBoxSearchAssignedTo.Size = new System.Drawing.Size(120, 23);
            this.comboBoxSearchAssignedTo.TabIndex = 7;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(929, 29);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(67, 15);
            this.label28.TabIndex = 6;
            this.label28.Text = "指派给：";
            // 
            // buttonSearchNextWeek
            // 
            this.buttonSearchNextWeek.Location = new System.Drawing.Point(864, 124);
            this.buttonSearchNextWeek.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSearchNextWeek.Name = "buttonSearchNextWeek";
            this.buttonSearchNextWeek.Size = new System.Drawing.Size(55, 29);
            this.buttonSearchNextWeek.TabIndex = 29;
            this.buttonSearchNextWeek.Text = "下周";
            this.buttonSearchNextWeek.UseVisualStyleBackColor = true;
            this.buttonSearchNextWeek.Click += new System.EventHandler(this.buttonSearchNextWeek_Click);
            // 
            // buttonSearchLastWeek
            // 
            this.buttonSearchLastWeek.Location = new System.Drawing.Point(811, 124);
            this.buttonSearchLastWeek.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSearchLastWeek.Name = "buttonSearchLastWeek";
            this.buttonSearchLastWeek.Size = new System.Drawing.Size(55, 29);
            this.buttonSearchLastWeek.TabIndex = 28;
            this.buttonSearchLastWeek.Text = "上周";
            this.buttonSearchLastWeek.UseVisualStyleBackColor = true;
            this.buttonSearchLastWeek.Click += new System.EventHandler(this.buttonSearchLastWeek_Click);
            // 
            // buttonSearchThisWeek
            // 
            this.buttonSearchThisWeek.Location = new System.Drawing.Point(757, 124);
            this.buttonSearchThisWeek.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSearchThisWeek.Name = "buttonSearchThisWeek";
            this.buttonSearchThisWeek.Size = new System.Drawing.Size(55, 29);
            this.buttonSearchThisWeek.TabIndex = 27;
            this.buttonSearchThisWeek.Text = "本周";
            this.buttonSearchThisWeek.UseVisualStyleBackColor = true;
            this.buttonSearchThisWeek.Click += new System.EventHandler(this.buttonSearchThisWeek_Click);
            // 
            // buttonSearchTomorrow
            // 
            this.buttonSearchTomorrow.Location = new System.Drawing.Point(864, 90);
            this.buttonSearchTomorrow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSearchTomorrow.Name = "buttonSearchTomorrow";
            this.buttonSearchTomorrow.Size = new System.Drawing.Size(55, 29);
            this.buttonSearchTomorrow.TabIndex = 26;
            this.buttonSearchTomorrow.Text = "明日";
            this.buttonSearchTomorrow.UseVisualStyleBackColor = true;
            this.buttonSearchTomorrow.Click += new System.EventHandler(this.buttonSearchTomorrow_Click);
            // 
            // buttonSearchYesterday
            // 
            this.buttonSearchYesterday.Location = new System.Drawing.Point(811, 90);
            this.buttonSearchYesterday.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSearchYesterday.Name = "buttonSearchYesterday";
            this.buttonSearchYesterday.Size = new System.Drawing.Size(55, 29);
            this.buttonSearchYesterday.TabIndex = 25;
            this.buttonSearchYesterday.Text = "昨日";
            this.buttonSearchYesterday.UseVisualStyleBackColor = true;
            this.buttonSearchYesterday.Click += new System.EventHandler(this.buttonSearchYesterday_Click);
            // 
            // buttonSearchToday
            // 
            this.buttonSearchToday.Location = new System.Drawing.Point(757, 90);
            this.buttonSearchToday.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSearchToday.Name = "buttonSearchToday";
            this.buttonSearchToday.Size = new System.Drawing.Size(55, 29);
            this.buttonSearchToday.TabIndex = 24;
            this.buttonSearchToday.Text = "今日";
            this.buttonSearchToday.UseVisualStyleBackColor = true;
            this.buttonSearchToday.Click += new System.EventHandler(this.buttonSearchToday_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(1027, 56);
            this.buttonExport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(96, 96);
            this.buttonExport.TabIndex = 23;
            this.buttonExport.Text = "导 出";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.ForeColor = System.Drawing.Color.Red;
            this.label26.Location = new System.Drawing.Point(37, 161);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(863, 15);
            this.label26.TabIndex = 21;
            this.label26.Text = "下方“待办列表”和“数据/操作”可以拖动中间调节宽度；“数据/操作”中的“内容”和“备注”中间可以上下拖动调节高度。";
            // 
            // textBoxSearchRelatedID
            // 
            this.textBoxSearchRelatedID.Location = new System.Drawing.Point(776, 58);
            this.textBoxSearchRelatedID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxSearchRelatedID.Name = "textBoxSearchRelatedID";
            this.textBoxSearchRelatedID.Size = new System.Drawing.Size(140, 25);
            this.textBoxSearchRelatedID.TabIndex = 13;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(705, 62);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(68, 15);
            this.label25.TabIndex = 12;
            this.label25.Text = "关联ID：";
            // 
            // comboBoxSearchBranch
            // 
            this.comboBoxSearchBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchBranch.FormattingEnabled = true;
            this.comboBoxSearchBranch.Location = new System.Drawing.Point(475, 25);
            this.comboBoxSearchBranch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxSearchBranch.Name = "comboBoxSearchBranch";
            this.comboBoxSearchBranch.Size = new System.Drawing.Size(219, 23);
            this.comboBoxSearchBranch.TabIndex = 3;
            this.comboBoxSearchBranch.SelectedIndexChanged += new System.EventHandler(this.comboBoxSearchBranch_SelectedIndexChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(420, 29);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(52, 15);
            this.label23.TabIndex = 2;
            this.label23.Text = "分支：";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(929, 56);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(96, 96);
            this.buttonSearch.TabIndex = 22;
            this.buttonSearch.Text = "查 询";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // dateTimePickerSearchPlannedEndTo
            // 
            this.dateTimePickerSearchPlannedEndTo.CustomFormat = "yyyy年MM月dd日 HH时mm分";
            this.dateTimePickerSearchPlannedEndTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerSearchPlannedEndTo.Location = new System.Drawing.Point(475, 125);
            this.dateTimePickerSearchPlannedEndTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePickerSearchPlannedEndTo.Name = "dateTimePickerSearchPlannedEndTo";
            this.dateTimePickerSearchPlannedEndTo.ShowCheckBox = true;
            this.dateTimePickerSearchPlannedEndTo.Size = new System.Drawing.Size(265, 25);
            this.dateTimePickerSearchPlannedEndTo.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(432, 132);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 15);
            this.label5.TabIndex = 20;
            this.label5.Text = "～";
            // 
            // dateTimePickerSearchPlannedEndFrom
            // 
            this.dateTimePickerSearchPlannedEndFrom.CustomFormat = "yyyy年MM月dd日 HH时mm分";
            this.dateTimePickerSearchPlannedEndFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerSearchPlannedEndFrom.Location = new System.Drawing.Point(143, 125);
            this.dateTimePickerSearchPlannedEndFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePickerSearchPlannedEndFrom.Name = "dateTimePickerSearchPlannedEndFrom";
            this.dateTimePickerSearchPlannedEndFrom.ShowCheckBox = true;
            this.dateTimePickerSearchPlannedEndFrom.Size = new System.Drawing.Size(265, 25);
            this.dateTimePickerSearchPlannedEndFrom.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 132);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = "计划结束时间：";
            // 
            // dateTimePickerSearchPlannedStartTo
            // 
            this.dateTimePickerSearchPlannedStartTo.CustomFormat = "yyyy年MM月dd日 HH时mm分";
            this.dateTimePickerSearchPlannedStartTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerSearchPlannedStartTo.Location = new System.Drawing.Point(475, 91);
            this.dateTimePickerSearchPlannedStartTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePickerSearchPlannedStartTo.Name = "dateTimePickerSearchPlannedStartTo";
            this.dateTimePickerSearchPlannedStartTo.ShowCheckBox = true;
            this.dateTimePickerSearchPlannedStartTo.Size = new System.Drawing.Size(265, 25);
            this.dateTimePickerSearchPlannedStartTo.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(432, 99);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "～";
            // 
            // dateTimePickerSearchPlannedStartFrom
            // 
            this.dateTimePickerSearchPlannedStartFrom.CustomFormat = "yyyy年MM月dd日 HH时mm分";
            this.dateTimePickerSearchPlannedStartFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerSearchPlannedStartFrom.Location = new System.Drawing.Point(143, 91);
            this.dateTimePickerSearchPlannedStartFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePickerSearchPlannedStartFrom.Name = "dateTimePickerSearchPlannedStartFrom";
            this.dateTimePickerSearchPlannedStartFrom.ShowCheckBox = true;
            this.dateTimePickerSearchPlannedStartFrom.Size = new System.Drawing.Size(265, 25);
            this.dateTimePickerSearchPlannedStartFrom.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 99);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "计划开始时间：";
            // 
            // comboBoxSearchStatus
            // 
            this.comboBoxSearchStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchStatus.FormattingEnabled = true;
            this.comboBoxSearchStatus.Location = new System.Drawing.Point(776, 25);
            this.comboBoxSearchStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxSearchStatus.Name = "comboBoxSearchStatus";
            this.comboBoxSearchStatus.Size = new System.Drawing.Size(140, 23);
            this.comboBoxSearchStatus.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(705, 29);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "状  态：";
            // 
            // textBoxSearchContent
            // 
            this.textBoxSearchContent.Location = new System.Drawing.Point(475, 58);
            this.textBoxSearchContent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxSearchContent.Name = "textBoxSearchContent";
            this.textBoxSearchContent.Size = new System.Drawing.Size(219, 25);
            this.textBoxSearchContent.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(420, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "内容：";
            // 
            // textBoxSearchTitle
            // 
            this.textBoxSearchTitle.Location = new System.Drawing.Point(79, 58);
            this.textBoxSearchTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxSearchTitle.Name = "textBoxSearchTitle";
            this.textBoxSearchTitle.Size = new System.Drawing.Size(329, 25);
            this.textBoxSearchTitle.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "标题：";
            // 
            // comboBoxSearchProject
            // 
            this.comboBoxSearchProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchProject.FormattingEnabled = true;
            this.comboBoxSearchProject.Location = new System.Drawing.Point(79, 25);
            this.comboBoxSearchProject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxSearchProject.Name = "comboBoxSearchProject";
            this.comboBoxSearchProject.Size = new System.Drawing.Size(329, 23);
            this.comboBoxSearchProject.TabIndex = 1;
            this.comboBoxSearchProject.SelectedIndexChanged += new System.EventHandler(this.comboBoxSearchProject_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "项目：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainerMain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 192);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1387, 676);
            this.panel1.TabIndex = 1;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.groupBoxToDoList);
            this.splitContainerMain.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainerMain.Panel1MinSize = 100;
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.groupBoxDataOperation);
            this.splitContainerMain.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainerMain.Panel2MinSize = 308;
            this.splitContainerMain.Size = new System.Drawing.Size(1387, 676);
            this.splitContainerMain.SplitterDistance = 970;
            this.splitContainerMain.SplitterWidth = 5;
            this.splitContainerMain.TabIndex = 6;
            // 
            // groupBoxToDoList
            // 
            this.groupBoxToDoList.Controls.Add(this.panel2);
            this.groupBoxToDoList.Controls.Add(this.panel3);
            this.groupBoxToDoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxToDoList.Location = new System.Drawing.Point(0, 0);
            this.groupBoxToDoList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxToDoList.Name = "groupBoxToDoList";
            this.groupBoxToDoList.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxToDoList.Size = new System.Drawing.Size(970, 676);
            this.groupBoxToDoList.TabIndex = 6;
            this.groupBoxToDoList.TabStop = false;
            this.groupBoxToDoList.Text = "待办列表";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewToDoList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 22);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(942, 650);
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
            this.dataGridViewToDoList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewToDoList.MultiSelect = false;
            this.dataGridViewToDoList.Name = "dataGridViewToDoList";
            this.dataGridViewToDoList.ReadOnly = true;
            this.dataGridViewToDoList.RowHeadersVisible = false;
            this.dataGridViewToDoList.RowHeadersWidth = 51;
            this.dataGridViewToDoList.RowTemplate.Height = 23;
            this.dataGridViewToDoList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewToDoList.Size = new System.Drawing.Size(942, 650);
            this.dataGridViewToDoList.TabIndex = 0;
            this.dataGridViewToDoList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewToDoList_CellContentClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labelHideInfo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(946, 22);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(20, 650);
            this.panel3.TabIndex = 6;
            // 
            // labelHideInfo
            // 
            this.labelHideInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelHideInfo.Location = new System.Drawing.Point(0, 0);
            this.labelHideInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHideInfo.Name = "labelHideInfo";
            this.labelHideInfo.Size = new System.Drawing.Size(20, 650);
            this.labelHideInfo.TabIndex = 31;
            this.labelHideInfo.Text = ">\r\n\r\n\r\n>\r\n\r\n\r\n>\r\n\r\n\r\n>\r\n\r\n\r\n>\r\n\r\n\r\n>\r\n\r\n\r\n>\r\n\r\n\r\n>\r\n\r\n\r\n>";
            this.labelHideInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelHideInfo.Click += new System.EventHandler(this.labelHideInfo_Click);
            // 
            // groupBoxDataOperation
            // 
            this.groupBoxDataOperation.Controls.Add(this.checkBoxAddToReminder);
            this.groupBoxDataOperation.Controls.Add(this.buttonCancelled);
            this.groupBoxDataOperation.Controls.Add(this.buttonOperateNextWeek);
            this.groupBoxDataOperation.Controls.Add(this.buttonOperateLastWeek);
            this.groupBoxDataOperation.Controls.Add(this.buttonOperateThisWeek);
            this.groupBoxDataOperation.Controls.Add(this.buttonOperateTomorrow);
            this.groupBoxDataOperation.Controls.Add(this.buttonOperateYesterday);
            this.groupBoxDataOperation.Controls.Add(this.buttonOperateToday);
            this.groupBoxDataOperation.Controls.Add(this.comboBoxOperateAssignedTo);
            this.groupBoxDataOperation.Controls.Add(this.label27);
            this.groupBoxDataOperation.Controls.Add(this.splitContainerContentAndMemo);
            this.groupBoxDataOperation.Controls.Add(this.textBoxOperateRelatedID);
            this.groupBoxDataOperation.Controls.Add(this.label24);
            this.groupBoxDataOperation.Controls.Add(this.comboBoxOperateBranch);
            this.groupBoxDataOperation.Controls.Add(this.label22);
            this.groupBoxDataOperation.Controls.Add(this.label21);
            this.groupBoxDataOperation.Controls.Add(this.buttonWorking);
            this.groupBoxDataOperation.Controls.Add(this.buttonDone);
            this.groupBoxDataOperation.Controls.Add(this.comboBoxOperateStatus);
            this.groupBoxDataOperation.Controls.Add(this.label20);
            this.groupBoxDataOperation.Controls.Add(this.label18);
            this.groupBoxDataOperation.Controls.Add(this.numericUpDownOperatePlannedDays);
            this.groupBoxDataOperation.Controls.Add(this.label17);
            this.groupBoxDataOperation.Controls.Add(this.numericUpDownOperatePlannedHours);
            this.groupBoxDataOperation.Controls.Add(this.label16);
            this.groupBoxDataOperation.Controls.Add(this.textBoxOperateTitle);
            this.groupBoxDataOperation.Controls.Add(this.label15);
            this.groupBoxDataOperation.Controls.Add(this.dateTimePickerOperatePlannedEndTime);
            this.groupBoxDataOperation.Controls.Add(this.label14);
            this.groupBoxDataOperation.Controls.Add(this.comboBoxOperateSeverity);
            this.groupBoxDataOperation.Controls.Add(this.label13);
            this.groupBoxDataOperation.Controls.Add(this.comboBoxOperatePriority);
            this.groupBoxDataOperation.Controls.Add(this.label12);
            this.groupBoxDataOperation.Controls.Add(this.buttonDelete);
            this.groupBoxDataOperation.Controls.Add(this.buttonEdit);
            this.groupBoxDataOperation.Controls.Add(this.buttonAdd);
            this.groupBoxDataOperation.Controls.Add(this.dateTimePickerOperatePlannedStartTime);
            this.groupBoxDataOperation.Controls.Add(this.label10);
            this.groupBoxDataOperation.Controls.Add(this.comboBoxOperateProject);
            this.groupBoxDataOperation.Controls.Add(this.label11);
            this.groupBoxDataOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDataOperation.Location = new System.Drawing.Point(0, 0);
            this.groupBoxDataOperation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxDataOperation.Name = "groupBoxDataOperation";
            this.groupBoxDataOperation.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxDataOperation.Size = new System.Drawing.Size(412, 676);
            this.groupBoxDataOperation.TabIndex = 4;
            this.groupBoxDataOperation.TabStop = false;
            this.groupBoxDataOperation.Text = "数据/操作";
            // 
            // checkBoxAddToReminder
            // 
            this.checkBoxAddToReminder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxAddToReminder.AutoSize = true;
            this.checkBoxAddToReminder.Location = new System.Drawing.Point(261, 564);
            this.checkBoxAddToReminder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxAddToReminder.Name = "checkBoxAddToReminder";
            this.checkBoxAddToReminder.Size = new System.Drawing.Size(104, 19);
            this.checkBoxAddToReminder.TabIndex = 39;
            this.checkBoxAddToReminder.Text = "新增到提醒";
            this.checkBoxAddToReminder.UseVisualStyleBackColor = true;
            this.checkBoxAddToReminder.CheckedChanged += new System.EventHandler(this.checkBoxAddToReminder_CheckedChanged);
            // 
            // buttonCancelled
            // 
            this.buttonCancelled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancelled.Location = new System.Drawing.Point(307, 636);
            this.buttonCancelled.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCancelled.Name = "buttonCancelled";
            this.buttonCancelled.Size = new System.Drawing.Size(67, 29);
            this.buttonCancelled.TabIndex = 33;
            this.buttonCancelled.Text = "已取消";
            this.buttonCancelled.UseVisualStyleBackColor = true;
            this.buttonCancelled.Click += new System.EventHandler(this.buttonCancelled_Click);
            // 
            // buttonOperateNextWeek
            // 
            this.buttonOperateNextWeek.Location = new System.Drawing.Point(343, 192);
            this.buttonOperateNextWeek.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonOperateNextWeek.Name = "buttonOperateNextWeek";
            this.buttonOperateNextWeek.Size = new System.Drawing.Size(55, 29);
            this.buttonOperateNextWeek.TabIndex = 38;
            this.buttonOperateNextWeek.Text = "下周";
            this.buttonOperateNextWeek.UseVisualStyleBackColor = true;
            this.buttonOperateNextWeek.Click += new System.EventHandler(this.buttonOperateNextWeek_Click);
            // 
            // buttonOperateLastWeek
            // 
            this.buttonOperateLastWeek.Location = new System.Drawing.Point(289, 192);
            this.buttonOperateLastWeek.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonOperateLastWeek.Name = "buttonOperateLastWeek";
            this.buttonOperateLastWeek.Size = new System.Drawing.Size(55, 29);
            this.buttonOperateLastWeek.TabIndex = 37;
            this.buttonOperateLastWeek.Text = "上周";
            this.buttonOperateLastWeek.UseVisualStyleBackColor = true;
            this.buttonOperateLastWeek.Click += new System.EventHandler(this.buttonOperateLastWeek_Click);
            // 
            // buttonOperateThisWeek
            // 
            this.buttonOperateThisWeek.Location = new System.Drawing.Point(236, 192);
            this.buttonOperateThisWeek.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonOperateThisWeek.Name = "buttonOperateThisWeek";
            this.buttonOperateThisWeek.Size = new System.Drawing.Size(55, 29);
            this.buttonOperateThisWeek.TabIndex = 36;
            this.buttonOperateThisWeek.Text = "本周";
            this.buttonOperateThisWeek.UseVisualStyleBackColor = true;
            this.buttonOperateThisWeek.Click += new System.EventHandler(this.buttonOperateThisWeek_Click);
            // 
            // buttonOperateTomorrow
            // 
            this.buttonOperateTomorrow.Location = new System.Drawing.Point(343, 159);
            this.buttonOperateTomorrow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonOperateTomorrow.Name = "buttonOperateTomorrow";
            this.buttonOperateTomorrow.Size = new System.Drawing.Size(55, 29);
            this.buttonOperateTomorrow.TabIndex = 35;
            this.buttonOperateTomorrow.Text = "明日";
            this.buttonOperateTomorrow.UseVisualStyleBackColor = true;
            this.buttonOperateTomorrow.Click += new System.EventHandler(this.buttonOperateTomorrow_Click);
            // 
            // buttonOperateYesterday
            // 
            this.buttonOperateYesterday.Location = new System.Drawing.Point(289, 159);
            this.buttonOperateYesterday.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonOperateYesterday.Name = "buttonOperateYesterday";
            this.buttonOperateYesterday.Size = new System.Drawing.Size(55, 29);
            this.buttonOperateYesterday.TabIndex = 34;
            this.buttonOperateYesterday.Text = "昨日";
            this.buttonOperateYesterday.UseVisualStyleBackColor = true;
            this.buttonOperateYesterday.Click += new System.EventHandler(this.buttonOperateYesterday_Click);
            // 
            // buttonOperateToday
            // 
            this.buttonOperateToday.Location = new System.Drawing.Point(236, 159);
            this.buttonOperateToday.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonOperateToday.Name = "buttonOperateToday";
            this.buttonOperateToday.Size = new System.Drawing.Size(55, 29);
            this.buttonOperateToday.TabIndex = 33;
            this.buttonOperateToday.Text = "今日";
            this.buttonOperateToday.UseVisualStyleBackColor = true;
            this.buttonOperateToday.Click += new System.EventHandler(this.buttonOperateToday_Click);
            // 
            // comboBoxOperateAssignedTo
            // 
            this.comboBoxOperateAssignedTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperateAssignedTo.FormattingEnabled = true;
            this.comboBoxOperateAssignedTo.Location = new System.Drawing.Point(111, 194);
            this.comboBoxOperateAssignedTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxOperateAssignedTo.Name = "comboBoxOperateAssignedTo";
            this.comboBoxOperateAssignedTo.Size = new System.Drawing.Size(120, 23);
            this.comboBoxOperateAssignedTo.TabIndex = 11;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(16, 198);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(83, 15);
            this.label27.TabIndex = 10;
            this.label27.Text = "指 派 给：";
            // 
            // splitContainerContentAndMemo
            // 
            this.splitContainerContentAndMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerContentAndMemo.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerContentAndMemo.Location = new System.Drawing.Point(4, 361);
            this.splitContainerContentAndMemo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainerContentAndMemo.Name = "splitContainerContentAndMemo";
            this.splitContainerContentAndMemo.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerContentAndMemo.Panel1
            // 
            this.splitContainerContentAndMemo.Panel1.Controls.Add(this.richTextBoxOperateContent);
            this.splitContainerContentAndMemo.Panel1.Controls.Add(this.label9);
            // 
            // splitContainerContentAndMemo.Panel2
            // 
            this.splitContainerContentAndMemo.Panel2.Controls.Add(this.richTextBoxOperateMemo);
            this.splitContainerContentAndMemo.Panel2.Controls.Add(this.label19);
            this.splitContainerContentAndMemo.Size = new System.Drawing.Size(404, 191);
            this.splitContainerContentAndMemo.SplitterDistance = 112;
            this.splitContainerContentAndMemo.SplitterWidth = 5;
            this.splitContainerContentAndMemo.TabIndex = 24;
            // 
            // richTextBoxOperateContent
            // 
            this.richTextBoxOperateContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxOperateContent.Location = new System.Drawing.Point(107, 2);
            this.richTextBoxOperateContent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBoxOperateContent.Name = "richTextBoxOperateContent";
            this.richTextBoxOperateContent.Size = new System.Drawing.Size(286, 106);
            this.richTextBoxOperateContent.TabIndex = 1;
            this.richTextBoxOperateContent.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 2);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "内    容：";
            // 
            // richTextBoxOperateMemo
            // 
            this.richTextBoxOperateMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxOperateMemo.Location = new System.Drawing.Point(107, 2);
            this.richTextBoxOperateMemo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBoxOperateMemo.Name = "richTextBoxOperateMemo";
            this.richTextBoxOperateMemo.Size = new System.Drawing.Size(286, 68);
            this.richTextBoxOperateMemo.TabIndex = 3;
            this.richTextBoxOperateMemo.Text = "";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 2);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(84, 15);
            this.label19.TabIndex = 2;
            this.label19.Text = "备    注：";
            // 
            // textBoxOperateRelatedID
            // 
            this.textBoxOperateRelatedID.Location = new System.Drawing.Point(111, 95);
            this.textBoxOperateRelatedID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxOperateRelatedID.Name = "textBoxOperateRelatedID";
            this.textBoxOperateRelatedID.Size = new System.Drawing.Size(120, 25);
            this.textBoxOperateRelatedID.TabIndex = 5;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(16, 100);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(84, 15);
            this.label24.TabIndex = 4;
            this.label24.Text = "关 联 ID：";
            // 
            // comboBoxOperateBranch
            // 
            this.comboBoxOperateBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperateBranch.FormattingEnabled = true;
            this.comboBoxOperateBranch.Location = new System.Drawing.Point(111, 62);
            this.comboBoxOperateBranch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxOperateBranch.Name = "comboBoxOperateBranch";
            this.comboBoxOperateBranch.Size = new System.Drawing.Size(185, 23);
            this.comboBoxOperateBranch.TabIndex = 3;
            this.comboBoxOperateBranch.SelectedIndexChanged += new System.EventHandler(this.comboBoxOperateBranch_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(16, 66);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(84, 15);
            this.label22.TabIndex = 2;
            this.label22.Text = "分    支：";
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(60, 642);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(97, 15);
            this.label21.TabIndex = 30;
            this.label21.Text = "修改状态为：";
            // 
            // buttonWorking
            // 
            this.buttonWorking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonWorking.Location = new System.Drawing.Point(165, 636);
            this.buttonWorking.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonWorking.Name = "buttonWorking";
            this.buttonWorking.Size = new System.Drawing.Size(67, 29);
            this.buttonWorking.TabIndex = 31;
            this.buttonWorking.Text = "工作中";
            this.buttonWorking.UseVisualStyleBackColor = true;
            this.buttonWorking.Click += new System.EventHandler(this.buttonWorking_Click);
            // 
            // buttonDone
            // 
            this.buttonDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDone.Location = new System.Drawing.Point(236, 636);
            this.buttonDone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(67, 29);
            this.buttonDone.TabIndex = 32;
            this.buttonDone.Text = "已完成";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // comboBoxOperateStatus
            // 
            this.comboBoxOperateStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxOperateStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperateStatus.FormattingEnabled = true;
            this.comboBoxOperateStatus.Location = new System.Drawing.Point(111, 560);
            this.comboBoxOperateStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxOperateStatus.Name = "comboBoxOperateStatus";
            this.comboBoxOperateStatus.Size = new System.Drawing.Size(120, 23);
            this.comboBoxOperateStatus.TabIndex = 26;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(16, 563);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(84, 15);
            this.label20.TabIndex = 25;
            this.label20.Text = "状    态：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(355, 299);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(22, 15);
            this.label18.TabIndex = 20;
            this.label18.Text = "天";
            // 
            // numericUpDownOperatePlannedDays
            // 
            this.numericUpDownOperatePlannedDays.DecimalPlaces = 2;
            this.numericUpDownOperatePlannedDays.Location = new System.Drawing.Point(265, 294);
            this.numericUpDownOperatePlannedDays.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownOperatePlannedDays.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            0});
            this.numericUpDownOperatePlannedDays.Name = "numericUpDownOperatePlannedDays";
            this.numericUpDownOperatePlannedDays.Size = new System.Drawing.Size(87, 25);
            this.numericUpDownOperatePlannedDays.TabIndex = 19;
            this.numericUpDownOperatePlannedDays.ValueChanged += new System.EventHandler(this.numericUpDownOperatePlannedTime_ValueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(199, 299);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 15);
            this.label17.TabIndex = 18;
            this.label17.Text = "小时 或";
            // 
            // numericUpDownOperatePlannedHours
            // 
            this.numericUpDownOperatePlannedHours.DecimalPlaces = 2;
            this.numericUpDownOperatePlannedHours.Location = new System.Drawing.Point(111, 294);
            this.numericUpDownOperatePlannedHours.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownOperatePlannedHours.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            0});
            this.numericUpDownOperatePlannedHours.Name = "numericUpDownOperatePlannedHours";
            this.numericUpDownOperatePlannedHours.Size = new System.Drawing.Size(87, 25);
            this.numericUpDownOperatePlannedHours.TabIndex = 17;
            this.numericUpDownOperatePlannedHours.ValueChanged += new System.EventHandler(this.numericUpDownOperatePlannedTime_ValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 299);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(82, 15);
            this.label16.TabIndex = 16;
            this.label16.Text = "计划时长：";
            // 
            // textBoxOperateTitle
            // 
            this.textBoxOperateTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOperateTitle.Location = new System.Drawing.Point(111, 328);
            this.textBoxOperateTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxOperateTitle.Name = "textBoxOperateTitle";
            this.textBoxOperateTitle.Size = new System.Drawing.Size(286, 25);
            this.textBoxOperateTitle.TabIndex = 22;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 331);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 15);
            this.label15.TabIndex = 21;
            this.label15.Text = "标    题：";
            // 
            // dateTimePickerOperatePlannedEndTime
            // 
            this.dateTimePickerOperatePlannedEndTime.CustomFormat = "yyyy年MM月dd日 HH时mm分";
            this.dateTimePickerOperatePlannedEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerOperatePlannedEndTime.Location = new System.Drawing.Point(111, 260);
            this.dateTimePickerOperatePlannedEndTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePickerOperatePlannedEndTime.Name = "dateTimePickerOperatePlannedEndTime";
            this.dateTimePickerOperatePlannedEndTime.ShowCheckBox = true;
            this.dateTimePickerOperatePlannedEndTime.Size = new System.Drawing.Size(265, 25);
            this.dateTimePickerOperatePlannedEndTime.TabIndex = 15;
            this.dateTimePickerOperatePlannedEndTime.ValueChanged += new System.EventHandler(this.dateTimePickerOperatePlannedTime_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(83, 268);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 15);
            this.label14.TabIndex = 14;
            this.label14.Text = "～";
            // 
            // comboBoxOperateSeverity
            // 
            this.comboBoxOperateSeverity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperateSeverity.FormattingEnabled = true;
            this.comboBoxOperateSeverity.Location = new System.Drawing.Point(111, 161);
            this.comboBoxOperateSeverity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxOperateSeverity.Name = "comboBoxOperateSeverity";
            this.comboBoxOperateSeverity.Size = new System.Drawing.Size(120, 23);
            this.comboBoxOperateSeverity.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 165);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 15);
            this.label13.TabIndex = 8;
            this.label13.Text = "严 重 度：";
            // 
            // comboBoxOperatePriority
            // 
            this.comboBoxOperatePriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperatePriority.FormattingEnabled = true;
            this.comboBoxOperatePriority.Location = new System.Drawing.Point(111, 129);
            this.comboBoxOperatePriority.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxOperatePriority.Name = "comboBoxOperatePriority";
            this.comboBoxOperatePriority.Size = new System.Drawing.Size(120, 23);
            this.comboBoxOperatePriority.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 132);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 15);
            this.label12.TabIndex = 6;
            this.label12.Text = "优 先 级：";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDelete.Location = new System.Drawing.Point(273, 600);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(100, 29);
            this.buttonDelete.TabIndex = 29;
            this.buttonDelete.Text = "删除";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonEdit.Location = new System.Drawing.Point(165, 600);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(100, 29);
            this.buttonEdit.TabIndex = 28;
            this.buttonEdit.Text = "修改";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.Location = new System.Drawing.Point(57, 600);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(100, 29);
            this.buttonAdd.TabIndex = 27;
            this.buttonAdd.Text = "新增";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // dateTimePickerOperatePlannedStartTime
            // 
            this.dateTimePickerOperatePlannedStartTime.CustomFormat = "yyyy年MM月dd日 HH时mm分";
            this.dateTimePickerOperatePlannedStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerOperatePlannedStartTime.Location = new System.Drawing.Point(111, 226);
            this.dateTimePickerOperatePlannedStartTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePickerOperatePlannedStartTime.Name = "dateTimePickerOperatePlannedStartTime";
            this.dateTimePickerOperatePlannedStartTime.ShowCheckBox = true;
            this.dateTimePickerOperatePlannedStartTime.Size = new System.Drawing.Size(265, 25);
            this.dateTimePickerOperatePlannedStartTime.TabIndex = 13;
            this.dateTimePickerOperatePlannedStartTime.ValueChanged += new System.EventHandler(this.dateTimePickerOperatePlannedTime_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 231);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 15);
            this.label10.TabIndex = 12;
            this.label10.Text = "计划时间：";
            // 
            // comboBoxOperateProject
            // 
            this.comboBoxOperateProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperateProject.FormattingEnabled = true;
            this.comboBoxOperateProject.Location = new System.Drawing.Point(111, 29);
            this.comboBoxOperateProject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxOperateProject.Name = "comboBoxOperateProject";
            this.comboBoxOperateProject.Size = new System.Drawing.Size(185, 23);
            this.comboBoxOperateProject.TabIndex = 1;
            this.comboBoxOperateProject.SelectedIndexChanged += new System.EventHandler(this.comboBoxOperateProject_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 32);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "项    目：";
            // 
            // ColumnDone
            // 
            this.ColumnDone.FalseValue = "false";
            this.ColumnDone.HeaderText = "完成";
            this.ColumnDone.IndeterminateValue = "indeterminate";
            this.ColumnDone.MinimumWidth = 6;
            this.ColumnDone.Name = "ColumnDone";
            this.ColumnDone.ReadOnly = true;
            this.ColumnDone.ThreeState = true;
            this.ColumnDone.TrueValue = "true";
            this.ColumnDone.Width = 60;
            // 
            // ColumnOrderNo
            // 
            this.ColumnOrderNo.HeaderText = "序号";
            this.ColumnOrderNo.MinimumWidth = 6;
            this.ColumnOrderNo.Name = "ColumnOrderNo";
            this.ColumnOrderNo.ReadOnly = true;
            this.ColumnOrderNo.Width = 60;
            // 
            // ColumnProject
            // 
            this.ColumnProject.HeaderText = "项目";
            this.ColumnProject.MinimumWidth = 6;
            this.ColumnProject.Name = "ColumnProject";
            this.ColumnProject.ReadOnly = true;
            this.ColumnProject.Width = 125;
            // 
            // ColumnBranch
            // 
            this.ColumnBranch.HeaderText = "分支";
            this.ColumnBranch.MinimumWidth = 6;
            this.ColumnBranch.Name = "ColumnBranch";
            this.ColumnBranch.ReadOnly = true;
            this.ColumnBranch.Width = 125;
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
            this.ColumnAssignedTo.MinimumWidth = 6;
            this.ColumnAssignedTo.Name = "ColumnAssignedTo";
            this.ColumnAssignedTo.ReadOnly = true;
            this.ColumnAssignedTo.Width = 80;
            // 
            // ColumnPriority
            // 
            this.ColumnPriority.HeaderText = "优先级";
            this.ColumnPriority.MinimumWidth = 6;
            this.ColumnPriority.Name = "ColumnPriority";
            this.ColumnPriority.ReadOnly = true;
            this.ColumnPriority.Width = 80;
            // 
            // ColumnSeverity
            // 
            this.ColumnSeverity.HeaderText = "严重度";
            this.ColumnSeverity.MinimumWidth = 6;
            this.ColumnSeverity.Name = "ColumnSeverity";
            this.ColumnSeverity.ReadOnly = true;
            this.ColumnSeverity.Width = 80;
            // 
            // ColumnPlannedEndTime
            // 
            this.ColumnPlannedEndTime.HeaderText = "计划结束时间";
            this.ColumnPlannedEndTime.MinimumWidth = 6;
            this.ColumnPlannedEndTime.Name = "ColumnPlannedEndTime";
            this.ColumnPlannedEndTime.ReadOnly = true;
            this.ColumnPlannedEndTime.Width = 150;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1387, 868);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBoxSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "待办事项";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.groupBoxToDoList.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewToDoList)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBoxDataOperation.ResumeLayout(false);
            this.groupBoxDataOperation.PerformLayout();
            this.splitContainerContentAndMemo.Panel1.ResumeLayout(false);
            this.splitContainerContentAndMemo.Panel1.PerformLayout();
            this.splitContainerContentAndMemo.Panel2.ResumeLayout(false);
            this.splitContainerContentAndMemo.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerContentAndMemo)).EndInit();
            this.splitContainerContentAndMemo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOperatePlannedDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOperatePlannedHours)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.ComboBox comboBoxSearchProject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DateTimePicker dateTimePickerSearchPlannedEndTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerSearchPlannedEndFrom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePickerSearchPlannedStartTo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePickerSearchPlannedStartFrom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxSearchStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSearchContent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSearchTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBoxDataOperation;
        private System.Windows.Forms.DateTimePicker dateTimePickerOperatePlannedEndTime;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBoxOperateSeverity;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBoxOperatePriority;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.DateTimePicker dateTimePickerOperatePlannedStartTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxOperateProject;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown numericUpDownOperatePlannedDays;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown numericUpDownOperatePlannedHours;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxOperateTitle;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox comboBoxOperateStatus;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button buttonWorking;
        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.ToolTip toolTipInfo;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox comboBoxOperateBranch;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox comboBoxSearchBranch;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBoxOperateRelatedID;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox textBoxSearchRelatedID;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.GroupBox groupBoxToDoList;
        private System.Windows.Forms.DataGridView dataGridViewToDoList;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelHideInfo;
        private System.Windows.Forms.SplitContainer splitContainerContentAndMemo;
        private System.Windows.Forms.RichTextBox richTextBoxOperateContent;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox richTextBoxOperateMemo;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.ComboBox comboBoxOperateAssignedTo;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button buttonSearchToday;
        private System.Windows.Forms.Button buttonSearchTomorrow;
        private System.Windows.Forms.Button buttonSearchYesterday;
        private System.Windows.Forms.Button buttonSearchNextWeek;
        private System.Windows.Forms.Button buttonSearchLastWeek;
        private System.Windows.Forms.Button buttonSearchThisWeek;
        private System.Windows.Forms.Button buttonOperateNextWeek;
        private System.Windows.Forms.Button buttonOperateLastWeek;
        private System.Windows.Forms.Button buttonOperateThisWeek;
        private System.Windows.Forms.Button buttonOperateTomorrow;
        private System.Windows.Forms.Button buttonOperateYesterday;
        private System.Windows.Forms.Button buttonOperateToday;
        private System.Windows.Forms.ComboBox comboBoxSearchAssignedTo;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button buttonCancelled;
        private System.Windows.Forms.CheckBox checkBoxAddToReminder;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnDone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProject;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAssignedTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPriority;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSeverity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPlannedEndTime;
    }
}