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
using System.ComponentModel;
using System.Drawing;
using System.Web.SessionState;
using CommonUtility.DBUtility;
using Modules.City;


public partial class SysAdmin_City_City_Conf : System.Web.UI.Page
{
    CityDAL dal = new CityDAL();
    CityModal modal = new CityModal();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.Params["CityID"] != null)
            {
                int cityid = Int32.Parse(Request.Params["CityID"].ToString());
                modal = dal.GetModel(cityid);
                this.txtCityID.Text = modal.CityID.ToString();
                this.txtCityName.Text =modal.CityName.ToString();
                this.txtCode1.Text = modal.Code1.ToString();
                this.txtCode2.Text = modal.Code2.ToString();
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
       
        string msg = "";
        if (this.txtCityID.Text == "")
        {
            modal.CityName = this.txtCityName.Text;
            modal.Code1 = this.txtCode1.Text;
            modal.Code2 = this.txtCode2.Text;
            dal.Add(modal);
            msg = "新增城市成功!";
        }
        else
        {
            modal.CityID=Convert.ToInt32(this.txtCityID.Text);
            modal.CityName = this.txtCityName.Text;
            modal.Code1 = this.txtCode1.Text;
            modal.Code2 = this.txtCode2.Text;
            dal.Update(modal);
            msg = "修改城市成功!";
        }
     
        Response.Write("<script>alert('" + msg + "');document.location.replace('City_List.aspx');</script>");
    }
}
