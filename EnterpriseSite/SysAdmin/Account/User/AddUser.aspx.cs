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
using Modules.Department;
using CommonUtility.DBUtility;


public partial class SysAdmin_Account_User_AddUser : System.Web.UI.Page
{
    private string _userId = HttpContext.Current.Request["UserId"];
    private RoleBLL _role = new RoleBLL();
    private UserBLL _user = new UserBLL();
    private DepartmentCategoryBLL _category = new DepartmentCategoryBLL();
    protected string _pageTitle = "添加用户信息";
    AdoHelper helper = AdoHelper.CreateHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            BindRole();
            BindParentCategory();
            if (this._userId != null)
            {
                p.Demand(15);
                int userId = Convert.ToInt32(this._userId);
                UserDetail detail = this._user.GetUserDetail(userId);
                if (detail != null)
                {
                    this.txtNickname.Text = detail.Nickname;
                    this.txtNickname.Enabled = false;
                    ViewState["PWD"] = detail.Password;
                    this.txtRealname.Text = detail.Realname;
                    this.txtProvince.Text = detail.Province;
                    this.txtCity.Text = detail.City;
                    this.txtAddress.Text = detail.Address;
                    this.txtPostalcode.Text = detail.Postalcode;
                    this.txtTel.Text = detail.Tel;
                    this.txtEmail.Text = detail.Email;
                    this.txtRemark.Text = detail.Remark;
                    ArrayList role = this._user.GetUserRoles(userId);
                    if (role.Count > 0)
                        this.ddlRole.SelectedValue = (role[0]).ToString();
                    this.trPwd.Visible = false;
                    this.trPwdConfirm.Visible = false;
                    ddlParentCategory.SelectedValue = detail.Email;
                }
                this._pageTitle = "修改用户信息";
            }
            else
            {
                p.Demand(14);
            }
        }
    }
    private void BindParentCategory()
    {
        //ArrayList items = this._category.GetSortedDepartmentCategoryItems(4);
        //IEnumerator e = items.GetEnumerator();
        //while (e.MoveNext())
        //{
        //    CategoryEntity item = (CategoryEntity)e.Current;
        //    this.ddlParentCategory.Items.Add(new ListItem(item.Name, item.Id));
        //}
        ArrayList items = new ArrayList();
        if (Request.Cookies["__userinfo"]["deptid"] != null)
        {
            string strid = Request.Cookies["__userinfo"]["deptid"].ToString();
            //是否是顶级
            if (strid == "0")
            {
                items = this._category.GetSortedDepartmentCategoryItems(4);
            }
            else
            {
                items = this._category.GetSortedDepartmentCategoryItems(strid);
            }
        }
        else
        {
            items = this._category.GetSortedDepartmentCategoryItems(4);
        }
        IEnumerator e = items.GetEnumerator();
        while (e.MoveNext())
        {
            CategoryEntity item = (CategoryEntity)e.Current;
            this.ddlParentCategory.Items.Add(new ListItem(item.Name, item.Id));
        }
    }
    private void BindRole()
    {
        this.ddlRole.DataSource = this._role.GetRoleList(new int[]{1,8});
        this.ddlRole.DataTextField = "Name";
        this.ddlRole.DataValueField = "RoleId";
        this.ddlRole.DataBind();
        this.ddlRole.Items.Insert(0, new ListItem("--请选择角色--", "0"));
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int roleId =Convert.ToInt32( this.ddlRole.SelectedValue);

        UserDetail detail = new UserDetail();
        detail.Nickname = this.txtNickname.Text.Trim();
        detail.Realname = this.txtRealname.Text.Trim();
        detail.Province = this.txtProvince.Text.Trim();
        detail.City = this.txtCity.Text.Trim();
        detail.Address = this.txtAddress.Text.Trim();
        detail.Postalcode = this.txtPostalcode.Text.Trim();
        detail.Email = this.ddlParentCategory.SelectedValue;// this.txtEmail.Text.Trim();
        detail.Tel = this.txtTel.Text.Trim();
        detail.Remark = this.txtRemark.Text.Trim();
        detail.Approved = 1;
        detail.RegisterType = 1;
        if (this.txtPwd.Text.Trim() != String.Empty)
            detail.Password = CustomPrincipal.EncryptPassword(this.txtPwd.Text.Trim());
        else
            detail.Password = ViewState["PWD"].ToString();
        if (this._userId != null)
        {
            int userId = Convert.ToInt32(this._userId);
            detail.UserId = userId;
            detail.LastModifiedDate = DateTime.Now.ToShortDateString();
            this._user.Update(detail);
            if (roleId != 0)
                this._user.ChangeUserRole(userId, roleId);
            JSUtility.AlertAndRedirect("修改成功！", "userlist.aspx");
        }
        else
        {
            if (this._user.ExistNickname(detail.Nickname))
            {
                JSUtility.Alert("用户名已经存在!");
                return;
            }
            int id=this._user.Add(detail);
            if (roleId != 0)
            {
                DataTable dtrole = helper.ExecuteDataset("select userid from t_user where nickname='" + detail.Nickname + "'").Tables[0];
                if (dtrole.Rows.Count>0)
                {
                    try
                    {
                        id = int.Parse(dtrole.Rows[0][0].ToString());
                        this._user.ChangeUserRole(id, roleId);
                    }
                    catch { }
                }
                
            }
            this.txtNickname.Text = String.Empty;
            this.txtRealname.Text = String.Empty;
            this.txtProvince.Text = String.Empty;
            this.txtCity.Text = String.Empty;
            this.txtAddress.Text = String.Empty;
            this.txtPostalcode.Text = String.Empty;
            this.txtEmail.Text = String.Empty;
            this.txtTel.Text = String.Empty;
            this.txtRemark.Text = String.Empty;
            this.ddlRole.SelectedIndex = 0;
            JSUtility.Alert("添加用户信息成功！");
        }
    }
}
