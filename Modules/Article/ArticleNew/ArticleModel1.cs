using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// ArticleModel1 的摘要说明
/// </summary>
namespace Modules.Article
{
    public class ArticleModel1
    {
        public ArticleModel1()
        {
        }
        #region 文章Model
        private int _articleid;
        private string _title;
        private string _body;
        private int _addeduserid;
        private string _publicationunit;
        private string _addeddate;
        private string _releasedate;
        private string _expiredate;
        private int _categoryid;
        private int _approved;
        private int _viewcount;
        /// <summary>
        /// 文章标识
        /// </summary>
        public int ArticleId
        {
            set { _articleid = value; }
            get { return _articleid; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 主体
        /// </summary>
        public string Body
        {
            set { _body = value; }
            get { return _body; }
        }
        /// <summary>
        /// 添加人
        /// </summary>
        public int AddedUserId
        {
            set { _addeduserid = value; }
            get { return _addeduserid; }
        }
        /// <summary>
        /// 发布单位
        /// </summary>
        public string PublicationUnit
        {
            set { _publicationunit = value; }
            get { return _publicationunit; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public string AddedDate
        {
            set { _addeddate = value; }
            get { return _addeddate; }
        }
        /// <summary>
        /// 发布时间
        /// </summary>
        public string ReleaseDate
        {
            set { _releasedate = value; }
            get { return _releasedate; }
        }
        /// <summary>
        /// 时效时间
        /// </summary>
        public string ExpireDate
        {
            set { _expiredate = value; }
            get { return _expiredate; }
        }
        /// <summary>
        /// 目录标识
        /// </summary>
        public int CategoryId
        {
            set { _categoryid = value; }
            get { return _categoryid; }
        }
        /// <summary>
        /// 审核 0：未审核 1：审核通过 2：审核未通过
        /// </summary>
        public int Approved
        {
            set { _approved = value; }
            get { return _approved; }
        }
        /// <summary>
        /// 点击数
        /// </summary>
        public int ViewCount
        {
            set { _viewcount = value; }
            get { return _viewcount; }
        }
        #endregion Model
    }
}