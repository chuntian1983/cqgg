using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonUtility.DBUtility;
using CommonUtility;

namespace Modules.Picture
{
    public class PictureDetail
    {
        public int PictureId;
        public string Description;
        public string PicName;
        public string ExtensionName;
        public string SmallPicPath;
        public string OriginalPicPath;
        public int CategoryId;
        public int UploadUserId;
        public string UploadDate;
        public string bz;
        public string deptid;
    }
    internal class PictureDAL
    {
        public int AddUploadPic(string description, string picName,string extensionName, string smallPicPath,
                                string originalPicPath , int categoryId,string bz, int uploadUserId,string deptid)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            IDataParameter[] paras = new IDataParameter[10];
            paras[0] = helper.GetParameter("@Description", description);
            paras[1] = helper.GetParameter("@PicName", picName);
            paras[2] = helper.GetParameter("@ExtensionName", extensionName);
            paras[3] = helper.GetParameter("@SmallPicPath", smallPicPath);
            paras[4] = helper.GetParameter("@OriginalPicPath", originalPicPath);
            paras[5] = helper.GetParameter("@CategoryId", categoryId);
            paras[6] = helper.GetParameter("@UploadUserId", uploadUserId);
            paras[7] = helper.GetParameter("@PictureId", DbType.Int32, 4, ParameterDirection.Output);
            paras[8] = helper.GetParameter("@bz", bz);
            paras[9] = helper.GetParameter("@deptid",deptid);
            string strsql = @"Insert T_Picture_Picture (Description,PicName,ExtensionName,SmallPicPath,OriginalPicPath,CategoryId,UploadUserId,bz)
Values(@Description,@PicName,@ExtensionName,@SmallPicPath,@OriginalPicPath,@CategoryId,@UploadUserId,@bz)";
            int i= helper.ExecuteNonQuery(helper.connectionString,CommandType.Text,strsql, paras);

            return i;
        }
        public int AddUploadPic(string description, string picName, string extensionName, string smallPicPath,
                               string originalPicPath, int categoryId, int uploadUserId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            IDataParameter[] paras = new IDataParameter[8];
            paras[0] = helper.GetParameter("@Description", description);
            paras[1] = helper.GetParameter("@PicName", picName);
            paras[2] = helper.GetParameter("@ExtensionName", extensionName);
            paras[3] = helper.GetParameter("@SmallPicPath", smallPicPath);
            paras[4] = helper.GetParameter("@OriginalPicPath", originalPicPath);
            paras[5] = helper.GetParameter("@CategoryId", categoryId);
            paras[6] = helper.GetParameter("@UploadUserId", uploadUserId);
            paras[7] = helper.GetParameter("@PictureId", DbType.Int32, 4, ParameterDirection.Output);
            string strsql = "Insert T_Picture_Category (Title,AddedUserId) values (@Title,@AddedUserId)";
            helper.ExecuteNonQuery(helper.connectionString, CommandType.Text, strsql, paras);
            //helper.ExecuteNonQuery("sp_Picture_AddPicture", paras);
            return Convert.ToInt32(paras[7].Value);
        }
        public int AddUploadPic(PictureDetail detail)
        {
            return AddUploadPic(detail.Description, detail.PicName, detail.ExtensionName, detail.SmallPicPath,
                                detail.OriginalPicPath,detail.CategoryId,detail.bz,detail.UploadUserId,detail.deptid);
        }
        public int AddUploadPicbz(PictureDetail detail)
        {
            return AddUploadPic(detail.Description, detail.PicName, detail.ExtensionName, detail.SmallPicPath,
                                detail.OriginalPicPath, detail.CategoryId,detail.bz, detail.UploadUserId,detail.deptid);
        }
        public bool UpdateUploadPic(int pictureId, string picName, string description, int categoryId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder sql = new StringBuilder();
            sql.Append("Update T_Picture_Picture Set ");
            sql.AppendFormat("PicName='{0}',Description='{1}',CategoryId={2} ", picName, description, categoryId);
            sql.AppendFormat("where PictureId={0}", pictureId);
            return helper.ExecuteNonQuery(sql.ToString()) > 0;
        }
        public bool UpdateUploadPic(int pictureId, string picName, string description,string bz, int categoryId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder sql = new StringBuilder();
            sql.Append("Update T_Picture_Picture Set ");
            sql.AppendFormat("PicName='{0}',Description='{1}',bz='{3}',CategoryId={2} ", picName, description, categoryId,bz);
            sql.AppendFormat("where PictureId={0}", pictureId);
            return helper.ExecuteNonQuery(sql.ToString()) > 0;
        }
        public bool UpdateUploadPic(PictureDetail detail)
        {
            return UpdateUploadPic(detail.PictureId,detail.PicName,detail.Description,detail.bz,detail.CategoryId);
        }

        public PictureDetail GetPicDetail(int pictureId)
        {
            return GetPicDetailFromDataRow(GetPicDataRow(pictureId));
        }

        public DataRow GetPicDataRow(int pictureId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string query = String.Format("Select * from T_Picture_Picture where PictureId={0}", pictureId);
            DataSet ds = helper.ExecuteDataset(query);
            if (ds.Tables[0].Rows.Count == 1) return ds.Tables[0].Rows[0];
            return null;
        }
        private PictureDetail GetPicDetailFromDataRow(DataRow info)
        {
            if (info != null)
            {
                PictureDetail detail = new PictureDetail();
                detail.PictureId = (int)info["PictureId"];
                detail.Description = info["Description"].ToString();
                detail.PicName = info["PicName"].ToString();
                detail.ExtensionName = info["ExtensionName"].ToString();
                detail.SmallPicPath = info["SmallPicPath"].ToString();
                detail.OriginalPicPath = info["OriginalPicPath"].ToString();
                detail.CategoryId = (int)info["CategoryId"];
                detail.UploadDate = info["UploadDate"].ToString();
                detail.UploadUserId = (int)info["UploadUserId"];
                detail.bz = info["bz"]==null?"":info["bz"].ToString();
                detail.deptid = info["deptid"] == null ? "" : info["deptid"].ToString();
                return detail;
            }
            return null;
        }
        public DataSet GetList(string userid,string where)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string query = String.Format("Select * from T_Picture_Picture where uploaduserid='{0}'", userid);
            if (!string.IsNullOrEmpty(where))
            {
                query += " and "+where;
            }
            DataSet ds = helper.ExecuteDataset(query);
            return ds;
        }
        public DataSet GetList(int deptid, string where)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string query = String.Format("Select * from T_Picture_Picture a,T_User b where a.uploaduserid=b.UserId and b.email='{0}'", deptid);
            if (!string.IsNullOrEmpty(where))
            {
                query += " and " + where;
            }
            DataSet ds = helper.ExecuteDataset(query);
            return ds;
        }
        public DataSet GetAllPicDetailInfo()
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder query = new StringBuilder();
            query.Append("select a.*,b.Title,c.Nickname ");
            query.Append("from T_Picture_Picture a inner join T_Picture_Category b on a.CategoryId=b.CategoryId ");
            query.Append("inner join T_User  c on a.UploadUserId=c.UserId ");
            return helper.ExecuteDataset(query.ToString());
        }
        public DataSet GetAllPicDetailInfo(string deptid)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder query = new StringBuilder();
            query.Append("select a.*,b.Title,c.Nickname ");
            query.Append("from T_Picture_Picture a inner join T_Picture_Category b on a.CategoryId=b.CategoryId ");
            query.Append("inner join T_User  c on a.UploadUserId=c.UserId where c.email='"+deptid+"'");
            return helper.ExecuteDataset(query.ToString());
        }
        public DataSet GetAllPicDetailInfo(string deptid,string imglb)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder query = new StringBuilder();
            query.Append("select a.*,b.Title,c.Nickname ");
            query.Append("from T_Picture_Picture a inner join T_Picture_Category b on a.CategoryId=b.CategoryId ");
            query.Append("inner join T_User  c on a.UploadUserId=c.UserId where c.email='" + deptid + "' and b.categoryid='"+imglb+"'");
            return helper.ExecuteDataset(query.ToString());
        }
       public DataSet GetPicList(string fields,string filter,string sort,int currentPageIndex,int pageSize,out int recordCount)
       {
           return PaginationUtility.GetPaginationList(fields,"V_Picture_Picture", filter, sort, currentPageIndex, pageSize, out recordCount);
       }
        public DataRow GetPicView(int pictureId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string sql = String.Format("select * from V_Picture_Picture where PictureId={0}", pictureId);
            DataSet ds=helper.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count == 1) return ds.Tables[0].Rows[0];
            return null;
        }

        public bool DeleteUploadPic(int pictureId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string sql = String.Format("delete from T_Picture_Picture where PictureId={0}", pictureId);
            return helper.ExecuteNonQuery(sql) > 0;
        }
    }
}
