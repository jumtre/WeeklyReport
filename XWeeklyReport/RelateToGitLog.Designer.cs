namespace XWeeklyReport
{
    partial class RelateToGitLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RelateToGitLog));
            this.dataGridViewGitLogs = new System.Windows.Forms.DataGridView();
            this.richTextBoxLogContent = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonRelate = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ColumnContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGitLogs)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewGitLogs
            // 
            this.dataGridViewGitLogs.AllowUserToAddRows = false;
            this.dataGridViewGitLogs.AllowUserToDeleteRows = false;
            this.dataGridViewGitLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewGitLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGitLogs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnContent,
            this.ColumnAuthor,
            this.ColumnDate});
            this.dataGridViewGitLogs.Location = new System.Drawing.Point(19, 15);
            this.dataGridViewGitLogs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewGitLogs.MultiSelect = false;
            this.dataGridViewGitLogs.Name = "dataGridViewGitLogs";
            this.dataGridViewGitLogs.ReadOnly = true;
            this.dataGridViewGitLogs.RowHeadersVisible = false;
            this.dataGridViewGitLogs.RowHeadersWidth = 51;
            this.dataGridViewGitLogs.RowTemplate.Height = 23;
            this.dataGridViewGitLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGitLogs.Size = new System.Drawing.Size(1032, 321);
            this.dataGridViewGitLogs.TabIndex = 0;
            this.dataGridViewGitLogs.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewGitLogs_CellFormatting);
            this.dataGridViewGitLogs.SelectionChanged += new System.EventHandler(this.dataGridViewGitLogs_SelectionChanged);
            // 
            // richTextBoxLogContent
            // 
            this.richTextBoxLogContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxLogContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxLogContent.Location = new System.Drawing.Point(16, 45);
            this.richTextBoxLogContent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBoxLogContent.Name = "richTextBoxLogContent";
            this.richTextBoxLogContent.ReadOnly = true;
            this.richTextBoxLogContent.Size = new System.Drawing.Size(1033, 158);
            this.richTextBoxLogContent.TabIndex = 1;
            this.richTextBoxLogContent.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonRelate);
            this.panel1.Controls.Add(this.richTextBoxLogContent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 344);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1067, 255);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "内容预览：";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(619, 211);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 29);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonRelate
            // 
            this.buttonRelate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRelate.Location = new System.Drawing.Point(384, 211);
            this.buttonRelate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRelate.Name = "buttonRelate";
            this.buttonRelate.Size = new System.Drawing.Size(100, 29);
            this.buttonRelate.TabIndex = 2;
            this.buttonRelate.Text = "关联";
            this.buttonRelate.UseVisualStyleBackColor = true;
            this.buttonRelate.Click += new System.EventHandler(this.buttonRelate_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewGitLogs);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1067, 344);
            this.panel2.TabIndex = 3;
            // 
            // ColumnContent
            // 
            this.ColumnContent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnContent.HeaderText = "内容";
            this.ColumnContent.MinimumWidth = 6;
            this.ColumnContent.Name = "ColumnContent";
            this.ColumnContent.ReadOnly = true;
            // 
            // ColumnAuthor
            // 
            this.ColumnAuthor.HeaderText = "作者";
            this.ColumnAuthor.MinimumWidth = 6;
            this.ColumnAuthor.Name = "ColumnAuthor";
            this.ColumnAuthor.ReadOnly = true;
            this.ColumnAuthor.Width = 125;
            // 
            // ColumnDate
            // 
            this.ColumnDate.HeaderText = "日期";
            this.ColumnDate.MinimumWidth = 6;
            this.ColumnDate.Name = "ColumnDate";
            this.ColumnDate.ReadOnly = true;
            this.ColumnDate.Width = 160;
            // 
            // RelateToGitLog
            // 
            this.AcceptButton = this.buttonRelate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(1067, 599);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RelateToGitLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "关联Git日志";
            this.Load += new System.EventHandler(this.RelateToGitLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGitLogs)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewGitLogs;
        private System.Windows.Forms.RichTextBox richTextBoxLogContent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonRelate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAuthor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDate;
    }
}