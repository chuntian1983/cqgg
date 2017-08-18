using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Swgk_main : System.Web.UI.Page
{
    public string deptid;
    public string _nickname;
    public string _topMenu;
    public string st;
    protected void Page_Load(object sender, EventArgs e)
    {
        deptid = Request.QueryString["deptid"];
        st = Request.QueryString["st"];
        _nickname = "群众";
    }
    protected void lnkbtnLogout_Click(object sender, EventArgs e)
    {

    }
}