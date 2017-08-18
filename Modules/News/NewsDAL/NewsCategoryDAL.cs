using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonUtility.DBUtility;

namespace Modules.News
{
    public class NewsCategoryDetail
    {
        public int CategoryId;
        public string Title;
        public int Sort;
        public int Type;
        public int ParentCategoryId;
        public int AddedUserId;
        public string AddedDate;
    }
    class NewsCategoryDAL
    {
        public DataSet GetAllCategoryItems()
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string query = "select * from T_ArticleCategory where Type=1";
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
            string strsql = "Insert T_ArticleCategory (Title,Sort,Type,ParentCategoryId,AddedUserId) Values(@Title,@Sort,@Type,@ParentCategoryId,@AddedUserId)";
            helper.ExecuteNonQuery(helper.connectionString, CommandType.Text, strsql, paras);
            return Convert.ToInt32(paras[5].Value);
        }
        public int AddCategory(NewsCategoryDetail detail)
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

        public bool UpdateCategory(NewsCategoryDetail detail)
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
            string strsql = "delete from T_ArticleCategory where CategoryId='"+categoryId+"'";
            int i= helper.ExecuteNonQuery(CommandType.Text, strsql);
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            //return Convert.ToBoolean(paras[1].Value);
        }

        public NewsCategoryDetail GetCategoryDetail(int categoryId)
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

        private NewsCategoryDetail GetCategoryDetailFromDataRow(DataRow info)
        {
            if (info != null)
            {
                NewsCategoryDetail detail = new NewsCategoryDetail();
                detail.CategoryId = (int)info["CategoryId"];
                detail.Title = info["Title"].ToString();
                detail.Sort = (int)info["Sort"];
                detail.Type = (int)info["Type"];
                detail.ParentCategoryId = (int)info["ParentCategoryId"];
                detail.AddedUserId = (int)info["AddedUserId"];
                detail.AddedDate =info["AddedDate"].ToString();
                return detail;
            }
            return null;
        }
    }
}
