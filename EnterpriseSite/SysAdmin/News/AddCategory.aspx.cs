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
using Modules.News;
using CommonUtility;

public partial class SysAdmin_News_AddCategory1 : System.Web.UI.Page
{
    private string _categoryId = HttpContext.Current.Request["CategoryId"];
    private NewsCategoryBLL _category = new NewsCategoryBLL();
    private string _userId = HttpContext.Current.User.Identity.Name;
    protected string _pageTitle = "添加新闻类别";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            BindParentCategory();
            if (this._categoryId != null)
            {
                p.Demand(160);
                int categoryId = Convert.ToInt32(this._categoryId);
                NewsCategoryDetail detail = this._category.GetCategoryDetail(categoryId);
                this.txtTitle.Text = detail.Title;
                this.txtSort.Text = detail.Sort.ToString();
                this.ddlParentCategory.SelectedValue = detail.ParentCategoryId.ToString();
                this._pageTitle = "修改文章类别";
                this.spanBack.Visible = true;
            }
            else
            {
                p.Demand(158);
            }
        }
    }

    private void BindParentCategory()
    {
        ArrayList items = this._category.GetSortedArticleCategoryItems(4);
        IEnumerator e = items.GetEnumerator();
        while (e.MoveNext())
        {
            CategoryEntity item = (CategoryEntity)e.Current;
            this.ddlParentCategory.Items.Add(new ListItem(item.Name, item.Id));
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        NewsCategoryDetail detail = new NewsCategoryDetail();
        detail.Title = this.txtTitle.Text.Trim();
        detail.Sort = Convert.ToInt32(this.txtSort.Text.Trim());
        detail.Type = 1;
        detail.ParentCategoryId = Convert.ToInt32(this.ddlParentCategory.SelectedValue);
        if (this._categoryId != null)
        {
            detail.CategoryId = Convert.ToInt32(this._categoryId);
            this._category.UpdateCategory(detail);

            JSUtility.AlertAndRedirect("修改成功!", "CategoryTree.Aspx");

        }
        else
        {
            detail.AddedUserId = Convert.ToInt32(this._userId);
            this._category.AddCategory(detail);
            this.ddlParentCategory.Items.Clear();
            BindParentCategory();

            this.txtSort.Text = String.Empty;
            this.txtTitle.Text = String.Empty;
            this.ddlParentCategory.SelectedIndex = 0;
            this.ddlType.SelectedIndex = 0;
            JSUtility.AlertAndRedirect("保存成功!", "CategoryTree.Aspx");
        }
    }
}