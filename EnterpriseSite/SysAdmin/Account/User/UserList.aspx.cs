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

public partial class SysAdmin_Account_User_UserList : System.Web.UI.Page
{
    private UserBLL _user = new UserBLL();
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
    public bool AllowApprove
    {
        get { return Convert.ToBoolean(ViewState["AllowApprove"]); }
        set { ViewState["AllowApprove"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            p.Demand(13);
            this.AllowEdit = p.HasPermission(15);
            this.AllowDel = p.HasPermission(17);
            this.AllowApprove = p.HasPermission(114);
            this.gvUserList.Columns[6].Visible = this.AllowDel || this.AllowEdit;
            Bind();
        }
    }

    private void Bind()
    {
        //wh edit deptid or deptchildid
        string id = "";
        if (Request.Cookies["__UserInfo"]["deptid"] != null)
        {
            id = Request.Cookies["__UserInfo"]["deptid"].ToString();
            string strid = this._user.GetDeptid(id);
            if (id == "0")
            {
                this.trcx.Visible = true;
                string strwhere = "";
                if (!string.IsNullOrEmpty(this.TextBox1.Text))
                {
                    strwhere = " and a.nickname like '%" + this.TextBox1.Text + "%'";
                }
                this.gvUserList.DataSource = this._user.GetUsers("a.RegisterType=1 " + strwhere + " ");
                //strid = strid + "," + "0";
            }
            else
            {
                this.gvUserList.DataSource = this._user.GetUsers("a.RegisterType=1 and email in(" + strid + ")");
            }
        }
        else
        {
            this.gvUserList.DataSource = this._user.GetUsers("a.RegisterType=1 ");
        }

        this.DataBind();
        ////this.gvUserList.DataSource = this._user.GetUserList("RegisterType=1", "UserId");
        //this.gvUserList.DataSource = this._user.GetUsers("a.RegisterType=1");
        //this.DataBind();
    }
    protected void lbtnApprove_Command(object sender, CommandEventArgs e)
    {
        int userId = Convert.ToInt32(e.CommandArgument);
        this._user.ChangeApprovedStatus(userId);
        Bind();
    }

    protected void ibtnDel_Command(object sender, CommandEventArgs e)
    {
        int userId = Convert.ToInt32(e.CommandArgument);
        //this._user.Delete(userId);
        this._user.DeleteUserChange(userId);
        Bind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Bind();
    }
}
