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
using Modules.Recorder;

public partial class SysAdmin_Recorder_RecorderAdd : System.Web.UI.Page
{
    RecorderBLL recorder = new RecorderBLL();
    RecorderModel model = new RecorderModel();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           // CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
           
           
            if (Request.QueryString["RecorderId"] != null && Request.QueryString["RecorderId"].ToString() != "")
            { 
               // p.Demand(276);
                int RecorderId = Int32.Parse(Request.QueryString["RecorderId"].ToString());
                PageBill(RecorderId);
                this.lbState.Text = "修改";
            }
            else
            { 
               // p.Demand(274);
                this.lbState.Text = "添加";
            }
        }
    }

    private void PageBill(int recorderId)
    {
        model = recorder.GetModel(recorderId);
        this.txtRecorderId.Text = model.RecorderID;
        this.txtName.Text = model.Name;
        this.txtDegree.Text = model.Degree;
        this.txtGTSchool.Text = model.GradeTimeSchool;
        this.txtSubject.Text = model.Speciality;
        this.txtZZQK.Text = model.ZZQK;
        this.txtZCQK.Text = model.ZCQK;
        this.txtZSID.Text = model.ZCID;
        this.txtCompanyInfo.Text = model.CompanyInfo;
        this.txtTCF.Text = model.TCF;
        this.txtTCID.Text = model.TCID;
        this.txtGZQK.Text = model.GZQK;
        this.txtPay.Text = model.Pay;
        this.txtYDW.Text = model.YDW;
        this.txtXDW.Text = model.XDW;
        this.lbAddDate.Text = model.AddTime.ToShortDateString();
        this.lbID.Text = model.ID.ToString();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.txtRecorderId.Text.Trim() == "")
        {
            Response.Write("<Script>alert('档案号不能为空！');</Script>");
            return;
        }
        else
        {
            model.RecorderID = this.txtRecorderId.Text.Trim();
        }
        if (this.txtName.Text.Trim() == "")
        {
            Response.Write("<Script>alert('姓名不能为空！');</Script>");
            return;
        }
        else
        {
            model.Name = this.txtName.Text.Trim();
        }

        model.Degree = this.txtGTSchool.Text.Trim();
        model.GradeTimeSchool = this.txtGTSchool.Text.Trim();
        model.Speciality = this.txtSubject.Text.Trim();
        model.ZZQK = this.txtZZQK.Text.Trim();
        model.ZCQK = this.txtZCQK.Text.Trim();
        model.ZCID = this.txtZSID.Text.Trim();
        model.CompanyInfo = this.txtCompanyInfo.Text.Trim();
        model.TCF = this.txtTCF.Text.Trim();
        model.TCID = this.txtTCID.Text.Trim();
        model.GZQK = this.txtGZQK.Text.Trim();
        model.Pay = this.txtPay.Text.Trim();
        model.YDW = this.txtYDW.Text.Trim();
        model.XDW = this.txtXDW.Text.Trim();
    
        if (this.lbState.Text == "修改")
        {
            model.ID = Int32.Parse(this.lbID.Text.ToString());
            model.AddTime = DateTime.Parse(this.lbAddDate.Text.ToString());
            recorder.Update(model);
            Response.Write("<Script>alert('修改成功！');location.href('RecorderList.aspx');</Script>");
        }
        else
        {
            model.AddTime = DateTime.Now;
            recorder.Add(model);
            Response.Write("<Script>alert('修改成功！');location.href('RecorderList.aspx');</Script>");
        }
    }
}
