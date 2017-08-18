using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Modules.Applyforjob
{
    public class CollectBLL
    {
        CollectDAL dal = new CollectDAL();
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int CollectId)
        {
            return dal.Exists(CollectId);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Add(R_Job_CollectModel model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(R_Job_CollectModel model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int CollectId)
        {
            dal.Delete(CollectId);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public R_Job_CollectModel GetModel(int CollectId)
        {
            return dal.GetModel(CollectId);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// ������˻�Ա����ø�λ�����ӦƸ��Ϣ��¼����
        /// </summary>
        /// <param name="ID"></param>
        public void InsertSent(int UserId, int PostId)
        {
            dal.InsertSent(UserId, PostId);
        }


        /// <summary>
        ///�����û�����ź͸�λ��ŵõ���¼������(0:���ղ� 1:������)
        /// </summary>
        /// <param name="MemberId"></param>
        /// <param name="PostId"></param>
        /// <returns></returns>
        public DataSet CheceCollectInfo(int MemberId, int PostId)
        {
            return dal.CheceCollectInfo(MemberId, PostId);
        }

        #endregion  ��Ա����
    }
}
