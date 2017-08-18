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
using CommonUtility;
using Modules.Department;
using Maticsoft.DBUtility;
using System.Collections.Generic;

public partial class jubao_jubaoview : System.Web.UI.Page
{
    private DepartmentCategoryBLL _category = new DepartmentCategoryBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                string id = Request.QueryString["id"].ToString();
                DataTable dt = new DataTable();
                dt = DbHelperSQL.Query("select * from t_jb_info where id='" + Request.QueryString["id"] + "'").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    CommClass.ViewPage(this.form1.Controls, dt);
                    wtnr2.Text = dt.Rows[0]["wtnr"].ToString();
                    wtlx.Text = dt.Rows[0]["wtlx"].ToString();
                    string zt = dt.Rows[0]["zhuangtai"].ToString();
                    //switch (zt)
                    //{
                    //    case "2":
                    //        ImageButton1.Visible = false;
                    //        ImageButton2.Visible = false;
                    //        ImageButton3.Visible = false;
                    //        ImageButton4.Visible = false;
                    //        break;
                    //    default:
                    //        ImageButton1.Visible = true;
                    //        ImageButton2.Visible = true;
                    //        ImageButton3.Visible = true;
                    //        ImageButton4.Visible = true;
                    //        break;
                    //}
                }
                if (!string.IsNullOrEmpty(wtlx.Text.Trim())&&this.wtlx.Text.Length>0)
                {
                    try
                    {
                        wtlx.Text = DbHelperSQL.Query("select lxname from t_jb_type where id='" + wtlx.Text + "'").Tables[0].Rows[0][0].ToString();
                    }
                    catch { }
                }
                if (!string.IsNullOrEmpty(szdq.Text.Trim()) && this.szdq.Text.Length > 0)
                {
                    try { szdq.Text = DbHelperSQL.Query("select Title from T_DepartCategory where CategoryId='" + szdq.Text + "'").Tables[0].Rows[0][0].ToString(); }
                    catch { }
                }
            }
            BindParentCategory();
        }
    }

    private void BindParentCategory()
    {
        //ArrayList items = this._category.GetSortedDepartmentCategoryItems(4);
        //IEnumerator e = items.GetEnumerator();
        //while (e.MoveNext())
        //{
        //    CategoryEntity item = (CategoryEntity)e.Current;
        //    this.ddlParentCategory.Items.Add(new ListItem(item.Name, item.Id));
        //}
        ArrayList items = new ArrayList();
        //if (Request.Cookies["__userinfo"]["deptid"] != null)
        //{
        //    string strid = Request.Cookies["__userinfo"]["deptid"].ToString();
        //    //是否是顶级
        //    if (strid == "0")
        //    {
        //        items = this._category.GetSortedDepartmentCategoryItems(4);
        //    }
        //    else
        //    {
        //        items = this._category.GetSortedDepartmentCategoryItems(strid);
        //    }
        //}
        //else
        //{
        //items = this._category.GetSortedDepartmentCategoryItems(4);
        ////}
        //IEnumerator e = items.GetEnumerator();
        //while (e.MoveNext())
        //{
        //    CategoryEntity item = (CategoryEntity)e.Current;
        //    this.DropDownList1.Items.Add(new ListItem(item.Name, item.Id));
        //    //this.DropDownList1.Items.Add(new ListItem(item.Name, item.Id));
        //}
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //if (this.trsq.Visible)
        //{
        //    this.trsq.Visible = false;
        //}
        //else
        //{
        //    this.trsq.Visible = true;
        //    this.trzjcl.Visible = false;
        //    this.trjbfk.Visible = false;
        //}

    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        //if (this.trzjcl.Visible)
        //{
        //    this.trzjcl.Visible = false;
        //}
        //else
        //{
        //    this.trzjcl.Visible = true;
        //    this.trsq.Visible = false;
        //    this.trjbfk.Visible = false;
        //}
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        //if (this.trjbfk.Visible)
        //{
        //    this.trjbfk.Visible = false;
        //}
        //else
        //{
        //    this.trjbfk.Visible = true;
        //    this.trsq.Visible = false;
        //    this.trzjcl.Visible = false;
        //}
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            string id = Request.QueryString["id"].ToString();
            Dictionary<string, string> dc = new Dictionary<string, string>();
            dc.Add("zhuangtai", "2");
            DbHelperSQL.ExecuteSQL("T_Jb_info", dc, " id='" + id + "'");
            Maticsoft.Common.MessageBox.Show(this, "办结成功");
        }
    }
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        //if (Request.QueryString["id"] != null)
        //{
        //    string id = Request.QueryString["id"].ToString();
        //    Dictionary<string, string> dc = new Dictionary<string, string>();
        //    dc.Add("shouldw", this.DropDownList1.SelectedItem.Value);
        //    dc.Add("zhuangtai", "1");//已转发
        //    dc.Add("wcqx", this.TextBox1.Text);
        //    DbHelperSQL.ExecuteSQL("T_Jb_info", dc, " id='" + id + "'");
        //    Maticsoft.Common.MessageBox.Show(this, "授权处理成功");
        //}
    }
    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
    {
        //if (Request.QueryString["id"] != null)
        //{
        //    string id = Request.QueryString["id"].ToString();
        //    Dictionary<string, string> dc = new Dictionary<string, string>();
        //    dc.Add("chuliyijian", this.TextBox4.Text);
        //    dc.Add("zhuangtai", "3");//已处理
        //    dc.Add("wcqx", this.TextBox2.Text);
        //    DbHelperSQL.ExecuteSQL("T_Jb_info", dc, " id='" + id + "'");
        //    Maticsoft.Common.MessageBox.Show(this, "处理成功");
        //}
    }
    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {
        //if (Request.QueryString["id"] != null)
        //{
        //    string id = Request.QueryString["id"].ToString();
        //    Dictionary<string, string> dc = new Dictionary<string, string>();
        //    dc.Add("fankuiyj", this.TextBox7.Text);
        //    dc.Add("zhuangtai", "4");//已反馈
        //    dc.Add("wcqx", "0");
        //    DbHelperSQL.ExecuteSQL("T_Jb_info", dc, " id='" + id + "'");
        //    Maticsoft.Common.MessageBox.Show(this, "反馈成功");
        //}
    }
}