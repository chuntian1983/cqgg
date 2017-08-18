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
using Modules.Account;

public partial class SysAdmin_Vote_VoteSubList : System.Web.UI.Page
{
    VoteSubDAL dal = new VoteSubDAL();
    VoteOperate index = new VoteOperate();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            p.Demand(199);
            PageBill();
        }
    }

    private void PageBill()
    {
        DataSet ds = new DataSet();
        ds = dal.GetList("");
        if (ds.Tables[0].Rows.Count > 0)
        {
            this.dgSub.DataSource = ds;
            this.dgSub.DataBind();
        }
    }
    //全部选中的删除
    protected void ButDelAllInfo_Click(object sender, EventArgs e)
    {
        VoteSubDAL dal = new VoteSubDAL();
        if (this.allchk.Checked == true)
        {
            for (int i = 0; i < this.dgSub.Items.Count; i++)
            {
                if (((System.Web.UI.HtmlControls.HtmlInputCheckBox)this.dgSub.Items[i].FindControl("chk")).Checked == true)
                {
                    int numID = Int32.Parse(((Label)this.dgSub.Items[i].FindControl("LabId")).Text);
                    dal.Delete(numID);
                    index.VoteTypeDelete1(numID);
                }
            }
            Response.Redirect(Request.RawUrl);
        }
    }

    //是否推荐的选择
    protected void dgSub_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ((HtmlInputCheckBox)e.Item.FindControl("chk")).Value = e.Item.Cells[2].Text;
            if (e.Item.Cells[4].Text == "0")
            {
                e.Item.Cells[4].Text = "<a href='javascript:MominateIndex_Node1(0," + e.Item.Cells[2].Text + ")'><font color=green>是</font></a>";
            }
            else
            {
                e.Item.Cells[4].Text = "<a href='javascript:MominateIndex_Node1(1," + e.Item.Cells[2].Text + ")'><font color=red>否</font></a>";
            }
        }
    }
}
