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

public partial class Controls_Political : System.Web.UI.UserControl
{
    NewsDAL1 dal = new NewsDAL1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            PageBill();
        }
    }

    private void PageBill()
    {
        //政策法规　取前5条
        DataSet ds = dal.GetNewsList("政策法规", 5);
        if (ds.Tables[0].Rows.Count > 0)
        {
            this.DlPolitical.DataSource = ds;
            this.DlPolitical.DataBind();
        }
    }


    //截取字符串长度
    public string getSubString(string str, int len)
    {
        if (str.Length > len)
        {
            return str.Substring(0, len) + "...";
        }
        return str;
    }

}
