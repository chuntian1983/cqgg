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
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int UserID)
        {
            return dal.Exists(UserID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Add(T_CompanyInfoMoel model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
       public void Update(T_CompanyInfoMoel model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
       public void Delete(int UserID)
        {
            dal.Delete(UserID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
       public T_CompanyInfoMoel GetModel(int UserID)
        {
            return dal.GetModel(UserID);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }


        /// <summary>
        ///�Ƽ���λ
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
       ///// ���ݳ�Ա���ȡ����ҵ��Ա��Ϣ
       ///// </summary>
       //public DataSet GetCommpanyInfo(int MemberID)
       //{
       //    return dal.GetCompanyInfo(MemberID);
       //}
        #endregion  ��Ա����
    }
}
