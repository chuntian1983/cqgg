using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Vote
{
    public class VoteSubModel
    {
        public VoteSubModel()
        {}
        #region Model
        private int _id;
        private string _vote;
        private DateTime _filltime;
        private int _vouch;
        /// <summary>
        /// 投票主题表ID 和VoteType表中的VoteID关联
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 投票主题
        /// </summary>
        public string Vote
        {
            set { _vote = value; }
            get { return _vote; }
        }
        /// <summary>
        /// 输入的时间
        /// </summary>
        public DateTime FillTime
        {
            set { _filltime = value; }
            get { return _filltime; }
        }
        /// <summary>
        /// 是否推荐
        /// </summary>
        public int Vouch
        {
            set { _vouch = value; }
            get { return _vouch; }
        }
        #endregion Model

    }
   
}
