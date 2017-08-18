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
using Modules.Account;

public partial class SysAdmin_Vote_VoteSub : System.Web.UI.Page
{
    VoteSubDAL dal = new VoteSubDAL();
    VoteSubModel modal = new VoteSubModel();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            p.Demand(197);
            this.lbltitle.Text = "调查项目添加";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        modal.Vote = this.TextBox2.Text;//投票主题
        modal.Vouch = Int32.Parse(RadioButtonList1.SelectedValue.ToString());//是否推荐
        modal.FillTime = DateTime.Now;
        int count = dal.Add(modal);
        //count代表投票主题的编号
        Response.Write("<Script>alert('你已成功添加投票主题！接下来将添加投票类别！');location.href('VoteType.aspx?vid=" + count + "');</Script>");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.TextBox2.Text = "";
    }
}
