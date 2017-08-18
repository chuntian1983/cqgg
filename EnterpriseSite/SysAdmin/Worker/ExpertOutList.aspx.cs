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

public partial class SysAdmin_Worker_ExpertOutList : System.Web.UI.Page
{
    ExpertOutDAL dal = new ExpertOutDAL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            p.Demand(175);
            BindWorker();
        }
    }

   

    protected void ibtnDel_Command(object sender, CommandEventArgs e)
    {
        string ExpertName = e.CommandArgument.ToString();
        dal.Delete(ExpertName);
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
        string sort = "sot asc,ID";
        int index = this.pageBar.PageIndex;
        int size = this.pageBar.PageSize;
        this.gvWorkerList.DataSource = dal.GetExpertOutList("*", filter, sort, index, size, out count);
        this.gvWorkerList.DataBind();
        this.pageBar.RecordCount = count;
    }

    private string SetFilter()
    {
        StringBuilder filter = new StringBuilder();
        filter.Append("1=1");
        //filter.Append(" and Type=0");
        ViewState["Filter"] = filter.ToString();
        return filter.ToString();
    }
}
