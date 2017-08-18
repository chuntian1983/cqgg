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

public partial class SysAdmin_Department_CategoryTree : System.Web.UI.Page
{
    private DepartmentCategoryBLL _category = new  DepartmentCategoryBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            p.Demand(179);
            this.imgDel.Visible = this.lbtnDel.Visible = p.HasPermission(181);
            this.imgEdit.Visible = this.lbtnEdit.Visible = p.HasPermission(182);
            if (Request.Cookies["__userinfo"]["deptid"] != null)
            {
                string dtid = Request.Cookies["__userinfo"]["deptid"].ToString();
                if (dtid == "0")
                {
                    this.treeCategory.Nodes.Add(this._category.GetCategoryTree());
                }
                else
                {
                    this.treeCategory.Nodes.Add(this._category.GetCategoryTree(int.Parse(dtid)));
                }
            }
            else
            {
                this.treeCategory.Nodes.Add(this._category.GetCategoryTree());
            }
        }
    }

    protected void lbtnEdit_Click(object sender, EventArgs e)
    {
        ArrayList selectedNodes = this._category.GetSelectedTreeNodes(this.treeCategory.Nodes[0]);
        if (selectedNodes.Count == 0) JSUtility.Alert("请选择一个要编辑的节点!");
        else if (selectedNodes.Count == 1)
        {
            string categoryId = ((TreeNode)selectedNodes[0]).Value;
            Response.Redirect(String.Format("AddCategory.aspx?CategoryId={0}", categoryId), true);
        }
        else JSUtility.Alert("只能选择一个要编辑的节点!");
    }

    protected void lbtnDel_Click(object sender, EventArgs e)
    {
        ArrayList selectedNodes = this._category.GetSelectedTreeNodes(this.treeCategory.Nodes[0]);
        if (selectedNodes.Count == 0)
            JSUtility.Alert("请选择要删除的页节点!");
        else
        {
            int[] selectedIds = new int[selectedNodes.Count];
            for (int i = 0; i < selectedNodes.Count; i++)
            {
                selectedIds[i] = Convert.ToInt32(((TreeNode)selectedNodes[i]).Value);
            }
           bool sucess = this._category.DeleteCategory(selectedIds);
           // bool sucess = this._category.DEL(selectedIds);
            if (sucess) JSUtility.Alert("删除菜单项成功!");
            else JSUtility.Alert("包含子节点的菜单项无法删除,请先删除子节点!");
            this.treeCategory.Nodes.Clear();
            this.treeCategory.Nodes.Add(this._category.GetCategoryTree());
        }
    }
}
