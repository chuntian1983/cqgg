using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Modules.Personal;

namespace Modules.Personal
{
    public class PersonalBLL
    {
        PersonalDAL dal = new PersonalDAL();
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
        public void Add(T_PersonalModel model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(T_PersonalModel model)
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
        public T_PersonalModel GetModel(int UserID)
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
        /// �ϴ�������Ƭ
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="Src"></param>
        public void UpdatePic(int UserId, string Src)
        {
            dal.UpdatePic(UserId,Src);
        }

        /// <summary>
        /// ��ø�����Ƭ
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public string GetPic(int UserId)
        {
            return dal.GetPic(UserId);
        }
        #endregion  ��Ա����
    }
}
