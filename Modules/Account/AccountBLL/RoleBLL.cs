using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections;

namespace Modules.Account
{
    /// <summary>
    /// ��ɫ��ҵ���߼���
    /// </summary>
    public class RoleBLL
    {
        /// <summary>
        /// ��ȡ��ɫ��Ϣ(RoleDetail��ʽ)
        /// </summary>
        /// <param name="roleId">��ɫ��ʶ</param>
        /// <returns>��ɫ��Ϣ(RoleDetail��ʽ)</returns>
        public RoleDetail GetRoleDetail(int roleId)
        {
            return new RoleDAL().GetRoleDetail(roleId);
        }

        /// <summary>
        /// ���½�ɫ��Ϣ
        /// </summary>
        /// <param name="detail">��ɫ��Ϣ(RoleDetail��ʽ)</param>
        /// <returns>�ɹ� ����true</returns>
        public bool Update(RoleDetail detail)
        {
           return new RoleDAL().Update(detail);
        }

        /// <summary>
        /// ��ӽ�ɫ
        /// </summary>
        /// <param name="detail">��ɫ��Ϣ(RoleDetail��ʽ)</param>
        /// <returns>��ɫ��ʶ</returns>
        public int Add(RoleDetail detail)
        {
            return new RoleDAL().Add(detail);
        }
        /// <summary>
        /// ��ȡϵͳ�����н�ɫ
        /// </summary>
        /// <returns>���н�ɫ</returns>
        public DataSet GetRoleList()
        {
            return GetRoleList(null);
        }
        public DataSet GetRoleList(int[] limitRoleIds)
        { 
            DataSet ds=new RoleDAL().GetAllRoles();
            if (limitRoleIds == null || limitRoleIds.Length == 0) return ds;
            DataTable dt = ds.Tables[0];

            foreach (int roleId in limitRoleIds)
            {
                DataRow[] dr = dt.Select(String.Format("RoleId={0}", roleId));
                if (dr.Length == 1)
                {
                    dt.Rows.Remove(dr[0]);
                }
            }
            return ds;
        }
        /// <summary>
        /// ɾ����ɫ
        /// </summary>
        /// <param name="roleId">��ɫ��ʶ</param>
        /// <returns>�ɹ� ����true</returns>
        public bool Delete(int roleId)
        {
            return new RoleDAL().Delete(roleId);
        }

        /// <summary>
        /// �����ɫ�Ĳ˵�Ȩ��
        /// </summary>
        /// <param name="roleId">��ɫ��ʶ</param>
        /// <param name="menuTree">�˵���</param>
        public void SaveMenuPermission(int roleId,TreeNode menuTree)
        {
            RoleDAL role = new RoleDAL();
            int permissionId = Convert.ToInt32(menuTree.Value);
            if (permissionId != 0)
            {
                if (menuTree.Checked) 
                    role.AddPermission(roleId, permissionId);
                else
                    role.DeletePermission(roleId, permissionId);
            }
            foreach (TreeNode child in menuTree.ChildNodes)
            {

                SaveMenuPermission(roleId, child);
            }
        }
        public void AssignRolePermissionToMenuTree(int roleId,TreeNode menuTree)
        {
            ArrayList permissionList = new RoleDAL().GetMenuPermissionList(roleId);
            IEnumerator e=permissionList.GetEnumerator();
            while (e.MoveNext())
            {
                int permissionId = (int)(e.Current);
                TreeNode node = RecursiveSearch(menuTree, permissionId);
                if (node != null) node.Checked = true;
            }
        }
        private TreeNode RecursiveSearch(TreeNode node,int menuId)
        {
            int val = Convert.ToInt32(node.Value);
            if (menuId == val) return node;
            foreach (TreeNode child in node.ChildNodes)
            {
                TreeNode temp = RecursiveSearch(child, menuId);
                if (temp != null)
                {
                    return temp;
                }
            }
            return null;
        }
    }
}
