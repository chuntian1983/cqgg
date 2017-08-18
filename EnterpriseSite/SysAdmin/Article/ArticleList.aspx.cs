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
using Modules.Article;
using CommonUtility;

public partial class SysAdmin_Article_ArticleList : System.Web.UI.Page
{
    private ArticleBLL _article = new ArticleBLL();
    private ArticleCategoryBLL _category = new ArticleCategoryBLL();
    CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
    int[] b = new int[30];

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
            p.Demand(31);
            this.trSearchButtom.Visible = this.trSearchTop.Visible = p.HasPermission(111);
            this.AllowDel = p.HasPermission(110);
            this.AllowEdit = p.HasPermission(109);
            this.AllowApprove = p.HasPermission(112);
            this.gvArticleList.Columns[7].Visible = this.AllowEdit || this.AllowDel;
            this.gvArticleList.Columns[4].Visible = p.HasPermission(112);
            BindCategory();
            //BindArticle();
        }
    }

    private void BindCategory()
    {
        /////
        ArrayList items=this._category.GetSortedArticleCategoryItems(6);
        IEnumerator e = items.GetEnumerator();
        while (e.MoveNext())
        {
            CategoryEntity item = (CategoryEntity)e.Current;
            this.ddlCategory.Items.Add(new ListItem(item.Name, item.Id));
        }
        #region 菜单权限管理

        if (p.HasPermission(280) == false) //人事代理
        {
            b[0] = 181;
            b[1] = 182;
            Delete(b);
        }
        else if (p.HasPermission(280))
        {
            if (p.HasPermission(284) == false)
            {
                b[0] = 182;
                Delete(b);
            }
        }

        if (p.HasPermission(281) == false)//办事指南
        {
            b[0] = 196;
            b[1] = 197;
            Delete(b);
        }
        else if (p.HasPermission(281))
        {
            if (p.HasPermission(285) == false)
            {
                b[0] = 197;
                Delete(b);
            }
        }

        if (p.HasPermission(282) == false)//服务天地
        {
            b[0] = 207;
            b[1] = 208;
            Delete(b);
        }
        else if (p.HasPermission(282))
        {
            if (p.HasPermission(286) == false)
            {
                b[0] = 208;
                Delete(b);
            }
        }

        if (p.HasPermission(283) == false)//关于我们
        {
            b[0] = 203;
            b[1] = 204;
            b[2] = 205;
            b[3] = 206;
            Delete(b);
        }
        else if (p.HasPermission(283))
        {
            if (p.HasPermission(287) == false)
            {
                b[0] = 204;
                Delete(b);
            }
            if (p.HasPermission(288) == false)
            {
                b[0] = 205;
                Delete(b);
            }
            if (p.HasPermission(289) == false)
            {
                b[0] = 206;
                Delete(b);
            }
        }

        #endregion
        ddlCategory.Items.Insert(0,new ListItem("--请选择类别--","0"));
    }
    protected void Delete(int[] a)
    {
        for (int i = 0; i < a.Length; i++)
        {
            for (int j = 0; j < ddlCategory.Items.Count; j++)
            {
                if (int.Parse(ddlCategory.Items[j].Value) == a[i])
                {
                    ddlCategory.Items.RemoveAt(j);
                    //j = ddlType.Items.Count;

                }
            }
        }
        // ddlType.Items.Insert(0, "--请选择类别--");

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
        string type = this.ddlCategory.SelectedValue;
        string approved=this.ddlApproved.SelectedValue;
        if (starDate != String.Empty) filter.AppendFormat(" and AddedDate>='{0}'", starDate);
        if (endDate != String.Empty) filter.AppendFormat(" and AddedDate<='{0}'", endDate);
        if (title != String.Empty) filter.AppendFormat(" and Title like '%{0}%'", title);
        if (type != "0") filter.AppendFormat(" and CategoryId={0}", type);
        if (approved != "-1") filter.AppendFormat(" and Approved={0}", approved);
        ViewState["Filter"] = filter.ToString();
    }
    private void BindArticle()
    {
        string filter=this.GetFilter();
        string sort="ArticleId desc";
        int pageIndex=this.pageBar.PageIndex;
        int pageSize=this.pageBar.PageSize;
        int count;
        DataSet ds = this._article.GetArticleList("*", filter, sort, pageIndex, pageSize, out count);

        this.gvArticleList.DataSource = ds;
        this.gvArticleList.DataBind();

        this.pageBar.RecordCount = count;
    }
    protected void ibtnDel_Command(object sender, CommandEventArgs e)
    {
        int articleId = Convert.ToInt32(e.CommandArgument);
        this._article.DeleteArticle(articleId);
        BindArticle();
    }
    protected void pageBar_PageIndexChanged(object sender, PageIndexChangedEventArguments e)
    {
        BindArticle();
    }

    protected void lbtnApprove_Command(object sender, CommandEventArgs e)
    {
        int articleId = Convert.ToInt32(e.CommandArgument);
        this._article.ChangeApprovedStatus(articleId);
        BindArticle();
    }
    protected void btnFind_Click(object sender, EventArgs e)
    {
        this.SetFilter();
        BindArticle();
    }
   
}
