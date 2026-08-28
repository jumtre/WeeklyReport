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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.buttonBrowseWorkingDirectory = new System.Windows.Forms.Button();
            this.textBoxWorkingDirectory = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
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
            this.ColumnSortNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWorkingDirectory = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.ColumnMemo,
            this.ColumnWorkingDirectory});
            this.dataGridViewShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewShow.Location = new System.Drawing.Point(4, 22);
            this.dataGridViewShow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewShow.MultiSelect = false;
            this.dataGridViewShow.Name = "dataGridViewShow";
            this.dataGridViewShow.ReadOnly = true;
            this.dataGridViewShow.RowHeadersVisible = false;
            this.dataGridViewShow.RowHeadersWidth = 51;
            this.dataGridViewShow.RowTemplate.Height = 23;
            this.dataGridViewShow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewShow.Size = new System.Drawing.Size(805, 239);
            this.dataGridViewShow.TabIndex = 1;
            this.dataGridViewShow.SelectionChanged += new System.EventHandler(this.dataGridViewShow_SelectionChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewShow);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(7, 484);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(813, 265);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "显示";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(447, 268);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(100, 29);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "删除";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(284, 268);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(100, 29);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Text = "修改";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(107, 268);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(100, 29);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "新增";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
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
            this.groupBox2.Location = new System.Drawing.Point(7, 180);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(813, 304);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据/操作";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.buttonBrowseWorkingDirectory);
            this.groupBox5.Controls.Add(this.textBoxWorkingDirectory);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.comboBoxProject);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.textBoxMemo);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Location = new System.Drawing.Point(4, 120);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox5.Size = new System.Drawing.Size(805, 140);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "分支";
            // 
            // buttonBrowseWorkingDirectory
            // 
            this.buttonBrowseWorkingDirectory.Location = new System.Drawing.Point(649, 89);
            this.buttonBrowseWorkingDirectory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonBrowseWorkingDirectory.Name = "buttonBrowseWorkingDirectory";
            this.buttonBrowseWorkingDirectory.Size = new System.Drawing.Size(75, 29);
            this.buttonBrowseWorkingDirectory.TabIndex = 6;
            this.buttonBrowseWorkingDirectory.Text = "浏览";
            this.buttonBrowseWorkingDirectory.UseVisualStyleBackColor = true;
            this.buttonBrowseWorkingDirectory.Click += new System.EventHandler(this.buttonBrowseWorkingDirectory_Click);
            // 
            // textBoxWorkingDirectory
            // 
            this.textBoxWorkingDirectory.Location = new System.Drawing.Point(71, 90);
            this.textBoxWorkingDirectory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxWorkingDirectory.Name = "textBoxWorkingDirectory";
            this.textBoxWorkingDirectory.Size = new System.Drawing.Size(569, 25);
            this.textBoxWorkingDirectory.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 94);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 15);
            this.label12.TabIndex = 4;
            this.label12.Text = "目录：";
            // 
            // comboBoxProject
            // 
            this.comboBoxProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProject.FormattingEnabled = true;
            this.comboBoxProject.Location = new System.Drawing.Point(71, 18);
            this.comboBoxProject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxProject.Name = "comboBoxProject";
            this.comboBoxProject.Size = new System.Drawing.Size(185, 23);
            this.comboBoxProject.TabIndex = 1;
            this.comboBoxProject.SelectedIndexChanged += new System.EventHandler(this.comboBoxProject_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 21);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "项目：";
            // 
            // textBoxMemo
            // 
            this.textBoxMemo.Location = new System.Drawing.Point(71, 54);
            this.textBoxMemo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxMemo.Name = "textBoxMemo";
            this.textBoxMemo.Size = new System.Drawing.Size(569, 25);
            this.textBoxMemo.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 58);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "备注：";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.textBoxItemName);
            this.groupBox4.Location = new System.Drawing.Point(4, 65);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(805, 55);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "用户/项目/分支";
            // 
            // textBoxItemName
            // 
            this.textBoxItemName.Location = new System.Drawing.Point(71, 21);
            this.textBoxItemName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxItemName.Name = "textBoxItemName";
            this.textBoxItemName.Size = new System.Drawing.Size(569, 25);
            this.textBoxItemName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "字典：";
            // 
            // comboBoxDict
            // 
            this.comboBoxDict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDict.FormattingEnabled = true;
            this.comboBoxDict.Location = new System.Drawing.Point(75, 29);
            this.comboBoxDict.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxDict.Name = "comboBoxDict";
            this.comboBoxDict.Size = new System.Drawing.Size(181, 23);
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
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(813, 174);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "功能";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.DimGray;
            this.label11.Location = new System.Drawing.Point(123, 142);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(217, 15);
            this.label11.TabIndex = 20;
            this.label11.Text = "弹出窗体设置，关闭时保存设置";
            // 
            // radioButtonTileExit
            // 
            this.radioButtonTileExit.AutoSize = true;
            this.radioButtonTileExit.Location = new System.Drawing.Point(724, 141);
            this.radioButtonTileExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonTileExit.Name = "radioButtonTileExit";
            this.radioButtonTileExit.Size = new System.Drawing.Size(58, 19);
            this.radioButtonTileExit.TabIndex = 24;
            this.radioButtonTileExit.TabStop = true;
            this.radioButtonTileExit.Text = "退出";
            this.radioButtonTileExit.UseVisualStyleBackColor = true;
            this.radioButtonTileExit.CheckedChanged += new System.EventHandler(this.radioButtonTileCommand_CheckedChanged);
            // 
            // radioButtonTileHide
            // 
            this.radioButtonTileHide.AutoSize = true;
            this.radioButtonTileHide.Location = new System.Drawing.Point(641, 141);
            this.radioButtonTileHide.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonTileHide.Name = "radioButtonTileHide";
            this.radioButtonTileHide.Size = new System.Drawing.Size(58, 19);
            this.radioButtonTileHide.TabIndex = 23;
            this.radioButtonTileHide.TabStop = true;
            this.radioButtonTileHide.Text = "隐藏";
            this.radioButtonTileHide.UseVisualStyleBackColor = true;
            this.radioButtonTileHide.CheckedChanged += new System.EventHandler(this.radioButtonTileCommand_CheckedChanged);
            // 
            // radioButtonTileNoCommand
            // 
            this.radioButtonTileNoCommand.AutoSize = true;
            this.radioButtonTileNoCommand.Location = new System.Drawing.Point(547, 141);
            this.radioButtonTileNoCommand.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonTileNoCommand.Name = "radioButtonTileNoCommand";
            this.radioButtonTileNoCommand.Size = new System.Drawing.Size(73, 19);
            this.radioButtonTileNoCommand.TabIndex = 22;
            this.radioButtonTileNoCommand.TabStop = true;
            this.radioButtonTileNoCommand.Text = "无操作";
            this.radioButtonTileNoCommand.UseVisualStyleBackColor = true;
            this.radioButtonTileNoCommand.CheckedChanged += new System.EventHandler(this.radioButtonTileCommand_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(389, 142);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(142, 15);
            this.label10.TabIndex = 21;
            this.label10.Text = "启动磁贴无数据时：";
            // 
            // buttonSetReminderTile
            // 
            this.buttonSetReminderTile.Location = new System.Drawing.Point(15, 136);
            this.buttonSetReminderTile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSetReminderTile.Name = "buttonSetReminderTile";
            this.buttonSetReminderTile.Size = new System.Drawing.Size(100, 29);
            this.buttonSetReminderTile.TabIndex = 19;
            this.buttonSetReminderTile.Text = "磁贴设置";
            this.buttonSetReminderTile.UseVisualStyleBackColor = true;
            this.buttonSetReminderTile.Click += new System.EventHandler(this.buttonSetReminderTile_Click);
            // 
            // checkBoxReminderTileAutoStartup
            // 
            this.checkBoxReminderTileAutoStartup.AutoSize = true;
            this.checkBoxReminderTileAutoStartup.Location = new System.Drawing.Point(692, 109);
            this.checkBoxReminderTileAutoStartup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxReminderTileAutoStartup.Name = "checkBoxReminderTileAutoStartup";
            this.checkBoxReminderTileAutoStartup.Size = new System.Drawing.Size(89, 19);
            this.checkBoxReminderTileAutoStartup.TabIndex = 18;
            this.checkBoxReminderTileAutoStartup.Text = "提醒磁贴";
            this.checkBoxReminderTileAutoStartup.UseVisualStyleBackColor = true;
            this.checkBoxReminderTileAutoStartup.CheckedChanged += new System.EventHandler(this.checkBoxReminderTileAutoStartup_CheckedChanged);
            // 
            // checkBoxTodoListAutoStartup
            // 
            this.checkBoxTodoListAutoStartup.AutoSize = true;
            this.checkBoxTodoListAutoStartup.Location = new System.Drawing.Point(593, 109);
            this.checkBoxTodoListAutoStartup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxTodoListAutoStartup.Name = "checkBoxTodoListAutoStartup";
            this.checkBoxTodoListAutoStartup.Size = new System.Drawing.Size(89, 19);
            this.checkBoxTodoListAutoStartup.TabIndex = 17;
            this.checkBoxTodoListAutoStartup.Text = "待办事项";
            this.checkBoxTodoListAutoStartup.UseVisualStyleBackColor = true;
            this.checkBoxTodoListAutoStartup.CheckedChanged += new System.EventHandler(this.checkBoxTodoListAutoStartup_CheckedChanged);
            // 
            // checkBoxWeeklyReportAutoStartup
            // 
            this.checkBoxWeeklyReportAutoStartup.AutoSize = true;
            this.checkBoxWeeklyReportAutoStartup.Location = new System.Drawing.Point(495, 109);
            this.checkBoxWeeklyReportAutoStartup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxWeeklyReportAutoStartup.Name = "checkBoxWeeklyReportAutoStartup";
            this.checkBoxWeeklyReportAutoStartup.Size = new System.Drawing.Size(89, 19);
            this.checkBoxWeeklyReportAutoStartup.TabIndex = 16;
            this.checkBoxWeeklyReportAutoStartup.Text = "个人周报";
            this.checkBoxWeeklyReportAutoStartup.UseVisualStyleBackColor = true;
            this.checkBoxWeeklyReportAutoStartup.CheckedChanged += new System.EventHandler(this.checkBoxWeeklyReportAutoStartup_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(389, 110);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "随系统启动：";
            // 
            // checkBoxApplyCurrentProjectAndBranchToSearch
            // 
            this.checkBoxApplyCurrentProjectAndBranchToSearch.AutoSize = true;
            this.checkBoxApplyCurrentProjectAndBranchToSearch.Location = new System.Drawing.Point(581, 70);
            this.checkBoxApplyCurrentProjectAndBranchToSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxApplyCurrentProjectAndBranchToSearch.Name = "checkBoxApplyCurrentProjectAndBranchToSearch";
            this.checkBoxApplyCurrentProjectAndBranchToSearch.Size = new System.Drawing.Size(104, 19);
            this.checkBoxApplyCurrentProjectAndBranchToSearch.TabIndex = 9;
            this.checkBoxApplyCurrentProjectAndBranchToSearch.Text = "应用到查询";
            this.checkBoxApplyCurrentProjectAndBranchToSearch.UseVisualStyleBackColor = true;
            // 
            // comboBoxCurrentBranch
            // 
            this.comboBoxCurrentBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCurrentBranch.FormattingEnabled = true;
            this.comboBoxCurrentBranch.Location = new System.Drawing.Point(392, 68);
            this.comboBoxCurrentBranch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxCurrentBranch.Name = "comboBoxCurrentBranch";
            this.comboBoxCurrentBranch.Size = new System.Drawing.Size(169, 23);
            this.comboBoxCurrentBranch.TabIndex = 8;
            this.comboBoxCurrentBranch.SelectedIndexChanged += new System.EventHandler(this.comboBoxCurrentBranch_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(329, 71);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "分支：";
            // 
            // buttonSetCurrentProjectAndBranch
            // 
            this.buttonSetCurrentProjectAndBranch.Location = new System.Drawing.Point(707, 65);
            this.buttonSetCurrentProjectAndBranch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSetCurrentProjectAndBranch.Name = "buttonSetCurrentProjectAndBranch";
            this.buttonSetCurrentProjectAndBranch.Size = new System.Drawing.Size(75, 29);
            this.buttonSetCurrentProjectAndBranch.TabIndex = 10;
            this.buttonSetCurrentProjectAndBranch.Text = "设置";
            this.buttonSetCurrentProjectAndBranch.UseVisualStyleBackColor = true;
            this.buttonSetCurrentProjectAndBranch.Click += new System.EventHandler(this.buttonSetCurrentProjectAndBranch_Click);
            // 
            // comboBoxCurrentProject
            // 
            this.comboBoxCurrentProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCurrentProject.FormattingEnabled = true;
            this.comboBoxCurrentProject.Location = new System.Drawing.Point(107, 68);
            this.comboBoxCurrentProject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxCurrentProject.Name = "comboBoxCurrentProject";
            this.comboBoxCurrentProject.Size = new System.Drawing.Size(212, 23);
            this.comboBoxCurrentProject.TabIndex = 6;
            this.comboBoxCurrentProject.SelectedIndexChanged += new System.EventHandler(this.comboBoxCurrentProject_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 71);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "当前项目：";
            // 
            // buttonBackup
            // 
            this.buttonBackup.Location = new System.Drawing.Point(273, 104);
            this.buttonBackup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Size = new System.Drawing.Size(75, 29);
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
            this.checkBoxBackupConfigFile.Location = new System.Drawing.Point(163, 109);
            this.checkBoxBackupConfigFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxBackupConfigFile.Name = "checkBoxBackupConfigFile";
            this.checkBoxBackupConfigFile.Size = new System.Drawing.Size(89, 19);
            this.checkBoxBackupConfigFile.TabIndex = 13;
            this.checkBoxBackupConfigFile.Text = "配置文件";
            this.checkBoxBackupConfigFile.UseVisualStyleBackColor = true;
            // 
            // checkBoxBackupDatabase
            // 
            this.checkBoxBackupDatabase.AutoSize = true;
            this.checkBoxBackupDatabase.Checked = true;
            this.checkBoxBackupDatabase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBackupDatabase.Location = new System.Drawing.Point(75, 109);
            this.checkBoxBackupDatabase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxBackupDatabase.Name = "checkBoxBackupDatabase";
            this.checkBoxBackupDatabase.Size = new System.Drawing.Size(74, 19);
            this.checkBoxBackupDatabase.TabIndex = 12;
            this.checkBoxBackupDatabase.Text = "数据库";
            this.checkBoxBackupDatabase.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "备份：";
            // 
            // buttonSetCurrentUser
            // 
            this.buttonSetCurrentUser.Location = new System.Drawing.Point(273, 24);
            this.buttonSetCurrentUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSetCurrentUser.Name = "buttonSetCurrentUser";
            this.buttonSetCurrentUser.Size = new System.Drawing.Size(75, 29);
            this.buttonSetCurrentUser.TabIndex = 4;
            this.buttonSetCurrentUser.Text = "设置";
            this.buttonSetCurrentUser.UseVisualStyleBackColor = true;
            this.buttonSetCurrentUser.Click += new System.EventHandler(this.buttonSetCurrentUser_Click);
            // 
            // comboBoxCurrentUser
            // 
            this.comboBoxCurrentUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCurrentUser.FormattingEnabled = true;
            this.comboBoxCurrentUser.Location = new System.Drawing.Point(107, 25);
            this.comboBoxCurrentUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxCurrentUser.Name = "comboBoxCurrentUser";
            this.comboBoxCurrentUser.Size = new System.Drawing.Size(157, 23);
            this.comboBoxCurrentUser.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "当前用户：";
            // 
            // ColumnSortNo
            // 
            this.ColumnSortNo.HeaderText = "序号";
            this.ColumnSortNo.MinimumWidth = 6;
            this.ColumnSortNo.Name = "ColumnSortNo";
            this.ColumnSortNo.ReadOnly = true;
            this.ColumnSortNo.Width = 60;
            // 
            // ColumnID
            // 
            this.ColumnID.HeaderText = "ID";
            this.ColumnID.MinimumWidth = 6;
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            this.ColumnID.Width = 60;
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnName.HeaderText = "名称";
            this.ColumnName.MinimumWidth = 6;
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // ColumnProjectName
            // 
            this.ColumnProjectName.HeaderText = "项目名称";
            this.ColumnProjectName.MinimumWidth = 6;
            this.ColumnProjectName.Name = "ColumnProjectName";
            this.ColumnProjectName.ReadOnly = true;
            this.ColumnProjectName.Width = 160;
            // 
            // ColumnMemo
            // 
            this.ColumnMemo.HeaderText = "备注";
            this.ColumnMemo.MinimumWidth = 6;
            this.ColumnMemo.Name = "ColumnMemo";
            this.ColumnMemo.ReadOnly = true;
            this.ColumnMemo.Width = 160;
            // 
            // ColumnWorkingDirectory
            // 
            this.ColumnWorkingDirectory.HeaderText = "工作目录";
            this.ColumnWorkingDirectory.MinimumWidth = 6;
            this.ColumnWorkingDirectory.Name = "ColumnWorkingDirectory";
            this.ColumnWorkingDirectory.ReadOnly = true;
            this.ColumnWorkingDirectory.Width = 160;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 755);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
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
        private System.Windows.Forms.Button buttonBrowseWorkingDirectory;
        private System.Windows.Forms.TextBox textBoxWorkingDirectory;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSortNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWorkingDirectory;
    }
}

