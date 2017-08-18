using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonUtility.DBUtility;
using MySql.Data.MySqlClient;

namespace Modules.News
{
    public class NewsDetail
    {
        public int NewsId;
        public string Title;
        public string Body;
        public int AddedUserId;
        public string PublicationUnit;
        public string AddedDate;
        public string ReleaseDate;
        public string ExpireDate;
        public int CategoryId;
        public int Approved;
        public int ViewCount;
        public string ImgLink;//用于放医疗服务价格信息//存部门id
        public int IsState;//首页图片状态
    }
    internal class NewsDAL
    {
        public DataRow GetArticleRow(int newsId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder query = new StringBuilder();
            query.Append("select * from T_News a inner join T_ArticleCategory b on a.CategoryId=b.CategoryId");
            query.AppendFormat(" where a.NewsId={0}", newsId);
            DataSet result = helper.ExecuteDataset(query.ToString());
            if (result.Tables[0].Rows.Count == 1) return result.Tables[0].Rows[0];
            return null;
        }
        /// <summary>
        /// 村统计得分
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        public int Getrowscount(int deptid,string startime,string endtime)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder query = new StringBuilder();
            query.Append("select count(*) from T_News where addeddate>='" + startime + "' and addeddate<='" + endtime + "' and CategoryId in(241,242,243,244) and imglink='"+deptid+"'");

            return int.Parse(helper.ExecuteScalar(query.ToString()).ToString());
        }
        /// <summary>
        /// 根据类列取信息
        /// </summary>
        /// <param name="lbid">ex:240,250,260</param>
        /// <returns></returns>
        public DataTable GetListbylbid(int deptid, string lbid)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder query = new StringBuilder();
            query.Append("select *,b.title as lbtitle from T_News a ,T_ArticleCategory b where a.CategoryId=b.CategoryId and   a.CategoryId in(" + lbid + ") and a.imglink='" + deptid + "'");

            return helper.ExecuteDataset(query.ToString()).Tables[0];
        }
        /// <summary>
        /// 获取新闻信息
        /// </summary>
        /// <param name="strwhere"></param>
        /// <returns></returns>
        public DataTable GetListnews(string strwhere)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder query = new StringBuilder();
            query.Append("select * from V_News ");
            if (!string.IsNullOrEmpty(strwhere))
            {
                query.Append(" where "+strwhere+"");
            }
            query.Append(" order by releasedate desc");
            return helper.ExecuteDataset(query.ToString()).Tables[0];
        }
        public NewsDetail GetArticleDetail(int newsId)
        {
            DataRow info = this.GetArticleRow(newsId);
            return this.GetArticleDetailFromDataRow(info);
        }

        private NewsDetail GetArticleDetailFromDataRow(DataRow articleInfo)
        {
            if (articleInfo == null) return null;
            NewsDetail detail = new NewsDetail();
            detail.NewsId = (int)articleInfo["NewsId"];
            detail.Title = articleInfo["Title"].ToString();
            detail.Body = articleInfo["Body"].ToString();
            detail.PublicationUnit=articleInfo["PublicationUnit"].ToString();
            detail.AddedUserId = (int)articleInfo["AddedUserId"];
            detail.AddedDate =articleInfo["AddedDate"].ToString();
            detail.ReleaseDate = articleInfo["ReleaseDate"].ToString();
            detail.ExpireDate = articleInfo["ExpireDate"].ToString();
            detail.CategoryId = (int)articleInfo["CategoryId"];
            detail.Approved = (int)articleInfo["Approved"];
            detail.ViewCount = (int)articleInfo["ViewCount"];
            detail.ImgLink = articleInfo["ImgLink"].ToString();
            detail.IsState = (int)articleInfo["IsState"];
            return detail;

        }

        public int Add(string title, string body,
                       string unit, string release,
                       string expire,
                       int categoryId, int approved,
                       int viewCount, int addedUserId, string imgLink, int IsState)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            IDataParameter[] paras = new IDataParameter[12];
            paras[0] = helper.GetParameter("@Title", title);
            paras[1] = helper.GetParameter("@Body", body);
            paras[2] = helper.GetParameter("@PublicationUnit", unit);
            paras[3] = helper.GetParameter("@ReleaseDate", release);
            paras[4] = helper.GetParameter("@ExpireDate", expire);
            paras[5] = helper.GetParameter("@CategoryId", categoryId);
            paras[6] = helper.GetParameter("@Approved", approved);
            paras[7] = helper.GetParameter("@ViewCount", viewCount);
            paras[8] = helper.GetParameter("@AddedUserId", addedUserId);
            paras[9] = helper.GetParameter("@ImgLink", imgLink);
            paras[10] = helper.GetParameter("@NewsId",DbType.Int32,4,ParameterDirection.Output);
            paras[11] = helper.GetParameter("@IsState", IsState);
            string strsql = @"insert into T_News (Title,Body,PublicationUnit,ReleaseDate,ExpireDate,CategoryId,Approved,ViewCount,AddedUserId,ImgLink,IsState)
values (@Title,@Body,@PublicationUnit,@ReleaseDate,@ExpireDate,@CategoryId,@Approved,@ViewCount,@AddedUserId,@ImgLink,@IsState)";
            helper.ExecuteNonQuery(helper.connectionString, CommandType.Text, strsql, paras);
           // helper.ExecuteNonQuery("sp_News_Add", paras);
            return Convert.ToInt32(paras[10].Value);
        }

        public int Add(NewsDetail detail)
        {
            return this.Add(detail.Title, detail.Body, detail.PublicationUnit,
                            detail.ReleaseDate, detail.ExpireDate,
                            detail.CategoryId, detail.Approved, detail.ViewCount, detail.AddedUserId, detail.ImgLink, detail.IsState);
        }

        public bool Update(int newsId, string title, string body,
                           string unit, string release, string expire,
                           int categoryId, int approved, int viewCount,string imgLink,int isState)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder sql = new StringBuilder();
            IDataParameter[] paras = new IDataParameter[11];
            paras[0] = helper.GetParameter("@Title", title);
            paras[1] = helper.GetParameter("@Body", body);
            paras[2] = helper.GetParameter("@PublicationUnit", unit);
            paras[3] = helper.GetParameter("@ReleaseDate", release);
            paras[4] = helper.GetParameter("@ExpireDate", expire);
            paras[5] = helper.GetParameter("@CategoryId", categoryId);
            paras[6] = helper.GetParameter("@Approved", approved);
            paras[7] = helper.GetParameter("@ViewCount", viewCount);
            paras[8] = helper.GetParameter("@ImgLink", imgLink);
            paras[9] = helper.GetParameter("@IsState", isState);
            paras[10] = helper.GetParameter("@NewsId", newsId);
            sql.Append("update T_News set Title=@Title,Body=@Body,PublicationUnit=@PublicationUnit,");
            sql.Append("ReleaseDate=@ReleaseDate,ExpireDate=@ExpireDate,CategoryId=@CategoryId,");
            sql.Append("ImgLink=@ImgLink,IsState=@IsState,");
            sql.Append("Approved=@Approved,ViewCount=@ViewCount where NewsId=@NewsId");
            return helper.ExecuteNonQuery(helper.connectionString,CommandType.Text, sql.ToString(),paras) > 0;
        }
       
        public bool Update(NewsDetail detail)
        {
            return this.Update(detail.NewsId, detail.Title, detail.Body,
                               detail.PublicationUnit, detail.ReleaseDate, detail.ExpireDate,
                               detail.CategoryId, detail.Approved, detail.ViewCount,detail.ImgLink,detail.IsState);
        }

        public DataSet GetAllArticleDetailes()
        {
            return GetArticleDetailList(String.Empty, "NewsId desc");
        }
        public DataSet GetArticleList(string fields, string filter, string sort, int currentPageIndex, int pageSize, out int recordCount)
        {
            return CommonUtility.PaginationUtility.GetPaginationList(fields, "V_News", filter, sort, currentPageIndex, pageSize, out recordCount);
        }
        public DataSet GetArticleDetailList(string filter, string sort)
        {
            filter = filter.Trim();
            sort = sort.Trim();
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder sql = new StringBuilder();
            sql.Append("select a.*,b.Title as CategoryTitle,c.Nickname ");
            sql.Append("from T_News a inner join T_ArticleCategory b on a.CategoryId=b.CategoryId ");
            sql.Append(" inner join T_User c on a.AddedUserId=c.UserId");
            if (filter != String.Empty) sql.AppendFormat(" where {0} ", filter);
            if (sort != String.Empty) sql.AppendFormat(" order by {0}", sort);
            return helper.ExecuteDataset(sql.ToString());
        }
        public bool DeleteArtile(int newsId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string sql = String.Format("delete from T_News where NewsId={0}", newsId);
            return helper.ExecuteNonQuery(sql) > 0;
        }
        public void ApproveArticle(int newsId, bool isApproved)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string sql = String.Format("update T_News set Approved={0} where NewsId={1}", isApproved ? 1 : 0, newsId);
            helper.ExecuteNonQuery(sql);
        }

        public int GetRecordCount(string filter)
        {
            filter=filter.Trim();
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder sql=new StringBuilder();
            sql.Append("select count(*) from T_News");
            if (filter != String.Empty)
                sql.AppendFormat(" where {0}", filter);
            return Convert.ToInt32(helper.ExecuteScalar(sql.ToString()));
        }
        /// <summary>
        /// 根据新闻类别获取信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tops"></param>
        /// <returns></returns>
        public DataSet GetALLlist(string id,int tops)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string strsql = "SELECT * from t_news where Approved='1' and CategoryId=" + id + " order by ReleaseDate desc LIMIT " + tops + "";
            //string strsql = "select top " + tops + " * from t_news where Approved='1' and CategoryId=" + id + "";
            DataSet ds = helper.ExecuteDataset(strsql);
            return ds;
        }
        /// <summary>
        /// 根据新闻类别获取信息(部门信息id)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tops"></param>
        /// <returns></returns>
        public DataSet GetALLlist(string id, int tops,string deptid)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string strsql = "select  * from t_news where Approved='1' and CategoryId in(" + id + ") ";
            //string strsql = "select top " + tops + " * from t_news where Approved='1' and CategoryId in(" + id + ") ";
            if (!string.IsNullOrEmpty(deptid))
            {
                strsql += " and imglink='"+deptid+"'";
            }
            strsql += " order by ReleaseDate desc LIMIT " + tops + "";
            DataSet ds = helper.ExecuteDataset(strsql);
            return ds;
        }
    }
}
