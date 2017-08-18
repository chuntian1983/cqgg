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

public partial class SysAdmin_Picture_CategoryList : System.Web.UI.Page
{
    private PictureCategoryBLL _category = new PictureCategoryBLL();
    public bool AllowDel
    {
        get { return Convert.ToBoolean(ViewState["AllowDel"]); }
        set { ViewState["AllowDel"] = value; }
    }
    public bool AllowEdit
    {
        get { return Convert.ToBoolean(ViewState["AllowEdit"]); }
        set { ViewState["AllowEdit"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            p.Demand(64);
            this.AllowDel = p.HasPermission(117);
            this.AllowEdit = p.HasPermission(116);
            //this.gvPictureCategoryList.Columns[4].Visible = this.AllowEdit || this.AllowDel;
            Bind();
        }
    }
    private void Bind()
    {
        this.gvPictureCategoryList.DataSource = this._category.GetAllPicCategories();
        this.gvPictureCategoryList.DataBind();
    }

    protected void ibtnDel_Command(object sender, CommandEventArgs e)
    {
        int categoryId = Convert.ToInt32(e.CommandArgument);
        if (this._category.DeleteCategory(categoryId))
            JSUtility.Alert("删除成功!");
        else
            JSUtility.Alert("删除失败!");
        Bind();
    }
}
