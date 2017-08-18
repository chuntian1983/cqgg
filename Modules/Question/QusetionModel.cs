using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Question
{
    public class QusetionModel
    {
        public QusetionModel()
        {}
       
        #region  网上挂号，在线咨询Model
        private int _id;
        private string _name;
        private string _age;
        private int _sex;
        private string _pid;
        private string _tel;
        private DateTime _looktime;
        private string _info;
        private int _state;
        private DateTime _adddate;
        private string _registid;
        private string _email;
        private string _title;
        private int _type;
        private string _history;
        /// <summary>
        /// 挂号信息表 0,电子函诊表 1
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
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
        /// 0:男 1:女
        /// </summary>
        public int Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string Pid
        {
            set { _pid = value; }
            get { return _pid; }
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
        public DateTime LookTime
        {
            set { _looktime = value; }
            get { return _looktime; }
        }
        /// <summary>
        /// 简要病情
        /// </summary>
        public string Info
        {
            set { _info = value; }
            get { return _info; }
        }
        /// <summary>
        /// 审核状态 0:未审核 1:已审核
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        /// <summary>
        /// 挂号单号码 用于查询
        /// </summary>
        public string RegistID
        {
            set { _registid = value; }
            get { return _registid; }
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
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 表的类型 0:挂号 1:函诊
        /// </summary>
        public int Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 病史
        /// </summary>
        public string History
        {
            set { _history = value; }
            get { return _history; }
        }
        #endregion Model

    }
}
