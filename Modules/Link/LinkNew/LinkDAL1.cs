using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CommonUtility.DBUtility;

namespace Modules.Link
{
   public class LinkDAL1
    {
       public LinkDAL1()
       { }
       #region  成员方法
       /// <summary>
       /// 是否存在该记录
       /// </summary>
       public bool Exists(int LinkId)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select count(1) from T_Link");
           strSql.Append(" where LinkId= @LinkId");
           SqlParameter[] parameters = {
					new SqlParameter("@LinkId", SqlDbType.Int,4)
				};
           parameters[0].Value = LinkId;
           return SQLHelper.Exists(strSql.ToString(), parameters);
       }


       /// <summary>
       /// 增加一条数据
       /// </summary>
       public void Add(LinkModel1 model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into T_Link(");
           strSql.Append("Title,Link,Image,DisplayMode,Sort)");
           strSql.Append(" values (");
           strSql.Append("@Title,@Link,@Image,@DisplayMode,@Sort)");
           SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.VarChar,50),
					new SqlParameter("@Link", SqlDbType.VarChar,200),
					new SqlParameter("@Image", SqlDbType.VarChar,200),
					new SqlParameter("@DisplayMode", SqlDbType.Int,4),
					new SqlParameter("@Sort", SqlDbType.Int,4)};
           parameters[0].Value = model.Title;
           parameters[1].Value = model.Link;
           parameters[2].Value = model.Image;
           parameters[3].Value = model.DisplayMode;
           parameters[4].Value = model.Sort;

           SQLHelper.ExecuteSql(strSql.ToString(), parameters);
       }
       /// <summary>
       /// 更新一条数据
       /// </summary>
       public void Update(LinkModel1 model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update T_Link set ");
           strSql.Append("Title=@Title,");
           strSql.Append("Link=@Link,");
           strSql.Append("Image=@Image,");
           strSql.Append("DisplayMode=@DisplayMode,");
           strSql.Append("Sort=@Sort");
           strSql.Append(" where LinkId=@LinkId");
           SqlParameter[] parameters = {
					new SqlParameter("@LinkId", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.VarChar,50),
					new SqlParameter("@Link", SqlDbType.VarChar,200),
					new SqlParameter("@Image", SqlDbType.VarChar,200),
					new SqlParameter("@DisplayMode", SqlDbType.Int,4),
					new SqlParameter("@Sort", SqlDbType.Int,4)};
           parameters[0].Value = model.LinkId;
           parameters[1].Value = model.Title;
           parameters[2].Value = model.Link;
           parameters[3].Value = model.Image;
           parameters[4].Value = model.DisplayMode;
           parameters[5].Value = model.Sort;

           SQLHelper.ExecuteSql(strSql.ToString(), parameters);
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public void Delete(int LinkId)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete T_Link ");
           strSql.Append(" where LinkId=@LinkId");
           SqlParameter[] parameters = {
					new SqlParameter("@LinkId", SqlDbType.Int,4)
				};
           parameters[0].Value = LinkId;
           SQLHelper.ExecuteSql(strSql.ToString(), parameters);
       }


       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public LinkModel1 GetModel(int LinkId)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select * from T_Link ");
           strSql.Append(" where LinkId=@LinkId");
           SqlParameter[] parameters = {
					new SqlParameter("@LinkId", SqlDbType.Int,4)};
           parameters[0].Value = LinkId;
           LinkModel1 model = new LinkModel1();
           DataSet ds = SQLHelper.Query(strSql.ToString(), parameters);
           model.LinkId = LinkId;
           if (ds.Tables[0].Rows.Count > 0)
           {
               model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
               model.Link = ds.Tables[0].Rows[0]["Link"].ToString();
               model.Image = ds.Tables[0].Rows[0]["Image"].ToString();
               if (ds.Tables[0].Rows[0]["DisplayMode"].ToString() != "")
               {
                   model.DisplayMode = int.Parse(ds.Tables[0].Rows[0]["DisplayMode"].ToString());
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
       public DataSet GetList(string strWhere)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select * from T_Link ");
           if (strWhere.Trim() != "")
           {
               strSql.Append(" where " + strWhere);
           }
           strSql.Append(" order by LinkId ");
           return SQLHelper.Query(strSql.ToString());
       }
       #endregion  成员方法
    
    }
}
