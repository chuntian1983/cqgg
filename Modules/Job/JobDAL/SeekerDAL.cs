using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonUtility.DBUtility;

namespace Modules.Job
{
    internal class SeekerDAL
    {
        public DataSet GetAllOffers()
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder query = new StringBuilder();
            query.Append("Select a.* ,b.SendDate,b.SendOfferId,c.Description,d.[Name] DepartName ");
            query.Append("From T_Job_Seeker a inner join R_Job_SendOffer b on a.SeekerId=b.PostId ");
            query.Append("inner join T_Job_Post c on b.SeekerID=c.PostId ");
            query.Append("inner join T_Job_Department d on c.DepartmentId=d.DepartmentId");
            return helper.ExecuteDataset(query.ToString());
        }

        public DataSet GetOneOffer(int pid)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder query = new StringBuilder();
            query.Append("Select a.* ,b.SendDate,b.SendOfferId,c.Description,d.[Name] DepartName ");
            query.Append("From T_Job_Seeker a inner join R_Job_SendOffer b on a.SeekerId=b.PostId ");
            query.Append("inner join T_Job_Post c on b.SeekerID=c.PostId ");
            query.Append("inner join T_Job_Department d on c.DepartmentId=d.DepartmentId ");
            query.Append("where a.SeekerID=" + pid + "");
            return helper.ExecuteDataset(query.ToString());
        }

        /// <summary>
        /// 删除应聘人员信息
        /// </summary>

        public bool DeleteOffer(int OfferId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            IDataParameter[] paras = new IDataParameter[1];
            paras[0] = helper.GetParameter("@OfferId", OfferId);
            return helper.ExecuteNonQuery("sp_Job_DelOffer", paras) > 0;
        }
       
    }
}
