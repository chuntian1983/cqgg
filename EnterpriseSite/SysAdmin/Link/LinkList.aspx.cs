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
using Modules.Link;

public partial class SysAdmin_Link_LinkList : System.Web.UI.Page
{
    private LinkBLL _link = new LinkBLL();
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
            p.Demand(326);
            this.AllowDel = p.HasPermission(328);
            this.AllowEdit = p.HasPermission(329);
            this.gvLinkList.Columns[3].Visible = this.AllowEdit || this.AllowDel;
            Bind();
        }
    }
    private void Bind()
    {
        DataTable dt = new DataTable();
        string deptid=Request.Cookies["__UserInfo"]["deptid"];
        dt = this._link.GetLinkList(" image='"+deptid+"'").Tables[0];
        this.gvLinkList.DataSource = this._link.GetAllLinkDetailes();
        this.gvLinkList.DataBind();
        if (this._link.GetAllLinkDetailes().Tables[0].Rows.Count == 0)
        {
            this.Label1.Text = "暂无数据";
        }
    }

    protected void ibtnDel_Command(object sender, CommandEventArgs e)
    {
        int linkId = Convert.ToInt32(e.CommandArgument);
        this._link.DeleteLink(linkId);
        Bind();
    }
}
