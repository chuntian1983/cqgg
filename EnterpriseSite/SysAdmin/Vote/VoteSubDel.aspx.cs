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

public partial class SysAdmin_Vote_VoteSubDel : System.Web.UI.Page
{
    VoteOperate index = new VoteOperate();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
            {
                VoteSubDAL dal = new VoteSubDAL();
                int sid = Int32.Parse(Request.QueryString["id"].ToString());
                dal.Delete(sid);
                index.VoteTypeDelete1(sid);

                Response.Write("<script>alert('删除该主题成功!');location.href('VoteSublist.aspx');</script>");
            }
            else
                Response.Write("<script>alert('删除该主题失败!');location.href('VoteSublist.aspx');</script>");
        }
    }
}
