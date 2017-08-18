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
using Modules.Applyforjob;
using Modules.Resume;
using Modules.Account;

public partial class SysAdmin_Job_QZList : System.Web.UI.Page
{
    private ApplyforjobBLL _applyforjob = new ApplyforjobBLL();
    private ResumeBLL _resume = new ResumeBLL();
    private int PageIndex = 0;

    public bool AllowDel
    {
        get { return Convert.ToBoolean(ViewState["AllowDel"]); }
        set { ViewState["AllowDel"] = value; }
    }
    public bool AllowApprove
    {
        get { return Convert.ToBoolean(ViewState["Approve"]); }
        set { ViewState["Approve"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            p.Demand(315);
            this.AllowDel = p.HasPermission(317);
            this.AllowApprove = p.HasPermission(316);
            this.gvQZList.Columns[4].Visible = this.AllowApprove;
            this.gvQZList.Columns[5].Visible = this.AllowDel;
            Bind(0,"");
        }
    }

    private void Bind(int pageIndex,string  where)
    {
        DataSet ds = _applyforjob.GetPersonInfoList(where);
        this.gvQZList.PageIndex = pageIndex;
        this.gvQZList.DataSource = ds;
        this.gvQZList.DataBind();
        this.pageBar.RecordCount = ds.Tables[0].Rows.Count;
    }
    protected void ibtnDel_Command(object sender, CommandEventArgs e)
    {
        int postId = Convert.ToInt32(e.CommandArgument);
        this._resume.Delete(postId);
        this._applyforjob.Delete(postId);
        Bind(this.pageBar.PageIndex,"");
    }
    protected void pageBar_PageIndexChanged(object sender, PageIndexChangedEventArguments e)
    {
        PageIndex = e.NewPageIndex;
        Bind(e.NewPageIndex,"");
    }
    protected void lbtnApprove_Command(object sender, CommandEventArgs e)
    {
        int userId = Convert.ToInt32(e.CommandArgument);
        this._resume.ChangeApprovedStatus(userId);
        Bind(PageIndex,"");
    }

   //根据求职人员姓名查询
    protected void Button1_Click(object sender, EventArgs e)
    {
        string Name = this.txtName.Text.Trim();
        Bind(0, " UserName like '%" + Name + "%'");
    }


    //protected void gvQZList_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    System.Web.UI.WebControls.Label lbDiploma = (System.Web.UI.WebControls.Label)e.Row.FindControl("lbDiploma");
    //    System.Web.UI.WebControls.Label lbDiploma1 = (System.Web.UI.WebControls.Label)e.Row.FindControl("lbDiploma1");
    //    switch (lbDiploma1.Text.Trim())
    //    {
    //        case "0": lbDiploma.Text = "初中"; break;
    //        case "1": lbDiploma.Text = "高中"; break;
    //        case "2": lbDiploma.Text = "中技"; break;
    //        case "3": lbDiploma.Text = "中专"; break;
    //        case "4": lbDiploma.Text = "大专"; break;
    //        case "5": lbDiploma.Text = "本科"; break;
    //        case "6": lbDiploma.Text = "硕士"; break;
    //        case "7": lbDiploma.Text = "博士"; break;
    //        case "8": lbDiploma.Text = "其他"; break;
    //    }
    //}
}
