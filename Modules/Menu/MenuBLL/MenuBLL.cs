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
        /// ��ȡ�û��ĸ��˵����µ������Ӳ˵�
        /// </summary>
        /// <param name="userId">�û���ʶ</param>
        /// <param name="parentMenuPermissionId">���˵����ʶ</param>
        /// <returns>�����Ӳ˵�</returns>
        public DataSet GetChildMenuItem(int userId, int parentMenuPermissionId)
        {
            return new MenuDAL().RetrieveChildMenuItem(userId, parentMenuPermissionId);
        }
        /// <summary>
        /// ��ȡ�û������ж����˵���
        /// </summary>
        /// <param name="userId">�û���ʶ</param>
        /// <returns>���û������ж����˵���</returns>
        public DataSet GetTopMenuItem(int userId)
        {
            return new MenuDAL().RetrieveChildMenuItem(userId, 0);
        }
        /// <summary>
        /// ��ȡվ������в˵���
        /// </summary>
        /// <returns>վ������в˵���</returns>
        public DataSet GetAllMenuItem()
        {
            return new MenuDAL().RetrieveAllMenuItem();
        }

        #region ��ӻ����޸Ĳ˵�ʱ�����еĿ�ѡ�˵���
        
        public ArrayList AllMenuItemForUpdate()
        {
            ArrayList validMenuItems = new ArrayList();
            DataSet allMenu = new MenuDAL().RetrieveAllMenuItem();
            validMenuItems.Add(new MenuEntity("<վ��>", "0"));
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
                sb.Append("����");
            }
            sb.Append(menuName);
            return sb.ToString();
        }
        #endregion

        #region ��ȡ�˵���
        /// <summary>
        /// ��ȡ�˵���
        /// </summary>
        /// <returns>�˵���</returns>

        public TreeNode GetMenuTreeWithLimit(bool showDetail, int[] permissions)
        {
            return Modules.Utility.TreeNodeUtil.EnableSelected(GetMenuTree(showDetail), permissions);
        }
        public TreeNode GetMenuTree(bool showDetail)
        {
            TreeNode root = new TreeNode("վ��", "0");
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
        /// ���Ӳ˵���ݹ���ӵ����˵�����
        /// </summary>
        /// <param name="dataSource">������Դ</param>
        /// <param name="parentNode">���ڵ�</param>
        /// <param name="parentMenuId">���ڵ��ʶ</param>
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
                    string visible = Convert.ToBoolean(dr["IsVisible"] )? "��" : "��";
                    string text;
                    if (showDetail)
                        text = String.Format("{0} <span style=\"color:red;\">[ ��ʶ:{1},�����:{2},�ɼ�:{3} ]</span>", description, menuId, sort,visible);
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

        #region ��ȡ���б�ѡ�еĽڵ�
        /// <summary>
        /// ��ȡ���б�ѡ�еĽڵ�
        /// </summary>
        /// <param name="root">���ĸ��ڵ�</param>
        /// <returns>��ѡ�еĽڵ�</returns>
        public ArrayList GetSelectedTreeNodes(TreeNode root)
        {
            return Modules.Utility.TreeNodeUtil.GetSelectedTreeNodes(root);
           
        }
       
        #endregion
 
        /// <summary>
        /// ��ȡ�˵�����ϸ��Ϣ
        /// </summary>
        /// <param name="menuId">�˵����ʶ</param>
        /// <returns>�˵�����ϸ��Ϣ</returns>
        public MenuDetail GetMenuDetail(int menuId)
        {
            return new MenuDAL().GetMenuDetail(menuId);
        }

        /// <summary>
        /// ��Ӳ˵���
        /// </summary>
        /// <param name="name">����</param>
        /// <param name="menuLink">�˵�������</param>
        /// <param name="imageLink">ͼƬ����</param>
        /// <param name="sort">����</param>
        /// <param name="isVisible">�Ƿ�ɼ�</param>
        /// <param name="parentMenuId">���˵����ʶ</param>
        /// <returns>�´����Ĳ˵����ʶ</returns>
        public int Add(string name, string menuLink,string imageLink, int sort,int isVisible, int parentMenuId)
        {
            return new MenuDAL().Add(name, menuLink,imageLink, sort,isVisible, parentMenuId);
        }

        /// <summary>
        /// ��Ӳ˵���
        /// </summary>
        /// <param name="detail">�˵�����ϸ��Ϣ</param>
        /// <returns>�´����Ĳ˵����ʶ</returns>
        public int Add(MenuDetail detail)
        {
            return new MenuDAL().Add(detail);
        }

        /// <summary>
        /// ���²˵���
        /// </summary>
        /// <param name="menuId">�˵����ʶ</param>
        /// <param name="name">����</param>
        /// <param name="menuLink">�˵�������</param>
        /// <param name="imageLink">ͼƬ����</param>
        /// <param name="sort">����</param>
        /// <param name="isVisible">�Ƿ�ɼ�</param>
        /// <param name="parentMenuId">���˵����ʶ</param>
        /// <returns>���³ɹ�������true</returns>
        public bool Update(int menuId, string name, string menuLink, string imageLink, int sort, int isVisible, int parentMenuId)
        {
            return new MenuDAL().Update(menuId, name, menuLink,imageLink, sort,isVisible, parentMenuId);
        }

        /// <summary>
        /// ���²˵���
        /// </summary>
        /// <param name="detail">�˵�����ϸ��Ϣ</param>
        /// <returns>���³ɹ�������true</returns>
        public bool Update(MenuDetail detail)
        {
            return new MenuDAL().Update(detail);
        }

        /// <summary>
        /// ɾ��Ҷ�ڵ�˵����Ҷ�ڵ��޷�ɾ��
        /// </summary>
        /// <param name="menuId">�˵����ʶ</param>
        /// <returns>ɾ�� ����true ,����false</returns>
        public bool Delete(int menuId)
        {
            return new MenuDAL().Delete(menuId);
        }
        /// <summary>
        /// ɾ��Ҷ�ڵ�˵������Ҷ�ڵ��޷�ɾ��
        /// </summary>
        /// <param name="menuIds">�˵����ʶ��</param>
        /// <returns>ȫ��ɾ�� ����true ,����false</returns>
        public bool Delete(int[] menuIds)
        {
            return new MenuDAL().Delete(menuIds);
        }
    }
}
