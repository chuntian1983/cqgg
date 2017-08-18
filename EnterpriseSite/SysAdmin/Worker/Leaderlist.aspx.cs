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
using Modules.Article;
using Modules.Account;

public partial class SysAdmin_Worker_Leaderlist : System.Web.UI.Page
{
    WorkerDAL dal = new WorkerDAL();
    ArticleDAL1 dal1 = new ArticleDAL1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            p.Demand(171);
           BindWorker();
        }
    }


    protected void ibtnDel_Command(object sender, CommandEventArgs e)
    {
        int workerId = Convert.ToInt32(e.CommandArgument);
       string Name= dal.GetPersonNameById(workerId);
       if (dal1.Exists(Name) == true)
       {
           dal1.Delete(Name);
       }
        dal.Delete(workerId);
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
        this.gvWorkerList.DataSource = dal.GetWorkerList1("*", filter, sort, index, size, out count);
        this.gvWorkerList.DataBind();
        this.pageBar.RecordCount = count;
    }

    private string SetFilter()
    {
        StringBuilder filter = new StringBuilder();
        filter.Append("1=1");
        filter.Append(" and PersonType=0");
        ViewState["Filter"] = filter.ToString();
        return filter.ToString();
    }
}
