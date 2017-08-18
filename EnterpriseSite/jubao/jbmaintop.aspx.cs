using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class jubao_jbmaintop : System.Web.UI.Page
{
    public string pid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["pid"]!=null)
        {
            pid = Request.QueryString["pid"];
        }
    }
}