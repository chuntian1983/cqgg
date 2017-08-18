using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Swgk_Default2 : System.Web.UI.Page
{
    public string deptid;
    public string st;
    public string dwurl;
    protected void Page_Load(object sender, EventArgs e)
    {
        dwurl = "maindw.aspx?deptid=<%=deptid %>&st=<%=st %>";
        deptid = Request.QueryString["deptid"];
        st = Request.QueryString["st"];
        if (deptid == null || deptid == "0")
        {
            deptid = "0";
            dwurl = "http://www.tadj.gov.cn/ ";
        }
        else
        {
            dwurl = "maindw.aspx?deptid=" + deptid + "&st=" + st + "";
        }
    }
}