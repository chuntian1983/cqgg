using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Modules.LoginRecorder;

namespace Modules.LoginRecorder
{
    public class LoginRecorderBLL
    {
        LoginRecorderDAL dal = new LoginRecorderDAL();
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Add(T_LoginRecorderModel model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(T_LoginRecorderModel model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int ID)
        {
            dal.Delete(ID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public T_LoginRecorderModel GetModel(int MemberID)
        {
            return dal.GetModel(MemberID);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        //���ݳ�Ա���ȡ�ó�Ա�û���
        public string GetNickName(int MemberId)
        {
            return dal.GetNickName(MemberId);
        }
        
        #endregion  ��Ա����
    }
}
