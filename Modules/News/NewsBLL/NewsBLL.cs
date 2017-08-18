using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Modules.News
{
    public class NewsBLL
    {
        public NewsDetail GetArticleDetail(int ArticleId)
        {
            return new NewsDAL().GetArticleDetail(ArticleId);
        }
        /// <summary>
        /// 根据新闻类别获取信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tops"></param>
        /// <returns></returns>
        public DataSet GetALLlist(string id, int tops)
        {
            return new NewsDAL().GetALLlist(id, tops);
        }
         /// <summary>
        /// 根据新闻类别获取信息(部门信息id)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tops"></param>
        /// <returns></returns>
        public DataSet GetALLlist(string id, int tops, string deptid)
        {
            return new NewsDAL().GetALLlist(id, tops, deptid);
        }
        /// <summary>
        /// 根据类列取信息
        /// </summary>
        /// <param name="lbid">ex:240,250,260</param>
        /// <returns></returns>
        public DataTable GetListbylbid(int deptid, string lbid)
        {
            return new NewsDAL().GetListbylbid(deptid, lbid);
        }
        /// <summary>
        /// 获取新闻信息
        /// </summary>
        /// <param name="strwhere"></param>
        /// <returns></returns>
        public DataTable GetListnews(string strwhere)
        { return new NewsDAL().GetListnews(strwhere); }
        /// <summary>
        /// 村统计得分
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        public int Getrowscount(int deptid, string startime, string endtime)
        {
            return new NewsDAL().Getrowscount(deptid, startime, endtime);
        }
        public int Add(NewsDetail detail)
        {
            NewsDAL article = new NewsDAL();

            int categoryId=detail.CategoryId;
            NewsCategoryDetail categoryDetail = new NewsCategoryDAL().GetCategoryDetail(categoryId);
            if (categoryDetail.Type == 1)
                return new NewsDAL().Add(detail);
            else
            {
                int count=article.GetRecordCount(String.Format("CategoryId={0}", categoryId));
                if (count == 0)
                    return new NewsDAL().Add(detail);
                else return -2;
            }

        }

        public bool Update(NewsDetail detail)
        {
            return new NewsDAL().Update(detail);
        }

        public DataSet GetAllArticleDetailes()
        {
            return new NewsDAL().GetArticleDetailList(String.Empty, "ArticleId desc");
        }
        public DataSet GetArticleDetailList(string filter,string sort)
        {
            return new NewsDAL().GetArticleDetailList(filter, sort);
        }
        public bool DeleteArticle(int articleId)
        {
            return new NewsDAL().DeleteArtile(articleId);
        }
        public void ChangeApprovedStatus(int articleId)
        {
            NewsDAL article = new NewsDAL();
            int status = article.GetArticleDetail(articleId).Approved;
            if (status == 0) article.ApproveArticle(articleId, true);
            else article.ApproveArticle(articleId, false);
        }
        public DataSet GetArticleList(string fields, string filter, string sort, int currentPageIndex, int pageSize, out int recordCount)
        {
            return new NewsDAL().GetArticleList(fields, filter, sort, currentPageIndex, pageSize, out recordCount);
        }
    }
}
