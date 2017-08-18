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

public partial class SysAdmin_Vote_VoteTypeDel : System.Web.UI.Page
{
    public int id=0;
    VoteOperate index = new VoteOperate();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            if (Request.QueryString["id"].ToString() != "")
            {
                id = Int32.Parse(Request.QueryString["id"].ToString());
                index.VoteTypeDelete1(id);
                if (Request.QueryString["vid"] != null && Request.QueryString["vid"].ToString() != "")
                {
                    int vid = Int32.Parse(Request.QueryString["vid"].ToString());//用来放置投票主题的编号
                    Response.Write("<script>alert('删除成功!');location.href('VoteTypeList.aspx?vid=" + vid + "');</script>");
                }
                else
                    Response.Write("<script>alert('删除成功!');location.href('VoteTypeList.aspx');</script>");
            }
            else
            {
                Response.Write("<script>alert('删除出错!');location.href('VoteTypeList.aspx');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('删除出错!');location.href('VoteTypeList.aspx');</script>");
        }
    }
}
