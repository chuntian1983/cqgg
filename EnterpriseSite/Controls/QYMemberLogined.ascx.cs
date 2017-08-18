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
using Modules.Member;

public partial class Controls_QYMemberLogined : System.Web.UI.UserControl
{
    MemberBLL bll = new MemberBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.Cookies["MemberId"] != null && Request.Cookies["MemberId"].Value.Trim() != "")
            {
                int memberId = Int32.Parse(Request.Cookies["MemberId"].Value.ToString());
                string NickName=bll.GetNickNameByMemberId(memberId);
                this.lbCompany.Text = NickName;            
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["MemberID"] != null)
        {
            if (Request.Cookies["MemberID"].Value.ToString() != "")
            {
                HttpCookie cookie = Request.Cookies["MemberID"];
                cookie.Expires = DateTime.Now.AddDays(-10);
                Response.Cookies.Add(cookie);
                Response.Write("<Script>alert('注销成功!');location.href('../Index.aspx');</Script>");
            }
        }
    }
}
