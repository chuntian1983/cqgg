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
using CommonUtility;
using Modules.Applyforjob;
using Modules.Account;

public partial class SysAdmin_Job_YPList : System.Web.UI.Page
{
    private ApplyforjobBLL _applyforjob = new ApplyforjobBLL();
    private int PageIndex = 0;

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
            p.Demand(252);
            this.AllowDel = p.HasPermission(262);
            this.gvSeekerList.Columns[5].Visible = this.AllowDel;
            Bind(0,"");
        }
    }
    private void Bind(int pageIndex,string where)
    {
        DataSet ds = this._applyforjob.GetYPList(where);
        this.gvSeekerList.PageIndex = pageIndex;
        this.gvSeekerList.PageSize = this.pageBar.PageSize;
        this.gvSeekerList.DataSource = ds;
        this.gvSeekerList.DataBind();

        this.pageBar.RecordCount = ds.Tables[0].Rows.Count;
    }
    protected void ibtnDel_Command(object sender, CommandEventArgs e)
    {
        int seekId = Convert.ToInt32(e.CommandArgument);
        this._applyforjob.DeleteYPInfo(seekId);
        Bind(this.pageBar.PageIndex,"");
    }
    protected void pageBar_PageIndexChanged(object sender, PageIndexChangedEventArguments e)
    {
        PageIndex = e.NewPageIndex;
        Bind(e.NewPageIndex,"");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string Name = this.txtName.Text.Trim();
        Bind(0,"UserName like '%"+Name+"%'");
    }
}
