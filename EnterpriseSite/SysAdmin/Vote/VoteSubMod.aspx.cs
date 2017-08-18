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
using Modules.Vote;

public partial class SysAdmin_Vote_VoteSubMod : System.Web.UI.Page
{
    VoteSubModel modal = new VoteSubModel();
    VoteSubDAL dal = new VoteSubDAL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
            {
                this.lbsubid.Text = Request.QueryString["id"].ToString();
                this.lbltitle.Text = "投票主题的修改";
                int subid = Int32.Parse(Request.QueryString["id"].ToString());
                PageBill(subid);
            }
        }
    }

    private void PageBill(int sid)
    {
        modal = dal.GetModel(sid);
        this.TextBox2.Text = modal.Vote;
        this.RadioButtonList1.SelectedValue = modal.Vouch.ToString();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        modal.Vote = this.TextBox2.Text;
        modal.Vouch = Int32.Parse(this.RadioButtonList1.SelectedValue.ToString());
        modal.FillTime = DateTime.Now;
        modal.ID = Int32.Parse(this.lbsubid.Text.ToString());
        dal.Update(modal);
        Response.Write("<Script>alert('你已成功修改该投票主题！');location.href('VoteSubList.aspx');</Script>");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.TextBox2.Text = "";
    }
}
