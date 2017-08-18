using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonUtility.DBUtility;

namespace Modules.Article
{
    public class ArticleDetail
    {
        public int ArticleId;
        public string Title;
        public string Body;
        public int AddedUserId;
        public string PublicationUnit;
        public DateTime AddedDate;
        public DateTime ReleaseDate;
        public DateTime ExpireDate;
        public int CategoryId;
        public int Approved;
        public int ViewCount;
    }
    internal class ArticleDAL
    {
        public DataRow GetArticleRow(int articleId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder query = new StringBuilder();
            query.Append("select * from T_Article a inner join T_ArticleCategory b on a.CategoryId=b.CategoryId");
            query.AppendFormat(" where a.ArticleId={0}", articleId);
            DataSet result = helper.ExecuteDataset(query.ToString());
            if (result.Tables[0].Rows.Count == 1) return result.Tables[0].Rows[0];
            return null;
        }

        public ArticleDetail GetArticleDetail(int articleId)
        {
            DataRow info = this.GetArticleRow(articleId);
            return this.GetArticleDetailFromDataRow(info);
        }

        private ArticleDetail GetArticleDetailFromDataRow(DataRow articleInfo)
        {
            if (articleInfo == null) return null;
            ArticleDetail detail = new ArticleDetail();
            detail.ArticleId = (int)articleInfo["ArticleId"];
            detail.Title = articleInfo["Title"].ToString();
            detail.Body = articleInfo["Body"].ToString();
            detail.PublicationUnit=articleInfo["PublicationUnit"].ToString();
            detail.AddedUserId = (int)articleInfo["AddedUserId"];
            detail.AddedDate = Convert.ToDateTime(articleInfo["AddedDate"]);
            detail.ReleaseDate = Convert.ToDateTime(articleInfo["ReleaseDate"]);
            detail.ExpireDate = Convert.ToDateTime(articleInfo["ExpireDate"]);
            detail.CategoryId = (int)articleInfo["CategoryId"];
            detail.Approved = (int)articleInfo["Approved"];
            detail.ViewCount = (int)articleInfo["ViewCount"];
            return detail;

        }

        public int Add(string title, string body,
                       string unit, DateTime release,
                       DateTime expire,
                       int categoryId, int approved,
                       int viewCount, int addedUserId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            IDataParameter[] paras = new IDataParameter[10];
            paras[0] = helper.GetParameter("@Title", title);
            paras[1] = helper.GetParameter("@Body", body);
            paras[2] = helper.GetParameter("@PublicationUnit", unit);
            paras[3] = helper.GetParameter("@ReleaseDate", release);
            paras[4] = helper.GetParameter("@ExpireDate", expire);
            //paras[5] = helper.GetParameter("@AddedDate", addedDate);
            paras[5] = helper.GetParameter("@CategoryId", categoryId);
            paras[6] = helper.GetParameter("@Approved", approved);
            paras[7] = helper.GetParameter("@ViewCount", viewCount);
            paras[8] = helper.GetParameter("@AddedUserId", addedUserId);
            paras[9] = helper.GetParameter("@ArticleId",DbType.Int32,4,ParameterDirection.Output);
            helper.ExecuteNonQuery("sp_Article_Add", paras);
            return Convert.ToInt32(paras[9].Value);
        }

        public int Add(ArticleDetail detail)
        {
            return this.Add(detail.Title, detail.Body, detail.PublicationUnit,
                            detail.ReleaseDate, detail.ExpireDate,
                            detail.CategoryId, detail.Approved, detail.ViewCount, detail.AddedUserId);
        }

        public bool Update(int articleId, string title, string body,
                           string unit, DateTime release, DateTime expire,
                           int categoryId, int approved, int viewCount)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("update T_Article set Title='{0}',Body='{1}',PublicationUnit='{2}',", title, body, unit);
            sql.AppendFormat("ReleaseDate='{0}',ExpireDate='{1}',CategoryId={2},", release, expire, categoryId);
            sql.AppendFormat("Approved={0},ViewCount={1} where ArticleId={2}", approved,viewCount, articleId);
            return helper.ExecuteNonQuery(sql.ToString()) > 0;
        }

        public bool Update(ArticleDetail detail)
        {
            return this.Update(detail.ArticleId, detail.Title, detail.Body,
                               detail.PublicationUnit, detail.ReleaseDate, detail.ExpireDate,
                               detail.CategoryId, detail.Approved, detail.ViewCount);
        }

        public DataSet GetAllArticleDetailes()
        {
            return GetArticleDetailList(String.Empty, "ArcticleId desc");
        }
        public DataSet GetArticleList(string fields, string filter, string sort, int currentPageIndex, int pageSize, out int recordCount)
        {
            return CommonUtility.PaginationUtility.GetPaginationList(fields, "V_Article", filter, sort, currentPageIndex, pageSize, out recordCount);
        }
        public DataSet GetArticleDetailList(string filter, string sort)
        {
            filter = filter.Trim();
            sort = sort.Trim();
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder sql = new StringBuilder();
            sql.Append("select a.*,b.Title as CategoryTitle,c.Nickname ");
            sql.Append("from T_Article a inner join T_ArticleCategory b on a.CategoryId=b.CategoryId ");
            sql.Append(" inner join T_User c on a.AddedUserId=c.UserId");
            if (filter != String.Empty) sql.AppendFormat(" where {0} ", filter);
            if (sort != String.Empty) sql.AppendFormat(" order by {0}", sort);
            return helper.ExecuteDataset(sql.ToString());
        }
        public bool DeleteArtile(int articleId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string sql = String.Format("delete T_Article where ArticleId={0}", articleId);
            return helper.ExecuteNonQuery(sql) > 0;
        }
        public void ApproveArticle(int articleId, bool isApproved)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string sql = String.Format("update T_Article set Approved={0} where ArticleId={1}", isApproved ? 1 : 0, articleId);
            helper.ExecuteNonQuery(sql);
        }

        public int GetRecordCount(string filter)
        {
            filter=filter.Trim();
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder sql=new StringBuilder();
            sql.Append("select count(*) from T_Article");
            if (filter != String.Empty)
                sql.AppendFormat(" where {0}", filter);
            return Convert.ToInt32(helper.ExecuteScalar(sql.ToString()));
        }
    }
}
