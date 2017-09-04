using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modules.News;
using System.Data;
using Maticsoft.DBUtility;
using Maticsoft.Common;

public partial class index : System.Web.UI.Page
{
    Modules.News.NewsBLL bll = new NewsBLL();
    Modules.News.NewsDetail model = new NewsDetail();
    public string toutiaot, toutiaonr, toutiaoid;
    public string strtupian, strtupianzi;
    public string gzdtBiaoti, gzdtMiaoshu,gzdtId,gzdtList;
    public string zcfgBiaoti, zcfgMiaoshu, zcfgId, zcfgList;
    public string hnzcBiaoti, hnzcMiaoshu, hnzcId, hnzcList;
    public string jyjlBiaoti, jyjlMiaoshu, jyjlId, jyjlList;
    public string szjg, szcx;
    protected void Page_Load(object sender, EventArgs e)
    {
        szjg=System.Configuration.ConfigurationManager.AppSettings["szjg"];
        szcx= System.Configuration.ConfigurationManager.AppSettings["szcx"];
        if (!IsPostBack)
        {
            //今日头条
            DataTable dt = DbHelperMySQL.Query(" select * from t_news where CategoryId='283' and imgname!='' and Approved=1 order by NewsId desc").Tables[0];
            if (dt.Rows.Count>0)
            {
                toutiaot = dt.Rows[0]["Title"].ToString();
                toutiaonr = dt.Rows[0]["imgname"].ToString();
                toutiaoid = dt.Rows[0]["NewsId"].ToString();
            }
            //图片新闻
            dt = DbHelperMySQL.Query(" select * from t_news where CategoryId='261' and imgpath!='' and Approved=1 order by NewsId desc LIMIT 0,6").Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    strtupian += "<a href=\"content.aspx?p="+dr["newsid"]+"\"><img src=\"upload/"+dr["imgpath"]+"\"></a>";
                    strtupianzi += "<span>"+dr["title"]+"</span>";
                }
            }
            //工作动态
             dt = DbHelperMySQL.Query(" select * from t_news where CategoryId='261' and imgname!='' and Approved=1 order by NewsId desc LIMIT 0,1").Tables[0];
             if (dt.Rows.Count > 0)
             {
                 gzdtBiaoti = dt.Rows[0]["title"].ToString();
                 gzdtMiaoshu = dt.Rows[0]["imgname"].ToString().Length > 46 ? dt.Rows[0]["imgname"].ToString().Substring(0, 46) + ".." : dt.Rows[0]["imgname"].ToString();
                 gzdtId = dt.Rows[0]["newsid"].ToString();
             }
            //工作动态6条信息
            dt = DbHelperMySQL.Query(" select * from t_news where CategoryId='261'  and Approved=1 order by NewsId desc LIMIT 1,6").Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    gzdtList += "<li><span>■</span><a href=\"content.aspx?p="+dr["newsid"]+"\">"+dr["title"]+"</a></li>";
                }
                
            }
            BinNews("275", zcfgBiaoti, zcfgMiaoshu, zcfgId, zcfgList);
            BinNews("260", hnzcBiaoti, hnzcMiaoshu, hnzcId, hnzcList);
            BinNews("262", jyjlBiaoti, jyjlMiaoshu, jyjlId, jyjlList);

        }
        
        
    }
    /// <summary>
    /// 绑定信息
    /// </summary>
    /// <param name="lbid">新闻类别id</param>
    /// <param name="gzdtBiaoti">标题</param>
    /// <param name="gzdtMiaoshu">描述</param>
    /// <param name="gzdtId">id</param>
    /// <param name="gzdtList">列表</param>
    protected void BinNews(string strlbid, string strgzdtBiaoti, string strgzdtMiaoshu, string strgzdtId, string strgzdtList)
    {
        //工作动态
       DataTable dt = DbHelperMySQL.Query(" select * from t_news where CategoryId='"+strlbid+"'  and Approved='1' order by NewsId desc LIMIT 0,1").Tables[0];
        if (dt.Rows.Count > 0)
        {
            strgzdtBiaoti = dt.Rows[0]["title"].ToString();
            strgzdtMiaoshu = dt.Rows[0]["imgname"].ToString().Length>30? dt.Rows[0]["imgname"].ToString().Substring(0,30)+"..":dt.Rows[0]["imgname"].ToString();
            strgzdtId = dt.Rows[0]["newsid"].ToString();
        }
        //工作动态6条信息
        dt = DbHelperMySQL.Query(" select * from t_news where CategoryId='"+strlbid+"'  and Approved='1' order by NewsId desc LIMIT 1,11").Tables[0];
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                strgzdtList += "<li><span>■</span><a href=\"content.aspx?p=" + dr["newsid"] + "\">" + dr["title"] + "</a></li>";
            }

        }
        switch (strlbid)
        {
            case "275":
                zcfgBiaoti = strgzdtBiaoti;
                zcfgId = strgzdtId;
                zcfgList = strgzdtList;
                zcfgMiaoshu = strgzdtMiaoshu;
                break;
            case "260":
                hnzcBiaoti = strgzdtBiaoti;
                hnzcId = strgzdtId;
                hnzcList = strgzdtList;
                hnzcMiaoshu = strgzdtMiaoshu;
                break;
            case "262":
                jyjlBiaoti = strgzdtBiaoti;
                jyjlId = strgzdtId;
                jyjlList = strgzdtList;
                jyjlMiaoshu = strgzdtMiaoshu;
                break;
        }
    }
}