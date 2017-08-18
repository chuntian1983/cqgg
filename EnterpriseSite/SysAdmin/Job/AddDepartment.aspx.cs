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
using CommonUtility;
using Modules.Job;
using Modules.Account;

public partial class SysAdmin_Job_AddDepartment : System.Web.UI.Page
{
    private string _departmentId = HttpContext.Current.Request["DepartmentId"];
    private DepartmentBLL _department = new DepartmentBLL();
    protected string _pageTitle = "添加部门信息";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            if (this._departmentId != null)
            {
                p.Demand(128);
                int departmentId = Convert.ToInt32(this._departmentId);
                DepartmentDetail detail = this._department.GetDepartmentDetail(departmentId);
                this.txtName.Text = detail.Name;
                this.txtManager.Text = detail.Manager;
                this.fckIntro.Value = detail.Introduce;
                this._pageTitle = "修改部门信息";
            }
            else
            {
                p.Demand(41);
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DepartmentDetail detail = new DepartmentDetail();
        detail.Name = this.txtName.Text.Trim();
        detail.Manager = this.txtManager.Text.Trim();
        detail.Introduce = this.fckIntro.Value.Trim();
        if (this._departmentId != null)
        {
            int departmentId = Convert.ToInt32(this._departmentId);
            detail.DepartmentId = departmentId;
            this._department.UpdateDepartment(detail);
            JSUtility.AlertAndRedirect("修改部门信息成功!", "DepartmentList.aspx");
        }
        else
        {
            this._department.AddDepartment(detail);
            this.txtName.Text = String.Empty;
            this.txtManager.Text = String.Empty;
            this.fckIntro.Value = String.Empty;
            JSUtility.Alert("添加部门信息成功!");
        }
    }
}
