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


public partial class SysAdmin_Account_User_ModifyPWD : System.Web.UI.Page
{
    private string _loginUserId = HttpContext.Current.User.Identity.Name;
    private UserBLL _user = new UserBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            p.Demand(24);
            int userId=Convert.ToInt32(this._loginUserId);
            this.lblNickname.Text = this._user.GetUserDetail(userId).Nickname;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string newPwd=this.txtNewPwd.Text.Trim();
        string oldPwd=this.txtOldPwd.Text.Trim();
        int userId=Convert.ToInt32(this._loginUserId);
        if(this._user.ValidatePwd(userId,oldPwd))
        {
            this._user.ModifyPwd(userId, newPwd);
            JSUtility.Alert("密码修改成功!");
        }else
        {
            JSUtility.Alert("密码错误!");
        }
        
    }
}
