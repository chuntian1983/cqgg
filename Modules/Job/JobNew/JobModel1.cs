using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Job
{
    public class JobModel1
    {
        public JobModel1()
        { }
        #region Model
        private int _postid;
        private string _description;
        private string _personnum;
        private int _sex;
        private string _age;
        private string _diploma;
        private int _workmode;
        private int _isthisyear;
        private string _workage;
        private string _otherrequests;
        private DateTime _releasedate;
        private DateTime _expiredate;
        private DateTime _addeddate;
        private int _addeduserid;
        private int _departmentid;
        private int _viewcount;
        private string _workplace;
        private string _connecttel;
        private int _approved;
        /// <summary>
        /// 
        /// </summary>
        public int PostId
        {
            set { _postid = value; }
            get { return _postid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PersonNum
        {
            set { _personnum = value; }
            get { return _personnum; }
        }
        /// <summary>
        /// 0女 1男 2不限
        /// </summary>
        public int Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Age
        {
            set { _age = value; }
            get { return _age; }
        }
        /// <summary>
        /// 学历
        /// </summary>
        public string Diploma
        {
            set { _diploma = value; }
            get { return _diploma; }
        }
        /// <summary>
        /// 工作方式 1全职 或者 0兼职
        /// </summary>
        public int WorkMode
        {
            set { _workmode = value; }
            get { return _workmode; }
        }
        /// <summary>
        /// 是否应届 1应届 0往届
        /// </summary>
        public int IsThisYear
        {
            set { _isthisyear = value; }
            get { return _isthisyear; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WorkAge
        {
            set { _workage = value; }
            get { return _workage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OtherRequests
        {
            set { _otherrequests = value; }
            get { return _otherrequests; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ReleaseDate
        {
            set { _releasedate = value; }
            get { return _releasedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ExpireDate
        {
            set { _expiredate = value; }
            get { return _expiredate; }
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
        public int AddedUserId
        {
            set { _addeduserid = value; }
            get { return _addeduserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int DepartmentId
        {
            set { _departmentid = value; }
            get { return _departmentid; }
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
        public string WorkPlace
        {
            set { _workplace = value; }
            get { return _workplace; }
        }

        /// <summary>
        /// 联系方式
        /// </summary>
        public string ConnectTel
        {
            set { _connecttel = value; }
            get { return _connecttel; }
        }

        /// <summary>
        /// 审核状态
        /// </summary>
        public int Approved
        {
            set { _approved = value; }
            get { return _approved; }
        }
        #endregion Model
    }

}
