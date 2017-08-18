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
using Modules.Job;
using CommonUtility;

public partial class SysAdmin_Job_DepartmentList : System.Web.UI.Page
{
    private DepartmentBLL _department = new DepartmentBLL();

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
            p.Demand(42);
            this.AllowDel = p.HasPermission(129);
            this.AllowEdit = p.HasPermission(128);
            this.gvDepartmentList.Columns[3].Visible = this.AllowEdit || this.AllowDel;
            Bind();
        }
    }
    private void Bind()
    {
        this.gvDepartmentList.DataSource = this._department.GetAllDepartments();
        this.gvDepartmentList.DataBind();
    }

    protected void ibtnDel_Command(object sender, CommandEventArgs e)
    {
        int departmentId = Convert.ToInt32(e.CommandArgument);
        if (this._department.DeleteDepartment(departmentId))
            JSUtility.Alert("删除成功!");
        else
            JSUtility.Alert("删除失败!");
        Bind();
    }
}
