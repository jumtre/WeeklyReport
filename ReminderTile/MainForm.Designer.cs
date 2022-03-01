namespace ReminderTile
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonColor = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.richTextBoxContent = new System.Windows.Forms.RichTextBox();
            this.buttonTop = new System.Windows.Forms.Button();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.panelBar = new System.Windows.Forms.Panel();
            this.toolTipInfo = new System.Windows.Forms.ToolTip(this.components);
            this.notifyIconNofity = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemTop = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.contextMenuStripNotify.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonColor
            // 
            this.buttonColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonColor.BackColor = System.Drawing.Color.LightGray;
            this.buttonColor.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.buttonColor.FlatAppearance.BorderSize = 0;
            this.buttonColor.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
            this.buttonColor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.buttonColor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.buttonColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonColor.Font = new System.Drawing.Font("宋体", 12F);
            this.buttonColor.Location = new System.Drawing.Point(293, 180);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(18, 18);
            this.buttonColor.TabIndex = 8;
            this.buttonColor.Text = "█";
            this.buttonColor.UseVisualStyleBackColor = false;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.BackColor = System.Drawing.Color.LightGray;
            this.buttonClose.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
            this.buttonClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Location = new System.Drawing.Point(311, 180);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(18, 18);
            this.buttonClose.TabIndex = 9;
            this.buttonClose.Text = "×";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // richTextBoxContent
            // 
            this.richTextBoxContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxContent.Location = new System.Drawing.Point(8, 8);
            this.richTextBoxContent.Name = "richTextBoxContent";
            this.richTextBoxContent.Size = new System.Drawing.Size(314, 168);
            this.richTextBoxContent.TabIndex = 0;
            this.richTextBoxContent.Text = "";
            this.richTextBoxContent.BackColorChanged += new System.EventHandler(this.richTextBoxContent_BackColorChanged);
            // 
            // buttonTop
            // 
            this.buttonTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTop.BackColor = System.Drawing.Color.LightGray;
            this.buttonTop.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.buttonTop.FlatAppearance.BorderSize = 0;
            this.buttonTop.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
            this.buttonTop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.buttonTop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.buttonTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTop.Location = new System.Drawing.Point(275, 180);
            this.buttonTop.Name = "buttonTop";
            this.buttonTop.Size = new System.Drawing.Size(18, 18);
            this.buttonTop.TabIndex = 7;
            this.buttonTop.Text = "↓";
            this.buttonTop.UseVisualStyleBackColor = false;
            this.buttonTop.Click += new System.EventHandler(this.buttonTop_Click);
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPrevious.BackColor = System.Drawing.Color.LightGray;
            this.buttonPrevious.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.buttonPrevious.FlatAppearance.BorderSize = 0;
            this.buttonPrevious.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
            this.buttonPrevious.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.buttonPrevious.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.buttonPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrevious.Location = new System.Drawing.Point(185, 180);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(18, 18);
            this.buttonPrevious.TabIndex = 2;
            this.buttonPrevious.Text = "<";
            this.buttonPrevious.UseVisualStyleBackColor = false;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNext.BackColor = System.Drawing.Color.LightGray;
            this.buttonNext.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.buttonNext.FlatAppearance.BorderSize = 0;
            this.buttonNext.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
            this.buttonNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.buttonNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNext.Location = new System.Drawing.Point(203, 180);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(18, 18);
            this.buttonNext.TabIndex = 3;
            this.buttonNext.Text = ">";
            this.buttonNext.UseVisualStyleBackColor = false;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.BackColor = System.Drawing.Color.LightGray;
            this.buttonAdd.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
            this.buttonAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.buttonAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Location = new System.Drawing.Point(221, 180);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(18, 18);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "+";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.BackColor = System.Drawing.Color.LightGray;
            this.buttonSave.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
            this.buttonSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.buttonSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Location = new System.Drawing.Point(239, 180);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(18, 18);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "✓";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.BackColor = System.Drawing.Color.LightGray;
            this.buttonDelete.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
            this.buttonDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.buttonDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Location = new System.Drawing.Point(257, 180);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(18, 18);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "-";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // panelBar
            // 
            this.panelBar.Location = new System.Drawing.Point(0, 180);
            this.panelBar.Name = "panelBar";
            this.panelBar.Size = new System.Drawing.Size(165, 18);
            this.panelBar.TabIndex = 9;
            this.panelBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelBar_MouseDown);
            this.panelBar.MouseEnter += new System.EventHandler(this.panelBar_MouseEnter);
            this.panelBar.MouseLeave += new System.EventHandler(this.panelBar_MouseLeave);
            this.panelBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBar_MouseMove);
            this.panelBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelBar_MouseUp);
            // 
            // notifyIconNofity
            // 
            this.notifyIconNofity.ContextMenuStrip = this.contextMenuStripNotify;
            this.notifyIconNofity.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconNofity.Icon")));
            this.notifyIconNofity.Text = "提醒磁贴";
            this.notifyIconNofity.Visible = true;
            this.notifyIconNofity.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconNofity_MouseDoubleClick);
            // 
            // contextMenuStripNotify
            // 
            this.contextMenuStripNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemTop,
            this.ToolStripMenuItemExit});
            this.contextMenuStripNotify.Name = "contextMenuStripNotify";
            this.contextMenuStripNotify.Size = new System.Drawing.Size(101, 48);
            // 
            // ToolStripMenuItemTop
            // 
            this.ToolStripMenuItemTop.Name = "ToolStripMenuItemTop";
            this.ToolStripMenuItemTop.Size = new System.Drawing.Size(100, 22);
            this.ToolStripMenuItemTop.Text = "置顶";
            this.ToolStripMenuItemTop.Click += new System.EventHandler(this.ToolStripMenuItemTop_Click);
            // 
            // ToolStripMenuItemExit
            // 
            this.ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
            this.ToolStripMenuItemExit.Size = new System.Drawing.Size(100, 22);
            this.ToolStripMenuItemExit.Text = "退出";
            this.ToolStripMenuItemExit.Click += new System.EventHandler(this.ToolStripMenuItemExit_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefresh.BackColor = System.Drawing.Color.LightGray;
            this.buttonRefresh.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.buttonRefresh.FlatAppearance.BorderSize = 0;
            this.buttonRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.buttonRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.Location = new System.Drawing.Point(167, 180);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(18, 18);
            this.buttonRefresh.TabIndex = 1;
            this.buttonRefresh.Text = "¤";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 200);
            this.Controls.Add(this.panelBar);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonColor);
            this.Controls.Add(this.buttonTop);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.richTextBoxContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "提醒磁贴";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.contextMenuStripNotify.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.RichTextBox richTextBoxContent;
        private System.Windows.Forms.Button buttonTop;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Panel panelBar;
        private System.Windows.Forms.ToolTip toolTipInfo;
        private System.Windows.Forms.NotifyIcon notifyIconNofity;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNotify;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemTop;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExit;
        private System.Windows.Forms.Button buttonRefresh;
    }
}

