﻿using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    /// <summary>
    /// 通用数据类
    /// </summary>
    public static class CommonData
    {
        /// <summary>
        /// 程序路径：Environment.CurrentDirectory
        /// </summary>
        public static readonly string ApplicationPath = Environment.CurrentDirectory;

        /// <summary>
        /// 数据库文件名：DB.mdb
        /// </summary>
        public static readonly string DBFileName = "DB.mdb";

        /// <summary>
        /// 数据库路径
        /// </summary>
        public static readonly string DBPath = Path.Combine(ApplicationPath, "DB", DBFileName);

        /// <summary>
        /// 配置文件名
        /// </summary>
        public static readonly string ConfigFileName = "Settings.ini";

        /// <summary>
        /// 配置文件路径
        /// </summary>
        public static readonly string ConfigFilePath = Path.Combine(ApplicationPath, ConfigFileName);

        private static AccessHelper accessHelper = null;
        /// <summary>
        /// 数据库帮助对象
        /// </summary>
        public static AccessHelper AccessHelper
        {
            get
            {
                if (accessHelper == null)
                {
                    try
                    {
                        accessHelper = new AccessHelper(CommonData.DBPath);
                    }
                    catch (Exception ex)
                    {
                        CommonInfoException infoEx = new CommonInfoException("读取数据库出错。", ex);
                        throw infoEx;
                    }
                }
                return accessHelper;
            }
        }

        private static IniHelper iniHelper;
        /// <summary>
        /// ini文件帮助对象
        /// </summary>
        public static IniHelper IniHelper
        {
            get
            {
                if (iniHelper == null)
                {
                    try
                    {
                        iniHelper = new IniHelper(CommonData.ConfigFilePath);
                    }
                    catch (Exception ex)
                    {
                        CommonInfoException infoEx = new CommonInfoException("读取配置文件出错。", ex);
                        throw infoEx;
                    }
                }
                return iniHelper;
            }
        }

        /// <summary>
        /// 备份路径
        /// </summary>
        public static readonly string BackupPath = ApplicationPath + "\\Backup";

        /// <summary>
        /// 日期格式：yyyy-MM-dd
        /// </summary>
        public static readonly string DateFormat = "yyyy-MM-dd";

        /// <summary>
        /// 时间格式：HH:mm:ss
        /// </summary>
        public static readonly string TimeFormat = "HH:mm:ss";

        /// <summary>
        /// 日期时间格式：yyyy-MM-dd HH:mm:ss
        /// </summary>
        public static readonly string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// 日期时间精确到分钟的格式：yyyy-MM-dd HH:mm
        /// </summary>
        public static readonly string DateTimeMinuteFormat = "yyyy-MM-dd HH:mm";

        /// <summary>
        /// 日期时间详细格式：yyyyMMddHHmmssfff
        /// </summary>
        public static readonly string DateTimeDetailFormat = "yyyyMMddHHmmssfff";

        /// <summary>
        /// 查询时增加的“（全部）”项目的值：-1
        /// </summary>
        public static readonly int ItemAllValue = -1;

        /// <summary>
        /// 查询时增加的“（全部）”项目的名称：（全部）
        /// </summary>
        public static readonly string ItemAllName = "（全部）";

        private static int currentUserGetTimes = 0;
        private static User currentUser = null;
        /// <summary>
        /// 当前用户
        /// </summary>
        public static User CurrentUser
        {
            get
            {
                if (currentUser == null && currentUserGetTimes == 0)
                {
                    currentUserGetTimes++;
                    return CommonFunc.GetCurrentUser();
                }
                else
                    return currentUser;
            }
            set { currentUser = value; }
        }

        private static int projectSearchTimes = 0;
        private static List<Project> projectList = null;
        /// <summary>
        /// 项目列表
        /// </summary>
        public static List<Project> ProjectList
        {
            get
            {
                if (projectList == null && projectSearchTimes == 0)
                {
                    projectSearchTimes++;
                    return CommonFunc.GetProjectList();
                }
                else
                    return projectList;
            }
            set { projectList = value; }
        }

        private static int userSearchTimes = 0;
        private static List<User> userList = null;
        /// <summary>
        /// 用户列表
        /// </summary>
        public static List<User> UserList
        {
            get
            {
                if (userList == null && userSearchTimes == 0)
                {
                    userSearchTimes++;
                    return CommonFunc.GetUserList();
                }
                else
                    return userList;
            }
            set { userList = value; }
        }

        private static int toDoStatusSearchTimes = 0;
        private static List<ToDoStatus> toDoStatusList = null;
        /// <summary>
        /// 待办事项状态列表
        /// </summary>
        public static List<ToDoStatus> ToDoStatusList
        {
            get
            {
                if (toDoStatusList == null && toDoStatusSearchTimes == 0)
                {
                    toDoStatusSearchTimes++;
                    return CommonFunc.GetToDoStatusList();
                }
                else
                    return toDoStatusList;
            }
            set { toDoStatusList = value; }
        }

        private static int toDoPrioritySearchTimes = 0;
        private static List<ToDoPriority> toDoPriorityList = null;
        /// <summary>
        /// 待办事项优先级列表
        /// </summary>
        public static List<ToDoPriority> ToDoPriorityList
        {
            get
            {
                if (toDoPriorityList == null && toDoPrioritySearchTimes == 0)
                {
                    toDoPrioritySearchTimes++;
                    return CommonFunc.GetToDoPriorityList();
                }
                else
                    return toDoPriorityList;
            }
            set { toDoPriorityList = value; }
        }

        private static int toDoSeveritySearchTimes = 0;
        private static List<ToDoSeverity> toDoSeverityList = null;
        /// <summary>
        /// 待办事项严重度列表
        /// </summary>
        public static List<ToDoSeverity> ToDoSeverityList
        {
            get
            {
                if (toDoSeverityList == null && toDoSeveritySearchTimes == 0)
                {
                    toDoSeveritySearchTimes++;
                    return CommonFunc.GetToDoSeverityList();
                }
                else
                    return toDoSeverityList;
            }
            set { toDoSeverityList = value; }
        }
    }

    /// <summary>
    /// 通用方法类
    /// </summary>
    public static class CommonFunc
    {
        public static void GetWeekDateTime(ref DateTime dtStart, ref DateTime dtEnd)
        {
            DateTime now = DateTime.Now;
            DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;
            int nDayOfWeek = (int)dayOfWeek;
            if (dayOfWeek == DayOfWeek.Sunday)
                nDayOfWeek = 7;
            dtStart = now.AddDays(-(nDayOfWeek - 1)).Date;
            dtEnd = dtStart.Date.AddDays(6).Date.AddHours(23).AddMinutes(59).AddSeconds(59);
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

        /// <summary>
        /// 从配置文件中获取当前用户
        /// </summary>
        /// <param name="lazyLoad">是否懒加载。默认是</param>
        /// <returns></returns>
        public static User GetCurrentUser(bool lazyLoad = true)
        {
            if (CommonData.CurrentUser != null && lazyLoad)
                return CommonData.CurrentUser;
            int iCurrentUserID = -1;
            try
            {
                string currentUserID = CommonData.IniHelper.Read("Common", "CurrentUserID");
                if (!int.TryParse(currentUserID, out iCurrentUserID))
                {
                    throw new CommonInfoException("配置文件中的 Common.CurrentUserID 配置项数据错误。");
                }
                string currentUserName = CommonData.IniHelper.Read("Common", "CurrentUserName");
                CommonData.CurrentUser = new User { ID = iCurrentUserID, Name = currentUserName };
                return CommonData.CurrentUser;
            }
            catch (Exception ex)
            {
                throw new CommonInfoException("配置文件中没有当前用户的设置，请先运行管理工具设置当前用户。", ex);
            }
        }

        /// <summary>
        /// 获取项目列表
        /// </summary>
        /// <param name="lazyLoad">是否懒加载。默认是</param>
        /// <returns></returns>
        public static List<Project> GetProjectList(bool lazyLoad = true)
        {
            if (CommonData.ProjectList != null && lazyLoad)
                return CommonData.ProjectList;
            List<Project> projectList = null;
            DataTable dtProject = CommonData.AccessHelper.GetDataTable("select ID, Name from Project");
            if (dtProject != null && dtProject.Rows.Count > 0)
            {
                projectList = new List<Project>();
                foreach (DataRow row in dtProject.Rows)
                {
                    Project project = new Project()
                    {
                        ID = DataConvert.ToInt(row["ID"]),
                        Name = DataConvert.ToString(row["Name"])
                    };
                    projectList.Add(project);
                }
            }
            CommonData.ProjectList = projectList;
            return CommonData.ProjectList;
        }

        /// <summary>
        /// 为查询获取项目列表（首项为“全部”）
        /// </summary>
        /// <param name="lazyLoad">是否懒加载。默认是</param>
        /// <returns></returns>
        public static List<Project> GetProjectListForSearch(bool lazyLoad = true)
        {
            Project projectAll = new Project
            {
                ID = CommonData.ItemAllValue,
                Name = CommonData.ItemAllName
            };
            List<Project> projectList = new List<Project>();
            projectList.Add(projectAll);
            projectList.AddRange(GetProjectList(lazyLoad));
            return projectList;
        }

        /// <summary>
        /// 绑定项目列表到ComboBox控件
        /// </summary>
        /// <param name="comboBox">要绑定数据的ComboBox控件</param>
        /// <param name="projectList">要绑定的项目列表</param>
        /// <param name="forSearch">是否为查询。如果是，首项为“全部”。默认否</param>
        /// <param name="lazyLoad">是否懒加载。默认是</param>
        public static void BindProjectListToComboBox(ComboBox comboBox, List<Project> projectList = null, bool forSearch = false, bool lazyLoad = true)
        {
            if (comboBox == null)
                return;
            if (projectList == null)
                projectList = forSearch ? GetProjectListForSearch(lazyLoad) : GetProjectList(lazyLoad);
            if (projectList != null && projectList.Count > 0)
            {
                comboBox.DataSource = projectList;
                comboBox.ValueMember = "ID";
                comboBox.DisplayMember = "Name";
            }
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="lazyLoad">是否懒加载。默认是</param>
        /// <returns></returns>
        public static List<User> GetUserList(bool lazyLoad = true)
        {
            if (CommonData.UserList != null && lazyLoad)
                return CommonData.UserList;
            List<User> userList = null;

            DataTable dtUser = CommonData.AccessHelper.GetDataTable("select ID, Name from [User]");
            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                userList = new List<User>();
                foreach (DataRow row in dtUser.Rows)
                {
                    User user = new User()
                    {
                        ID = DataConvert.ToInt(row["ID"]),
                        Name = DataConvert.ToString(row["Name"])
                    };
                    userList.Add(user);
                }
            }
            CommonData.UserList = userList;
            return CommonData.UserList;
        }

        /// <summary>
        /// 为查询获取用户列表（首项为“全部”）
        /// </summary>
        /// <param name="lazyLoad">是否懒加载。默认是</param>
        /// <returns></returns>
        public static List<User> GetUserListForSearch(bool lazyLoad = true)
        {
            User userAll = new User
            {
                ID = CommonData.ItemAllValue,
                Name = CommonData.ItemAllName
            };
            List<User> userList = new List<User>();
            userList.Add(userAll);
            userList.AddRange(GetUserList(lazyLoad));
            return userList;
        }

        /// <summary>
        /// 绑定用户列表到ComboBox控件
        /// </summary>
        /// <param name="comboBox">要绑定数据的ComboBox控件</param>
        /// <param name="userList">要绑定的用户列表</param>
        /// <param name="forSearch">是否为查询。如果是，首项为“全部”。默认否</param>
        /// <param name="lazyLoad">是否懒加载。默认是</param>
        public static void BindUserListToComboBox(ComboBox comboBox, List<User> userList = null, bool forSearch = false, bool lazyLoad = true)
        {
            if (comboBox == null)
                return;
            if (userList == null)
                userList = forSearch ? GetUserListForSearch(lazyLoad) : GetUserList(lazyLoad);
            if (userList != null && userList.Count > 0)
            {
                comboBox.DataSource = userList;
                comboBox.ValueMember = "ID";
                comboBox.DisplayMember = "Name";
            }
        }

        /// <summary>
        /// 获取待办事项状态列表
        /// </summary>
        /// <returns></returns>
        public static List<ToDoStatus> GetToDoStatusList()
        {
            if (CommonData.ToDoStatusList != null)
                return CommonData.ToDoStatusList;
            List<ToDoStatus> toDoStatusList = new List<ToDoStatus>();
            toDoStatusList.Add(new ToDoStatus((int)EnumToDoStatus.Planning, GetDescription(EnumToDoStatus.Planning), EnumToDoStatus.Planning));
            toDoStatusList.Add(new ToDoStatus((int)EnumToDoStatus.Working, GetDescription(EnumToDoStatus.Working), EnumToDoStatus.Working));
            toDoStatusList.Add(new ToDoStatus((int)EnumToDoStatus.Done, GetDescription(EnumToDoStatus.Done), EnumToDoStatus.Done));
            CommonData.ToDoStatusList = toDoStatusList;
            return CommonData.ToDoStatusList;
        }

        /// <summary>
        /// 为查询获取待办事项状态列表（首项为“全部”）
        /// </summary>
        /// <returns></returns>
        public static List<ToDoStatus> GetToDoStatusListForSearch()
        {
            List<ToDoStatus> toDoStatusList = new List<ToDoStatus>();
            toDoStatusList.Add(new ToDoStatus(CommonData.ItemAllValue, CommonData.ItemAllName, EnumToDoStatus.Planning | EnumToDoStatus.Working | EnumToDoStatus.Done));
            toDoStatusList.AddRange(GetToDoStatusList());
            return toDoStatusList;
        }

        /// <summary>
        /// 绑定待办事项状态列表到ComboBox控件
        /// </summary>
        /// <param name="comboBox">要绑定数据的ComboBox控件</param>
        /// <param name="toDoStatusList">要绑定的待办事项状态列表</param>
        /// <param name="forSearch">是否为查询。如果是，首项为“全部”。默认否</param>
        public static void BindToDoStatusListToComboBox(ComboBox comboBox, List<ToDoStatus> toDoStatusList = null, bool forSearch = false)
        {
            if (comboBox == null)
                return;
            if (toDoStatusList == null)
                toDoStatusList = forSearch ? GetToDoStatusListForSearch() : GetToDoStatusList();
            if (toDoStatusList != null && toDoStatusList.Count > 0)
            {
                comboBox.DataSource = toDoStatusList;
                comboBox.ValueMember = "Status";
                comboBox.DisplayMember = "Name";
            }
        }

        /// <summary>
        /// 获取待办事项优先级列表
        /// </summary>
        /// <returns></returns>
        public static List<ToDoPriority> GetToDoPriorityList()
        {
            if (CommonData.ToDoPriorityList != null)
                return CommonData.ToDoPriorityList;
            List<ToDoPriority> toDoPriorityList = new List<ToDoPriority>();
            toDoPriorityList.Add(new ToDoPriority((int)EnumToDoPriority.Immediate, GetDescription(EnumToDoPriority.Immediate), EnumToDoPriority.Immediate));
            toDoPriorityList.Add(new ToDoPriority((int)EnumToDoPriority.Urgent, GetDescription(EnumToDoPriority.Urgent), EnumToDoPriority.Urgent));
            toDoPriorityList.Add(new ToDoPriority((int)EnumToDoPriority.High, GetDescription(EnumToDoPriority.High), EnumToDoPriority.High));
            toDoPriorityList.Add(new ToDoPriority((int)EnumToDoPriority.Normal, GetDescription(EnumToDoPriority.Normal), EnumToDoPriority.Normal));
            toDoPriorityList.Add(new ToDoPriority((int)EnumToDoPriority.Low, GetDescription(EnumToDoPriority.Low), EnumToDoPriority.Low));
            CommonData.ToDoPriorityList = toDoPriorityList;
            return CommonData.ToDoPriorityList;
        }

        /// <summary>
        /// 为查询获取待办事项优先级列表（首项为“全部”）
        /// </summary>
        /// <returns></returns>
        public static List<ToDoPriority> GetToDoPriorityListForSearch()
        {
            List<ToDoPriority> toDoPriorityList = new List<ToDoPriority>();
            toDoPriorityList.Add(new ToDoPriority(CommonData.ItemAllValue, CommonData.ItemAllName, EnumToDoPriority.Immediate | EnumToDoPriority.Urgent | EnumToDoPriority.High| EnumToDoPriority.Normal| EnumToDoPriority.Low));
            toDoPriorityList.AddRange(GetToDoPriorityList());
            return toDoPriorityList;
        }

        /// <summary>
        /// 绑定待办事项优先级列表到ComboBox控件
        /// </summary>
        /// <param name="comboBox">要绑定数据的ComboBox控件</param>
        /// <param name="toDoPriorityList">要绑定的待办事项优先级列表</param>
        /// <param name="forSearch">是否为查询。如果是，首项为“全部”。默认否</param>
        public static void BindToDoPriorityListToComboBox(ComboBox comboBox, List<ToDoPriority> toDoPriorityList = null, bool forSearch = false)
        {
            if (comboBox == null)
                return;
            if (toDoPriorityList == null)
                toDoPriorityList = forSearch ? GetToDoPriorityListForSearch() : GetToDoPriorityList();
            if (toDoPriorityList != null && toDoPriorityList.Count > 0)
            {
                comboBox.DataSource = toDoPriorityList;
                comboBox.ValueMember = "Priority";
                comboBox.DisplayMember = "Name";
            }
        }

        /// <summary>
        /// 获取待办事项严重度列表
        /// </summary>
        /// <returns></returns>
        public static List<ToDoSeverity> GetToDoSeverityList()
        {
            if (CommonData.ToDoSeverityList != null)
                return CommonData.ToDoSeverityList;
            List<ToDoSeverity> toDoSeverityList = new List<ToDoSeverity>();
            toDoSeverityList.Add(new ToDoSeverity((int)EnumToDoSeverity.Blocker, GetDescription(EnumToDoSeverity.Blocker), EnumToDoSeverity.Blocker));
            toDoSeverityList.Add(new ToDoSeverity((int)EnumToDoSeverity.Critical, GetDescription(EnumToDoSeverity.Critical), EnumToDoSeverity.Critical));
            toDoSeverityList.Add(new ToDoSeverity((int)EnumToDoSeverity.Major, GetDescription(EnumToDoSeverity.Major), EnumToDoSeverity.Major));
            toDoSeverityList.Add(new ToDoSeverity((int)EnumToDoSeverity.Minor, GetDescription(EnumToDoSeverity.Minor), EnumToDoSeverity.Minor));
            CommonData.ToDoSeverityList = toDoSeverityList;
            return CommonData.ToDoSeverityList;
        }

        /// <summary>
        /// 为查询获取待办事项严重度列表（首项为“全部”）
        /// </summary>
        /// <returns></returns>
        public static List<ToDoSeverity> GetToDoSeverityListForSearch()
        {
            List<ToDoSeverity> toDoSeverityList = new List<ToDoSeverity>();
            toDoSeverityList.Add(new ToDoSeverity(CommonData.ItemAllValue, CommonData.ItemAllName, EnumToDoSeverity.Blocker | EnumToDoSeverity.Critical | EnumToDoSeverity.Major | EnumToDoSeverity.Minor));
            toDoSeverityList.AddRange(GetToDoSeverityList());
            return toDoSeverityList;
        }

        /// <summary>
        /// 绑定待办事项严重度列表到ComboBox控件
        /// </summary>
        /// <param name="comboBox">要绑定数据的ComboBox控件</param>
        /// <param name="toDoSeverityList">要绑定的待办事项严重度列表</param>
        /// <param name="forSearch">是否为查询。如果是，首项为“全部”。默认否</param>
        public static void BindToDoSeverityListToComboBox(ComboBox comboBox, List<ToDoSeverity> toDoSeverityList = null, bool forSearch = false)
        {
            if (comboBox == null)
                return;
            if (toDoSeverityList == null)
                toDoSeverityList = forSearch ? GetToDoSeverityListForSearch() : GetToDoSeverityList();
            if (toDoSeverityList != null && toDoSeverityList.Count > 0)
            {
                comboBox.DataSource = toDoSeverityList;
                comboBox.ValueMember = "Severity";
                comboBox.DisplayMember = "Name";
            }
        }
    }

    /// <summary>
    /// 数据转换类
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
        /// 转换成可空整型
        /// </summary>
        /// <param name="obj">要转换的数据</param>
        /// <returns></returns>
        public static int? ToNullableInt(object obj)
        {
            if (obj == null)
                return null;
            if (int.TryParse(obj.ToString(), out int i))
                return i;
            else
                return null;
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
        /// 转换成可空Decimal类型
        /// </summary>
        /// <param name="obj">要转换的数据</param>
        /// <returns></returns>
        public static decimal? ToNullableDecimal(object obj)
        {
            if (obj == null)
                return null;
            if (decimal.TryParse(obj.ToString(), out decimal i))
                return i;
            else
                return null;
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
            if (DateTime.TryParse(obj.ToString(), out DateTime dt))
                return dt;
            else
                return DateTime.MinValue;
        }

        /// <summary>
        /// 转换成可空时间类型
        /// </summary>
        /// <param name="obj">要转换的数据</param>
        /// <returns></returns>
        public static DateTime? ToNullableDateTime(object obj)
        {
            if (obj == null)
                return null;
            if (DateTime.TryParse(obj.ToString(), out DateTime dt))
                return dt;
            else
                return null;
        }

        ///// <summary>
        ///// 转换成枚举
        ///// </summary>
        ///// <typeparam name="T">枚举类型</typeparam>
        ///// <param name="obj">要转换的数据</param>
        ///// <returns></returns>
        //public static T ToEnum<T>(object obj)
        //{
        //    if (obj == null)
        //        return default(T);
        //    if (obj.GetType() != typeof(int) && obj.GetType() != typeof(char))
        //        //return default(T);
        //        throw new CommonInfoException(obj + "不是int或char类型，无法转换成枚举。");
        //    if (Enum.IsDefined(typeof(T), obj))
        //        return (T)obj;
        //    else
        //        return default(T);
        //}

        /// <summary>
        /// 转换成枚举
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="obj">要转换的数据</param>
        /// <returns></returns>
        public static object ToEnum<T>(object obj)
        {
            if (obj == null)
                return null;
            if (obj.GetType() != typeof(int) && obj.GetType() != typeof(Int16) && obj.GetType() != typeof(Int64) && obj.GetType() != typeof(char))
                //return default(T);
                throw new CommonInfoException(obj + "不是int或char类型，无法转换成枚举。");
            if (obj.GetType() != typeof(Int16) || obj.GetType() != typeof(Int64))
            {
                object o = Convert.ToInt32(obj);
                if (Enum.IsDefined(typeof(T), o))
                    return (T)o;
                else
                    return null;
            }
            else
            {
                if (Enum.IsDefined(typeof(T), obj))
                    return (T)obj;
                else
                    return null;
            }
        }

        /// <summary>
        /// 转换成Access数据库String类型对应的值
        /// </summary>
        /// <param name="value">要转换的值</param>
        /// <returns></returns>
        public static string ToAccessStringValue(string value)
        {
            return "'" + value + "'";
        }

        /// <summary>
        /// 转换成Access数据库String类型对应的值
        /// </summary>
        /// <param name="textBox">要转换值的TextBox控件</param>
        /// <param name="trim">是否丢弃首尾的空字符。默认是</param>
        /// <returns></returns>
        public static string ToAccessStringValue(TextBox textBox, bool trim = true)
        {
            string value = trim ? textBox.Text.Trim() : textBox.Text;
            return "'" + value + "'";
        }

        /// <summary>
        /// 转换成Access数据库String类型对应的值
        /// </summary>
        /// <param name="richTextBox">要转换值的RichTextBox控件</param>
        /// <param name="trim">是否丢弃首尾的空字符。默认是</param>
        /// <returns></returns>
        public static string ToAccessStringValue(RichTextBox richTextBox, bool trim = true)
        {
            string value = trim ? richTextBox.Text.Trim() : richTextBox.Text;
            return "'" + value + "'";
        }

        /// <summary>
        /// 转换成Access数据库Int类型对应的值
        /// </summary>
        /// <param name="value">要转换的值</param>
        /// <returns></returns>
        public static string ToAccessIntValue(int value)
        {
            return value.ToString();
        }

        /// <summary>
        /// 转换成Access数据库Int类型对应的值（仅在ComboBox.SelectedValue取值时使用）
        /// </summary>
        /// <param name="comboBox">要转换值的ComboBox控件</param>
        /// <returns></returns>
        public static string ToAccessIntValue(ComboBox comboBox)
        {
            if (comboBox.SelectedValue is int)
                return comboBox.SelectedValue.ToString();
            else
                return null;
        }

        /// <summary>
        /// 转换成Access数据库Decimal类型对应的值
        /// </summary>
        /// <param name="value">要转换的值</param>
        /// <returns></returns>
        public static string ToAccessDecimalValue(decimal value)
        {
            return value.ToString();
        }

        /// <summary>
        /// 转换成Access数据库Decimal类型对应的值
        /// </summary>
        /// <param name="value">要转换的值</param>
        /// <returns></returns>
        public static string ToAccessDecimalValue(decimal? value)
        {
            if (value.HasValue)
                return value.Value.ToString();
            else
                return "null";
        }

        /// <summary>
        /// 转换成Access数据库Decimal类型对应的值
        /// </summary>
        /// <param name="numericUpDown">要转换值的NumericUpDown控件</param>
        /// <returns></returns>
        public static string ToAccessDecimalValue(NumericUpDown numericUpDown)
        {
            return numericUpDown.Value.ToString();
        }

        /// <summary>
        /// 转换成Access数据库DateTime类型对应的值
        /// </summary>
        /// <param name="value">要转换的值</param>
        /// <returns></returns>
        public static string ToAccessDateTimeValue(DateTime value)
        {
            return "#" + value.ToString(CommonData.DateTimeFormat) + "#";
        }

        /// <summary>
        /// 转换成Access数据库DateTime类型对应的值
        /// </summary>
        /// <param name="value">要转换的值</param>
        /// <returns></returns>
        public static string ToAccessDateTimeValue(DateTime? value)
        {
            if (value.HasValue)
                return "#" + value.Value.ToString(CommonData.DateTimeFormat) + "#";
            else
                return "null";
        }

        /// <summary>
        /// 转换成Access数据库DateTime类型对应的值
        /// </summary>
        /// <param name="dateTimePicker">要转换值的DateTimePicker控件</param>
        /// <returns></returns>
        public static string ToAccessDateTimeValue(DateTimePicker dateTimePicker)
        {
            if ((dateTimePicker.ShowCheckBox && dateTimePicker.Checked) || !dateTimePicker.ShowCheckBox)
                return "#" + dateTimePicker.Value.ToString(CommonData.DateTimeFormat) + "#";
            else
                return "null";
        }
    }

    /// <summary>
    /// 时间管理类
    /// </summary>
    public sealed class DateTimeManger
    {
        private DateTimeManger()
        { }

        /// <summary>
        /// 计算时间间隔
        /// </summary>
        /// <param name="Interval">间隔类型</param>
        /// <param name="StartDate">开始时间</param>
        /// <param name="EndDate">结束时间</param>
        /// <returns></returns>
        public static double DateDiff(DateInterval Interval, DateTime StartDate, DateTime EndDate)
        {
            double dateDiffValue = 0;
            TimeSpan TS = new TimeSpan(EndDate.Ticks - StartDate.Ticks);
            switch (Interval)
            {
                case DateInterval.Second:
                    dateDiffValue = TS.TotalSeconds;
                    break;
                case DateInterval.Minute:
                    dateDiffValue = TS.TotalMinutes;
                    break;
                case DateInterval.Hour:
                    dateDiffValue = TS.TotalHours;
                    break;
                case DateInterval.Day:
                    dateDiffValue = TS.TotalDays;
                    break;
                case DateInterval.Week:
                    dateDiffValue = TS.TotalDays / 7;
                    break;
                case DateInterval.Month:
                    dateDiffValue = TS.TotalDays / DateTime.DaysInMonth(StartDate.Year,StartDate.Month);
                    break;
                case DateInterval.Quarter:
                    dateDiffValue = (TS.TotalDays / DateTime.DaysInMonth(StartDate.Year, StartDate.Month)) / 3;
                    break;
                case DateInterval.Year:
                    dateDiffValue = TS.TotalDays / (DateTime.IsLeapYear(StartDate.Year) ? 366 : 365);
                    break;
            }
            return dateDiffValue;
        }
    }

    /// <summary>
    /// 公共信息类异常
    /// </summary>
    [Serializable()]
    public class CommonInfoException : Exception
    {
        public CommonInfoException() : base() { }
        public CommonInfoException(string message) : base(message) { }
        public CommonInfoException(string message, System.Exception inner) : base(message, inner) { }

        //当异常从远程服务器传播到客户端时，需要序列化构造函数。
        protected CommonInfoException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
