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
using Modules.News;
using Modules.Account;
using Modules.File;
using CommonUtility;
using System.IO;
using Modules.News;



public partial class SysAdmin_News_AddOrEditArticle : System.Web.UI.Page
{
    private string _articleId = HttpContext.Current.Request["ArticleId"];
    private NewsBLL _article = new NewsBLL();
    private NewsCategoryBLL _category = new NewsCategoryBLL();
    private string _userId = HttpContext.Current.User.Identity.Name;
    protected string _pageTitle = "添加文章";
    public string ContentInfo = string.Empty;
    NewsDAL1 dal2 = new NewsDAL1();
    CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
    int[] b = new int[40];

    //页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.txtReleaseDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
            BindCategory();
            if (this._articleId != null)
            {
                p.Demand(164);
                int articleId = Convert.ToInt32(this._articleId);
                NewsDetail detail = this._article.GetArticleDetail(articleId);
                this.txtTitle.Text = detail.Title;
          
                this.content1.Value = detail.Body;
                this.txtUnit.Text = detail.PublicationUnit;
                this.txtReleaseDate.Text = detail.ReleaseDate;
                this.txtExpireDate.Text =detail.ExpireDate;
                this.ddlType.SelectedValue = detail.CategoryId.ToString();
                if (this.ddlType.SelectedValue == "122")
                {
                    this.Label1.Text = "医疗服务名称";
                    this.a.Visible = true;
                    this.txtPrice.Text = detail.ImgLink;
                }
                if (this.ddlType.SelectedValue == "104")
                {
                    this.aa.Visible = true;
                    if (detail.IsState== 1)
                    {
                        this.CheckBox1.Checked = true;
                        this.bb.Visible = true;
                        this.txtImageLink.Text = detail.ImgLink.ToString();
                    }
                }
                ViewState["Approved"] = detail.Approved;
                ViewState["ViewCount"] = detail.ViewCount;
                this._pageTitle = "修改文章";
                this.spanBack.Visible = true;
            }
            else
            {
                p.Demand(162);
            }
        }
    }

    //绑定下拉选择框数据
    private void BindCategory()
    {
        ArrayList items = this._category.GetSortedArticleCategoryItems(5);
        IEnumerator e = items.GetEnumerator();
        while (e.MoveNext())
        {
            CategoryEntity item = (CategoryEntity)e.Current;
            this.ddlType.Items.Add(new ListItem(item.Name, item.Id));
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
            if(p.HasPermission(299)==false)
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

        ddlType.Items.Insert(0, "--请选择类别--");

    }
    //确定按纽
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        NewsDetail detail = new NewsDetail();
        if (this._articleId != null)
        {
          detail=  this._article.GetArticleDetail(int.Parse(this._articleId));
        }
        detail.Title = this.txtTitle.Text.Trim();
        detail.Body = this.content1.Value;
     
        detail.PublicationUnit = this.txtUnit.Text.Trim();
        string release = this.txtReleaseDate.Text.Trim();
        if (release == String.Empty) detail.ReleaseDate = DateTime.Now.ToString();
        else detail.ReleaseDate =release;
        string expire = this.txtExpireDate.Text.Trim();
        if (expire == String.Empty) detail.ExpireDate = DateTime.Now.AddYears(100).ToString();
        else detail.ExpireDate = expire;
        if (ddlType.SelectedIndex == 0)
        {
            Response.Write("<Script>alert('文章类别不能为空');</Script>");
            return;
        }
        else
            detail.CategoryId = Convert.ToInt32(this.ddlType.SelectedValue);
        if (this.ddlType.SelectedValue == "122")
        {
            detail.ImgLink = this.txtPrice.Text;
        }
        else if(this.ddlType.SelectedValue=="104")
        {
            if (this.txtImageLink.Text != "")
            {
                //判断是否存在本院新闻
                bool result = dal2.CheckNews();
                if (result == true)
                {
                    //更新本院新闻的图片显示状态
                    dal2.UpdateState();
                }

                detail.ImgLink = this.txtImageLink.Text;
                detail.IsState = 1;
            }
            else
            {
                detail.ImgLink = "";
                detail.IsState = 0;
            }
          
                
        }
        
        if (this._articleId != null)
        {
            int articleId = Convert.ToInt32(this._articleId);
            detail.NewsId = articleId;
            detail.Approved = (int)ViewState["Approved"];
            detail.ViewCount = (int)ViewState["ViewCount"];
            this._article.Update(detail);
            Response.Write("<Script>alert('修改文章成功!');location.href('ArticleList.aspx');</Script>");
        }
        else
        {
            UserDetail ud = new UserDetail();
            UserBLL ubl = new UserBLL();
            ud = ubl.GetUserDetail(int.Parse(this._userId));
            detail.ImgLink = ud.Email;
            detail.Approved = 0;
            detail.ViewCount = 0;
            detail.AddedUserId = Convert.ToInt32(this._userId);
            int ret = this._article.Add(detail);
            if (ret == -2)
                JSUtility.Alert("该类别只允许添加1篇文章，请到列表中查找然后修改!");
            else
            {
                JSUtility.Alert("添加文章成功!请继续添加！");

                this.txtTitle.Text = String.Empty;
                this.txtUnit.Text = String.Empty;
                this.txtReleaseDate.Text = String.Empty;
                this.txtExpireDate.Text = String.Empty;
                
                this.content1.Value = string.Empty;
                this.txtPrice.Text = string.Empty;
                this.a.Visible = false;
                this.Label1.Text = "新闻名称";
                this.ddlType.SelectedIndex = 0;
                this.CheckBox1.Checked = false;
                this.txtImageLink.Text = "";
                this.bb.Visible = false;
                this.aa.Visible = false;
                this.txtReleaseDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
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

    //选择新闻类型
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlType.SelectedValue == "122")
        {
            this.Label1.Text = "医疗服务名称";
            this.a.Visible = true;
        }
        else
        {
            this.Label1.Text = "新闻名称";
            this.a.Visible = false;
        }
        if (this.ddlType.SelectedValue == "104")
        {
            this.aa.Visible = true;
        }
        else
        {
            this.aa.Visible = false;
        }
    }

    //上传附件
    protected void Button1_Click(object sender, EventArgs e)
    {
        FileModel1 model1 = new FileModel1();
        FileDAL1 dal1 = new FileDAL1();
        //确定上传文件
        if (this.fileUpload.PostedFile.ContentLength > 0)
        {
            string mainPath = ConfigurationManager.AppSettings["uploadFilePath"];
            DateTime now=DateTime.Now;
            HttpPostedFile file=Request.Files["fileUpload"];
            string fullName=file.FileName.Substring(file.FileName.LastIndexOf(@"\")+1);
            string extensionName = fullName.Substring(fullName.LastIndexOf("."));
            model1.FilePath = String.Format("{0}/{1}/{2}{3}", now.Year, now.Month, now.Ticks, extensionName);
            model1.FileName = this.txtFileName.Text.Trim();
            model1.DownloadCount = 0;
            model1.Description = this.txtDescription.Text.ToString();
            model1.FileCategoryId = 100;
            model1.UploadDate = DateTime.Now;
            string path = mainPath + model1.FilePath;
            string spath = Server.MapPath(mainPath + String.Format("{0}/{1}", now.Year, now.Month));
            if (File.Exists(spath))
            {
                file.SaveAs(Server.MapPath(path));
            }
            else
            {
                File.Create(spath);
                file.SaveAs(Server.MapPath(path));
            }
            //dal1.Add(model1);
            JSUtility.Alert("附件上传成功！");
            //---------
            ContentInfo = this.content1.Value.ToString();
            string url = "<a href='" + this.ResolveUrl(path) + "'>" + model1.FileName + "</a>";
            this.content1.Value = ContentInfo+url;
            //---------
            this.txtFileName.Text = "";
            this.txtDescription.Text = "";
        }
    }

    //上传首页图片
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (this.CheckBox1.Checked == true)
        {
            this.bb.Visible = true;
        }
        else
        {
            this.bb.Visible = false;
        }
    }
}
