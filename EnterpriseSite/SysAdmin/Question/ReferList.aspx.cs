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

public partial class SysAdmin_Question_ReferList : System.Web.UI.Page
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
    ReferDAL dal = new ReferDAL();
    private int PageIndex = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            p.Demand(269);
            this.AllowDel = p.HasPermission(278);
            this.AllowModify = p.HasPermission(279);
            this.gvOptions.Columns[4].Visible = this.AllowDel || this.AllowModify;
            Bind(0);
        }
    }

    private void Bind(int pageIndex)
    {
        DataSet ds = this.dal.GetList("");
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



}

