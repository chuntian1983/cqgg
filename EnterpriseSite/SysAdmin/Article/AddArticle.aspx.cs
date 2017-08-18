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
using Modules.Article;
using Modules.Account;
using CommonUtility;

public partial class SysAdmin_Article_AddOrEditArticle : System.Web.UI.Page
{
    private string _articleId = HttpContext.Current.Request["ArticleId"];
    private ArticleBLL _article = new ArticleBLL();
    private ArticleCategoryBLL _category = new ArticleCategoryBLL();
    private string _userId = HttpContext.Current.User.Identity.Name;
    protected string _pageTitle = "添加文章";
    ArticleDAL1 dal = new ArticleDAL1();
    public DataTable dt;
    public DataSet ds;
    CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
    int[] b=new int[30];

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCategory();
            if (this._articleId != null)
            {
                p.Demand(109);
                int articleId = Convert.ToInt32(this._articleId);
                ArticleDetail detail = this._article.GetArticleDetail(articleId);
                this.txtTitle.Text = detail.Title;
                this.fckBody.Value = detail.Body;
                this.txtUnit.Text = detail.PublicationUnit;
                this.txtReleaseDate.Text = detail.ReleaseDate.ToString("yyyy-MM-dd");
                this.txtExpireDate.Text = detail.ExpireDate.ToString("yyyy-MM-dd");
                this.txtUnit.Text = detail.PublicationUnit;
                this.ddlType.SelectedValue = detail.CategoryId.ToString();
                ViewState["Approved"] = detail.Approved;
                ViewState["ViewCount"] = detail.ViewCount;
                this._pageTitle = "修改文章";
                this.spanBack.Visible = true;
            }
            else
            {
                p.Demand(30);
            }

  
        }
    }

    private void BindCategory()
    {
        
            ArrayList items = this._category.GetSortedArticleCategoryItems(6);
            IEnumerator e = items.GetEnumerator();
            while (e.MoveNext())
            {
                CategoryEntity item = (CategoryEntity)e.Current;
                this.ddlType.Items.Add(new ListItem(item.Name, item.Id));
            }

            #region 菜单权限管理

            if (p.HasPermission(280) == false) //人事代理
            {
                b[0] = 181;
                b[1] = 182;
                Delete(b);
            }
            else if(p.HasPermission(280))
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

            ddlType.Items.Insert(0, "--请选择类别--");
    }

    protected void Delete(int[] a)
    { 
         for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < ddlType.Items.Count; j++)
                {
                    if (int.Parse(ddlType.Items[j].Value) == a[i])
                    {
                        ddlType.Items.RemoveAt(j);
                        //j = ddlType.Items.Count;
                       
                    }
                }
            } 
       // ddlType.Items.Insert(0, "--请选择类别--");

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ArticleDetail detail = new ArticleDetail();
        detail.Title = this.txtTitle.Text.Trim();
        detail.Body = this.fckBody.Value.Replace("'", "''");
        detail.PublicationUnit = this.txtUnit.Text.Trim();
        string release = this.txtReleaseDate.Text.Trim();
        if (release == String.Empty) detail.ReleaseDate = DateTime.Now;
        else detail.ReleaseDate = Convert.ToDateTime(release);
        string expire = this.txtExpireDate.Text.Trim();
        if (expire == String.Empty) detail.ExpireDate = DateTime.Now.AddYears(100);
        else detail.ExpireDate = Convert.ToDateTime(expire);
        if (ddlType.SelectedIndex == 0)
        {
            Response.Write("<Script>alert('文章类别不能为空');</Script>");
            return;
        }
        else
            detail.CategoryId = Convert.ToInt32(this.ddlType.SelectedValue);
        
        if (this._articleId != null)
        {
            int articleId = Convert.ToInt32(this._articleId);
            detail.ArticleId = articleId;
            detail.Approved = (int)ViewState["Approved"];
            detail.ViewCount = (int)ViewState["ViewCount"];
            this._article.Update(detail);
            Response.Write("<Script>alert('修改文章成功!');location.href('ArticleList.aspx');</Script>");
        }
        else
        {
            detail.Approved = 0;
            detail.ViewCount = 0;
            detail.AddedUserId = Convert.ToInt32(this._userId);
            int ret=this._article.Add(detail);
            if (ret == -2)
                JSUtility.Alert("该类别只允许添加1篇文章，请到列表中查找然后修改!");
            else
            {
                JSUtility.Alert("添加文章成功!请继续添加！");

                this.txtTitle.Text = String.Empty;
                this.txtUnit.Text = String.Empty;
                this.txtReleaseDate.Text = String.Empty;
                this.txtExpireDate.Text = String.Empty;
                this.fckBody.Value = String.Empty;
                this.ddlType.SelectedIndex = 0;
            }
        }
    }
   
}
