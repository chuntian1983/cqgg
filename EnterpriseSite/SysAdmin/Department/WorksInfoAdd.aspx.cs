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
using Modules.Department;
using Modules.Account;
using CommonUtility;

public partial class SysAdmin_Department_WorksInfoAdd : System.Web.UI.Page
{
    ExpertOutDAL dal = new ExpertOutDAL();
    ExpertOutModel model = new ExpertOutModel();
    DepartDAL dal1 = new DepartDAL();
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            p.Demand(189);
            CategoryBind();
            if (Request.QueryString["ID"] != null && Request.QueryString["ID"].ToString() != "")
            {
                int id = Int32.Parse(Request.QueryString["ID"].ToString());
                PageBill(id);
            }
           
        }
    }

    protected void CategoryBind()
    {
        DataSet ds=dal1.GetSonCategoryList();
        if (ds.Tables[0].Rows.Count > 0)
        {
            this.ddlType.DataSource = ds;
            this.ddlType.DataTextField = "Title";
            this.ddlType.DataValueField = "CategoryId";
            this.ddlType.DataBind();
        }
    }

    protected void PageBill(int id)
    {
        model = dal.GetModel1(id);
        string CategoryName = model.Characteristic.Trim();
        string CategoryId = dal1.GetCategoryId(CategoryName);
        this.ddlType.SelectedValue = CategoryId;
        this.txtTitle.Text = model.Name;
        this.txtOutTime.Text = model.OutTime;
        this.txtSort.Text = model.Sort.ToString();
        this.Label1.Text = "修改专家门诊信息";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int CategoryId = Int32.Parse(this.ddlType.SelectedValue.ToString());//获得专科科室类别
        string CategoryName = dal1.GetCategoryName(CategoryId);
        model.Characteristic = CategoryName;
        model.Name = this.txtTitle.Text;
        model.AddedUserId = 1;
        model.OutTime = this.txtOutTime.Text;
        model.AddDate = DateTime.Now;
        model.Sort =Int32.Parse(this.txtSort.Text.ToString());
        model.Price = "";
        model.Type = 1;
        if (Request.QueryString["ID"] != null)
        {
            model.ID = Int32.Parse(Request.QueryString["ID"].ToString());
            dal.Update(model);
            Response.Write("<Script>alert('修改成功！');location.href('WorksInfoList.aspx');</Script>");
        }
        else
        {
            dal.Add(model);
            Response.Write("<Script>alert('添加成功，请继续添加！');</Script>");
            this.txtTitle.Text = string.Empty;
            this.txtSort.Text = string.Empty;
            this.txtOutTime.Text = string.Empty;
            CategoryBind();
        }
    }
}
