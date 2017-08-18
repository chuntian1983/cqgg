using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Member
{
    public class MemberModel
    {
        public MemberModel()
        { }
        #region 会员Model
        private int _memberid;
        private string _nickname;
        private string _password;
        private string _realname;
        private string _province;
        private string _city;
        private string _address;
        private string _postalcode;
        private string _tel;
        private string _email;
        private string _remark;
        private int _registertype;
        private DateTime _addeddate;
        private int _approved;
        /// <summary>
        /// 
        /// </summary>
        public int MemberId
        {
            set { _memberid = value; }
            get { return _memberid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Nickname
        {
            set { _nickname = value; }
            get { return _nickname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Realname
        {
            set { _realname = value; }
            get { return _realname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Province
        {
            set { _province = value; }
            get { return _province; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string City
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Postalcode
        {
            set { _postalcode = value; }
            get { return _postalcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 会员类型0:个人会员1:企业会员
        /// </summary>
        public int RegisterType
        {
            set { _registertype = value; }
            get { return _registertype; }
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
        public int Approved
        {
            set { _approved = value; }
            get { return _approved; }
        }
        #endregion Model
    }
}
