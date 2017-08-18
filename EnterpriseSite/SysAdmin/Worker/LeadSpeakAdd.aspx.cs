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
using Modules.Workers;

public partial class SysAdmin_Worker_LeadSpeakAdd : System.Web.UI.Page
{
    private string _userId = HttpContext.Current.User.Identity.Name;
    ArticleDAL1 dal1 = new ArticleDAL1();
    ArticleModel1 model = new ArticleModel1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if(Request.QueryString["ArticleId"]!=null && Request.QueryString["ArticleId"].ToString()!="")
            {
                int articleId = Int32.Parse(Request.QueryString["ArticleId"].ToString());
                PageBind(articleId);
            }
            if (Request.QueryString["WorkerId"] != null && Request.QueryString["WorkerId"].ToString() != "")
            {
                int workerId = Int32.Parse(Request.QueryString["WorkerId"].ToString());
                PageBill(workerId);
            }
        }
    }

    protected void PageBind(int articleid)
    {
        model = dal1.GetModel(articleid);
        this.txtTitle.Text = model.Title;
        this.lbSpeaker.Text = model.PublicationUnit;
        this.txtReleaseDate.Text = model.ReleaseDate;
        this.Label1.Text = this.txtReleaseDate.Text.Trim();
        this.txtContent.Value = model.Body;
    }

    protected void PageBill(int workerid)
    {
        WorkerDAL dal = new WorkerDAL();
        this.lbSpeaker.Text = dal.GetPersonNameById(workerid);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      
        if (this.txtTitle.Text == "")
        {
            this.lbWarning.Text = "文章标题不能为空！";
            this.lbWarning.Visible = true;
            return;
        }
        else 
        {
            model.Title = this.txtTitle.Text;
        }
        model.PublicationUnit = this.lbSpeaker.Text;
        if (this.txtReleaseDate.Text != "")
        {
            model.ReleaseDate = this.txtReleaseDate.Text.ToString();
        }
        else if(this.txtReleaseDate.Text.ToString()==this.Label1.Text && this.txtReleaseDate.Text!="")
        {
            model.ReleaseDate = this.Label1.Text.ToString();
        }
        else
        {
            model.ReleaseDate = DateTime.Now.ToString();
        }
        model.Body = this.txtContent.Value;
        model.AddedUserId = Int32.Parse(this._userId);
        model.AddedDate = DateTime.Now.ToString();
        model.ExpireDate = DateTime.Now.ToString();
        model.CategoryId = 1000;
        model.Approved = 0;
        model.ViewCount = 0;
        if (Request.QueryString["ArticleId"] != null)
        {
            model.ArticleId = Int32.Parse(Request.QueryString["ArticleId"].ToString());
            dal1.Update(model);
            Response.Write("<Script>alert('你已成功修改！');location.href('Leaderlist.aspx');</Script>");
        }
        else
        { 
            dal1.Add(model);
            Response.Write("<Script>alert('你已成功添加！');location.href('Leaderlist.aspx');</Script>");
        }
        
    }
}
