using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Modules.Poll
{
    /// <summary>
    /// 网上调查的业务逻辑接口
    /// </summary>
    public class PollBLL
    {
        /// <summary>
        /// 添加一个网上调查
        /// </summary>
        /// <param name="pollText">内容</param>
        /// <param name="addedUserId">添加人标识</param>
        /// <returns>调查标识</returns>
        public int Create(string pollText,int addedUserId)
        {
            return new PollDAL().Add(pollText, addedUserId, 1);
        }
        /// <summary>
        /// 获取网上调查
        /// </summary>
        /// <param name="pollId">调查标识</param>
        /// <returns>网上调查（DataRow形式）</returns>
        public DataRow GetPoll(int pollId)
        {
            return new PollDAL().Retrieve(pollId);
        }
        /// <summary>
        /// 获取网上调查
        /// </summary>
        /// <param name="pollId">调查标识</param>
        /// <returns>网上调查（PollDetail形式）</returns>
        public PollDetail GetPollDetail(int pollId)
        {
            return new PollDAL().GetDetail(pollId);
        }
        
    }
}
