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
        /// 广告编号
        /// </summary>
        public int ADId
        {
            set { _adid = value; }
            get { return _adid; }
        }
        /// <summary>
        /// 广告名称
        /// </summary>
        public string ADName
        {
            set { _adname = value; }
            get { return _adname; }
        }
        /// <summary>
        /// 广告图片
        /// </summary>
        public string ADPic
        {
            set { _adpic = value; }
            get { return _adpic; }
        }
        /// <summary>
        /// 链接地址
        /// </summary>
        public string Link
        {
            set { _link = value; }
            get { return _link; }
        }
        /// <summary>
        /// 排序号
        /// </summary>
        public int Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Plus
        {
            set { _plus = value; }
            get { return _plus; }
        }
        /// <summary>
        /// 广告类型
        /// </summary>
        public int Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 广告位置
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 审核状态
        /// </summary>
        public int Approved
        {
            set { _approved = value; }
            get { return _approved; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime FillTime
        {
            set { _filltime = value; }
            get { return _filltime; }
        }
        #endregion Model
    }
}
