using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonUtility.DBUtility;

namespace Modules.Poll
{
    public class PollOptionDetail
    {
        public int PollOptionId;
        public string OptionText;
        public int AddedUserId;
        public int PollId;
        public DateTime AddedTime;
        public DateTime LastModifiedTime;
        public int Votes;
    }
    internal class PollOptionDAL
    {
        public int Add(string optionText, int addedUserId, int pollId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            IDataParameter[] paras = new IDataParameter[4];
            paras[0] = helper.GetParameter("@OptionText", optionText);
            paras[1] = helper.GetParameter("@addedUserId", addedUserId);
            paras[2] = helper.GetParameter("@PollId", pollId);
            paras[3] = helper.GetParameter("@PollOptionId", DbType.Int32, 4, ParameterDirection.Output);
            helper.ExecuteNonQuery("sp_Poll_InsertPollOption", paras);
            return Convert.ToInt32(paras[3].Value);
        }
        public DataSet GetPollOptionByPollId(int PollId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            String query = String.Format("select * from T_PollOption where PollId={0}", PollId);
            return helper.ExecuteDataset(query);
        }
        /// <summary>
        /// 选答案
        /// </summary>
        /// <param name="PollOptionId">答案的标识</param>
        public void AddVote(int PollOptionId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string sql = String.Format("update T_PollOption set Votes=Votes+1 where PollOptionId={0}", PollOptionId);
            helper.ExecuteNonQuery(sql);
        }
    }
}
