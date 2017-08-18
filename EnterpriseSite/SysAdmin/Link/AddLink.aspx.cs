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
using Modules.Account;
using Modules.Link;
using CommonUtility;

public partial class SysAdmin_Link_AddLink : System.Web.UI.Page
{
    private LinkBLL _link = new LinkBLL();
    private string _linkId = HttpContext.Current.Request["LinkId"];
    protected string _pageTitle = "添加友情连接";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            if (this._linkId != null)
            {
                //p.Demand(126);
                int linkId = Convert.ToInt32(this._linkId);
                LinkDetail detail = this._link.GetLinkDetail(linkId);
                this.txtTitle.Text = detail.Title;
                this.txtLink.Text = detail.Link;
                this.txtImage.Text = detail.Image;
                this.txtSort.Text = detail.Sort.ToString();
                this.ddlDisplayMode.SelectedValue = detail.DisplayMode.ToString();
                this._pageTitle = "修改友情连接";
            }
            else
            {
                //p.Demand(49);
            }
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        LinkDetail detail = new LinkDetail();
        detail.Title = this.txtTitle.Text.Trim();
        detail.Link = this.txtLink.Text.Trim();
        detail.Image = this.txtImage.Text.Trim();
        detail.Sort = Convert.ToInt32(this.txtSort.Text.Trim());
        detail.DisplayMode = Convert.ToInt32(this.ddlDisplayMode.SelectedValue);
        if (Request.Cookies["__UserInfo"]["deptid"] != null)
        {
            detail.deptid = Request.Cookies["__UserInfo"]["deptid"];
        }
        //detail.DisplayMode = 1;//文字
        if (this._linkId != null)
        {
            detail.LinkId = Convert.ToInt32(this._linkId);
            this._link.UpdateLink(detail);
            JSUtility.AlertAndRedirect("修改友情连接成功!", "linklist.aspx");
        }
        else
        {
            this._link.AddLink(detail);
            JSUtility.Alert("添加友情连接成功!");
            this.txtTitle.Text = String.Empty;
            this.txtLink.Text = String.Empty;
            this.txtImage.Text = String.Empty;
            this.txtSort.Text = String.Empty;
            this.ddlDisplayMode.SelectedIndex = 0;
        }
    }
}
