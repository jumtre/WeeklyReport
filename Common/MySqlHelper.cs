using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// MySql帮助类
    /// </summary>
    public class MySqlHelper
    {
        /// <summary>
        /// 数据库连接语句
        /// </summary>
        private string dbConnectionString = string.Empty;
        /// <summary>
        /// 数据库连接
        /// </summary>
        private MySqlConnection dbConnection = null;

        //public MySqlHelper()
        //{
        //    SetDbString();
        //    SetDbConnection();
        //}

        /// <summary>
        /// 初始化数据库连接
        /// </summary>
        /// <param name="connectionString">连接字符串
        /// <para>data source=localhost;database=test1;user id=root;password=root;pooling=true;charset=utf8;port=3306;</para>
        /// <para>server=127.0.0.1;port=3306;user=root;password=root; database=minecraftdb;</para>
        /// </param>
        public MySqlHelper(string connectionString)
        {
            //string connectstring= "data source=localhost;database=test1;user id=root;password=root;pooling=true;charset=utf8;port=3306;";
            //string connectstring= "server=127.0.0.1;port=3306;user=root;password=root; database=minecraftdb;";
            //todo 检测连接字符串合法性
            dbConnectionString = connectionString;
            SetDbConnection();
        }

        /// <summary>
        /// 初始化数据库连接
        /// </summary>
        /// <param name="server">服务器地址</param>
        /// <param name="database">数据库名称</param>
        /// <param name="userID">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="port">端口号，默认3306</param>
        public MySqlHelper(string server, string database, string userID, string password, uint port = 3306)
        {
            SetDbString(server, database, userID, password, port);
            SetDbConnection();
        }

        /// <summary>
        /// 设置数据库连接字符串
        /// </summary>
        /// <param name="server">服务器地址</param>
        /// <param name="database">数据库名称</param>
        /// <param name="userID">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="port">端口号，默认3306</param>
        private void SetDbString(string server, string database, string userID, string password, uint port = 3306)
        {
            if (string.IsNullOrWhiteSpace(server) || string.IsNullOrWhiteSpace(database) || string.IsNullOrWhiteSpace(userID) || string.IsNullOrWhiteSpace(password) || port < 0 || port > 65535)
                throw new ArgumentException("参数无效");

            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = server;
            builder.Database = database;
            builder.UserID = userID;
            builder.Password = password;
            builder.Port = port;
            builder.Pooling = true;//是否使用线程池，默认true
            dbConnectionString = builder.ConnectionString;
            //MySqlConnection connection = new MySqlConnection(builder.ConnectionString);
            builder = null;
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
                            dbConnection = new MySqlConnection(dbConnectionString);
                            return;
                        }
                        else
                            throw new ArgumentException("没有连接语句");
                    }
                }
                if (connStr.Trim().ToLower() == dbConnectionString.Trim().ToLower())
                {
                    if (dbConnection == null)
                        dbConnection = new MySqlConnection(connStr);
                }
                else
                {
                    dbConnectionString = connStr;
                    dbConnection = new MySqlConnection(dbConnectionString);
                }
            }
            catch (MySqlException ex)
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
        public MySqlConnection GetDbConnection(string connStr = null)
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
                return new MySqlConnection(connStr);
            }
            catch (MySqlException ex)
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
            MySqlConnection conn = GetDbConnection();

            MySqlDataAdapter da = null;
            try
            {
                DataTable dt = new DataTable();
                using (conn)
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = sql;
                        cmd.CommandType = CommandType.Text;
                        da = new MySqlDataAdapter(cmd);
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
            catch (MySqlException ex)
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
        /// <param name="sql">查询语句</param>
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql, MySqlConnection conn = null)
        {
            if (string.IsNullOrWhiteSpace(sql))
                return null;
            if (conn == null)
                conn = GetDbConnection();

            MySqlDataAdapter da = null;
            try
            {
                DataTable dt = new DataTable();
                using (conn)
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = sql;
                        cmd.CommandType = CommandType.Text;
                        da = new MySqlDataAdapter(cmd);
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
            catch (MySqlException ex)
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
        /// <param name="sql">查询语句</param>
        /// <param name="paramDict">参数字典</param>
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql, IDictionary<string, object> paramDict = null, MySqlConnection conn = null)
        {
            if (string.IsNullOrWhiteSpace(sql))
                return null;
            if (conn == null)
                conn = GetDbConnection();

            MySqlDataAdapter da = null;
            try
            {
                DataTable dt = new DataTable();
                using (conn)
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = sql;
                        cmd.CommandType = CommandType.Text;
                        if (paramDict != null && paramDict.Count > 0)
                        {
                            foreach (KeyValuePair<string, object> pair in paramDict)
                                cmd.Parameters.AddWithValue(pair.Key, pair.Value ?? DBNull.Value);
                        }
                        da = new MySqlDataAdapter(cmd);
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
            catch (MySqlException ex)
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
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public DataTable GetDataTable(string tableName, IEnumerable<string> fieldList = null, IDictionary<string, object> whereParamDict = null, MySqlConnection conn = null)
        {
            if (string.IsNullOrWhiteSpace(tableName))
                return null;
            if (conn == null)
                conn = GetDbConnection();

            MySqlDataAdapter da = null;
            try
            {
                DataTable dt = new DataTable();
                using (conn)
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
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
                        da = new MySqlDataAdapter(cmd);
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
            catch (MySqlException ex)
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
        public int ExecuteNonQuery(string sql, IDictionary<string, object> paramDict = null, MySqlConnection conn = null)
        {
            if (string.IsNullOrWhiteSpace(sql))
                return 0;
            if (conn == null)
                conn = GetDbConnection();

            MySqlCommand cmd = null;
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
            catch (MySqlException ex)
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
        public object ExecuteScalar(string sql, IDictionary<string, object> paramDict = null, MySqlConnection conn = null)
        {
            if (string.IsNullOrWhiteSpace(sql))
                return null;
            if (conn == null)
                conn = GetDbConnection();

            MySqlCommand cmd = null;
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
            catch (MySqlException ex)
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

        /////// <summary>
        /////// 格式化字段名
        /////// </summary>
        /////// <param name="fieldName">要格式化的原始字段名</param>
        /////// <returns></returns>
        ////public string FormatFieldName(string fieldName)
        ////{
        ////    return CommonData.IsAccessKeyword(fieldName) ? "[" + fieldName + "]" : fieldName;
        ////}

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
        public int Insert(string tableName, IDictionary<string, object> paramDict, MySqlConnection conn = null)
        {
            if (string.IsNullOrWhiteSpace(tableName) || paramDict == null || paramDict.Count == 0)
                throw new ArgumentException("执行失败，参数有误。");
            if (conn == null)
                conn = GetDbConnection();

            MySqlCommand cmd = null;
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
            catch (MySqlException ex)
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
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public long InsertAndReturnNewIdentity(string tableName, IDictionary<string, object> paramDict, MySqlConnection conn = null)
        {
            if (string.IsNullOrWhiteSpace(tableName) || paramDict == null || paramDict.Count == 0)
                throw new ArgumentException("执行失败，参数有误。");
            if (conn == null)
                conn = GetDbConnection();

            MySqlCommand cmd = null;
            try
            {
                long result = 0;
                using (conn)
                {
                    conn.Open();
                    cmd = new MySqlCommand();
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
                            cmd.Parameters.Add(new MySqlParameter()
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
                    cmd.CommandText = "insert into " + tableName + " (" + fieldBuilder.ToString().TrimEnd(',') + ") values (" + paramBuilder.ToString().TrimEnd(',') + ");select last_insert_id();";//select @@identity
                    object oResult = cmd.ExecuteScalar();//也可以在使用ExecuteNonQuery执行insert后读取MySqlCommand的LastInsertedId属性
                    if (oResult == null || !long.TryParse(oResult.ToString(), out result))
                        throw new Exception("数据插入失败或返回值有误");
                    conn.Close();
                    conn.Dispose();
                }
                return result;
            }
            catch (MySqlException ex)
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
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public int Update(string tableName, IDictionary<string, object> setParamDict, IDictionary<string, object> whereParamDict, MySqlConnection conn = null)
        {
            //检查whereParamDict，避免全表更新
            if (string.IsNullOrWhiteSpace(tableName) || setParamDict == null || setParamDict.Count == 0 || whereParamDict == null || whereParamDict.Count == 0)
                throw new ArgumentException("执行失败，参数有误。");
            if (conn == null)
                conn = GetDbConnection();

            MySqlCommand cmd = null;
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
            catch (MySqlException ex)
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
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public int Update(string tableName, string setFieldName, object setParamValue, string whereFieldName, object whereParamValue, MySqlConnection conn = null)
        {
            //检查whereParamDict，避免全表更新
            if (string.IsNullOrWhiteSpace(tableName) || string.IsNullOrWhiteSpace(setFieldName) || string.IsNullOrWhiteSpace(whereFieldName))
                throw new ArgumentException("执行失败，参数有误。");
            if (conn == null)
                conn = GetDbConnection();

            MySqlCommand cmd = null;
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
            catch (MySqlException ex)
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
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public int Delete(string tableName, IDictionary<string, object> paramDict, MySqlConnection conn = null)
        {
            //检查whereParamDict，避免全表更新
            if (string.IsNullOrWhiteSpace(tableName) || paramDict == null || paramDict.Count == 0)
                throw new ArgumentException("执行失败，参数有误。");
            if (conn == null)
                conn = GetDbConnection();

            MySqlCommand cmd = null;
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
            catch (MySqlException ex)
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
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public int Delete(string tableName, string fieldName, object paramValue, MySqlConnection conn = null)
        {
            //检查whereParamDict，避免全表更新
            if (string.IsNullOrWhiteSpace(tableName) || string.IsNullOrWhiteSpace(fieldName))
                throw new ArgumentException("执行失败，参数有误。");
            if (conn == null)
                conn = GetDbConnection();

            MySqlCommand cmd = null;
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
            catch (MySqlException ex)
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
        public bool Exists(string tableName, IDictionary<string, object> whereParamDict = null, MySqlConnection conn = null)
        {
            if (string.IsNullOrWhiteSpace(tableName))
                throw new ArgumentException("执行失败，参数有误。");
            if (conn == null)
                conn = GetDbConnection();

            MySqlCommand cmd = null;
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
            catch (MySqlException ex)
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
        private string GetCommandWhereStr(MySqlCommand cmd, IDictionary<string, object> whereParamDict, string paramPrefix = "")
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
        public MySqlCommand GetInsertCommand(string tableName, IDictionary<string, object> paramDict, MySqlConnection conn = null)
        {
            if (string.IsNullOrWhiteSpace(tableName) || paramDict == null || paramDict.Count == 0)
                throw new ArgumentException("参数有误。");

            MySqlCommand cmd = new MySqlCommand();
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
                    cmd.Parameters.Add(new MySqlParameter()
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
        public MySqlCommand GetUpdateCommand(string tableName, IDictionary<string, object> setParamDict, IDictionary<string, object> whereParamDict, MySqlConnection conn = null)
        {
            //检查whereParamDict，避免全表更新
            if (string.IsNullOrWhiteSpace(tableName) || setParamDict == null || setParamDict.Count == 0 || whereParamDict == null || whereParamDict.Count == 0)
                throw new ArgumentException("参数有误。");

            MySqlCommand cmd = new MySqlCommand();
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
        public MySqlCommand GetUpdateCommand(string tableName, string setFieldName, object setParamValue, string whereFieldName, object whereParamValue, MySqlConnection conn = null)
        {
            //检查whereParamDict，避免全表更新
            if (string.IsNullOrWhiteSpace(tableName) || string.IsNullOrWhiteSpace(setFieldName) || string.IsNullOrWhiteSpace(whereFieldName))
                throw new ArgumentException("参数有误。");

            MySqlCommand cmd = new MySqlCommand();
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
        public MySqlCommand GetDeleteCommand(string tableName, IDictionary<string, object> paramDict, MySqlConnection conn = null)
        {
            //检查whereParamDict，避免全表更新
            if (string.IsNullOrWhiteSpace(tableName) || paramDict == null || paramDict.Count == 0)
                throw new ArgumentException("参数有误。");

            MySqlCommand cmd = new MySqlCommand();
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
        public MySqlCommand GetDeleteCommand(string tableName, string fieldName, object paramValue, MySqlConnection conn = null)
        {
            //检查whereParamDict，避免全表更新
            if (string.IsNullOrWhiteSpace(tableName) || string.IsNullOrWhiteSpace(fieldName))
                throw new ArgumentException("执行失败，参数有误。");

            MySqlCommand cmd = new MySqlCommand();
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
        public int Execute(MySqlCommand cmd, MySqlConnection conn = null)
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
            catch (MySqlException ex)
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
        public bool ExecuteByTransaction(IEnumerable<MySqlCommand> cmdList, MySqlConnection conn = null)
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
                    using (MySqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            foreach (MySqlCommand command in cmdList)
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
                                MySqlCommand command = cmdList.ElementAt(i);
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
            catch (MySqlException ex)
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
}
