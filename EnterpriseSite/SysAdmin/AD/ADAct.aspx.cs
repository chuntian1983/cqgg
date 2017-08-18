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
using System.Xml;
using Modules.AD;

public partial class SysAdmin_AD_ADAct : System.Web.UI.Page
{
    private string strXML = string.Empty;
    private XmlDocument objDom;		

    protected void Page_Load(object sender, EventArgs e)
    {
        strXML = Request.Form.ToString();
        strXML = Server.UrlDecode(strXML);
        objDom = new XmlDocument();
        objDom.LoadXml(strXML);

        string UserAction = objDom.GetElementsByTagName("UserAction")[0].InnerText;
        switch (UserAction)
        {
            case "CreateJS":
                CreateJS();
                break;
            case "Show":
                Show();
                break;
            case "DelAD":
                DelAD();
                break;
            default:
                Response.AddHeader("msg", "参数错误！");
                break;
        }
    }

    private void CreateJS()
    {
        int ID = int.Parse(objDom.GetElementsByTagName("ID")[0].InnerText);
        ADDetail dal = new ADDetail();
        dal.CreateJS(ID);
    }

    private void Show()
    {
        string ID = objDom.GetElementsByTagName("ID")[0].InnerText;
        string Flag = objDom.GetElementsByTagName("Flag")[0].InnerText;
        ADDetail dal = new ADDetail();
        dal.Show(Flag, ID);
    }

    private void DelAD()
    {
        string ID = objDom.GetElementsByTagName("ID")[0].InnerText;
        ADDetail dal = new ADDetail();
        dal.DelAD(ID);
    }
}
