using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Swgk_cunwutj : System.Web.UI.Page
{
    public string deptid;
    public string st;
    Modules.Department.DepartmentCategoryBLL bll = new Modules.Department.DepartmentCategoryBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        st = Request.QueryString["st"];
        if (!IsPostBack)
        {
            deptid = Request.QueryString["deptid"];
            bindll();
            if (deptid != null)
            {
                bindData();
            }
            
        }
        
    }
    private void bindll()
    {
        
        DataTable dt = bll.GetChildCategoryItems(0).Tables[0];
        this.DropDownList1.DataSource = dt;
        this.DropDownList1.DataTextField = "title";
        this.DropDownList1.DataValueField = "CategoryId";
        this.DropDownList1.DataBind();
        this.DropDownList1.Items.Insert(0, new ListItem("选择市（区县）","0"));
        this.DropDownList2.Items.Insert(0,new ListItem("请选择乡镇（街道）","0"));
        this.DropDownList3.Items.Insert(0,new ListItem("请选择村","0"));
    }
    void bindData()
    {
        string times=this.DropDownList4.Text+"-"+this.DropDownList5.Text;
        DataTable dt = new DataTable();
        dt.Columns.Add("f0");
        dt.Columns.Add("f1");
        dt.Columns.Add("f2");
        dt.Columns.Add("f3");
        dt.Columns.Add("f4");
        dt.Columns.Add("f5");
        dt.Columns.Add("f6");
        dt.Columns.Add("f7");
        //济宁市统计
        #region
        if (this.DropDownList1.SelectedValue == "0")
        {
            DataTable ds = bll.GetChildCategoryItems(0).Tables[0];

            for (int i = 0; i < ds.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[1] = ds.Rows[i]["title"];
                DataTable dtzhen = bll.GetChildCategoryItems(int.Parse(ds.Rows[i]["CategoryId"].ToString())).Tables[0];
                dr[2] = dtzhen.Rows.Count;
                int cous = 0;
                for (int j = 0; j < dtzhen.Rows.Count; j++)
                {
                    cous += bll.GetChildCategoryItems(int.Parse(dtzhen.Rows[j]["CategoryId"].ToString())).Tables[0].Rows.Count;
                }
                dr[3] = cous;
                dr[4] = Qutj(times, ds.Rows[i]["CategoryId"].ToString());
                if (dr[4].ToString() == "0")
                {
                    dr[4] = "96";
                    dr[0] = "GreenCard.gif";
                }
                else
                {
                    if (int.Parse(dr[4].ToString()) > 95)
                    {
                        dr[0] = "GreenCard.gif";
                    }
                    else
                    {
                        dr[0] = "YellowCard.gif";
                    }
                }
                dt.Rows.Add(dr);

            }

            this.gvArticleList.DataSource = dt;
            this.gvArticleList.DataBind();
            this.gvArticleList.HeaderRow.Cells[2].Text = "镇总数";
            this.gvArticleList.HeaderRow.Cells[3].Text = "村总数";
            this.gvArticleList.HeaderRow.Cells[4].Text = "区（县）测评平均分数";
            this.gvArticleList.Columns[5].Visible = false;
            this.gvArticleList.Columns[6].Visible = false;
            this.gvArticleList.Columns[7].Visible = false;

        }
        #endregion
        #region 区县统计
        else
        {
            if (this.DropDownList2.SelectedValue == "0")
            {
                DataTable ds = bll.GetChildCategoryItems(int.Parse(this.DropDownList1.SelectedValue)).Tables[0];

                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[1] = this.DropDownList1.SelectedItem.Text;
                    dr[2] = ds.Rows[i]["title"];
                    DataTable dtzhen = bll.GetChildCategoryItems(int.Parse(ds.Rows[i]["CategoryId"].ToString())).Tables[0];
                    dr[3] = dtzhen.Rows.Count;
                    //int cous = 0;
                    //for (int j = 0; j < dtzhen.Rows.Count; j++)
                    //{
                    //    cous += bll.GetChildCategoryItems(int.Parse(dtzhen.Rows[j]["CategoryId"].ToString())).Tables[0].Rows.Count;
                    //}
                    //dr[3] = cous;
                    int zhefss = 0;
                    int zfs = 0;
                    zhefss = Zhentj(times, ds.Rows[i]["CategoryId"].ToString());
                    if (zhefss == 0)
                    {
                        zhefss = 96;
                    }
                    else
                    {
                        zfs = 100 - zhefss;
                    }
                    dr[4] = zfs;
                    dr[5] = "4";
                    dr[6] = zhefss;//村平均分
                    dr[7] = zhefss;
                    if (zfs == 0)
                    {

                        dr[0] = "YellowCard.gif";
                    }
                    else
                    {
                        if (zhefss > 96)
                        {
                            dr[0] = "GreenCard.gif";
                        }
                        else
                        {
                            dr[0] = "RedCard.gif";
                        }
                    }
                    dt.Rows.Add(dr);

                }

                this.gvArticleList.Columns[5].Visible = true;
                this.gvArticleList.Columns[6].Visible = true;
                this.gvArticleList.Columns[7].Visible = true;
                this.gvArticleList.DataSource = dt;
                this.gvArticleList.DataBind();
                this.gvArticleList.HeaderRow.Cells[2].Text = "镇名称";
                this.gvArticleList.HeaderRow.Cells[3].Text = "村总数";
                this.gvArticleList.HeaderRow.Cells[4].Text = "镇公开得分";
                this.gvArticleList.HeaderRow.Cells[5].Text = "镇应公开满分";
                this.gvArticleList.HeaderRow.Cells[6].Text = "村平均分";
                this.gvArticleList.HeaderRow.Cells[7].Text = "镇测评得分";
                

            }
            else
            {
                #region 镇统计分数
                if (this.DropDownList3.SelectedValue == "0")
                {
                    DataTable ds = bll.GetChildCategoryItems(int.Parse(this.DropDownList2.SelectedValue)).Tables[0];

                    for (int i = 0; i < ds.Rows.Count; i++)
                    {
                        DataRow dr = dt.NewRow();
                        dr[1] = this.DropDownList1.SelectedItem.Text;
                        dr[2] = this.DropDownList2.SelectedItem.Text;
                        dr[3] = ds.Rows[i]["title"];
                        DataTable dtzhen = bll.GetChildCategoryItems(int.Parse(ds.Rows[i]["CategoryId"].ToString())).Tables[0];
                        //dr[4] = dtzhen.Rows.Count;
                        //int cous = 0;
                        //for (int j = 0; j < dtzhen.Rows.Count; j++)
                        //{
                        //    cous += bll.GetChildCategoryItems(int.Parse(dtzhen.Rows[j]["CategoryId"].ToString())).Tables[0].Rows.Count;
                        //}
                        //dr[3] = cous;
                        int zhefss = 0;
                        int zfs = 0;
                        zhefss = Cuntj(times, ds.Rows[i]["CategoryId"].ToString());
                        if (zhefss == 0)
                        {
                            zhefss = 96;
                        }
                        else
                        {
                            zfs = 100 - zhefss;
                        }
                        dr[4] = zfs;
                        dr[5] = "4";
                        dr[6] = zhefss;//村平均分
                        if (zfs == 0)
                        {

                            dr[0] = "YellowCard.gif";
                        }
                        else
                        {
                            if (zhefss >= 96)
                            {
                                dr[0] = "GreenCard.gif";
                            }
                            else
                            {
                                dr[0] = "RedCard.gif";
                            }
                        }
                        dt.Rows.Add(dr);

                    }

                    this.gvArticleList.DataSource = dt;
                    this.gvArticleList.DataBind();
                    this.gvArticleList.HeaderRow.Cells[2].Text = "镇名称";
                    this.gvArticleList.HeaderRow.Cells[3].Text = "村名称";
                    this.gvArticleList.HeaderRow.Cells[4].Text = "实际公开得分";
                    this.gvArticleList.HeaderRow.Cells[5].Text = "村应公开满分";
                    this.gvArticleList.HeaderRow.Cells[6].Text = "村测评分数";

                    this.gvArticleList.Columns[5].Visible = true;
                    this.gvArticleList.Columns[6].Visible = true;
                    this.gvArticleList.Columns[7].Visible = false;

                }
                #endregion
                else//村统计分数
                {
                    
                        DataRow dr = dt.NewRow();
                        dr[1] = this.DropDownList1.SelectedItem.Text;
                        dr[2] = this.DropDownList2.SelectedItem.Text;
                        dr[3] = this.DropDownList3.SelectedItem.Text;
                        int zhefss = 0;
                        int zfs = 0;
                        zhefss = Cuntj(times, this.DropDownList3.SelectedValue);
                        if (zhefss == 0)
                        {
                            zhefss = 96;
                        }
                        else
                        {
                            zfs = 100 - zhefss;
                        }
                        dr[4] = zhefss;
                        dr[5] = "4";
                        dr[6] = zhefss;//村平均分
                        if (zhefss == 0)
                        {

                            dr[0] = "YellowCard.gif";
                        }
                        else
                        {
                            if (zhefss > 96)
                            {
                                dr[0] = "GreenCard.gif";
                            }
                            else
                            {
                                dr[0] = "RedCard.gif";
                            }
                        }
                        dt.Rows.Add(dr);
                    this.gvArticleList.DataSource = dt;
                    this.gvArticleList.DataBind();
                    this.gvArticleList.HeaderRow.Cells[2].Text = "镇名称";
                    this.gvArticleList.HeaderRow.Cells[3].Text = "村名称";
                    this.gvArticleList.HeaderRow.Cells[4].Text = "实际公开得分";
                    this.gvArticleList.HeaderRow.Cells[5].Text = "村应公开满分";
                    this.gvArticleList.HeaderRow.Cells[6].Text = "村测评分数";

                    this.gvArticleList.Columns[5].Visible = true;
                    this.gvArticleList.Columns[6].Visible = true;
                    this.gvArticleList.Columns[7].Visible = false;
                }
            }
        }
        #endregion
    }

    /// <summary>
    /// 村分数统计
    /// </summary>
    /// <param name="times"></param>
    /// <returns></returns>
    public int Cuntj(string times,string cunid)
    {
        string statrtime = DateTime.Parse(times).AddMonths(-1).AddDays(20).ToString();
        string endtime = DateTime.Parse(times).AddDays(20).ToString();
        Modules.News.NewsBLL bllnew = new Modules.News.NewsBLL();
        int fs = bllnew.Getrowscount(int.Parse(cunid), statrtime, endtime);
        return fs;
    }
    /// <summary>
    /// 镇分数统计
    /// </summary>
    /// <param name="times"></param>
    /// <returns></returns>
    public int Zhentj(string times,string zhenid)
    {
        DataTable dt = bll.GetChildCategoryItems(int.Parse(zhenid)).Tables[0];
        int zhcounts =dt.Rows.Count;
        int fscounts = 0;
        int zhenfs = 0;
        if (zhcounts>0)
        {
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                fscounts += Cuntj(times, dt.Rows[i]["CategoryId"].ToString());
            }
            zhenfs = fscounts / zhcounts;
        }
        
        return zhenfs;
    }
    /// <summary>
    /// 县分数统计
    /// </summary>
    /// <param name="times"></param>
    /// <param name="quid"></param>
    /// <returns></returns>
    public int Qutj(string times, string quid)
    {
        DataTable dt = bll.GetChildCategoryItems(int.Parse(quid)).Tables[0];
        int zhcounts = dt.Rows.Count;
        int fscounts = 0;
        int zhenfs = 0;
        if (zhcounts > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                fscounts += Zhentj(times, dt.Rows[i]["CategoryId"].ToString());
            }
            zhenfs = fscounts / zhcounts;
        }
        return zhenfs;
    }
    protected void AspNetPager1_PageChanged(object src, EventArgs e)
    {
        bindData();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        bindData();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.DropDownList1.SelectedValue!="0")
        {
            DataTable dt = bll.GetChildCategoryItems(int.Parse(this.DropDownList1.SelectedValue)).Tables[0];
            this.DropDownList2.Items.Clear();
            this.DropDownList2.DataSource = dt;
            this.DropDownList2.DataTextField = "title";
            this.DropDownList2.DataValueField = "CategoryId";
            this.DropDownList2.DataBind();
            this.DropDownList2.Items.Insert(0, new ListItem("请选择乡镇（街道）", "0"));
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.DropDownList2.SelectedValue != "0")
        {
            DataTable dt = bll.GetChildCategoryItems(int.Parse(this.DropDownList2.SelectedValue)).Tables[0];
            this.DropDownList3.Items.Clear();
            this.DropDownList3.DataSource = dt;
            this.DropDownList3.DataTextField = "title";
            this.DropDownList3.DataValueField = "CategoryId";
            this.DropDownList3.DataBind();
            this.DropDownList3.Items.Insert(0, new ListItem("请选择乡镇（街道）", "0"));
        }
    }
}