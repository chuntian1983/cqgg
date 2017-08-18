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
using System.IO;
using Modules.Account;
using Modules.Picture;
using Modules.Log;
using CommonUtility;

public partial class SysAdmin_Picture_UploadPicture : System.Web.UI.Page
{
    private string _pictureId = HttpContext.Current.Request["PictureId"];
    private string _userId = HttpContext.Current.User.Identity.Name;
    private PictureBLL _picture = new PictureBLL();
    private PictureCategoryBLL _category = new PictureCategoryBLL();
    protected string _pageTitle = "上传图片";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            BindPicType();
            if (this._pictureId != null)
            {//只在页面首次加载是验证,减少性能损失
                p.Demand(68);//验证 编辑图片信息 权限
                int pictureId = Convert.ToInt32(this._pictureId);
                this._pageTitle = "修改图片信息";
                this.trPicUpload.Visible = false;
                this.trPicName.Visible = true;
                PictureDetail detail = this._picture.GetPictureDetail(pictureId);
                this.txtPicName.Text = detail.PicName;
                this.txtDescription.Text = detail.Description;
                this.ddlPicType.SelectedValue = detail.CategoryId.ToString();
                fckBody.Value = detail.bz;
            }
            else
            {
                p.Demand(66);//验证 上传图片 权限
                this.trPicUpload.Visible = true;
                this.trPicName.Visible = false;
            }
        }
    }
    private void BindPicType()
    {
        this.ddlPicType.DataSource = this._category.GetAllPicCategories();
        this.ddlPicType.DataTextField = "Title";
        this.ddlPicType.DataValueField = "CategoryId";
        this.ddlPicType.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        PictureDetail detail = new PictureDetail();
        detail.Description = this.txtDescription.Text.Trim();
        detail.CategoryId = Convert.ToInt32(this.ddlPicType.SelectedValue);
        if (this._pictureId != null)
        {
            int pictureId = Convert.ToInt32(this._pictureId);
            detail.PictureId = pictureId;
            detail.PicName = this.txtPicName.Text.Trim();
            detail.bz = fckBody.Value;
            this._picture.UpdateUploadPic(detail);
          //  OperateLog.AddLog(String.Format("修改图片信息 图片标识:{0}", pictureId));
            JSUtility.Alert("修改图片信息成功!");
            JSUtility.CloseWindow();
        }
        else
        {
            string originalPicPath = ConfigurationManager.AppSettings["originalPicPath"].Trim();
            string smallPicPath = ConfigurationManager.AppSettings["smallPicPath"].Trim();
            string smallPicSize = ConfigurationManager.AppSettings["smallPicSize"].Trim();
            int width = Convert.ToInt32(smallPicSize.Split(",".ToCharArray())[0]);
            int height = Convert.ToInt32(smallPicSize.Split(",".ToCharArray())[1]);
            
            DateTime now = DateTime.Now;
            HttpPostedFile pic = Request.Files["picUpload"];
            string mime = pic.ContentType.ToLower();
            if (mime != "image/pjpeg" && mime != "image/gif")
            {
                JSUtility.Alert("上传图片格式不正确!");
                return;
            }
            string fullName = pic.FileName.Substring(pic.FileName.LastIndexOf(@"\") + 1);
            string extensionName = fullName.Substring(fullName.LastIndexOf("."));
            detail.ExtensionName = extensionName;
            detail.SmallPicPath = String.Format("{0}/{1}/{2}{3}", now.Year, now.Month, now.Ticks, extensionName);
            detail.OriginalPicPath = detail.SmallPicPath;
            detail.PicName = fullName.Substring(0, fullName.LastIndexOf("."));
            detail.UploadUserId = Convert.ToInt32(this._userId);
            detail.bz = fckBody.Value;
            detail.deptid= Request.Cookies["__UserInfo"]["deptid"].ToString();
            int id= this._picture.AddUploadPic(detail);
            if (id > 0)
            {
               // OperateLog.AddLog(String.Format("上传图片 图片标识:{0}", id));
                //保存原始图片
                string originalPath = Server.MapPath(originalPicPath + detail.OriginalPicPath);
                string originalCategory = originalPath.Substring(0, originalPath.LastIndexOf(@"\"));
                if (!Directory.Exists(originalCategory))
                {
                    Directory.CreateDirectory(originalCategory);
                }
                pic.SaveAs(originalPath);
                //保存压缩后的小图片
                string smallPath = Server.MapPath(smallPicPath + detail.SmallPicPath);
                string smallCategory = smallPath.Substring(0, smallPath.LastIndexOf(@"\"));
                if (!Directory.Exists(smallCategory))
                {
                    Directory.CreateDirectory(smallCategory);
                }
                ImageUtility.MakeSmallImage(pic, smallPath, width, height);
                this.txtDescription.Text = String.Empty;
                JSUtility.Alert("图片上传成功!");
            }

        }
    }
}
