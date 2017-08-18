using System;
using System.Collections.Generic;
using System.Text;
using CommonUtility.DBUtility;
using System.Data;
using System.Data.SqlClient;
using CommonUtility;

namespace Modules.Workers
{
  public  class ExpertOutDAL
    {
      public ExpertOutDAL()
      { }
      #region  成员方法
      /// <summary>
      /// 是否存在该记录
      /// </summary>
      public bool Exists(string Name)
      {
          StringBuilder strSql = new StringBuilder();
          strSql.Append("select count(1) from T_Experter_Out");
          strSql.Append(" where Name= @Name");
          SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50)
				};
          parameters[0].Value = Name;
          return SQLHelper.Exists(strSql.ToString(), parameters);
      }

      /// <summary>
      /// 是否存在该记录
      /// </summary>
      public bool Exists1(int ID)
      {
          StringBuilder strSql = new StringBuilder();
          strSql.Append("select count(1) from T_Experter_Out");
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
      public void Add(ExpertOutModel model)
      {
          StringBuilder strSql = new StringBuilder();
          strSql.Append("insert into T_Experter_Out(");
          strSql.Append("Name,Characteristic,AddedUserId,OutTime,Price,AddDate,Type,Sort)");
          strSql.Append(" values (");
          strSql.Append("@Name,@Characteristic,@AddedUserId,@OutTime,@Price,@AddDate,@Type,@Sort)");
          SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Characteristic", SqlDbType.VarChar,100),
					new SqlParameter("@AddedUserId", SqlDbType.Int,4),
					new SqlParameter("@OutTime", SqlDbType.VarChar,50),
					new SqlParameter("@Price", SqlDbType.VarChar,50),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
                    new SqlParameter("@Type",SqlDbType.Int,4),
                    new SqlParameter("@Sort",SqlDbType.Int,4)
          };
          parameters[0].Value = model.Name;
          parameters[1].Value = model.Characteristic;
          parameters[2].Value = model.AddedUserId;
          parameters[3].Value = model.OutTime;
          parameters[4].Value = model.Price;
          parameters[5].Value = model.AddDate;
          parameters[6].Value = model.Type;
          parameters[7].Value = model.Sort;

          SQLHelper.ExecuteSql(strSql.ToString(), parameters);
      }
      /// <summary>
      /// 更新一条数据
      /// </summary>
      public void Update(ExpertOutModel model)
      {
          StringBuilder strSql = new StringBuilder();
          strSql.Append("update T_Experter_Out set ");
          strSql.Append("Name=@Name,");
          strSql.Append("Characteristic=@Characteristic,");
          strSql.Append("AddedUserId=@AddedUserId,");
          strSql.Append("OutTime=@OutTime,");
          strSql.Append("Price=@Price,");
          strSql.Append("AddDate=@AddDate,");
          strSql.Append("Type=@Type,");
          strSql.Append("Sort=@Sort");
          strSql.Append(" where ID=@ID");
          SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Characteristic", SqlDbType.VarChar,100),
					new SqlParameter("@AddedUserId", SqlDbType.Int,4),
					new SqlParameter("@OutTime", SqlDbType.VarChar,50),
					new SqlParameter("@Price", SqlDbType.VarChar,50),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
                    new SqlParameter("@Type",SqlDbType.Int,4),
                    new SqlParameter("@Sort",SqlDbType.Int,4)
          };
          parameters[0].Value = model.ID;
          parameters[1].Value = model.Name;
          parameters[2].Value = model.Characteristic;
          parameters[3].Value = model.AddedUserId;
          parameters[4].Value = model.OutTime;
          parameters[5].Value = model.Price;
          parameters[6].Value = model.AddDate;
          parameters[7].Value = model.Type;
          parameters[8].Value = model.Sort;

          SQLHelper.ExecuteSql(strSql.ToString(), parameters);
      }

      /// <summary>
      /// 删除一条数据
      /// </summary>
      public void Delete(string Name)
      {
          StringBuilder strSql = new StringBuilder();
          strSql.Append("delete T_Experter_Out ");
          strSql.Append(" where Name=@Name");
          SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50)
				};
          parameters[0].Value = Name;
          SQLHelper.ExecuteSql(strSql.ToString(), parameters);
      }


      /// <summary>
      /// 删除一条数据
      /// </summary>
      public void Delete1(int ID)
      {
          StringBuilder strSql = new StringBuilder();
          strSql.Append("delete T_Experter_Out ");
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
      public ExpertOutModel GetModel(string Name)
      {
          StringBuilder strSql = new StringBuilder();
          strSql.Append("select * from T_Experter_Out ");
          strSql.Append(" where Name=@Name");
          SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50)};
          parameters[0].Value = Name;
          ExpertOutModel model = new ExpertOutModel();
          DataSet ds = SQLHelper.Query(strSql.ToString(), parameters);
          model.Name =Name;
          if (ds.Tables[0].Rows.Count > 0)
          {
              model.ID = Int32.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
              model.Characteristic = ds.Tables[0].Rows[0]["Characteristic"].ToString();
              if (ds.Tables[0].Rows[0]["AddedUserId"].ToString() != "")
              {
                  model.AddedUserId = int.Parse(ds.Tables[0].Rows[0]["AddedUserId"].ToString());
              }
              model.OutTime = ds.Tables[0].Rows[0]["OutTime"].ToString();
              model.Price = ds.Tables[0].Rows[0]["Price"].ToString();
              if (ds.Tables[0].Rows[0]["AddDate"].ToString() != "")
              {
                  model.AddDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
              }
              if (ds.Tables[0].Rows[0]["Type"].ToString() != "")
              {
                  model.Type = int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
              }
              
              if (ds.Tables[0].Rows[0]["Sort"].ToString() != "")
              {
                  model.Sort = int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
              }
              return model;
          }
          else
          {
              return null;
          }
      }

      /// <summary>
      /// 得到一个对象实体
      /// </summary>
      public ExpertOutModel GetModel1(int ID)
      {
          StringBuilder strSql = new StringBuilder();
          strSql.Append("select * from T_Experter_Out ");
          strSql.Append(" where ID=@ID");
          SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
          parameters[0].Value = ID;
          ExpertOutModel model = new ExpertOutModel();
          DataSet ds = SQLHelper.Query(strSql.ToString(), parameters);
          model.ID = ID;
          if (ds.Tables[0].Rows.Count > 0)
          {
              model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
              model.Characteristic = ds.Tables[0].Rows[0]["Characteristic"].ToString();
              if (ds.Tables[0].Rows[0]["AddedUserId"].ToString() != "")
              {
                  model.AddedUserId = int.Parse(ds.Tables[0].Rows[0]["AddedUserId"].ToString());
              }
              model.OutTime = ds.Tables[0].Rows[0]["OutTime"].ToString();
              model.Price = ds.Tables[0].Rows[0]["Price"].ToString();
              if (ds.Tables[0].Rows[0]["AddDate"].ToString() != "")
              {
                  model.AddDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
              }
              if (ds.Tables[0].Rows[0]["Type"].ToString() != "")
              {
                  model.Type = int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
              }

              if (ds.Tables[0].Rows[0]["Sort"].ToString() != "")
              {
                  model.Sort = int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
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
      public DataSet GetList()
      {
          string sql = "select * from VExpertOutList  order by Sort asc";
          return SQLHelper.Query(sql);
      }

      //获得专家门诊医师出诊信息
      public DataSet GetList1()
      {
          string sql = "select * from T_Experter_Out where Type=1 order by Sort asc";
          return SQLHelper.Query(sql);
      }

      //判断专家是否有出诊信息
      public bool CheckExpertOut(string name)
      {
          string sql = "select count(*) from T_Experter_Out where Name='"+name+"' ";
          string  count = SQLHelper.GetSingle(sql).ToString();
          if (count == "0")
          {
              return false;
          }
          else 
          {
              return true;
          }
       }


      //分页的方法 专家出诊
      public DataSet GetExpertOutList(string fields, string filter, string sort, int currentPageIndex, int pageSize, out int recordCount)
      {
          return PaginationUtility.GetPaginationList(fields, "VExpertOutList", filter, sort, currentPageIndex, pageSize, out recordCount);
      }

      //分页的方法 专科门诊
      public DataSet GetExpertOutList1(string fields, string filter, string sort, int currentPageIndex, int pageSize, out int recordCount)
      {
          return PaginationUtility.GetPaginationList(fields, "T_Experter_Out", filter, sort, currentPageIndex, pageSize, out recordCount);
      }

    
      #endregion  成员方法
    }
}
