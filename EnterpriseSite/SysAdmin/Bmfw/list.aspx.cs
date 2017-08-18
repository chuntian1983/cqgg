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
using Modules.Refer;
using Modules.Account;

public partial class SysAdmin_Bmfw_list : System.Web.UI.Page
{
    public bool AllowDel
    {
        get { return Convert.ToBoolean(ViewState["AllowDel"]); }
        set { ViewState["AllowDel"] = value; }
    }
    public bool AllowModify
    {
        get { return Convert.ToBoolean(ViewState["AllowModify"]); }
        set { ViewState["AllowModify"] = value; }
    }
    //ReferDAL dal = new ReferDAL();
    Modules.T_BMFW.DAL.T_BMFW dal = new Modules.T_BMFW.DAL.T_BMFW();
    private int PageIndex = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            p.Demand(269);
            this.AllowDel = p.HasPermission(279);
            this.AllowModify = p.HasPermission(278);
            this.gvOptions.Columns[3].Visible = this.AllowDel || this.AllowModify;
            Bind(0);
        }
    }

    private void Bind(int pageIndex)
    {
         string deptid = HttpContext.Current.Request.Cookies["__UserInfo"]["deptid"];
         DataSet ds = this.dal.GetListcun(" b.ParentCategoryId='"+deptid+"'");
        this.gvOptions.PageIndex = pageIndex;
        this.gvOptions.PageSize = this.pageBar.PageSize;
        this.gvOptions.DataSource = ds;
        this.gvOptions.DataBind();
        this.pageBar.RecordCount = ds.Tables[0].Rows.Count;
    }

    protected void pageBar_PageIndexChanged(object sender, PageIndexChangedEventArguments e)
    {
        PageIndex = e.NewPageIndex;
        Bind(e.NewPageIndex);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        string id = btn.CommandArgument.ToString();
        Response.Redirect("add.aspx?id="+id+"");
    }
}