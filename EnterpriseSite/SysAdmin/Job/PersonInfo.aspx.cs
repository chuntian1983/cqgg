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
using Modules.Applyforjob;

public partial class SysAdmin_Job_PersonInfo : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["PersonID"] != null && Request.QueryString["PersonID"].ToString() != "")
            {
                int pid = Int32.Parse(Request.QueryString["PersonID"].ToString());
                PageBill(pid);  
            }
        }
    }

    protected void PageBill(int PersonID)
    {
        ApplyforjobBLL bll = new ApplyforjobBLL();
        DataSet ds=bll.GetOnePersonInfo(PersonID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //简历编号
            this.lbResumeId.Text = ds.Tables[0].Rows[0]["ResumeID"].ToString();
            //刷新简历时间
            this.lbChangeTime.Text = DateTime.Parse(ds.Tables[0].Rows[0]["ChangeTime"].ToString()).ToLongDateString();
            //会员姓名
            this.lbName.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
            //欲应聘岗位
            switch (ds.Tables[0].Rows[0]["JobType"].ToString())
            {
                case "0": this.lbJobType.Text = "全/兼职"; break;
                case "1": this.lbJobType.Text = "兼职"; break;
                case "2": this.lbJobType.Text = "全职"; break;
                case "3": this.lbJobType.Text = "实习"; break;
            }
            this.lbJobName.Text = ds.Tables[0].Rows[0]["JobName"].ToString();
            //工作要求
            this.lbWorkNow.Text = ds.Tables[0].Rows[0]["WorkNow"].ToString();
            switch (ds.Tables[0].Rows[0]["CompanyTypeNow"].ToString())
            {
                case "0": this.lbCompanyTypeNow.Text = "事业"; break;
                case "1": this.lbCompanyTypeNow.Text = "国有"; break;
                case "2": this.lbCompanyTypeNow.Text = "外资"; break;
                case "3": this.lbCompanyTypeNow.Text = "股份制"; break;
                case "4": this.lbCompanyTypeNow.Text = "私营"; break;
                case "5": this.lbCompanyTypeNow.Text = "集体"; break;
                case "6": this.lbCompanyTypeNow.Text = "有限责任"; break;
                case "7": this.lbCompanyTypeNow.Text = "独资"; break;
                case "8": this.lbCompanyTypeNow.Text = "合资"; break;
                case "9": this.lbCompanyTypeNow.Text = "其他"; break;
            }
            switch (ds.Tables[0].Rows[0]["CompanyType"].ToString())
            {
                case "0": this.lbCompanyType.Text = "事业"; break;
                case "1": this.lbCompanyType.Text = "国有"; break;
                case "2": this.lbCompanyType.Text = "外资"; break;
                case "3": this.lbCompanyType.Text = "股份制"; break;
                case "4": this.lbCompanyType.Text = "私营"; break;
                case "5": this.lbCompanyType.Text = "集体"; break;
                case "6": this.lbCompanyType.Text = "有限责任"; break;
                case "7": this.lbCompanyType.Text = "独资"; break;
                case "8": this.lbCompanyType.Text = "合资"; break;
                case "9": this.lbCompanyType.Text = "其他"; break;
            }
            this.lbWorkYear.Text = ds.Tables[0].Rows[0]["WorkYear"].ToString();
            this.lbWorkYearNow.Text = ds.Tables[0].Rows[0]["WorkYearNow"].ToString();
            this.lbPlace.Text = ds.Tables[0].Rows[0]["Place"].ToString();
            this.lbPlaceNow.Text = ds.Tables[0].Rows[0]["PlaceNow"].ToString();
            this.lbPayBegin.Text = ds.Tables[0].Rows[0]["PayBegin"].ToString();
            this.lbPayEnd.Text = ds.Tables[0].Rows[0]["PayEnd"].ToString();
            this.lbCompanyNow.Text = ds.Tables[0].Rows[0]["CompanyNow"].ToString();
            switch (ds.Tables[0].Rows[0]["WorkOntime"].ToString())
            {
                case "0": this.lbWorkOntime.Text = "面议"; break;
                case "1": this.lbWorkOntime.Text = "一周内"; break;
                case "2": this.lbWorkOntime.Text = "二周内"; break;
                case "3": this.lbWorkOntime.Text = "一个月内"; break;
                case "4": this.lbWorkOntime.Text = "二个月内"; break;
                case "5": this.lbWorkOntime.Text = "三个月内"; break;
                case "6": this.lbWorkOntime.Text = "随时到岗"; break;
            }
            this.lbOther.Text = ds.Tables[0].Rows[0]["Other"].ToString();
            //求职简历
            this.liTrainInfo.Text = ds.Tables[0].Rows[0]["TrainInfo"].ToString();
            this.liWorkInfo.Text = ds.Tables[0].Rows[0]["WorkInfo"].ToString();
            this.liSpecialSkill.Text = ds.Tables[0].Rows[0]["SpecialSkill"].ToString();
            this.liWorkResult.Text = ds.Tables[0].Rows[0]["WorkResult"].ToString();
            this.liPersonAssess.Text = ds.Tables[0].Rows[0]["PersonAssess"].ToString();
            this.liPrefer.Text = ds.Tables[0].Rows[0]["Prefer"].ToString();
            this.liPlus.Text = ds.Tables[0].Rows[0]["Plus"].ToString();
        }
    }	
}
