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
using Modules.AD;

public partial class SysAdmin_AD_ADEdit : System.Web.UI.Page
{
    private int ID;
    protected void Page_Load(object sender, EventArgs e)
    {
        ID = Int32.Parse(Request.QueryString["id"].ToString());
        if (!Page.IsPostBack)
        {
            ADBind();
        }
    }

    private void ADBind()
    {

        ADDetail dal = new ADDetail();
        admodel model = new admodel();
        model = dal.GetADOne(ID);

        if (model != null)
        {
            switch (model.Flag)
            {
                case "普通静态广告":
                    ADmargin.Visible = false;
                    break;
                case "任意漂浮广告":
                    break;
                case "左侧滚动广告":
                case "右侧滚动广告":
                case "左侧对联广告":
                case "右侧对联广告":
                    Sidemargin.Disabled = true;
                    break;
                case "弹出广告":
                    NotADPop.Visible = false;
                    IsADPop.Visible = true;
                    fckBody.Value = model.AdCode;
                    break;
                default:
                    break;
            }
            ADFlag.Text = model.Flag;
            ADBoard.Text = model.BoardName;
            Sidemargin.Value = model.Sidemargin.ToString();
            Topmargin.Value = model.Topmargin.ToString();
            Title.Value = model.Title;
            Url.Value = model.Url;
            Readme.Value = model.Readme;
            ImageUrl.Value = model.PicUrl;
           
            Width.Value = model.Width.ToString();
            lblFitWidth.Text = model.FitWidth.ToString();//推荐宽度
            lblFitHeight.Text = model.FitHeight.ToString();//推荐高度
            Height.Value = model.Height.ToString();
            if (model.IsLock == "显示")
                Show1.Checked = true;
            else
                Show2.Checked = true;
            ADBoardID.Value = model.BoardID.ToString();
        }
        else
        {
            Response.Write("<script>alert('无记录');</script>");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ADDetail dal = new ADDetail();
        admodel model = new admodel();

        model.ADID = ID;
        model.BoardID = int.Parse(ADBoardID.Value);

        model.Title = Title.Value;
        model.Url = Url.Value;
        string picurl =ImageUrl.Value;
        model.PicUrl = picurl;
        model.Readme = Readme.Value;
        model.AdCode = fckBody.Value;
        model.Width = int.Parse(Width.Value);
        model.Height = int.Parse(Height.Value);
        model.Topmargin = int.Parse(Topmargin.Value);
        model.Sidemargin = int.Parse(Sidemargin.Value);
        model.StartTime = DateTime.Now;

        if (ImageUrl.Value != "")
        {
            if (ImageUrl.Value.Substring(ImageUrl.Value.LastIndexOf(".") + 1, 3).ToString() == "swf")
            {
                model.PicOrFlash = true;
            }
            else
            {
                model.PicOrFlash = false;
            }
        }
        else
        {
            model.PicOrFlash = false;
        }

        if (Show1.Checked == true)
        {
            model.IsLock = "显示";
        }
        else
        {
            model.IsLock = "未显示";
        }

        dal.EditAD(model);
        Response.Write("<script language='javascript'>alert('修改成功');location.href='ADList.aspx';</script>");	
    }
}
