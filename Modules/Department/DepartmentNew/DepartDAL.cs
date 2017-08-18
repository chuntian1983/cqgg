using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CommonUtility.DBUtility;

namespace Modules.Department
{
   public  class DepartDAL
    {
       public DepartDAL()
       { }
       #region  成员方法
       /// <summary>
       /// 是否存在该记录
       /// </summary>
       public bool Exists(int CategoryId)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select count(1) from T_DepartInfo");
           strSql.Append(" where CategoryId= @CategoryId");
           SqlParameter[] parameters = {
					new SqlParameter("@CategoryId", SqlDbType.Int,4)
				};
           parameters[0].Value = CategoryId;
           return SQLHelper.Exists(strSql.ToString(), parameters);
       }


       /// <summary>
       /// 增加一条数据
       /// </summary>
       public void Add(DepartModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into T_DepartInfo(");
           strSql.Append("Title,Body,AddedUserId,AddedDate,CategoryId,Approved,ViewCount,ImgLink,IsState)");
           strSql.Append(" values (");
           strSql.Append("@Title,@Body,@AddedUserId,@AddedDate,@CategoryId,@Approved,@ViewCount,@ImgLink,@IsState)");
           SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@Body", SqlDbType.Text),
					new SqlParameter("@AddedUserId", SqlDbType.Int,4),
					new SqlParameter("@AddedDate", SqlDbType.DateTime),
					new SqlParameter("@CategoryId", SqlDbType.Int,4),
					new SqlParameter("@Approved", SqlDbType.Int,4),
					new SqlParameter("@ViewCount", SqlDbType.Int,4),
					new SqlParameter("@ImgLink", SqlDbType.VarChar,50),
					new SqlParameter("@IsState", SqlDbType.Int,4)};
           parameters[0].Value = model.Title;
           parameters[1].Value = model.Body;
           parameters[2].Value = model.AddedUserId;
           parameters[3].Value = model.AddedDate;
           parameters[4].Value = model.CategoryId;
           parameters[5].Value = model.Approved;
           parameters[6].Value = model.ViewCount;
           parameters[7].Value = model.ImgLink;
           parameters[8].Value = model.IsState;

           SQLHelper.ExecuteSql(strSql.ToString(), parameters);
       }
       /// <summary>
       /// 更新一条数据
       /// </summary>
       public void Update(DepartModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update T_DepartInfo set ");
           strSql.Append("Title=@Title,");
           strSql.Append("Body=@Body,");
           strSql.Append("AddedUserId=@AddedUserId,");
           strSql.Append("AddedDate=@AddedDate,");
           strSql.Append("CategoryId=@CategoryId,");
           strSql.Append("Approved=@Approved,");
           strSql.Append("ViewCount=@ViewCount,");
           strSql.Append("ImgLink=@ImgLink,");
           strSql.Append("IsState=@IsState");
           strSql.Append(" where DepartId=@DepartId");
           SqlParameter[] parameters = {
					new SqlParameter("@DepartId", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@Body", SqlDbType.Text),
					new SqlParameter("@AddedUserId", SqlDbType.Int,4),
					new SqlParameter("@AddedDate", SqlDbType.DateTime),
					new SqlParameter("@CategoryId", SqlDbType.Int,4),
					new SqlParameter("@Approved", SqlDbType.Int,4),
					new SqlParameter("@ViewCount", SqlDbType.Int,4),
					new SqlParameter("@ImgLink", SqlDbType.VarChar,50),
					new SqlParameter("@IsState", SqlDbType.Int,4)};
           parameters[0].Value = model.DepartId;
           parameters[1].Value = model.Title;
           parameters[2].Value = model.Body;
           parameters[3].Value = model.AddedUserId;
           parameters[4].Value = model.AddedDate;
           parameters[5].Value = model.CategoryId;
           parameters[6].Value = model.Approved;
           parameters[7].Value = model.ViewCount;
           parameters[8].Value = model.ImgLink;
           parameters[9].Value = model.IsState;

           SQLHelper.ExecuteSql(strSql.ToString(), parameters);
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public void Delete(int DepartId)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete T_DepartInfo ");
           strSql.Append(" where DepartId=@DepartId");
           SqlParameter[] parameters = {
					new SqlParameter("@DepartId", SqlDbType.Int,4)
				};
           parameters[0].Value = DepartId;
           SQLHelper.ExecuteSql(strSql.ToString(), parameters);
       }


       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public DepartModel GetModel(int CategoryId)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select * from T_DepartInfo ");
           strSql.Append(" where CategoryId=@CategoryId");
           SqlParameter[] parameters = {
					new SqlParameter("@CategoryId", SqlDbType.Int,4)};
           parameters[0].Value = CategoryId;
           DepartModel model = new DepartModel();
           DataSet ds = SQLHelper.Query(strSql.ToString(), parameters);
           model.CategoryId = CategoryId;
           if (ds.Tables[0].Rows.Count > 0)
           {
               model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
               model.Body = ds.Tables[0].Rows[0]["Body"].ToString();
               if (ds.Tables[0].Rows[0]["AddedUserId"].ToString() != "")
               {
                   model.AddedUserId = int.Parse(ds.Tables[0].Rows[0]["AddedUserId"].ToString());
               }
               if (ds.Tables[0].Rows[0]["AddedDate"].ToString() != "")
               {
                   model.AddedDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddedDate"].ToString());
               }
               if (ds.Tables[0].Rows[0]["DepartId"].ToString() != "")
               {
                   model.CategoryId = int.Parse(ds.Tables[0].Rows[0]["DepartId"].ToString());
               }
               if (ds.Tables[0].Rows[0]["Approved"].ToString() != "")
               {
                   model.Approved = int.Parse(ds.Tables[0].Rows[0]["Approved"].ToString());
               }
               if (ds.Tables[0].Rows[0]["ViewCount"].ToString() != "")
               {
                   model.ViewCount = int.Parse(ds.Tables[0].Rows[0]["ViewCount"].ToString());
               }
               model.ImgLink = ds.Tables[0].Rows[0]["ImgLink"].ToString();
               if (ds.Tables[0].Rows[0]["IsState"].ToString() != "")
               {
                   model.IsState = int.Parse(ds.Tables[0].Rows[0]["IsState"].ToString());
               }
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
           strSql.Append("select * from T_DepartInfo ");
           if (strWhere.Trim() != "")
           {
               strSql.Append(" where " + strWhere);
           }
           strSql.Append(" order by DepartId ");
           return SQLHelper.Query(strSql.ToString());
       }

       //根据专科科室的编号取得专科科室的名称
       public string GetCategoryName(int CategoryId)
       {
           string sql = "select Title from T_DepartCategory where CategoryId=" + CategoryId + "";
           return SQLHelper.GetSingle(sql).ToString();
       }

       //根据专科科室的名称取得专科科室的编号
       public string GetCategoryId(string Name)
       {
           string sql = "select CategoryId from T_DepartCategory where Title='" + Name + "'";
           return SQLHelper.GetSingle(sql).ToString();
       }

       //根据子类别编号取得父类别编号
       public string GetParentCategoryId(int CategoryId)
       {
           string sql = "select ParentCategoryId from T_DepartCategory where CategoryId="+CategoryId+"";
           return SQLHelper.GetSingle(sql).ToString();
       }

       //取得科室表中所有父类别的信息
       public DataSet GetAllPartentCategoryInfo()
       {
           string sql = "select * from T_DepartCategory where ParentCategoryId=0 order by Sort asc";
           return SQLHelper.Query(sql);
       }

       //根据父类别编号取得其子类别列表(专科门诊子类别列表)
       public DataSet GetSonCategoryList()
       {
           string sql = "select * from T_DepartCategory where ParentCategoryId='3' order by Sort asc";
           return SQLHelper.Query(sql);
       }

       //根据父类别ID去取得该父类别下的子类别信息
       public DataSet GetSonCategoryInfo(int ParentCategoryID)
       {
           string sql = "select * from T_DepartCategory where ParentCategoryId="+ParentCategoryID+" order by Sort asc";
           return SQLHelper.Query(sql);
       }

       //判断部门类别ID是不是父类别编号
       public bool CheckCategoryId(int CategoryId)
       {
           string sql = "select count(*) from T_DepartCategory as  a inner join T_DepartCategory as b on a.ParentCategoryId=b.CategoryId where b.ParentCategoryId=0 and a.CategoryId=" + CategoryId + "";
           string result = SQLHelper.GetSingle(sql).ToString();
           if (result == "0")
           {
               return true;//表示该类别是父类别
           }

           else
               return false;//表示该类别是子类别
       }

       //根据父类别ID的编号,取得该父类别下的第一个子类别的ID
       public string GetFistCategoryId(int CategoryId)
       {
           string sql = "select top 1 CategoryId from T_DepartCategory where ParentCategoryId="+CategoryId+" order by Sort asc";
           return SQLHelper.GetSingle(sql).ToString();
       }

       //取得医疗科室和医技科室中所有的子类科室
       public DataSet GetSonList()
       {
           string sql = "select * from T_DepartCategory where ParentCategoryId =1 or ParentCategoryId=2 ";
           return SQLHelper.Query(sql);
       }

       //根据科室类别编号取得科室名称
       public string GetDCategoryNameById(int CategoryId)
       {
           string sql = "select Title from T_DepartCategory where CategoryId="+CategoryId+"";
           return SQLHelper.GetSingle(sql).ToString();
       }
       #endregion  成员方法
    }
}
