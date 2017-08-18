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

public partial class SysAdmin_DownLoad_FileList : System.Web.UI.Page
{
    private FileBLL _file = new FileBLL();
    private string _mainPath = ConfigurationSettings.AppSettings["uploadFilePath"];
    private FileCategoryBLL _category = new FileCategoryBLL();

    public bool AllowEdit
    {
        get { return Convert.ToBoolean(ViewState["AllowEdit"]); }
        set { ViewState["AllowEdit"] = value; }
    }

    public bool AllowDel
    {
        get { return Convert.ToBoolean(ViewState["AllowDel"]); }
        set { ViewState["AllowDel"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            p.Demand(38);
            this.AllowDel = p.HasPermission(53);
            this.AllowEdit = p.HasPermission(51);
            this.gvFileList.Columns[5].Visible = p.HasPermission(54);
            this.gvFileList.Columns[6].Visible = this.AllowEdit || this.AllowDel;

            if (Request.QueryString["CategoryName"] != null && Request.QueryString["CategoryName"].ToString() != "")
            {
                string categoryName = Request.QueryString["CategoryName"].ToString().Trim();
                DataSet ds = this._file.GetFileByCategoryName(categoryName);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.gvFileList.DataSource = ds;
                    this.gvFileList.DataBind();
                    this.gvFileList.Visible = false;
                    this.Label1.Visible = false; 
                }
            }
            else
            {
                Bind(0);
                BindFileType();
            }
           
        }
    }


  

    private void Bind(int pageIndex)
    {
        DataSet ds = this._file.GetAllFilesDetailInfo();
        this.gvFileList.PageIndex = pageIndex;
        this.gvFileList.PageSize = this.pageBar.PageSize;
        this.gvFileList.DataSource = ds;
        this.gvFileList.DataBind();

        this.pageBar.RecordCount = ds.Tables[0].Rows.Count;
    }
    protected void ibtnDel_Command(object sender, CommandEventArgs e)
    {
        int fileId = Convert.ToInt32(e.CommandArgument);
        string path =this._mainPath + this._file.GetFileDetail(fileId).FilePath;
        if(this._file.DeleteUploadFile(fileId))
        {
            try
            {
                File.Delete(Server.MapPath(path));
            }
            catch
            { throw; }
        }
        Bind(this.pageBar.PageIndex);
    }
    protected void pageBar_PageIndexChanged(object sender, PageIndexChangedEventArguments e)
    {
        Bind(e.NewPageIndex);
    }

    protected void lbtnDownload_Command(object sender, CommandEventArgs e)
    {
        int fileId = Convert.ToInt32(e.CommandArgument);
        bool isSuccess = true;
        FileDetail detail = this._file.GetFileDetail(fileId);
        string extensionName = detail.FilePath.Substring(detail.FilePath.LastIndexOf("."));
        string fileName = String.Format("attachment; filename=\"{0}{1}\"", HttpUtility.UrlEncode(detail.FileName), extensionName);
        string path = Server.MapPath(this._mainPath + detail.FilePath);
        try
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", fileName);
            Response.AddHeader("Content-Length", fs.Length.ToString());
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);
            Response.BinaryWrite(buffer);
        }
        catch (Exception ex)
        {
            isSuccess = false;
            Context.Response.ClearHeaders();
            Context.Response.Clear();
            Context.Response.ContentType = "text/html";
            //Context.Response.Write("<script>alert('" + ex.Message + "');</script>");
            JSUtility.Alert(ex.Message);
        }
        if (isSuccess) Context.Response.End();
    }


    //绑定文件类别
    private void BindFileType()
    {
        this.ddlFileType.DataSource = this._category.GetAllFileCategories();
        this.ddlFileType.DataTextField = "Title";
        this.ddlFileType.DataValueField = "FileCategoryId";
        this.ddlFileType.DataBind();
    }
   
    //根据所选文件类别取得该类别下的文件列表

    protected void ddlFileType_SelectedIndexChanged(object sender, EventArgs e)
    {
        int CategoryId = Int32.Parse(this.ddlFileType.SelectedValue.ToString());
      
        DataSet ds = this._file.GetFileByCategoryId(CategoryId);
     
            this.gvFileList.DataSource = ds;
            this.gvFileList.DataBind();
        
    }
}
