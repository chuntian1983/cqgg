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
using Modules.Advertisement;
using Modules.Account;

public partial class SysAdmin_Advertisement_AdvertisementList : System.Web.UI.Page
{
    private AdvertisementBLL _ad = new AdvertisementBLL();

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
            p.Demand(80);
            this.AllowApprove = p.HasPermission(321);
            this.AllowDel = p.HasPermission(320);
            this.gvADList.Columns[2].Visible = this.AllowApprove;
            this.gvADList.Columns[4].Visible = this.AllowDel;
            Bind();
        }
    }



    private void Bind()
    {
        string filter = "1=1";
        string sort = "Sort asc,adid desc";
        int pageIndex = this.pageBar.PageIndex;
        int pageSize = this.pageBar.PageSize;
        int count;
        DataSet ds = this._ad.GetArticleList("*", filter, sort, pageIndex, pageSize, out count);
        this.gvADList.DataSource = ds;
        this.gvADList.DataBind();
        this.pageBar.RecordCount = count;
    }


    protected void lbtnApprove_Command(object sender, CommandEventArgs e)
    {
        int AdId = Convert.ToInt32(e.CommandArgument);
        this._ad.ChangeApprovedStatus(AdId);
        Bind();
    }

    protected void ibtnDel_Command(object sender, CommandEventArgs e)
    {
        int AdId = Convert.ToInt32(e.CommandArgument);
        this._ad.Delete(AdId);
        Bind();
    }

    protected void pageBar_PageIndexChanged(object sender, PageIndexChangedEventArguments e)
    {
        Bind();
    }
}
