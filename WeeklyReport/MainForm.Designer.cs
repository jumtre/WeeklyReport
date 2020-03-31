namespace WeeklyReport
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonLastWeek = new System.Windows.Forms.Button();
            this.comboBoxSearchBranch = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxKeyWord = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.comboBoxSearchProject = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerSearchTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerSearchFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxOperateBranch = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonDateTimeNow = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.richTextBoxOperateContent = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePickerOperateFinishTime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxOperateProject = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewShow = new System.Windows.Forms.DataGridView();
            this.ColumnSortNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFinishTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonThisWeek = new System.Windows.Forms.Button();
            this.textBoxOperateRelatedID = new System.Windows.Forms.TextBox();
            this.textBoxSearchRelatedID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShow)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxSearchRelatedID);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.buttonThisWeek);
            this.groupBox1.Controls.Add(this.buttonLastWeek);
            this.groupBox1.Controls.Add(this.comboBoxSearchBranch);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBoxKeyWord);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.buttonSearch);
            this.groupBox1.Controls.Add(this.comboBoxSearchProject);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTimePickerSearchTo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePickerSearchFrom);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(722, 120);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // buttonLastWeek
            // 
            this.buttonLastWeek.Location = new System.Drawing.Point(382, 24);
            this.buttonLastWeek.Name = "buttonLastWeek";
            this.buttonLastWeek.Size = new System.Drawing.Size(43, 23);
            this.buttonLastWeek.TabIndex = 4;
            this.buttonLastWeek.Text = "上周";
            this.buttonLastWeek.UseVisualStyleBackColor = true;
            this.buttonLastWeek.Click += new System.EventHandler(this.buttonLastWeek_Click);
            // 
            // comboBoxSearchBranch
            // 
            this.comboBoxSearchBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchBranch.FormattingEnabled = true;
            this.comboBoxSearchBranch.Location = new System.Drawing.Point(313, 55);
            this.comboBoxSearchBranch.Name = "comboBoxSearchBranch";
            this.comboBoxSearchBranch.Size = new System.Drawing.Size(160, 20);
            this.comboBoxSearchBranch.TabIndex = 9;
            this.comboBoxSearchBranch.SelectedIndexChanged += new System.EventHandler(this.comboBoxSearchBranch_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(254, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "分  支：";
            // 
            // textBoxKeyWord
            // 
            this.textBoxKeyWord.Location = new System.Drawing.Point(71, 81);
            this.textBoxKeyWord.Name = "textBoxKeyWord";
            this.textBoxKeyWord.Size = new System.Drawing.Size(280, 21);
            this.textBoxKeyWord.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "关键字：";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(501, 25);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(93, 77);
            this.buttonSearch.TabIndex = 14;
            this.buttonSearch.Text = "查  询";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // comboBoxSearchProject
            // 
            this.comboBoxSearchProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchProject.FormattingEnabled = true;
            this.comboBoxSearchProject.Location = new System.Drawing.Point(71, 55);
            this.comboBoxSearchProject.Name = "comboBoxSearchProject";
            this.comboBoxSearchProject.Size = new System.Drawing.Size(160, 20);
            this.comboBoxSearchProject.TabIndex = 7;
            this.comboBoxSearchProject.SelectedIndexChanged += new System.EventHandler(this.comboBoxSearchProject_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "项  目：";
            // 
            // dateTimePickerSearchTo
            // 
            this.dateTimePickerSearchTo.Location = new System.Drawing.Point(235, 25);
            this.dateTimePickerSearchTo.Name = "dateTimePickerSearchTo";
            this.dateTimePickerSearchTo.ShowCheckBox = true;
            this.dateTimePickerSearchTo.Size = new System.Drawing.Size(140, 21);
            this.dateTimePickerSearchTo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "～";
            // 
            // dateTimePickerSearchFrom
            // 
            this.dateTimePickerSearchFrom.Location = new System.Drawing.Point(71, 25);
            this.dateTimePickerSearchFrom.Name = "dateTimePickerSearchFrom";
            this.dateTimePickerSearchFrom.ShowCheckBox = true;
            this.dateTimePickerSearchFrom.Size = new System.Drawing.Size(140, 21);
            this.dateTimePickerSearchFrom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "日  期：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxOperateRelatedID);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.comboBoxOperateBranch);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.buttonDateTimeNow);
            this.groupBox2.Controls.Add(this.buttonDelete);
            this.groupBox2.Controls.Add(this.buttonExport);
            this.groupBox2.Controls.Add(this.buttonEdit);
            this.groupBox2.Controls.Add(this.buttonAdd);
            this.groupBox2.Controls.Add(this.richTextBoxOperateContent);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dateTimePickerOperateFinishTime);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.comboBoxOperateProject);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(5, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(722, 195);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据/操作";
            // 
            // comboBoxOperateBranch
            // 
            this.comboBoxOperateBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperateBranch.FormattingEnabled = true;
            this.comboBoxOperateBranch.Location = new System.Drawing.Point(313, 27);
            this.comboBoxOperateBranch.Name = "comboBoxOperateBranch";
            this.comboBoxOperateBranch.Size = new System.Drawing.Size(160, 20);
            this.comboBoxOperateBranch.TabIndex = 3;
            this.comboBoxOperateBranch.SelectedIndexChanged += new System.EventHandler(this.comboBoxOperateBranch_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(254, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "分  支：";
            // 
            // buttonDateTimeNow
            // 
            this.buttonDateTimeNow.Location = new System.Drawing.Point(276, 56);
            this.buttonDateTimeNow.Name = "buttonDateTimeNow";
            this.buttonDateTimeNow.Size = new System.Drawing.Size(75, 23);
            this.buttonDateTimeNow.TabIndex = 6;
            this.buttonDateTimeNow.Text = "当前时间";
            this.buttonDateTimeNow.UseVisualStyleBackColor = true;
            this.buttonDateTimeNow.Click += new System.EventHandler(this.buttonDateTimeNow_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(627, 112);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 33);
            this.buttonDelete.TabIndex = 11;
            this.buttonDelete.Text = "删除";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(627, 154);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(75, 33);
            this.buttonExport.TabIndex = 12;
            this.buttonExport.Text = "导出";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(627, 70);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 33);
            this.buttonEdit.TabIndex = 10;
            this.buttonEdit.Text = "修改";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(627, 26);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 33);
            this.buttonAdd.TabIndex = 9;
            this.buttonAdd.Text = "新增";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // richTextBoxOperateContent
            // 
            this.richTextBoxOperateContent.Location = new System.Drawing.Point(71, 87);
            this.richTextBoxOperateContent.Name = "richTextBoxOperateContent";
            this.richTextBoxOperateContent.Size = new System.Drawing.Size(521, 100);
            this.richTextBoxOperateContent.TabIndex = 8;
            this.richTextBoxOperateContent.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "内  容：";
            // 
            // dateTimePickerOperateFinishTime
            // 
            this.dateTimePickerOperateFinishTime.CustomFormat = "yyyy年MM月dd日 HH时mm分";
            this.dateTimePickerOperateFinishTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerOperateFinishTime.Location = new System.Drawing.Point(71, 57);
            this.dateTimePickerOperateFinishTime.Name = "dateTimePickerOperateFinishTime";
            this.dateTimePickerOperateFinishTime.ShowCheckBox = true;
            this.dateTimePickerOperateFinishTime.Size = new System.Drawing.Size(200, 21);
            this.dateTimePickerOperateFinishTime.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "时  间：";
            // 
            // comboBoxOperateProject
            // 
            this.comboBoxOperateProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperateProject.FormattingEnabled = true;
            this.comboBoxOperateProject.Location = new System.Drawing.Point(71, 27);
            this.comboBoxOperateProject.Name = "comboBoxOperateProject";
            this.comboBoxOperateProject.Size = new System.Drawing.Size(160, 20);
            this.comboBoxOperateProject.TabIndex = 1;
            this.comboBoxOperateProject.SelectedIndexChanged += new System.EventHandler(this.comboBoxOperateProject_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "项  目：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewShow);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(5, 320);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(722, 256);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "显示";
            // 
            // dataGridViewShow
            // 
            this.dataGridViewShow.AllowUserToAddRows = false;
            this.dataGridViewShow.AllowUserToDeleteRows = false;
            this.dataGridViewShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSortNo,
            this.ColumnProject,
            this.ColumnBranch,
            this.ColumnContent,
            this.ColumnFinishTime});
            this.dataGridViewShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewShow.Location = new System.Drawing.Point(3, 17);
            this.dataGridViewShow.MultiSelect = false;
            this.dataGridViewShow.Name = "dataGridViewShow";
            this.dataGridViewShow.ReadOnly = true;
            this.dataGridViewShow.RowHeadersVisible = false;
            this.dataGridViewShow.RowTemplate.Height = 23;
            this.dataGridViewShow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewShow.Size = new System.Drawing.Size(716, 236);
            this.dataGridViewShow.TabIndex = 1;
            this.dataGridViewShow.SelectionChanged += new System.EventHandler(this.dataGridViewShow_SelectionChanged);
            // 
            // ColumnSortNo
            // 
            this.ColumnSortNo.HeaderText = "序号";
            this.ColumnSortNo.Name = "ColumnSortNo";
            this.ColumnSortNo.ReadOnly = true;
            this.ColumnSortNo.Width = 40;
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
            // ColumnContent
            // 
            this.ColumnContent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnContent.HeaderText = "内容";
            this.ColumnContent.Name = "ColumnContent";
            this.ColumnContent.ReadOnly = true;
            // 
            // ColumnFinishTime
            // 
            this.ColumnFinishTime.HeaderText = "完成时间";
            this.ColumnFinishTime.Name = "ColumnFinishTime";
            this.ColumnFinishTime.ReadOnly = true;
            this.ColumnFinishTime.Width = 120;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(362, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 13;
            this.label10.Text = "关联ID：";
            // 
            // buttonThisWeek
            // 
            this.buttonThisWeek.Location = new System.Drawing.Point(431, 24);
            this.buttonThisWeek.Name = "buttonThisWeek";
            this.buttonThisWeek.Size = new System.Drawing.Size(43, 23);
            this.buttonThisWeek.TabIndex = 5;
            this.buttonThisWeek.Text = "本周";
            this.buttonThisWeek.UseVisualStyleBackColor = true;
            this.buttonThisWeek.Click += new System.EventHandler(this.buttonThisWeek_Click);
            // 
            // textBoxOperateRelatedID
            // 
            this.textBoxOperateRelatedID.Location = new System.Drawing.Point(413, 57);
            this.textBoxOperateRelatedID.Name = "textBoxOperateRelatedID";
            this.textBoxOperateRelatedID.Size = new System.Drawing.Size(60, 21);
            this.textBoxOperateRelatedID.TabIndex = 14;
            // 
            // textBoxSearchRelatedID
            // 
            this.textBoxSearchRelatedID.Location = new System.Drawing.Point(413, 81);
            this.textBoxSearchRelatedID.Name = "textBoxSearchRelatedID";
            this.textBoxSearchRelatedID.Size = new System.Drawing.Size(60, 21);
            this.textBoxSearchRelatedID.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(362, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 12;
            this.label11.Text = "关联ID：";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 581);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "个人周报";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerSearchFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerSearchTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxSearchProject;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxOperateProject;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerOperateFinishTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox richTextBoxOperateContent;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridViewShow;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonDateTimeNow;
        private System.Windows.Forms.TextBox textBoxKeyWord;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxOperateBranch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxSearchBranch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSortNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProject;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFinishTime;
        private System.Windows.Forms.Button buttonLastWeek;
        private System.Windows.Forms.Button buttonThisWeek;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxOperateRelatedID;
        private System.Windows.Forms.TextBox textBoxSearchRelatedID;
        private System.Windows.Forms.Label label11;
    }
}

