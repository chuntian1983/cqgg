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
using Modules.Picture;
using CommonUtility;

public partial class SysAdmin_Picture_AddCategory : System.Web.UI.Page
{
    private PictureCategoryBLL _category = new PictureCategoryBLL();
    private string _categoryId = HttpContext.Current.Request["CategoryId"];
    private string _userId = HttpContext.Current.User.Identity.Name;
    protected string _pageTitle = "添加图片类别";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            if (this._categoryId != null)
            {
                p.Demand(116);
                int categoryId = Convert.ToInt32(this._categoryId);
                PictureCategoryDetail detail = this._category.GetCategoryDetail(categoryId);
                this.txtType.Text = detail.Title;
                this._pageTitle = "修改图片类别";
            }
            else
            {
                p.Demand(63);
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        PictureCategoryDetail detail = new PictureCategoryDetail();
        detail.Title = this.txtType.Text.Trim();
        if (this._categoryId != null)
        {
            int categoryId = Convert.ToInt32(this._categoryId);
            detail.CategoryId = categoryId;
            this._category.UpdateCategory(detail);
            JSUtility.AlertAndRedirect("修改图片类别成功!", "CategoryList.aspx");
        }
        else
        {
            detail.AddedUserId = Convert.ToInt32(this._userId);
            this._category.AddCategory(detail);
            this.txtType.Text = String.Empty;
            JSUtility.Alert("添加图片类别成功!");
        }
    }
}
