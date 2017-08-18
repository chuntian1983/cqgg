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
using Modules.Poll;
using CommonUtility;

public partial class SysAdmin_Poll_AddPoll : System.Web.UI.Page
{
    private string _userId = HttpContext.Current.User.Identity.Name;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.plAnswer.Visible = false;
            this.plQuestion.Visible = true;
        }
    }
    protected void btnSubmitQuestion_Click(object sender, EventArgs e)
    {
        string question = this.txtQuestion.Text.Trim();
        int pollId=new PollBLL().Create(question, Convert.ToInt32(this._userId));
        if (pollId != -1)
        {
            ViewState["PollId"] = pollId;
            this.plAnswer.Visible = true;
            this.plQuestion.Visible = false;
        }
        else
        {
            JSUtility.Alert("添加问题失败!");
        }
        


    }
    protected void btnSubmitAnswer_Click(object sender, EventArgs e)
    {
        SubmitAnswers();
    }
    private void SubmitAnswers()
    {
        string ans1 = txtAns1.Text.Trim();
        string ans2 = txtAns2.Text.Trim();
        string ans3 = txtAns3.Text.Trim();
        string ans4 = txtAns4.Text.Trim();
        PollOptionBLL pollOption = new PollOptionBLL();
        int pollId = Convert.ToInt32(ViewState["PollId"]);
        int userId = Convert.ToInt32(this._userId);
        if (ans1 != String.Empty) pollOption.Create(ans1, userId, pollId);
        if (ans2 != String.Empty) pollOption.Create(ans2, userId, pollId);
        if (ans3 != String.Empty) pollOption.Create(ans3, userId, pollId);
        if (ans4 != String.Empty) pollOption.Create(ans4, userId, pollId);
        txtAns1.Text = txtAns2.Text = txtAns3.Text = txtAns4.Text = String.Empty;
    }
    protected void btnCreateNextQuestion_Click(object sender, EventArgs e)
    {
        SubmitAnswers();
        Response.Redirect("~/sysadmin/poll/addpoll.aspx");
    }
}
