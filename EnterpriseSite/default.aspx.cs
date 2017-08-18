using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Modules.Picture;
using Modules.News;
using System.Configuration;

public partial class taishan1 : System.Web.UI.Page
{
   
    Modules.Department.DepartmentCategoryDetail deptmodel = new Modules.Department.DepartmentCategoryDetail();
    Modules.Department.DepartmentCategoryBLL deptbll = new Modules.Department.DepartmentCategoryBLL();
   
    protected void Page_Load(object sender, EventArgs e)
    {

        DataTable dt = deptbll.GetChildCategoryItems(3942).Tables[0];
        this.rep1.DataSource = dt;
        this.rep1.DataBind();

    }
    protected string GetWeek(string dt)
    {
        string week = "星期一";
        //根据取得的英文单词返回汉字 
        switch (dt)
        {
            case "Monday":
                week = "星期一";
                break;
            case "Tuesday":
                week = "星期二";
                break;
            case "Wednesday":
                week = "星期三";
                break;
            case "Thursday":
                week = "星期四";
                break;
            case "Friday":
                week = "星期五";
                break;
            case "Saturday":
                week = "星期六";
                break;
            case "Sunday":
                week = "星期日";
                break;
        }
        return week;
    }
    protected void rep1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater rep = e.Item.FindControl("rep2") as Repeater;//找到里层的repeater对象
            DataRowView rowv = (DataRowView)e.Item.DataItem;//找到分类Repeater关联的数据项 
            int typeid = Convert.ToInt32(rowv["categoryid"]); //获取填充子类的id 
            rep.DataSource = deptbll.GetChildCategoryItems(typeid).Tables[0];
            rep.DataBind();
        }
    }
}