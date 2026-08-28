using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// SqlHelper抽象基类
    /// </summary>
    public abstract class SqlHelper
    {
        /// <summary>
        /// 数据库连接语句
        /// </summary>
        private string dbConnectionString = string.Empty;
        /// <summary>
        /// 数据库连接
        /// </summary>
        private DbConnection dbConnection = null;

        public SqlHelper()
        {
            SetDbString();
            SetDbConnection();
        }

        /// <summary>
        /// 初始化数据库连接
        /// </summary>
        /// <param name="dataSource">数据源</param>
        public SqlHelper(string dataSource)
        {
            //connStr = "data source=" + dataSource + ";";
            SetDbString(dataSource);
            SetDbConnection();
        }

        /// <summary>
        /// 初始化数据库连接
        /// </summary>
        /// <param name="dataSource">数据源</param>
        /// <param name="password">密码</param>
        public SqlHelper(string dataSource, string password)
        {
            //dbConnectionString = "data source=" + dataSource + ";password=" + password;
            SetDbString(dataSource, password);
            SetDbConnection();
        }

        /// <summary>
        /// 设置数据库连接字符串
        /// </summary>
        /// <param name="dataSource">数据源</param>
        public abstract void SetDbString(string dataSource = null, string password = null)
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
        public virtual void SetDbConnection(string connStr = null)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(connStr))
                {
                    if (dbConnection == null)
                    {
                        if (!string.IsNullOrWhiteSpace(dbConnectionString))
                        {
                            dbConnection = new DbConnection(dbConnectionString);
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
            catch (DbException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
