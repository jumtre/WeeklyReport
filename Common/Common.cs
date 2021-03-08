using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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
        public const string DBFileName = "DB.mdb";

        /// <summary>
        /// 数据库路径
        /// </summary>
        public static readonly string DBPath = Path.Combine(ApplicationPath, "DB", DBFileName);

        /// <summary>
        /// 配置文件名
        /// </summary>
        public const string ConfigFileName = "Settings.ini";

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
        public const string DateFormat = "yyyy-MM-dd";

        /// <summary>
        /// 时间格式：HH:mm:ss
        /// </summary>
        public const string TimeFormat = "HH:mm:ss";

        /// <summary>
        /// 日期时间格式：yyyy-MM-dd HH:mm:ss
        /// </summary>
        public const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// 日期时间精确到分钟的格式：yyyy-MM-dd HH:mm
        /// </summary>
        public const string DateTimeMinuteFormat = "yyyy-MM-dd HH:mm";

        /// <summary>
        /// 日期时间精确到小时的格式：yyyy-MM-dd HH
        /// </summary>
        public const string DateTimeHourFormat = "yyyy-MM-dd HH";

        /// <summary>
        /// 日期时间详细格式：yyyyMMddHHmmssfff
        /// </summary>
        public const string DateTimeDetailFormat = "yyyyMMddHHmmssfff";

        /// <summary>
        /// 查询时增加的“（全部）”项目的值：-1
        /// </summary>
        public const int ItemAllValue = -1;

        /// <summary>
        /// 查询时增加的“（全部）”项目的名称：（全部）
        /// </summary>
        public const string ItemAllName = "（全部）";

        /// <summary>
        /// 绑定时项目到控件时增加的空项目的值：-99
        /// </summary>
        public const int ItemNullValue = -99;

        /// <summary>
        /// 绑定时项目到控件时增加的空项目的值：""
        /// </summary>
        public const string ItemNullName = "";

        private static int currentUserGetTimes = 0;
        private static User currentUser = null;
        /// <summary>
        /// 当前用户
        /// </summary>
        public static User CurrentUser
        {
            get
            {
                if (currentUserGetTimes == 0 && currentUser == null)
                {
                    currentUserGetTimes++;
                    return CommonFunc.GetCurrentUser();
                }
                else
                    return currentUser;
            }
            set { currentUser = value; }
        }

        private static int currentProjectGetTimes = 0;
        private static Project currentProject = null;
        /// <summary>
        /// 当前项目
        /// </summary>
        public static Project CurrentProject
        {
            get
            {
                if (currentProjectGetTimes == 0 && currentProject == null)
                {
                    currentProjectGetTimes++;
                    return CommonFunc.GetCurrentProject();
                }
                else
                    return currentProject;
            }
            set { currentProject = value; }
        }

        private static int currentBranchGetTimes = 0;
        private static Branch currentBranch = null;
        /// <summary>
        /// 当前分支
        /// </summary>
        public static Branch CurrentBranch
        {
            get
            {
                if (currentBranchGetTimes == 0 && currentBranch == null)
                {
                    currentBranchGetTimes++;
                    return CommonFunc.GetCurrentBranch();
                }
                else
                    return currentBranch;
            }
            set { currentBranch = value; }
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

        private static int branchSearchTimes = 0;
        private static List<Branch> branchList = null;
        /// <summary>
        /// 分支列表
        /// </summary>
        public static List<Branch> BranchList
        {
            get
            {
                if (branchList == null && branchSearchTimes == 0)
                {
                    branchSearchTimes++;
                    return CommonFunc.GetBranchList();
                }
                else
                    return branchList;
            }
            set { branchList = value; }
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

        /// <summary>
        /// 待办事项状态“未完成”的ID：-99
        /// </summary>
        public const int toDoStatusNotDoneID = -99;
        /// <summary>
        /// 待办事项状态“未完成”的ID名称：未完成
        /// </summary>
        public const string toDoStatusNotDoneName = "未完成";
        /// <summary>
        /// 待办事项状态“未完成”
        /// </summary>
        public static readonly ToDoStatus toDoStatusNotDone = new ToDoStatus()
        {
            ID = toDoStatusNotDoneID,
            Name = toDoStatusNotDoneName,
            Status = EnumToDoStatus.Planning | EnumToDoStatus.Working
        };

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
        /// <summary>
        /// 获取当前周的起止时间
        /// </summary>
        /// <param name="dtStart">当前周的开始时间</param>
        /// <param name="dtEnd">当前周的结束时间</param>
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
        /// 获取当前周的开始时间
        /// </summary>
        public static DateTime GetWeekStartDate()
        {
            DateTime now = DateTime.Now;
            DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;
            int nDayOfWeek = (int)dayOfWeek;
            if (dayOfWeek == DayOfWeek.Sunday)
                nDayOfWeek = 7;
            return now.AddDays(-(nDayOfWeek - 1)).Date;
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
                if (currentUserID.IsNullOrWhiteSpace())
                    throw new CommonInfoException("配置文件中的 Common.CurrentUserID 配置项数据错误。");
                if (!int.TryParse(currentUserID, out iCurrentUserID))
                    throw new CommonInfoException("配置文件中的 Common.CurrentUserID 配置项数据错误。");
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
        /// 从配置文件中获取当前项目，若未配置或出错，则设置CommonData.CurrentProject为null并返回CommonData.CurrentProject
        /// </summary>
        /// <param name="lazyLoad">是否懒加载。默认是</param>
        /// <returns></returns>
        public static Project GetCurrentProject(bool lazyLoad = true)
        {
            if (CommonData.CurrentProject != null && lazyLoad)
                return CommonData.CurrentProject;
            int iCurrentProjectID = -1;
            try
            {
                string currentProjectID = CommonData.IniHelper.Read("Common", "CurrentProjectID");
                if (currentProjectID.IsNullOrWhiteSpace())
                {
                    CommonData.CurrentProject = null;
                    return CommonData.CurrentProject;
                }
                if (!int.TryParse(currentProjectID, out iCurrentProjectID))
                {
                    CommonData.CurrentProject = null;
                    return CommonData.CurrentProject;
                }
                string currentProjectName = CommonData.IniHelper.Read("Common", "CurrentProjectName");
                CommonData.CurrentProject = new Project { ID = iCurrentProjectID, Name = currentProjectName };
                return CommonData.CurrentProject;
            }
            catch (Exception ex)
            {
                CommonData.CurrentProject = null;
                return CommonData.CurrentProject;
            }
        }

        /// <summary>
        /// 从配置文件中获取当前分支，若未配置或出错，则设置CommonData.CurrentBranch为null并返回CommonData.CurrentBranch
        /// </summary>
        /// <param name="lazyLoad">是否懒加载。默认是</param>
        /// <returns></returns>
        public static Branch GetCurrentBranch(bool lazyLoad = true)
        {
            if (CommonData.CurrentBranch != null && lazyLoad)
                return CommonData.CurrentBranch;
            int iCurrentBranchID = -1;
            try
            {
                string currentBranchID = CommonData.IniHelper.Read("Common", "CurrentBranchID");
                if (currentBranchID.IsNullOrWhiteSpace())
                {
                    CommonData.CurrentBranch = null;
                    return CommonData.CurrentBranch;
                }
                if (!int.TryParse(currentBranchID, out iCurrentBranchID))
                {
                    CommonData.CurrentBranch = null;
                    return CommonData.CurrentBranch;
                }
                string currentBranchName = CommonData.IniHelper.Read("Common", "CurrentBranchName");
                CommonData.CurrentBranch = new Branch { ID = iCurrentBranchID, Name = currentBranchName };
                return CommonData.CurrentBranch;
            }
            catch (Exception ex)
            {
                CommonData.CurrentBranch = null;
                return CommonData.CurrentBranch;
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
            List<Project> projectList = new List<Project>();
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
        /// 为查询获取项目列表
        /// </summary>
        /// <param name="lazyLoad">是否懒加载。默认是</param>
        /// <param name="firstItemNull">首项是否为空。用于不指定项目。若true，首项为空；若false，首项为“全部”。默认否</param>
        /// <returns></returns>
        public static List<Project> GetProjectListForSearch(bool lazyLoad = true, bool firstItemNull = false)
        {
            Project projectFirst = new Project
            {
                ID = firstItemNull ? CommonData.ItemNullValue : CommonData.ItemAllValue,
                Name = firstItemNull ? CommonData.ItemNullName : CommonData.ItemAllName
            };
            List<Project> projectList = new List<Project>();
            projectList.Add(projectFirst);
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
        /// <param name="firstItemNull">首项是否为空。用于不指定项目，如果是，会修改forSearch为true。默认否</param>
        public static void BindProjectListToComboBox(ComboBox comboBox, List<Project> projectList = null, bool forSearch = false, bool lazyLoad = true, bool firstItemNull = false)
        {
            if (comboBox == null)
                return;
            if (firstItemNull)
                forSearch = true;
            if (projectList == null)
                projectList = forSearch ? GetProjectListForSearch(lazyLoad, firstItemNull) : GetProjectList(lazyLoad);
            if (projectList != null && projectList.Count > 0)
            {
                comboBox.DataSource = projectList;
                comboBox.ValueMember = "ID";
                comboBox.DisplayMember = "Name";
            }
        }

        /// <summary>
        /// 获取分支列表
        /// </summary>
        /// <param name="lazyLoad">是否懒加载。默认是</param>
        /// <returns></returns>
        public static List<Branch> GetBranchList(bool lazyLoad = true)
        {
            if (CommonData.BranchList != null && lazyLoad)
                return CommonData.BranchList;
            List<Branch> branchList = new List<Branch>();
            DataTable dtBranch = CommonData.AccessHelper.GetDataTable("select b.ID, b.Name, b.[Memo], b.ProjectID, p.Name as ProjectName from Branch b left join Project p on b.ProjectID = p.ID");
            if (dtBranch != null && dtBranch.Rows.Count > 0)
            {
                branchList = new List<Branch>();
                foreach (DataRow row in dtBranch.Rows)
                {
                    Branch branch = new Branch()
                    {
                        ID = DataConvert.ToInt(row["ID"]),
                        Name = DataConvert.ToString(row["Name"]),
                        Memo = DataConvert.ToString(row["Memo"]),
                        Project = new Project()
                        {
                            ID = DataConvert.ToInt(row["ProjectID"]),
                            Name = DataConvert.ToString(row["ProjectName"])
                        }
                    };
                    branchList.Add(branch);
                }
            }
            CommonData.BranchList = branchList;
            return CommonData.BranchList;
        }

        /// <summary>
        /// 根据项目ID获取分支列表
        /// </summary>
        /// <param name="projectID">项目ID</param>
        /// <param name="lazyLoad">是否懒加载。默认是</param>
        /// <returns></returns>
        public static List<Branch> GetBranchListByProjectID(int projectID=CommonData.ItemNullValue, bool lazyLoad = true)
        {
            if (CommonData.BranchList != null && lazyLoad)
                return CommonData.BranchList.FindAll(b => b.Project != null && b.Project.ID == projectID);
            List<Branch> branchList = new List<Branch>();
            DataTable dtBranch = CommonData.AccessHelper.GetDataTable("select b.ID, b.Name, b.[Memo], b.ProjectID, p.Name as ProjectName from Branch b left join Project p on b.ProjectID = p.ID where ProjectID = " + projectID);
            if (dtBranch != null && dtBranch.Rows.Count > 0)
            {
                branchList = new List<Branch>();
                foreach (DataRow row in dtBranch.Rows)
                {
                    Branch branch = new Branch()
                    {
                        ID = DataConvert.ToInt(row["ID"]),
                        Name = DataConvert.ToString(row["Name"]),
                        Memo = DataConvert.ToString(row["Memo"]),
                        Project = new Project()
                        {
                            ID = DataConvert.ToInt(row["ProjectID"]),
                            Name = DataConvert.ToString(row["ProjectName"])
                        }
                    };
                    branchList.Add(branch);
                }
            }
            return branchList;
        }

        /// <summary>
        /// 为查询获取分支列表（首项为“全部”）
        /// </summary>
        /// <param name="lazyLoad">是否懒加载。默认是</param>
        /// <param name="firstItemNull">首项是否为空。用于不指定分支。默认否</param>
        /// <returns></returns>
        public static List<Branch> GetBranchListForSearch(bool lazyLoad = true, bool firstItemNull = false)
        {
            Branch branchFirst = new Branch
            {
                ID = firstItemNull ? CommonData.ItemNullValue : CommonData.ItemAllValue,
                Name = firstItemNull ? CommonData.ItemNullName : CommonData.ItemAllName
            };
            List<Branch> branchList = new List<Branch>();
            branchList.Add(branchFirst);
            branchList.AddRange(GetBranchList(lazyLoad));
            return branchList;
        }

        /// <summary>
        /// 根据项目ID为查询获取分支列表（首项为“全部”）
        /// </summary>
        /// <param name="projectID">项目ID</param>
        /// <param name="lazyLoad">是否懒加载。默认是</param>
        /// <param name="firstItemNull">首项是否为空。用于不指定分支。默认否</param>
        /// <returns></returns>
        public static List<Branch> GetBranchListForSearchByProjectID(int projectID, bool lazyLoad = true, bool firstItemNull = false)
        {
            Branch branchFirst = new Branch
            {
                ID = firstItemNull ? CommonData.ItemNullValue : CommonData.ItemAllValue,
                Name = firstItemNull ? CommonData.ItemNullName : CommonData.ItemAllName
            };
            List<Branch> branchList = new List<Branch>();
            branchList.Add(branchFirst);
            branchList.AddRange(GetBranchListByProjectID(projectID, lazyLoad));
            return branchList;
        }

        /// <summary>
        /// 绑定分支列表到ComboBox控件
        /// </summary>
        /// <param name="comboBox">要绑定数据的ComboBox控件</param>
        /// <param name="branchList">要绑定的分支列表</param>
        /// <param name="forSearch">是否为查询。如果是，首项为“全部”。默认否</param>
        /// <param name="lazyLoad">是否懒加载。默认是</param>
        /// <param name="firstItemNull">首项是否为空。用于不指定分支，如果是，会修改forSearch为true。默认否</param>
        public static void BindBranchListToComboBox(ComboBox comboBox, List<Branch> branchList = null, bool forSearch = false, bool lazyLoad = true, bool firstItemNull = false)
        {
            if (comboBox == null)
                return;
            if (firstItemNull)
                forSearch = true;
            if (branchList == null)
                branchList = forSearch ? GetBranchListForSearch(lazyLoad, firstItemNull) : GetBranchList(lazyLoad);
            if (branchList != null && branchList.Count > 0)
            {
                comboBox.DataSource = branchList;
                comboBox.ValueMember = "ID";
                comboBox.DisplayMember = "Name";
            }
        }

        /// <summary>
        /// 绑定分支列表到ComboBox控件
        /// </summary>
        /// <param name="comboBox">要绑定数据的ComboBox控件</param>
        /// <param name="projectID">项目ID</param>
        /// <param name="branchList">要绑定的分支列表</param>
        /// <param name="forSearch">是否为查询。如果是，首项为“全部”。默认否</param>
        /// <param name="lazyLoad">是否懒加载。默认是</param>
        /// <param name="firstItemNull">首项是否为空。用于不指定分支，如果是，会修改forSearch为true。默认否</param>
        public static void BindBranchListToComboBoxByProjectID(ComboBox comboBox, int projectID, List<Branch> branchList = null, bool forSearch = false, bool lazyLoad = true, bool firstItemNull = false)
        {
            if (comboBox == null)
                return;
            if (firstItemNull)
                forSearch = true;
            if (branchList == null)
                branchList = forSearch ? GetBranchListForSearchByProjectID(projectID, lazyLoad, firstItemNull) : GetBranchListByProjectID(projectID, lazyLoad);
            if (branchList != null && branchList.Count > 0)
            {
                comboBox.DataSource = branchList;
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
            List<User> userList = new List<User>();
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
        /// <param name="firstItemNull">首项是否为空。用于不指定用户。默认否</param>
        /// <returns></returns>
        public static List<User> GetUserListForSearch(bool lazyLoad = true, bool firstItemNull = false)
        {
            User userFirst = new User
            {
                ID = firstItemNull ? CommonData.ItemNullValue : CommonData.ItemAllValue,
                Name = firstItemNull ? CommonData.ItemNullName : CommonData.ItemAllName
            };
            List<User> userList = new List<User>();
            userList.Add(userFirst);
            userList.AddRange(GetUserList(lazyLoad));
            return userList;
        }

        /// <summary>
        /// 绑定用户列表到ComboBox控件
        /// </summary>
        /// <param name="comboBox">要绑定数据的ComboBox控件</param>
        /// <param name="userList">要绑定的用户列表</param>
        /// <param name="forSearch">是否为查询。如果是，首项为“全部”。默认否。如果firstItemNull设为true，会把此参数修改为false。</param>
        /// <param name="lazyLoad">是否懒加载。默认是</param>
        /// <param name="firstItemNull">首项是否为空。用于不指定用户，如果是，会修改forSearch为true。默认否</param>
        public static void BindUserListToComboBox(ComboBox comboBox, List<User> userList = null, bool forSearch = false, bool lazyLoad = true, bool firstItemNull = false)
        {
            if (comboBox == null)
                return;
            if (firstItemNull)
                forSearch = true;
            if (userList == null)
                userList = forSearch ? GetUserListForSearch(lazyLoad, firstItemNull) : GetUserList(lazyLoad);
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

        /// <summary>
        /// 转换成Access数据库DateTime类型对应的值
        /// </summary>
        /// <param name="dateTimePicker">要转换值的DateTimePicker控件</param>
        /// <param name="secondsValue">DateTime中秒的值。小于等于0取0，大于等于59取59</param>
        /// <returns></returns>
        public static string ToAccessDateTimeValue(DateTimePicker dateTimePicker, int secondsValue)
        {
            if ((dateTimePicker.ShowCheckBox && dateTimePicker.Checked) || !dateTimePicker.ShowCheckBox)
            {
                string secondsValueStr = "00";
                if (secondsValue <= 0)
                    secondsValueStr = "00";
                else if (secondsValue >= 59)
                    secondsValueStr = "59";
                else
                    secondsValueStr = secondsValue.ToString("00");
                return "#" + dateTimePicker.Value.ToString(CommonData.DateTimeMinuteFormat) + ":" + secondsValueStr + "#";
            }
            else
                return "null";
        }

        /// <summary>
        /// 转换成Access数据库DateTime类型对应的值
        /// </summary>
        /// <param name="dateTimePicker">要转换值的DateTimePicker控件</param>
        /// <param name="minutesValue">DateTime中分的值。小于等于0取0，大于等于59取59</param>
        /// <param name="secondsValue">DateTime中秒的值。小于等于0取0，大于等于59取59</param>
        /// <returns></returns>
        public static string ToAccessDateTimeValue(DateTimePicker dateTimePicker, int minutesValue, int secondsValue)
        {
            if ((dateTimePicker.ShowCheckBox && dateTimePicker.Checked) || !dateTimePicker.ShowCheckBox)
            {
                string minutesValueStr = "00";
                if (minutesValue <= 0)
                    minutesValueStr = "00";
                else if (minutesValue >= 59)
                    minutesValueStr = "59";
                else
                    minutesValueStr = secondsValue.ToString("00");
                string secondsValueStr = "00";
                if (secondsValue <= 0)
                    secondsValueStr = "00";
                else if (secondsValue >= 59)
                    secondsValueStr = "59";
                else
                    secondsValueStr = secondsValue.ToString("00");
                return "#" + dateTimePicker.Value.ToString(CommonData.DateTimeHourFormat) + ":" + minutesValueStr + ":" + secondsValueStr + "#";
            }
            else
                return "null";
        }

        /// <summary>
        /// 自动按类型转换成Access数据库中对应类型的值
        /// </summary>
        /// <param name="value">要转换的值</param>
        /// <returns></returns>
        public static string ToAccessValue(object value)
        {
            string aValue = string.Empty;
            string typeName = value.GetType().FullName;
            switch (typeName)
            {
                case "int":
                    aValue = ToAccessIntValue((int)value);
                    break;
                case "decimal":
                    aValue = ToAccessDecimalValue((decimal)value);
                    break;
                case "datetime":
                    aValue = ToAccessDateTimeValue((DateTime)value);
                    break;
                case "String":
                default:
                    aValue = ToAccessStringValue((string)value);
                    break;
            }
            return aValue;
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

    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// 指示指定的字符串是 null、空还是仅由空白字符组成。
        /// </summary>
        /// <param name="value">要测试的字符串。</param>
        /// <returns>如果 value 参数为 null 或 System.String.Empty，或者如果 value 仅由空白字符组成，则为 true。</returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// 字符串是否不为null或空字符串或只包含空字符
        /// </summary>
        /// <param name="value">要判断的字符串</param>
        /// <returns></returns>
        public static bool NotNullOrWhiteSpace(this string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// 从当前 System.String 对象移除所有前导空白字符和尾部空白字符。
        /// </summary>
        /// <param name="input">当前字符串</param>
        /// <returns>从当前字符串的开头和结尾删除所有空白字符后剩余的字符串。</returns>
        public static string ToTrimmedString(this object input)
        {
            if (input == null)
                return null;
            else
                return input.ToString().Trim();
        }

        /// <summary>
        /// 将指定字符串中的格式项替换为指定数组中相应对象的字符串表示形式。指定的参数提供区域性特定的格式设置信息。
        /// </summary>
        /// <param name="provider">一个提供区域性特定的格式设置信息的对象。</param>
        /// <param name="format">复合格式字符串。</param>
        /// <param name="args">一个对象数组，其中包含零个或多个要设置格式的对象。</param>
        /// <returns>format 的副本，其中的格式项已替换为 args 中相应对象的字符串表示形式。</returns>
        /// <exception cref="T:System.ArgumentNullException">format 或 args 为 null。</exception>
        /// <exception cref="T:System.FormatException">format 无效。- 或 -格式项的索引小于零或大于等于 args 数组的长度。</exception>
        public static string Format(IFormatProvider provider, string format, params object[] args)
        {
            return string.Format(provider, format, args);
        }

        /// <summary>
        /// 将指定字符串中的格式项替换为指定数组中相应对象的字符串表示形式。
        /// </summary>
        /// <param name="format">复合格式字符串。</param>
        /// <param name="args">一个对象数组，其中包含零个或多个要设置格式的对象。</param>
        /// <returns>format 的副本，其中的格式项已替换为 args 中相应对象的字符串表示形式。</returns>
        /// <exception cref="T:System.ArgumentNullException">format 或 args 为 null。</exception>
        /// <exception cref="T:System.FormatException">format 无效。- 或 -格式项的索引小于零或大于等于 args 数组的长度。</exception>
        public static string Format(string format, params object[] args)
        {
            return string.Format(format, args);
        }

        /// <summary>
        /// 将指定字符串中的格式项替换为三个指定对象的字符串表示形式。
        /// </summary>
        /// <param name="format">复合格式字符串。</param>
        /// <param name="arg0">要设置格式的第一个对象。</param>
        /// <param name="arg1">要设置格式的第二个对象。</param>
        /// <param name="arg2">要设置格式的第三个对象。</param>
        /// <returns>format 的副本，其中的格式项已替换为 arg0、arg1 和 arg2 的字符串表示形式。</returns>
        /// <exception cref="T:System.ArgumentNullException">format 为 null。</exception>
        /// <exception cref="T:System.FormatException">format 无效。- 或 -格式项的索引小于零或大于二。</exception>
        public static string Format(string format, object arg0, object arg1, object arg2)
        {
            return string.Format(format, arg0, arg1, arg2);
        }

        /// <summary>
        /// 将指定字符串中的一个或多个格式项替换为指定对象的字符串表示形式。
        /// </summary>
        /// <param name="format">复合格式字符串。</param>
        /// <param name="arg0">要设置格式的对象。</param>
        /// <returns>format 的副本，其中的任何格式项均替换为 arg0 的字符串表示形式。</returns>
        /// <exception cref="T:System.ArgumentNullException">format 为 null。</exception>
        /// <exception cref="T:System.FormatException">format 中的格式项无效。- 或 -格式项的索引大于或小于零。</exception>
        public static string Format(string format, object arg0)
        {
            return string.Format(format, arg0);
        }

        /// <summary>
        /// 将指定字符串中的格式项替换为两个指定对象的字符串表示形式。
        /// </summary>
        /// <param name="format">复合格式字符串。</param>
        /// <param name="arg0">要设置格式的第一个对象。</param>
        /// <param name="arg1">要设置格式的第二个对象。</param>
        /// <returns>format 的副本，其中的格式项替换为 arg0 和 arg1 的字符串表示形式。</returns>
        /// <exception cref="T:System.ArgumentNullException">format 为 null。</exception>
        /// <exception cref="T:System.FormatException">format 无效。- 或 -格式项的索引小于零或大于一。</exception>
        public static string Format(string format, object arg0, object arg1)
        {
            return string.Format(format, arg0, arg1);
        }

        /// <summary>
        /// 指示所指定的正则表达式在指定的输入字符串中是否找到了匹配项。
        /// </summary>
        /// <param name="input">要搜索匹配项的字符串。</param>
        /// <param name="pattern">要匹配的正则表达式模式。</param>
        /// <returns>如果正则表达式找到匹配项，则为 true；否则，为 false。</returns>
        /// <exception cref="T:System.ArgumentException">出现正则表达式分析错误。</exception>
        /// <exception cref="T:System.ArgumentNullException">input 或 pattern 为 null。</exception>
        public static bool IsMatch(this string input, string pattern)
        {
            if (input == null)
                return false;
            else
                return Regex.IsMatch(input, pattern);
        }

        /// <summary>
        /// 从输入字符串中获取指定的正则表达式的第一个匹配捕获的子字符串。
        /// </summary>
        /// <param name="input">要搜索匹配项的字符串。</param>
        /// <param name="pattern">要匹配的正则表达式模式。</param>
        /// <returns>通过匹配捕获的实际子字符串。</returns>
        public static string Match(this string input, string pattern)
        {
            if (input == null)
                return string.Empty;
            else
                return Regex.Match(input, pattern).Value;
        }

        /// <summary>
        /// 使用指定的匹配选项在输入字符串中搜索指定的正则表达式的第一个匹配捕获的子字符串。
        /// </summary>
        /// <param name="input">对其匹配测试的字符串。</param>
        /// <param name="pattern">要匹配的正则表达式模式。</param>
        /// <param name="options">枚举值的一个按位组合，这些枚举值提供匹配选项。</param>
        /// <returns>通过匹配捕获的实际子字符串。</returns>
        /// <exception cref="T:System.ArgumentException">出现正则表达式分析错误。</exception>
        /// <exception cref="T:System.ArgumentNullException">input 或 pattern 为 null。</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">options 不是 System.Text.RegularExpressions.RegexOptions 值的有效按位组合。</exception>
        public static string Match(this string input, string pattern, RegexOptions options)
        {
            if (input == null)
                return string.Empty;
            else
                return Regex.Match(input, pattern, options).Value;
        }

        public static string Match(this string input, string pattern, RegexOptions options, TimeSpan matchTimeout)
        {
            if (input == null)
                return string.Empty;
            return Regex.Match(input, pattern, options, matchTimeout).Value;
        }
    }
}
