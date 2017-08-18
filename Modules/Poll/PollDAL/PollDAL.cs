using System;
using System.Collections.Generic;
using System.Text;
using CommonUtility.DBUtility;
using System.Data;

namespace Modules.Poll
{
    /// <summary>
    /// ���ϵ�����ϸ��Ϣ
    /// </summary>
    public class PollDetail
    {
        /// <summary>
        /// �����ʶ
        /// </summary>
        public int PollId;
        /// <summary>
        /// ��������
        /// </summary>
        public string PollText;
        /// <summary>
        /// ��Ӹõ�����û�Id
        /// </summary>
        public int AddedUserId;
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime AddedTime;
        /// <summary>
        /// ����޸�ʱ��
        /// </summary>
        public DateTime LastModifiedTime;
        /// <summary>
        /// ״̬  1��������2���浵
        /// </summary>
        public int Status;   
    }
    /// <summary>
    /// ���ϵ�������ݷ��ʽӿ�
    /// </summary>
    internal class PollDAL
    {
        /// <summary>
        /// ������ϵ���
        /// </summary>
        /// <param name="pollText">��������</param>
        /// <param name="addedUserId">��Ӹõ�����û�Id</param>
        /// <param name="status">״̬  1��������2���浵</param>
        /// <returns>�����ʶ</returns>
        public int Add(string pollText, int addedUserId, int status)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            IDataParameter[] paras=new IDataParameter[4];
            paras[0] = helper.GetParameter("@PollText", pollText);
            paras[1] = helper.GetParameter("@addedUserId", addedUserId);
            paras[2] = helper.GetParameter("@Status", status);
            paras[3] = helper.GetParameter("@PollId", DbType.Int32, 4, ParameterDirection.Output);
            helper.ExecuteNonQuery("sp_Poll_InsertPoll", paras);
            return Convert.ToInt32(paras[3].Value);
        }
        /// <summary>
        /// ��ȡ�������ϸ��Ϣ
        /// </summary>
        /// <param name="pollId"> �����ʶ</param>
        /// <returns>��ϸ��Ϣ(DataRow)</returns>
        public DataRow Retrieve(int pollId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder query = new StringBuilder();
            query.AppendFormat("select * from T_Poll where PollId={0}", pollId);
            DataSet ds = helper.ExecuteDataset(query.ToString());
            if (ds.Tables[0].Rows.Count == 1) return ds.Tables[0].Rows[0];
            return null;
        }
        /// <summary>
        /// ��ȡ�������ϸ��Ϣ
        /// </summary>
        /// <param name="pollId">�����ʶ</param>
        /// <returns>��ϸ��Ϣ(PollDetail)</returns>
        public PollDetail GetDetail(int pollId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder query = new StringBuilder();
            query.AppendFormat("select * from T_Poll where PollId={0}", pollId);
            DataSet ds = helper.ExecuteDataset(query.ToString());
            if (ds.Tables[0].Rows.Count == 1) return GetPollDetailFromDataRow(ds.Tables[0].Rows[0]);
            return null;
        }
        /// <summary>
        /// ��DataRowת����PollDetail
        /// </summary>
        /// <param name="pollEntity"></param>
        /// <returns></returns>
        internal PollDetail GetPollDetailFromDataRow(DataRow pollEntity)
        {
            PollDetail detail = new PollDetail();
            detail.PollId = (int)pollEntity["PollId"];
            detail.PollText = pollEntity["PollText"].ToString();
            detail.AddedUserId = (int)pollEntity["AddedUserId"];
            detail.AddedTime = Convert.ToDateTime(pollEntity["AddedTime"]);
            detail.LastModifiedTime = Convert.ToDateTime(pollEntity["LastModifiedTime"]);
            detail.Status = (int)pollEntity["Status"];
            return detail;
        }
    }
}
