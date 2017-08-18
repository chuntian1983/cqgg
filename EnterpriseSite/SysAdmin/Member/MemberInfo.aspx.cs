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
using Modules.Member;

public partial class SysAdmin_Member_MemberInfo : System.Web.UI.Page
{
    private MemberBLL _member = new MemberBLL();
   
    private string _memberId = HttpContext.Current.Request["MemberId"];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (this._memberId != null)
            {
                int memberId = Convert.ToInt32(this._memberId);
                DataSet ds= _member.GetCompanyInfo(memberId);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    this.lbName.Text = ds.Tables[0].Rows[0]["Nickname"].ToString();
                    this.lbCompany.Text = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                    switch (ds.Tables[0].Rows[0]["CompanySize"].ToString())
                    {
                        case "0": this.lbSize.Text = "少于50人"; break;
                        case "1": this.lbSize.Text = "50-100人"; break;
                        case "2": this.lbSize.Text = "150-500人"; break;
                        case "3": this.lbSize.Text = "500人以上"; break;
                    }
                    switch (ds.Tables[0].Rows[0]["CompanyCharacter"].ToString())
                    {
                        case "0": this.lbCharacter.Text = "外商独资企业"; break;
                        case "1": this.lbCharacter.Text = "中外合营/合资/合作"; break;
                        case "2": this.lbCharacter.Text = "跨国企业"; break;
                        case "3": this.lbCharacter.Text = "私营/民营企业"; break;
                        case "4": this.lbCharacter.Text = "国有企业"; break;
                        case "5": this.lbCharacter.Text = "国内上市公司"; break;
                        case "6": this.lbCharacter.Text = "政府机关/非盈利机构"; break;
                        case "7": this.lbCharacter.Text = "事业单位"; break;
                        case "8": this.lbCharacter.Text = "其他"; break;
                    }
                    this.lbLicenseID.Text = ds.Tables[0].Rows[0]["LicenseID"].ToString();
                    this.lbOrgan.Text = ds.Tables[0].Rows[0]["Organ"].ToString();
                    this.lbLocus.Text = ds.Tables[0].Rows[0]["Locus"].ToString();
                    this.lbAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    this.lbPost.Text = ds.Tables[0].Rows[0]["Post"].ToString();
                    this.lbLinkman.Text = ds.Tables[0].Rows[0]["Linkman"].ToString();
                    this.lbTel.Text = ds.Tables[0].Rows[0]["Tel"].ToString();
                    this.lbFax.Text = ds.Tables[0].Rows[0]["Fax"].ToString();
                    this.lbEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    this.lbWeb.Text = ds.Tables[0].Rows[0]["Web"].ToString();
                    this.lbAddDate.Text = DateTime.Parse(ds.Tables[0].Rows[0]["AddedDate"].ToString()).ToShortDateString();
                    this.liCompanyInfo.Text = UnCode(ds.Tables[0].Rows[0]["CompanyInfo"].ToString());
                    this.lbQuestion.Text = ds.Tables[0].Rows[0]["Province"].ToString();
                    this.lbAnswer.Text = ds.Tables[0].Rows[0]["City"].ToString();
                    this.lbPassEmail.Text = ds.Tables[0].Rows[0]["Email1"].ToString();
                    this.lbpwd.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
                }
            }
          
        }
    }

    public string UnCode(string content)
    {
        string str1 = content.Replace("&amp;", "&");
        string str2 = str1.Replace("&quot;", "\"");
        string str3 = str2.Replace("<br>", "\r\n");
        string str4 = str3.Replace("&nbsp;", " ");
        string str5 = str4.Replace("'", "&apos;");
        string str6 = str5.Replace("&gt;", ">");
        string str7 = str6.Replace("&lt;", "<");
        return str7;
    }
}
