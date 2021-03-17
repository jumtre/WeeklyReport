using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Model
{
    /// <summary>
    /// SQL参数集合类
    /// </summary>
    public class SqlParams : Dictionary<string, object>
    {
        /// <summary>
        /// 给where语句新增参数，返回SQL语句的查询条件
        /// </summary>
        /// <param name="fieldName">SQL语句中字段的名称，同时用作参数的名称</param>
        /// <param name="paramValue">参数的值</param>
        /// <param name="tableName">表的名称或别名</param>
        /// <returns></returns>
        public string AddToWhere(string fieldName, object paramValue, string tableName = "")
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new ArgumentException("查询语句中参数有误。");
            if (!string.IsNullOrWhiteSpace(tableName))
                tableName += ".";
            string str = " and " + tableName + fieldName + " = @" + fieldName;
            base.Add(fieldName, paramValue);
            return str;
        }

        /// <summary>
        /// 给where语句新增参数，返回SQL语句的查询条件
        /// </summary>
        /// <param name="fieldName">SQL语句中字段的名称</param>
        /// <param name="queryCondition">查询条件</param>
        /// <param name="paramName">参数的名称</param>
        /// <param name="paramValue">参数的值</param>
        /// <param name="tableName">表的名称或别名</param>
        /// <returns></returns>
        public string AddToWhere(string fieldName, string queryCondition, string paramName, object paramValue, string tableName = "")
        {
            if (string.IsNullOrWhiteSpace(fieldName) || string.IsNullOrWhiteSpace(paramName) || string.IsNullOrWhiteSpace(queryCondition))
                throw new ArgumentException("查询语句中参数有误。");
            if (!string.IsNullOrWhiteSpace(tableName))
                tableName += ".";
            string str = " and " + tableName + fieldName + " " + queryCondition + " @" + paramName;
            base.Add(paramName, paramValue);
            return str;
        }

        /// <summary>
        /// 给where语句新增参数，返回SQL语句的查询条件。用于同一字段多个查询条件，参数在3个（含）以内用or关键字拼接语句，否则用in拼接语句。
        /// </summary>
        /// <param name="fieldName">SQL语句中字段的名称</param>
        /// <param name="paramNameList">参数名称的列表</param>
        /// <param name="paramValueList">参数值的列表</param>
        /// <param name="tableName">表的名称或别名</param>
        /// <returns></returns>
        public string AddToWhere(string fieldName, List<string> paramNameList, List<object> paramValueList, string tableName = "")
        {
            if (paramNameList == null || paramValueList == null || paramNameList.Count != paramValueList.Count || paramNameList.Count == 0)
                throw new ArgumentException("查询语句中参数有误。");
            if (!string.IsNullOrWhiteSpace(tableName))
                tableName += ".";
            StringBuilder strBuilder = new StringBuilder();
            if (paramNameList.Count <= 3)
            {
                strBuilder.Append(" and (");
                for (int i = 0; i < paramNameList.Count; i++)
                {
                    strBuilder.Append(tableName + fieldName + " = @" + paramNameList[i] + " or ");
                    base.Add(paramNameList[i], paramValueList[i]);
                }
                strBuilder.Remove(strBuilder.Length - " or ".Length, " or ".Length);
                strBuilder.Append(")");
            }
            else
            {
                strBuilder.Append(" and " + tableName + fieldName + " in (");
                for (int i = 0; i < paramNameList.Count; i++)
                {
                    strBuilder.Append(paramNameList[i] + ",");
                    base.Add(paramNameList[i], paramValueList[i]);
                }
                strBuilder.Remove(strBuilder.Length - 1, 1).Append(")");
            }
            return strBuilder.ToString();
        }

        /// <summary>
        /// 给where语句新增参数，返回SQL语句的查询条件。用于同一字段多个查询条件，参数在3个（含）以内用or关键字拼接语句，否则用in拼接语句。
        /// </summary>
        /// <param name="fieldName">SQL语句中字段的名称</param>
        /// <param name="paramValueList">参数值的列表</param>
        /// <param name="tableName">表的名称或别名</param>
        /// <returns></returns>
        public string AddToWhere(string fieldName, List<object> paramValueList, string tableName = "")
        {
            if (paramValueList == null || paramValueList.Count == 0)
                throw new ArgumentException("查询语句中参数有误。");
            List<string> paramNameList = new List<string>();
            for (int i = 0; i < paramValueList.Count; i++)
            {
                paramNameList.Add(fieldName + i);
            }
            return this.AddToWhere(fieldName, paramNameList, paramValueList, tableName);
        }

        /// <summary>
        /// 给where语句新增参数，返回SQL语句的查询条件
        /// </summary>
        /// <param name="fieldName">SQL语句中字段的名称，同时用作参数的名称</param>
        /// <param name="textBox">从中取参数的值的TextBox控件</param>
        /// <param name="tableName">表的名称或别名</param>
        /// <returns></returns>
        public string AddToWhere(string fieldName, TextBox textBox, string tableName = "")
        {
            if (string.IsNullOrWhiteSpace(fieldName) || textBox == null)
                throw new ArgumentException("查询语句中参数有误。");
            return this.AddToWhere(fieldName, textBox.Text.Trim(), tableName);
        }

        /// <summary>
        /// 给where语句新增参数，返回SQL语句的like查询条件
        /// </summary>
        /// <param name="fieldName">SQL语句中字段的名称，同时用作参数的名称</param>
        /// <param name="paramValue">参数的值</param>
        /// <param name="tableName">表的名称或别名</param>
        /// <returns></returns>
        public string AddLikeToWhere(string fieldName, string paramValue, string tableName = "")
        {
            if (string.IsNullOrWhiteSpace(fieldName) || string.IsNullOrWhiteSpace(paramValue))
                throw new ArgumentException("查询语句中参数有误。");
            if (!string.IsNullOrWhiteSpace(tableName))
                tableName += ".";
            string str = " and " + tableName + fieldName + " like @" + fieldName;
            base.Add(fieldName, "%" + paramValue + "%");
            return str;
        }

        /// <summary>
        /// 给where语句新增参数，返回SQL语句的like查询条件
        /// </summary>
        /// <param name="fieldName">SQL语句中字段的名称，同时用作参数的名称</param>
        /// <param name="textBox">从中取参数的值的TextBox控件</param>
        /// <param name="tableName">表的名称或别名</param>
        /// <returns></returns>
        public string AddLikeToWhere(string fieldName, TextBox textBox, string tableName = "")
        {
            if (string.IsNullOrWhiteSpace(fieldName) || textBox == null)
                throw new ArgumentException("查询语句中参数有误。");
            return this.AddLikeToWhere(fieldName, textBox.Text.Trim(), tableName);
        }

        /// <summary>
        /// 给values语句新增参数，返回SQL语句
        /// </summary>
        /// <param name="fieldName">SQL语句中字段的名称，同时用作参数的名称</param>
        /// <param name="paramValue">参数的值</param>
        /// <param name="tableName">表的名称或别名</param>
        /// <returns></returns>
        public string AddToValues(string fieldName, object paramValue, string tableName = "")
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new ArgumentException("查询语句中参数有误。");
            if (!string.IsNullOrWhiteSpace(tableName))
                tableName += ".";
            string str = " and " + tableName + fieldName + " = @" + fieldName;
            base.Add(fieldName, paramValue);
            return str;
        }

        /// <summary>
        /// 新增参数
        /// </summary>
        /// <param name="fieldName">SQL语句中字段的名称，同时用作参数的名称</param>
        /// <param name="paramValue">参数的值</param>
        public new void Add(string fieldName, object paramValue)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new ArgumentException("查询语句中参数有误。");
            //参数化查询时，如果参数的值是DateTime类型的，要转成String
            if (paramValue != null && paramValue.GetType() == typeof(DateTime))
            {
                paramValue = ((DateTime)paramValue).ToString("yyyy-MM-dd HH:mm:ss");
            }
            base.Add(fieldName, paramValue);
        }
    }
}
