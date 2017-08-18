using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonUtility.DBUtility;
using System.Collections;
using CommonUtility;
namespace Modules.Log
{
    internal class OperateLogDAL
    {
        /// <summary>
        /// �����־
        /// </summary>
        /// <param name="userId">�û���ʶ</param>
        /// <param name="ip">��½�û����ڻ��ӵ�IP��ַ</param>
        /// <param name="url">������־�������ڵ�ҳ���ַ</param>
        /// <param name="description">��������</param>
        /// <returns>��ӳɹ�,������־��ʶ,���򷵻�-1</returns>
        public int Add(int userId, string ip, string url, string description)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            IDataParameter[] paras = new IDataParameter[5];
            paras[0] = helper.GetParameter("@UserId", userId);
            paras[1] = helper.GetParameter("@IP", ip);
            paras[2] = helper.GetParameter("@Url", url);
            paras[3] = helper.GetParameter("@Description", description);
            paras[4] = helper.GetParameter("@LogId",DbType.Int32,4,ParameterDirection.Output);
            if (helper.ExecuteNonQuery("sp_Log_Add", paras) == 1) return (int)paras[4].Value;
            return -1;
        }


        /// <summary>
        ///ɾ����־
        /// </summary>
        /// <param name="logIdList">��־��ʶ����</param>
        public void Delete(int[] logIdList)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from T_Log where LogId ");
            if (logIdList.Length == 1)
                sql.AppendFormat("={0}", logIdList[0]);
            else if (logIdList.Length > 1)
            {
                string[] strLogIdList=StringUtility.TranslateToStringArray(logIdList);
                sql.AppendFormat("in({0})",String.Join(",",strLogIdList)); 
            }
            helper.ExecuteNonQuery(sql.ToString());
        }
       

        /// <summary>
        /// ������־��¼
        /// </summary>
        /// <param name="where">��������</param>
        /// <param name="order">��������</param>
        /// <returns>������������־��¼��¼��</returns>
        public DataSet Select(string where, string order)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder query = new StringBuilder();
            query.Append("select a.*,b.Nickname from T_Log a inner join T_User b on a.UserId=b.UserId ");
            query.AppendFormat("where {0} ", where);
            query.AppendFormat("order by {0}", order);
            return helper.ExecuteDataset(query.ToString());
        }

        public DataSet GetLogList(string fields, string filter, string sort, int currentPageIndex, int pageSize, out int recordCount)
        {
            return PaginationUtility.GetPaginationList(fields, "V_Log", filter, sort, currentPageIndex, pageSize, out recordCount);
        }
    }
}
