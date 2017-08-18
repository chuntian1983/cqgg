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
using CommonUtility;

public partial class SysAdmin_Account_Role_addRole : System.Web.UI.Page
{
    private string _roleId = HttpContext.Current.Request["RoleId"];
    private RoleBLL _role = new RoleBLL();
    protected string _pageTitle = "添加角色";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            if (this._roleId != null)
            {
                p.Demand(19);
                int roleId = Convert.ToInt32(this._roleId);
                RoleDetail detail = this._role.GetRoleDetail(roleId);
                if (detail != null)
                {
                    this.txtName.Text = detail.Name;
                    this.txtRemark.Text = detail.Remark;
                    this.txtSort.Text = detail.Sort.ToString();
                }
                else JSUtility.Alert("该角色不存在!");
                this._pageTitle = "修改角色";
            }
            else
            {
                p.Demand(18);
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        RoleDetail detail = new RoleDetail();
        detail.Name = this.txtName.Text.Trim();
        detail.Remark = this.txtRemark.Text.Trim();
        detail.Sort = Convert.ToInt32(this.txtSort.Text.Trim());
        if (this._roleId != null)
        {
            detail.RoleID = Convert.ToInt32(this._roleId);
            detail.LastModifiedDate = DateTime.Now.ToString();
            if (this._role.Update(detail)) JSUtility.AlertAndRedirect("更新成功!","RoleList.aspx");
            else JSUtility.Alert("更新失败!");
        }
        else
        {
            detail.AddedUserId = Convert.ToInt32(User.Identity.Name);
            this._role.Add(detail);
            this.txtName.Text = String.Empty;
            this.txtRemark.Text = String.Empty;
            this.txtSort.Text = String.Empty;
            JSUtility.Alert("添加成功!");
        }
    }
}
