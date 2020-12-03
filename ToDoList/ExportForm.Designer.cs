namespace ToDoList
{
    partial class ExportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxAutoReorder = new System.Windows.Forms.CheckBox();
            this.buttonReorder = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextBoxContent = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxAutoReorder);
            this.panel1.Controls.Add(this.buttonReorder);
            this.panel1.Controls.Add(this.buttonSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(680, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 450);
            this.panel1.TabIndex = 0;
            // 
            // checkBoxAutoReorder
            // 
            this.checkBoxAutoReorder.AutoSize = true;
            this.checkBoxAutoReorder.Location = new System.Drawing.Point(18, 80);
            this.checkBoxAutoReorder.Name = "checkBoxAutoReorder";
            this.checkBoxAutoReorder.Size = new System.Drawing.Size(96, 16);
            this.checkBoxAutoReorder.TabIndex = 2;
            this.checkBoxAutoReorder.Text = "自动重新编号";
            this.checkBoxAutoReorder.UseVisualStyleBackColor = true;
            this.checkBoxAutoReorder.Visible = false;
            // 
            // buttonReorder
            // 
            this.buttonReorder.Location = new System.Drawing.Point(18, 50);
            this.buttonReorder.Name = "buttonReorder";
            this.buttonReorder.Size = new System.Drawing.Size(75, 23);
            this.buttonReorder.TabIndex = 1;
            this.buttonReorder.Text = "重新编号";
            this.buttonReorder.UseVisualStyleBackColor = true;
            this.buttonReorder.Visible = false;
            this.buttonReorder.Click += new System.EventHandler(this.buttonReorder_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(18, 21);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.richTextBoxContent);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(680, 450);
            this.panel2.TabIndex = 1;
            // 
            // richTextBoxContent
            // 
            this.richTextBoxContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxContent.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxContent.Name = "richTextBoxContent";
            this.richTextBoxContent.Size = new System.Drawing.Size(680, 450);
            this.richTextBoxContent.TabIndex = 0;
            this.richTextBoxContent.Text = "";
            this.richTextBoxContent.TextChanged += new System.EventHandler(this.richTextBoxContent_TextChanged);
            // 
            // ExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导出";
            this.Load += new System.EventHandler(this.ExportForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox richTextBoxContent;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckBox checkBoxAutoReorder;
        private System.Windows.Forms.Button buttonReorder;
    }
}