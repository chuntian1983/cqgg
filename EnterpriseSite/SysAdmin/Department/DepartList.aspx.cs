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
using System.Text;
using Modules.Account;
using Modules.Department;
using CommonUtility;


public partial class SysAdmin_Department_DepartList : System.Web.UI.Page
{
    private DepartmentBLL _depart = new DepartmentBLL();
    private DepartmentCategoryBLL _category = new DepartmentCategoryBLL();

    public bool AllowDel
    {
        get { return Convert.ToBoolean(ViewState["AllowDel"]); }
        set { ViewState["AllowDel"] = value; }
    }
    public bool AllowEdit
    {
        get { return Convert.ToBoolean(ViewState["AllowEdit"]); }
        set { ViewState["AllowEdit"] = value; }
    }

    public bool AllowApprove
    {
        get { return Convert.ToBoolean(ViewState["AllowApprove"]); }
        set { ViewState["AllowApprove"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            p.Demand(184);
            this.trSearchButtom.Visible = this.trSearchTop.Visible = p.HasPermission(187);
            this.AllowDel = p.HasPermission(186);
            this.AllowEdit = p.HasPermission(185);
           //this.AllowApprove = p.HasPermission(112);
            this.gvArticleList.Columns[5].Visible = this.AllowEdit || this.AllowDel;
            //this.gvArticleList.Columns[4].Visible = p.HasPermission(112);
            BindCategory();
            BindArticle();
        }
    }

    private void BindCategory()
    {
        ArrayList items = this._category.GetSortedDepartmentCategoryItems(4);
        IEnumerator e = items.GetEnumerator();
        while (e.MoveNext())
        {
            CategoryEntity item = (CategoryEntity)e.Current;
            this.ddlCategory.Items.Add(new ListItem(item.Name, item.Id));
        }
    }

    private string GetFilter()
    {
        if (ViewState["Filter"] == null)
        {
            ViewState["Filter"] = "1=1";
        }
        return this.ViewState["Filter"].ToString();
    }
    private void SetFilter()
    {
        StringBuilder filter = new StringBuilder();
        filter.Append("1=1");
        string starDate = this.txtStart.Text.Trim();
        string endDate = this.txtEnd.Text.Trim();
        string title = this.txtTitle.Text.Trim();
        string approved = this.ddlApproved.SelectedValue;
        if (starDate != String.Empty) filter.AppendFormat(" and AddedDate>='{0}'", starDate);
        if (endDate != String.Empty) filter.AppendFormat(" and AddedDate<='{0}'", endDate);
        if (title != String.Empty) filter.AppendFormat(" and Title like '%{0}%'", title);
        if (approved != "-1") filter.AppendFormat(" and Approved={0}", approved);
        ViewState["Filter"] = filter.ToString();
    }
    private void BindArticle()
    {
        string filter = this.GetFilter();
        string sort = "DepartId desc";
        int pageIndex = this.pageBar.PageIndex;
        int pageSize = this.pageBar.PageSize;
        int count;
        DataSet ds = this._depart.GetDepartmentList("*", filter, sort, pageIndex, pageSize, out count);
        this.gvArticleList.DataSource = ds;
        this.gvArticleList.DataBind();

        this.pageBar.RecordCount = count;
    }


    protected void ibtnDel_Command(object sender, CommandEventArgs e)
    {
        int departId = Convert.ToInt32(e.CommandArgument);
        this._depart.DeleteDepartment(departId);
        BindArticle();
    }
    protected void pageBar_PageIndexChanged(object sender, PageIndexChangedEventArguments e)
    {
        BindArticle();
    }

    protected void lbtnApprove_Command(object sender, CommandEventArgs e)
    {
        int departId = Convert.ToInt32(e.CommandArgument);
        this._depart.ChangeApprovedStatus(departId);
        BindArticle();
    }
    protected void btnFind_Click(object sender, EventArgs e)
    {
        this.SetFilter();
        BindArticle();
    }
    protected void gvArticleList_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
}