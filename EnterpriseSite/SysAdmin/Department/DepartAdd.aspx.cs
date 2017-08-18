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
using Modules.Department;
using Modules.Account;
using CommonUtility;

public partial class SysAdmin_Department_DepartAdd : System.Web.UI.Page
{
    private string _departId = HttpContext.Current.Request["DepartId"];
    private DepartmentBLL _depart = new DepartmentBLL();
    private DepartmentCategoryBLL _category = new DepartmentCategoryBLL();
    DepartDAL dal = new DepartDAL();
    private string _userId = HttpContext.Current.User.Identity.Name;
    protected string _pageTitle = "添加科室介绍";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            BindCategory();
            if (this._departId != null)
            {
                p.Demand(185);
                int departId = Convert.ToInt32(this._departId);
                DepartmentDetail detail = this._depart.GetDepartmentDetail(departId);
                this.txtTitle.Text = detail.Title;
                this.fckBody.Value = detail.Body;
                this.ddlType.SelectedValue = detail.CategoryId.ToString();
                ViewState["Approved"] = detail.Approved;
                ViewState["ViewCount"] = detail.ViewCount;
                this._pageTitle = "修改科室介绍";
                this.spanBack.Visible = true;
            }
            else
            {
                p.Demand(183);
            }
        }
    }
    private void BindCategory()
    {
        ArrayList items = this._category.GetSortedDepartmentCategoryItems(4);
        IEnumerator e = items.GetEnumerator();
        while (e.MoveNext())
        {
            CategoryEntity item = (CategoryEntity)e.Current;
            this.ddlType.Items.Add(new ListItem(item.Name, item.Id));
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DepartmentDetail detail = new DepartmentDetail();
        detail.Title = this.txtTitle.Text.Trim();
        detail.Body = this.fckBody.Value.Trim();
        if (ddlType.SelectedIndex == 0)
        {
            Response.Write("<Script>alert('请选择科室名称');</Script>");
        }
        else
            detail.CategoryId = Convert.ToInt32(this.ddlType.SelectedValue);
        detail.ImgLink = "";
        if (this._departId != null)
        {
            int depatId = Convert.ToInt32(this._departId);
            detail.DepartId = depatId;
            detail.Approved = (int)ViewState["Approved"];
            detail.ViewCount = (int)ViewState["ViewCount"];
            this._depart.Update(detail);
            JSUtility.Alert("修改科室成功!");
            JSUtility.CloseWindow();
        }
        else
        {
            detail.Approved = 0;
            detail.ViewCount = 0;
            detail.AddedUserId = Convert.ToInt32(this._userId);
            int ret = this._depart.Add(detail);
            if (ret == -2)
                JSUtility.Alert("该类别只允许添加1篇文章，请到列表中查找然后修改!");
            else
            {
                JSUtility.Alert("添加文章成功!请继续添加！");
                this.txtTitle.Text = String.Empty;
                this.fckBody.Value = String.Empty; 
                this.ddlType.SelectedIndex = 0;
            }
        }
    }

    
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        int CategoryId = Int32.Parse(this.ddlType.SelectedValue.ToString());
        string ParentCategoryId=dal.GetParentCategoryId(CategoryId).Trim();
        if (ParentCategoryId == "3" || CategoryId == 3)
        {
            Response.Redirect("WorksInfoAdd.aspx");
        }
    }
}
