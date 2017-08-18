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
using System.Drawing;
using System.Text;

public partial class SysAdmin_AD_upload : System.Web.UI.Page
{
    private string UploadType = string.Empty;
    private string AllowFileType = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        UploadType = Request.QueryString["UploadType"].ToString();
      
        switch (UploadType)
        {
            case "Pic":
                AllowFileType = "jpg|gif|swf";
                break;
            case "Ad":
                AllowFileType = "jpg|gif|swf";
                break;
            case "File":
                break;
            case "Media":
                break;
            default:
                break;
        }
    }

    protected void UploadFile(object sender, EventArgs e)
    {
        string ErrMsg = "";

        if (FileUp.PostedFile.ContentLength == 0)
        {
            ErrMsg = "请选择要上传的文件！";
            FileInfo.Visible = false;
            Response.Write("<script language=javascript>alert('" + ErrMsg + "');history.go(-1);</script>");
        }
        else if (FileUp.PostedFile.ContentLength / 1024 > 1024)
        {
            ErrMsg = "文件大小不得超过1M！";
            FileInfo.Visible = false;
            Response.Write("<script language=javascript>alert('" + ErrMsg + "');history.go(-1);</script>");
        }
        else if (UploadType == "Pic")
        {
            //获取上传文件属性
            string SaveFileName;
            string SaveFileType;
            string SaveImgUrl;

            SaveFileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            SaveFileType = FileUp.PostedFile.FileName.Substring(FileUp.PostedFile.FileName.Length - 3, 3);//文件类型

            string ADPic = ConfigurationSettings.AppSettings["uploadADPath"].ToString();

            SaveImgUrl = Server.MapPath(ADPic + SaveFileName + "." + SaveFileType);//保存物理路径

            if (AllowFileType.IndexOf(SaveFileType.ToLower()) == -1)//判断上传文件的类型(后缀)
            {
                ErrMsg = "请上传正确的文件类型！";
                FileInfo.Visible = false;
                Response.Write("<script language=javascript>alert('" + ErrMsg + "');history.go(-1);</script>");
            }
            else
            {
                if (Session["TypePic"] != null)
                {
                    if (Session["TypePic"].ToString() != "")
                    {
                        Session.Remove("TypePic");
                    }
                }
                FSize.Text = (FileUp.PostedFile.ContentLength / 1024).ToString() + "KB";
                FName.Text = FileUp.PostedFile.FileName + "<br>" + FName.Text;
                FileInfo.Visible = true;
                PanelUp.Visible = false;
                FileUp.PostedFile.SaveAs(SaveImgUrl);
                Session["TypePic"] = SaveFileName + "." + SaveFileType;

                Response.Write("<script language=javascript>parent.document.getElementById('uploadimage').src=file:///'" + SaveImgUrl + "';</script>");
            }
        }
        else
        {
            //获取上传文件属性
            string SaveFileName;
            string SaveFileType;
            string SaveImgUrl;

            SaveFileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            SaveFileType = FileUp.PostedFile.FileName.Substring(FileUp.PostedFile.FileName.Length - 3, 3);
            // SaveImgUrl = "upload/" + SaveFileName + "." + SaveFileType;
            SaveImgUrl ="upload/"+ SaveFileName + "." + SaveFileType;   

            if (AllowFileType.IndexOf(SaveFileType) == -1)
            {
                ErrMsg = "请上传正确的文件类型！";
                FileInfo.Visible = false;
                Response.Write("<script language=javascript>alert('" + ErrMsg + "');history.go(-1);</script>");
            }
            else
            {
                FSize.Text = (FileUp.PostedFile.ContentLength / 1024).ToString() + "KB";

                FileInfo.Visible = true;

                //保存图片
                FileUp.PostedFile.SaveAs(Server.MapPath(SaveImgUrl));
                Session["imgurl"] = SaveImgUrl;
                Response.Write("<script language='javascript'>parent.document.getElementById('ImageUrl').value='" + SaveImgUrl + "';</script>");
            }
        }
    }
}
