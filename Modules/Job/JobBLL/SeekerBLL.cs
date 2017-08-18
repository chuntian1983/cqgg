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
        /// 删除应聘人信息
        /// </summary>
      
        public bool Delete(int OfferId)
        {
            return new SeekerDAL().DeleteOffer(OfferId);
        }


       

        ///// <summary>
        ///// 新添加的　应聘工作岗位的审核071112 Yj
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
