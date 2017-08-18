using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Modules.Job
{
    public class SeekerBLL
    {
        public DataSet GetAllOffers()
        {
            return new SeekerDAL().GetAllOffers();
        }
        public DataSet GetOneOffer(int pid)
        {
            return new SeekerDAL().GetOneOffer(pid);
        }
        /// <summary>
        /// ɾ��ӦƸ����Ϣ
        /// </summary>
      
        public bool Delete(int OfferId)
        {
            return new SeekerDAL().DeleteOffer(OfferId);
        }


       

        ///// <summary>
        ///// ����ӵġ�ӦƸ������λ�����071112 Yj
        ///// </summary>
        ///// <param name="postId"></param>
        //public void ChangeApprovedStatus(int seekerId)
        //{
        //    SeekerBLL seeker = new SeekerBLL();
        //    int status = seeker.GetModel(seekerId).Approved;
        //    if (status == 0) seeker.ApproveSeek(seekerId, true);
        //    else seeker.ApproveSeek(seekerId, false);
        //}
    }
}
