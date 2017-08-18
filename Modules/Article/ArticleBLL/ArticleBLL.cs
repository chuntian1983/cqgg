using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Modules.Article
{
    public class ArticleBLL
    {
        public ArticleDetail GetArticleDetail(int ArticleId)
        {
            return new ArticleDAL().GetArticleDetail(ArticleId);
        }

        public int Add(ArticleDetail detail)
        {
            ArticleDAL article = new ArticleDAL();

            int categoryId=detail.CategoryId;
            ArticleCategoryDetail categoryDetail = new ArticleCategoryDAL().GetCategoryDetail(categoryId);
            if (categoryDetail.Type == 1)
                return new ArticleDAL().Add(detail);
            else
            {
                int count=article.GetRecordCount(String.Format("CategoryId={0}", categoryId));
                if (count == 0)
                    return new ArticleDAL().Add(detail);
                else return -2;
            }

        }

        public bool Update(ArticleDetail detail)
        {
            return new ArticleDAL().Update(detail);
        }

        public DataSet GetAllArticleDetailes()
        {
            return new ArticleDAL().GetArticleDetailList(String.Empty, "ArticleId desc");
        }
        public DataSet GetArticleDetailList(string filter,string sort)
        {
            return new ArticleDAL().GetArticleDetailList(filter, sort);
        }
        public bool DeleteArticle(int articleId)
        {
            return new ArticleDAL().DeleteArtile(articleId);
        }
        public void ChangeApprovedStatus(int articleId)
        {
            ArticleDAL article = new ArticleDAL();
            int status = article.GetArticleDetail(articleId).Approved;
            if (status == 0) article.ApproveArticle(articleId, true);
            else article.ApproveArticle(articleId, false);
        }
        public DataSet GetArticleList(string fields, string filter, string sort, int currentPageIndex, int pageSize, out int recordCount)
        {
            return new ArticleDAL().GetArticleList(fields, filter, sort, currentPageIndex, pageSize, out recordCount);
        }
    }
}
