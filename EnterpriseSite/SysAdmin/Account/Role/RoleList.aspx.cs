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

public partial class SysAdmin_Account_Role_RoleList : System.Web.UI.Page
{
    private RoleBLL _role = new RoleBLL();
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
    public bool AllowAssign
    {
        get { return Convert.ToBoolean(ViewState["AllowAssign"]); }
        set { ViewState["AllowAssign"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            p.Demand(12);
            this.AllowEdit = p.HasPermission(19);
            this.AllowDel = p.HasPermission(20);
            this.AllowAssign = p.HasPermission(113);
            this.gvRoleList.Columns[3].Visible = this.AllowAssign || this.AllowDel || this.AllowEdit;
            BindList();
        }
    }

    private void BindList()
    {
        this.gvRoleList.DataSource = this._role.GetRoleList();
        this.gvRoleList.DataBind();
    }
    protected void ibtnDel_Command(object sender, CommandEventArgs e)
    {
        int roleId = Convert.ToInt32(e.CommandArgument);
        this._role.Delete(roleId);
        BindList();
    }
}
