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
using Modules.File;

public partial class Controls_Service : System.Web.UI.UserControl
{
    FileDAL1 file = new FileDAL1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            PageBill();
        }
    }

    private void PageBill()
    {
        DataSet ds = file.GetFileCategory();
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
            {
                if (ds.Tables[0].Rows[i]["Title"].ToString() == "档案资料")
                {
                    int j = ds.Tables[0].Rows.IndexOf(ds
                        .Tables[0].Rows[i]);
                    ds.Tables[0].Rows.RemoveAt(j);
                }

            }
            this.DlZP.DataSource = ds;
            this.DlZP.DataBind();
        }
    }
}
