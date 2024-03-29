﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class AccessHelper
    {
        /// <summary>
        /// 数据库连接语句
        /// </summary>
        public string DbConnectionString { get; set; }
        /// <summary>
        /// 数据库连接
        /// </summary>
        public OleDbConnection DbConnection { get; set; }

        public AccessHelper()
        {
            SetDbString();
        }

        public AccessHelper(string dbPath)
        {
            SetDbString(dbPath);
        }

        /// <summary>
        /// 设置数据库连接字符串
        /// </summary>
        /// <param name="dbPath">数据库地址</param>
        public void SetDbString(string dbPath = null)
        {
            if (string.IsNullOrWhiteSpace(dbPath))
                dbPath = Environment.CurrentDirectory + "\\DB\\DB.mdb";
            if (!File.Exists(dbPath))
            {
                throw new FileNotFoundException("数据库文件不存在");
            }
            DbConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbPath;
        }

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <param name="connStr">数据库连接语句</param>
        /// <returns></returns>
        public OleDbConnection GetDbConnection(string connStr = null)
        {
            if (string.IsNullOrWhiteSpace(connStr))
                connStr = DbConnectionString;
            if (connStr.Trim().ToLower() == DbConnectionString.Trim().ToString() && DbConnection != null)
                return DbConnection;
            else
                return new OleDbConnection(DbConnectionString);
        }

        /// <summary>
        /// 通过查询获取DataTable
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql, Dictionary<string, object> paramDict = null, OleDbConnection conn = null)
        {
            if (string.IsNullOrWhiteSpace(sql))
                return null;
            if (conn == null)
                conn = GetDbConnection();

            DataTable dt = new DataTable();
            using (conn)
            {
                conn.Open();
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
                if (paramDict != null && paramDict.Count > 0)
                {
                    foreach (KeyValuePair<string, object> pair in paramDict)
                        da.SelectCommand.Parameters.AddWithValue(pair.Key, pair.Value ?? DBNull.Value);
                }
                da.Fill(dt);
                da.Dispose();
                da = null;
                conn.Close();
                conn.Dispose();
            }
            return dt;
        }

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="paramDict">参数字典</param>
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, Dictionary<string, object> paramDict = null, OleDbConnection conn = null)
        {
            if (string.IsNullOrWhiteSpace(sql))
                return 0;
            if (conn == null)
                conn = GetDbConnection();

            int result = 0;
            using (conn)
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                if (paramDict != null && paramDict.Count > 0)
                {
                    foreach (KeyValuePair<string, object> pair in paramDict)
                        cmd.Parameters.AddWithValue(pair.Key, pair.Value ?? DBNull.Value);
                }
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = null;
                conn.Close();
                conn.Dispose();
            }
            return result;
        }

        /// <summary>
        /// 执行命令获取查询结果中第0行第0列的值
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="paramDict">参数字典</param>
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public object ExecuteScalar(string sql, Dictionary<string, object> paramDict = null, OleDbConnection conn = null)
        {
            if (string.IsNullOrWhiteSpace(sql))
                return null;
            if (conn == null)
                conn = GetDbConnection();

            object o = null;
            using (conn)
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                if (paramDict != null && paramDict.Count > 0)
                {
                    foreach (KeyValuePair<string, object> pair in paramDict)
                        cmd.Parameters.AddWithValue(pair.Key, pair.Value ?? DBNull.Value);
                }
                o = cmd.ExecuteScalar();
                cmd.Dispose();
                cmd = null;
                conn.Close();
                conn.Dispose();
            }
            return o;
        }

        /// <summary>
        /// 格式化字段名
        /// </summary>
        /// <param name="fieldName">要格式化的原始字段名</param>
        /// <returns></returns>
        public string FormatFieldName(string fieldName)
        {
            return CommonData.IsAccessKeyword(fieldName) ? "[" + fieldName + "]" : fieldName;
        }

        /// <summary>
        /// 格式化参数名
        /// </summary>
        /// <param name="paramName">要格式化的原始参数名</param>
        /// <param name="prefix">参数名前缀。可选，默认为空字符串。</param>
        /// <returns></returns>
        public string FormatParamName(string paramName, string prefix = "")
        {
            string strParamName = paramName;
            if (strParamName.StartsWith("[") && strParamName.EndsWith("]"))
                strParamName = strParamName.TrimStart('[').TrimEnd(']');
            if (!string.IsNullOrWhiteSpace(prefix))
                strParamName = prefix.Trim() + strParamName;
            return strParamName;
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="paramDict">参数字典</param>
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public int Insert(string tableName, Dictionary<string, object> paramDict, OleDbConnection conn = null)
        {
            if (string.IsNullOrWhiteSpace(tableName) || paramDict == null || paramDict.Count == 0)
                throw new ArgumentException("执行失败，参数有误。");
            if (conn == null)
                conn = GetDbConnection();

            int result = 0;
            using (conn)
            {
                conn.Open();
                OleDbCommand cmd = GetInsertCommand(tableName, paramDict, conn);
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = null;
                conn.Close();
                conn.Dispose();
            }
            return result;
        }

        /// <summary>
        /// 插入并返回新插入数据的标识符
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="paramDict">参数字典</param>
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public decimal InsertAndReturnNewIdentity(string tableName, Dictionary<string, object> paramDict, OleDbConnection conn = null)
        {
            if (string.IsNullOrWhiteSpace(tableName) || paramDict == null || paramDict.Count == 0)
                throw new ArgumentException("执行失败，参数有误。");
            if (conn == null)
                conn = GetDbConnection();

            decimal result = -1;
            using (conn)
            {
                conn.Open();
                using (OleDbTransaction trans = conn.BeginTransaction())
                {
                    OleDbCommand cmd = null;
                    try
                    {
                        cmd = GetInsertCommand(tableName, paramDict);
                        cmd.Connection = conn;
                        cmd.Transaction = trans;
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "SELECT @@IDENTITY";
                        cmd.Parameters.Clear();
                        //cmd.Transaction = trans;
                        object oResult = cmd.ExecuteScalar();
                        trans.Commit();
                        if (oResult == null)
                            throw new CommonInfoException("执行失败。");
                        if (!decimal.TryParse(oResult.ToString(), out result))
                            throw new CommonInfoException("执行失败。");
                        return result;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw new CommonInfoException("执行失败。" + Environment.NewLine + ex.Message, ex);
                    }
                    finally
                    {
                        cmd.Dispose();
                        cmd = null;
                        trans.Dispose();
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="setParamDict">set参数字典</param>
        /// <param name="whereParamDict">where参数字典</param>
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public int Update(string tableName, Dictionary<string, object> setParamDict, Dictionary<string, object> whereParamDict, OleDbConnection conn = null)
        {
            //检查whereParamDict，避免全表更新
            if (string.IsNullOrWhiteSpace(tableName) || setParamDict == null || setParamDict.Count == 0 || whereParamDict == null || whereParamDict.Count == 0)
                throw new ArgumentException("执行失败，参数有误。");
            if (conn == null)
                conn = GetDbConnection();

            int result = 0;
            using (conn)
            {
                conn.Open();
                OleDbCommand cmd = GetUpdateCommand(tableName, setParamDict, whereParamDict, conn);
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = null;
                conn.Close();
                conn.Dispose();
            }
            return result;
        }

        /// <summary>
        /// 通过某一字段及其值更新表中另一字段为另一个值
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="setFieldName">更新此字段，同时会用来做参数名</param>
        /// <param name="setParamValue">更新参数的值</param>
        /// <param name="whereFieldName">根据此字段执行更新，同时会用来做参数名</param>
        /// <param name="whereParamValue">条件参数的值</param>
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public int Update(string tableName, string setFieldName, object setParamValue, string whereFieldName, object whereParamValue, OleDbConnection conn = null)
        {
            //检查whereParamDict，避免全表更新
            if (string.IsNullOrWhiteSpace(tableName) || string.IsNullOrWhiteSpace(setFieldName) || string.IsNullOrWhiteSpace(whereFieldName))
                throw new ArgumentException("执行失败，参数有误。");
            if (conn == null)
                conn = GetDbConnection();

            int result = 0;
            using (conn)
            {
                conn.Open();
                OleDbCommand cmd = GetUpdateCommand(tableName, setFieldName, setParamValue, whereFieldName, whereParamValue, conn);
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = null;
                conn.Close();
                conn.Dispose();
            }
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="paramDict">参数字典</param>
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public int Delete(string tableName, Dictionary<string, object> paramDict, OleDbConnection conn = null)
        {
            //检查whereParamDict，避免全表更新
            if (string.IsNullOrWhiteSpace(tableName)  || paramDict == null || paramDict.Count == 0)
                throw new ArgumentException("执行失败，参数有误。");
            if (conn == null)
                conn = GetDbConnection();

            int result = 0;
            using (conn)
            {
                conn.Open();
                OleDbCommand cmd = GetDeleteCommand(tableName, paramDict, conn);
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = null;
                conn.Close();
                conn.Dispose();
            }
            return result;
        }

        /// <summary>
        /// 通过某一字段及其值执行SQL删除语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fieldName">根据此字段执行删除，同时会用来做参数名</param>
        /// <param name="paramValue">参数的值</param>
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public int Delete(string tableName, string fieldName, object paramValue, OleDbConnection conn = null)
        {
            //检查whereParamDict，避免全表更新
            if (string.IsNullOrWhiteSpace(tableName) || string.IsNullOrWhiteSpace(fieldName))
                throw new ArgumentException("执行失败，参数有误。");
            if (conn == null)
                conn = GetDbConnection();

            int result = 0;
            using (conn)
            {
                conn.Open();
                OleDbCommand cmd = GetDeleteCommand(tableName, fieldName, paramValue, conn);
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = null;
                conn.Close();
                conn.Dispose();
            }
            return result;
        }

        /// <summary>
        /// 通过参数字典获取到SQL中的Where语句部分
        /// </summary>
        /// <param name="cmd">SQL命令</param>
        /// <param name="whereParamDict">Where语句中的参数字典</param>
        /// <param name="paramPrefix">参数名前缀，用于避免和SQL语句中其他部分的参数重名。可选，默认为空字符串。</param>
        /// <returns></returns>
        private string GetCommandWhereStr(OleDbCommand cmd, Dictionary<string, object> whereParamDict, string paramPrefix = "")
        {
            if (cmd == null)
                throw new ArgumentException("参数有误。");
            if (whereParamDict == null || whereParamDict.Count == 0)
                return string.Empty;
            StringBuilder whereBuilder = new StringBuilder(" where ");
            for (int i = 0; i < whereParamDict.Count; i++)
            {
                KeyValuePair<string, object> pair = whereParamDict.ElementAt(i);
                //Access关键字需进行处理
                string fieldName = FormatFieldName(pair.Key);
                //参数名前加特定字符串，避免与set里的参数名重复
                string paramName = FormatParamName(pair.Key, paramPrefix);
                if (i == 0)
                    whereBuilder.Append(fieldName + " = @" + paramName);
                else
                    whereBuilder.Append(" and " + fieldName + " = @" + paramName);
                cmd.Parameters.AddWithValue(paramName, pair.Value ?? DBNull.Value);
            }
            return whereBuilder.ToString();
        }

        /// <summary>
        /// 获取插入命令
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="paramDict">参数字典</param>
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public OleDbCommand GetInsertCommand(string tableName, Dictionary<string, object> paramDict, OleDbConnection conn = null)
        {
            if (string.IsNullOrWhiteSpace(tableName) || paramDict == null || paramDict.Count == 0)
                throw new ArgumentException("参数有误。");

            OleDbCommand cmd = new OleDbCommand();
            if (conn != null)
                cmd.Connection = conn;
            StringBuilder fieldBuilder = new StringBuilder();
            StringBuilder paramBuilder = new StringBuilder();
            foreach (KeyValuePair<string, object> pair in paramDict)
            {
                //Access关键字需进行处理
                string fieldName = FormatFieldName(pair.Key);
                string paramName = pair.Key.StartsWith("[") && pair.Key.EndsWith("]") ? pair.Key.TrimStart('[').TrimEnd(']') : pair.Key;
                fieldBuilder.Append(fieldName + ",");
                paramBuilder.Append("@" + paramName + ",");
                //update貌似无需处理
                if (pair.Value.GetType() == typeof(DateTime))//针对DateTime类型的特殊处理，可能DateTime和OleDbType没有映射关系，不指定OleDbType会报错“System.Data.OleDb.OleDbException: 标准表达式中数据类型不匹配”
                {
                    cmd.Parameters.Add(new OleDbParameter()
                    {
                        OleDbType = OleDbType.Date,//这里试过DBDate和DBTimeStamp都不行；DBDate只会记录日期部分，DBTimeStamp报数据类型不匹配的错误
                        Value = pair.Value ?? DBNull.Value
                    });
                }
                else
                {
                    cmd.Parameters.AddWithValue(paramName, pair.Value ?? DBNull.Value);
                }
            }
            cmd.CommandText = "insert into " + tableName + " (" + fieldBuilder.ToString().TrimEnd(',') + ") values (" + paramBuilder.ToString().TrimEnd(',') + ")";
            return cmd;
        }

        /// <summary>
        /// 获取更新命令
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="setParamDict">set参数字典</param>
        /// <param name="whereParamDict">where参数字典</param>
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public OleDbCommand GetUpdateCommand(string tableName, Dictionary<string, object> setParamDict, Dictionary<string, object> whereParamDict, OleDbConnection conn = null)
        {
            //检查whereParamDict，避免全表更新
            if (string.IsNullOrWhiteSpace(tableName) || setParamDict == null || setParamDict.Count == 0 || whereParamDict == null || whereParamDict.Count == 0)
                throw new ArgumentException("参数有误。");

            OleDbCommand cmd = new OleDbCommand();
            if (conn != null)
                cmd.Connection = conn;
            StringBuilder setBuilder = new StringBuilder();
            foreach (KeyValuePair<string, object> pair in setParamDict)
            {
                //Access关键字需进行处理
                string fieldName = FormatFieldName(pair.Key);
                string paramName = FormatParamName(pair.Key);
                setBuilder.Append(fieldName + " = @" + paramName + ",");
                cmd.Parameters.AddWithValue(paramName, pair.Value ?? DBNull.Value);
            }
            //StringBuilder whereBuilder = new StringBuilder();
            //for (int i = 0; i < whereParamDict.Count; i++)
            //{
            //    KeyValuePair<string, object> pair = whereParamDict.ElementAt(i);
            //    //Access关键字需进行处理
            //    string fieldName = CommonData.AccessKeyword.Contains(pair.Key) ? "[" + pair.Key + "]" : pair.Key;
            //    string paramName = pair.Key.StartsWith("[") && pair.Key.EndsWith("]") ? pair.Key.TrimStart('[').TrimEnd(']') : pair.Key;
            //    //参数名前加特定字符串，避免与set里的参数名重复
            //    if (i == 0)
            //        whereBuilder.Append(fieldName + " = @Where" + paramName);
            //    else
            //        whereBuilder.Append(" and " + fieldName + " = @Where" + paramName);
            //    cmd.Parameters.AddWithValue("Where" + paramName, pair.Value ?? DBNull.Value);
            //}
            //cmd.CommandText = "update " + tableName + " set " + setBuilder.ToString().TrimEnd(',') + " where " + whereBuilder.ToString();
            cmd.CommandText = "update " + tableName + " set " + setBuilder.ToString().TrimEnd(',') + GetCommandWhereStr(cmd, whereParamDict, "Where");
            return cmd;
        }

        /// <summary>
        /// 获取通过某一字段及其值更新表中另一字段为另一个值的命令
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="setFieldName">更新此字段，同时会用来做参数名</param>
        /// <param name="setParamValue">更新参数的值</param>
        /// <param name="whereFieldName">根据此字段执行更新，同时会用来做参数名</param>
        /// <param name="whereParamValue">条件参数的值</param>
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public OleDbCommand GetUpdateCommand(string tableName, string setFieldName, object setParamValue, string whereFieldName, object whereParamValue, OleDbConnection conn = null)
        {
            //检查whereParamDict，避免全表更新
            if (string.IsNullOrWhiteSpace(tableName) || string.IsNullOrWhiteSpace(setFieldName) || string.IsNullOrWhiteSpace(whereFieldName))
                throw new ArgumentException("参数有误。");

            OleDbCommand cmd = new OleDbCommand();
            if (conn != null)
                cmd.Connection = conn;
            //Access关键字需进行处理
            string setParamName = FormatParamName(setFieldName);
            setFieldName = FormatFieldName(setFieldName);
            string whereParamName = FormatParamName(whereFieldName);
            whereFieldName = FormatFieldName(whereFieldName);
            //判断set的参数名和where的参数名是否相同，相同则进行处理
            if (whereParamName.ToLower() == setParamName.ToLower())
                whereParamName = "Where" + whereParamName;
            cmd.CommandText = "update " + tableName + " set " + setFieldName + " = @" + setParamName + " where " + whereFieldName + " = @" + whereParamName;
            cmd.Parameters.AddWithValue(setParamName, setParamValue ?? DBNull.Value);
            cmd.Parameters.AddWithValue(whereParamName, whereParamValue ?? DBNull.Value);
            return cmd;
        }

        /// <summary>
        /// 获取删除命令
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="paramDict">参数字典</param>
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public OleDbCommand GetDeleteCommand(string tableName, Dictionary<string, object> paramDict, OleDbConnection conn = null)
        {
            //检查whereParamDict，避免全表更新
            if (string.IsNullOrWhiteSpace(tableName) || paramDict == null || paramDict.Count == 0)
                throw new ArgumentException("参数有误。");

            OleDbCommand cmd = new OleDbCommand();
            if (conn != null)
                cmd.Connection = conn;
            //StringBuilder whereBuilder = new StringBuilder();
            //for (int i = 0; i < paramDict.Count; i++)
            //{
            //    KeyValuePair<string, object> pair = paramDict.ElementAt(i);
            //    //Access关键字需进行处理
            //    string fieldName = CommonData.AccessKeyword.Contains(pair.Key) ? "[" + pair.Key + "]" : pair.Key;
            //    string paramName = pair.Key.StartsWith("[") && pair.Key.EndsWith("]") ? pair.Key.TrimStart('[').TrimEnd(']') : pair.Key;
            //    //参数名前加特定字符串，避免与set里的参数名重复
            //    if (i == 0)
            //        whereBuilder.Append(fieldName + " = @" + paramName);
            //    else
            //        whereBuilder.Append(" and " + fieldName + " = @" + paramName);
            //    cmd.Parameters.AddWithValue(paramName, pair.Value ?? DBNull.Value);
            //}
            //cmd.CommandText = "delete from " + tableName + " where " + whereBuilder.ToString();
            cmd.CommandText = "delete from " + tableName + GetCommandWhereStr(cmd, paramDict);
            return cmd;
        }

        /// <summary>
        /// 获取通过某一字段及其值执行SQL删除语句的命令
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fieldName">根据此字段执行删除，同时会用来做参数名</param>
        /// <param name="paramValue">参数的值</param>
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public OleDbCommand GetDeleteCommand(string tableName, string fieldName, object paramValue, OleDbConnection conn = null)
        {
            //检查whereParamDict，避免全表更新
            if (string.IsNullOrWhiteSpace(tableName) || string.IsNullOrWhiteSpace(fieldName))
                throw new ArgumentException("执行失败，参数有误。");

            OleDbCommand cmd = new OleDbCommand();
            if (conn != null)
                cmd.Connection = conn;
            //Access关键字需进行处理
            string paramName = FormatParamName(fieldName);
            fieldName = FormatFieldName(fieldName);
            cmd.CommandText = "delete from " + tableName + " where " + fieldName + " = @" + paramName;
            cmd.Parameters.AddWithValue(paramName, paramValue ?? DBNull.Value);
            return cmd;
        }

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="command">要执行的命令</param>
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public int Execute(OleDbCommand command, OleDbConnection conn = null)
        {
            if (command == null || string.IsNullOrWhiteSpace(command.CommandText))
                throw new ArgumentException("执行失败，参数有误。");
            if (conn == null)
                conn = GetDbConnection();

            int result = 0;
            using (conn)
            {
                conn.Open();
                command.Connection = conn;
                result = command.ExecuteNonQuery();
                command.Dispose();
                command = null;
                conn.Close();
                conn.Dispose();
            }
            return result;
        }

        /// <summary>
        /// 使用事务执行命令列表
        /// </summary>
        /// <param name="commandList">要执行的命令列表</param>
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public bool ExecuteByTransaction(List<OleDbCommand> commandList, OleDbConnection conn = null)
        {
            if (commandList == null || commandList.Count == 0)
                throw new ArgumentException("执行失败，参数有误。");
            if (conn == null)
                conn = GetDbConnection();

            using (conn)
            {
                conn.Open();
                using (OleDbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (OleDbCommand command in commandList)
                        {
                            command.Connection = conn;
                            command.Transaction = trans;
                            command.ExecuteNonQuery();
                        }
                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw new CommonInfoException("执行失败。" + Environment.NewLine + ex.Message, ex);
                    }
                    finally
                    {
                        for (int i = 0; i < commandList.Count-1; i++)
                        {
                            OleDbCommand command = commandList[i];
                            command.Dispose();
                            command = null;
                        }
                        trans.Dispose();
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }
        }
    }
}
