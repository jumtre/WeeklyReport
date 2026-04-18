using Common;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeeklyReport
{
    public partial class RelateToGitLog : Form
    {
        /// <summary>
        /// 选择的Git日志
        /// </summary>
        public GitLog GitLog { get; private set; }

        private List<GitLog> gitLogList;

        public RelateToGitLog(List<GitLog> gitLogs)
        {
            InitializeComponent();

            gitLogList = gitLogs;
        }

        private void RelateToGitLog_Load(object sender, EventArgs e)
        {
            BindGitLog(gitLogList);
        }

        private void BindGitLog(List<GitLog> gitLogs)
        {
            dataGridViewGitLogs.SelectionChanged -= dataGridViewGitLogs_SelectionChanged;
            //dataGridViewGitLogs.Rows.Clear();
            if (gitLogs == null || gitLogs.Count == 0)
                return;
            foreach (GitLog log in gitLogs)
            {
                int index = dataGridViewGitLogs.Rows.Add();
                DataGridViewRow row = dataGridViewGitLogs.Rows[index];
                //row.Cells[ColumnSortNo.Index].Value = index + 1;
                row.Cells[ColumnContent.Index].Value = log.Content;
                row.Cells[ColumnAuthor.Index].Value = log.AuthorName;
                row.Cells[ColumnDate.Index].Value = log.Date;
                row.Tag = log;
            }
            dataGridViewGitLogs.ClearSelection();
            dataGridViewGitLogs.SelectionChanged += dataGridViewGitLogs_SelectionChanged;
        }

        private void dataGridViewGitLogs_SelectionChanged(object sender, EventArgs e)
        {
            richTextBoxLogContent.Text = string.Empty;
            if (dataGridViewGitLogs.SelectedRows.Count != 1)
                return;
            DataGridViewRow row = dataGridViewGitLogs.SelectedRows[0];
            if (!(row.Tag is GitLog log))
                return;
            richTextBoxLogContent.Text = log.Content;
        }

        private void dataGridViewGitLogs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == ColumnDate.Index)
            {
                DateTime dt = DateTime.MinValue;
                if (DateTime.TryParse(e.Value?.ToString(), out dt))
                    e.Value = dt.ToString(CommonData.DateTimeFormat);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonRelate_Click(object sender, EventArgs e)
        {
            if (dataGridViewGitLogs.SelectedRows.Count != 1)
            {
                MessageBox.Show("未选择要关联的Git日志", "提示");
                return;
            }
            DataGridViewRow row = dataGridViewGitLogs.SelectedRows[0];
            if (!(row.Tag is GitLog log))
            {
                MessageBox.Show("选择的Git日志数据错误", "提示");
                return;
            }
            GitLog = log;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
