using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Link
{
    public class LinkModel1
    {
        public LinkModel1()
        { }
        #region Model
        private int _linkid;
        private string _title;
        private string _link;
        private string _image;
        private int _displaymode;
        private int _sort;
        /// <summary>
        /// 
        /// </summary>
        public int LinkId
        {
            set { _linkid = value; }
            get { return _linkid; }
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
        public string Link
        {
            set { _link = value; }
            get { return _link; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Image
        {
            set { _image = value; }
            get { return _image; }
        }
        /// <summary>
        /// 显示方式  0:图片 1:文字
        /// </summary>
        public int DisplayMode
        {
            set { _displaymode = value; }
            get { return _displaymode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        #endregion Model
    }
}
