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
using Modules.Log;
using CommonUtility;

public partial class SysAdmin_login2 : System.Web.UI.Page
{
    private string returnUrl = HttpContext.Current.Request["ReturnUrl"];
    protected void Page_Load(object sender, EventArgs e)
    {
       // ValidateClass.GetRegDataSet(this);
        Response.Redirect("loginuser.aspx");
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //if (ValidateClass.GetRegDataSet(this) == null)
        //{ return; }
        string nickname = this.txtName.Value.Trim();
        string pwd = this.txtPassword.Value.Trim();
        int userId = CustomPrincipal.ValidateLogin(nickname, pwd);
        if (userId == -2)
        {
            JSUtility.Alert("用户名或密码错误!");
            JSUtility.GoHistory(-1);
        }
        else if (userId == -1)
        {
            JSUtility.Alert(@"该用户还未审核或审核未通过.\r\n请与管理员联系!");
            JSUtility.GoHistory(-1);
        }
        else
        {
            HttpCookie cookie = new HttpCookie("__UserInfo");
            cookie["userId"] = userId.ToString();
            cookie["nickname"] = nickname;
            Modules.Account.UserDetail model = new UserDetail();
            Modules.Account.UserBLL bll = new UserBLL();
            model = bll.GetUserDetail(userId);
            cookie["deptid"] = model.Email;
            Response.Cookies.Add(cookie);
            FormsAuthentication.SetAuthCookie(userId.ToString(), false);
            //OperateLog.AddLog(String.Format("用户[nickname:{0},userid:{1}]登陆系统。", nickname, userId), userId);
            if (returnUrl != null) Response.Redirect(returnUrl);
            else
                Response.Redirect("Desktop/Desktop.aspx");
        }
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        JSUtility.GoHistory(-1);
    }
}