using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Advertisement
{
    public class AdvertisementModel
    {
        public AdvertisementModel()
        { }
        #region Model
        private int _adid;
        private string _adname;
        private string _adpic;
        private string _link;
        private int _sort;
        private string _plus;
        private int _type;
        private int _state;
        private int _approved;
        private DateTime _filltime;
        /// <summary>
        /// �����
        /// </summary>
        public int ADId
        {
            set { _adid = value; }
            get { return _adid; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public string ADName
        {
            set { _adname = value; }
            get { return _adname; }
        }
        /// <summary>
        /// ���ͼƬ
        /// </summary>
        public string ADPic
        {
            set { _adpic = value; }
            get { return _adpic; }
        }
        /// <summary>
        /// ���ӵ�ַ
        /// </summary>
        public string Link
        {
            set { _link = value; }
            get { return _link; }
        }
        /// <summary>
        /// �����
        /// </summary>
        public int Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// ��ע
        /// </summary>
        public string Plus
        {
            set { _plus = value; }
            get { return _plus; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public int Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// ���λ��
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// ���״̬
        /// </summary>
        public int Approved
        {
            set { _approved = value; }
            get { return _approved; }
        }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime FillTime
        {
            set { _filltime = value; }
            get { return _filltime; }
        }
        #endregion Model
    }
}
