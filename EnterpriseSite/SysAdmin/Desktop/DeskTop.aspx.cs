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
using Modules.Menu;
using Modules.Account;
using System.Text;

public partial class SysAdmin_Desktop_DeskTop : System.Web.UI.Page
{
    protected string _nickname;
    protected string _topMenu;
    private string _userId = HttpContext.Current.User.Identity.Name;
    public string meid;
    protected void Page_Load(object sender, EventArgs e)
    {
        this._nickname = Request.Cookies["__UserInfo"]["nickname"];
        this._topMenu = this.GetTopMenu(this._userId);
       
    }
    private string GetTopMenu(string userId)
    {
        StringBuilder htmlMenu = new StringBuilder();
        DataSet topMenu = new MenuBLL().GetTopMenuItem(Convert.ToInt32(userId));
        if (topMenu.Tables[0].Rows.Count != 0)
        {
            meid = topMenu.Tables[0].Rows[0]["PermissionId"].ToString();
            foreach (DataRow dr in topMenu.Tables[0].Rows)
            {
                if (Convert.ToBoolean(dr["IsVisible"]))
                {
                    string menuName = dr["Description"].ToString();
                    string menuId = dr["PermissionId"].ToString();
                    htmlMenu.Append("<td width=\"1\" valign=\"top\"><img src=\"../images/top/xian.gif\" width=\"1\" height=\"24\"/></td>");
                    htmlMenu.Append("<td width=\"8\"/><td align=\"center\">");
                    htmlMenu.AppendFormat("<a href=\"SubMenu.aspx?MenuId={0}\" class=\"a\" target=\"leftFrame\">{1}</a></td>", menuId, menuName);
                }
            }
        }
      return htmlMenu.ToString();
    }
    protected void lnkbtnLogout_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Cookies["__UserInfo"].Expires = DateTime.Now.AddDays(-1);
        Response.Redirect("../login.aspx");
    }
}
