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
using Modules.Member;
using Modules.Account;

public partial class SysAdmin_Member_PersonalMemberList : System.Web.UI.Page
{
    private MemberBLL _member = new MemberBLL();
    public bool AllowApprove
    {
        get { return Convert.ToBoolean(ViewState["AllowApprove"]); }
        set { ViewState["AllowApprove"] = value; }
    }

    public bool AllowDel
    {
        get { return Convert.ToBoolean(ViewState["AllowDel"]); }
        set { ViewState["AllowDel"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            p.Demand(266);
            this.AllowApprove = p.HasPermission(267);
            this.AllowDel = p.HasPermission(268);
            this.gvMemberList.Columns[2].Visible = this.AllowApprove;
            this.gvMemberList.Columns[4].Visible = this.AllowDel;
            Bind(0);
        }
    }

    private void Bind(int pageIndex)
    {
        DataSet ds = this._member.GetPersonList();//获得个人会员列表
        this.gvMemberList.PageIndex = pageIndex;
        this.gvMemberList.PageSize = this.pageBar.PageSize;
        this.gvMemberList.DataSource = ds;
        this.gvMemberList.DataBind();

        this.pageBar.RecordCount = ds.Tables[0].Rows.Count;
    }

    protected void lbtnApprove_Command(object sender, CommandEventArgs e)
    {
        int memberId = Convert.ToInt32(e.CommandArgument);
        this._member.ChangeApprovedStatus(memberId);
        Bind(this.pageBar.PageIndex);
    }

    protected void ibtnDel_Command(object sender, CommandEventArgs e)
    {
        int memberId = Convert.ToInt32(e.CommandArgument);
        this._member.Delete(memberId);
        Bind(this.pageBar.PageIndex);
    }

    protected void pageBar_PageIndexChanged(object sender, PageIndexChangedEventArguments e)
    {
        Bind(e.NewPageIndex);
    }
}
