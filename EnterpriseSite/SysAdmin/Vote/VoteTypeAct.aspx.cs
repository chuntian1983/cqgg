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
using Modules.Vote;

public partial class SysAdmin_Vote_VoteTypeAct : System.Web.UI.Page
{
    private string strXML = string.Empty;
    private XmlDocument objDom;
    VoteOperate index = new VoteOperate();

    private void Page_Load(object sender, System.EventArgs e)
    {
        strXML = Request.Form.ToString();
        strXML = Server.UrlDecode(strXML);
        objDom = new XmlDocument();
        objDom.LoadXml(strXML);

        string UserAction = objDom.GetElementsByTagName("UserAction")[0].InnerText;
        switch (UserAction)
        {
            case "MominateIndex":
                MominateIndex();
                break;
            case "MominateIndex1":
                MominateIndex1();
                break;
            default:
                Response.AddHeader("msg", "参数错误！");
                break;
        }
    }
    private void MominateIndex()
    {
        string ID = objDom.GetElementsByTagName("ID")[0].InnerText.ToString();
        string Flag = objDom.GetElementsByTagName("Flag")[0].InnerText.ToString();

        string vouch = "0";
        if (Flag == "0")
        {
            vouch = "1";
        }
        else if (Flag == "1")
        {
            vouch = "0";
        }
        else
        {
            Response.AddHeader("msg", "参数错误！");
        }
        index.VoteTypeUpdate(Int32.Parse(ID), vouch, "");
    }

    private void MominateIndex1()
    {
        string ID = objDom.GetElementsByTagName("ID")[0].InnerText.ToString();
        string Flag = objDom.GetElementsByTagName("Flag")[0].InnerText.ToString();
        VoteSubDAL dal = new VoteSubDAL();
        VoteSubModel modal = new VoteSubModel();
        VoteSubModel modal1 = new VoteSubModel();
        string vouch = "0";
        if (Flag == "0")
        {
            vouch = "1";
        }
        else if (Flag == "1")
        {
            vouch = "0";
        }
        else
        {
            Response.AddHeader("msg", "参数错误！");
        }
        modal = dal.GetModel(Int32.Parse(ID));
        modal1.Vote = modal.Vote;
        modal1.FillTime = modal.FillTime;
        modal1.ID = Int32.Parse(ID);
        modal1.Vouch = Int32.Parse(vouch);
        dal.Update(modal1);


    }
}
