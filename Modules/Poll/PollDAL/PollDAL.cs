using System;
using System.Collections.Generic;
using System.Text;
using CommonUtility.DBUtility;
using System.Data;

namespace Modules.Poll
{
    /// <summary>
    /// 网上调查详细信息
    /// </summary>
    public class PollDetail
    {
        /// <summary>
        /// 调查标识
        /// </summary>
        public int PollId;
        /// <summary>
        /// 调查内容
        /// </summary>
        public string PollText;
        /// <summary>
        /// 添加该调查的用户Id
        /// </summary>
        public int AddedUserId;
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddedTime;
        /// <summary>
        /// 最近修改时间
        /// </summary>
        public DateTime LastModifiedTime;
        /// <summary>
        /// 状态  1：发布，2：存档
        /// </summary>
        public int Status;   
    }
    /// <summary>
    /// 网上调查的数据访问接口
    /// </summary>
    internal class PollDAL
    {
        /// <summary>
        /// 添加网上调查
        /// </summary>
        /// <param name="pollText">调查内容</param>
        /// <param name="addedUserId">添加该调查的用户Id</param>
        /// <param name="status">状态  1：发布，2：存档</param>
        /// <returns>调查标识</returns>
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
        /// 获取调查的详细信息
        /// </summary>
        /// <param name="pollId"> 调查标识</param>
        /// <returns>详细信息(DataRow)</returns>
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
        /// 获取调查的详细信息
        /// </summary>
        /// <param name="pollId">调查标识</param>
        /// <returns>详细信息(PollDetail)</returns>
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
        /// 将DataRow转化成PollDetail
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
