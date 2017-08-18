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
using CommonUtility.DBUtility;

public partial class SysAdmin_AD_Popads : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            if (Request.QueryString["id"].ToString() != "")
            {
                AdoHelper helper = AdoHelper.CreateHelper();
     
                string SQL = "select * from  T_ADList where ID = " + Request.QueryString["id"].ToString();
                DataSet ds = helper.ExecuteDataset(SQL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    label1.Text = ds.Tables[0].Rows[0]["AdCode"].ToString();
                }
            }
        }
    }
}
