using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public class ToDoCommon//懒了，有些不规范写法。。
    {
        /// <summary>
        /// 完成待办事项
        /// </summary>
        /// <param name="toDo">已完成的待办事项</param>
        /// <param name="parentForm">父窗体</param>
        /// <returns></returns>
        public static bool ToDoDone(ToDo toDo, Form parentForm = null)
        {
            if (toDo == null || toDo.ID <= 0)
            {
                MessageBox.Show("待办事项数据错误", "提示");
                return false;
            }
            if (UpdateToDo(toDo, EnumToDoStatus.Done, true))
                AddToReport(toDo, parentForm);
            else
                return false;
            return true;
        }

        /// <summary>
        /// 新增待办事项到个人周报
        /// </summary>
        /// <param name="toDo">要新增的待办事项</param>
        /// <param name="parentForm">父窗体</param>
        private static void AddToReport(ToDo toDo, Form parentForm = null)
        {
            if (toDo == null || toDo.ID <= 0)
                return;
            if (MessageBox.Show("是否新增到个人周报中？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                AddToReport add = new AddToReport(toDo);
                if (parentForm != null)
                    add.ShowDialog(parentForm);
                else
                    add.ShowDialog();
            }
        }

        /// <summary>
        /// 根据状态更新待办事项
        /// </summary>
        /// <param name="toDo">要更新的待办事项</param>
        /// <param name="status">待办事项的状态</param>
        /// <param name="deleteReminder">是否删除待办事项对应的提醒事项</param>
        /// <returns></returns>
        public static bool UpdateToDo(ToDo toDo, EnumToDoStatus status, bool deleteReminder)
        {
            if (toDo == null || toDo.ID <= 0)
            {
                //throw new ArgumentException("待办事项数据错误", "toDo");
                MessageBox.Show("待办事项数据错误", "提示");
                return false;
            }
            if (status != EnumToDoStatus.Cancelled && status != EnumToDoStatus.Done)
                return false;
            DateTime now = DateTime.Now;
            SqlParams setParamDict = new SqlParams();
            setParamDict.Add("Status", (int)status);
            if (status == EnumToDoStatus.Cancelled)
            {
                setParamDict.Add("CancelTime", now);
                setParamDict.Add("CancelUserID", CommonData.CurrentUser.ID);
            }
            else if (status == EnumToDoStatus.Done)
            {
                setParamDict.Add("FinishTime", now);
                setParamDict.Add("FinishUserID", CommonData.CurrentUser.ID);
            }
            SqlParams whereParamDict = new SqlParams();
            whereParamDict.Add("ID", toDo.ID);
            //int i = CommonData.AccessHelper.Update("ToDo", setParamDict, whereParamDict);
            List<System.Data.OleDb.OleDbCommand> commandList = new List<System.Data.OleDb.OleDbCommand>();
            commandList.Add(CommonData.AccessHelper.GetUpdateCommand("ToDo", setParamDict, whereParamDict));
            if (deleteReminder)
                commandList.Add(DeleteReminderByToDoIDCommand(toDo.ID));
            bool result = CommonData.AccessHelper.ExecuteByTransaction(commandList);
            toDo.Status = status;
            if (status == EnumToDoStatus.Cancelled)
            {
                toDo.CancelTime = now;
                toDo.CancelUser = CommonData.CurrentUser;
            }
            else if (status == EnumToDoStatus.Done)
            {
                toDo.FinishTime = now;
                toDo.FinishUser = CommonData.CurrentUser;
            }
            return result;
        }

        /// <summary>
        /// 根据待办事项ID删除提醒事项的命令
        /// </summary>
        /// <param name="toDoID">待办事项ID</param>
        /// <returns></returns>
        public static System.Data.OleDb.OleDbCommand DeleteReminderByToDoIDCommand(decimal toDoID)
        {
            return CommonData.AccessHelper.GetUpdateCommand("Reminder", "Status", 1, "ToDoID", toDoID);
        }
    }
}
