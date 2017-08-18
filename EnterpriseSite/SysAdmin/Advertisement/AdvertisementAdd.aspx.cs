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
using Modules.Advertisement;
using Modules.Account;
using System.Text.RegularExpressions;

public partial class SysAdmin_Advertisement_AdvertisementAdd : System.Web.UI.Page
{
    AdvertisementBLL bll = new AdvertisementBLL();
    AdvertisementModel model = new AdvertisementModel();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            if (Request.QueryString["ADId"] != null && Request.QueryString["ADId"].ToString() != "")
            {
                p.Demand(318);//修改
                this.lbType.Text = "修改";
                int ADId = Int32.Parse(Request.QueryString["ADId"].ToString().Trim());
                this.lbID.Text = ADId.ToString();
                PageBill(ADId);
            }
            else
            {
                p.Demand(81);//添加
                this.lbType.Text = "添加";
            }
        }
    }

    private void PageBill(int ADId)
    {
        model=bll.GetModel(ADId);
        this.txtName.Text = model.ADName;
        this.txtImageLink.Text = model.ADPic;
        this.txtLink.Text = model.Link;
        this.txtSort.Text = model.Sort.ToString();
        if (model.Type == 1)
        {
            this.CheckBox1.Checked = true;
        }
        else
        {
            this.CheckBox1.Checked = false;
        }
        this.DrADState.SelectedValue = model.State.ToString();
        this.lbFillTime.Text = model.FillTime.ToShortDateString();
        this.fckRemark.Value = model.Plus;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (this.txtName.Text == "" )
        {
            Response.Write("<Script>alert('名称不允许为空！');</Script>");
            return;
        }
        if (this.txtSort.Text.Trim() == "")
        {
            Response.Write("<Script>alert('排序号不能为空！');</Script>");
            return;
        }
        else
        {
            string str = this.txtSort.Text.Trim();
            if (CheckInsert(str) == false)
            {
                Response.Write("<Script>alert('排序号输入有误！');</Script>");
                return;
            }
        }
       
        if (this.DrADState.SelectedValue == "0")
        {
            Response.Write("<Script>alert('请选择广告类型！');</Script>");
            return;
        }
            model.ADName = this.txtName.Text.Trim();//广告名称
            model.ADPic = this.txtImageLink.Text.Trim();//广告图片
            model.Link = this.txtLink.Text.Trim();//链接地址
            model.Plus = this.fckRemark.Value.ToString();//备注
            model.FillTime = DateTime.Now;//添加时间
            model.Approved = 1;//审核状态默认为1:已审核
            if (this.CheckBox1.Checked)
            {
                model.Type = 1;//推荐状态
            }
            else
            {
                model.Type = 0;
            }
            model.State = Int32.Parse(this.DrADState.SelectedValue.ToString());//广告类型
            model.Sort = Int32.Parse(this.txtSort.Text.Trim());//排序号
            if (this.lbID.Text.Trim() != "")
            {
                model.ADId = Int32.Parse(this.lbID.Text.Trim());
                model.FillTime = DateTime.Parse(this.lbFillTime.Text.Trim());//原先添加时间
                bll.Update(model);
                Response.Write("<Script>alert('更新成功！');location.href('AdvertisementList.aspx');</Script>");
            }
            else
            {
                model.FillTime = DateTime.Now;//添加时间
                bll.Add(model);
                Response.Write("<Script>alert('添加成功,请继续添加！');location.href('AdvertisementAdd.aspx');</Script>");
            }
       
    }

    //判断输入的是否为数字
    private bool CheckInsert(string str)
    {
        return Regex.IsMatch(str, @"^\d", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    }
}
