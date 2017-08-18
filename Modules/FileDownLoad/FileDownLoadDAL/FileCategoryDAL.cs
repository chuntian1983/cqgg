using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonUtility.DBUtility;

namespace Modules.File
{
    public class FileCategoryDetail
    {
        public int FileCategoryId;
        public string Title;
        public int AddedUserId;
        public DateTime AddedDate;
    }
   internal class FileCategoryDAL
    {
        public DataSet GetAllFileCategories()
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string query = "select a.*,b.Nickname from T_FileCategory a inner join T_User b on a.AddedUserId=b.UserId order by FileCategoryId Asc";
            return helper.ExecuteDataset(query);
        }
        public FileCategoryDetail GetFileCategoryDetail(int fileCategoryId)
        {
            return GetFileCategoryDetailFromDataRow(GetFileCategoryDataRow(fileCategoryId));
        }

        public DataRow GetFileCategoryDataRow(int fileCategoryId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string query = String.Format("select * from T_FileCategory where FileCategoryId={0}", fileCategoryId);
            DataSet ds = helper.ExecuteDataset(query);
            if (ds.Tables[0].Rows.Count == 1) return ds.Tables[0].Rows[0];
            return null;
        }
       private FileCategoryDetail GetFileCategoryDetailFromDataRow(DataRow info)
        {
            if (info != null)
            {
                FileCategoryDetail detail = new FileCategoryDetail();
                detail.Title = info["Title"].ToString();
                detail.FileCategoryId = (int)info["FileCategoryId"];
                detail.AddedUserId = (int)info["AddedUserId"];
                detail.AddedDate = Convert.ToDateTime(info["AddedDate"]);
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
            paras[2] = helper.GetParameter("@FileCategoryId", DbType.Int32, 4, ParameterDirection.Output);
            helper.ExecuteNonQuery("sp_File_AddCategory", paras);
            return Convert.ToInt32(paras[2].Value);
        }
        public int AddCategory(FileCategoryDetail detail)
        {
            return AddCategory(detail.Title, detail.AddedUserId);
        }
        public bool DeleteCategory(int fileCategoryId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string sql = String.Format("delete T_FileCategory where FileCategoryId={0}", fileCategoryId);
            return helper.ExecuteNonQuery(sql) > 0;
        }

        public bool UpdateCategory(int fileCategoryId, string title)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string sql = String.Format("update T_FileCategory set Title='{0}' where FileCategoryId={1}", title, fileCategoryId);
            return helper.ExecuteNonQuery(sql) > 0;
        }

        public bool UpdateCategory(FileCategoryDetail detail)
        {
            return UpdateCategory(detail.FileCategoryId, detail.Title);
        }


        //20071213加 根据文件的类别号取得所属文件列表
        public DataSet GetFileByCategoryId(int CategoryId)
        {
            string sql = "select * from T_File where FileCategoryId=" + CategoryId + "";
            return SQLHelper.Query(sql);
        }

    }
}
