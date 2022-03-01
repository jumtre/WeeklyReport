namespace WRManagement
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dataGridViewShow = new System.Windows.Forms.DataGridView();
            this.ColumnSortNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.comboBoxProject = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxMemo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxItemName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDict = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.radioButtonTileExit = new System.Windows.Forms.RadioButton();
            this.radioButtonTileHide = new System.Windows.Forms.RadioButton();
            this.radioButtonTileNoCommand = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonSetReminderTile = new System.Windows.Forms.Button();
            this.checkBoxReminderTileAutoStartup = new System.Windows.Forms.CheckBox();
            this.checkBoxTodoListAutoStartup = new System.Windows.Forms.CheckBox();
            this.checkBoxWeeklyReportAutoStartup = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBoxApplyCurrentProjectAndBranchToSearch = new System.Windows.Forms.CheckBox();
            this.comboBoxCurrentBranch = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonSetCurrentProjectAndBranch = new System.Windows.Forms.Button();
            this.comboBoxCurrentProject = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonBackup = new System.Windows.Forms.Button();
            this.checkBoxBackupConfigFile = new System.Windows.Forms.CheckBox();
            this.checkBoxBackupDatabase = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSetCurrentUser = new System.Windows.Forms.Button();
            this.comboBoxCurrentUser = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShow)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewShow
            // 
            this.dataGridViewShow.AllowUserToAddRows = false;
            this.dataGridViewShow.AllowUserToDeleteRows = false;
            this.dataGridViewShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSortNo,
            this.ColumnID,
            this.ColumnName,
            this.ColumnProjectName,
            this.ColumnMemo});
            this.dataGridViewShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewShow.Location = new System.Drawing.Point(3, 17);
            this.dataGridViewShow.MultiSelect = false;
            this.dataGridViewShow.Name = "dataGridViewShow";
            this.dataGridViewShow.ReadOnly = true;
            this.dataGridViewShow.RowHeadersVisible = false;
            this.dataGridViewShow.RowTemplate.Height = 23;
            this.dataGridViewShow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewShow.Size = new System.Drawing.Size(604, 223);
            this.dataGridViewShow.TabIndex = 1;
            this.dataGridViewShow.SelectionChanged += new System.EventHandler(this.dataGridViewShow_SelectionChanged);
            // 
            // ColumnSortNo
            // 
            this.ColumnSortNo.HeaderText = "序号";
            this.ColumnSortNo.Name = "ColumnSortNo";
            this.ColumnSortNo.ReadOnly = true;
            this.ColumnSortNo.Width = 60;
            // 
            // ColumnID
            // 
            this.ColumnID.HeaderText = "ID";
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            this.ColumnID.Width = 60;
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnName.HeaderText = "名称";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // ColumnProjectName
            // 
            this.ColumnProjectName.HeaderText = "项目名称";
            this.ColumnProjectName.Name = "ColumnProjectName";
            this.ColumnProjectName.ReadOnly = true;
            this.ColumnProjectName.Width = 120;
            // 
            // ColumnMemo
            // 
            this.ColumnMemo.HeaderText = "备注";
            this.ColumnMemo.Name = "ColumnMemo";
            this.ColumnMemo.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewShow);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(5, 356);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(610, 243);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "显示";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(339, 179);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "删除";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(217, 179);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Text = "修改";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(84, 179);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "新增";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "名称：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.buttonDelete);
            this.groupBox2.Controls.Add(this.buttonEdit);
            this.groupBox2.Controls.Add(this.buttonAdd);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboBoxDict);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(5, 144);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(610, 212);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据/操作";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.comboBoxProject);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.textBoxMemo);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Location = new System.Drawing.Point(3, 96);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(604, 73);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "分支";
            // 
            // comboBoxProject
            // 
            this.comboBoxProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProject.FormattingEnabled = true;
            this.comboBoxProject.Location = new System.Drawing.Point(53, 14);
            this.comboBoxProject.Name = "comboBoxProject";
            this.comboBoxProject.Size = new System.Drawing.Size(140, 20);
            this.comboBoxProject.TabIndex = 1;
            this.comboBoxProject.SelectedIndexChanged += new System.EventHandler(this.comboBoxProject_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "项目：";
            // 
            // textBoxMemo
            // 
            this.textBoxMemo.Location = new System.Drawing.Point(53, 43);
            this.textBoxMemo.Name = "textBoxMemo";
            this.textBoxMemo.Size = new System.Drawing.Size(428, 21);
            this.textBoxMemo.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "备注：";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.textBoxItemName);
            this.groupBox4.Location = new System.Drawing.Point(3, 52);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(604, 44);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "用户/项目/分支";
            // 
            // textBoxItemName
            // 
            this.textBoxItemName.Location = new System.Drawing.Point(53, 17);
            this.textBoxItemName.Name = "textBoxItemName";
            this.textBoxItemName.Size = new System.Drawing.Size(428, 21);
            this.textBoxItemName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "字典：";
            // 
            // comboBoxDict
            // 
            this.comboBoxDict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDict.FormattingEnabled = true;
            this.comboBoxDict.Location = new System.Drawing.Point(56, 23);
            this.comboBoxDict.Name = "comboBoxDict";
            this.comboBoxDict.Size = new System.Drawing.Size(137, 20);
            this.comboBoxDict.TabIndex = 1;
            this.comboBoxDict.SelectedIndexChanged += new System.EventHandler(this.comboBoxDict_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.radioButtonTileExit);
            this.groupBox1.Controls.Add(this.radioButtonTileHide);
            this.groupBox1.Controls.Add(this.radioButtonTileNoCommand);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.buttonSetReminderTile);
            this.groupBox1.Controls.Add(this.checkBoxReminderTileAutoStartup);
            this.groupBox1.Controls.Add(this.checkBoxTodoListAutoStartup);
            this.groupBox1.Controls.Add(this.checkBoxWeeklyReportAutoStartup);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.checkBoxApplyCurrentProjectAndBranchToSearch);
            this.groupBox1.Controls.Add(this.comboBoxCurrentBranch);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.buttonSetCurrentProjectAndBranch);
            this.groupBox1.Controls.Add(this.comboBoxCurrentProject);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.buttonBackup);
            this.groupBox1.Controls.Add(this.checkBoxBackupConfigFile);
            this.groupBox1.Controls.Add(this.checkBoxBackupDatabase);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.buttonSetCurrentUser);
            this.groupBox1.Controls.Add(this.comboBoxCurrentUser);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 139);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "功能";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.DimGray;
            this.label11.Location = new System.Drawing.Point(92, 114);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(173, 12);
            this.label11.TabIndex = 20;
            this.label11.Text = "弹出窗体设置，关闭时保存设置";
            // 
            // radioButtonTileExit
            // 
            this.radioButtonTileExit.AutoSize = true;
            this.radioButtonTileExit.Location = new System.Drawing.Point(543, 113);
            this.radioButtonTileExit.Name = "radioButtonTileExit";
            this.radioButtonTileExit.Size = new System.Drawing.Size(47, 16);
            this.radioButtonTileExit.TabIndex = 24;
            this.radioButtonTileExit.TabStop = true;
            this.radioButtonTileExit.Text = "退出";
            this.radioButtonTileExit.UseVisualStyleBackColor = true;
            this.radioButtonTileExit.CheckedChanged += new System.EventHandler(this.radioButtonTileCommand_CheckedChanged);
            // 
            // radioButtonTileHide
            // 
            this.radioButtonTileHide.AutoSize = true;
            this.radioButtonTileHide.Location = new System.Drawing.Point(481, 113);
            this.radioButtonTileHide.Name = "radioButtonTileHide";
            this.radioButtonTileHide.Size = new System.Drawing.Size(47, 16);
            this.radioButtonTileHide.TabIndex = 23;
            this.radioButtonTileHide.TabStop = true;
            this.radioButtonTileHide.Text = "隐藏";
            this.radioButtonTileHide.UseVisualStyleBackColor = true;
            this.radioButtonTileHide.CheckedChanged += new System.EventHandler(this.radioButtonTileCommand_CheckedChanged);
            // 
            // radioButtonTileNoCommand
            // 
            this.radioButtonTileNoCommand.AutoSize = true;
            this.radioButtonTileNoCommand.Location = new System.Drawing.Point(410, 113);
            this.radioButtonTileNoCommand.Name = "radioButtonTileNoCommand";
            this.radioButtonTileNoCommand.Size = new System.Drawing.Size(59, 16);
            this.radioButtonTileNoCommand.TabIndex = 22;
            this.radioButtonTileNoCommand.TabStop = true;
            this.radioButtonTileNoCommand.Text = "无操作";
            this.radioButtonTileNoCommand.UseVisualStyleBackColor = true;
            this.radioButtonTileNoCommand.CheckedChanged += new System.EventHandler(this.radioButtonTileCommand_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(292, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 12);
            this.label10.TabIndex = 21;
            this.label10.Text = "启动磁贴无数据时：";
            // 
            // buttonSetReminderTile
            // 
            this.buttonSetReminderTile.Location = new System.Drawing.Point(11, 109);
            this.buttonSetReminderTile.Name = "buttonSetReminderTile";
            this.buttonSetReminderTile.Size = new System.Drawing.Size(75, 23);
            this.buttonSetReminderTile.TabIndex = 19;
            this.buttonSetReminderTile.Text = "磁贴设置";
            this.buttonSetReminderTile.UseVisualStyleBackColor = true;
            this.buttonSetReminderTile.Click += new System.EventHandler(this.buttonSetReminderTile_Click);
            // 
            // checkBoxReminderTileAutoStartup
            // 
            this.checkBoxReminderTileAutoStartup.AutoSize = true;
            this.checkBoxReminderTileAutoStartup.Location = new System.Drawing.Point(519, 87);
            this.checkBoxReminderTileAutoStartup.Name = "checkBoxReminderTileAutoStartup";
            this.checkBoxReminderTileAutoStartup.Size = new System.Drawing.Size(72, 16);
            this.checkBoxReminderTileAutoStartup.TabIndex = 18;
            this.checkBoxReminderTileAutoStartup.Text = "提醒磁贴";
            this.checkBoxReminderTileAutoStartup.UseVisualStyleBackColor = true;
            this.checkBoxReminderTileAutoStartup.CheckedChanged += new System.EventHandler(this.checkBoxReminderTileAutoStartup_CheckedChanged);
            // 
            // checkBoxTodoListAutoStartup
            // 
            this.checkBoxTodoListAutoStartup.AutoSize = true;
            this.checkBoxTodoListAutoStartup.Location = new System.Drawing.Point(445, 87);
            this.checkBoxTodoListAutoStartup.Name = "checkBoxTodoListAutoStartup";
            this.checkBoxTodoListAutoStartup.Size = new System.Drawing.Size(72, 16);
            this.checkBoxTodoListAutoStartup.TabIndex = 17;
            this.checkBoxTodoListAutoStartup.Text = "待办事项";
            this.checkBoxTodoListAutoStartup.UseVisualStyleBackColor = true;
            this.checkBoxTodoListAutoStartup.CheckedChanged += new System.EventHandler(this.checkBoxTodoListAutoStartup_CheckedChanged);
            // 
            // checkBoxWeeklyReportAutoStartup
            // 
            this.checkBoxWeeklyReportAutoStartup.AutoSize = true;
            this.checkBoxWeeklyReportAutoStartup.Location = new System.Drawing.Point(371, 87);
            this.checkBoxWeeklyReportAutoStartup.Name = "checkBoxWeeklyReportAutoStartup";
            this.checkBoxWeeklyReportAutoStartup.Size = new System.Drawing.Size(72, 16);
            this.checkBoxWeeklyReportAutoStartup.TabIndex = 16;
            this.checkBoxWeeklyReportAutoStartup.Text = "个人周报";
            this.checkBoxWeeklyReportAutoStartup.UseVisualStyleBackColor = true;
            this.checkBoxWeeklyReportAutoStartup.CheckedChanged += new System.EventHandler(this.checkBoxWeeklyReportAutoStartup_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(292, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "随系统启动：";
            // 
            // checkBoxApplyCurrentProjectAndBranchToSearch
            // 
            this.checkBoxApplyCurrentProjectAndBranchToSearch.AutoSize = true;
            this.checkBoxApplyCurrentProjectAndBranchToSearch.Location = new System.Drawing.Point(436, 56);
            this.checkBoxApplyCurrentProjectAndBranchToSearch.Name = "checkBoxApplyCurrentProjectAndBranchToSearch";
            this.checkBoxApplyCurrentProjectAndBranchToSearch.Size = new System.Drawing.Size(84, 16);
            this.checkBoxApplyCurrentProjectAndBranchToSearch.TabIndex = 9;
            this.checkBoxApplyCurrentProjectAndBranchToSearch.Text = "应用到查询";
            this.checkBoxApplyCurrentProjectAndBranchToSearch.UseVisualStyleBackColor = true;
            // 
            // comboBoxCurrentBranch
            // 
            this.comboBoxCurrentBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCurrentBranch.FormattingEnabled = true;
            this.comboBoxCurrentBranch.Location = new System.Drawing.Point(294, 54);
            this.comboBoxCurrentBranch.Name = "comboBoxCurrentBranch";
            this.comboBoxCurrentBranch.Size = new System.Drawing.Size(128, 20);
            this.comboBoxCurrentBranch.TabIndex = 8;
            this.comboBoxCurrentBranch.SelectedIndexChanged += new System.EventHandler(this.comboBoxCurrentBranch_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(247, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "分支：";
            // 
            // buttonSetCurrentProjectAndBranch
            // 
            this.buttonSetCurrentProjectAndBranch.Location = new System.Drawing.Point(530, 52);
            this.buttonSetCurrentProjectAndBranch.Name = "buttonSetCurrentProjectAndBranch";
            this.buttonSetCurrentProjectAndBranch.Size = new System.Drawing.Size(56, 23);
            this.buttonSetCurrentProjectAndBranch.TabIndex = 10;
            this.buttonSetCurrentProjectAndBranch.Text = "设置";
            this.buttonSetCurrentProjectAndBranch.UseVisualStyleBackColor = true;
            this.buttonSetCurrentProjectAndBranch.Click += new System.EventHandler(this.buttonSetCurrentProjectAndBranch_Click);
            // 
            // comboBoxCurrentProject
            // 
            this.comboBoxCurrentProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCurrentProject.FormattingEnabled = true;
            this.comboBoxCurrentProject.Location = new System.Drawing.Point(80, 54);
            this.comboBoxCurrentProject.Name = "comboBoxCurrentProject";
            this.comboBoxCurrentProject.Size = new System.Drawing.Size(160, 20);
            this.comboBoxCurrentProject.TabIndex = 6;
            this.comboBoxCurrentProject.SelectedIndexChanged += new System.EventHandler(this.comboBoxCurrentProject_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "当前项目：";
            // 
            // buttonBackup
            // 
            this.buttonBackup.Location = new System.Drawing.Point(205, 83);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Size = new System.Drawing.Size(56, 23);
            this.buttonBackup.TabIndex = 14;
            this.buttonBackup.Text = "备份";
            this.buttonBackup.UseVisualStyleBackColor = true;
            this.buttonBackup.Click += new System.EventHandler(this.buttonBackup_Click);
            // 
            // checkBoxBackupConfigFile
            // 
            this.checkBoxBackupConfigFile.AutoSize = true;
            this.checkBoxBackupConfigFile.Checked = true;
            this.checkBoxBackupConfigFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBackupConfigFile.Location = new System.Drawing.Point(122, 87);
            this.checkBoxBackupConfigFile.Name = "checkBoxBackupConfigFile";
            this.checkBoxBackupConfigFile.Size = new System.Drawing.Size(72, 16);
            this.checkBoxBackupConfigFile.TabIndex = 13;
            this.checkBoxBackupConfigFile.Text = "配置文件";
            this.checkBoxBackupConfigFile.UseVisualStyleBackColor = true;
            // 
            // checkBoxBackupDatabase
            // 
            this.checkBoxBackupDatabase.AutoSize = true;
            this.checkBoxBackupDatabase.Checked = true;
            this.checkBoxBackupDatabase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBackupDatabase.Location = new System.Drawing.Point(56, 87);
            this.checkBoxBackupDatabase.Name = "checkBoxBackupDatabase";
            this.checkBoxBackupDatabase.Size = new System.Drawing.Size(60, 16);
            this.checkBoxBackupDatabase.TabIndex = 12;
            this.checkBoxBackupDatabase.Text = "数据库";
            this.checkBoxBackupDatabase.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "备份：";
            // 
            // buttonSetCurrentUser
            // 
            this.buttonSetCurrentUser.Location = new System.Drawing.Point(205, 19);
            this.buttonSetCurrentUser.Name = "buttonSetCurrentUser";
            this.buttonSetCurrentUser.Size = new System.Drawing.Size(56, 23);
            this.buttonSetCurrentUser.TabIndex = 4;
            this.buttonSetCurrentUser.Text = "设置";
            this.buttonSetCurrentUser.UseVisualStyleBackColor = true;
            this.buttonSetCurrentUser.Click += new System.EventHandler(this.buttonSetCurrentUser_Click);
            // 
            // comboBoxCurrentUser
            // 
            this.comboBoxCurrentUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCurrentUser.FormattingEnabled = true;
            this.comboBoxCurrentUser.Location = new System.Drawing.Point(80, 20);
            this.comboBoxCurrentUser.Name = "comboBoxCurrentUser";
            this.comboBoxCurrentUser.Size = new System.Drawing.Size(119, 20);
            this.comboBoxCurrentUser.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "当前用户：";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 604);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "管理程序";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShow)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewShow;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxDict;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSetCurrentUser;
        private System.Windows.Forms.ComboBox comboBoxCurrentUser;
        private System.Windows.Forms.TextBox textBoxItemName;
        private System.Windows.Forms.CheckBox checkBoxBackupConfigFile;
        private System.Windows.Forms.CheckBox checkBoxBackupDatabase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonBackup;
        private System.Windows.Forms.TextBox textBoxMemo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox comboBoxProject;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSortNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
        private System.Windows.Forms.Button buttonSetCurrentProjectAndBranch;
        private System.Windows.Forms.ComboBox comboBoxCurrentProject;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxCurrentBranch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBoxApplyCurrentProjectAndBranchToSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBoxTodoListAutoStartup;
        private System.Windows.Forms.CheckBox checkBoxWeeklyReportAutoStartup;
        private System.Windows.Forms.CheckBox checkBoxReminderTileAutoStartup;
        private System.Windows.Forms.Button buttonSetReminderTile;
        private System.Windows.Forms.RadioButton radioButtonTileExit;
        private System.Windows.Forms.RadioButton radioButtonTileHide;
        private System.Windows.Forms.RadioButton radioButtonTileNoCommand;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}

