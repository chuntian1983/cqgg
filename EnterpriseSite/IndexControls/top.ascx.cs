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
using Modules.News;
using System.Text;
public partial class Controls_top : System.Web.UI.UserControl
{
    NewsDAL1 dal = new NewsDAL1();
    protected string GG = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.lbYear.Text = DateTime.Now.Year.ToString();
            this.lbMonth.Text = DateTime.Now.Month.ToString();
            this.lbDay.Text = DateTime.Now.Day.ToString();
            this.lbweakDay.Text = GetChineseWeek(DateTime.Now.DayOfWeek.ToString());
            PageBill();
        }
    }

    private string GetChineseWeek(string week)
    {
        switch (week.ToLower())
        {
            case "monday":
                return "星期一";
            case "tuesday":
                return "星期二";
            case "wednesday":
                return "星期三";
            case "thursday":
                return "星期四";
            case "friday":
                return "星期五";
            case "saturday":
                return "星期六";
            case "sunday":
                return "星期日";
            default:
                return "";
        }
    }

    private void PageBill()
    { 
        //通知公告 前两条
        DataSet ds=dal.GetNewsList("通知公告",2);
        StringBuilder sb = new StringBuilder();
        foreach (DataRow row in ds.Tables[0].Rows)
        { 
            string newsID=row["newsID"].ToString();
            string title=row["title"].ToString();
            sb.AppendFormat("·<a href=\"Web/News_View.aspx?NewsID={0}\" target=\"_blank\">{1}</a>", newsID,title);
            sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;");
        }
        GG = sb.ToString();
    }
}
