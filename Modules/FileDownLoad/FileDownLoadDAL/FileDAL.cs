using System;
using System.Collections.Generic;
using System.Text;
using CommonUtility.DBUtility;
using System.Data;

namespace Modules.File
{
    public class FileDetail
    {
        public int FileId;
        public string Description;
        public string FileName;
        public string FilePath;
        public int DownloadCount;
        public int CategoryId;
        public int UploadUserId;
        public DateTime UploadDate;
    }
    internal class FileDAL
    {
        public int AddUploadFile(string description, string fileName, string filePath,
                                 int downloadCount, int categoryId, int uploadUserId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            IDataParameter[] paras = new IDataParameter[7];
            paras[0] = helper.GetParameter("@Description", description);
            paras[1] = helper.GetParameter("@FileName", fileName);
            paras[2] = helper.GetParameter("@FilePath", filePath);
            paras[3] = helper.GetParameter("@DownloadCount", downloadCount);
            paras[4] = helper.GetParameter("@FileCategoryId", categoryId);
            paras[5] = helper.GetParameter("@UploadUserId", uploadUserId);
            paras[6] = helper.GetParameter("@FileId",DbType.Int32,4,ParameterDirection.Output);
            helper.ExecuteNonQuery("sp_File_Add", paras);
            return Convert.ToInt32(paras[6].Value);
        }

        public int AddUploadFile(FileDetail detail)
        {
            return AddUploadFile(detail.Description, detail.FileName, detail.FilePath, detail.DownloadCount,
                                 detail.CategoryId, detail.UploadUserId);
        }
        public bool UpdateUploadFileInfo(int fileId, string fileName, string description, int categoryId,string filepath)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder sql = new StringBuilder();
            sql.Append("Update T_File Set ");
            sql.AppendFormat("FileName='{0}',Description='{1}',FileCategoryId={2},FilePath='{3}' ", fileName, description, categoryId,filepath);
            sql.AppendFormat("where FileId={0}", fileId);
            return helper.ExecuteNonQuery(sql.ToString()) > 0;
        }
        public bool UpdateUploadFileInfo(FileDetail detail)
        {
            return UpdateUploadFileInfo(detail.FileId, detail.FileName, detail.Description, detail.CategoryId,detail.FilePath);
        }

        public FileDetail GetFileDetail(int fileId)
        {
            return GetFileDetailFromDataRow(GetFileDataRow(fileId));
        }

        public DataRow GetFileDataRow(int fileId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string query = String.Format("Select * from T_File where FileId={0}", fileId);
            DataSet ds = helper.ExecuteDataset(query);
            if (ds.Tables[0].Rows.Count == 1) return ds.Tables[0].Rows[0];
            return null;
        }
        private FileDetail GetFileDetailFromDataRow(DataRow info)
        {
            if(info!=null)
            {
                FileDetail detail = new FileDetail();
                detail.FileId = (int)info["FileId"];
                detail.Description = info["Description"].ToString();
                detail.FileName = info["FileName"].ToString();
                detail.CategoryId = (int)info["FileCategoryId"];
                detail.DownloadCount = (int)info["DownloadCount"];
                detail.FilePath = info["FilePath"].ToString();
                detail.UploadDate = Convert.ToDateTime(info["UploadDate"]);
                detail.UploadUserId = (int)info["UploadUserId"];
                return detail;
            }
            return null;
        }

        public DataSet GetAllFilesDetailInfo()
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder query = new StringBuilder();
            query.Append("select a.*,b.Title as CategoryName,c.Nickname ");
            query.Append("from T_File a inner join T_FileCategory b on a.FileCategoryId=b.FilecategoryId ");
            query.Append("inner join T_User  c on a.UploadUserId=c.UserId order by a.FileId desc");
            return helper.ExecuteDataset(query.ToString());
        }

        public bool DeleteUploadFile(int fileId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string sql = String.Format("delete from T_File where FileId={0}", fileId);
            return helper.ExecuteNonQuery(sql) > 0;
        }

        //20071213加 根据文件的类别号取得所属文件列表
        public DataSet GetFileByCategoryId(int CategoryId)
        {
            string sql = "select a.*,b.Title as CategoryName,c.Nickname "
            + "from T_File a inner join T_FileCategory b on a.FileCategoryId=b.FilecategoryId "
            + "inner join T_User  c on a.UploadUserId=c.UserId where a.FileCategoryId=" + CategoryId + " order by a.FileId desc";
            return SQLHelper.Query(sql);
        }


        //20071213加 根据文件的类别号取得所属文件列表
        public DataSet GetFileByCategoryName(string CategoryName)
        {
            string sql = "select a.*,b.Title as CategoryName,c.Nickname "
            + "from T_File a inner join T_FileCategory b on a.FileCategoryId=b.FilecategoryId "
            + "inner join T_User  c on a.UploadUserId=c.UserId where b.Title='" + CategoryName + "' order by a.FileId desc";
            return SQLHelper.Query(sql);
        }

    }
}
