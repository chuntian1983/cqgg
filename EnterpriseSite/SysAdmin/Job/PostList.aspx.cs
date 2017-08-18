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
using Modules.Account;
using CommonUtility;


public partial class SysAdmin_Job_PostList : System.Web.UI.Page
{
    private PostBLL _post = new PostBLL();
    private int PageIndex = 0;

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
            p.Demand(251);
            this.AllowDel = p.HasPermission(260);
            this.AllowApprove= p.HasPermission(259);
            this.gvPostList.Columns[4].Visible = this.AllowApprove;
            this.gvPostList.Columns[5].Visible = this.AllowDel;
            Bind(0);
        }
    }
    private void Bind(int pageIndex)
    {
        DataSet ds = this._post.GetAllPostDetailes();
        if (txtName.Text.Trim() != "")
        {
            string Name = this.txtName.Text.Trim();
            ds = this._post.GetCommpanyInfo(Name);
        }
        this.gvPostList.PageIndex = pageIndex;
        this.gvPostList.PageSize = this.pageBar.PageSize;
        this.gvPostList.DataSource = ds;
        this.gvPostList.DataBind();

        this.pageBar.RecordCount = ds.Tables[0].Rows.Count;
    }
    protected void ibtnDel_Command(object sender, CommandEventArgs e)
    {
        int postId = Convert.ToInt32(e.CommandArgument);
        this._post.DeletePost(postId);
        Bind(this.pageBar.PageIndex);
    }

    protected void lbtnApprove_Command(object sender, CommandEventArgs e)
    {
        int postId = Convert.ToInt32(e.CommandArgument);
        this._post.ChangeApprovedStatus(postId);
        Bind(PageIndex);
    }

    protected void pageBar_PageIndexChanged(object sender, PageIndexChangedEventArguments e)
    {
        PageIndex = e.NewPageIndex;
        Bind(e.NewPageIndex);
    }

    //根据公司名称查询
    protected void Button1_Click(object sender, EventArgs e)
    {
        string Name = this.txtName.Text.Trim();
        DataSet ds = this._post.GetCommpanyInfo(Name);
        this.gvPostList.DataSource = ds;
        this.gvPostList.DataBind();
        this.pageBar.RecordCount = ds.Tables[0].Rows.Count;
    }
}
