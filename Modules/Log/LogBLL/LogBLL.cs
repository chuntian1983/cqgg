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
        /// �����־(��½��,�û�Ʊ�ݴ���ʱʹ��)
        /// </summary>
        /// <param name="description">��־��������</param>
        /// <returns>�ɹ�,������־��ʶ,����,����-1</returns>
        public static int AddLog(string description)
        {
            string ipAddress = HttpContext.Current.Request.UserHostAddress;
            string url = HttpContext.Current.Request.Path;
            int userId = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            return OperateLog.AddLog(description, ipAddress, url, userId);
        }
        /// <summary>
        /// �����־ (��½ǰʹ��)
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
        /// ɾ����־
        /// </summary>
        /// <param name="logIdList"></param>
        public void Delete(int[] logIdList)
        {
            new OperateLogDAL().Delete(logIdList);
        }

        /// <summary>
        /// ������־��¼
        /// </summary>
        /// <param name="where">��������</param>
        /// <param name="order">��������</param>
        /// <returns>������������־��¼��¼��</returns>
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
