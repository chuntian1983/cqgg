using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modules;
using System.Data;
using System.Configuration;

public partial class Swgk_Default3 : System.Web.UI.Page
{
    public string deptid;
    public string st;
    public string dwurl;
    public string zwgk;
    public string cwgk;
    Modules.Link.LinkDetail lmodel = new Modules.Link.LinkDetail();
    Modules.Link.LinkBLL lbll = new Modules.Link.LinkBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        //dwurl = "maindw.aspx?deptid=<%=deptid %>&st=<%=st %>";
        dwurl = ConfigurationManager.AppSettings["dwurl"].ToString();
        zwgk = ConfigurationManager.AppSettings["zwgk"].ToString();
        cwgk = ConfigurationManager.AppSettings["cwgk"].ToString();
        //deptid = Request.QueryString["deptid"];
        //if (deptid != null)
        //{
        //    DataTable dtlink = lbll.GetLinkList(" deptid='" + deptid + "' and displaymode='0'").Tables[0];
        //    DataTable dtlinkz = lbll.GetLinkList(" deptid='" + deptid + "' and displaymode='1'").Tables[0];
        //    if (dtlink.Rows.Count > 0)
        //    {
        //        dwurl = dtlink.Rows[0]["link"].ToString();
        //    }
        //    if (dtlinkz.Rows.Count > 0)
        //    {
        //        zwgk = dtlinkz.Rows[0]["link"].ToString();
        //    }
        //}
        //st = Request.QueryString["st"];
        //if (deptid == null || deptid == "0")
        //{
        //    deptid = "0";
        //    dwurl = "http://60.217.72.17:8047/index.aspx";
        //    zwgk = "http://www.weihai.gov.cn/col/col350/index.html";
        //}
        //else if (deptid=="144")
        //{
        //    dwurl = "http://dwgk.rongcheng.gov.cn/";
        //    zwgk = "http://www.rongcheng.gov.cn/col/col22/index.html";
        //}
        //else if (deptid=="207")//tengjia
        //{
        //    dwurl = "http://www.tengjia.gov.cn/index.aspx?menuid=16&language=cn";
        //    zwgk = "http://www.tengjia.gov.cn/index.aspx?menuid=3&type=article&lanmuid=44&language=cn";
        //}
        //else if (deptid == "205")//renhe
        //{
        //    dwurl = "http://www.renhe.gov.cn/type.asp?zf11id=165";
        //    zwgk = "http://www.renhe.gov.cn/type.asp?zf11id=2";
        //}
        //else if (deptid == "209")//lidao
        //{
        //    dwurl = "http://www.lidao.gov.cn/index.aspx";
        //    zwgk = "http://www.lidao.gov.cn/index.aspx?menuid=3&type=article&lanmuid=89&language=cn";
        //}
        //else if (deptid == "196")//yatou
        //{
        //    dwurl = "http://www.yatou.gov.cn/dwgk/class/";
        //    zwgk = "http://www.yatou.gov.cn/index.php";
        //}
        //else if (deptid == "203")//renhe
        //{
        //    dwurl = "http://www.ytnongcun.com/dwgk/index.asp";
        //    zwgk = "http://www.wanglian.gov.cn/type.asp?zf11id=2";
        //}
        
        //if (st == null)
        //{
        //    //cwgk = "../neiye.aspx?id=259&deptid=" + deptid + "";
        //    //cwgk = "" + cwgk + "?deptid=0&zd=259";

        //}
        //else
        //{
        //    switch (st)
        //    {
        //        case "1":
        //            //cwgk = "../newlist2.aspx?id=259&deptid=" + deptid + "";
        //            cwgk = ""+cwgk+"?deptid=0&zd=259";
        //            break;
        //        case "2":
        //            //cwgk = "../townnewslist.aspx?id=259&deptid=" + deptid + "";
        //            cwgk = "" + cwgk + "?deptid=0&zd=259";
        //            break;
        //        default:
        //            //cwgk = "../neiye.aspx?id=259&deptid=" + deptid + "";
        //            cwgk = "" + cwgk + "?deptid=0&zd=259";
        //            break;
        //    }
        //}
    }
}