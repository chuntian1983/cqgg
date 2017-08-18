using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Modules.AD
{
    /// <summary>
    /// ListItems列表
    /// </summary>
    public class Collection
    {
        public Collection()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

         /// <summary>
        /// 广告listitem
        /// </summary>
        /// <returns></returns>
        public static ListItemCollection ADFlag()
        {
            ListItemCollection ltc = new ListItemCollection();
            ltc.Add(new ListItem("所有类型", "0"));
            ltc.Add(new ListItem("普通静态广告", "static"));
            ltc.Add(new ListItem("任意漂浮广告", "float"));
            ltc.Add(new ListItem("左侧滚动广告", "leftroll"));
            ltc.Add(new ListItem("右侧滚动广告", "rightroll"));
            ltc.Add(new ListItem("左侧对联广告", "leftpair"));
            ltc.Add(new ListItem("右侧对联广告", "rightpair"));
            ltc.Add(new ListItem("弹出广告", "pop"));
            return ltc;
        }
    }
}
