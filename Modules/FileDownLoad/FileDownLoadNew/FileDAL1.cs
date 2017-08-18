using System;
using System.Collections.Generic;
using System.Text;
using CommonUtility.DBUtility;
using System.Data;
using System.Data.SqlClient;
using Modules.File;

namespace Modules.File
{
    public class FileDAL1
    {
        public FileDAL1()
        { }

        /// <summary>
        /// 得到下载列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetDownLoadList()
        {
            string sql = "select *  from T_File where FileCategoryId=7 order by FileId desc";
            return SQLHelper.Query(sql);
        }

        public DataSet GetFileInfo(int NewsId)
        {
            string sql = "select * from T_File where NewsID="+NewsId+" order by FileId desc";
            return SQLHelper.Query(sql);
        }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int FileId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_File");
            strSql.Append(" where FileId= @FileId");
            SqlParameter[] parameters = {
					new SqlParameter("@FileId", SqlDbType.Int,4)
				};
            parameters[0].Value = FileId;
            return SQLHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(FileModel1 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_File(");
            strSql.Append("Description,FileName,FilePath,DownloadCount,FileCategoryId,UploadUserId,UploadDate,Sort,NewsID)");
            strSql.Append(" values (");
            strSql.Append("@Description,@FileName,@FilePath,@DownloadCount,@FileCategoryId,@UploadUserId,@UploadDate,@Sort,@NewsID)");
            SqlParameter[] parameters = {
					new SqlParameter("@Description", SqlDbType.VarChar,400),
					new SqlParameter("@FileName", SqlDbType.VarChar,200),
					new SqlParameter("@FilePath", SqlDbType.VarChar,150),
					new SqlParameter("@DownloadCount", SqlDbType.Int,4),
					new SqlParameter("@FileCategoryId", SqlDbType.Int,4),
					new SqlParameter("@UploadUserId", SqlDbType.Int,4),
					new SqlParameter("@UploadDate", SqlDbType.DateTime),
					new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@NewsID",SqlDbType.Int,4)
            };
            parameters[0].Value = model.Description;
            parameters[1].Value = model.FileName;
            parameters[2].Value = model.FilePath;
            parameters[3].Value = model.DownloadCount;
            parameters[4].Value = model.FileCategoryId;
            parameters[5].Value = model.UploadUserId;
            parameters[6].Value = model.UploadDate;
            parameters[7].Value = model.Sort;
            parameters[8].Value = model.NewsId;

            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(FileModel1 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_File set ");
            strSql.Append("Description=@Description,");
            strSql.Append("FileName=@FileName,");
            strSql.Append("FilePath=@FilePath,");
            strSql.Append("DownloadCount=@DownloadCount,");
            strSql.Append("FileCategoryId=@FileCategoryId,");
            strSql.Append("UploadUserId=@UploadUserId,");
            strSql.Append("UploadDate=@UploadDate,");
            strSql.Append("Sort=@Sort");
            strSql.Append("NesID=@NewsID");
            strSql.Append(" where FileId=@FileId");
           
            SqlParameter[] parameters = {
					new SqlParameter("@FileId", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.VarChar,400),
					new SqlParameter("@FileName", SqlDbType.VarChar,200),
					new SqlParameter("@FilePath", SqlDbType.VarChar,150),
					new SqlParameter("@DownloadCount", SqlDbType.Int,4),
					new SqlParameter("@FileCategoryId", SqlDbType.Int,4),
					new SqlParameter("@UploadUserId", SqlDbType.Int,4),
					new SqlParameter("@UploadDate", SqlDbType.DateTime),
					new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@NewsID",SqlDbType.Int,4)
            };
            parameters[0].Value = model.FileId;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.FileName;
            parameters[3].Value = model.FilePath;
            parameters[4].Value = model.DownloadCount;
            parameters[5].Value = model.FileCategoryId;
            parameters[6].Value = model.UploadUserId;
            parameters[7].Value = model.UploadDate;
            parameters[8].Value = model.Sort;
            parameters[9].Value=model.NewsId;

            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int FileId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete T_File ");
            strSql.Append(" where FileId=@FileId");
            SqlParameter[] parameters = {
					new SqlParameter("@FileId", SqlDbType.Int,4)
				};
            parameters[0].Value = FileId;
            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public FileModel1 GetModel(int FileId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_File ");
            strSql.Append(" where FileId=@FileId");
            SqlParameter[] parameters = {
					new SqlParameter("@FileId", SqlDbType.Int,4)};
            parameters[0].Value = FileId;
            FileModel1 model = new FileModel1();
            DataSet ds = SQLHelper.Query(strSql.ToString(), parameters);
            model.FileId = FileId;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                model.FileName = ds.Tables[0].Rows[0]["FileName"].ToString();
                model.FilePath = ds.Tables[0].Rows[0]["FilePath"].ToString();
                if (ds.Tables[0].Rows[0]["DownloadCount"].ToString() != "")
                {
                    model.DownloadCount = int.Parse(ds.Tables[0].Rows[0]["DownloadCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FileCategoryId"].ToString() != "")
                {
                    model.FileCategoryId = int.Parse(ds.Tables[0].Rows[0]["FileCategoryId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UploadUserId"].ToString() != "")
                {
                    model.UploadUserId = int.Parse(ds.Tables[0].Rows[0]["UploadUserId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UploadDate"].ToString() != "")
                {
                    model.UploadDate = DateTime.Parse(ds.Tables[0].Rows[0]["UploadDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
                }
                //if (ds.Tables[0].Rows[0]["NewID"].ToString() != "")
                //{
                //    model.NewsId = int.Parse(ds.Tables[0].Rows[0]["NewsID"].ToString());
                //}
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_File ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by FileId ");
            return SQLHelper.Query(strSql.ToString());
        }

        //取得最新的药品价格信息或治疗价格信息
        public DataSet GetInfo(int Type)
        {
            string sql = "select top 1 * from T_File where FileCategoryId="+Type+" order by UploadDate desc";
            return SQLHelper.Query(sql);
        }

        //得到下载文件的类别列表
        public DataSet GetFileCategory()
        {
            string sql = "select * from T_FileCategory order by FileCategoryId asc";
            return SQLHelper.Query(sql);
        }
        #endregion  成员方法
    }
}
