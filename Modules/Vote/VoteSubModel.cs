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
        /// ͶƱ�����ID ��VoteType���е�VoteID����
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// ͶƱ����
        /// </summary>
        public string Vote
        {
            set { _vote = value; }
            get { return _vote; }
        }
        /// <summary>
        /// �����ʱ��
        /// </summary>
        public DateTime FillTime
        {
            set { _filltime = value; }
            get { return _filltime; }
        }
        /// <summary>
        /// �Ƿ��Ƽ�
        /// </summary>
        public int Vouch
        {
            set { _vouch = value; }
            get { return _vouch; }
        }
        #endregion Model

    }
   
}
