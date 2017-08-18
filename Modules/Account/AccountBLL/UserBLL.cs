using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace Modules.Account
{
    /// <summary>
    /// �û�ҵ���߼���
    /// </summary>
    public class UserBLL
    {
        /// <summary>
        /// ��ȡ�û���ϸ��Ϣ
        /// </summary>
        /// <param name="userId">�û���ʶ</param>
        /// <returns>�û���ϸ��Ϣ</returns>
        public UserDetail GetUserDetail(int userId)
        {
           return new UserDAL().GetUserDetail(userId);
        }
        /// <summary>
        /// ��ȡ�û��Ľ�ɫ��ʶ�б�
        /// </summary>
        /// <param name="userId">�û���ʶ</param>
        /// <returns>��ɫ��ʶ�б�</returns>
        public ArrayList GetUserRoles(int userId)
        {
            return new UserDAL().GetUserRoles(userId);
        }
        /// <summary>
        /// ����û�
        /// </summary>
        /// <param name="detail">�û���ϸ��Ϣ��UserDetail��ʽ��</param>
        /// <returns>�û���ʶ</returns>
        public int Add(UserDetail detail)
        {
            return new UserDAL().Add(detail);
        }

        /// <summary>
        /// �޸��û���Ϣ
        /// </summary>
        /// <param name="detail">�û���ϸ��Ϣ��UserDetail��ʽ��</param>
        /// <returns>�ɹ� ����true</returns>
        public bool Update(UserDetail detail)
        {
            return new UserDAL().Update(detail);
        }

        /// <summary>
        /// ɾ���û�
        /// </summary>
        /// <param name="userId">�û���ʶ</param>
        /// <returns>�ɹ� ����true</returns>
        public bool Delete(int userId)
        {
            return new UserDAL().DeleteUser(userId);
        }
        /// <summary>
        /// ɾ���û��ı��ʶ
        /// </summary>
        /// <param name="userId">�û���ʶ</param>
        /// <returns>�ɹ� ����true</returns>
        public bool DeleteUserChange(int userId)
        {
            return new UserDAL().DeleteUserChange(userId);
        }
        /// <summary>
        /// �ı��û��Ľ�ɫ
        /// </summary>
        /// <param name="userId">�û���ʶ</param>
        /// <param name="roleId">��ɫ��ʾ</param>
        public void ChangeUserRole(int userId, int roleId)
        {
            UserDAL user = new UserDAL();
            user.DeleteAllRoles(userId);
            user.AddRole(userId, roleId);
        }
        /// <summary>
        /// ȡ�¼�����id�ͱ�������id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetDeptid(string id)
        {
            return new UserDAL().GetDeptid(id);
        }
        /// <summary>
        /// ��ȡ�����������û�
        /// </summary>
        /// <param name="filter">��������</param>
        /// <param name="sort">����</param>
        /// <returns>�û���</returns>
        public DataSet GetUserList(string filter, string sort)
        {
            return new UserDAL().GetUsers(filter, sort);
        }
        /// <summary>
        /// �ı����״̬
        /// </summary>
        /// <param name="userId">�û���ʶ</param>
        public void ChangeApprovedStatus(int userId)
        {
            UserDAL user = new UserDAL();
            int status=user.GetUserDetail(userId).Approved;
            if (status == 0) user.Approve(userId, true);
            else user.Approve(userId, false);
        }
        /// <summary>
        /// �޸�����
        /// </summary>
        /// <param name="userId">�û���ʶ</param>
        /// <param name="pwd">ԭʼ����</param>
        /// <returns>�ɹ� ���� true</returns>
        public bool ModifyPwd(int userId, string pwd)
        {
            return new UserDAL().ModifyPwd(userId, CustomPrincipal.EncryptPassword(pwd));
        }

        /// <summary>
        /// ��֤���������
        /// </summary>
        /// <param name="userId">�û���ʶ</param>
        /// <param name="pwd">ԭʼ����</param>
        /// <returns>��֤�ɹ� ����true</returns>
        public bool ValidatePwd(int userId, string pwd)
        {
            UserDAL user = new UserDAL();
            UserDetail detail = user.GetUserDetail(userId);
            string encPwd = CustomPrincipal.EncryptPassword(pwd);
            return encPwd.Equals(detail.Password);
        }
        public bool ExistNickname(string nickname)
        {
            return new UserDAL().GetUserDetail(nickname) != null;
        }
        public DataSet GetUsers(string where)
        {
            return new UserDAL().GetUsers(where);
        }
        
    }
}
