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
using Modules.News;
using CommonUtility;


public partial class SysAdmin_News_ArticleList : System.Web.UI.Page
{
    private NewsBLL _article = new NewsBLL();
    private NewsCategoryBLL _category = new NewsCategoryBLL();
    CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
    int[] b = new int[30];
    public bool AllowDel
    {
        get{return Convert.ToBoolean(ViewState["AllowDel"]);}
        set{ViewState["AllowDel"]=value;}
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
           // CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            p.Demand(163);
            this.trSearchButtom.Visible = this.trSearchTop.Visible = p.HasPermission(166);
            this.AllowDel = p.HasPermission(165);
            this.AllowEdit = p.HasPermission(164);
            this.AllowApprove = p.HasPermission(167);
            this.gvArticleList.Columns[7].Visible = this.AllowEdit || this.AllowDel;
            this.gvArticleList.Columns[4].Visible = p.HasPermission(167);
            BindCategory();
            //BindArticle();
        }
    }

    private void BindCategory()
    {
        ArrayList items=this._category.GetSortedArticleCategoryItems(4);
        IEnumerator e = items.GetEnumerator();
        while (e.MoveNext())
        {
            CategoryEntity item = (CategoryEntity)e.Current;
            this.ddlCategory.Items.Add(new ListItem(item.Name, item.Id));
        }
        #region 菜单权限管理
        if (p.HasPermission(290) == false)//毕业生园地
        {
            b[0] = 177;
            b[1] = 211;
            Delete(b);
        }
        else if (p.HasPermission(290))
        {
            if (p.HasPermission(299) == false)
            {
                b[0] = 211;
                Delete(b);
            }
        }

        if (p.HasPermission(291) == false)//最新动态
        {
            b[0] = 178;
            b[1] = 179;
            b[2] = 180;
            b[3] = 213;
            b[4] = 214;
            Delete(b);
        }
        else if (p.HasPermission(291))
        {
            if (p.HasPermission(300) == false)
            {
                b[0] = 179;
                Delete(b);
            }
            if (p.HasPermission(301) == false)
            {
                b[0] = 180;
                Delete(b);
            }
            if (p.HasPermission(323) == false)
            {
                b[0] = 213;
                Delete(b);
            }
            if (p.HasPermission(324) == false)
            {
                b[0] = 214;
                Delete(b);
            }
        }

        if (p.HasPermission(292) == false)//人事代理
        {
            b[0] = 183;
            b[1] = 184;
            Delete(b);
        }
        else if (p.HasPermission(292))
        {
            if (p.HasPermission(302) == false)
            {
                b[0] = 184;
                Delete(b);
            }
        }

        if (p.HasPermission(293) == false)//考试培训
        {
            b[0] = 185;
            b[1] = 186;
            Delete(b);
        }
        else if (p.HasPermission(293))
        {
            if (p.HasPermission(303) == false)
            {
                b[0] = 186;
                Delete(b);
            }
        }

        if (p.HasPermission(294) == false)//职称评审
        {
            b[0] = 187;
            b[1] = 188;
            Delete(b);
        }
        else if (p.HasPermission(294))
        {
            if (p.HasPermission(304) == false)
            {
                b[0] = 188;
                Delete(b);
            }
        }

        if (p.HasPermission(295) == false)//政策法规
        {
            b[0] = 189;
            b[1] = 190;
            Delete(b);
        }
        else if (p.HasPermission(295))
        {
            if (p.HasPermission(305) == false)
            {
                b[0] = 190;
                Delete(b);
            }
        }

        if (p.HasPermission(296) == false)//党建园地
        {
            b[0] = 191;
            b[1] = 192;
            b[2] = 193;
            b[3] = 194;
            b[4] = 195;
            Delete(b);
        }
        else if (p.HasPermission(296))
        {
            if (p.HasPermission(306) == false)
            {
                b[0] = 192;
                Delete(b);
            }
            if (p.HasPermission(307) == false)
            {
                b[0] = 193;
                Delete(b);
            }
            if (p.HasPermission(308) == false)
            {
                b[0] = 194;
                Delete(b);
            }
            if (p.HasPermission(309) == false)
            {
                b[0] = 195;
                Delete(b);
            }
        }

        if (p.HasPermission(297) == false)//办事指南
        {
            b[0] = 198;
            b[1] = 199;
            Delete(b);
        }
        else if (p.HasPermission(297))
        {
            if (p.HasPermission(310) == false)
            {
                b[0] = 199;
                Delete(b);
            }
        }

        if (p.HasPermission(298) == false)//服务天地
        {
            b[0] = 200;
            b[1] = 212;
            Delete(b);
        }
        else if (p.HasPermission(298))
        {
            if (p.HasPermission(313) == false)
            {
                b[0] = 212;
                Delete(b);
            }
        }
        #endregion
        ddlCategory.Items.Insert(0,new ListItem( "--请选择类别--","0"));
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
        if (starDate != String.Empty) filter.AppendFormat(" and a.AddedDate>='{0}'", starDate);
        if (endDate != String.Empty) filter.AppendFormat(" and a.AddedDate<='{0}'", endDate);
        if (title != String.Empty) filter.AppendFormat(" and a.Title like '%{0}%'", title);
        if (type != "0") filter.AppendFormat(" and a.CategoryId={0}", type);
        if (approved != "-1") filter.AppendFormat(" and a.Approved={0}", approved);
        //王浩 修改 2012-4-10
        string uid = HttpContext.Current.User.Identity.Name;
        UserBLL ub = new UserBLL();
        UserDetail ud = new UserDetail();
        ud = ub.GetUserDetail(int.Parse(uid));
        if (uid != "1")
        {
            filter.Append(" and a.imglink='" + ud.Email + "'");
        }
        ViewState["Filter"] = filter.ToString();
    }
    private void BindArticle()
    {
        string filter = this.GetFilter();


        DataTable dts = this._article.GetListnews(filter);
        AspNetPager1.RecordCount = dts.Rows.Count;
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = dts.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.PageSize = AspNetPager1.PageSize;
        gvArticleList.DataSource = pds;
        gvArticleList.DataBind();
    }
    void bindData()
    {
        string filter = this.GetFilter();
        

        DataTable dts =this._article.GetListnews(filter);
        AspNetPager1.RecordCount = dts.Rows.Count;
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = dts.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.PageSize = AspNetPager1.PageSize;
        gvArticleList.DataSource = pds;
        gvArticleList.DataBind();
    }
    protected void AspNetPager1_PageChanged(object src, EventArgs e)
    {
        bindData();
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
