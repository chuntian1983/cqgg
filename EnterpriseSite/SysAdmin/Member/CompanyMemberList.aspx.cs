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
using Modules.Company;
using Modules.Account;

public partial class SysAdmin_Member_CompanyMemberList : System.Web.UI.Page
{
    private MemberBLL _member = new MemberBLL();
    private CompanyBLL _company = new CompanyBLL();
    private int PageIndex = 0;

    public bool AllowApprove
    {
        get { return Convert.ToBoolean(ViewState["AllowApprove"]); }
        set { ViewState["AllowApprove"] = value; }
    }
    public bool AllowTj
    {
        get { return Convert.ToBoolean(ViewState["AllowTj"]); }
        set { ViewState["AllowTj"] = value; }
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
            p.Demand(263);
            this.AllowApprove = p.HasPermission(264);
            this.AllowDel = p.HasPermission(265);
            this.AllowTj = p.HasPermission(322);
            this.gvMemberList.Columns[2].Visible = this.AllowApprove;
            this.gvMemberList.Columns[3].Visible = this.AllowTj;
            this.gvMemberList.Columns[5].Visible = this.AllowDel;
            
            Bind(0);
        }
    }

    private void Bind(int pageIndex)
    {
        DataSet ds = this._member.GetCompanyList();//获得企业用户列表
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
    protected void lbtnTj_Command(object sender, CommandEventArgs e)
    {
        int userId = Convert.ToInt32(e.CommandArgument);
        int i=this._company.ChangeTjStatus(userId);
        if (i == 0)
        {
            Response.Write("<Script>alert('企业会员资料不齐全，不能推荐！');</Script>");
        }
        Bind(this.pageBar.PageIndex);
    }

    protected void lbtn08Tj_Command(object sender, CommandEventArgs e)
    {
        int userId = Convert.ToInt32(e.CommandArgument);
        int i = this._company.Change08TjStatus(userId);
        if (i == 0)
        {
            Response.Write("<Script>alert('企业会员资料不齐全，不能推荐！');</Script>");
        }
        Bind(this.pageBar.PageIndex);
    }

    protected void ibtnDel_Command(object sender, CommandEventArgs e)
    {
        int memberId = Convert.ToInt32(e.CommandArgument);
        this._member.Delete(memberId);
        this._company.Delete(memberId);
        Bind(this.pageBar.PageIndex);
    }

    protected void pageBar_PageIndexChanged(object sender, PageIndexChangedEventArguments e)
    {
        PageIndex = e.NewPageIndex;
        Bind(e.NewPageIndex);
    }
}
