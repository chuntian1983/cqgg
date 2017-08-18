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
using Modules.Picture;

public partial class SysAdmin_Picture_PictureDetail : System.Web.UI.Page
{
    protected string _picPath;
    private string originalPicPath = ConfigurationManager.AppSettings["originalPicPath"];
    private string smallPicPath = ConfigurationManager.AppSettings["smallPicPath"];
    private PictureBLL _picture = new PictureBLL();
    private string _pictureId = HttpContext.Current.Request["PictureId"];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (this._pictureId != null)
            {
                DataRow detail = this._picture.GetPicView(Convert.ToInt32(this._pictureId));
                this._picPath = this.ResolveClientUrl(originalPicPath + detail["OriginalPicPath"].ToString());
                this.lblCategory.Text = detail["Title"].ToString();
                this.lblDescription.Text = detail["Description"].ToString();
                this.lblNickname.Text = detail["Nickname"].ToString();
                this.lblOriginal.Text = this.ResolveUrl(originalPicPath+detail["OriginalPicPath"].ToString());
                this.lblPicName.Text = detail["PicName"].ToString() + detail["extensionName"].ToString();
                this.lblPictureID.Text = detail["PictureId"].ToString();
                this.lblSmall.Text = this.ResolveUrl(smallPicPath + detail["SmallPicPath"].ToString());
                this.lblUploadDate.Text = detail["UploadDate"].ToString();
            }
        }
    }
}
