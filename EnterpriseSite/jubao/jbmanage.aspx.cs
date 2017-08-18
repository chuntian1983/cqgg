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
using System.Text;
using Modules.Account;
using Modules.Department;
using CommonUtility;
using System.Collections.Generic;
using Maticsoft.DBUtility;

public partial class jubao_jbmanage : System.Web.UI.Page
{
    private DepartmentBLL _depart = new DepartmentBLL();
    private DepartmentCategoryBLL _category = new DepartmentCategoryBLL();

    public bool AllowDel
    {
        get { return Convert.ToBoolean(ViewState["AllowDel"]); }
        set { ViewState["AllowDel"] = value; }
    }
    public bool AllowEdit
    {
        get { return Convert.ToBoolean(ViewState["AllowEdit"]); }
        set { ViewState["AllowEdit"] = value; }
    }

    public bool AllowApprove
    {
        get { return Convert.ToBoolean(ViewState["AllowApprove"]); }
        set { ViewState["AllowApprove"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            //p.Demand(184);
            //this.trSearchButtom.Visible = this.trSearchTop.Visible = p.HasPermission(187);
            //this.AllowDel = p.HasPermission(186);
            //this.AllowEdit = p.HasPermission(185);
            ////this.AllowApprove = p.HasPermission(112);
            //this.gvArticleList.Columns[5].Visible = this.AllowEdit || this.AllowDel;
            //this.gvArticleList.Columns[4].Visible = p.HasPermission(112);
            // BindCategory();
            BindArticle();
        }
    }



    private string GetFilter()
    {
        if (ViewState["Filter"] == null)
        {
            ViewState["Filter"] = "1=1";
        }
        return this.ViewState["Filter"].ToString();
    }
    private void SetFilter()
    {
        StringBuilder filter = new StringBuilder();
        filter.Append("1=1");
        //if (this.txtTitle.Text.Length > 0)
        //{
        //    filter.Append(" and lxname like '%" + this.txtTitle.Text.Trim() + "%'");
        //}
        //string starDate = this.txtStart.Text.Trim();
        //string endDate = this.txtEnd.Text.Trim();
        //string title = this.txtTitle.Text.Trim();
        //string approved = this.ddlApproved.SelectedValue;
        //if (starDate != String.Empty) filter.AppendFormat(" and AddedDate>='{0}'", starDate);
        //if (endDate != String.Empty) filter.AppendFormat(" and AddedDate<='{0}'", endDate);
        //if (title != String.Empty) filter.AppendFormat(" and Title like '%{0}%'", title);
        //if (approved != "-1") filter.AppendFormat(" and Approved={0}", approved);
        ViewState["Filter"] = filter.ToString();
    }
    private void BindArticle()
    {
        string filter = this.GetFilter();
        string sort = "id desc";
        int pageIndex = this.pageBar.PageIndex;
        int pageSize = this.pageBar.PageSize;
        int count;
        string strsql = "view_jubao";
        DataSet ds = CommonUtility.PaginationUtility.GetPaginationList("*", strsql, filter, sort, pageIndex, pageSize, out count);// this._depart.GetDepartmentList("*", filter, sort, pageIndex, pageSize, out count);
        this.GridView1.DataSource = ds;
        this.GridView1.DataBind();

        this.pageBar.RecordCount = count;
    }


    protected void ibtnDel_Command(object sender, CommandEventArgs e)
    {
        int departId = Convert.ToInt32(e.CommandArgument);
        DbHelperSQL.ExecuteSql("delete from T_Jb_type where id=" + departId + "");
        BindArticle();
    }
    protected void pageBar_PageIndexChanged(object sender, PageIndexChangedEventArguments e)
    {
        BindArticle();
    }

    protected void lbtnApprove_Command(object sender, CommandEventArgs e)
    {
        int departId = Convert.ToInt32(e.CommandArgument);
        this._depart.ChangeApprovedStatus(departId);
        BindArticle();
    }
    protected void btnFind_Click(object sender, EventArgs e)
    {
        this.SetFilter();
        BindArticle();
    }
    protected void gvArticleList_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void btnFind0_Click(object sender, EventArgs e)
    {
        //if (this.TextBox1.Text.Length > 0)
        //{
        //    try
        //    {
        //        int.Parse(this.TextBox1.Text);
        //    }
        //    catch { Maticsoft.Common.MessageBox.Show(this, "排序号只能输入数字"); }
        //}
        //Dictionary<string, string> dc = new Dictionary<string, string>();
        //dc.Add("lxname", this.lxname.Text);
        //dc.Add("lxsort", this.TextBox1.Text);
        ////dc = CommonUtility.CommClass.Add(this.form1.Controls);
        //int i = DbHelperSQL.ExecuteSQL("T_Jb_type", dc);
        //if (i > 0)
        //{
        //    BindArticle();
        //}
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        switch (e.Row.RowType)
        {
            case DataControlRowType.Header:
                TableCellCollection tcHeader = e.Row.Cells;               
                tcHeader.Clear();
                tcHeader.Add(new TableHeaderCell());
                tcHeader[0].Attributes.Add("colspan","5");
                tcHeader[0].Attributes.Add("bgcolor", "Gray");
                tcHeader[0].Attributes.Add("style", "color:white;font-size:12px;");
                tcHeader[0].Text = "被举报人";

                 tcHeader.Add(new TableHeaderCell());
                tcHeader[1].Attributes.Add("rowspan","2");
                 tcHeader[1].Attributes.Add("bgcolor", "Gray");
                tcHeader[1].Attributes.Add("style", "color:white;font-size:12px;");
                tcHeader[1].Text = "处理期限";
                 tcHeader.Add(new TableHeaderCell());
                tcHeader[2].Attributes.Add("rowspan","2");
                 tcHeader[2].Attributes.Add("bgcolor", "Gray");
                tcHeader[2].Attributes.Add("style", "color:white;font-size:12px;");
                tcHeader[2].Text = "转办";

                 tcHeader.Add(new TableHeaderCell());
                tcHeader[3].Attributes.Add("rowspan","2");
                 tcHeader[3].Attributes.Add("bgcolor", "Gray");
                tcHeader[3].Attributes.Add("style", "color:white;font-size:12px;");
                tcHeader[3].Text = "受理部门";

                 tcHeader.Add(new TableHeaderCell());
                tcHeader[4].Attributes.Add("rowspan","2");
                 tcHeader[4].Attributes.Add("bgcolor", "Gray");
                tcHeader[4].Attributes.Add("style", "color:white;font-size:12px;");
                tcHeader[4].Text = "处理进度";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[5].Attributes.Add("rowspan","2");
                 tcHeader[5].Attributes.Add("bgcolor", "Gray");
                tcHeader[5].Attributes.Add("style", "color:white;font-size:12px;");
                tcHeader[5].Text = "删除</th></tr><tr>";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[6].Attributes.Add("rowspan","1");
                 tcHeader[6].Attributes.Add("bgcolor", "Gray");
                tcHeader[6].Attributes.Add("style", "color:white;font-size:12px;");
                tcHeader[6].Text = "所属单位";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[7].Attributes.Add("rowspan","1");
                 tcHeader[7].Attributes.Add("bgcolor", "Gray");
                tcHeader[7].Attributes.Add("style", "color:white;font-size:12px;");
                tcHeader[7].Text = "问题类别";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[8].Attributes.Add("rowspan","1");
                 tcHeader[8].Attributes.Add("bgcolor", "Gray");
                tcHeader[8].Attributes.Add("style", "color:white;font-size:12px;");
                tcHeader[8].Text = "姓名";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[9].Attributes.Add("rowspan","1");
                 tcHeader[9].Attributes.Add("bgcolor", "Gray");
                tcHeader[9].Attributes.Add("style", "color:white;font-size:12px;");
                tcHeader[9].Text = "职务";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[10].Attributes.Add("rowspan","1");
                 tcHeader[10].Attributes.Add("bgcolor", "Gray");
                tcHeader[10].Attributes.Add("style", "color:white;font-size:12px;");
                tcHeader[10].Text = "举报时间";

                
                break;
            
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //如果是绑定数据行       
        if (e.Row.RowType == DataControlRowType.DataRow)       
        {            //鼠标经过时，行背景色变             
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#E6F5FA'");         
            //鼠标移出时，行背景色变         
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
            Label lb = e.Row.FindControl("Label1") as Label;
            Label lb2 = e.Row.FindControl("Label2") as Label;
            switch (lb.Text)
            {
                case "0":
                    lb.Text = "处理中";
                    break;
                case "1":
                    lb.Text = "处理中";
                    break;
                case "2":
                    lb.Text = "已办结";
                    break;
                case "4":
                    lb.Text = "已办结";
                    break;
                default:
                    break;
            }
            if (lb2.Text=="0")
            {
                lb2.Text = "山东省";
            }
        }        
        //if (e.Row.RowIndex != -1)     
        //{            int id = e.Row.RowIndex + 1;     
        //    e.Row.Cells[0].Text = id.ToString();//Gridview自动生成序号   
        //    // e.Row.Cells[15].Text=dt2.Rows[id][3].ToString()+"--"+dt2.Rows[id][4].ToString();     
        //}
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        if (e.CommandName=="del")
        {
            DbHelperSQL.ExecuteSql("delete from t_jb_info where id='"+id+"'");
            BindArticle();
        }
    }
}