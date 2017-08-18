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
using Modules.Applyforjob;

public partial class SysAdmin_Job_YPView : System.Web.UI.Page
{
    ApplyforjobBLL bll = new ApplyforjobBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["SendOfferId"] != null && Request.QueryString["SendOfferId"].ToString() != "")
            {
                int SendOfferId = Int32.Parse(Request.QueryString["SendOfferId"].ToString().Trim());
            }
        }
    }

    private void PageBill(int SendOfferId)
    {
        DataSet ds=bll.GetYPInfo(SendOfferId);
        if (ds.Tables[0].Rows.Count > 0)
        { 
            this.lbCommpany.Text=ds.Tables[0].Rows[0]["CommpanyName"].ToString();
            this.lbCount.Text = ds.Tables[0].Rows[0]["PersonNum"].ToString();
            this.lbJobName.Text = ds.Tables[0].Rows[0]["Description"].ToString();
            this.lbPersonName.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
            this.lbSendDate.Text = DateTime.Parse(ds.Tables[0].Rows[0]["SendDate"].ToString()).ToLongDateString();
            this.lbFillTime.Text = DateTime.Parse(ds.Tables[0].Rows[0]["AddedDate"].ToString()).ToLongDateString();
            this.lbBirthDay.Text = ds.Tables[0].Rows[0]["Birthday"].ToString();
            this.lbSex.Text = ds.Tables[0].Rows[0]["Sex"].ToString()=="0"?"男":"女";
            this.lbSubject.Text = ds.Tables[0].Rows[0]["Speciality"].ToString();
            this.lbDegree.Text = ds.Tables[0].Rows[0]["Levels"].ToString();
        }
    }
}
