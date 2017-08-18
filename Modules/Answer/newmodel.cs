using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Answer
{
    /// <summary>
    /// T_Answer:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class T_Answer
    {
        public T_Answer()
        { }
        #region Model
        private int _answerid;
        private int _questionid;
        private string _content;
        private string _name = "1";
        private string _business;
        private DateTime? _adddate = DateTime.Now;
        private string _title;
        private int? _state = 0;
        /// <summary>
        /// 
        /// </summary>
        public int AnswerId
        {
            set { _answerid = value; }
            get { return _answerid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int QuestionId
        {
            set { _questionid = value; }
            get { return _questionid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
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
        public string Business
        {
            set { _business = value; }
            get { return _business; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
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
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }
        #endregion Model

    }
}
