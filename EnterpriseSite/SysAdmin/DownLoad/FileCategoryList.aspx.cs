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
using Modules.File;
using CommonUtility;
using CommonUtility.DBUtility;

public partial class SysAdmin_DownLoad_FileCategoryList : System.Web.UI.Page
{
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
            p.Demand(36);
            this.AllowDel = p.HasPermission(134);
            this.AllowEdit = p.HasPermission(133);
            this.gvFileCategoryList.Columns[4].Visible = this.AllowEdit || this.AllowDel;
            Bind();
        }
       
    }
    private void Bind()
    {
        this.gvFileCategoryList.DataSource = this._category.GetAllFileCategories();
        this.gvFileCategoryList.DataBind();
    }

    protected void ibtnDel_Command(object sender, CommandEventArgs e)
    {

       
        int categoryId = Convert.ToInt32(e.CommandArgument);
        if (this._category.DeleteCategory(categoryId))
        {
            string sql = "delete from T_File where FileCategoryId=" + categoryId + "";
            SQLHelper.ExecuteSql(sql);
            JSUtility.Alert("删除成功!");
        }
        else
        {
            JSUtility.Alert("删除失败!");
        }
        Bind();
       
    }
}
