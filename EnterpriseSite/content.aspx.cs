using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using Maticsoft.DBUtility;
using System.Data;

public partial class content : System.Web.UI.Page
{
    public string strtou, strzuozhe, strshijian, strneirong, strimg;
    public string strgzdtList;
    public string szjg, szcx;
    protected void Page_Load(object sender, EventArgs e)
    {
        szjg = System.Configuration.ConfigurationManager.AppSettings["szjg"];
        szcx = System.Configuration.ConfigurationManager.AppSettings["szcx"];
        if (!IsPostBack)
        {
            if (Request.QueryString["p"]!=null)
            {
                string strid = Request.QueryString["p"];
                Modules.News.NewsDetail model = new Modules.News.NewsDetail();
                Modules.News.NewsBLL bll = new Modules.News.NewsBLL();
                model = bll.GetArticleDetail(int.Parse(strid));
                if (model != null)
                {
                    strtou = model.Title;
                    strzuozhe = model.PublicationUnit;
                    strneirong = model.Body;
                    strshijian = model.ReleaseDate;
                    if (string.IsNullOrEmpty(model.imgpath))
                    {
                        strimg = "html/images/kongbai.jpg";
                    }
                    else
                    {
                        strimg = "upload/" + model.imgpath;
                    }
                }
                else { strimg = "html/images/kongbai.jpg"; }

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
                DataTable dt = DbHelperMySQL.Query(" select * from t_news where title like '%" + this.txtgjc.Value.Trim() + "%' and Approved=1 order by NewsId desc ").Tables[0];
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