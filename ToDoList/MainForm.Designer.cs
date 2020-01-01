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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewToDoList = new System.Windows.Forms.DataGridView();
            this.groupBoxDataOperation = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.labelHideInfo = new System.Windows.Forms.Label();
            this.buttonWorking = new System.Windows.Forms.Button();
            this.buttonDone = new System.Windows.Forms.Button();
            this.comboBoxOperateStatus = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.richTextBoxOperateMemo = new System.Windows.Forms.RichTextBox();
            this.label19 = new System.Windows.Forms.Label();
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
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.richTextBoxOperateContent = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePickerOperatePlannedStartTime = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxOperateProject = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.toolTipInfo = new System.Windows.Forms.ToolTip(this.components);
            this.ColumnDone = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPriority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSeverity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewToDoList)).BeginInit();
            this.groupBoxDataOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOperatePlannedDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOperatePlannedHours)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSearch);
            this.groupBox1.Controls.Add(this.dateTimePickerSearchPlannedEndTo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dateTimePickerSearchPlannedEndFrom);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dateTimePickerSearchPlannedStartTo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dateTimePickerSearchPlannedStartFrom);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.comboBoxSearchStatus);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxSearchContent);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxSearchTitle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxSearchProject);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(711, 107);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(559, 47);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 48);
            this.buttonSearch.TabIndex = 16;
            this.buttonSearch.Text = "查询";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // dateTimePickerSearchPlannedEndTo
            // 
            this.dateTimePickerSearchPlannedEndTo.CustomFormat = "yyyy年MM月dd日 HH时mm分";
            this.dateTimePickerSearchPlannedEndTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerSearchPlannedEndTo.Location = new System.Drawing.Point(336, 74);
            this.dateTimePickerSearchPlannedEndTo.Name = "dateTimePickerSearchPlannedEndTo";
            this.dateTimePickerSearchPlannedEndTo.ShowCheckBox = true;
            this.dateTimePickerSearchPlannedEndTo.Size = new System.Drawing.Size(200, 21);
            this.dateTimePickerSearchPlannedEndTo.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(313, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "～";
            // 
            // dateTimePickerSearchPlannedEndFrom
            // 
            this.dateTimePickerSearchPlannedEndFrom.CustomFormat = "yyyy年MM月dd日 HH时mm分";
            this.dateTimePickerSearchPlannedEndFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerSearchPlannedEndFrom.Location = new System.Drawing.Point(107, 74);
            this.dateTimePickerSearchPlannedEndFrom.Name = "dateTimePickerSearchPlannedEndFrom";
            this.dateTimePickerSearchPlannedEndFrom.ShowCheckBox = true;
            this.dateTimePickerSearchPlannedEndFrom.Size = new System.Drawing.Size(200, 21);
            this.dateTimePickerSearchPlannedEndFrom.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "计划结束时间：";
            // 
            // dateTimePickerSearchPlannedStartTo
            // 
            this.dateTimePickerSearchPlannedStartTo.CustomFormat = "yyyy年MM月dd日 HH时mm分";
            this.dateTimePickerSearchPlannedStartTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerSearchPlannedStartTo.Location = new System.Drawing.Point(336, 47);
            this.dateTimePickerSearchPlannedStartTo.Name = "dateTimePickerSearchPlannedStartTo";
            this.dateTimePickerSearchPlannedStartTo.ShowCheckBox = true;
            this.dateTimePickerSearchPlannedStartTo.Size = new System.Drawing.Size(200, 21);
            this.dateTimePickerSearchPlannedStartTo.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(313, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "～";
            // 
            // dateTimePickerSearchPlannedStartFrom
            // 
            this.dateTimePickerSearchPlannedStartFrom.CustomFormat = "yyyy年MM月dd日 HH时mm分";
            this.dateTimePickerSearchPlannedStartFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerSearchPlannedStartFrom.Location = new System.Drawing.Point(107, 47);
            this.dateTimePickerSearchPlannedStartFrom.Name = "dateTimePickerSearchPlannedStartFrom";
            this.dateTimePickerSearchPlannedStartFrom.ShowCheckBox = true;
            this.dateTimePickerSearchPlannedStartFrom.Size = new System.Drawing.Size(200, 21);
            this.dateTimePickerSearchPlannedStartFrom.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "计划开始时间：";
            // 
            // comboBoxSearchStatus
            // 
            this.comboBoxSearchStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchStatus.FormattingEnabled = true;
            this.comboBoxSearchStatus.Location = new System.Drawing.Point(559, 20);
            this.comboBoxSearchStatus.Name = "comboBoxSearchStatus";
            this.comboBoxSearchStatus.Size = new System.Drawing.Size(75, 20);
            this.comboBoxSearchStatus.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(511, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "状态：";
            // 
            // textBoxSearchContent
            // 
            this.textBoxSearchContent.Location = new System.Drawing.Point(405, 20);
            this.textBoxSearchContent.Name = "textBoxSearchContent";
            this.textBoxSearchContent.Size = new System.Drawing.Size(100, 21);
            this.textBoxSearchContent.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(358, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "内容：";
            // 
            // textBoxSearchTitle
            // 
            this.textBoxSearchTitle.Location = new System.Drawing.Point(252, 19);
            this.textBoxSearchTitle.Name = "textBoxSearchTitle";
            this.textBoxSearchTitle.Size = new System.Drawing.Size(100, 21);
            this.textBoxSearchTitle.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "标题：";
            // 
            // comboBoxSearchProject
            // 
            this.comboBoxSearchProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchProject.FormattingEnabled = true;
            this.comboBoxSearchProject.Location = new System.Drawing.Point(59, 20);
            this.comboBoxSearchProject.Name = "comboBoxSearchProject";
            this.comboBoxSearchProject.Size = new System.Drawing.Size(140, 20);
            this.comboBoxSearchProject.TabIndex = 1;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBoxDataOperation);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(711, 540);
            this.panel1.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewToDoList);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(406, 540);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "待办列表";
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
            this.ColumnTitle,
            this.ColumnPriority,
            this.ColumnSeverity});
            this.dataGridViewToDoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewToDoList.Location = new System.Drawing.Point(3, 17);
            this.dataGridViewToDoList.MultiSelect = false;
            this.dataGridViewToDoList.Name = "dataGridViewToDoList";
            this.dataGridViewToDoList.ReadOnly = true;
            this.dataGridViewToDoList.RowHeadersVisible = false;
            this.dataGridViewToDoList.RowTemplate.Height = 23;
            this.dataGridViewToDoList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewToDoList.Size = new System.Drawing.Size(400, 520);
            this.dataGridViewToDoList.TabIndex = 0;
            this.dataGridViewToDoList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewToDoList_CellContentClick);
            this.dataGridViewToDoList.SelectionChanged += new System.EventHandler(this.dataGridViewToDoList_SelectionChanged);
            // 
            // groupBoxDataOperation
            // 
            this.groupBoxDataOperation.Controls.Add(this.label21);
            this.groupBoxDataOperation.Controls.Add(this.labelHideInfo);
            this.groupBoxDataOperation.Controls.Add(this.buttonWorking);
            this.groupBoxDataOperation.Controls.Add(this.buttonDone);
            this.groupBoxDataOperation.Controls.Add(this.comboBoxOperateStatus);
            this.groupBoxDataOperation.Controls.Add(this.label20);
            this.groupBoxDataOperation.Controls.Add(this.richTextBoxOperateMemo);
            this.groupBoxDataOperation.Controls.Add(this.label19);
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
            this.groupBoxDataOperation.Controls.Add(this.buttonExport);
            this.groupBoxDataOperation.Controls.Add(this.buttonEdit);
            this.groupBoxDataOperation.Controls.Add(this.buttonAdd);
            this.groupBoxDataOperation.Controls.Add(this.richTextBoxOperateContent);
            this.groupBoxDataOperation.Controls.Add(this.label9);
            this.groupBoxDataOperation.Controls.Add(this.dateTimePickerOperatePlannedStartTime);
            this.groupBoxDataOperation.Controls.Add(this.label10);
            this.groupBoxDataOperation.Controls.Add(this.comboBoxOperateProject);
            this.groupBoxDataOperation.Controls.Add(this.label11);
            this.groupBoxDataOperation.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBoxDataOperation.Location = new System.Drawing.Point(406, 0);
            this.groupBoxDataOperation.Name = "groupBoxDataOperation";
            this.groupBoxDataOperation.Size = new System.Drawing.Size(305, 540);
            this.groupBoxDataOperation.TabIndex = 4;
            this.groupBoxDataOperation.TabStop = false;
            this.groupBoxDataOperation.Text = "数据/操作";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(57, 447);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 12);
            this.label21.TabIndex = 30;
            this.label21.Text = "修改状态为：";
            // 
            // labelHideInfo
            // 
            this.labelHideInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelHideInfo.Location = new System.Drawing.Point(3, 17);
            this.labelHideInfo.Name = "labelHideInfo";
            this.labelHideInfo.Size = new System.Drawing.Size(15, 520);
            this.labelHideInfo.TabIndex = 29;
            this.labelHideInfo.Text = ">\r\n\r\n\r\n>\r\n\r\n\r\n>\r\n\r\n\r\n>\r\n\r\n\r\n>\r\n\r\n\r\n>\r\n\r\n\r\n>\r\n\r\n\r\n>\r\n\r\n\r\n>";
            this.labelHideInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelHideInfo.Click += new System.EventHandler(this.labelHideInfo_Click);
            // 
            // buttonWorking
            // 
            this.buttonWorking.Location = new System.Drawing.Point(136, 442);
            this.buttonWorking.Name = "buttonWorking";
            this.buttonWorking.Size = new System.Drawing.Size(75, 23);
            this.buttonWorking.TabIndex = 26;
            this.buttonWorking.Text = "工作中";
            this.buttonWorking.UseVisualStyleBackColor = true;
            this.buttonWorking.Click += new System.EventHandler(this.buttonWorking_Click);
            // 
            // buttonDone
            // 
            this.buttonDone.Location = new System.Drawing.Point(217, 442);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(75, 23);
            this.buttonDone.TabIndex = 27;
            this.buttonDone.Text = "已完成";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // comboBoxOperateStatus
            // 
            this.comboBoxOperateStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperateStatus.FormattingEnabled = true;
            this.comboBoxOperateStatus.Location = new System.Drawing.Point(95, 371);
            this.comboBoxOperateStatus.Name = "comboBoxOperateStatus";
            this.comboBoxOperateStatus.Size = new System.Drawing.Size(91, 20);
            this.comboBoxOperateStatus.TabIndex = 22;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(24, 374);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 21;
            this.label20.Text = "状    态：";
            // 
            // richTextBoxOperateMemo
            // 
            this.richTextBoxOperateMemo.Location = new System.Drawing.Point(95, 292);
            this.richTextBoxOperateMemo.Name = "richTextBoxOperateMemo";
            this.richTextBoxOperateMemo.Size = new System.Drawing.Size(200, 73);
            this.richTextBoxOperateMemo.TabIndex = 20;
            this.richTextBoxOperateMemo.Text = "";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(24, 292);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 12);
            this.label19.TabIndex = 19;
            this.label19.Text = "备    注：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(278, 163);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 12);
            this.label18.TabIndex = 14;
            this.label18.Text = "天";
            // 
            // numericUpDownOperatePlannedDays
            // 
            this.numericUpDownOperatePlannedDays.DecimalPlaces = 2;
            this.numericUpDownOperatePlannedDays.Location = new System.Drawing.Point(211, 159);
            this.numericUpDownOperatePlannedDays.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            0});
            this.numericUpDownOperatePlannedDays.Name = "numericUpDownOperatePlannedDays";
            this.numericUpDownOperatePlannedDays.Size = new System.Drawing.Size(65, 21);
            this.numericUpDownOperatePlannedDays.TabIndex = 13;
            this.numericUpDownOperatePlannedDays.ValueChanged += new System.EventHandler(this.numericUpDownOperatePlannedTime_ValueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(161, 163);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 12);
            this.label17.TabIndex = 12;
            this.label17.Text = "小时 或";
            // 
            // numericUpDownOperatePlannedHours
            // 
            this.numericUpDownOperatePlannedHours.DecimalPlaces = 2;
            this.numericUpDownOperatePlannedHours.Location = new System.Drawing.Point(95, 159);
            this.numericUpDownOperatePlannedHours.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            0});
            this.numericUpDownOperatePlannedHours.Name = "numericUpDownOperatePlannedHours";
            this.numericUpDownOperatePlannedHours.Size = new System.Drawing.Size(65, 21);
            this.numericUpDownOperatePlannedHours.TabIndex = 11;
            this.numericUpDownOperatePlannedHours.ValueChanged += new System.EventHandler(this.numericUpDownOperatePlannedTime_ValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(24, 163);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 10;
            this.label16.Text = "计划时长：";
            // 
            // textBoxOperateTitle
            // 
            this.textBoxOperateTitle.Location = new System.Drawing.Point(95, 186);
            this.textBoxOperateTitle.Name = "textBoxOperateTitle";
            this.textBoxOperateTitle.Size = new System.Drawing.Size(200, 21);
            this.textBoxOperateTitle.TabIndex = 16;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(24, 189);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 15;
            this.label15.Text = "标    题：";
            // 
            // dateTimePickerOperatePlannedEndTime
            // 
            this.dateTimePickerOperatePlannedEndTime.CustomFormat = "yyyy年MM月dd日 HH时mm分";
            this.dateTimePickerOperatePlannedEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerOperatePlannedEndTime.Location = new System.Drawing.Point(95, 132);
            this.dateTimePickerOperatePlannedEndTime.Name = "dateTimePickerOperatePlannedEndTime";
            this.dateTimePickerOperatePlannedEndTime.ShowCheckBox = true;
            this.dateTimePickerOperatePlannedEndTime.Size = new System.Drawing.Size(200, 21);
            this.dateTimePickerOperatePlannedEndTime.TabIndex = 9;
            this.dateTimePickerOperatePlannedEndTime.ValueChanged += new System.EventHandler(this.dateTimePickerOperatePlannedTime_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(74, 138);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 12);
            this.label14.TabIndex = 8;
            this.label14.Text = "～";
            // 
            // comboBoxOperateSeverity
            // 
            this.comboBoxOperateSeverity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperateSeverity.FormattingEnabled = true;
            this.comboBoxOperateSeverity.Location = new System.Drawing.Point(95, 79);
            this.comboBoxOperateSeverity.Name = "comboBoxOperateSeverity";
            this.comboBoxOperateSeverity.Size = new System.Drawing.Size(91, 20);
            this.comboBoxOperateSeverity.TabIndex = 5;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 82);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 4;
            this.label13.Text = "严 重 度：";
            // 
            // comboBoxOperatePriority
            // 
            this.comboBoxOperatePriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperatePriority.FormattingEnabled = true;
            this.comboBoxOperatePriority.Location = new System.Drawing.Point(95, 53);
            this.comboBoxOperatePriority.Name = "comboBoxOperatePriority";
            this.comboBoxOperatePriority.Size = new System.Drawing.Size(91, 20);
            this.comboBoxOperatePriority.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 2;
            this.label12.Text = "优 先 级：";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(217, 413);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 25;
            this.buttonDelete.Text = "删除";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(163, 505);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(75, 23);
            this.buttonExport.TabIndex = 28;
            this.buttonExport.Text = "导出";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Visible = false;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(136, 413);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 24;
            this.buttonEdit.Text = "修改";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(55, 413);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 23;
            this.buttonAdd.Text = "新增";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // richTextBoxOperateContent
            // 
            this.richTextBoxOperateContent.Location = new System.Drawing.Point(95, 213);
            this.richTextBoxOperateContent.Name = "richTextBoxOperateContent";
            this.richTextBoxOperateContent.Size = new System.Drawing.Size(200, 73);
            this.richTextBoxOperateContent.TabIndex = 18;
            this.richTextBoxOperateContent.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 213);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "内    容：";
            // 
            // dateTimePickerOperatePlannedStartTime
            // 
            this.dateTimePickerOperatePlannedStartTime.CustomFormat = "yyyy年MM月dd日 HH时mm分";
            this.dateTimePickerOperatePlannedStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerOperatePlannedStartTime.Location = new System.Drawing.Point(95, 105);
            this.dateTimePickerOperatePlannedStartTime.Name = "dateTimePickerOperatePlannedStartTime";
            this.dateTimePickerOperatePlannedStartTime.ShowCheckBox = true;
            this.dateTimePickerOperatePlannedStartTime.Size = new System.Drawing.Size(200, 21);
            this.dateTimePickerOperatePlannedStartTime.TabIndex = 7;
            this.dateTimePickerOperatePlannedStartTime.ValueChanged += new System.EventHandler(this.dateTimePickerOperatePlannedTime_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 109);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 6;
            this.label10.Text = "计划时间：";
            // 
            // comboBoxOperateProject
            // 
            this.comboBoxOperateProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperateProject.FormattingEnabled = true;
            this.comboBoxOperateProject.Location = new System.Drawing.Point(95, 27);
            this.comboBoxOperateProject.Name = "comboBoxOperateProject";
            this.comboBoxOperateProject.Size = new System.Drawing.Size(140, 20);
            this.comboBoxOperateProject.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "项    目：";
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
            // ColumnTitle
            // 
            this.ColumnTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnTitle.HeaderText = "标题";
            this.ColumnTitle.MinimumWidth = 150;
            this.ColumnTitle.Name = "ColumnTitle";
            this.ColumnTitle.ReadOnly = true;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 647);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "待办事项";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewToDoList)).EndInit();
            this.groupBoxDataOperation.ResumeLayout(false);
            this.groupBoxDataOperation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOperatePlannedDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOperatePlannedHours)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
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
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.RichTextBox richTextBoxOperateContent;
        private System.Windows.Forms.Label label9;
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
        private System.Windows.Forms.RichTextBox richTextBoxOperateMemo;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox comboBoxOperateStatus;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button buttonWorking;
        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.ToolTip toolTipInfo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelHideInfo;
        private System.Windows.Forms.DataGridView dataGridViewToDoList;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnDone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProject;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPriority;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSeverity;
    }
}