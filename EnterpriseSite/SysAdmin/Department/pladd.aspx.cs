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
using Maticsoft.Common;

public partial class SysAdmin_Department_pladd : System.Web.UI.Page
{
    private string _categoryId = HttpContext.Current.Request["CategoryId"];
    private DepartmentCategoryBLL _category = new DepartmentCategoryBLL();
    private string _userId = HttpContext.Current.User.Identity.Name;
    protected string _pageTitle = "添加行政级别";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            BindParentCategory();
            if (this._categoryId != null)
            {
                p.Demand(182);
                int categoryId = Convert.ToInt32(this._categoryId);
                DepartmentCategoryDetail detail = this._category.GetCategoryDetail(categoryId);
                this.txtTitle.Text = detail.Title;
                this.txtSort.Text = detail.Sort.ToString();
                this.ddlParentCategory.SelectedValue = detail.ParentCategoryId.ToString();
                this._pageTitle = "修改行政级别";
                this.spanBack.Visible = true;
            }
            else
            {
                p.Demand(180);
            }
        }
    }

    private void BindParentCategory()
    {
        ArrayList items = this._category.GetSortedDepartmentCategoryItems(4);
        IEnumerator e = items.GetEnumerator();
        while (e.MoveNext())
        {
            CategoryEntity item = (CategoryEntity)e.Current;
            this.ddlParentCategory.Items.Add(new ListItem(item.Name, item.Id));
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.txtTitle.Text.Trim()))
        {
            string[] strlist = this.txtTitle.Text.Split('|');
            for (int i = 0; i < strlist.Length; i++)
            {
                if (strlist[i]!=null&&strlist[i]!="")
                {
                    DepartmentCategoryDetail detail = new DepartmentCategoryDetail();
                    detail.Title = strlist[i];
                    detail.Sort = i;
            detail.ParentCategoryId = Convert.ToInt32(this.ddlParentCategory.SelectedValue);
            detail.AddedUserId = Convert.ToInt32(this._userId);
            detail.AddedDate = System.DateTime.Now.ToString();
            this._category.Add(detail);
                }
            }
            MessageBox.Show(this, "添加成功");
            this.ddlParentCategory.Items.Clear();
            BindParentCategory();

            this.txtSort.Text = String.Empty;
            this.txtTitle.Text = String.Empty;
            this.ddlParentCategory.SelectedIndex = 0;
            this.ddlType.SelectedIndex = 0;
        }
        
    }
}