using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using Maticsoft.DBUtility;
using System.Data;
using MySql.Data.MySqlClient;

public partial class list : System.Web.UI.Page
{
    public string strlb;
    public string strgzdtList;
    public string szjg, szcx;
    protected void Page_Load(object sender, EventArgs e)
    {
        szjg = System.Configuration.ConfigurationManager.AppSettings["szjg"];
        szcx = System.Configuration.ConfigurationManager.AppSettings["szcx"];
        //if (!IsPostBack)
        //{
            if (Request.QueryString["lb"]!=null)
            {
                BindLog();
            }
            
        //}
    }
    private void BindLog()
    {
        string strid=Request.QueryString["lb"];
        if (!safe_360.CheckFromIn(strid))
        {
            MessageBox.Show(this, "该参数含有特殊字符！");
            Response.Redirect("index.aspx");
            
        }
        Modules.News.NewsBLL bll = new Modules.News.NewsBLL();
        string strsql = "select * from t_news where Approved='1' and CategoryId='"+strid+"'";
        
        DataTable dts = DbHelperMySQL.Query(strsql).Tables[0];
        AspNetPager1.RecordCount = dts.Rows.Count;
        AspNetPager1.PageSize = 10;
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = dts.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.PageSize = AspNetPager1.PageSize;
        rep.DataSource = pds;
        rep.DataBind();
        if (dts.Rows.Count > 0)
        {
            Modules.News.NewsCategoryBLL lbll = new Modules.News.NewsCategoryBLL();
            Modules.News.NewsCategoryDetail lbmodel = new Modules.News.NewsCategoryDetail();
            lbmodel = lbll.GetCategoryDetail(int.Parse(dts.Rows[0]["CategoryId"].ToString()));
            if (lbmodel != null)
            {
                strlb = lbmodel.Title;
            }
        }

        //工作动态6条信息
        DataTable dt = DbHelperMySQL.Query(" select * from t_news where CategoryId='261'  and Approved=1 order by NewsId desc LIMIT 0,6").Tables[0];
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                strgzdtList += "<li><span>■</span><a href=\"content.aspx?p=" + dr["newsid"] + "\">" + dr["title"] + "</a></li>";
            }

        }
        
    }
    protected void AspNetPager1_PageChanged(object src, EventArgs e)
    {
        BindLog();
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.txtgjc.Value))
        {
            if (this.txtgjc.Value != "请输入关键词")
            {
                if (safe_360.CheckData(this.txtgjc.Value))
                {
                    MessageBox.Show(this, "您输入的关键词含有特殊字符请重新输入！");
                    return;
                }
                DataTable dt = DbHelperMySQL.Query("select * from t_news where title like '%"+this.txtgjc.Value.Trim()+"%' and Approved=1 order by NewsId desc ").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    Session["chaxun"] = dt;
                    Response.Redirect("searchlist.aspx");
                }
                else { MessageBox.Show(this, "对不起！您查询的关键词，没有查询到相关内容！"); return; }
            }
            else { MessageBox.Show(this, "请输入你要查询的关键词"); return; }
        }
        else { MessageBox.Show(this, "请输入你要查询的关键词"); return; }
    }
}