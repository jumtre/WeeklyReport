using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 通用数据类
    /// </summary>
    public static class CommonData
    {
        /// <summary>
        /// 数据库路径
        /// </summary>
        public static readonly string DBPath = Environment.CurrentDirectory + "\\DB\\DB.mdb";

        /// <summary>
        /// ini文件路径
        /// </summary>
        public static readonly string IniFilePath = Environment.CurrentDirectory + "\\Settings.ini";

        /// <summary>
        /// 日期格式
        /// </summary>
        public static readonly string DateFormat = "yyyy-MM-dd";

        /// <summary>
        /// 时间格式
        /// </summary>
        public static readonly string TimeFormat = "HH:mm:ss";

        /// <summary>
        /// 日期时间格式
        /// </summary>
        public static readonly string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
    }

    /// <summary>
    /// 数据转换
    /// </summary>
    public static class DataConvert
    {
        /// <summary>
        /// 转换成字符串
        /// </summary>
        /// <param name="obj">要转换的数据</param>
        /// <returns></returns>
        public static string ToString(object obj)
        {
            return obj?.ToString();
        }

        /// <summary>
        /// 转换成整型，null转换成0
        /// </summary>
        /// <param name="obj">要转换的数据</param>
        /// <returns></returns>
        public static int ToInt(object obj)
        {
            if (obj == null)
                return 0;
            if (int.TryParse(obj.ToString(), out int i))
                return i;
            else
                return 0;
        }

        /// <summary>
        /// 转换成Decimal类型，null转换成0
        /// </summary>
        /// <param name="obj">要转换的数据</param>
        /// <returns></returns>
        public static decimal ToDecimal(object obj)
        {
            if (obj == null)
                return 0;
            if (decimal.TryParse(obj.ToString(), out decimal i))
                return i;
            else
                return 0;
        }

        /// <summary>
        /// 转换成时间类型，null转换成DateTime.MinValue
        /// </summary>
        /// <param name="obj">要转换的数据</param>
        /// <returns></returns>
        public static DateTime ToDateTime(object obj)
        {
            if (obj == null)
                return DateTime.MinValue;
            DateTime dt = DateTime.MinValue;
            if (DateTime.TryParse(obj.ToString(), out dt))
                return dt;
            else
                return DateTime.MinValue;
        }
    }
}
