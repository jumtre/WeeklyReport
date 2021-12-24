using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 提醒
    /// </summary>
    public class Reminder
    {
        /// <summary>
        /// ID
        /// </summary>
        public decimal ID { get; set; }

        private string content;
        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            get
            {
                if (string.IsNullOrWhiteSpace(content) && ToDo != null)
                {
                    StringBuilder sBuilder = new StringBuilder();
                    string str = ContentFormat.Format(new List<string>() { "项目：", "分支：" }, new List<string>() { ToDo.Project?.Name, ToDo.Branch?.Name }, "  ");
                    if (!string.IsNullOrWhiteSpace(str))
                        sBuilder.AppendLine(str);
                    //                                                             , "状态："                                                                             , ToDo.Status.GetDescription()
                    str = ContentFormat.Format(new List<string>() { "优先级：", "严重度：", "指派给：" }, new List<string>() { ToDo.Priority.GetDescription(), ToDo.Severity.GetDescription(), ToDo.User?.Name }, "  ");
                    if (!string.IsNullOrWhiteSpace(str))
                        sBuilder.AppendLine(str);
                    if (ToDo.PlannedStartTime.HasValue || ToDo.PlannedEndTime.HasValue)
                    {
                        str = "计划时间：";
                        if (ToDo.PlannedStartTime.HasValue && ToDo.PlannedEndTime.HasValue)
                            str += ToDo.PlannedStartTime.Value.ToString("yyyy-MM-dd HH:mm") + " 至 " + ToDo.PlannedEndTime.Value.ToString("yyyy-MM-dd HH:mm");
                        else if (ToDo.PlannedStartTime.HasValue && !ToDo.PlannedEndTime.HasValue)
                            str += ToDo.PlannedStartTime.Value.ToString("yyyy-MM-dd HH:mm") + "(起)";
                        else if (!ToDo.PlannedStartTime.HasValue && ToDo.PlannedEndTime.HasValue)
                            str += ToDo.PlannedEndTime.Value.ToString("yyyy-MM-dd HH:mm") + "(止)";
                        else
                            str = string.Empty;
                        if (!string.IsNullOrWhiteSpace(str))
                            sBuilder.AppendLine(str);
                    }
                    string strPlannedTime = string.Empty;
                    if (ToDo.PlannedHours.HasValue || ToDo.PlannedDays.HasValue)
                    {
                        strPlannedTime = "计划时长：";
                        if (ToDo.PlannedHours.HasValue && ToDo.PlannedDays.HasValue)
                            strPlannedTime += ToDo.PlannedHours.Value.ToString() + "小时/" + ToDo.PlannedDays.Value.ToString() + "天";
                        else if (ToDo.PlannedHours.HasValue && !ToDo.PlannedDays.HasValue)
                            strPlannedTime += ToDo.PlannedHours.Value.ToString() + "小时";
                        else if (!ToDo.PlannedHours.HasValue && ToDo.PlannedDays.HasValue)
                            strPlannedTime += ToDo.PlannedDays.Value.ToString() + "天";
                        else
                            strPlannedTime = string.Empty;
                    }
                    string strTimeLeft = string.Empty;
                    if (ToDo.PlannedEndTime.HasValue)
                    {
                        TimeSpan timeLeft = ToDo.PlannedEndTime.Value - DateTime.Now;
                        if (timeLeft.TotalMinutes >= 0)
                        {
                            strTimeLeft = "剩余时长：";
                            if (timeLeft.Days > 0)
                                strTimeLeft += timeLeft.Days + "天";
                            if (timeLeft.Hours > 0)
                                strTimeLeft += timeLeft.Hours + "小时";
                            if (timeLeft.Minutes > 0)
                                strTimeLeft += timeLeft.Minutes + "分";
                        }
                        else
                        {
                            strTimeLeft = "延期时长：";
                            if (timeLeft.Days < 0)
                                strTimeLeft += Math.Abs(timeLeft.Days) + "天";
                            if (timeLeft.Hours < 0)
                                strTimeLeft += Math.Abs(timeLeft.Hours) + "小时";
                            if (timeLeft.Minutes < 0)
                                strTimeLeft += Math.Abs(timeLeft.Minutes) + "分";
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(strPlannedTime) || !string.IsNullOrWhiteSpace(strTimeLeft))
                    {
                        if (!string.IsNullOrWhiteSpace(strPlannedTime) && !string.IsNullOrWhiteSpace(strTimeLeft))
                            sBuilder.AppendLine(strPlannedTime + "  " + strTimeLeft);
                        else if (!string.IsNullOrWhiteSpace(strPlannedTime) && string.IsNullOrWhiteSpace(strTimeLeft))
                            sBuilder.AppendLine(strPlannedTime);
                        else if (string.IsNullOrWhiteSpace(strPlannedTime) && !string.IsNullOrWhiteSpace(strTimeLeft))
                            sBuilder.AppendLine(strTimeLeft);
                    }
                    if (!string.IsNullOrWhiteSpace(ToDo.Title))
                        sBuilder.AppendLine("标题：" + ToDo.Title);
                    if (!string.IsNullOrWhiteSpace(ToDo.Content))
                        sBuilder.AppendLine("内容：" + ToDo.Content);
                    if (!string.IsNullOrWhiteSpace(ToDo.Memo))
                        sBuilder.AppendLine("备注：" + ToDo.Memo);
                    content = sBuilder.ToString();
                }
                return content;
            }
            set { content = value; }
        }

        /// <summary>
        /// 关联的待办事项
        /// </summary>
        public ToDo ToDo { get; set; }

        /// <summary>
        /// 状态。0-正常；1-已删除
        /// </summary>
        public int? Status { get; set; }
    }

    public static class ContentFormat
    {
        /// <summary>
        /// 格式化内容。key有可能重复，所以不用Dictionary
        /// </summary>
        /// <param name="keyList">键的列表</param>
        /// <param name="valueList">值的列表</param>
        /// <param name="separateStr">分隔字符串</param>
        /// <returns></returns>
        public static string Format(List<string> keyList, List<string> valueList, string separateStr = null)
        {
            if (keyList?.Count == 0 || valueList?.Count == 0 || keyList.Count != valueList.Count)
                return string.Empty;
            //值为空则key和value内容都不要
            for (int i = valueList.Count - 1; i >= 0; i--)
            {
                if (string.IsNullOrWhiteSpace(valueList[i]))
                {
                    valueList.RemoveAt(i);
                    keyList.RemoveAt(i);
                }
            }
            StringBuilder stringBuilder = new StringBuilder();
            if (separateStr == null)
                separateStr = string.Empty;
            for (int i = 0; i < valueList.Count; i++)
                stringBuilder.Append(keyList[i] + valueList[i] + separateStr);
            if (separateStr.Length > 0)
                stringBuilder = stringBuilder.Remove(stringBuilder.Length - separateStr.Length, separateStr.Length);
            return stringBuilder.ToString();
        }

        /// <summary>
        /// 通过反射得到枚举值的描述
        /// </summary>
        /// <param name="enumItem">要获取描述的枚举值</param>
        /// <returns></returns>
        public static string GetDescription(this Enum enumItem)
        {
            if (enumItem == null)
                return null;
            string name = enumItem.ToString();
            if (string.IsNullOrWhiteSpace(name))
                return null;
            FieldInfo fieldInfo = enumItem.GetType().GetField(name);
            //如果name是多态枚举值或者是未找到符合指定要求的字段的对象，将返回null
            if (fieldInfo == null)
                return null;

            DescriptionAttribute descriptionAttr = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute)) as DescriptionAttribute;
            if (descriptionAttr == null)
                return null;
            return descriptionAttr.Description;
        }
    }
}
