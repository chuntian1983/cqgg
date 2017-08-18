using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonUtility.DBUtility;

namespace Modules.Product
{
    public class ProductCategoryDetail
    {
        public int CategoryId;
        public string Description;
        public string ImageLink;
        public int ParentCategoryId;
        public int AddedUserId;
        public DateTime AddedDate;
    }
    class ProductCategoryDAL
    {
        public DataSet GetAllCategoryItems()
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string query = "select * from T_Product_Category";
            return helper.ExecuteDataset(query);
        }
        public DataSet GetChildCategoryItems(int parentCategoryId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string query = String.Format("select * from T_Product_Category where ParentCategoryId={0}", parentCategoryId);
            return helper.ExecuteDataset(query);
        }

        public int AddCategory(string description, string imageLink, int parentCategoryId, int addedUserId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            IDataParameter[] paras = new IDataParameter[5];
            paras[0] = helper.GetParameter("@Description", description);
            paras[1] = helper.GetParameter("@ImageLink", imageLink);
            paras[2] = helper.GetParameter("@ParentCategoryId", parentCategoryId);
            paras[3] = helper.GetParameter("@AddedUserId", addedUserId);
            paras[4] = helper.GetParameter("@CategoryId", DbType.Int32, 4, ParameterDirection.Output);
            helper.ExecuteNonQuery("sp_Product_AddCategory", paras);
            return Convert.ToInt32(paras[4].Value);
        }
        public int AddCategory(ProductCategoryDetail detail)
        {
            return AddCategory(detail.Description, detail.ImageLink, detail.ParentCategoryId, detail.AddedUserId);
        }

        public bool UpdateCategory(int categoryId, string description, string imageLink, int parentCategoryId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("Update T_Product_Category Set Description='{0}',ImageLink='{1}',ParentCategoryId={2}", description, imageLink, parentCategoryId);
            sql.AppendFormat(" where CategoryId={0}", categoryId);
            return helper.ExecuteNonQuery(sql.ToString()) > 0;
        }

        public bool UpdateCategory(ProductCategoryDetail detail)
        {
            return UpdateCategory(detail.CategoryId, detail.Description, detail.ImageLink, detail.ParentCategoryId);
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
            helper.ExecuteNonQuery("sp_Product_DelCategory", paras);
            return Convert.ToBoolean(paras[1].Value);
        }

        public ProductCategoryDetail GetCategoryDetail(int categoryId)
        {
            return GetCategoryDetailFromDataRow(GetCategoryDataRow(categoryId));
        }
        public DataRow GetCategoryDataRow(int categoryId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string query = String.Format("Select * from T_Product_Category where CategoryId={0}", categoryId);
            DataSet ds = helper.ExecuteDataset(query);
            if (ds.Tables[0].Rows.Count == 1) return ds.Tables[0].Rows[0];
            return null;
        }

        private ProductCategoryDetail GetCategoryDetailFromDataRow(DataRow info)
        {
            if (info != null)
            {
                ProductCategoryDetail detail = new ProductCategoryDetail();
                detail.CategoryId = (int)info["CategoryId"];
                detail.Description = info["Description"].ToString();
                detail.ImageLink = info["ImageLink"].ToString();
                detail.ParentCategoryId = (int)info["ParentCategoryId"];
                detail.AddedUserId = (int)info["AddedUserId"];
                detail.AddedDate = Convert.ToDateTime(info["AddedDate"]);
                return detail;
            }
            return null;
        }
    }
}
