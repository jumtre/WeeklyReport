using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 报告
    /// </summary>
    public class Report
    {
        /// <summary>
        /// ID
        /// </summary>
        public decimal ID { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// 项目
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        /// 分支
        /// </summary>
        public Branch Branch { get; set; }

        /// <summary>
        /// 关联ID。如需求ID或缺陷ID
        /// </summary>
        public string RelatedID { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime FinishTime { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        public EnumReportSource? Source { get; set; }

        /// <summary>
        /// 关联的待办事项ID
        /// </summary>
        public decimal? ToDoID { get; set; }
    }
}
