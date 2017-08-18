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

public partial class jubao_login2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //DateTime dt = DateTime.Parse("2012-09-08");
            //DateTime dt3 = DateTime.Parse("2012-11-10");
            //DateTime dt2 = System.DateTime.Now;
            //if (dt2 < dt)
            //{
            //    Maticsoft.Common.MessageBox.Show(this, "您的服务器时间不正确请调整！");
            //    return;
            //}
            //else
            //{
            //    if (dt3<dt2)
            //    {
            //        Maticsoft.Common.MessageBox.Show(this, "您的软件试用期已经到期！");
            //    return;
            //    }
            //}
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //DateTime dt = DateTime.Parse("2012-09-08");
        //DateTime dt3 = DateTime.Parse("2012-11-10");
        //DateTime dt2 = System.DateTime.Now;
        //if (dt2 < dt)
        //{
        //    Maticsoft.Common.MessageBox.Show(this, "您的服务器时间不正确请调整！");
        //    return;
        //}
        //else
        //{
        //    if (dt3 < dt2)
        //    {
        //        Maticsoft.Common.MessageBox.Show(this, "您的软件试用期已经到期！");
        //        return;
        //    }
        //}
        if (this.Text1.Value.Trim().Length > 0)
        {
            if (this.Text1.Value.Trim() != this.Validnum.Number.Trim())
            {
                Maticsoft.Common.MessageBox.Show(this, "验证码输入不正确！");
                return;
            }
        }
        else
        {
            Maticsoft.Common.MessageBox.Show(this, "验证码不能为空！");
            return;
        }
        string nickname = this.txtName.Text.Trim();
        string pwd = this.txtPassword.Text.Trim();
        int userId = CustomPrincipal.ValidateLogin(nickname, pwd);
        if (userId == -2)
        {
            Maticsoft.Common.MessageBox.Show(this, "用户名或密码错误!");
            return;

        }
        else if (userId == -1)
        {
            Maticsoft.Common.MessageBox.Show(this, @"该用户还未审核或审核未通过.\r\n请与管理员联系!");

            return;
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
            Response.Redirect("jbmaintop.aspx?pid="+model.Email+"");
            //OperateLog.AddLog(String.Format("用户[nickname:{0},userid:{1}]登陆系统。", nickname, userId), userId);
            //if (returnUrl != null) Response.Redirect(returnUrl);
            //else
            //    Response.Redirect("Desktop/Desktop.aspx");
        }
    }
}