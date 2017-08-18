using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Modules.Poll
{
    public class PollOptionBLL
    {
        /// <summary>
        /// 添加网上调查的答案
        /// </summary>
        /// <param name="optionText">答案</param>
        /// <param name="addedUserId">添加答案的人</param>
        /// <param name="pollId">网上调查的标识</param>
        /// <returns>答案的标识</returns>
        public int Create(string optionText, int addedUserId, int pollId)
        {
            return new PollOptionDAL().Add(optionText, addedUserId, pollId);
        }
        /// <summary>
        /// 获取网上调查的答案
        /// </summary>
        /// <param name="PollOptionId">网上调查的标识</param>
        /// <returns>网上调查的答案</returns>
        public DataSet GetPollOption(int pollId)
        {
            return new PollOptionDAL().GetPollOptionByPollId(pollId);
        }
        /// <summary>
        /// 选答案
        /// </summary>
        /// <param name="pollOptionId">答案标识</param>
        public void AddVote(int pollOptionId)
        {
            new PollOptionDAL().AddVote(pollOptionId);
        }
    }
}
