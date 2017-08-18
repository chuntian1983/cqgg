using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections;

namespace Modules.Department
{
    public class CategoryEntity
    {
         public CategoryEntity(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }
        public string Name;
        public string Id;
    }

    public class DepartmentCategoryBLL
    {
        /// <summary>
        /// 获得下级行政级别项目
        /// </summary>
        /// <param name="parentCategoryId"></param>
        /// <returns></returns>
        public DataSet GetChildCategoryItems(int parentCategoryId)
        {
            return new DepartmentCategoryDAL().GetChildCategoryItems(parentCategoryId);
           
        }
        public DepartmentCategoryDetail GetCategoryDetail(int categoryId)
        {
            return new DepartmentCategoryDAL().GetCategoryDetail(categoryId);
        }
        #region 获取添加或修改文章类别时，显示的类别下拉框的数据
        public ArrayList GetSortedDepartmentCategoryItems(int maxLevel)
        {
            ArrayList sortedCategoryItems = new ArrayList();
            DataSet allCategoryItems = new DepartmentCategoryDAL().GetAllCategoryItems();
            sortedCategoryItems.Add(new CategoryEntity("行政单位", "0"));
            this.RecursionFill(allCategoryItems, sortedCategoryItems, "0", 1, maxLevel);
            return sortedCategoryItems;
        }
        public ArrayList GetSortedDepartmentCategoryItems(string deptid)
        {
            int maxLevel = 4;
            DepartmentCategoryDetail dep = GetCategoryDetail(int.Parse(deptid));

            ArrayList sortedCategoryItems = new ArrayList();
            DataSet allCategoryItems = new DepartmentCategoryDAL().GetAllCategoryItems();
            sortedCategoryItems.Add(new CategoryEntity(dep.Title, deptid));
            this.RecursionFill(allCategoryItems, sortedCategoryItems, deptid, 1, maxLevel);
            return sortedCategoryItems;
        }
         private void RecursionFill(DataSet dataSource, ArrayList targetToFill, string parentCategoryId, int currentLevel, int maxLevel)
        {
            if (currentLevel == maxLevel && currentLevel != 1) return;
            DataRow[] childCategoryItems = dataSource.Tables[0].Select(String.Format("ParentCategoryId={0}", parentCategoryId),"Sort");
            foreach (DataRow categoryItems in childCategoryItems)
            {
                string categoryName = GetAppropriateCategoryName(categoryItems["Title"].ToString(), currentLevel);
                string categoryId = categoryItems["CategoryId"].ToString();
                targetToFill.Add(new CategoryEntity(categoryName, categoryId));
                RecursionFill(dataSource, targetToFill, categoryId, currentLevel + 1, maxLevel);
            }
        }
        private string GetAppropriateCategoryName(string categoryName, int level)
        {
            StringBuilder sb = new StringBuilder();
            for (; level > 0; level--)
            {
                sb.Append("－－");
            }
            sb.Append(categoryName);
            return sb.ToString();
        }
        #endregion

         #region  获取类别树
        public TreeNode GetCategoryTree()
        {
            TreeNode root = new TreeNode("行政单位", "0");
            root.SelectAction = TreeNodeSelectAction.Expand;
            DepartmentCategoryDAL category = new DepartmentCategoryDAL();
            DataSet categoryItems = category.GetAllCategoryItems();
            AddChildNode(categoryItems, root, root.Value);
            return root;
        }
        public TreeNode GetCategoryTree(int deptid)
        {
            DepartmentCategoryDAL category = new DepartmentCategoryDAL();
            Modules.Department.DepartmentCategoryDetail dc = new DepartmentCategoryDetail();
            dc = category.GetCategoryDetail(deptid);
            TreeNode root = new TreeNode(dc.Title,dc.CategoryId.ToString());
            root.SelectAction = TreeNodeSelectAction.Expand;
            
            DataSet categoryItems = category.GetAllCategoryItems();
            AddChildNode(categoryItems, root, root.Value);
            return root;
        }
        public TreeNode GetCategoryTree(string id)
        {
            Modules.Department.DepartmentCategoryDetail dc = new DepartmentCategoryDetail();
            DepartmentCategoryDAL category = new DepartmentCategoryDAL();
            TreeNode root = new TreeNode();
            if (id != "0")
            {
                dc = category.GetCategoryDetail(int.Parse(id));
                root.Text = dc.Title;
                root.Value = dc.CategoryId.ToString();
                root.NavigateUrl = "content.aspx?deptid="+dc.CategoryId+"";
                root.Target = "mainFrame";
            }
            else
            {
                root.Text = "行政单位";
                root.Value = "0";
                root.NavigateUrl = "content.aspx?deptid=0";
                root.Target = "mainFrame";
            }
            root.SelectAction = TreeNodeSelectAction.Expand;
            
            DataSet categoryItems = category.GetAllCategoryItems();
            AddChildNodebyid(categoryItems, root, root.Value);
            return root;
        }
        public TreeNode GetCategoryTree(string id,string url)
        {
            Modules.Department.DepartmentCategoryDetail dc = new DepartmentCategoryDetail();
            DepartmentCategoryDAL category = new DepartmentCategoryDAL();
            TreeNode root = new TreeNode();
            if (id != "0")
            {
                dc = category.GetCategoryDetail(int.Parse(id));
                root.Text = dc.Title;
                root.Value = dc.CategoryId.ToString();
                root.NavigateUrl = ""+url+"?deptid=" + dc.CategoryId + "";
                root.Target = "mainFrame";
            }
            else
            {
                root.Text = "行政单位";
                root.Value = "0";
                root.NavigateUrl = ""+url+"?deptid=0";
                root.Target = "mainFrame";
            }
            root.SelectAction = TreeNodeSelectAction.Expand;

            DataSet categoryItems = category.GetAllCategoryItems();
            AddChildNodebyid(categoryItems, root, root.Value,url);
            return root;
        }
        private void AddChildNode(DataSet dataSource, TreeNode parentNode, string parentCategoryId)
        {
            DataRow[] childCategoryItems = dataSource.Tables[0].Select(String.Format("ParentCategoryId={0}", parentCategoryId), "Sort");
            if (childCategoryItems.Length > 0)
            {
                foreach (DataRow dr in childCategoryItems)
                {
                    string title ="["+dr["CategoryId"].ToString()+"]"+ dr["Title"].ToString();
                    string categoryId = dr["CategoryId"].ToString();
                    TreeNode childNode = new TreeNode(title, categoryId);
                    childNode.ShowCheckBox = true;
                    childNode.SelectAction = TreeNodeSelectAction.Expand;
                    parentNode.ChildNodes.Add(childNode);
                    AddChildNode(dataSource, childNode, categoryId);
                }
            }
        }
        private void AddChildNodebyid(DataSet dataSource, TreeNode parentNode, string parentCategoryId)
        {
            DataRow[] childCategoryItems = dataSource.Tables[0].Select(String.Format("ParentCategoryId={0}", parentCategoryId), "Sort");
            if (childCategoryItems.Length > 0)
            {
                foreach (DataRow dr in childCategoryItems)
                {
                    string title = dr["Title"].ToString();
                    string categoryId = dr["CategoryId"].ToString();
                    TreeNode childNode = new TreeNode(title, categoryId);
                    childNode.NavigateUrl = "content.aspx?deptid=" + categoryId + "";
                    childNode.Target = "mainFrame";
                    //childNode.ShowCheckBox = true;
                    childNode.SelectAction = TreeNodeSelectAction.Expand;
                    parentNode.ChildNodes.Add(childNode);
                    AddChildNodebyid(dataSource, childNode, categoryId);
                }
            }
        }
        private void AddChildNodebyid(DataSet dataSource, TreeNode parentNode, string parentCategoryId,string url)
        {
            DataRow[] childCategoryItems = dataSource.Tables[0].Select(String.Format("ParentCategoryId={0}", parentCategoryId), "Sort");
            if (childCategoryItems.Length > 0)
            {
                foreach (DataRow dr in childCategoryItems)
                {
                    string title = dr["Title"].ToString();
                    string categoryId = dr["CategoryId"].ToString();
                    TreeNode childNode = new TreeNode(title, categoryId);
                    childNode.NavigateUrl = ""+url+"?deptid=" + categoryId + "";
                    childNode.Target = "mainFrame";
                    //childNode.ShowCheckBox = true;
                    childNode.SelectAction = TreeNodeSelectAction.Expand;
                    parentNode.ChildNodes.Add(childNode);
                    AddChildNodebyid(dataSource, childNode, categoryId,url);
                }
            }
        }
        #endregion
        public ArrayList GetSelectedTreeNodes(TreeNode root)
        {
            return Modules.Utility.TreeNodeUtil.GetSelectedTreeNodes(root);
        }
        public bool DEL(int id)
        {
            return new DepartmentCategoryDAL().DEL(id);
        }
        public int AddCategory(DepartmentCategoryDetail detail)
        {
            return new DepartmentCategoryDAL().AddCategory(detail);
        }

        public bool UpdateCategory(DepartmentCategoryDetail detail)
        {
            return new DepartmentCategoryDAL().UpdateCategory(detail);
        }
        public int Add(DepartmentCategoryDetail detail)
        {
            return new DepartmentCategoryDAL().Add(detail);
        }
        public bool Update(DepartmentCategoryDetail detail)
        {
            return new DepartmentCategoryDAL().Update(detail);
        }
        public bool DeleteCategory(int[] categoryIds)
        {
            return new DepartmentCategoryDAL().DeleteCategory(categoryIds);
        }
        public DepartmentCategoryDetail Getmodel(int CategoryId)
        {
            return new DepartmentCategoryDAL().GetModel(CategoryId);
        }
    }
}