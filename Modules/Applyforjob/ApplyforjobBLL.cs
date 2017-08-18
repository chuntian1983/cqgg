using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Modules.Applyforjob;

namespace Modules.Applyforjob
{
   public class ApplyforjobBLL
    {
       ApplyforjobDAL dal = new ApplyforjobDAL();
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
        public void Add(T_ApplyforJobModel model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
       public void Update(T_ApplyforJobModel model)
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
       public T_ApplyforJobModel GetModel(int UserID)
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
        /// �õ���ְ��ԱӦƸ��Ϣ(����:��ְ�������ְ����)�б�(���ں�̨)
        /// </summary>
        public DataSet GetPersonInfoList(string strWhere)
        {
            return dal.GetPersonInfoList(strWhere);
        }

        /// <summary>
        /// ���ݻ�Ա��ŵõ�������ְ��Ա��ϸ��Ϣ(����:��ְ�������ְ����)
        /// </summary>
       public DataSet GetOnePersonInfo(int MemberId)
        {
            return dal.GetOnePersonInfo(MemberId);
        }

       /// <summary>
       /// ȡ�ø��˻�ԱӦƸ��Ϣ�б�
       /// </summary>
       public DataSet GetYPList(string where)
       {
           return dal.GetYPList(where);
       }

       /// <summary>
       ///  ȡ�ø��˻�ԱӦƸ��Ϣ
       /// </summary>
       public DataSet GetYPInfo(int YPId)
       {
           return dal.GetYPInfo(YPId);         
       }

       /// <summary>
       /// ɾ�����˻�ԱӦƸ��Ϣ(��ҵ�û�ɾ��)
       /// </summary>
       public void DeleteYPInfo(int SenderOfferId)
       {
           dal.DeleteYPInfo(SenderOfferId);
       }
       /// <summary>
       /// ɾ�����˻�ԱӦƸ��Ϣ(�����û�ɾ��)
       /// </summary>
       public void DeleteYPInfo1(int CollectId)
       {
           dal.DeleteYPInfo1(CollectId);
       }
       /// <summary>
       /// ����ӦƸ��Ա����
       /// </summary>
       /// <param name="seekerId"></param>
       public void ChangeApprovedStatus(int SendOfferId)
       {
          int status=dal.GetState(SendOfferId);
          dal.ChangeApprovedStatus(SendOfferId, status);
        }

       /// <summary>
       /// �����ҳ��ְ��Ϣ�б� ȡǰN��
       /// </summary>
       /// <returns></returns>
       public DataSet GetIndexQZList(int Num)
       {
           return dal.GetIndexQZList(Num);
       }

       /// <summary>
       /// //�õ���ҳ��Ƹ��Ϣ�б�ĵ�λ����(ȥ���ظ�) ȡǰN��
       /// </summary>
       /// <returns></returns>
       public DataSet GetIndexYPList(int Num)
       {
           return dal.GetIndexYPList(Num);
       }

       /// <summary>
       /// 08�Ƽ�
       /// </summary>
       /// <returns></returns>
       public DataSet GetYPList1(int Num)
       {
           return dal.GetYPList1(Num);
       }

      
       /// <summary>
       /// ������Ƹ��Ϣ��ID���ȡ�ø�λ��Ϣ(��ҳ)
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
       public DataSet GetGwNameByID(int Id)
       {
           return dal.GetGwNameByID(Id);
       }
       /// <summary>
       /// ������Ƹ��Ϣ��ID���ȡ�ø�λ��Ϣ(�ؼ�)
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
       public DataSet GetGwNameByID1(int Id)
       {
           return dal.GetGwNameByID1(Id);
       }
        #endregion  ��Ա����
    }
}
