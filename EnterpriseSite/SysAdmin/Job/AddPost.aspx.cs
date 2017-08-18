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
public partial class SysAdmin_Job_AddPost : System.Web.UI.Page
{
    private string _postId = HttpContext.Current.Request["PostId"];
    private string _userId = HttpContext.Current.User.Identity.Name;
    private DepartmentBLL _department = new DepartmentBLL();
    private PostBLL _post = new PostBLL();
    //protected string _pageTitle = "添加岗位信息";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            if (this._postId != null)
            {
                //p.Demand(130);
                int postId = Convert.ToInt32(this._postId);
                PostDetail detail = this._post.GetPostDetail(postId);
                this.lbCompanyName.Text = detail.CompanyName;
                this.lbJobName.Text = detail.Description;
                this.lbNum.Text = detail.PersonNum;
                switch (detail.Sex.ToString())
                {
                    case "0": this.lbSex.Text = "不限"; break;
                    case "1": this.lbSex.Text = "男"; break;
                    case "2": this.lbSex.Text = "女"; break;     
                }
                this.lbAge.Text = detail.Age;
                this.lbAg1.Text = detail.Age1;
                switch (detail.Diploma.ToString())
                {
                    case "0": lbDegree.Text = "初中"; break;
                    case "1": lbDegree.Text = "高中"; break;
                    case "2": lbDegree.Text = "中技"; break;
                    case "3": lbDegree.Text = "中专"; break;
                    case "4": lbDegree.Text = "大专"; break;
                    case "5": lbDegree.Text = "本科"; break;
                    case "6": lbDegree.Text = "硕士"; break;
                    case "7": lbDegree.Text = "博士"; break;
                    case "8": lbDegree.Text = "其他"; break;
                }
                this.lbWorkPlace.Text = detail.WorkPlace;
                this.lbSubject.Text = detail.Subject;
                switch (detail.WorkMode.ToString())
                {
                    case "0": this.lbWorkType.Text = "全/兼职"; break;
                    case "1": this.lbWorkType.Text = "兼职"; break;
                    case "2": this.lbWorkType.Text = "全职"; break;
                    case "3": this.lbWorkType.Text = "实习"; break;
                }
               
                //this.cbIsThisYear.Checked = detail.IsThisYear == 1 ? true : false;
                this.lbPayYear.Text = detail.Pay;
                this.lbStartTime.Text = detail.AddedDate.ToString("yyyy-MM-dd");
                this.lbEndTime.Text = detail.ExpireDate.ToString("yyyy-MM-dd");
                this.liContent.Text = UnCode(detail.OtherRequests);
               
                //ViewState["ViewCount"] = detail.ViewCount;
                //_pageTitle = "修改岗位信息";
            }
        }
    }

    public string UnCode(string content)
    {
        string str1 = content.Replace("&amp;", "&");
        string str2 = str1.Replace("&quot;", "\"");
        string str3 = str2.Replace("<br>", "\r\n");
        string str4 = str3.Replace("&nbsp;", " ");
        string str5 = str4.Replace("'", "&apos;");
        string str6 = str5.Replace("&gt;", ">");
        string str7 = str6.Replace("&lt;", "<");
        return str7;
    }
}
