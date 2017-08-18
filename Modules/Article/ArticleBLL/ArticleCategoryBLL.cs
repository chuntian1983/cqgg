using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections;

namespace Modules.Article
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

    public class ArticleCategoryBLL
    {
        public ArticleCategoryDetail GetCategoryDetail(int categoryId)
        {
            return new ArticleCategoryDAL().GetCategoryDetail(categoryId);
        }
        #region ��ȡ��ӻ��޸��������ʱ����ʾ����������������
        public ArrayList GetSortedArticleCategoryItems(int maxLevel)//------------
        {
            ArrayList sortedCategoryItems = new ArrayList();//����һ���Զ�������
            DataSet allCategoryItems = new ArticleCategoryDAL().GetAllCategoryItems();//�õ������������
            sortedCategoryItems.Add(new CategoryEntity("--��ѡ�����--", "0"));//����һ��
            this.RecursionFill(allCategoryItems, sortedCategoryItems, "0", 1, maxLevel);
            return sortedCategoryItems;
        }

        private void RecursionFill(DataSet dataSource, ArrayList targetToFill, string parentCategoryId, int currentLevel, int maxLevel)
        {
            if (currentLevel == maxLevel && currentLevel != 1) return;
            DataRow[] childCategoryItems = dataSource.Tables[0].Select(String.Format("ParentCategoryId={0}", parentCategoryId),"Sort");//���ո������Ž�������
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
                sb.Append("����");
            }
            sb.Append(categoryName);
            return sb.ToString();
        }
        #endregion

        #region  ��ȡ�����
        public TreeNode GetCategoryTree()
        {
            TreeNode root = new TreeNode("�������", "0");
            root.SelectAction = TreeNodeSelectAction.Expand;
            ArticleCategoryDAL category = new ArticleCategoryDAL();
            DataSet categoryItems = category.GetAllCategoryItems();
            AddChildNode(categoryItems, root, root.Value);
            return root;
        }

        private void AddChildNode(DataSet dataSource, TreeNode parentNode, string parentCategoryId)
        {
            DataRow[] childCategoryItems = dataSource.Tables[0].Select(String.Format("ParentCategoryId={0}", parentCategoryId), "Sort");
            if (childCategoryItems.Length > 0)
            {
                foreach (DataRow dr in childCategoryItems)
                {
                    string title = dr["Title"].ToString() + "����ʾ" + dr["CategoryId"].ToString()+"��";
                    string categoryId = dr["CategoryId"].ToString();
                    TreeNode childNode = new TreeNode(title, categoryId);
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
        public int AddCategory(ArticleCategoryDetail detail)
        {
            return new ArticleCategoryDAL().AddCategory(detail);
        }

        public bool UpdateCategory(ArticleCategoryDetail detail)
        {
            return new ArticleCategoryDAL().UpdateCategory(detail);
        }

        public bool DeleteCategory(int[] categoryIds)
        {
            return new ArticleCategoryDAL().DeleteCategory(categoryIds);
        }
    }
}
