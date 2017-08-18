using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class Swgk_contentdw : System.Web.UI.Page
{
    Modules.T_BMFW.BLL.T_BMFW bll = new Modules.T_BMFW.BLL.T_BMFW();
    Modules.Department.DepartmentCategoryBLL dbll = new Modules.Department.DepartmentCategoryBLL();
    Modules.News.NewsBLL bllnew = new Modules.News.NewsBLL();
    public string deptid;
    protected void Page_Load(object sender, EventArgs e)
    {
        deptid = Request.QueryString["deptid"];
        if (!IsPostBack)
        {
            if (deptid != null)
            {

                bindData();

            }

        }
    }
    void bindData()
    {
        
        DataTable dt = bllnew.GetListbylbid(int.Parse(deptid), "232,233,234,235,236,237,238,239,240");

        AspNetPager1.RecordCount = dt.Rows.Count;
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = dt.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.PageSize = AspNetPager1.PageSize;
        this.gvArticleList.DataSource = pds;
        this.gvArticleList.DataBind();

    }
    protected void AspNetPager1_PageChanged(object src, EventArgs e)
    {
        bindData();
    }
}