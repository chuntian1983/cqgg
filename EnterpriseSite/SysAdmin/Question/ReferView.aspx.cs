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
using Modules.Refer;
using Modules.Answer;

public partial class SysAdmin_Question_ReferView : System.Web.UI.Page
{
    ReferDAL dal = new ReferDAL();
    ReferModel model = new ReferModel();
    AnswerDAL dal1 = new AnswerDAL();
    AnswerModel model1 = new AnswerModel();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["ReferId"] != null && Request.QueryString["ReferId"].ToString() != "")
            {
                int referid = Int32.Parse(Request.QueryString["ReferId"].ToString());
                PageBill(referid);
                PageBill1(referid);
            }
        }
    }

    protected void PageBill(int referid)
    {
        model = dal.GetModel(referid);
        this.lblName.Text = model.OpName;
        this.lbEmail.Text = model.OpEmail;
        this.lbAddress.Text = model.OpAddress;
        this.lbPost.Text = model.OpPost;
        this.lbTitle.Text = model.OpTitle;
        this.lbcontent.Text = model.OpContent;
        this.lbtime.Text = model.FillTime.ToShortDateString();
        
    }

    protected void PageBill1(int referid)
    {
        bool result = dal1.Exists(referid);
        if (result == true)
        {
            this.aa.Visible = false;
            this.bb.Visible = true;
            model1 = dal1.GetModel(referid);
            this.lbRName.Text = model1.Name;
            this.lbRTime.Text = model1.AddDate.ToShortDateString();
            this.liRContent.Text = model1.Content;
            this.bthuifu.Visible = false;
        }
    }

    protected void bthuifu_Click(object sender, EventArgs e)
    {
        if (this.TextBox1.Text == "")
        {
            Response.Write("<Script>alert('回复人姓名不能为空！');</Script>");
            return;
        }
        else
        {
            model1.Name = this.TextBox1.Text;
        }
        model1.QuestionId = Int32.Parse(Request.QueryString["ReferId"].ToString());
        model1.Business = "";
        model1.State = 1;
        model1.Title = "";
        model1.AddDate = DateTime.Now;
        //if (this.fckBody.Value == "")
        //{
        //    Response.Write("<Script>alert('回复内容不能为空！');</Script>");
        //    return;
        //}
        //else
        //{
        //    model1.Content = this.fckBody.Value.ToString();
        //}
        dal1.Add(model1);
        int ReferId = Int32.Parse(Request.QueryString["ReferId"].ToString());
        dal.UpdateState(ReferId);
        Response.Write("<Script>alert('你已成功回复！');location.href('ReferList.aspx');</Script>");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReferList.aspx");
    }
}
