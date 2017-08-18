using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;

namespace Modules.Product
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
    
    public class ProductCategoryBLL
    {
        public ProductCategoryDetail GetCategoryDetail(int categoryId)
        {
            return new ProductCategoryDAL().GetCategoryDetail(categoryId);
        }
        #region 获取添加或修改产品类别时，显示的类别下拉框的数据
        public ArrayList GetSortedProductCategoryItems(int maxLevel)
        {
            ArrayList sortedCategoryItems = new ArrayList();
            DataSet allCategoryItems = new ProductCategoryDAL().GetAllCategoryItems();
            sortedCategoryItems.Add(new CategoryEntity("--请选择类别--", "0"));
            this.RecursionFill(allCategoryItems, sortedCategoryItems, "0", 1,maxLevel);
            return sortedCategoryItems;
        }

        private void RecursionFill(DataSet dataSource, ArrayList targetToFill, string parentCategoryId, int currentLevel,int maxLevel)
        {
            if (currentLevel == maxLevel && currentLevel!=1) return;
            DataRow[] childCategoryItems = dataSource.Tables[0].Select(String.Format("ParentCategoryId={0}", parentCategoryId));
            foreach (DataRow categoryItems in childCategoryItems)
            {
                string categoryName = GetAppropriateCategoryName(categoryItems["Description"].ToString(), currentLevel);
                string categoryId = categoryItems["CategoryId"].ToString();
                targetToFill.Add(new CategoryEntity(categoryName, categoryId));
                RecursionFill(dataSource, targetToFill, categoryId, currentLevel + 1,maxLevel);
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
            TreeNode root = new TreeNode("产品类别", "0");
            root.SelectAction = TreeNodeSelectAction.Expand;
            ProductCategoryDAL category = new ProductCategoryDAL();
            DataSet categoryItems = category.GetAllCategoryItems();
            AddChildNode(categoryItems, root, root.Value);
            return root;
        }

        private void AddChildNode(DataSet dataSource, TreeNode parentNode, string parentCategoryId)
        {
            DataRow[] childCategoryItems = dataSource.Tables[0].Select(String.Format("ParentCategoryId={0}", parentCategoryId), "CategoryId Desc");
            if (childCategoryItems.Length > 0)
            {
                foreach (DataRow dr in childCategoryItems)
                {
                    string description = dr["Description"].ToString();
                    string categoryId = dr["CategoryId"].ToString();
                    TreeNode childNode = new TreeNode(description, categoryId);
                    childNode.ShowCheckBox = true;
                    childNode.SelectAction = TreeNodeSelectAction.Expand;
                    parentNode.ChildNodes.Add(childNode);
                    AddChildNode(dataSource, childNode, categoryId);
                }
            }
        }
        #endregion

        public ArrayList GetSelectedTreeNodes(TreeNode root)
        {
            return Modules.Utility.TreeNodeUtil.GetSelectedTreeNodes(root);
        }
        public int AddCategory(ProductCategoryDetail detail)
        {
            return new ProductCategoryDAL().AddCategory(detail);
        }

        public bool UpdateCategory(ProductCategoryDetail detail)
        {
            return new ProductCategoryDAL().UpdateCategory(detail);
        }

        public bool DeleteCategory(int[] categoryIds)
        {
            return new ProductCategoryDAL().DeleteCategory(categoryIds);
        }
    }
}
