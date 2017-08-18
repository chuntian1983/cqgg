using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Modules.Poll
{
    /// <summary>
    /// ���ϵ����ҵ���߼��ӿ�
    /// </summary>
    public class PollBLL
    {
        /// <summary>
        /// ���һ�����ϵ���
        /// </summary>
        /// <param name="pollText">����</param>
        /// <param name="addedUserId">����˱�ʶ</param>
        /// <returns>�����ʶ</returns>
        public int Create(string pollText,int addedUserId)
        {
            return new PollDAL().Add(pollText, addedUserId, 1);
        }
        /// <summary>
        /// ��ȡ���ϵ���
        /// </summary>
        /// <param name="pollId">�����ʶ</param>
        /// <returns>���ϵ��飨DataRow��ʽ��</returns>
        public DataRow GetPoll(int pollId)
        {
            return new PollDAL().Retrieve(pollId);
        }
        /// <summary>
        /// ��ȡ���ϵ���
        /// </summary>
        /// <param name="pollId">�����ʶ</param>
        /// <returns>���ϵ��飨PollDetail��ʽ��</returns>
        public PollDetail GetPollDetail(int pollId)
        {
            return new PollDAL().GetDetail(pollId);
        }
        
    }
}
