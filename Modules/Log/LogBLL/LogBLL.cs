using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Data;
namespace Modules.Log
{
    public class OperateLog
    {
        /// <summary>
        /// 添加日志(登陆后,用户票据存在时使用)
        /// </summary>
        /// <param name="description">日志内容描述</param>
        /// <returns>成功,返回日志标识,否则,返回-1</returns>
        public static int AddLog(string description)
        {
            string ipAddress = HttpContext.Current.Request.UserHostAddress;
            string url = HttpContext.Current.Request.Path;
            int userId = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            return OperateLog.AddLog(description, ipAddress, url, userId);
        }
        /// <summary>
        /// 添加日志 (登陆前使用)
        /// </summary>
        /// <param name="description"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static int AddLog(string description, int userId)
        {
            string ipAddress = HttpContext.Current.Request.UserHostAddress;
            string url = HttpContext.Current.Request.Path;
            return OperateLog.AddLog(description, ipAddress, url, userId);
        }

        public static int AddLog(string description, string ip, string url, int userId)
        {
            return new OperateLogDAL().Add(userId, ip, url, description);
        }

        /// <summary>
        /// 删除日志
        /// </summary>
        /// <param name="logIdList"></param>
        public void Delete(int[] logIdList)
        {
            new OperateLogDAL().Delete(logIdList);
        }

        /// <summary>
        /// 检索日志记录
        /// </summary>
        /// <param name="where">检索条件</param>
        /// <param name="order">排序条件</param>
        /// <returns>满足条件的日志记录记录集</returns>
        public DataSet Select(string where, string order)
        {
            return new OperateLogDAL().Select(where, order);
        }

        public DataSet GetLogList(string fields, string filter, string sort, int currentPageIndex, int pageSize, out int recordCount)
        {
            return new OperateLogDAL().GetLogList(fields, filter, sort, currentPageIndex, pageSize, out recordCount);
        }
    }
}
