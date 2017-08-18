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
using Modules.Vote;

public partial class SysAdmin_Vote_VoteTypeMod : System.Web.UI.Page
{
    public int id = 0;
    VoteOperate index = new VoteOperate();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                if (Request.QueryString["id"].ToString() != "")
                {
                    this.lbltitle.Text = "在线调查类别修改";
                    this.Label1.Text = Request.QueryString["id"].ToString();
                    PageBill(Request.QueryString["id"].ToString());
                }
                else
                {
                    Response.Write("<script>alert('查无此类别!');location.href('VoteTypeList.aspx');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('查无此类别!');location.href('VoteTypeList.aspx');</script>");
            }
        }
    }

    private void PageBill(string _id)
    {
        DataSet ds = index.VoteTypeGetList(_id);
        this.TextBox2.Text = ds.Tables[0].Rows[0]["VoteType"].ToString();
        this.RadioButtonList1.SelectedValue = ds.Tables[0].Rows[0]["Vouch"].ToString();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.TextBox2.Text != "")
        {
            index.VoteTypeUpdate(Int32.Parse(this.Label1.Text.ToString()), this.RadioButtonList1.SelectedValue.ToString(), this.TextBox2.Text.ToString());
            if (Request.QueryString["vid"] != null && Request.QueryString["vid"].ToString() != "")
            {
                int vid = Int32.Parse(Request.QueryString["vid"].ToString());
                Response.Write("<script>alert('你已修改成功!');location.href('VoteTypeList.aspx?vid=" + vid + "');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('对不起！修改类别不能为空！');</script>");
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        this.TextBox2.Text = "";
    }
}
