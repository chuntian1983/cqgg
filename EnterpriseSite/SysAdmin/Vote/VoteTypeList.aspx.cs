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
using CommonUtility.DBUtility;

public partial class SysAdmin_Vote_VoteTypeList : System.Web.UI.Page
{
    VoteOperate index = new VoteOperate();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            if (Request.QueryString["vid"] != null && Request.QueryString["vid"].ToString() != "")
            {
                int voteid = Int32.Parse(Request.QueryString["vid"].ToString());
                this.lbvoteid.Text = Request.QueryString["vid"].ToString();
                PageBill(voteid);
            }

            else
                PageBill();


        }
    }

    private void PageBill(int vvid)
    {
        ds = index.VoteTypeGetList1(vvid);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataView dv = ds.Tables[0].DefaultView;
            this.dgType.DataSource = dv;
            this.dgType.DataBind();
        }
    }

    private void PageBill()
    {
        ds = index.VoteTypeGetList();
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataView dv = ds.Tables[0].DefaultView;
            this.dgType.DataSource = dv;
            this.dgType.DataBind();
        }
    }

    protected void ButDelAllInfo_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < this.dgType.Items.Count; i++)
        {
            if (((System.Web.UI.HtmlControls.HtmlInputCheckBox)this.dgType.Items[i].FindControl("chk")).Checked == true)
            {
                int numID = Int32.Parse(((Label)this.dgType.Items[i].FindControl("LabId")).Text);
                string sql = "delete from T_VoteType where ID=" + numID;
                SQLHelper.ExecuteSql(sql);
            }
        }
        Response.Redirect(Request.RawUrl);
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("VoteType.aspx?vid=" + this.lbvoteid.Text.ToString());
    }

    protected void dgType_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ((HtmlInputCheckBox)e.Item.FindControl("chk")).Value = e.Item.Cells[2].Text;

            if (e.Item.Cells[5].Text == "0")
            {
                e.Item.Cells[5].Text = "<a href='javascript:MominateIndex_Node1(0," + e.Item.Cells[2].Text + ")'><font color=green>是</font></a>";
            }
            else
            {
                e.Item.Cells[5].Text = "<a href='javascript:MominateIndex_Node1(1," + e.Item.Cells[2].Text + ")'><font color=red>否</font></a>";
            }
        }
    }



  
}
