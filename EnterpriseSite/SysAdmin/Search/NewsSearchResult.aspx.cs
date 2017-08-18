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
using CommonUtility;
using Modules.Search;

public partial class SysAdmin_Search_NewsSearchResult : System.Web.UI.Page
{
    private ArticleBLL _article = new ArticleBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["Filter"]=SearchHelper.GetFilterString(new String[]{"a.Title","b.Title","c.Nickname"});
            Bind(0);
        }
    }
    private void Bind(int pageIndex)
    {
        string filter=ViewState["Filter"].ToString();
        DataSet ds = this._article.GetArticleDetailList(filter,"ArticleId desc");
        this.gvArticleList.PageIndex = pageIndex;
        this.gvArticleList.PageSize = this.pageBar.PageSize;
        this.gvArticleList.DataSource = ds;
        this.gvArticleList.DataBind();

        this.pageBar.RecordCount =ds.Tables[0].Rows.Count;
    }
    protected void ibtnDel_Command(object sender, CommandEventArgs e)
    {
        int articleId = Convert.ToInt32(e.CommandArgument);
        this._article.DeleteArticle(articleId);
        Bind(this.pageBar.PageIndex);
    }
    protected void pageBar_PageIndexChanged(object sender, PageIndexChangedEventArguments e)
    {
        Bind(e.NewPageIndex);
    }

    protected void lbtnApprove_Command(object sender, CommandEventArgs e)
    {
        int articleId = Convert.ToInt32(e.CommandArgument);
        this._article.ChangeApprovedStatus(articleId);
        Bind(this.pageBar.PageIndex);
    }
    
}
