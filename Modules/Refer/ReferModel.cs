using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Refer
{
    public class ReferModel
    {
        public ReferModel()
        { }

        #region ÔÚÏß×ÉÑ¯Model
        private int _opinionid;
        private string _opname;
        private string _optel;
        private string _opemail;
        private string _optitle;
        private string _opcontent;
        private DateTime _filltime;
        private int _optype;
        private string _oppost;
        private string _opaddress;
        /// <summary>
        /// 
        /// </summary>
        public int OpinionID
        {
            set { _opinionid = value; }
            get { return _opinionid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OpName
        {
            set { _opname = value; }
            get { return _opname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OpType
        {
            set { _optype = value; }
            get { return _optype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OpTel
        {
            set { _optel = value; }
            get { return _optel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OpEmail
        {
            set { _opemail = value; }
            get { return _opemail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OpTitle
        {
            set { _optitle = value; }
            get { return _optitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OpContent
        {
            set { _opcontent = value; }
            get { return _opcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime FillTime
        {
            set { _filltime = value; }
            get { return _filltime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OpPost
        {
            set { _oppost = value; }
            get { return _oppost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OpAddress
        {
            set { _opaddress = value; }
            get { return _opaddress; }
        }
        #endregion Model
    }
}
