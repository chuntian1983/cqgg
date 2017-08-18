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
using Modules.Search;

public partial class SysAdmin_Search_MemberSearchResult : System.Web.UI.Page
{
    private UserBLL _user = new UserBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["Filter"]=SearchHelper.GetFilterString(new String[]{"Nickname","Realname",
                "Province","City","Email","Tel","Address","Remark"});
            Bind(0);
        }
    }
    private void Bind(int pageIndex)
    {   
        string filter=ViewState["Filter"].ToString();
        DataSet ds = this._user.GetUserList(String.Format("{0} {1} RegisterType=0",filter,filter.Trim()==String.Empty?"":"and"), "UserId desc");
        this.gvMemberList.PageIndex = pageIndex;
        this.gvMemberList.PageSize = this.pageBar.PageSize;
        this.gvMemberList.DataSource = ds;
        this.gvMemberList.DataBind();

        this.pageBar.RecordCount = ds.Tables[0].Rows.Count;
    }
    protected void lbtnApprove_Command(object sender, CommandEventArgs e)
    {
        int userId = Convert.ToInt32(e.CommandArgument);
        this._user.ChangeApprovedStatus(userId);
        Bind(this.pageBar.PageIndex);
    }

    protected void ibtnDel_Command(object sender, CommandEventArgs e)
    {
        int userId = Convert.ToInt32(e.CommandArgument);
        this._user.Delete(userId);
        Bind(this.pageBar.PageIndex);
    }
    protected void pageBar_PageIndexChanged(object sender, PageIndexChangedEventArguments e)
    {
        Bind(e.NewPageIndex);
    }
}
