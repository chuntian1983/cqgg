using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Modules.Menu;

public partial class SysAdmin_Desktop_Menu : System.Web.UI.Page
{
    protected string _content;
    private string _menuId = HttpContext.Current.Request["MenuId"];
    private MenuBLL _menu = new MenuBLL();
    private string _userId = HttpContext.Current.User.Identity.Name;
    /*----------------------------------菜单页面参数设置-----------------------------------------*/
    protected int _width = 143;                             //菜单宽度
    protected int _height = 520;                            //菜单高度
    protected int _iconWidth=32;							//图标宽度
	protected int _iconHeight=32;							//图标高度
    protected string _backgroundColor = "#F6F9FF";          //背景色
    /*-------------------------------------------------------------------------------------------*/
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (this._menuId != null)
            {
                //newadd
                int count = 0;
                int menuId = Convert.ToInt32(this._menuId);
                StringBuilder html = new StringBuilder();
                DataTable menuList = this._menu.GetChildMenuItem(Convert.ToInt32(this._userId),menuId).Tables[0];
                foreach (DataRow dr in menuList.Rows)
                {
                    bool IsVisible=Convert.ToBoolean(dr["IsVisible"]);
                    if (IsVisible)
                    {
                        string menuName = dr["Description"].ToString();
                        string link=dr["MenuLink"].ToString();
                        html.Append("<table  border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
                        html.AppendFormat("<tr  height=\"26\" style=\"CURSOR: hand\" OnClick=\"javascript:switchMenu(this);{0}\">\r\n", link != String.Empty ? String.Format("go('{0}');", link) : "");
                        html.AppendFormat("<td align=\"left\" valign=\"Middle\"  width=\"{0}\">\r\n", this._width);
                        html.AppendFormat("<input type=\"button\" style=\"BACKGROUND-IMAGE: url(../images/menu/left/anniu_1.gif);border:0px;width:100%;CURSOR:point;height:23px;\" value=\"{0}\" onFocus=\"this.blur();\"/>\r\n", menuName);
                        html.Append("</td></tr>\r\n");
                        int currentMenuId = (int)dr["PermissionId"];
                        DataTable childMenuList = this._menu.GetChildMenuItem(Convert.ToInt32(this._userId), currentMenuId).Tables[0];
                        //newadd
                        html.AppendFormat("<tr valign=\"top\" style=\"display:{0}\"><td valign=\"Top\">\r\n", count++ == 0 ? "" : "none");
                       // html.Append("<tr valign=\"top\" style=\"display:none\"><td valign=\"Top\">\r\n");
                        foreach (DataRow childMenuItem in childMenuList.Rows)
                        {
                            if (Convert.ToBoolean(childMenuItem["IsVisible"]))
                            {
                                string childMenuName = childMenuItem["Description"].ToString();
                                string childLink = childMenuItem["MenuLink"].ToString();
                                string childImageLink = childMenuItem["ImageLink"].ToString();

                                childImageLink=childImageLink!=String.Empty?childImageLink:"../images/Menu/Left/Logo/005.gif";
                                html.AppendFormat("<table><tr><td  valign=\"Middle\" align=\"center\" height=\"{0}px\">\r\n", this._iconHeight + 2);
                                html.AppendFormat("<div ><a href=\"javascript:void(0);\" onclick=\"javascirt:go('{0}');\" onfocus=\"this.blur();\">", childLink);
                                html.AppendFormat("<img src=\"{0}\" border=\"0px\" height=\"{1}\" width=\"{2}\" onmouseover=\"javascript:menuImageOver(this);\" onmouseout=\"javascript:menuImageOut(this);\"/></a></div>\r\n", childImageLink, this._iconHeight, this._iconWidth);
                                html.AppendFormat("<tr><td  valign=\"Top\" align=\"center\"><span style=\"font-size:12px;color:#000000;\">{0}</span></td></tr>\r\n</table>\r\n", childMenuName);
                            }
                        }
                        html.Append("</td></tr>\r\n");
                        html.Append("</table>\r\n");
                    }
                }
                this._content = html.ToString();
            }
        }
    }
}
