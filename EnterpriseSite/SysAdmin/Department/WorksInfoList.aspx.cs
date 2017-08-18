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
using Modules.Workers;
using System.Text;
using Modules.Account;

public partial class SysAdmin_Department_WorksInfoList : System.Web.UI.Page
{
    ExpertOutDAL dal = new ExpertOutDAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            p.Demand(190);
            BindWorker();
        }
    }

    protected void ibtnDel_Command(object sender, CommandEventArgs e)
    {
        int ID= Int32.Parse(e.CommandArgument.ToString());
        dal.Delete1(ID);
        BindWorker();
    }

    protected void pageBar_PageIndexChanged(object sender, PageIndexChangedEventArguments e)
    {
        BindWorker();
    }

    private void BindWorker()
    {
        int count;
        string filter = this.SetFilter();
        string sort = "Sort asc,ID";
        int index = this.pageBar.PageIndex;
        int size = this.pageBar.PageSize;
        this.gvWorkerList.DataSource = dal.GetExpertOutList1("*", filter, sort, index, size, out count);
        this.gvWorkerList.DataBind();
        this.pageBar.RecordCount = count;
    }

    private string SetFilter()
    {
        StringBuilder filter = new StringBuilder();
        filter.Append("1=1");
        filter.Append(" and Type=1");
        ViewState["Filter"] = filter.ToString();
        return filter.ToString();
    }

}
