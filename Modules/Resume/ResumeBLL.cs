using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Modules.Resume
{
    public class ResumeBLL
    {
        ResumeDAL dal = new ResumeDAL();
    
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
            public void Add(T_ResumeModel model)
            {
                dal.Add(model);
            }

            /// <summary>
            /// ����һ������
            /// </summary>
            public void Update(T_ResumeModel model)
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
            /// �õ�һ������ʵ��(ȫ��)
            /// </summary>
            public T_ResumeModel GetModel(int UserID)
            {
                return dal.GetModel(UserID);
            }

            /// <summary>
            /// �õ�һ������ʵ��(�����)
            /// </summary>
            public T_ResumeModel GetModel1(int UserID)
            {
                return dal.GetModel1(UserID);
            }

            /// <summary>
            /// ��������б�
            /// </summary>
            public DataSet GetList(string strWhere)
            {
                return dal.GetList(strWhere);
            }

            // <summary>
            ///�޸ĸ��˻�Ա����ְ���������״̬
            /// </summary>
            /// <param name="postId"></param>
            public void ChangeApprovedStatus(int UserID)
            {
                int status = dal.GetModel(UserID).Approved;
                if (status == 0)dal.ApproveUserResume(UserID, true);
                else dal.ApproveUserResume(UserID, false);
            }

            /// <summary>
            /// //���ݸ��˻�Ա���ȡ�û�Ա��ϸ����(������ְ����͸��˼����Լ���Ա������Ϣ)
            /// </summary>
            /// <param name="UserId"></param>
            /// <returns></returns>
            public DataSet GetAllResumeByID(int UserId)
            {
                return dal.GetAllResumeByID(UserId);
            }


        public int GetWeeklyResumeNum()
        {
            return dal.GetWeeklyResumeNum();
        }

        public int GetTotalResumeNum()
        {
            return dal.GetTotalResumeNum();
        }
            #endregion  ��Ա����

        }
}
