using System;
using System.Collections.Generic;
using System.Text;
using CommonUtility.DBUtility;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

/// <summary>
/// NewsDAL 的摘要说明
/// </summary>
namespace Modules.News
{
    public class NewsDAL1
    {
        AdoHelper help = AdoHelper.CreateHelper();
        public NewsDAL1()
        {
        }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int NewsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_News");
            strSql.Append(" where NewsID= @NewsID");
             MySqlParameter[] parameters = {
					new MySqlParameter("@NewsID",DbType.Int32)
				};
            parameters[0].Value = NewsID;
            return help.ExecuteNonQuery(strSql.ToString(), parameters)>0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(NewsModel1 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_News(");
            strSql.Append("Title,Body,AddedUserId,PublicationUnit,AddedDate,ReleaseDate,ExpireDate,CategoryId,Approved,ViewCount,ImgLink,IsState)");
            strSql.Append(" values (");
            strSql.Append("@Title,@Body,@AddedUserId,@PublicationUnit,@AddedDate,@ReleaseDate,@ExpireDate,@CategoryId,@Approved,@ViewCount,@ImgLink,@IsState)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@Title",model.Title),
					new MySqlParameter("@Body", model.Body),
					new MySqlParameter("@AddedUserId",model.AddedUserId),
					new MySqlParameter("@PublicationUnit", model.PublicationUnit),
					new MySqlParameter("@AddedDate", model.AddedDate),
					new MySqlParameter("@ReleaseDate", model.ReleaseDate),
					new MySqlParameter("@ExpireDate", model.ExpireDate),
					new MySqlParameter("@CategoryId", model.CategoryId),
					new MySqlParameter("@Approved", model.Approved),
					new MySqlParameter("@ViewCount", model.ViewCount),
					new MySqlParameter("@ImgLink", model.ImgLink),
					new MySqlParameter("@IsState",  model.IsState)};

            help.ExecuteNonQuery(help.connectionString,CommandType.Text,strSql,parameters);
            
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(NewsModel1 model)
        {
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("update T_News set ");
            //strSql.Append("Title=@Title,");
            //strSql.Append("Body=@Body,");
            //strSql.Append("AddedUserId=@AddedUserId,");
            //strSql.Append("PublicationUnit=@PublicationUnit,");
            //strSql.Append("AddedDate=@AddedDate,");
            //strSql.Append("ReleaseDate=@ReleaseDate,");
            //strSql.Append("ExpireDate=@ExpireDate,");
            //strSql.Append("CategoryId=@CategoryId,");
            //strSql.Append("Approved=@Approved,");
            //strSql.Append("ViewCount=@ViewCount,");
            //strSql.Append("ImgLink=@ImgLink,");
            //strSql.Append("IsState=@IsState");
            //strSql.Append(" where NewsID=@NewsID");
            //MySqlParameter[] parameters = {
            //        new MySqlParameter("@NewsID", SqlDbType.Int,4),
            //        new MySqlParameter("@Title", SqlDbType.VarChar,100),
            //        new MySqlParameter("@Body", SqlDbType.Text),
            //        new MySqlParameter("@AddedUserId", SqlDbType.Int,4),
            //        new MySqlParameter("@PublicationUnit", SqlDbType.VarChar,50),
            //        new MySqlParameter("@AddedDate", SqlDbType.DateTime),
            //        new MySqlParameter("@ReleaseDate", SqlDbType.DateTime),
            //        new MySqlParameter("@ExpireDate", SqlDbType.DateTime),
            //        new MySqlParameter("@CategoryId", SqlDbType.Int,4),
            //        new MySqlParameter("@Approved", SqlDbType.Int,4),
            //        new MySqlParameter("@ViewCount", SqlDbType.Int,4),
            //        new MySqlParameter("@ImgLink", SqlDbType.VarChar,50),
            //        new MySqlParameter("@IsState", SqlDbType.Int,4)};
            //parameters[0].Value = model.NewsID;
            //parameters[1].Value = model.Title;
            //parameters[2].Value = model.Body;
            //parameters[3].Value = model.AddedUserId;
            //parameters[4].Value = model.PublicationUnit;
            //parameters[5].Value = model.AddedDate;
            //parameters[6].Value = model.ReleaseDate;
            //parameters[7].Value = model.ExpireDate;
            //parameters[8].Value = model.CategoryId;
            //parameters[9].Value = model.Approved;
            //parameters[10].Value = model.ViewCount;
            //parameters[11].Value = model.ImgLink;
            //parameters[12].Value = model.IsState;

            //SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int NewsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete T_News ");
            strSql.Append(" where NewsID=@NewsID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@NewsID",NewsID)
				};
            help.ExecuteNonQuery(help.connectionString,CommandType.Text,strSql.ToString(),parameters);
            //SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public NewsModel1 GetModel(int NewsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_News ");
            strSql.Append(" where NewsID=@NewsID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@NewsID",MySqlDbType.Int32)};
            parameters[0].Value = NewsID;
            NewsModel1 model = new NewsModel1();
            DataSet ds =help.ExecuteDataset(help.connectionString,CommandType.Text, strSql.ToString(), parameters);
            model.NewsID = NewsID;
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
                    model.AddedDate = ds.Tables[0].Rows[0]["AddedDate"].ToString();
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
            strSql.Append("select * from T_News ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ReleaseDate desc ");
            return SQLHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据文章或新闻类别的编号取得类别名称
        /// </summary>
        public string GetCategoryName(int CategoryId)
        {
            string sql = "select Title from T_ArticleCategory where CategoryId=" + CategoryId + "";
            return help.ExecuteScalar(sql).ToString();
        }

        //根据新闻编号取得新闻的类别编号
        public string GetCategoryID(int NewsId)
        {
            string sql = "select CategoryId from T_News where NewsId=" + NewsId + "";
            return help.ExecuteScalar(sql).ToString();
        }

        //取得新闻 前N条
        public DataSet GetNewsList(string  CategoryName, int Num)
        {
            string sql = "select top " + Num + " a.*,b.Title as Title1 from T_News a left join T_ArticleCategory b on a.CategoryId=b.CategoryId where b.Title='" + CategoryName + "' and a.Approved=1 and ReleaseDate<=getdate() order by ReleaseDate desc";
            return SQLHelper.Query(sql);
        }

        //根据新闻编号取得新闻
        public DataSet GetNews(int id)
        {
            string sql = "select * from T_News where NewsId ="+id+"";
            return SQLHelper.Query(sql);
        }
        
        //判断是否有本院新闻记录
        public bool CheckNews()
        {
            string sql = "select count(*) from T_News where CategoryId=104";
            int result = Convert.ToInt32(SQLHelper.GetSingle(sql).ToString());
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //更改首页显示的本院新闻图片的显示状态
        public int UpdateState()
        {
            string sql = "update T_News set IsState=0 where CategoryId=104 and IsState=1";
           return SQLHelper.ExecuteSql(sql);
        }


        //显示首页新闻的数据（图片）
        public DataSet GetIndexPic()
        {
            string sql = "select * from T_News where CategoryId=104 and IsState=1 and Approved=1";
            return SQLHelper.Query(sql);
        }

        //判断传入的类别编号是一级还是二级
        public string CheckType(int id)
        {
            string sql = "select count(*) from T_ArticleCategory as a inner join T_ArticleCategory as b on a.ParentCategoryId=b.CategoryId where b.ParentCategoryId=131 and a.CategoryId="+id+"";
            string result = SQLHelper.GetSingle(sql).ToString();
             if (result == "0")//表示
            {
                string sql1 = "select count(*) from T_ArticleCategory as a inner join T_ArticleCategory as b on a.ParentCategoryId=b.CategoryId where b.ParentCategoryId="+id+"";
                int result1 = Int32.Parse(SQLHelper.GetSingle(sql1).ToString());
                if (result1 > 0)
                {
                    return "1";//表示该类别是1级类别
                }
                else
                {
                    return "3";//表示该类别是3级类别(也有可能是四级类别,因为是左边菜单调用,只可能显示三级)
                }
            }
            else
            {
                return "2";
            }
                
        }

       //更新点击率
        public void UpdateViewCount(int NewsID)
        {
            string sql = "Update T_News set ViewCount=ViewCount+15 where NewsId=" + NewsID + "";
            AdoHelper help = AdoHelper.CreateHelper();
            help.ExecuteNonQuery(sql);
            
        }

        //取得一级类别下的二级类别的第一个
        public string GetFirstID()
        {
            string sql = "select top 1 CategoryId from T_ArticleCategory where ParentCategoryId=0 order by CategoryId asc";
            return SQLHelper.GetSingle(sql).ToString();
        }

        //取得二级类别下的三级类的中第一个类别
        public string GetFirstID1(int pid)
        {
            string sql = "select top 1 CategoryId from T_ArticleCategory where ParentCategoryId="+pid+" order by CategoryId asc";
            return SQLHelper.GetSingle(sql).ToString();
        }


        //根据传入的子类别编号取得该子类别所属的父类别编号
        public string GetParentTypeBySonType(string sid)
        {
            string sql = "select ParentCategoryId from T_ArticleCategory where CategoryId='"+sid+"'";
            return SQLHelper.GetSingle(sql).ToString();
        }

        //查看所有父类别(医学科研)　
        public DataSet GetAllType()
        {
            string sql = "select * from T_ArticleCategory where ParentCategoryId=131 order by CategoryId asc ";
            return SQLHelper.Query(sql);
        }



        //------------------------------------------------------------------

        //根据传入的类别编号先判断是不是二级类别
        public bool CheckFirst(int id)
        {
            string sql = "select count(*) from T_ArticleCategory where ParentCategoryId=131 and CategoryId="+id+"";
            string result = SQLHelper.GetSingle(sql).ToString();
            if (result == "0")
            {
                return false;//说明它不是二级类别
            }
            else
            { 
                return true;//说明它是二级类别
            }
        }

        //判断传入的类别的下面是否有子类别
        public bool CheckSNum(int pid)
        {
            string sql = "select count(*) from T_ArticleCategory where ParentCategoryId=" + pid + "";
            string result = SQLHelper.GetSingle(sql).ToString();
            if (result == "0")
            {
                return false;//无子类别
            }
            else
                return true;//有子类别
        }


        //根据传入的父类别编号取得该父类别下的所有子类别信息
        public DataSet Subtype(int pid)
        {
            string sql = "select * from T_ArticleCategory where ParentCategoryId=" + pid + " order by Sort asc";
            return SQLHelper.Query(sql);
        }

        //根据二级类别编号取三级类别列表(第一条)
        //根据三级类别编号取四级类别列表(第一条)
        public DataSet GetThird(int CategoryId)
        {
            string sql = "select top 1 * from T_ArticleCategory where ParentCategoryId=" + CategoryId + " order by Sort asc";
            return SQLHelper.Query(sql);
        }

        #endregion  成员方法
    }
}
