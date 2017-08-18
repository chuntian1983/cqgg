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
using Modules.Advertisement;

public partial class Controls_tj : System.Web.UI.UserControl
{
    public string imagePath = ConfigurationSettings.AppSettings["originalPicPath"].ToString();
    AdvertisementBLL bll = new AdvertisementBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataSet ds = bll.GetTJADList(6);//取六条
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.DataList1.DataSource = ds;
                this.DataList1.DataBind();
            }
        }
    }
}
