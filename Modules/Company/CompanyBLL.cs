using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Modules.Company; 

namespace Modules.Company
{
   public class CompanyBLL
    {
       CompanyDAL dal = new CompanyDAL();
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserID)
        {
            return dal.Exists(UserID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(T_CompanyInfoMoel model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
       public void Update(T_CompanyInfoMoel model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
       public void Delete(int UserID)
        {
            dal.Delete(UserID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
       public T_CompanyInfoMoel GetModel(int UserID)
        {
            return dal.GetModel(UserID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }


        /// <summary>
        ///推荐单位
        /// </summary>
        /// <param name="postId"></param>
       public int ChangeTjStatus(int UserID)
        {
            if (dal.Exists(UserID) == false)
            {
                return 0;
            }
            else
            {
                int status = dal.GetModel(UserID).Tj1;
                if (status == 0) dal.TjCompany(UserID, true);
                else dal.TjCompany(UserID, false);
                return 1;
            }
        }

       public int Change08TjStatus(int UserID)
       {
           if (dal.Exists(UserID) == false)
           {
               return 0;
           }
           else
           {
               int status =Int32.Parse(dal.Tj08(UserID)) ;
               if (status == 0) dal.TjCompany08(UserID, true);
               else dal.TjCompany08(UserID, false);
               return 1;
           }
       }
       ///// <summary>
       ///// 根据成员编号取得企业会员信息
       ///// </summary>
       //public DataSet GetCommpanyInfo(int MemberID)
       //{
       //    return dal.GetCompanyInfo(MemberID);
       //}
        #endregion  成员方法
    }
}
