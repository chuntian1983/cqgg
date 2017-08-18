using System;
using System.Collections.Generic;
using System.Text;
using CommonUtility.DBUtility;
using System.Data;
using System.Data.SqlClient;
using CommonUtility;
using MySql.Data.MySqlClient;

/// <summary>
/// ArticleDAL 的摘要说明
/// </summary>
namespace Modules.Article
{
    public class ArticleDAL1
    {
        AdoHelper help = AdoHelper.CreateHelper();
        public ArticleDAL1()
        {
        }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string  Name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_Article");
            strSql.Append(" where PublicationUnit= @Name");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50)
				};
            parameters[0].Value = Name;
            return SQLHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ArticleModel1 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Article(");
            strSql.Append("Title,Body,AddedUserId,PublicationUnit,AddedDate,ReleaseDate,ExpireDate,CategoryId,Approved,ViewCount)");
            strSql.Append(" values (");
            strSql.Append("@Title,@Body,@AddedUserId,@PublicationUnit,@AddedDate,@ReleaseDate,@ExpireDate,@CategoryId,@Approved,@ViewCount)");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@Body", SqlDbType.Text),
					new SqlParameter("@AddedUserId", SqlDbType.Int,4),
					new SqlParameter("@PublicationUnit", SqlDbType.VarChar,50),
					new SqlParameter("@AddedDate", SqlDbType.DateTime),
					new SqlParameter("@ReleaseDate", SqlDbType.DateTime),
					new SqlParameter("@ExpireDate", SqlDbType.DateTime),
					new SqlParameter("@CategoryId", SqlDbType.Int,4),
					new SqlParameter("@Approved", SqlDbType.Int,4),
					new SqlParameter("@ViewCount", SqlDbType.Int,4)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.Body;
            parameters[2].Value = model.AddedUserId;
            parameters[3].Value = model.PublicationUnit;
            parameters[4].Value = model.AddedDate;
            parameters[5].Value = model.ReleaseDate;
            parameters[6].Value = model.ExpireDate;
            parameters[7].Value = model.CategoryId;
            parameters[8].Value = model.Approved;
            parameters[9].Value = model.ViewCount;

            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ArticleModel1 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Article set ");
            strSql.Append("Title=@Title,");
            strSql.Append("Body=@Body,");
            strSql.Append("AddedUserId=@AddedUserId,");
            strSql.Append("PublicationUnit=@PublicationUnit,");
            strSql.Append("AddedDate=@AddedDate,");
            strSql.Append("ReleaseDate=@ReleaseDate,");
            strSql.Append("ExpireDate=@ExpireDate,");
            strSql.Append("CategoryId=@CategoryId,");
            strSql.Append("Approved=@Approved,");
            strSql.Append("ViewCount=@ViewCount");
            strSql.Append(" where ArticleId=@ArticleId");
            SqlParameter[] parameters = {
					new SqlParameter("@ArticleId", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@Body", SqlDbType.Text),
					new SqlParameter("@AddedUserId", SqlDbType.Int,4),
					new SqlParameter("@PublicationUnit", SqlDbType.VarChar,50),
					new SqlParameter("@AddedDate", SqlDbType.DateTime),
					new SqlParameter("@ReleaseDate", SqlDbType.DateTime),
					new SqlParameter("@ExpireDate", SqlDbType.DateTime),
					new SqlParameter("@CategoryId", SqlDbType.Int,4),
					new SqlParameter("@Approved", SqlDbType.Int,4),
					new SqlParameter("@ViewCount", SqlDbType.Int,4)};
            parameters[0].Value = model.ArticleId;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Body;
            parameters[3].Value = model.AddedUserId;
            parameters[4].Value = model.PublicationUnit;
            parameters[5].Value = model.AddedDate;
            parameters[6].Value = model.ReleaseDate;
            parameters[7].Value = model.ExpireDate;
            parameters[8].Value = model.CategoryId;
            parameters[9].Value = model.Approved;
            parameters[10].Value = model.ViewCount;

            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ArticleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete T_Article ");
            strSql.Append(" where ArticleId=@ArticleId");
            SqlParameter[] parameters = {
					new SqlParameter("@ArticleId", SqlDbType.Int,4)
				};
            parameters[0].Value = ArticleId;
            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 删除一条数据1
        /// </summary>
        public void Delete(string  Name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete T_Article ");
            strSql.Append(" where PublicationUnit=@Name");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50)
				};
            parameters[0].Value = Name;
            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ArticleModel1 GetModel(int ArticleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_Article ");
            strSql.Append(" where ArticleId=@ArticleId");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ArticleId",MySqlDbType.Int32)};
            parameters[0].Value = ArticleId;
            ArticleModel1 model = new ArticleModel1();
            DataSet ds =help.ExecuteDataset(help.connectionString,CommandType.Text, strSql.ToString(), parameters);
            model.ArticleId = ArticleId;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Body = ds.Tables[0].Rows[0]["Body"].ToString();
                if (ds.Tables[0].Rows[0]["AddedUserId"].ToString() != "")
                {
                    model.AddedUserId = int.Parse(ds.Tables[0].Rows[0]["AddedUserId"].ToString());
                }
                model.PublicationUnit = ds.Tables[0].Rows[0]["PublicationUnit"].ToString();
                if (ds.Tables[0].Rows[0]["AddedDate"].ToString() != "")
                {
                    model.AddedDate =ds.Tables[0].Rows[0]["AddedDate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ReleaseDate"].ToString() != "")
                {
                    model.ReleaseDate =ds.Tables[0].Rows[0]["ReleaseDate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ExpireDate"].ToString() != "")
                {
                    model.ExpireDate = ds.Tables[0].Rows[0]["ExpireDate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CategoryId"].ToString() != "")
                {
                    model.CategoryId = int.Parse(ds.Tables[0].Rows[0]["CategoryId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Approved"].ToString() != "")
                {
                    model.Approved = int.Parse(ds.Tables[0].Rows[0]["Approved"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ViewCount"].ToString() != "")
                {
                    model.ViewCount = int.Parse(ds.Tables[0].Rows[0]["ViewCount"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        
        }

        //根据文章类别iD 取得文章类别信息
        public string GetArticleType(string aid)
        {
            string sql = "select Title from T_ArticleCategory where ArticleCategoryId='" + aid + "'";
            return SQLHelper.GetSingle(sql).ToString();
        }

        //得到控件上Datalist显示的子类别的名称 07.7.18
        public DataSet GetSonType(int PCategoryId)
        {
            string sql = "select a.Title ,a.Type,b.Title as SonTitle,b.CategoryId,b.ParentCategoryId from T_ArticleCategory a inner join T_ArticleCategory b on a.CategoryId =b.ParentCategoryId where a.CategoryId=" + PCategoryId + " order by a.Sort asc";
            return SQLHelper.Query(sql);
        }

        //页面登陆时在没有CategoryId得到T_ArticleCategory表中对应栏目的第一条子栏目 07.7.18 gy
        public DataSet Gettopsubtype(int topsubtype)
        {              
            string sql = "select top 1 * from T_ArticleCategory where ParentCategoryId="+topsubtype+"";
            return SQLHelper.Query(sql);
        }

        //根据文章类名称取得单篇文章信息
        public DataSet GetArticleSingle(string ArticleCategory)
        {
            string sql = @"select a.*,b.Title from T_Article a left join T_ArticleCategory b on a.CategoryId=b.CategoryId where b.Title='" + ArticleCategory + "' and a.Approved=1";
            return SQLHelper.Query(sql);
        }

        // //得到一篇文章(根据文章类型) 07.7.18
        //public DataSet GetArticleSingle(int Type)
        //{
        //    string sql = @"select a.*,b.Title as Titletype from T_Article as a,T_ArticleCategory as b where a.CategoryId=b.CategoryId  and b.CategoryId=" + Type + " and a.Approved=1";
        //    return SQLHelper.Query(sql);
        //}

       
        //判断传入的父文章类别是否还有子类别
        public bool CheckFType(int type)
        {
            string sql = "select count(*) from T_ArticleCategory where ParentCategoryId=" + type + "";
            string result = SQLHelper.GetSingle(sql).ToString();
            if (result == "0")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //根据父类别得到子类别 07.7.19
        public DataSet Subtype(int type)
        {
            string sql = "select * from T_ArticleCategory where ParentCategoryId=" + type + "";
            return SQLHelper.Query(sql);
        }

        //首页滚动显示的医学科研中取的是教学中的终极新闻
        public DataSet Yixue()
        {
            string sql = "select * from T_News where CategoryId in (select CategoryId from T_ArticleCategory where ParentCategoryId=196)  order by CategoryId";
            return SQLHelper.Query(sql);
        }

        //根据新闻类别取得新闻列表 07.7.19
        public DataSet GNewsList(int Typeid)
        {
            string sql = "select * from T_Article where CategoryId=" + Typeid + " order by ReleaseDate desc";
            return SQLHelper.Query(sql);
        }

        //根据新闻类别取得新闻列表7.20
        public DataSet NewsList(int NewsId)
        {
            string sql = "select * from T_Article where CategoryId =" + NewsId + "";
            return SQLHelper.Query(sql);
        }

        //根据新闻ＩＤ取得新闻 7.20
        public DataSet News(int NewsId) 
        {
            string sql = "select * from T_Article where ArticleId =" + NewsId + "";
            return SQLHelper.Query(sql);
        }

        //根据新闻类别取得新闻列表
        public DataSet GetNewsList(string NewsType)
        {
            string sql = "select a.*,b.Title as CategoryTitle,c.Nickname from T_Article a inner join T_ArticleCategory b on a.CategoryId=b.ArticleCategoryId inner join T_User c on a.AddedUserId=c.UserId where b.Type=1 and b.Title='" + NewsType + "'order by a.AddedDate desc";
            return SQLHelper.Query(sql);
        }

        //得到一篇文章(根据文章编号)
        public DataSet GetArticleSingle1(int ID)
        {
            string sql = "select * from T_Article where ArticleId=" + ID + "";
            return SQLHelper.Query(sql);
        }

        //得到领导讲话
        public DataSet GetLeaderSpeak(string Name)
        {
            string sql = "select * from T_Article where PublicationUnit='" + Name + "'";
            return SQLHelper.Query(sql);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 7 * from T_Article ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ReleaseDate desc ");
            return SQLHelper.Query(strSql.ToString());
        }
        /// <summary>
        /// 分页
        /// </summary>
        public DataSet GetSpeakList(string fields, string filter, string sort, int currentPageIndex, int pageSize, out int recordCount)
        {
            return PaginationUtility.GetPaginationList(fields, "T_Article", filter, sort, currentPageIndex, pageSize, out recordCount);
        }

        //判断传入的ID编号是一级还是二级 
        public bool CheckType(int id)
        {
            string sql = "select count(*) from T_ArticleCategory as  a inner join T_ArticleCategory as b on a.ParentCategoryId=b.CategoryId where b.ParentCategoryId=0 and a.CategoryId=" + id + "";
            string result = SQLHelper.GetSingle(sql).ToString();
            if (result == "0")
            {
                return false;//如果为0表示该类别是一级类别
            }

            else
                return true;//否则为二级类别
        }

        //根据子类别取得父类别
        public string GetParentType(int categoryid)
        {
            string sql = "select ParentCategoryId from T_ArticleCategory where CategoryId="+categoryid+"";
            return SQLHelper.GetSingle(sql).ToString();
        }

        //根据父类别编号取得该父类别下的第一个子类别
        public string GetFirstCategory(int categoryid)
        {
            string sql = "select top 1 CategoryId from T_ArticleCategory where ParentCategoryId="+categoryid+" order by Sort asc";
            return SQLHelper.GetSingle(sql).ToString();
        }

        //根据文章类别ID取得类别名称
        public string GetCategoryNameById(int CategoryId)
        {
            string sql = "select Title from T_ArticleCategory where CategoryId=" + CategoryId + "";
            return SQLHelper.GetSingle(sql).ToString();
        }

        //取父类别名称
        public DataSet GetCategoryName()
        {
            string sql = "select * from T_ArticleCategory where Type=0 and CategoryId=131";
            return SQLHelper.Query(sql);
        }
          
        //取得子类别名称
        public DataSet GetCategoryNames(int ParentID)
        {
            string sql = "select * from T_ArticleCategory where Type=0 and ParentCategoryId=" + ParentID + "";
            return SQLHelper.Query(sql);
        }
        //取得新闻
        public DataSet GetNews(string key)
        {
            string sql = "select * from T_News where Title like '%" + key + "%'";
            return SQLHelper.Query(sql);
        }
        //取得文章
        public DataSet GetArticle(string key)
        {
            string sql = "select * from T_Article where  Title like '%" + key + "%'";
            return SQLHelper.Query(sql);
        }
      
        #endregion  成员方法
    }
}
