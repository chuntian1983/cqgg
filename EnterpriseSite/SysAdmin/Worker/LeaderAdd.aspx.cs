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
using Modules.Workers;
using Modules.Article;
using System.Text;
using Modules.Account;

public partial class SysAdmin_Worker_LeaderAdd : System.Web.UI.Page
{
    private string AllowFileType = "jpg|gif|swf";
    WorkerDAL dal = new WorkerDAL();
    WorkerModel model = new WorkerModel();
    ArticleDAL1 dal1 = new ArticleDAL1();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            p.Demand(170);
            if (Request.QueryString["WorkerId"] != null && Request.QueryString["WorkerId"].ToString() != "")
            {
                int workerid = Int32.Parse(Request.QueryString["WorkerId"].ToString());
                PageBill(workerid);
                BindWorker();
            }
        }
    }

    protected void PageBill(int WorkeID)
    {

        model = dal.GetModel(WorkeID);
        this.txtName.Text = model.Name.ToString();
        PageBind(this.txtName.Text);
        this.txtBusiness.Text = model.Business.ToString();
        this.txtScience.Text = model.Science.ToString();
        this.txtArea.Text = model.Area.ToString();
        this.txtEmail.Text = model.Email.ToString();
        this.txtResume.Value = model.Resume.ToString();
        this.txtTel.Text = model.WorkTel.ToString();
        this.txtSortID.Text = model.Sort.ToString();
        this.txtpicurlhide.Text = model.ImgLink.ToString();
        this.lbAddDate.Text = model.AddDate.ToShortDateString();
        string PersonPic = System.Configuration.ConfigurationSettings.AppSettings["PersonPicPath"].ToString();
        this.uploadimage.Src = PersonPic + model.ImgLink.ToString();
    }

    protected void PageBind(string Name)
    {
       
        DataSet ds = dal1.GetLeaderSpeak(Name);
        if (ds.Tables[0].Rows.Count > 0)
        {
            this.gvArticleList.Visible = true;
            this.gvArticleList.DataSource = ds;
            this.gvArticleList.DataBind();
        }
    }

    public string SaveImg()
    {
        string SaveFileName = string.Empty;
        string SaveFileType = string.Empty;
        string SaveImgUrl = string.Empty;
        string ErrMsg = "";

        if (FileUp.PostedFile.ContentLength == 0)
        {
            ErrMsg = "请选择要上传的文件！";
            Response.Write("<script language=javascript>alert('" + ErrMsg + "');history.go(-1);</script>");
        }
        else if (FileUp.PostedFile.ContentLength / 1024 > 1024)
        {
            ErrMsg = "文件大小不得超过1M！";
            Response.Write("<script language=javascript>alert('" + ErrMsg + "');history.go(-1);</script>");
        }
        else
        {
            //获取上传文件属性
            SaveFileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() +
                        DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            SaveFileType = FileUp.PostedFile.FileName.Substring(FileUp.PostedFile.FileName.Length - 3, 3);//文件类型

            string PersonPic = System.Configuration.ConfigurationSettings.AppSettings["PersonPicPath"].ToString();
            SaveImgUrl = Server.MapPath(PersonPic + SaveFileName + "." + SaveFileType);//保存物理路径

            if (AllowFileType.IndexOf(SaveFileType.ToLower()) == -1)//判断上传文件的类型(后缀)
            {
                ErrMsg = "请上传正确的文件类型！";
                Response.Write("<script language=javascript>alert('" + ErrMsg + "');history.go(-1);</script>");
            }
            else
            {
                FileUp.PostedFile.SaveAs(SaveImgUrl);
            }
        }
        if (SaveFileName == "" && SaveFileType == "")
        {
            return "";
        }
        else
        {
            return SaveFileName + "." + SaveFileType;
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (this.txtName.Text == "")
        {
            this.lbwarning.Text = "请输入姓名";
            this.lbwarning.Visible = true;
            return;
        }
        else
        {
            model.Name = this.txtName.Text;
        }
        //图片上传
        if (Request.QueryString["WorkerId"] != null)
        {
            if (FileUp.PostedFile.ContentLength == 0)
            {
                //将原来的地址重新赋给model
                model.ImgLink = this.txtpicurlhide.Text;
            }
            else
            {
                model.ImgLink = SaveImg();
            }
        }
        else
        {
            if (FileUp.PostedFile.ContentLength == 0)
            {
                //不上传文件
                model.ImgLink = "";
            }
            else
            {
                model.ImgLink = SaveImg();
            }
        }
        model.Business = this.txtBusiness.Text;
        model.Science = this.txtScience.Text;
        model.Area = this.txtArea.Text;
        model.WorkTel = this.txtTel.Text;
        model.Email = this.txtEmail.Text;
        model.Resume = this.txtResume.Value;
        model.Sort = Int32.Parse(this.txtSortID.Text.ToString());
        model.PersonType = 0;
        model.Degree = "";
        model.MZTel = "";
        model.OfficeTel = "";
        model.LookTime = "";
        model.Prize = "";
        model.Depart = 0;
        if (Request.QueryString["WorkerId"] != null)
        {
            model.AddDate = DateTime.Parse(this.lbAddDate.Text.ToString());
            int workId = Int32.Parse(Request.QueryString["WorkerId"].ToString());
            model.ID = workId;
            dal.Update(model);
            Response.Write("<Script>alert('你已成功修改！');location.href('Leaderlist.aspx');</Script>");
        }
        else
        {
            model.AddDate = DateTime.Now;
            dal.Add(model);
            Response.Write("<Script>alert('你已成功添加！');location.href('Leaderlist.aspx');</Script>");
        }
    }

    protected void ibtnDel_Command(object sender, CommandEventArgs e)
    {
        int articleId = Convert.ToInt32(e.CommandArgument);
        dal1.Delete(articleId);
        PageBind(this.txtName.Text);
    }

    


    protected void pageBar_PageIndexChanged(object sender, PageIndexChangedEventArguments e)
    {
        BindWorker();
    }

    private void BindWorker()
    {
        int count;
        string filter = this.SetFilter();
        string sort = "ReleaseDate desc,ArticleId";
        int index = this.pageBar.PageIndex;
        int size = this.pageBar.PageSize;
        this.gvArticleList.DataSource = dal1.GetSpeakList("*", filter, sort, index, size, out count);
        this.gvArticleList.DataBind();
        this.pageBar.RecordCount = count;
    }

    private string SetFilter()
    {
        StringBuilder filter = new StringBuilder();
        filter.Append("1=1");
        filter.Append(" and PublicationUnit='"+this.txtName.Text+"'");
        ViewState["Filter"] = filter.ToString();
        return filter.ToString();
    }
}
