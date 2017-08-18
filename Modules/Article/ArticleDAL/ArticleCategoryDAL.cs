using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonUtility.DBUtility;

namespace Modules.Article
{
    //public class ArticleCategoryDetail
    //{
    //    public int ArticleCategoryId;
    //    public string Title;
    //    public int AddedUserId;
    //    public DateTime AddedDate;
    //}
    ///// <summary>
    ///// 
    ///// </summary>
    //internal class ArticleCategoryDAL
    //{
    //    public DataSet GetAllArticleCategories()
    //    {
    //        AdoHelper helper = AdoHelper.CreateHelper();
    //        string query = "select a.*,b.Nickname from T_ArticleCategory a inner join T_User b on a.AddedUserId=b.UserId";
    //        return helper.ExecuteDataset(query);
    //    }
    //    public ArticleCategoryDetail GetCategoryDetail(int articleCategoryId)
    //    {
    //        return GetCategoryDetailFromDataRow(GetCategoryDataRow(articleCategoryId));
    //    }
    //    public DataRow GetCategoryDataRow(int articleCategoryId)
    //    {
    //        AdoHelper helper = AdoHelper.CreateHelper();
    //        string query = String.Format("select * from T_ArticleCategory where ArticleCategoryId={0}", articleCategoryId);
    //        DataSet ds = helper.ExecuteDataset(query);
    //        if (ds.Tables[0].Rows.Count == 1) return ds.Tables[0].Rows[0];
    //        return null;
    //    }
    //    private ArticleCategoryDetail GetCategoryDetailFromDataRow(DataRow info)
    //    {
    //        if (info != null)
    //        {
    //            ArticleCategoryDetail detail = new ArticleCategoryDetail();
    //            detail.Title = info["Title"].ToString();
    //            detail.ArticleCategoryId = (int)info["ArticleCategoryId"];
    //            detail.AddedUserId = (int)info["AddedUserId"];
    //            detail.AddedDate = Convert.ToDateTime(info["AddedDate"]);
    //            return detail;
    //        }
    //        else
    //            return null;
    //    }

    //    public int AddCategory(string title, int addedUserId)
    //    {
    //        AdoHelper helper = AdoHelper.CreateHelper();
    //        IDataParameter[] paras = new IDataParameter[3];
    //        paras[0] = helper.GetParameter("@Title", title);
    //        paras[1] = helper.GetParameter("@AddedUserId", addedUserId);
    //        paras[2] = helper.GetParameter("@ArticleCategoryId", DbType.Int32, 4, ParameterDirection.Output);
    //        helper.ExecuteNonQuery("sp_Article_AddCategory", paras);
    //        return Convert.ToInt32(paras[2].Value);
    //    }
    //    public int AddCategory(ArticleCategoryDetail detail)
    //    {
    //        return AddCategory(detail.Title, detail.AddedUserId);
    //    }
    //    public bool DeleteCategory(int articleCategoryId)
    //    {
    //        AdoHelper helper = AdoHelper.CreateHelper();
    //        string sql = String.Format("delete T_ArticleCategory where ArticleCategoryId={0}", articleCategoryId);
    //        return helper.ExecuteNonQuery(sql) > 0;
    //    }

    //    public bool UpdateCategory(int articleCategoryId, string title)
    //    {
    //        AdoHelper helper = AdoHelper.CreateHelper();
    //        string sql = String.Format("update T_ArticleCategory set Title='{0}' where ArticleCategoryId={1}", title,articleCategoryId);
    //        return helper.ExecuteNonQuery(sql) > 0;
    //    }

    //    public bool UpdateCategory(ArticleCategoryDetail detail)
    //    {
    //        return UpdateCategory(detail.ArticleCategoryId, detail.Title);
    //    }


    //}

    public class ArticleCategoryDetail
    {
        public int CategoryId;
        public string Title;
        public int Sort;
        public int Type;
        public int ParentCategoryId;
        public int AddedUserId;
        public string AddedDate;
    }
    public class ArticleCategoryDAL
    {
        public DataSet GetAllCategoryItems()
        {
            //取出所有的文章类别
            AdoHelper helper = AdoHelper.CreateHelper();
            string query = "select * from T_ArticleCategory where Type=0 ";
            return helper.ExecuteDataset(query);
        }
        public DataSet GetChildCategoryItems(int parentCategoryId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string query = String.Format("select * from T_ArticleCategory where ParentCategoryId={0}", parentCategoryId);
            return helper.ExecuteDataset(query);
        }

        public int AddCategory(string title, int sort,int type, int parentCategoryId, int addedUserId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            IDataParameter[] paras = new IDataParameter[6];
            paras[0] = helper.GetParameter("@Title", title);
            paras[1] = helper.GetParameter("@Sort", sort);
            paras[2] = helper.GetParameter("@Type", type);
            paras[3] = helper.GetParameter("@ParentCategoryId", parentCategoryId);
            paras[4] = helper.GetParameter("@AddedUserId", addedUserId);
            paras[5] = helper.GetParameter("@CategoryId", DbType.Int32, 4, ParameterDirection.Output);
            helper.ExecuteNonQuery("sp_Article_AddCategory", paras);
            return Convert.ToInt32(paras[5].Value);
        }
        public int AddCategory(ArticleCategoryDetail detail)
        {
            return AddCategory(detail.Title,detail.Sort,detail.Type, detail.ParentCategoryId, detail.AddedUserId);
        }

        public bool UpdateCategory(int categoryId, string title, int sort,int type, int parentCategoryId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("Update T_ArticleCategory Set Title='{0}',Sort={1},Type={2},ParentCategoryId={3}", title, sort,type, parentCategoryId);
            sql.AppendFormat(" where CategoryId={0}", categoryId);
            return helper.ExecuteNonQuery(sql.ToString()) > 0;
        }

        public bool UpdateCategory(ArticleCategoryDetail detail)
        {
            return UpdateCategory(detail.CategoryId, detail.Title,detail.Sort,detail.Type, detail.ParentCategoryId);
        }

        public bool DeleteCategory(int[] categoryIds)
        {
            int count = 0;
            foreach (int categoryId in categoryIds)
            {
                if (DeleteCategory(categoryId)) count++;
            }
            return count == categoryIds.Length;
        }
        public bool DeleteCategory(int categoryId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            IDataParameter[] paras = new IDataParameter[2];
            paras[0] = helper.GetParameter("@CategoryId", categoryId);
            paras[1] = helper.GetParameter("@Return", DbType.Int32, 4, ParameterDirection.Output);
            helper.ExecuteNonQuery("sp_Article_DelCategory", paras);
            return Convert.ToBoolean(paras[1].Value);
        }

        public ArticleCategoryDetail GetCategoryDetail(int categoryId)
        {
            return GetCategoryDetailFromDataRow(GetCategoryDataRow(categoryId));
        }
        public DataRow GetCategoryDataRow(int categoryId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string query = String.Format("Select * from T_ArticleCategory where CategoryId={0}", categoryId);
            DataSet ds = helper.ExecuteDataset(query);
            if (ds.Tables[0].Rows.Count == 1) return ds.Tables[0].Rows[0];
            return null;
        }

        private ArticleCategoryDetail GetCategoryDetailFromDataRow(DataRow info)
        {
            if (info != null)
            {
                ArticleCategoryDetail detail = new ArticleCategoryDetail();
                detail.CategoryId = (int)info["CategoryId"];
                detail.Title = info["Title"].ToString();
                detail.Sort = (int)info["Sort"];
                detail.Type = (int)info["Type"];
                detail.ParentCategoryId = (int)info["ParentCategoryId"];
                detail.AddedUserId = (int)info["AddedUserId"];
                detail.AddedDate = info["AddedDate"].ToString();
                return detail;
            }
            return null;
        }
    }
}
