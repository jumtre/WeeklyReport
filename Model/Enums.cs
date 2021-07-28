using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 日期间隔枚举
    /// </summary>
    public enum DateInterval
    {
        /// <summary>
        /// 秒
        /// </summary>
        Second,
        /// <summary>
        /// 分
        /// </summary>
        Minute,
        /// <summary>
        /// 时
        /// </summary>
        Hour,
        /// <summary>
        /// 日
        /// </summary>
        Day,
        /// <summary>
        /// 周
        /// </summary>
        Week,
        /// <summary>
        /// 月
        /// </summary>
        Month,
        /// <summary>
        /// 季
        /// </summary>
        Quarter,
        /// <summary>
        /// 年
        /// </summary>
        Year
    }

    /// <summary>
    /// 待办事项状态枚举
    /// </summary>
    public enum EnumToDoStatus
    {
        /// <summary>
        /// 计划中
        /// </summary>
        [Description("计划中")]
        Planning,
        /// <summary>
        /// 工作中
        /// </summary>
        [Description("工作中")]
        Working,
        /// <summary>
        /// 已完成
        /// </summary>
        [Description("已完成")]
        Done,
        /// <summary>
        /// 已取消
        /// </summary>
        [Description("已取消")]
        Cancelled
    }

    /// <summary>
    /// 待办事项状态类
    /// </summary>
    public class ToDoStatus
    {
        /// <summary>
        /// 编码
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 待办事项状态枚举
        /// </summary>
        public EnumToDoStatus Status { get; set; }

        /// <summary>
        /// 待办事项状态类
        /// </summary>
        public ToDoStatus() { }

        /// <summary>
        /// 待办事项状态类
        /// </summary>
        /// <param name="id">编码</param>
        /// <param name="name">名称</param>
        /// <param name="status">状态枚举</param>
        public ToDoStatus(int id, string name, EnumToDoStatus status)
        {
            this.ID = id;
            this.Name = name;
            this.Status = status;
        }
    }

    /// <summary>
    /// 待办事项优先级枚举
    /// </summary>
    public enum EnumToDoPriority
    {
        /// <summary>
        /// 立刻
        /// <para>即“马上解决”，表示问题必须马上解决，否则系统根本无法达到预定的需求。</para>
        /// </summary>
        [Description("1-立刻")]
        Immediate = 1,
        /// <summary>
        /// 紧要、优先
        /// <para>即“急需解决”，表示问题的修复很紧要，很急迫，关系到系统的主要功能模块能否正常 。</para>
        /// </summary>
        [Description("2-紧要")]
        Urgent = 2,
        /// <summary>
        /// 高度重视
        /// <para>即“高度重视”，表示有时间就要马上解决，否则系统偏离需求较大或预定功能不能正常实现。</para>
        /// </summary>
        [Description("3-重视")]
        High = 3,
        /// <summary>
        /// 正常
        /// <para>即“正常处理”，进入个人计划解决，表示问题不影响需求的实现，但是影响其他使用方面，比如页面调用出错，调用了错误的等。</para>
        /// </summary>
        [Description("4-正常")]
        Normal = 4,
        /// <summary>
        /// 稍缓
        /// <para>即”低优先级”，即问题在系统发布以前必须确认解决或确认可以不予解决。</para>
        /// </summary>
        [Description("5-稍缓")]
        Low = 5
    }

    /// <summary>
    /// 待办事项优先级类
    /// </summary>
    public class ToDoPriority
    {
        /// <summary>
        /// 编码
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 待办事项优先级枚举
        /// </summary>
        public EnumToDoPriority Priority { get; set; }

        /// <summary>
        /// 待办事项优先级类
        /// </summary>
        public ToDoPriority() { }

        /// <summary>
        /// 待办事项优先级类
        /// </summary>
        /// <param name="id">编码</param>
        /// <param name="name">名称</param>
        /// <param name="priority">待办事项优先级枚举</param>
        public ToDoPriority(int id, string name, EnumToDoPriority priority)
        {
            this.ID = id;
            this.Name = name;
            this.Priority = priority;
        }
    }

    /// <summary>
    /// 待办事项严重度枚举
    /// </summary>
    public enum EnumToDoSeverity
    {
        /// <summary>
        /// 有妨碍的
        /// <para>即系统无法执行、崩溃或严重资源不足、应用模块无法启动或异常退出、无法测试、造成系统不稳定。</para>
        /// <para>严重花屏</para>
        /// <para>内存泄漏</para>
        /// <para>用户数据丢失或破坏</para>
        /// <para>系统崩溃/死机/冻结</para>
        /// <para>模块无法启动或异常退出</para>
        /// <para>严重的数值计算错误</para>
        /// <para>功能设计与需求严重不符</para>
        /// <para>其它导致无法测试的错误, 如服务器500错误</para>
        /// </summary>
        [Description("1-有妨碍的")]
        Blocker = 1,
        /// <summary>
        /// 紧要的
        /// <para>即影响系统功能或操作，主要功能存在严重缺陷，但不会影响到系统稳定性。</para>
        /// <para>功能未实现</para>
        /// <para>功能错误</para>
        /// <para>系统刷新错误</para>
        /// <para>数据通讯错误</para>
        /// <para>轻微的数值计算错误</para>
        /// <para>影响功能及界面的错误字或拼写错误</para>
        /// <para>安全性问题</para>
        /// </summary>
        [Description("2-紧要的")]
        Critical = 2,
        /// <summary>
        /// 严重的
        /// <para>即界面、性能缺陷、兼容性。</para>
        /// <para>操作界面错误（包括数据窗口内列名定义、含义是否一致）</para>
        /// <para>边界条件下错误</para>
        /// <para>提示信息错误（包括未给出信息、信息提示错误等）</para>
        /// <para>长时间操作无进度提示</para>
        /// <para>系统未优化（性能问题）</para>
        /// <para>光标跳转设置不好，鼠标（光标）定位错误</para>
        /// <para>兼容性问题</para>
        /// </summary>
        [Description("3-严重的")]
        Major = 3,
        /// <summary>
        /// 次要的/不严重的
        /// <para>即易用性及建议性问题。</para>
        /// <para>界面格式等不规范</para>
        /// <para>辅助说明描述不清楚</para>
        /// <para>操作时未给用户提示</para>
        ///<para>可输入区域和只读区域没有明显的区分标志</para>
        ///<para>个别不影响产品理解的错别字</para>
        ///<para>文字排列不整齐等一些小问题</para>
        /// </summary>
        [Description("4-次要的")]
        Minor = 4//Trivial
    }

    /// <summary>
    /// 待办事项严重度类
    /// </summary>
    public class ToDoSeverity
    {
        /// <summary>
        /// 编码
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 严重度枚举
        /// </summary>
        public EnumToDoSeverity Severity { get; set; }

        /// <summary>
        /// 待办事项优先级类
        /// </summary>
        public ToDoSeverity() { }

        /// <summary>
        /// 待办事项优先级类
        /// </summary>
        /// <param name="id">编码</param>
        /// <param name="name">名称</param>
        /// <param name="severity">待办事项严重度优先级枚举</param>
        public ToDoSeverity(int id, string name, EnumToDoSeverity severity)
        {
            this.ID = id;
            this.Name = name;
            this.Severity = severity;
        }
    }

    /// <summary>
    /// 报告来源
    /// </summary>
    public enum EnumReportSource
    {
        /// <summary>
        /// 手动
        /// </summary>
        Manual,
        /// <summary>
        /// 待办事项
        /// </summary>
        Todo
    }
}
