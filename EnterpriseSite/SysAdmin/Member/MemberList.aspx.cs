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
using Modules.Account;


public partial class SysAdmin_Member_MemberList : System.Web.UI.Page
{
    private UserBLL _user = new UserBLL();
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
        if (!IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            p.Demand(57);
            this.AllowApprove = p.HasPermission(125);
            this.AllowDel = p.HasPermission(124);
            Bind(0);
        }
    }
    private void Bind(int pageIndex)
    {
        DataSet ds = this._user.GetUserList("RegisterType=0","UserId desc");
        this.gvMemberList.PageIndex = pageIndex;
        this.gvMemberList.PageSize = this.pageBar.PageSize;
        this.gvMemberList.DataSource = ds;
        this.gvMemberList.DataBind();

        this.pageBar.RecordCount = ds.Tables[0].Rows.Count;
    }
    protected void lbtnApprove_Command(object sender, CommandEventArgs e)
    {
        int userId = Convert.ToInt32(e.CommandArgument);
        this._user.ChangeApprovedStatus(userId);
        Bind(this.pageBar.PageIndex);
    }

    protected void ibtnDel_Command(object sender, CommandEventArgs e)
    {
        int userId = Convert.ToInt32(e.CommandArgument);
        this._user.Delete(userId);
        Bind(this.pageBar.PageIndex);
    }
    protected void pageBar_PageIndexChanged(object sender, PageIndexChangedEventArguments e)
    {
        Bind(e.NewPageIndex);
    }
}
