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
using Modules.Menu;
using Modules.Account;
using CommonUtility;

public partial class SysAdmin_Account_Role_AssignPermission : System.Web.UI.Page
{
    private MenuBLL _menu = new MenuBLL();
    private RoleBLL _role = new RoleBLL();
    private string _roleId = HttpContext.Current.Request["RoleId"];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.treeMenu.Nodes.Add(this._menu.GetMenuTreeWithLimit(false, new int[] {3,10,21,22,23 }));
            if (this._roleId != null)
            { 
                int roleId=Convert.ToInt32(this._roleId);
                this._role.AssignRolePermissionToMenuTree(roleId, this.treeMenu.Nodes[0]);
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this._roleId != null)
        {
            this._role.SaveMenuPermission(Convert.ToInt32(this._roleId), this.treeMenu.Nodes[0]);
            JSUtility.AlertAndRedirect("保存成功!", "RoleList.aspx");
        }
    }
}
