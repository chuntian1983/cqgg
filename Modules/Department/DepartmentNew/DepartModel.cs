using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Department
{
    public class DepartModel
    {
        public DepartModel()
        { }
        #region Model
        private int _departid;
        private string _title;
        private string _body;
        private int _addeduserid;
        private DateTime _addeddate;
        private int _categoryid;
        private int _approved;
        private int _viewcount;
        private string _imglink;
        private int _isstate;
        /// <summary>
        /// 部门信息表
        /// </summary>
        public int DepartId
        {
            set { _departid = value; }
            get { return _departid; }
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
        public DateTime AddedDate
        {
            set { _addeddate = value; }
            get { return _addeddate; }
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
