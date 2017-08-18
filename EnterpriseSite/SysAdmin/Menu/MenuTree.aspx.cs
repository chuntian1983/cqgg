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

public partial class SysAdmin_MenuManager_MenuTree : System.Web.UI.Page
{
    private string _userId = HttpContext.Current.Request.Cookies["__UserInfo"]["userId"];
    private MenuBLL _menu = new MenuBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            p.Demand(10);
            this.tdDel.Visible = p.HasPermission(23);
            this.tdEdit.Visible = p.HasPermission(22);
            this.treeMenu.Nodes.Add(this._menu.GetMenuTree(true));
        }
    }

    protected void lbtnEdit_Click(object sender, EventArgs e)
    {
        ArrayList selectedNodes=this._menu.GetSelectedTreeNodes(this.treeMenu.Nodes[0]);
        if (selectedNodes.Count == 0) JSUtility.Alert("请选择一个要编辑的节点!");
        else if (selectedNodes.Count == 1)
        {
            string menuId = ((TreeNode)selectedNodes[0]).Value;
            Response.Redirect(String.Format("AddMenu.aspx?MenuId={0}", menuId), true);
        }
        else JSUtility.Alert("只能选择一个要编辑的节点!");
    }

    protected void lbtnDel_Click(object sender, EventArgs e)
    {
        ArrayList selectedNodes = this._menu.GetSelectedTreeNodes(this.treeMenu.Nodes[0]);
        if (selectedNodes.Count == 0) 
            JSUtility.Alert("请选择要删除的页节点!");
        else
        {
            int[] selectedIds = new int[selectedNodes.Count];
            for (int i = 0; i < selectedNodes.Count; i++)
            {
                selectedIds[i] = Convert.ToInt32(((TreeNode)selectedNodes[i]).Value);
            }
            bool sucess = this._menu.Delete(selectedIds);
            if (sucess) JSUtility.Alert("删除菜单项成功!");
            else JSUtility.Alert("包含子节点的菜单项无法删除,请先删除子节点!");
            this.treeMenu.Nodes.Clear();
            this.treeMenu.Nodes.Add(this._menu.GetMenuTree());
        }
        
    }
}
