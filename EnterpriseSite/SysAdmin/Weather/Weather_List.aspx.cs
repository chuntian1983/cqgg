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
using System.Data.SqlClient;
using CommonUtility.DBUtility;
using Modules.Weather;


public partial class SysAdmin_Weather_Weather_List : System.Web.UI.Page
{
    WeatherDAL dal = new WeatherDAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindWeather();
        }
    }
    //得到所有的天气信息
    private void BindWeather()
    {
        DataSet ds = dal.GetList("");
        dg_Weather.DataSource = ds;
        dg_Weather.DataBind();
    }


    //删除昨天及以前
    protected void btnDel1_Click(object sender, EventArgs e)
    {
        //dal.DeleteWeather("day");
        dal.Delete1("day");
        Response.Write("<script>alert('删除成功!');</script>");
        BindWeather();
    }
    //删除上月及以前
    protected void btnDel2_Click(object sender, EventArgs e)
    {
        dal.Delete1("month");
        Response.Write("<script>alert('删除成功!');</script>");
        BindWeather();
    }
    //删除去年及以前
    protected void btn3_Click(object sender, EventArgs e)
    {
        dal.Delete1("year");
        Response.Write("<script>alert('删除成功!');</script>");
        BindWeather();
    }
    //删除全部
    protected void btnDel4_Click(object sender, EventArgs e)
    {
        dal.Delete1("");
        Response.Write("<script>alert('删除成功!');</script>");
        BindWeather();
    }

    //分页
    protected void dg_Weather_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        this.dg_Weather.CurrentPageIndex = e.NewPageIndex;
        BindWeather();


    }
}
