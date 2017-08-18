using System;
using System.Collections.Generic;
using System.Text;
using CommonUtility.DBUtility;
using System.Data;
using System.Data.SqlClient;
using CommonUtility;

namespace Modules.Workers
{
   public class WorkerDAL
    {
       public WorkerDAL()
       { }
       #region  成员方法
       /// <summary>
       /// 是否存在该记录
       /// </summary>
       public bool Exists(int ID)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select count(1) from T_Workers");
           strSql.Append(" where ID= @ID");
           SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
           parameters[0].Value = ID;
           return SQLHelper.Exists(strSql.ToString(), parameters);
       }


       /// <summary>
       /// 增加一条数据
       /// </summary>
       public void Add(WorkerModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into T_Workers(");
           strSql.Append("Name,Business,Degree,WorkTel,MZTel,OfficeTel,Email,Area,Science,Resume,ImgLink,LookTime,Prize,PersonType,Sort,AddDate,Depart)");
           strSql.Append(" values (");
           strSql.Append("@Name,@Business,@Degree,@WorkTel,@MZTel,@OfficeTel,@Email,@Area,@Science,@Resume,@ImgLink,@LookTime,@Prize,@PersonType,@Sort,@AddDate,@Depart)");
           SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Business", SqlDbType.VarChar,100),
					new SqlParameter("@Degree", SqlDbType.VarChar,100),
					new SqlParameter("@WorkTel", SqlDbType.VarChar,50),
					new SqlParameter("@MZTel", SqlDbType.VarChar,50),
					new SqlParameter("@OfficeTel", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@Area", SqlDbType.VarChar,500),
					new SqlParameter("@Science", SqlDbType.VarChar,500),
					new SqlParameter("@Resume", SqlDbType.Text),
					new SqlParameter("@ImgLink", SqlDbType.VarChar,500),
					new SqlParameter("@LookTime", SqlDbType.VarChar,500),
					new SqlParameter("@Prize", SqlDbType.VarChar,500),
					new SqlParameter("@PersonType", SqlDbType.Int,4),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
                    new SqlParameter("@Depart",SqlDbType.Int,4)
           };
           parameters[0].Value = model.Name;
           parameters[1].Value = model.Business;
           parameters[2].Value = model.Degree;
           parameters[3].Value = model.WorkTel;
           parameters[4].Value = model.MZTel;
           parameters[5].Value = model.OfficeTel;
           parameters[6].Value = model.Email;
           parameters[7].Value = model.Area;
           parameters[8].Value = model.Science;
           parameters[9].Value = model.Resume;
           parameters[10].Value = model.ImgLink;
           parameters[11].Value = model.LookTime;
           parameters[12].Value = model.Prize;
           parameters[13].Value = model.PersonType;
           parameters[14].Value = model.Sort;
           parameters[15].Value = model.AddDate;
           parameters[16].Value = model.Depart;

           SQLHelper.ExecuteSql(strSql.ToString(), parameters);
       }
       /// <summary>
       /// 更新一条数据
       /// </summary>
       public void Update(WorkerModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update T_Workers set ");
           strSql.Append("Name=@Name,");
           strSql.Append("Business=@Business,");
           strSql.Append("Degree=@Degree,");
           strSql.Append("WorkTel=@WorkTel,");
           strSql.Append("MZTel=@MZTel,");
           strSql.Append("OfficeTel=@OfficeTel,");
           strSql.Append("Email=@Email,");
           strSql.Append("Area=@Area,");
           strSql.Append("Science=@Science,");
           strSql.Append("Resume=@Resume,");
           strSql.Append("ImgLink=@ImgLink,");
           strSql.Append("LookTime=@LookTime,");
           strSql.Append("Prize=@Prize,");
           strSql.Append("PersonType=@PersonType,");
           strSql.Append("Sort=@Sort,");
           strSql.Append("AddDate=@AddDate,");
           strSql.Append("Depart=@Depart");
           strSql.Append(" where ID=@ID");
           SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Business", SqlDbType.VarChar,100),
					new SqlParameter("@Degree", SqlDbType.VarChar,100),
					new SqlParameter("@WorkTel", SqlDbType.VarChar,50),
					new SqlParameter("@MZTel", SqlDbType.VarChar,50),
					new SqlParameter("@OfficeTel", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@Area", SqlDbType.VarChar,500),
					new SqlParameter("@Science", SqlDbType.VarChar,500),
					new SqlParameter("@Resume", SqlDbType.Text),
					new SqlParameter("@ImgLink", SqlDbType.VarChar,500),
					new SqlParameter("@LookTime", SqlDbType.VarChar,500),
					new SqlParameter("@Prize", SqlDbType.VarChar,500),
					new SqlParameter("@PersonType", SqlDbType.Int,4),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
                    new SqlParameter("@Depart",SqlDbType.Int,4)
           };
           parameters[0].Value = model.ID;
           parameters[1].Value = model.Name;
           parameters[2].Value = model.Business;
           parameters[3].Value = model.Degree;
           parameters[4].Value = model.WorkTel;
           parameters[5].Value = model.MZTel;
           parameters[6].Value = model.OfficeTel;
           parameters[7].Value = model.Email;
           parameters[8].Value = model.Area;
           parameters[9].Value = model.Science;
           parameters[10].Value = model.Resume;
           parameters[11].Value = model.ImgLink;
           parameters[12].Value = model.LookTime;
           parameters[13].Value = model.Prize;
           parameters[14].Value = model.PersonType;
           parameters[15].Value = model.Sort;
           parameters[16].Value = model.AddDate;
           parameters[17].Value = model.Depart;

           SQLHelper.ExecuteSql(strSql.ToString(), parameters);
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public void Delete(int ID)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete T_Workers ");
           strSql.Append(" where ID=@ID");
           SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
           parameters[0].Value = ID;
           SQLHelper.ExecuteSql(strSql.ToString(), parameters);
       }


       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public WorkerModel GetModel(int ID)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select * from T_Workers ");
           strSql.Append(" where ID=@ID");
           SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
           parameters[0].Value = ID;
           WorkerModel model = new WorkerModel();
           DataSet ds = SQLHelper.Query(strSql.ToString(), parameters);
           model.ID = ID;
           if (ds.Tables[0].Rows.Count > 0)
           {
               model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
               model.Business = ds.Tables[0].Rows[0]["Business"].ToString();
               model.Degree = ds.Tables[0].Rows[0]["Degree"].ToString();
               model.WorkTel = ds.Tables[0].Rows[0]["WorkTel"].ToString();
               model.MZTel = ds.Tables[0].Rows[0]["MZTel"].ToString();
               model.OfficeTel = ds.Tables[0].Rows[0]["OfficeTel"].ToString();
               model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
               model.Area = ds.Tables[0].Rows[0]["Area"].ToString();
               model.Science = ds.Tables[0].Rows[0]["Science"].ToString();
               model.Resume = ds.Tables[0].Rows[0]["Resume"].ToString();
               model.ImgLink = ds.Tables[0].Rows[0]["ImgLink"].ToString();
               model.LookTime = ds.Tables[0].Rows[0]["LookTime"].ToString();
               model.Prize = ds.Tables[0].Rows[0]["Prize"].ToString();
               if (ds.Tables[0].Rows[0]["PersonType"].ToString() != "")
               {
                   model.PersonType = int.Parse(ds.Tables[0].Rows[0]["PersonType"].ToString());
               }
               if (ds.Tables[0].Rows[0]["Sort"].ToString() != "")
               {
                   model.Sort = int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
               }
               if (ds.Tables[0].Rows[0]["AddDate"].ToString() != "")
               {
                   model.AddDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
               }
               if (ds.Tables[0].Rows[0]["Depart"].ToString() != "")
               {
                   model.Depart = int.Parse(ds.Tables[0].Rows[0]["Depart"].ToString());
               }
               return model;
           }
           else
           {
               return null;
           }
       }
       //根据workid取得人员姓名
       public string GetPersonNameById(int id)
       {
           string sql = "select Name from T_Workers where ID="+id+"";
           return SQLHelper.GetSingle(sql).ToString();
       }

       /// <summary>
       /// 获得数据列表
       /// </summary>
       public DataSet GetList(string strWhere)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select * from T_Workers ");
           if (strWhere.Trim() != "")
           {
               strSql.Append(" where " + strWhere);
           }
           strSql.Append(" order by Sort");
           return SQLHelper.Query(strSql.ToString());
       }
      

       //得到专家列表中专家列表信息
       public DataSet GetSingleList(int Depart)
       {
           string sql = "select * from V_WorkerList where Depart=" + Depart + " order by Sort";
           return SQLHelper.Query(sql);
        }

     


       //得到专家信息列表
       public DataSet GetWorkerList(string fields, string filter, string sort, int currentPageIndex, int pageSize, out int recordCount)
       {
           return PaginationUtility.GetPaginationList(fields, "V_WorkerList", filter, sort, currentPageIndex, pageSize, out recordCount);
       }

       //得到领导信息列表
       public DataSet GetWorkerList1(string fields, string filter, string sort, int currentPageIndex, int pageSize, out int recordCount)
       {
           return PaginationUtility.GetPaginationList(fields, "T_Workers", filter, sort, currentPageIndex, pageSize, out recordCount);
       }
       
     
       #endregion  成员方法
    }
}
