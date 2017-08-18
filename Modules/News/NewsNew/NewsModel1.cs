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
namespace Modules.News
{
    public class NewsModel1
    {
        public NewsModel1()
        {
        }
        #region 新闻Model
        private int _newsid;
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
        private string _imglink;
        private int _isstate;
        /// <summary>
        /// 
        /// </summary>
        public int NewsID
        {
            set { _newsid = value; }
            get { return _newsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Body
        {
            set { _body = value; }
            get { return _body; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AddedUserId
        {
            set { _addeduserid = value; }
            get { return _addeduserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PublicationUnit
        {
            set { _publicationunit = value; }
            get { return _publicationunit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AddedDate
        {
            set { _addeddate = value; }
            get { return _addeddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ReleaseDate
        {
            set { _releasedate = value; }
            get { return _releasedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ExpireDate
        {
            set { _expiredate = value; }
            get { return _expiredate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int CategoryId
        {
            set { _categoryid = value; }
            get { return _categoryid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Approved
        {
            set { _approved = value; }
            get { return _approved; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ViewCount
        {
            set { _viewcount = value; }
            get { return _viewcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ImgLink
        {
            set { _imglink = value; }
            get { return _imglink; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsState
        {
            set { _isstate = value; }
            get { return _isstate; }
        }
        #endregion Model
    }
}