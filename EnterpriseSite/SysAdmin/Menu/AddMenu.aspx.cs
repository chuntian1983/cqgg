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
using Modules.Menu;
using CommonUtility;

public partial class SysAdmin_MenuManager_AddOrEditMenu : System.Web.UI.Page
{
    private string _menuId = HttpContext.Current.Request["MenuId"];
    private MenuBLL _menu = new MenuBLL();
    protected string _pageTitle = "添加菜单项";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            BindDDL();
            if (this._menuId != null)
            {
                p.Demand(22);
                int menuId = Convert.ToInt32(this._menuId);
                MenuDetail detail = _menu.GetMenuDetail(menuId);
                this.txtMenuName.Text = detail.Name;
                this.txtMenuLink.Text = detail.MenuLink;
                this.txtImageLink.Text = detail.ImageLink;
                this.txtSort.Text = detail.Sort.ToString();
                this.cbIsVisible.Checked = detail.IsVisible==1?true:false;
                this.ddlParentMenu.SelectedValue = detail.ParentMenuId.ToString();
                this._pageTitle = "修改菜单项";
            }
            else
            {
                p.Demand(21);
            }
        }
    }
   private void BindDDL()
   {
       ArrayList items=this._menu.AllMenuItemForUpdate();
       IEnumerator e=items.GetEnumerator();
       while (e.MoveNext())
       {
           MenuEntity item = (MenuEntity)(e.Current);
           ListItem li=new ListItem(item.Name,item.Id);
           this.ddlParentMenu.Items.Add(li);
       }
   }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool isSuccess;
        MenuDetail detail = new MenuDetail();
        detail.Name = this.txtMenuName.Text.Trim();
        detail.MenuLink = this.txtMenuLink.Text.Trim();
        detail.ImageLink = this.txtImageLink.Text.Trim();
        detail.IsVisible = this.cbIsVisible.Checked==true?1:0;
        detail.Sort = Convert.ToInt32(this.txtSort.Text.Trim());
        detail.ParentMenuId = Convert.ToInt32(this.ddlParentMenu.SelectedValue);
        if (this._menuId != null)
        {
            int menuId = Convert.ToInt32(this._menuId);
            detail.MenuId = menuId;
            isSuccess=this._menu.Update(detail);
            if (isSuccess) JSUtility.AlertAndRedirect("更新菜单项成功!","menuTree.aspx");
            else JSUtility.Alert("更新菜单项失败!");
        }
        else
        {
            this._menu.Add(detail);
            this.ddlParentMenu.Items.Clear();
            BindDDL();
            this.txtMenuName.Text = String.Empty;
            this.txtMenuLink.Text = String.Empty;
            this.txtImageLink.Text = String.Empty;
            this.txtSort.Text = String.Empty;
            this.cbIsVisible.Checked = false;
            JSUtility.Alert("添加菜单项成功!");
           
        }
    }
}
