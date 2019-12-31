using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 待办事项
    /// </summary>
    public class ToDo
    {
        /// <summary>
        /// 待办事项ID
        /// </summary>
        public decimal ID { get; set; }

        /// <summary>
        /// 项目
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        /// 优先级
        /// </summary>
        public EnumToDoPriority? Priority { get; set; }

        /// <summary>
        /// 严重度
        /// </summary>
        public EnumToDoSeverity? Severity { get; set; }

        /// <summary>
        /// 待办标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 待办内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 待办备注
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// 计划开始时间
        /// </summary>
        public DateTime? PlannedStartTime { get; set; }

        /// <summary>
        /// 计划结束时间
        /// </summary>
        public DateTime? PlannedEndTime { get; set; }

        /// <summary>
        /// 计划小时数
        /// </summary>
        public decimal? PlannedHours { get; set; }

        /// <summary>
        /// 计划天数
        /// </summary>
        public decimal? PlannedDays { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public EnumToDoStatus? Status { get; set; }

        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime? FinishTime { get; set; }

        /// <summary>
        /// 完成用户
        /// </summary>
        public User FinishUser { get; set; }
    }
}
