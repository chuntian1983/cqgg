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
using Modules.Member;
using Modules.Applyforjob;

public partial class Controls_zpxx : System.Web.UI.UserControl
{
    MemberBLL bll = new MemberBLL();
    ApplyforjobBLL bll1 = new ApplyforjobBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            PageBill();
        }
    }

    private void PageBill()
    {
        //取得推荐单位名称 前三个
        DataSet ds = bll.GetTjCompanyInfo(3);
        if (ds.Tables[0].Rows.Count > 0)
        {
            this.DlZP.DataSource = ds;
            this.DlZP.DataBind();
            foreach (DataListItem item in this.DlZP.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    DataList dl = (DataList)(item.FindControl("DlZP1"));
                    int id = Int32.Parse(((Label)this.DlZP.Items[item.ItemIndex].FindControl("LabId")).Text);
                    //取1个岗位
                    DataSet ds1 = bll1.GetGwNameByID1(id);
                    dl.DataSource = ds1;
                    dl.DataBind();
                }

            }
        }
    }
}

