using System;
using System.Collections.Generic;
using System.Text;
using CommonUtility.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace Modules.Job
{
   public class JobDAL1
    {
       public JobDAL1()
       { }
       #region  成员方法
       /// <summary>
       /// 是否存在该记录
       /// </summary>
       public bool Exists(int PostId)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select count(1) from T_Job_Post");
           strSql.Append(" where PostId= @PostId");
           SqlParameter[] parameters = {
					new SqlParameter("@PostId", SqlDbType.Int,4)
				};
           parameters[0].Value = PostId;
           return SQLHelper.Exists(strSql.ToString(), parameters);
       }


       /// <summary>
       /// 增加一条数据
       /// </summary>
       public void Add(JobModel1 model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into T_Job_Post(");
           strSql.Append("Description,PersonNum,Sex,Age,Diploma,WorkMode,IsThisYear,WorkAge,OtherRequests,ReleaseDate,ExpireDate,AddedDate,AddedUserId,DepartmentId,ViewCount,WorkPlace,ConnectTel,Approved)");
           strSql.Append(" values (");
           strSql.Append("@Description,@PersonNum,@Sex,@Age,@Diploma,@WorkMode,@IsThisYear,@WorkAge,@OtherRequests,@ReleaseDate,@ExpireDate,@AddedDate,@AddedUserId,@DepartmentId,@ViewCount,@WorkPlace,@ConnectTel,@Approved)");
           SqlParameter[] parameters = {
					new SqlParameter("@Description", SqlDbType.VarChar,50),
					new SqlParameter("@PersonNum", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@Age", SqlDbType.VarChar,50),
					new SqlParameter("@Diploma", SqlDbType.VarChar,50),
					new SqlParameter("@WorkMode", SqlDbType.Int,4),
					new SqlParameter("@IsThisYear", SqlDbType.Int,4),
					new SqlParameter("@WorkAge", SqlDbType.VarChar,50),
					new SqlParameter("@OtherRequests", SqlDbType.Text),
					new SqlParameter("@ReleaseDate", SqlDbType.DateTime),
					new SqlParameter("@ExpireDate", SqlDbType.DateTime),
					new SqlParameter("@AddedDate", SqlDbType.DateTime),
					new SqlParameter("@AddedUserId", SqlDbType.Int,4),
					new SqlParameter("@DepartmentId", SqlDbType.Int,4),
					new SqlParameter("@ViewCount", SqlDbType.Int,4),
					new SqlParameter("@WorkPlace", SqlDbType.VarChar,500),
                    new SqlParameter("@ConnectTel", SqlDbType.VarChar,50),
                    new SqlParameter("@Approved",SqlDbType.Int,4)
           };
           parameters[0].Value = model.Description;
           parameters[1].Value = model.PersonNum;
           parameters[2].Value = model.Sex;
           parameters[3].Value = model.Age;
           parameters[4].Value = model.Diploma;
           parameters[5].Value = model.WorkMode;
           parameters[6].Value = model.IsThisYear;
           parameters[7].Value = model.WorkAge;
           parameters[8].Value = model.OtherRequests;
           parameters[9].Value = model.ReleaseDate;
           parameters[10].Value = model.ExpireDate;
           parameters[11].Value = model.AddedDate;
           parameters[12].Value = model.AddedUserId;
           parameters[13].Value = model.DepartmentId;
           parameters[14].Value = model.ViewCount;
           parameters[15].Value = model.WorkPlace;
           parameters[16].Value = model.ConnectTel;
           parameters[17].Value = model.Approved;

           SQLHelper.ExecuteSql(strSql.ToString(), parameters);
       }

     
       /// <summary>
       /// 更新一条数据
       /// </summary>
       public void Update(JobModel1 model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update T_Job_Post set ");
           strSql.Append("Description=@Description,");
           strSql.Append("PersonNum=@PersonNum,");
           strSql.Append("Sex=@Sex,");
           strSql.Append("Age=@Age,");
           strSql.Append("Diploma=@Diploma,");
           strSql.Append("WorkMode=@WorkMode,");
           strSql.Append("IsThisYear=@IsThisYear,");
           strSql.Append("WorkAge=@WorkAge,");
           strSql.Append("OtherRequests=@OtherRequests,");
           strSql.Append("ReleaseDate=@ReleaseDate,");
           strSql.Append("ExpireDate=@ExpireDate,");
           strSql.Append("AddedDate=@AddedDate,");
           strSql.Append("AddedUserId=@AddedUserId,");
           strSql.Append("DepartmentId=@DepartmentId,");
           strSql.Append("ViewCount=@ViewCount,");
           strSql.Append("WorkPlace=@WorkPlace");
           strSql.Append("ConnectTel=@ConnectTel");
           strSql.Append("Approved=@Approved");
           strSql.Append(" where PostId=@PostId");
           SqlParameter[] parameters = {
					new SqlParameter("@PostId", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.VarChar,50),
					new SqlParameter("@PersonNum", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@Age", SqlDbType.VarChar,50),
					new SqlParameter("@Diploma", SqlDbType.VarChar,50),
					new SqlParameter("@WorkMode", SqlDbType.Int,4),
					new SqlParameter("@IsThisYear", SqlDbType.Int,4),
					new SqlParameter("@WorkAge", SqlDbType.VarChar,50),
					new SqlParameter("@OtherRequests", SqlDbType.Text),
					new SqlParameter("@ReleaseDate", SqlDbType.DateTime),
					new SqlParameter("@ExpireDate", SqlDbType.DateTime),
					new SqlParameter("@AddedDate", SqlDbType.DateTime),
					new SqlParameter("@AddedUserId", SqlDbType.Int,4),
					new SqlParameter("@DepartmentId", SqlDbType.Int,4),
					new SqlParameter("@ViewCount", SqlDbType.Int,4),
					new SqlParameter("@WorkPlace", SqlDbType.VarChar,500),
                    new SqlParameter("@ConnectTel", SqlDbType.VarChar,50),
                    new SqlParameter("@Approved", SqlDbType.Int,4)
           };
           parameters[0].Value = model.PostId;
           parameters[1].Value = model.Description;
           parameters[2].Value = model.PersonNum;
           parameters[3].Value = model.Sex;
           parameters[4].Value = model.Age;
           parameters[5].Value = model.Diploma;
           parameters[6].Value = model.WorkMode;
           parameters[7].Value = model.IsThisYear;
           parameters[8].Value = model.WorkAge;
           parameters[9].Value = model.OtherRequests;
           parameters[10].Value = model.ReleaseDate;
           parameters[11].Value = model.ExpireDate;
           parameters[12].Value = model.AddedDate;
           parameters[13].Value = model.AddedUserId;
           parameters[14].Value = model.DepartmentId;
           parameters[15].Value = model.ViewCount;
           parameters[16].Value = model.WorkPlace;
           parameters[17].Value = model.ConnectTel;
           parameters[18].Value = model.Approved;

           SQLHelper.ExecuteSql(strSql.ToString(), parameters);
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public void Delete(int PostId)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete T_Job_Post ");
           strSql.Append(" where PostId=@PostId");
           SqlParameter[] parameters = {
					new SqlParameter("@PostId", SqlDbType.Int,4)
				};
           parameters[0].Value = PostId;
           SQLHelper.ExecuteSql(strSql.ToString(), parameters);
       }


       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public JobModel1 GetModel(int PostId)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select * from T_Job_Post ");
           strSql.Append(" where PostId=@PostId");
           SqlParameter[] parameters = {
					new SqlParameter("@PostId", SqlDbType.Int,4)};
           parameters[0].Value = PostId;
           JobModel1 model = new JobModel1();
           DataSet ds = SQLHelper.Query(strSql.ToString(), parameters);
           model.PostId = PostId;
           if (ds.Tables[0].Rows.Count > 0)
           {
               model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
               model.PersonNum = ds.Tables[0].Rows[0]["PersonNum"].ToString();
               if (ds.Tables[0].Rows[0]["Sex"].ToString() != "")
               {
                   model.Sex = int.Parse(ds.Tables[0].Rows[0]["Sex"].ToString());
               }
               model.Age = ds.Tables[0].Rows[0]["Age"].ToString();
               model.Diploma = ds.Tables[0].Rows[0]["Diploma"].ToString();
               if (ds.Tables[0].Rows[0]["WorkMode"].ToString() != "")
               {
                   model.WorkMode = int.Parse(ds.Tables[0].Rows[0]["WorkMode"].ToString());
               }
               if (ds.Tables[0].Rows[0]["IsThisYear"].ToString() != "")
               {
                   model.IsThisYear = int.Parse(ds.Tables[0].Rows[0]["IsThisYear"].ToString());
               }
               model.WorkAge = ds.Tables[0].Rows[0]["WorkAge"].ToString();
               model.OtherRequests = ds.Tables[0].Rows[0]["OtherRequests"].ToString();
               if (ds.Tables[0].Rows[0]["ReleaseDate"].ToString() != "")
               {
                   model.ReleaseDate = DateTime.Parse(ds.Tables[0].Rows[0]["ReleaseDate"].ToString());
               }
               if (ds.Tables[0].Rows[0]["ExpireDate"].ToString() != "")
               {
                   model.ExpireDate = DateTime.Parse(ds.Tables[0].Rows[0]["ExpireDate"].ToString());
               }
               if (ds.Tables[0].Rows[0]["AddedDate"].ToString() != "")
               {
                   model.AddedDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddedDate"].ToString());
               }
               if (ds.Tables[0].Rows[0]["AddedUserId"].ToString() != "")
               {
                   model.AddedUserId = int.Parse(ds.Tables[0].Rows[0]["AddedUserId"].ToString());
               }
               if (ds.Tables[0].Rows[0]["DepartmentId"].ToString() != "")
               {
                   model.DepartmentId = int.Parse(ds.Tables[0].Rows[0]["DepartmentId"].ToString());
               }
               if (ds.Tables[0].Rows[0]["ViewCount"].ToString() != "")
               {
                   model.ViewCount = int.Parse(ds.Tables[0].Rows[0]["ViewCount"].ToString());
               }
               model.WorkPlace = ds.Tables[0].Rows[0]["WorkPlace"].ToString();
               model.ConnectTel = ds.Tables[0].Rows[0]["ConnectTel"].ToString();
               if (ds.Tables[0].Rows[0]["Approved"].ToString() != "")
               {
                   model.Approved = int.Parse(ds.Tables[0].Rows[0]["Approved"].ToString());
               }
               return model;
           }
           else
           {
               return null;
           }
       }
       //显示招聘部门名称
       public DataSet GetDepartName(int jobid)
       {
           string sql = "select a.* ,b.Name from T_Job_Post a  left join T_Job_Department b on a.DepartmentId = b.DepartmentId where a.PostId="+jobid+"";
           return SQLHelper.Query(sql);
       }
       //显示招聘信息
       public DataSet GetJobList()
       {
           string sql = "select a.* ,b.Name from T_Job_Post a  left join T_Job_Department b on a.DepartmentId = b.DepartmentId where ExpireDate > getdate()";
           return SQLHelper.Query(sql);
       }
       /// <summary>
       /// 获得数据列表
       /// </summary>
       public DataSet GetList(string strWhere)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select * from T_Job_Post ");
           if (strWhere.Trim() != "")
           {
               strSql.Append(" where " + strWhere);
           }
           strSql.Append(" order by PostId ");
           return SQLHelper.Query(strSql.ToString());
       }
       #endregion  成员方法

    }
}
