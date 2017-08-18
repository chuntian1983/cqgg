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
using System.ComponentModel;
using System.Drawing;
using System.Web.SessionState;
using CommonUtility.DBUtility;
using Modules.City;



public partial class SysAdmin_City_City_List : System.Web.UI.Page
{
    CityDAL dal = new CityDAL();
    CityModal modal = new CityModal();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.PageBind();
        }
    }

    private void PageBind()
    {
        DataSet ds =  dal.GetList("");
        this.DataGrid1.DataSource = ds;
        this.DataGrid1.DataBind();
        for (int i = 0; i < this.DataGrid1.Items.Count; i++)
            ((ImageButton)this.DataGrid1.Items[i].FindControl("imgbDel")).Attributes.Add("onclick", "if(!window.confirm('确定删除吗？')) return false;");
    }



    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            int cityid = Int32.Parse(e.CommandArgument.ToString());
            dal.Delete(cityid);
            this.PageBind();
        }
    }


    protected void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        DataGrid1.CurrentPageIndex = e.NewPageIndex;
        PageBind();
    }
}
