using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;

namespace Modules.Menu
{
    public class MenuEntity
    {
        public MenuEntity(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }
        public string Name;
        public string Id;
    }
    public class MenuBLL
    {
        /// <summary>
        /// 获取用户的父菜单项下的所有子菜单
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <param name="parentMenuPermissionId">父菜单项标识</param>
        /// <returns>所有子菜单</returns>
        public DataSet GetChildMenuItem(int userId, int parentMenuPermissionId)
        {
            return new MenuDAL().RetrieveChildMenuItem(userId, parentMenuPermissionId);
        }
        /// <summary>
        /// 获取用户的所有顶级菜单项
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <returns>该用户的所有顶级菜单项</returns>
        public DataSet GetTopMenuItem(int userId)
        {
            return new MenuDAL().RetrieveChildMenuItem(userId, 0);
        }
        /// <summary>
        /// 获取站点的所有菜单项
        /// </summary>
        /// <returns>站点的所有菜单项</returns>
        public DataSet GetAllMenuItem()
        {
            return new MenuDAL().RetrieveAllMenuItem();
        }

        #region 添加或者修改菜单时，所有的可选菜单项
        
        public ArrayList AllMenuItemForUpdate()
        {
            ArrayList validMenuItems = new ArrayList();
            DataSet allMenu = new MenuDAL().RetrieveAllMenuItem();
            validMenuItems.Add(new MenuEntity("<站点>", "0"));
            this.RecursionFill(allMenu, validMenuItems, "0", 1);
            return validMenuItems;
        }

        private void RecursionFill(DataSet dataSource, ArrayList targetToFill, string parentMenuId, int level)
        {
            if (level == 5) return;
            DataRow[] childMenuItems = dataSource.Tables[0].Select(String.Format("ParentMenuId={0}", parentMenuId));
            foreach (DataRow menuItems in childMenuItems)
            {
                string menuName = GetAppropriateMenuName(menuItems["Description"].ToString(), level);
                string menuId = menuItems["PermissionId"].ToString();
                targetToFill.Add(new MenuEntity(menuName, menuId));
                RecursionFill(dataSource, targetToFill, menuId, level + 1);
            }
        }
        private string GetAppropriateMenuName(string menuName, int level)
        {
            StringBuilder sb = new StringBuilder();
            for (; level > 0; level--)
            {
                sb.Append("－－");
            }
            sb.Append(menuName);
            return sb.ToString();
        }
        #endregion

        #region 获取菜单树
        /// <summary>
        /// 获取菜单树
        /// </summary>
        /// <returns>菜单树</returns>

        public TreeNode GetMenuTreeWithLimit(bool showDetail, int[] permissions)
        {
            return Modules.Utility.TreeNodeUtil.EnableSelected(GetMenuTree(showDetail), permissions);
        }
        public TreeNode GetMenuTree(bool showDetail)
        {
            TreeNode root = new TreeNode("站点", "0");
            root.SelectAction = TreeNodeSelectAction.Expand;
            MenuDAL menu = new MenuDAL();
            DataSet childMenuItem = menu.RetrieveAllMenuItem();
            AddChildNode(childMenuItem,root, root.Value,showDetail);
            return root;
        }

        public TreeNode GetMenuTree()
        {
            return GetMenuTree(false);
        }

        /// <summary>
        /// 将子菜单项递归添加到父菜单项下
        /// </summary>
        /// <param name="dataSource">数据来源</param>
        /// <param name="parentNode">父节点</param>
        /// <param name="parentMenuId">父节点标识</param>
        private void AddChildNode(DataSet dataSource, TreeNode parentNode, string parentMenuId,bool showDetail)
        {
            DataRow[] childMenuItems = dataSource.Tables[0].Select(String.Format("ParentMenuId={0}", parentMenuId),"Sort");
            if (childMenuItems.Length> 0)
            {
                foreach (DataRow dr in childMenuItems)
                {
                    string description = dr["Description"].ToString();
                    string menuId = dr["PermissionId"].ToString();
                    string sort = dr["Sort"].ToString();
                    string visible = Convert.ToBoolean(dr["IsVisible"] )? "是" : "否";
                    string text;
                    if (showDetail)
                        text = String.Format("{0} <span style=\"color:red;\">[ 标识:{1},排序号:{2},可见:{3} ]</span>", description, menuId, sort,visible);
                    else
                        text = description;
                    TreeNode childNode = new TreeNode(text, menuId);
                    childNode.ShowCheckBox = true;
                    childNode.SelectAction = TreeNodeSelectAction.Expand;
                    parentNode.ChildNodes.Add(childNode);
                    AddChildNode(dataSource,childNode, menuId,showDetail);
                }
            }
        }
        #endregion

        #region 获取树中被选中的节点
        /// <summary>
        /// 获取树中被选中的节点
        /// </summary>
        /// <param name="root">树的跟节点</param>
        /// <returns>被选中的节点</returns>
        public ArrayList GetSelectedTreeNodes(TreeNode root)
        {
            return Modules.Utility.TreeNodeUtil.GetSelectedTreeNodes(root);
           
        }
       
        #endregion
 
        /// <summary>
        /// 获取菜单项详细信息
        /// </summary>
        /// <param name="menuId">菜单项标识</param>
        /// <returns>菜单项详细信息</returns>
        public MenuDetail GetMenuDetail(int menuId)
        {
            return new MenuDAL().GetMenuDetail(menuId);
        }

        /// <summary>
        /// 添加菜单项
        /// </summary>
        /// <param name="name">描述</param>
        /// <param name="menuLink">菜单项连接</param>
        /// <param name="imageLink">图片连接</param>
        /// <param name="sort">排序</param>
        /// <param name="isVisible">是否可见</param>
        /// <param name="parentMenuId">父菜单项标识</param>
        /// <returns>新创建的菜单项标识</returns>
        public int Add(string name, string menuLink,string imageLink, int sort,int isVisible, int parentMenuId)
        {
            return new MenuDAL().Add(name, menuLink,imageLink, sort,isVisible, parentMenuId);
        }

        /// <summary>
        /// 添加菜单项
        /// </summary>
        /// <param name="detail">菜单项详细信息</param>
        /// <returns>新创建的菜单项标识</returns>
        public int Add(MenuDetail detail)
        {
            return new MenuDAL().Add(detail);
        }

        /// <summary>
        /// 更新菜单项
        /// </summary>
        /// <param name="menuId">菜单项标识</param>
        /// <param name="name">描述</param>
        /// <param name="menuLink">菜单项连接</param>
        /// <param name="imageLink">图片连接</param>
        /// <param name="sort">排序</param>
        /// <param name="isVisible">是否可见</param>
        /// <param name="parentMenuId">父菜单项标识</param>
        /// <returns>更新成功，返回true</returns>
        public bool Update(int menuId, string name, string menuLink, string imageLink, int sort, int isVisible, int parentMenuId)
        {
            return new MenuDAL().Update(menuId, name, menuLink,imageLink, sort,isVisible, parentMenuId);
        }

        /// <summary>
        /// 更新菜单项
        /// </summary>
        /// <param name="detail">菜单项详细信息</param>
        /// <returns>更新成功，返回true</returns>
        public bool Update(MenuDetail detail)
        {
            return new MenuDAL().Update(detail);
        }

        /// <summary>
        /// 删除叶节点菜单项，非叶节点无法删除
        /// </summary>
        /// <param name="menuId">菜单项标识</param>
        /// <returns>删除 返回true ,否则false</returns>
        public bool Delete(int menuId)
        {
            return new MenuDAL().Delete(menuId);
        }
        /// <summary>
        /// 删除叶节点菜单项集，非叶节点无法删除
        /// </summary>
        /// <param name="menuIds">菜单项标识集</param>
        /// <returns>全部删除 返回true ,否则false</returns>
        public bool Delete(int[] menuIds)
        {
            return new MenuDAL().Delete(menuIds);
        }
    }
}
