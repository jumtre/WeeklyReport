using System;
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
        public DataTable GetDataTable(string sql, OleDbConnection conn = null)
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
                da.Fill(dt);
                da.Dispose();
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

            int i = 0;
            using (conn)
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                if (paramDict != null && paramDict.Count > 0)
                {
                    foreach (KeyValuePair<string, object> pair in paramDict)
                        cmd.Parameters.AddWithValue(pair.Key, pair.Value ?? string.Empty);
                }
                i = cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
            return i;
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
                        cmd.Parameters.AddWithValue(pair.Key, pair.Value ?? string.Empty);
                }
                o = cmd.ExecuteScalar();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
            return o;
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
                throw new CommonInfoException("执行失败，信息不完整。");
            if (conn == null)
                conn = GetDbConnection();

            int i = 0;
            using (conn)
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                StringBuilder field = new StringBuilder();
                StringBuilder param = new StringBuilder();
                foreach (KeyValuePair<string, object> pair in paramDict)
                {
                    field.Append(pair.Key + ",");
                    param.Append("@" + pair.Key + ",");
                    cmd.Parameters.AddWithValue(pair.Key, pair.Value ?? string.Empty);
                }
                cmd.CommandText = "insert into " + tableName + " (" + field.ToString().TrimEnd(',') + ") values (" + param.ToString().TrimEnd(',') + ")";
                i = cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
            return i;
        }
    }
}
