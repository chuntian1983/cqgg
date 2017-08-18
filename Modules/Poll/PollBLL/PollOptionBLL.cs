using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Modules.Poll
{
    public class PollOptionBLL
    {
        /// <summary>
        /// ������ϵ���Ĵ�
        /// </summary>
        /// <param name="optionText">��</param>
        /// <param name="addedUserId">��Ӵ𰸵���</param>
        /// <param name="pollId">���ϵ���ı�ʶ</param>
        /// <returns>�𰸵ı�ʶ</returns>
        public int Create(string optionText, int addedUserId, int pollId)
        {
            return new PollOptionDAL().Add(optionText, addedUserId, pollId);
        }
        /// <summary>
        /// ��ȡ���ϵ���Ĵ�
        /// </summary>
        /// <param name="PollOptionId">���ϵ���ı�ʶ</param>
        /// <returns>���ϵ���Ĵ�</returns>
        public DataSet GetPollOption(int pollId)
        {
            return new PollOptionDAL().GetPollOptionByPollId(pollId);
        }
        /// <summary>
        /// ѡ��
        /// </summary>
        /// <param name="pollOptionId">�𰸱�ʶ</param>
        public void AddVote(int pollOptionId)
        {
            new PollOptionDAL().AddVote(pollOptionId);
        }
    }
}
