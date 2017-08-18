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
using Maticsoft.Common;

public partial class SysAdmin_loginuser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //if (ValidateClass.GetRegDataSet(this) == null)
        //{ return; }
        string nickname = this.username.Value.Trim();
        string pwd = this.password.Value.Trim();
        string randid = this.randid.Value;
        string CheckCode = Session["CheckCode"] as string;
        if (randid.ToUpper().Equals(CheckCode.ToUpper()))
        {
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
               // Response.Redirect("main.aspx");
                Response.Redirect("desktop/main.aspx");
            }
            
        }
        else
        {
            MessageBox.Show(this, "验证码错误请重新输入！");
            return;

        }
        
    }
}