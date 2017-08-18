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
using Modules.Job;
using Modules.Resume;

public partial class Controls_wztj : System.Web.UI.UserControl
{
    private PostBLL post = new PostBLL();
    private ResumeBLL resume = new ResumeBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.lblPostNumTotal.Text = post.GetTotalPostNum().ToString();
        this.lblPostNumWeekly.Text = post.GetWeeklyPostNum().ToString();
        this.lblResumeNumTotal.Text = resume.GetTotalResumeNum().ToString();
        this.lblResumeNumWeekly.Text = resume.GetWeeklyResumeNum().ToString();
    }
}
