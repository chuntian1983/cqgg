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
using System.Drawing;
using System.Web.SessionState;
using System.Data.SqlClient;
using Modules.Weather;



public partial class SysAdmin_Weather_Weather_Del : System.Web.UI.Page
{
    public int id = 0;
    WeatherDAL dal = new WeatherDAL();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                id = Int32.Parse(Request.QueryString["ID"].ToString());
            }
            try
            {
                dal.Delete(id);
                Response.Redirect("Weather_List.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}
