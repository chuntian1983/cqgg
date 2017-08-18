using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonUtility.DBUtility;

namespace Modules.Picture
{
    public class PictureCategoryDetail
    {
        public int CategoryId;
        public string Title;
        public int AddedUserId;
        public string AddedDate;
    }
    internal class PictureCategoryDAL
    {
        public DataSet GetAllPictureCategories()
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string query = "select a.*,b.Nickname from T_Picture_Category a inner join T_User b on a.AddedUserId=b.UserId";
            return helper.ExecuteDataset(query);
        }
        public PictureCategoryDetail GetPictureCategoryDetail(int categoryId)
        {
            return GetPictureCategoryDetailFromDataRow(GetPictureCategoryDataRow(categoryId));
        }
        public DataRow GetPictureCategoryDataRow(int categoryId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string query = String.Format("select * from T_Picture_Category where CategoryId={0}", categoryId);
            DataSet ds = helper.ExecuteDataset(query);
            if (ds.Tables[0].Rows.Count == 1) return ds.Tables[0].Rows[0];
            return null;
        }
        private PictureCategoryDetail GetPictureCategoryDetailFromDataRow(DataRow info)
        {
            if (info != null)
            {
                PictureCategoryDetail detail = new PictureCategoryDetail();
                detail.Title = info["Title"].ToString();
                detail.CategoryId = (int)info["CategoryId"];
                detail.AddedUserId = (int)info["AddedUserId"];
                detail.AddedDate = info["AddedDate"].ToString();
                return detail;
            }
            else
                return null;
        }

        public int AddCategory(string title, int addedUserId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            IDataParameter[] paras = new IDataParameter[3];
            paras[0] = helper.GetParameter("@Title", title);
            paras[1] = helper.GetParameter("@AddedUserId", addedUserId);
            paras[2] = helper.GetParameter("@CategoryId", DbType.Int32, 4, ParameterDirection.Output);
            string strsql = "Insert T_Picture_Category (Title,AddedUserId) values (@Title,@AddedUserId)";
            helper.ExecuteNonQuery(helper.connectionString,CommandType.Text,strsql, paras);
            return Convert.ToInt32(paras[2].Value);
        }
        public int AddCategory(PictureCategoryDetail detail)
        {
            return AddCategory(detail.Title, detail.AddedUserId);
        }
        public bool DeleteCategory(int categoryId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string sql = String.Format("delete from T_Picture_Category where CategoryId='{0}'", categoryId);
            return helper.ExecuteNonQuery(sql) > 0;
        }

        public bool UpdateCategory(int categoryId, string title)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string sql = String.Format("update T_Picture_Category set Title='{0}' where CategoryId={1}", title, categoryId);
            return helper.ExecuteNonQuery(sql) > 0;
        }

        public bool UpdateCategory(PictureCategoryDetail detail)
        {
            return UpdateCategory(detail.CategoryId, detail.Title);
        }
    }
}
