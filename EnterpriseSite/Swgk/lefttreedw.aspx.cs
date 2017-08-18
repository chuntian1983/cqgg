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
using Modules.Account;
using Modules.Department;
using CommonUtility;

public partial class Swgk_lefttreedw : System.Web.UI.Page
{
    private DepartmentCategoryBLL _category = new DepartmentCategoryBLL();
    public string deptid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            //p.Demand(179);
            deptid = Request.QueryString["deptid"];
            if (deptid != null)
            {
                this.treeCategory.Nodes.Add(this._category.GetCategoryTree(deptid,"contentdw.aspx"));
            }
            else
            {
                this.treeCategory.Nodes.Add(this._category.GetCategoryTree("0","contentdw.aspx"));
            }

        }
    }
}