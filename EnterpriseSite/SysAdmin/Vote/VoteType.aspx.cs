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

public partial class SysAdmin_Vote_VoteType : System.Web.UI.Page
{
    VoteOperate index = new VoteOperate();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.lbltitle.Text = "调查类别添加";
            if (Request.QueryString["vid"] != null && Request.QueryString["vid"].ToString() != "")
            {
                this.Label1.Text = Request.QueryString["vid"].ToString();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.TextBox2.Text != "")
        {
            string a = this.TextBox2.Text.ToString();
            int b = Int32.Parse(this.Label1.Text.ToString());
            int c = Int32.Parse(this.RadioButtonList1.SelectedValue.ToString());
            int count = index.VoteTypeAdd(a, b, c);
            if (count > 0)
            {
                Response.Write("<script>alert('你已成功添加!');location.href('VoteTypeList.aspx?vid=" + b + "');</script>");
            }
            else
            {
                Response.Write("<script>alert('添加出错!');</script>");
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.TextBox2.Text = "";
    }
}
