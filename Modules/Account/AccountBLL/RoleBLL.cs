using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections;

namespace Modules.Account
{
    /// <summary>
    /// 角色的业务逻辑层
    /// </summary>
    public class RoleBLL
    {
        /// <summary>
        /// 获取角色信息(RoleDetail形式)
        /// </summary>
        /// <param name="roleId">角色标识</param>
        /// <returns>角色信息(RoleDetail形式)</returns>
        public RoleDetail GetRoleDetail(int roleId)
        {
            return new RoleDAL().GetRoleDetail(roleId);
        }

        /// <summary>
        /// 更新角色信息
        /// </summary>
        /// <param name="detail">角色信息(RoleDetail形式)</param>
        /// <returns>成功 返回true</returns>
        public bool Update(RoleDetail detail)
        {
           return new RoleDAL().Update(detail);
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="detail">角色信息(RoleDetail形式)</param>
        /// <returns>角色标识</returns>
        public int Add(RoleDetail detail)
        {
            return new RoleDAL().Add(detail);
        }
        /// <summary>
        /// 获取系统的所有角色
        /// </summary>
        /// <returns>所有角色</returns>
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
        /// 删除角色
        /// </summary>
        /// <param name="roleId">角色标识</param>
        /// <returns>成功 返回true</returns>
        public bool Delete(int roleId)
        {
            return new RoleDAL().Delete(roleId);
        }

        /// <summary>
        /// 保存角色的菜单权限
        /// </summary>
        /// <param name="roleId">角色标识</param>
        /// <param name="menuTree">菜单树</param>
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
