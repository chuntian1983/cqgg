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
using Modules.File;
using Modules.Account;
using CommonUtility;
using System.IO;

public partial class SysAdmin_DownLoad_FileUpLoad : System.Web.UI.Page
{
    private string _fileId = HttpContext.Current.Request["FileId"];
    private string _userId = HttpContext.Current.User.Identity.Name;
    private FileBLL _file = new FileBLL();
    private FileCategoryBLL _category = new FileCategoryBLL();
    protected string _pageTitle = "上传文件";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomPrincipal p = new CustomPrincipal(this._userId);
            BindFileType();
            if (this._fileId != null)
            {//只在页面首次加载是验证,减少性能损失
                p.Demand(51);//验证 编辑上传文件信息 权限
                int fileId = Convert.ToInt32(this._fileId);
                this._pageTitle = "修改上传文件信息";
                //this.trFileUpload.Visible = false;
                this.trFileName.Visible = true;
                this.lbWarning.Visible = true;
                FileDetail detail = this._file.GetFileDetail(fileId);
                this.txtFileName.Text = detail.FileName;
                this.lbFilePath.Text = detail.FilePath;//文件的原路径
                this.txtDescription.Text = detail.Description;
                this.ddlFileType.SelectedValue = detail.CategoryId.ToString();
            }
            else
            {
                p.Demand(52);//验证 上传文件 权限
                this.trFileUpload.Visible = true;

               

            }

        }
    }
    private void BindFileType()
    {
        this.ddlFileType.DataSource = this._category.GetAllFileCategories();
        this.ddlFileType.DataTextField = "Title";
        this.ddlFileType.DataValueField = "FileCategoryId";
        this.ddlFileType.DataBind();
    }
    
    FileDetail detail = new FileDetail();
    string mainPath = ConfigurationManager.AppSettings["uploadFilePath"];
   

    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        detail.Description = this.txtDescription.Text.Trim();
        detail.CategoryId = Convert.ToInt32(this.ddlFileType.SelectedValue);
        detail.UploadUserId = Convert.ToInt32(this._userId);
        if (this._fileId != null)
        {
            int fileId = Convert.ToInt32(this._fileId);
            detail.FileId = fileId;
            detail.FileName = this.txtFileName.Text.Trim();
            
            if (this.fileUpload.Value!="")
            {
                UploadFile();
            }
            else
            {
                detail.FilePath = lbFilePath.Text.Trim();
            }
            this._file.UpdateUploadFile(detail);
            JSUtility.AlertAndRedirect("修改上传文件信息成功!", "FileList.aspx");
        }
        else
        {
            if (this.fileUpload.Value == "")
            {
                this.Label1.Visible = true;
                return;
            }
            detail.FileName = this.txtFileName.Text.Trim();
            detail.DownloadCount = 0;
          
            UploadFile();

            JSUtility.AlertAndRedirect("文件上传成功!", "FileList.aspx");

        }

    }


    protected void UploadFile()
    {
        HttpPostedFile file = Request.Files["fileUpload"];
        DateTime now = DateTime.Now;  
        string fullName = file.FileName.Substring(file.FileName.LastIndexOf(@"\") + 1);
        string extensionName = fullName.Substring(fullName.LastIndexOf("."));
        detail.FilePath = String.Format("{0}/{1}/{2}{3}", now.Year, now.Month, now.Ticks, extensionName);
        if (this._fileId != null)
        {
            string path = Server.MapPath(mainPath + detail.FilePath);
            string category = path.Substring(0, path.LastIndexOf(@"\"));
            if (!Directory.Exists(category))
            {
                Directory.CreateDirectory(category);
            }

            file.SaveAs(path);
            this.txtDescription.Text = String.Empty;
        }
        else
        {
            if (this._file.AddUploadFile(detail) > 0)
            {
                string path = Server.MapPath(mainPath + detail.FilePath);
                string category = path.Substring(0, path.LastIndexOf(@"\"));
                if (!Directory.Exists(category))
                {
                    Directory.CreateDirectory(category);
                }

                file.SaveAs(path);
                this.txtDescription.Text = String.Empty;
            }
        }
    }
}
