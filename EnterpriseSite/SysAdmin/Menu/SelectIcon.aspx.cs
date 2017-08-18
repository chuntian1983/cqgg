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
using System.IO;

public partial class SysAdmin_Menu_SelectIcon : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string path = "~/sysadmin/images/menu/left/logo/";
        string iconDirectory=Server.MapPath(path);
        string[] files = Directory.GetFiles(iconDirectory);
        ArrayList list = new ArrayList();
        foreach (string file in files)
        {
            if (file.Substring(file.LastIndexOf(".") + 1).ToLower() == "gif")
            {
                string fileName = file.Substring(file.LastIndexOf(@"\") + 1);
                string iconUrl = this.ResolveClientUrl(path + fileName);
                list.Add(iconUrl);
            }
        }
        this.dlIcon.DataSource = list;
        this.dlIcon.DataBind();
    }
}
