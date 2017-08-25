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
using Maticsoft.Common;

public partial class SysAdmin_News_newslist : System.Web.UI.Page
{
    private NewsBLL _article = new NewsBLL();
    private NewsCategoryBLL _category = new NewsCategoryBLL();
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
            // CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            p.Demand(163);
            
            
            
            BindCategory();
            //BindArticle();
        }
    }

    //protected void BindDll()
    //{
    //    NCPEP.Bll.T_NewsType bll = new NCPEP.Bll.T_NewsType();
    //    DataTable dt = bll.GetAllList().Tables[0];
    //    this.ddlxwlx.DataSource = dt;
    //    this.ddlxwlx.DataTextField = "NewsTypeName";
    //    this.ddlxwlx.DataValueField = "Id";
    //    this.ddlxwlx.DataBind();
    //    this.ddlxwlx.Items.Insert(0, new ListItem("请选择"));
    //}
    /// <summary>
    /// 初始绑定数据
    /// </summary>
    private void BindDate()
    {
        //StringBuilder sb = new StringBuilder();
        //sb.Append(" 1=1");
        ////if (this.ddlxwlx.SelectedValue != "请选择")
        ////{
        ////    sb.Append(" and NewsTypeId='" + this.ddlxwlx.SelectedValue + "'");
        ////}
        //if (!string.IsNullOrEmpty(this.TextBox1.Text))
        //{
        //    sb.Append(" and NewsTitle like '%" + this.TextBox1.Text + "%'");
        //}
        ////if (this.DropDownList2.SelectedValue != "全部")
        ////{
        ////    sb.Append(" and IsCheck='" + this.DropDownList2.SelectedValue + "'");
        ////}
        //sb.Append("  and DepaStatus ='3' and StandardMode='2' and jbzt='1'");
        //if (model.JBYhm != null)
        //{
        //    sb.Append(" and jbyhm='" + model.JBYhm + "'");
        //}
        //NCPEP.Dal.T_Bid bll = new NCPEP.Dal.T_Bid();

        //this.pg.RecordCount = bll.GetRecordCountByUser(sb.ToString());
        //this.pg.PageSize = 10;
        //this.pg.UrlPageIndexName = "pg";
        //if (!string.IsNullOrEmpty(hdpage.Value) && hdpage.Value != "1")
        //{
        //    pg.CurrentPageIndex = int.Parse(hdpage.Value);
        //}

        //int sindex = (this.pg.CurrentPageIndex - 1) * this.pg.PageSize + 1;
        //int eindex = this.pg.CurrentPageIndex * this.pg.PageSize;

        //DataSet ds = bll.GetListByPageByUser(sb.ToString(), "id desc", sindex, eindex);
        ////DataSet ds = bll.GetList(this.AspNetPager1.PageSize, this.AspNetPager1.CurrentPageIndex, sb.ToString());
        //this.rep.DataSource = ds;
        //this.rep.DataBind();


    }
    
    protected void AspNetPager1_PageChanged(object src, EventArgs e)
    {
        bindData();
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        int i = 0;
        string sysID = string.Empty;
        foreach (RepeaterItem row in this.gvArticleList.Items)
        {
            if (row.ItemType == ListItemType.Item || row.ItemType == ListItemType.AlternatingItem)
            {
                CheckBox chk = (CheckBox)row.FindControl("cbx");
                Label lbid = (Label)row.FindControl("lbid");
                if (chk.Checked)
                {
                    i++;
                    sysID = lbid.Text;
                }

            }


        }
        if (i == 0)
        {
            MessageBox.Show(this, "请选择需要竞标的项目!");
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "dd", " <script>$(\".alert\").alert()</script>");
        }
        else if (i > 1)
        {
            MessageBox.Show(this, "只能选择一项进行竞标");
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "dd", " <script>$(\".alert\").alert()</script>");
        }
        else
        {

            Response.Redirect("oneagreeuserjb.aspx?st=" + sysID + "");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("add.aspx");
    }
    protected void btndel_Click(object sender, EventArgs e)
    {

    }
    private void BindCategory()
    {
        ArrayList items = this._category.GetSortedArticleCategoryItems(4);
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
        ddlCategory.Items.Insert(0, new ListItem("--请选择类别--", "0"));
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
      
        string title = this.txtTitle.Text.Trim();
        string type = this.ddlCategory.SelectedValue;
        
        
        if (title != String.Empty) filter.AppendFormat(" and a.Title like '%{0}%'", title);
        if (type != "0") filter.AppendFormat(" and a.CategoryId={0}", type);
       
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
    protected void Button5_Click(object sender, EventArgs e)
    {
        this.SetFilter();
        BindArticle();
    }
    private void BindArticle()
    {
        string filter = this.GetFilter();


        DataTable dts = this._article.GetListnews(filter);
        AspNetPager1.PageSize = 10;
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
}