using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;

namespace Common
{
    /// <summary>
    /// SQLite帮助类
    /// </summary>
    public class SQLiteHelper
    {
        /// <summary>
        /// 数据库连接语句
        /// </summary>
        private string dbConnectionString = string.Empty;
        /// <summary>
        /// 数据库连接
        /// </summary>
        private SQLiteConnection dbConnection = null;

        public SQLiteHelper()
        {
            SetDbString();
            SetDbConnection();
        }

        /// <summary>
        /// 初始化数据库连接
        /// </summary>
        /// <param name="dataSource">数据源</param>
        public SQLiteHelper(string dataSource)
        {
            //connStr = "data source=" + dataSource + ";";
            SetDbString(dataSource);
            SetDbConnection();
        }

        ///// <summary>
        ///// 初始化数据库连接
        ///// </summary>
        ///// <param name="dataSource">数据源</param>
        ///// <param name="password">密码</param>
        //public SQLiteHelper(string dataSource, string password)
        //{
        //    //dbConnectionString = "data source=" + dataSource + ";password=" + password;
        //    SetDbString(dataSource, password);
        //    SetDbConnection();
        //}

        /// <summary>
        /// 设置数据库连接字符串
        /// </summary>
        /// <param name="dataSource">数据源</param>
        private void SetDbString(string dataSource = null, string password = null)
        {
            if (string.IsNullOrWhiteSpace(dataSource))
                dataSource = Environment.CurrentDirectory + "\\DB\\DB.db";
            if (!File.Exists(dataSource))
            {
                throw new FileNotFoundException("数据库文件不存在");
            }
            if (string.IsNullOrWhiteSpace(password))
                dbConnectionString = "data source=" + dataSource + ";";
            else
                dbConnectionString = "data source=" + dataSource + ";password=" + password;
        }

        /// <summary>
        /// 设置数据库连接
        /// </summary>
        /// <param name="connStr">连接语句</param>
        private void SetDbConnection(string connStr = null)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(connStr))
                {
                    if (dbConnection == null)
                    {
                        if (!string.IsNullOrWhiteSpace(dbConnectionString))
                        {
                            dbConnection = new SQLiteConnection(dbConnectionString);
                            return;
                        }
                        else
                            throw new ArgumentException("没有连接语句");
                    }
                }
                if (connStr.Trim().ToLower() == dbConnectionString.Trim().ToLower())
                {
                    if (dbConnection == null)
                        dbConnection = new SQLiteConnection(connStr);
                }
                else
                {
                    dbConnectionString = connStr;
                    dbConnection = new SQLiteConnection(dbConnectionString);
                }
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <param name="connStr">数据库连接语句</param>
        /// <returns></returns>
        public SQLiteConnection GetDbConnection(string connStr = null)
        {
            //if (string.IsNullOrWhiteSpace(connStr))
            //{
            //    connStr = dbConnectionString;
            //    if (dbConnection != null)
            //        return dbConnection;
            //}
            //if (connStr.Trim().ToLower() == dbConnectionString.Trim().ToLower() && dbConnection != null)
            //{
            //    return dbConnection;
            //}
            //else
            //{
            //    try
            //    {
            //        dbConnection = new SQLiteConnection(connStr);
            //        return dbConnection;
            //    }
            //    catch (SQLiteException ex)
            //    {
            //        throw ex;
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}
            ////此逻辑建立在实例化SQLiteHelper时已设置数据库连接的基础上
            //if (!string.IsNullOrWhiteSpace(connStr))
            //    SetDbConnection(connStr);
            //return dbConnection;

            if (string.IsNullOrWhiteSpace(connStr))
                connStr = dbConnectionString;
            try
            {
                return new SQLiteConnection(connStr);
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 通过查询获取DataTable
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql)
        {
            if (string.IsNullOrWhiteSpace(sql))
                return null;
            SQLiteConnection conn = GetDbConnection();

            SQLiteDataAdapter da = null;
            try
            {
                DataTable dt = new DataTable();
                using (conn)
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = sql;
                        cmd.CommandType = CommandType.Text;
                        da = new SQLiteDataAdapter(cmd);
                        da.Fill(dt);
                        cmd.Dispose();
                    }
                    //da = new SQLiteDataAdapter(sql, conn);
                    //if (paramDict != null && paramDict.Count > 0)
                    //{
                    //    foreach (KeyValuePair<string, object> pair in paramDict)
                    //        da.SelectCommand.Parameters.AddWithValue(pair.Key, pair.Value ?? DBNull.Value);
                    //}
                    //da.Fill(dt);
                    conn.Close();
                    conn.Dispose();
                }
                return dt;
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (da != null)
                {
                    da.Dispose();
                    da = null;
                }
            }
        }

        ///// <summary>
        ///// 通过查询获取DataTable
        ///// </summary>
        ///// <param name="sql">查询语句</param>
        ///// <param name="conn">数据库连接</param>
        ///// <returns></returns>
        //public DataTable GetDataTable(string sql, SQLiteConnection conn = null)
        //{
        //    if (string.IsNullOrWhiteSpace(sql))
        //        return null;
        //    if (conn == null)
        //        conn = GetDbConnection();

        //    SQLiteDataAdapter da = null;
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        using (conn)
        //        {
        //            conn.Open();
        //            using (SQLiteCommand cmd = new SQLiteCommand())
        //            {
        //                cmd.Connection = conn;
        //                cmd.CommandText = sql;
        //                cmd.CommandType = CommandType.Text;
        //                da = new SQLiteDataAdapter(cmd);
        //                da.Fill(dt);
        //                cmd.Dispose();
        //            }
        //            //da = new SQLiteDataAdapter(sql, conn);
        //            //if (paramDict != null && paramDict.Count > 0)
        //            //{
        //            //    foreach (KeyValuePair<string, object> pair in paramDict)
        //            //        da.SelectCommand.Parameters.AddWithValue(pair.Key, pair.Value ?? DBNull.Value);
        //            //}
        //            //da.Fill(dt);
        //            conn.Close();
        //            conn.Dispose();
        //        }
        //        return dt;
        //    }
        //    catch (SQLiteException ex)
        //    {
        //        throw ex;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (da != null)
        //        {
        //            da.Dispose();
        //            da = null;
        //        }
        //    }
        //}

        /// <summary>
        /// 通过查询获取DataTable
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="paramDict">参数字典</param>
        ///// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql, IDictionary<string, object> paramDict = null)//, SQLiteConnection conn = null
        {
            if (string.IsNullOrWhiteSpace(sql))
                return null;
            //if (conn == null)
            //    conn = GetDbConnection();
            SQLiteConnection conn = GetDbConnection();

            SQLiteDataAdapter da = null;
            try
            {
                DataTable dt = new DataTable();
                using (conn)
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = sql;
                        cmd.CommandType = CommandType.Text;
                        if (paramDict != null && paramDict.Count > 0)
                        {
                            foreach (KeyValuePair<string, object> pair in paramDict)
                                cmd.Parameters.AddWithValue(pair.Key, pair.Value ?? DBNull.Value);
                        }
                        da = new SQLiteDataAdapter(cmd);
                        da.Fill(dt);
                        cmd.Dispose();
                    }
                    //da = new SQLiteDataAdapter(sql, conn);
                    //if (paramDict != null && paramDict.Count > 0)
                    //{
                    //    foreach (KeyValuePair<string, object> pair in paramDict)
                    //        da.SelectCommand.Parameters.AddWithValue(pair.Key, pair.Value ?? DBNull.Value);
                    //}
                    //da.Fill(dt);
                    conn.Close();
                    conn.Dispose();
                }
                return dt;
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (da != null)
                {
                    da.Dispose();
                    da = null;
                }
            }
        }

        /// <summary>
        /// 通过查询获取DataTable
        /// </summary>
        /// <param name="tableName">查询表名</param>
        /// <param name="fieldList">查询的字段列表</param>
        /// <param name="whereParamDict">Where语句中的参数字典</param>
        ///// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public DataTable GetDataTable(string tableName, IEnumerable<string> fieldList = null, IDictionary<string, object> whereParamDict = null)//, SQLiteConnection conn = null
        {
            if (string.IsNullOrWhiteSpace(tableName))
                return null;
            //if (conn == null)
            //    conn = GetDbConnection();
            SQLiteConnection conn = GetDbConnection();

            SQLiteDataAdapter da = null;
            try
            {
                DataTable dt = new DataTable();
                using (conn)
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand())
                    {
                        cmd.Connection = conn;
                        string sql = "select ";
                        if (fieldList != null && fieldList.Count() > 0)
                            sql += string.Join(",", fieldList);
                        else
                            sql += "*";
                        sql += " from " + tableName;
                        if (whereParamDict != null && whereParamDict.Count > 0)
                            sql += GetCommandWhereStr(cmd, whereParamDict);
                        cmd.CommandText = sql;
                        cmd.CommandType = CommandType.Text;
                        da = new SQLiteDataAdapter(cmd);
                        da.Fill(dt);
                        cmd.Dispose();
                    }
                    //da = new SQLiteDataAdapter(sql, conn);
                    //if (paramDict != null && paramDict.Count > 0)
                    //{
                    //    foreach (KeyValuePair<string, object> pair in paramDict)
                    //        da.SelectCommand.Parameters.AddWithValue(pair.Key, pair.Value ?? DBNull.Value);
                    //}
                    //da.Fill(dt);
                    conn.Close();
                    conn.Dispose();
                }
                return dt;
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (da != null)
                {
                    da.Dispose();
                    da = null;
                }
            }
        }

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="paramDict">参数字典</param>
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, IDictionary<string, object> paramDict = null, SQLiteConnection conn = null)
        {
            if (string.IsNullOrWhiteSpace(sql))
                return 0;
            if (conn == null)
                conn = GetDbConnection();

            SQLiteCommand cmd = null;
            try
            {
                int result = 0;
                using (conn)
                {
                    conn.Open();
                    cmd = conn.CreateCommand();
                    cmd.CommandText = sql;
                    if (paramDict != null && paramDict.Count > 0)
                    {
                        foreach (KeyValuePair<string, object> pair in paramDict)
                            cmd.Parameters.AddWithValue(pair.Key, pair.Value ?? DBNull.Value);
                    }
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                }
                return result;
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                    cmd = null;
                }
            }
        }

        /// <summary>
        /// 执行命令获取查询结果中第0行第0列的值
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="paramDict">参数字典</param>
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public object ExecuteScalar(string sql, IDictionary<string, object> paramDict = null)//, SQLiteConnection conn = null
        {
            if (string.IsNullOrWhiteSpace(sql))
                return null;
            //if (conn == null)
            //    conn = GetDbConnection();
            SQLiteConnection conn = GetDbConnection();

            SQLiteCommand cmd = null;
            try
            {
                object o = null;
                using (conn)
                {
                    conn.Open();
                    cmd = conn.CreateCommand();
                    cmd.CommandText = sql;
                    if (paramDict != null && paramDict.Count > 0)
                    {
                        foreach (KeyValuePair<string, object> pair in paramDict)
                            cmd.Parameters.AddWithValue(pair.Key, pair.Value ?? DBNull.Value);
                    }
                    o = cmd.ExecuteScalar();
                    conn.Close();
                    conn.Dispose();
                }
                return o;
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                    cmd = null;
                }
            }
        }

        ///// <summary>
        ///// 格式化字段名
        ///// </summary>
        ///// <param name="fieldName">要格式化的原始字段名</param>
        ///// <returns></returns>
        //public string FormatFieldName(string fieldName)
        //{
        //    return CommonData.IsAccessKeyword(fieldName) ? "[" + fieldName + "]" : fieldName;
        //}

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
        ///// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public int Insert(string tableName, IDictionary<string, object> paramDict)//, SQLiteConnection conn = null
        {
            if (string.IsNullOrWhiteSpace(tableName) || paramDict == null || paramDict.Count == 0)
                throw new ArgumentException("执行失败，参数有误。");
            //if (conn == null)
            //    conn = GetDbConnection();
            SQLiteConnection conn = GetDbConnection();

            SQLiteCommand cmd = null;
            try
            {
                int result = 0;
                using (conn)
                {
                    conn.Open();
                    cmd = GetInsertCommand(tableName, paramDict, conn);
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                }
                return result;
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                    cmd = null;
                }
            }
        }

        /// <summary>
        /// 插入并返回自增ID
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="paramDict">参数字典</param>
        ///// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public long InsertAndReturnNewIdentity(string tableName, IDictionary<string, object> paramDict)//, SQLiteConnection conn = null
        {
            if (string.IsNullOrWhiteSpace(tableName) || paramDict == null || paramDict.Count == 0)
                throw new ArgumentException("执行失败，参数有误。");
            //if (conn == null)
            //    conn = GetDbConnection();
            SQLiteConnection conn = GetDbConnection();

            SQLiteCommand cmd = null;
            try
            {
                long result = 0;
                using (conn)
                {
                    conn.Open();
                    cmd = new SQLiteCommand();
                    cmd.Connection = conn;
                    StringBuilder fieldBuilder = new StringBuilder();
                    StringBuilder paramBuilder = new StringBuilder();
                    foreach (KeyValuePair<string, object> pair in paramDict)
                    {
                        ////Access关键字需进行处理
                        //string fieldName = FormatFieldName(pair.Key);
                        string fieldName = pair.Key;
                        string paramName = pair.Key.StartsWith("[") && pair.Key.EndsWith("]") ? pair.Key.TrimStart('[').TrimEnd(']') : pair.Key;
                        fieldBuilder.Append(fieldName + ",");
                        paramBuilder.Append("@" + paramName + ",");
                        //update貌似无需处理
                        if (pair.Value.GetType() == typeof(DateTime))//针对DateTime类型的特殊处理，可能DateTime和OleDbType没有映射关系，不指定OleDbType会报错“System.Data.OleDb.OleDbException: 标准表达式中数据类型不匹配”
                        {
                            cmd.Parameters.Add(new SQLiteParameter()
                            {
                                DbType = DbType.Date,//这里试过DBDate和DBTimeStamp都不行；DBDate只会记录日期部分，DBTimeStamp报数据类型不匹配的错误
                                Value = pair.Value ?? DBNull.Value
                            });
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(paramName, pair.Value ?? DBNull.Value);
                        }
                    }
                    cmd.CommandText = "insert into " + tableName + " (" + fieldBuilder.ToString().TrimEnd(',') + ") values (" + paramBuilder.ToString().TrimEnd(',') + ");select last_insert_rowid();";// from tableName
                    object oResult = cmd.ExecuteScalar();
                    if (oResult == null || !long.TryParse(oResult.ToString(), out result))
                        throw new Exception("数据插入失败或返回值有误");
                    conn.Close();
                    conn.Dispose();
                }
                return result;
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                    cmd = null;
                }
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="setParamDict">set参数字典</param>
        /// <param name="whereParamDict">where参数字典</param>
        ///// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public int Update(string tableName, IDictionary<string, object> setParamDict, IDictionary<string, object> whereParamDict) //, SQLiteConnection conn = null
        {
            //检查whereParamDict，避免全表更新
            if (string.IsNullOrWhiteSpace(tableName) || setParamDict == null || setParamDict.Count == 0 || whereParamDict == null || whereParamDict.Count == 0)
                throw new ArgumentException("执行失败，参数有误。");
            //if (conn == null)
            //    conn = GetDbConnection();
            SQLiteConnection conn = GetDbConnection();

            SQLiteCommand cmd = null;
            try
            {
                int result = 0;
                using (conn)
                {
                    conn.Open();
                    cmd = GetUpdateCommand(tableName, setParamDict, whereParamDict, conn);
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                }
                return result;
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                    cmd = null;
                }
            }
        }

        /// <summary>
        /// 通过某一字段及其值更新表中另一字段为另一个值
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="setFieldName">更新此字段，同时会用来做参数名</param>
        /// <param name="setParamValue">更新参数的值</param>
        /// <param name="whereFieldName">根据此字段执行更新，同时会用来做参数名</param>
        /// <param name="whereParamValue">条件参数的值</param>
        ///// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public int Update(string tableName, string setFieldName, object setParamValue, string whereFieldName, object whereParamValue)//, SQLiteConnection conn = null
        {
            //检查whereParamDict，避免全表更新
            if (string.IsNullOrWhiteSpace(tableName) || string.IsNullOrWhiteSpace(setFieldName) || string.IsNullOrWhiteSpace(whereFieldName))
                throw new ArgumentException("执行失败，参数有误。");
            //if (conn == null)
            //    conn = GetDbConnection();
            SQLiteConnection conn = GetDbConnection();

            SQLiteCommand cmd = null;
            try
            {
                int result = 0;
                using (conn)
                {
                    conn.Open();
                    cmd = GetUpdateCommand(tableName, setFieldName, setParamValue, whereFieldName, whereParamValue, conn);
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                }
                return result;
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                    cmd = null;
                }
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="paramDict">参数字典</param>
        ///// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public int Delete(string tableName, IDictionary<string, object> paramDict)//, SQLiteConnection conn = null
        {
            //检查whereParamDict，避免全表更新
            if (string.IsNullOrWhiteSpace(tableName) || paramDict == null || paramDict.Count == 0)
                throw new ArgumentException("执行失败，参数有误。");
            //if (conn == null)
            //    conn = GetDbConnection();
            SQLiteConnection conn = GetDbConnection();

            SQLiteCommand cmd = null;
            try
            {
                int result = 0;
                using (conn)
                {
                    conn.Open();
                    cmd = GetDeleteCommand(tableName, paramDict, conn);
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                }
                return result;
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                    cmd = null;
                }
            }
        }

        /// <summary>
        /// 通过某一字段及其值执行SQL删除语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fieldName">根据此字段执行删除，同时会用来做参数名</param>
        /// <param name="paramValue">参数的值</param>
        ///// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public int Delete(string tableName, string fieldName, object paramValue)//, SQLiteConnection conn = null
        {
            //检查whereParamDict，避免全表更新
            if (string.IsNullOrWhiteSpace(tableName) || string.IsNullOrWhiteSpace(fieldName))
                throw new ArgumentException("执行失败，参数有误。");
            //if (conn == null)
            //    conn = GetDbConnection();
            SQLiteConnection conn = GetDbConnection();

            SQLiteCommand cmd = null;
            try
            {
                int result = 0;
                using (conn)
                {
                    conn.Open();
                    cmd = GetDeleteCommand(tableName, fieldName, paramValue, conn);
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                }
                return result;
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                    cmd = null;
                }
            }
        }

        /// <summary>
        /// 表中是否存在
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="whereParamDict">where参数字典</param>
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public bool Exists(string tableName, IDictionary<string, object> whereParamDict = null, SQLiteConnection conn = null)
        {
            if (string.IsNullOrWhiteSpace(tableName))
                throw new ArgumentException("执行失败，参数有误。");
            if (conn == null)
                conn = GetDbConnection();

            SQLiteCommand cmd = null;
            try
            {
                bool result = false;
                using (conn)
                {
                    conn.Open();
                    DataTable dt = GetDataTable(tableName, null, whereParamDict);
                    result = dt.Rows.Count > 0;
                    conn.Close();
                    conn.Dispose();
                }
                return result;
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                    cmd = null;
                }
            }
        }

        /// <summary>
        /// 通过参数字典获取到SQL中的Where语句部分
        /// </summary>
        /// <param name="cmd">SQL命令</param>
        /// <param name="whereParamDict">Where语句中的参数字典</param>
        /// <param name="paramPrefix">参数名前缀，用于避免和SQL语句中其他部分的参数重名。可选，默认为空字符串。</param>
        /// <returns></returns>
        private string GetCommandWhereStr(SQLiteCommand cmd, IDictionary<string, object> whereParamDict, string paramPrefix = "")
        {
            if (cmd == null)
                throw new ArgumentException("参数有误。");
            if (whereParamDict == null || whereParamDict.Count == 0)
                return string.Empty;
            StringBuilder whereBuilder = new StringBuilder(" where ");
            for (int i = 0; i < whereParamDict.Count; i++)
            {
                KeyValuePair<string, object> pair = whereParamDict.ElementAt(i);
                ////Access关键字需进行处理
                //string fieldName = FormatFieldName(pair.Key);
                string fieldName = pair.Key;
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
        public SQLiteCommand GetInsertCommand(string tableName, IDictionary<string, object> paramDict, SQLiteConnection conn = null)
        {
            if (string.IsNullOrWhiteSpace(tableName) || paramDict == null || paramDict.Count == 0)
                throw new ArgumentException("参数有误。");

            SQLiteCommand cmd = new SQLiteCommand();
            if (conn != null)
                cmd.Connection = conn;
            StringBuilder fieldBuilder = new StringBuilder();
            StringBuilder paramBuilder = new StringBuilder();
            foreach (KeyValuePair<string, object> pair in paramDict)
            {
                ////Access关键字需进行处理
                //string fieldName = FormatFieldName(pair.Key);
                string fieldName = pair.Key;
                string paramName = pair.Key.StartsWith("[") && pair.Key.EndsWith("]") ? pair.Key.TrimStart('[').TrimEnd(']') : pair.Key;
                fieldBuilder.Append(fieldName + ",");
                paramBuilder.Append("@" + paramName + ",");
                //update貌似无需处理
                if (pair.Value.GetType() == typeof(DateTime))//针对DateTime类型的特殊处理，可能DateTime和OleDbType没有映射关系，不指定OleDbType会报错“System.Data.OleDb.OleDbException: 标准表达式中数据类型不匹配”
                {
                    cmd.Parameters.Add(new SQLiteParameter()
                    {
                        DbType = DbType.Date,//这里试过DBDate和DBTimeStamp都不行；DBDate只会记录日期部分，DBTimeStamp报数据类型不匹配的错误
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
        public SQLiteCommand GetUpdateCommand(string tableName, IDictionary<string, object> setParamDict, IDictionary<string, object> whereParamDict, SQLiteConnection conn = null)
        {
            //检查whereParamDict，避免全表更新
            if (string.IsNullOrWhiteSpace(tableName) || setParamDict == null || setParamDict.Count == 0 || whereParamDict == null || whereParamDict.Count == 0)
                throw new ArgumentException("参数有误。");

            SQLiteCommand cmd = new SQLiteCommand();
            if (conn != null)
                cmd.Connection = conn;
            StringBuilder setBuilder = new StringBuilder();
            foreach (KeyValuePair<string, object> pair in setParamDict)
            {
                ////Access关键字需进行处理
                //string fieldName = FormatFieldName(pair.Key);
                string fieldName = pair.Key;
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
        public SQLiteCommand GetUpdateCommand(string tableName, string setFieldName, object setParamValue, string whereFieldName, object whereParamValue, SQLiteConnection conn = null)
        {
            //检查whereParamDict，避免全表更新
            if (string.IsNullOrWhiteSpace(tableName) || string.IsNullOrWhiteSpace(setFieldName) || string.IsNullOrWhiteSpace(whereFieldName))
                throw new ArgumentException("参数有误。");

            SQLiteCommand cmd = new SQLiteCommand();
            if (conn != null)
                cmd.Connection = conn;
            //Access关键字需进行处理
            string setParamName = FormatParamName(setFieldName);
            //setFieldName = FormatFieldName(setFieldName);
            string whereParamName = FormatParamName(whereFieldName);
            //whereFieldName = FormatFieldName(whereFieldName);
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
        public SQLiteCommand GetDeleteCommand(string tableName, IDictionary<string, object> paramDict, SQLiteConnection conn = null)
        {
            //检查whereParamDict，避免全表更新
            if (string.IsNullOrWhiteSpace(tableName) || paramDict == null || paramDict.Count == 0)
                throw new ArgumentException("参数有误。");

            SQLiteCommand cmd = new SQLiteCommand();
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
        public SQLiteCommand GetDeleteCommand(string tableName, string fieldName, object paramValue, SQLiteConnection conn = null)
        {
            //检查whereParamDict，避免全表更新
            if (string.IsNullOrWhiteSpace(tableName) || string.IsNullOrWhiteSpace(fieldName))
                throw new ArgumentException("执行失败，参数有误。");

            SQLiteCommand cmd = new SQLiteCommand();
            if (conn != null)
                cmd.Connection = conn;
            //Access关键字需进行处理
            string paramName = FormatParamName(fieldName);
            //fieldName = FormatFieldName(fieldName);
            cmd.CommandText = "delete from " + tableName + " where " + fieldName + " = @" + paramName;
            cmd.Parameters.AddWithValue(paramName, paramValue ?? DBNull.Value);
            return cmd;
        }

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="cmd">要执行的命令</param>
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public int Execute(SQLiteCommand cmd, SQLiteConnection conn = null)
        {
            if (cmd == null || string.IsNullOrWhiteSpace(cmd.CommandText))
                throw new ArgumentException("执行失败，参数有误。");
            if (conn == null)
                conn = GetDbConnection();

            try
            {
                int result = 0;
                using (conn)
                {
                    conn.Open();
                    cmd.Connection = conn;
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                }
                return result;
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                    cmd = null;
                }
            }
        }

        /// <summary>
        /// 使用事务执行命令列表
        /// </summary>
        /// <param name="cmdList">要执行的命令列表</param>
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public bool ExecuteByTransaction(IEnumerable<SQLiteCommand> cmdList, SQLiteConnection conn = null)
        {
            if (cmdList == null || cmdList.Count() == 0)
                throw new ArgumentException("执行失败，参数有误。");
            if (conn == null)
                conn = GetDbConnection();

            try
            {
                using (conn)
                {
                    conn.Open();
                    using (SQLiteTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            foreach (SQLiteCommand command in cmdList)
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
                            //throw new CommonInfoException("执行失败。" + Environment.NewLine + ex.Message, ex);
                            throw ex;
                        }
                        finally
                        {
                            for (int i = 0; i < cmdList.Count() - 1; i++)
                            {
                                SQLiteCommand command = cmdList.ElementAt(i);
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
            catch (SQLiteException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region "wasted"
        ///// <summary>
        ///// 连接数据库
        ///// </summary>
        ///// <returns></returns>
        //public bool Connect()
        //{
        //    try
        //    {
        //        if (dbConnection != null)
        //        {
        //            dbConnection.Close();
        //            dbConnection = null;
        //        }

        //        dbConnection = new SQLiteConnection(dbConnectionString);
        //        dbConnection.Open();
        //        if (dbConnection == null)
        //        {
        //            return false;
        //        }
        //        return true;
        //    }
        //    catch (SQLiteException ex)
        //    {
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(ex.Message + "\n\n" + ex.Source + "\n\n" + ex.StackTrace + "\n\n" + ex.Data);
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// 修改数据库密码
        ///// </summary>
        ///// <param name="newPassword"></param>
        ///// <returns></returns>
        //public bool ChangePassword(string newPassword)
        //{
        //    try
        //    {
        //        dbConnection.ChangePassword(newPassword);
        //        return true;
        //    }
        //    catch (SQLiteException ex)
        //    {
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// 关闭数据库连接
        ///// </summary>
        ///// <returns></returns>
        //public bool Disconnect()
        //{
        //    try
        //    {
        //        if (dbConnection != null)
        //        {
        //            dbConnection.Close();
        //            dbConnection = null;
        //        }
        //        return true;
        //    }
        //    catch (SQLiteException ex)
        //    {
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// 执行一个查询语句，返回一个包含查询结果的DataTable
        ///// </summary>
        ///// <param name="sql">要执行的查询语句</param>
        ///// <param name="parameters">执行SQL查询语句所需要的参数，参数必须以它们在SQL语句中的顺序为准</param>
        ///// <returns></returns>
        //public DataTable ExecuteDataTable(string sql, SQLiteParameter[] parameters)
        //{
        //    try
        //    {
        //        using (SQLiteCommand command = new SQLiteCommand(sql, dbConnection))
        //        {
        //            if (parameters != null)
        //            {
        //                command.Parameters.AddRange(parameters);
        //            }
        //            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
        //            DataTable dataTable = new DataTable();
        //            adapter.Fill(dataTable);
        //            return dataTable;
        //        }
        //    }
        //    catch (SQLiteException ex)
        //    {
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        ///// <summary> 
        ///// 对SQLite数据库执行增删改操作，返回受影响的行数。 
        ///// </summary> 
        ///// <param name="sql">要执行的增删改的SQL语句</param> 
        ///// <param name="parameters">执行增删改语句所需要的参数，参数必须以它们在SQL语句中的顺序为准</param> 
        ///// <returns></returns> 
        //public int ExecuteNonQuery(string sql, SQLiteParameter[] parameters)
        //{
        //    int affectRows = 0;

        //    try
        //    {
        //        using (SQLiteTransaction transaction = dbConnection.BeginTransaction())
        //        {
        //            using (SQLiteCommand command = new SQLiteCommand(sql, dbConnection, transaction))
        //            {
        //                if (parameters != null)
        //                {
        //                    command.Parameters.AddRange(parameters);
        //                }
        //                affectRows = command.ExecuteNonQuery();
        //            }
        //            transaction.Commit();
        //        }
        //    }
        //    catch (SQLiteException ex)
        //    {
        //        affectRows = -1;
        //    }
        //    catch (Exception ex)
        //    {
        //        affectRows = -1;
        //    }
        //    return affectRows;
        //}

        ///// <summary>
        ///// 收缩数据库
        ///// </summary>
        ///// <returns></returns>
        //public bool Vacuum()
        //{
        //    try
        //    {
        //        using (SQLiteCommand command = new SQLiteCommand("VACUUM", dbConnection))
        //        {
        //            command.ExecuteNonQuery();
        //        }
        //        return true;
        //    }
        //    catch (SQLiteException ex)
        //    {
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// 开始事务
        ///// </summary>
        //public void BeginTransaction()
        //{
        //    try
        //    {
        //        transaction = dbConnection.BeginTransaction();
        //    }
        //    catch (SQLiteException ex) { }
        //    catch (Exception ex) { }
        //}

        ///// <summary>
        ///// 提交事务
        ///// </summary>
        //public void CommitTransaction()
        //{
        //    try
        //    {
        //        transaction.Commit();
        //    }
        //    catch (SQLiteException ex) { }
        //    catch (Exception ex) { }
        //}

        ///// <summary>
        ///// 回滚事务
        ///// </summary>
        //public void RollbackTransaction()
        //{
        //    try
        //    {
        //        transaction.Rollback();
        //    }
        //    catch (SQLiteException ex) { }
        //    catch (Exception ex) { }
        //}
        #endregion
    }

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

        ///// <summary>
        ///// 给where语句新增参数，返回SQL语句的查询条件
        ///// </summary>
        ///// <param name="fieldName">SQL语句中字段的名称，同时用作参数的名称</param>
        ///// <param name="textBox">从中取参数的值的TextBox控件</param>
        ///// <param name="tableName">表的名称或别名</param>
        ///// <returns></returns>
        //public string AddToWhere(string fieldName, TextBox textBox, string tableName = "")
        //{
        //    if (string.IsNullOrWhiteSpace(fieldName) || textBox == null)
        //        throw new ArgumentException("查询语句中参数有误。");
        //    return this.AddToWhere(fieldName, textBox.Text.Trim(), tableName);
        //}

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

        ///// <summary>
        ///// 给where语句新增参数，返回SQL语句的like查询条件
        ///// </summary>
        ///// <param name="fieldName">SQL语句中字段的名称，同时用作参数的名称</param>
        ///// <param name="textBox">从中取参数的值的TextBox控件</param>
        ///// <param name="tableName">表的名称或别名</param>
        ///// <returns></returns>
        //public string AddLikeToWhere(string fieldName, TextBox textBox, string tableName = "")
        //{
        //    if (string.IsNullOrWhiteSpace(fieldName) || textBox == null)
        //        throw new ArgumentException("查询语句中参数有误。");
        //    return this.AddLikeToWhere(fieldName, textBox.Text.Trim(), tableName);
        //}

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
