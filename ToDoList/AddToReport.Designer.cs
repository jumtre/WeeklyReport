namespace ToDoList
{
    partial class AddToReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddToReport));
            this.buttonDateTimeNow = new System.Windows.Forms.Button();
            this.richTextBoxOperateContent = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePickerFinishTime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxOperateProject = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxOperateBranch = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonDateTimeNow
            // 
            this.buttonDateTimeNow.Location = new System.Drawing.Point(289, 42);
            this.buttonDateTimeNow.Name = "buttonDateTimeNow";
            this.buttonDateTimeNow.Size = new System.Drawing.Size(75, 23);
            this.buttonDateTimeNow.TabIndex = 17;
            this.buttonDateTimeNow.Text = "当前时间";
            this.buttonDateTimeNow.UseVisualStyleBackColor = true;
            this.buttonDateTimeNow.Click += new System.EventHandler(this.buttonDateTimeNow_Click);
            // 
            // richTextBoxOperateContent
            // 
            this.richTextBoxOperateContent.Location = new System.Drawing.Point(83, 75);
            this.richTextBoxOperateContent.Name = "richTextBoxOperateContent";
            this.richTextBoxOperateContent.Size = new System.Drawing.Size(509, 104);
            this.richTextBoxOperateContent.TabIndex = 16;
            this.richTextBoxOperateContent.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "内    容：";
            // 
            // dateTimePickerFinishTime
            // 
            this.dateTimePickerFinishTime.CustomFormat = "yyyy年MM月dd日 HH时mm分";
            this.dateTimePickerFinishTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFinishTime.Location = new System.Drawing.Point(83, 43);
            this.dateTimePickerFinishTime.Name = "dateTimePickerFinishTime";
            this.dateTimePickerFinishTime.ShowCheckBox = true;
            this.dateTimePickerFinishTime.Size = new System.Drawing.Size(200, 21);
            this.dateTimePickerFinishTime.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "完成时间：";
            // 
            // comboBoxOperateProject
            // 
            this.comboBoxOperateProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperateProject.FormattingEnabled = true;
            this.comboBoxOperateProject.Location = new System.Drawing.Point(83, 11);
            this.comboBoxOperateProject.Name = "comboBoxOperateProject";
            this.comboBoxOperateProject.Size = new System.Drawing.Size(140, 20);
            this.comboBoxOperateProject.TabIndex = 12;
            this.comboBoxOperateProject.SelectedIndexChanged += new System.EventHandler(this.comboBoxOperateProject_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "项    目：";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(172, 194);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 18;
            this.buttonAdd.Text = "新增";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(332, 194);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 19;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // comboBoxOperateBranch
            // 
            this.comboBoxOperateBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperateBranch.FormattingEnabled = true;
            this.comboBoxOperateBranch.Location = new System.Drawing.Point(313, 11);
            this.comboBoxOperateBranch.Name = "comboBoxOperateBranch";
            this.comboBoxOperateBranch.Size = new System.Drawing.Size(140, 20);
            this.comboBoxOperateBranch.TabIndex = 21;
            this.comboBoxOperateBranch.SelectedIndexChanged += new System.EventHandler(this.comboBoxOperateBranch_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(242, 14);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(65, 12);
            this.label22.TabIndex = 20;
            this.label22.Text = "分    支：";
            // 
            // AddToReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 232);
            this.Controls.Add(this.comboBoxOperateBranch);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonDateTimeNow);
            this.Controls.Add(this.richTextBoxOperateContent);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePickerFinishTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxOperateProject);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddToReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增到周报";
            this.Load += new System.EventHandler(this.AddToReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDateTimeNow;
        private System.Windows.Forms.RichTextBox richTextBoxOperateContent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePickerFinishTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxOperateProject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxOperateBranch;
        private System.Windows.Forms.Label label22;
    }
}