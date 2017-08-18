using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CommonUtility.DBUtility;
using Modules.Account;

public partial class SysAdmin_Picture_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        AdoHelper helper = AdoHelper.CreateHelper();
        DataTable dt = helper.ExecuteDataset("select * from [T_Picture_Picture]").Tables[0];
        if (dt.Rows.Count>0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string uid = dt.Rows[i]["UploadUserId"].ToString();
                string zid = dt.Rows[i]["PictureId"].ToString();
                UserDetail model = new UserDetail();
                UserBLL bll = new UserBLL();
                model = bll.GetUserDetail(int.Parse(uid));
                if (model!=null)
                {
                    helper.ExecuteNonQuery("update T_Picture_Picture set deptid='"+model.Email+"' where PictureId='"+zid+"'");
                }
            }
        }
    }
}