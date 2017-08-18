using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.T_BMFW.Model
{
    /// <summary>
    /// T_BMFW:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class T_BMFW
    {
        public T_BMFW()
        { }
        #region Model
        private int _id;
        private int _cunid;
        private string _imgurl;
        private string _state;
        private string _bz;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 村级id
        /// </summary>
        public int cunid
        {
            set { _cunid = value; }
            get { return _cunid; }
        }
        /// <summary>
        /// 上传图片的url
        /// </summary>
        public string imgurl
        {
            set { _imgurl = value; }
            get { return _imgurl; }
        }
        /// <summary>
        /// 是否有点的标识
        /// </summary>
        public string state
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string bz
        {
            set { _bz = value; }
            get { return _bz; }
        }
        #endregion Model

    }
}
