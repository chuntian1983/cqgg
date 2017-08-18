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
using Modules.Workers;
using Modules.Department;
using Modules.Account;

public partial class SysAdmin_Worker_WorkerAdd : System.Web.UI.Page
{
    private string AllowFileType = "jpg|gif|swf";
    WorkerDAL dal = new WorkerDAL();
    WorkerModel model = new WorkerModel();
    ExpertOutDAL dal1 = new ExpertOutDAL();
    ExpertOutModel model1 = new ExpertOutModel();
    DepartDAL dal2 = new DepartDAL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            p.Demand(173);
            PageBill1();
            if (Request.QueryString["WorkerId"] != null && Request.QueryString["WorkerId"].ToString() != "")
            {
                int workerid = Int32.Parse(Request.QueryString["WorkerId"].ToString());
                PageBill(workerid);
               
            }
        }
    }


    protected void PageBill(int WorkeID)
    {
       
        model = dal.GetModel(WorkeID);
        this.txtName.Text = model.Name.ToString();
     
        bool result = dal1.CheckExpertOut(this.txtName.Text);
        if (result == true)
        {
            this.RadioButtonList2.SelectedValue = "1";
            model1 = dal1.GetModel(this.txtName.Text);
            this.txtCharacter.Text = model1.Characteristic;
            this.txtOutTime.Text = model1.OutTime;
            this.txtPrice.Text = model1.Price;
            this.txtSort.Text = model1.Sort.ToString();
            this.Label1.Text = model1.ID.ToString();
            this.bb.Visible = true;
        }
        else
        {
            this.bb.Visible = false;
        }
        this.txtBusiness.Text = model.Business.ToString();
        this.txtDegree.Text = model.Degree.ToString();
        this.txtScience.Text = model.Science.ToString();
        this.txtArea.Text = model.Area.ToString();
        this.txtWorkTel.Text = model.WorkTel.ToString();
        this.txtEmail.Text = model.Email.ToString();
        this.txtResume.Value = model.Resume.ToString();
        this.txtLookTime.Text = model.LookTime.ToString();
        this.txtMZTel.Text = model.MZTel.ToString();
        this.txtOfficeTel.Text = model.OfficeTel.ToString();
        this.txtSortID.Text = model.Sort.ToString();
        this.txtpicurlhide.Text = model.ImgLink.ToString();
        this.lbAddDate.Text = model.AddDate.ToShortDateString();
        this.txtPrize.Text = model.Prize.ToString();
        this.RadioButtonList1.SelectedValue = model.PersonType.ToString();
        string PersonPic = System.Configuration.ConfigurationSettings.AppSettings["PersonPicPath"].ToString();
        this.uploadimage.Src = PersonPic + model.ImgLink.ToString();
        this.DropDownList1.SelectedValue = model.Depart.ToString();
    }


    protected void PageBill1()
    {
        DataSet ds2 = dal2.GetSonCategoryInfo(1);
        if (ds2.Tables[0].Rows.Count > 0)
        {
            this.DropDownList1.DataSource = ds2;
            this.DropDownList1.DataTextField = "Title";
            this.DropDownList1.DataValueField = "CategoryId";
            this.DropDownList1.DataBind();
        }

    }

    public string SaveImg()
    {
        string SaveFileName = string.Empty;
        string SaveFileType = string.Empty;
        string SaveImgUrl = string.Empty;
        string ErrMsg = "";

        if (FileUp.PostedFile.ContentLength == 0)
        {
            ErrMsg = "请选择要上传的文件！";
            Response.Write("<script language=javascript>alert('" + ErrMsg + "');history.go(-1);</script>");
        }
        else if (FileUp.PostedFile.ContentLength / 1024 > 1024)
        {
            ErrMsg = "文件大小不得超过1M！";
            Response.Write("<script language=javascript>alert('" + ErrMsg + "');history.go(-1);</script>");
        }
        else
        {
            //获取上传文件属性
            SaveFileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() +
                        DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            SaveFileType = FileUp.PostedFile.FileName.Substring(FileUp.PostedFile.FileName.Length - 3, 3);//文件类型

            string PersonPic = System.Configuration.ConfigurationSettings.AppSettings["PersonPicPath"].ToString();
            SaveImgUrl = Server.MapPath(PersonPic + SaveFileName + "." + SaveFileType);//保存物理路径

            if (AllowFileType.IndexOf(SaveFileType.ToLower()) == -1)//判断上传文件的类型(后缀)
            {
                ErrMsg = "请上传正确的文件类型！";
                Response.Write("<script language=javascript>alert('" + ErrMsg + "');history.go(-1);</script>");
            }
            else
            {
                FileUp.PostedFile.SaveAs(SaveImgUrl);
            }
        }
        if (SaveFileName == "" && SaveFileType == "")
        {
            return "";
        }
        else
        {
            return SaveFileName + "." + SaveFileType;
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (this.txtName.Text == "")
        {
            this.lbwarning.Text = "请输入姓名";
            this.lbwarning.Visible = true;
            return;
        }
        else
        {
            model.Name = this.txtName.Text;
        }
        //图片上传
        if (Request.QueryString["WorkerId"] != null)
        {
            if (FileUp.PostedFile.ContentLength == 0)
            {
                //将原来的地址重新赋给model
                model.ImgLink = this.txtpicurlhide.Text;
            }
            else
            {
                model.ImgLink = SaveImg();
            }
        }
        else
        {
            if (FileUp.PostedFile.ContentLength == 0)
            {
                //不上传文件
                model.ImgLink = "";
            }
            else
            {
                model.ImgLink = SaveImg();
            }
        }
        model.Business = this.txtBusiness.Text;
        model.Degree = this.txtDegree.Text;
        model.Science = this.txtScience.Text;
        model.Area = this.txtArea.Text;
        model.WorkTel = this.txtWorkTel.Text;
        model.Email = this.txtEmail.Text;
        model.Resume = this.txtResume.Value;
        model.LookTime = this.txtLookTime.Text;
        model.MZTel = this.txtMZTel.Text;
        model.OfficeTel = this.txtOfficeTel.Text;
        model.Sort = Int32.Parse(this.txtSortID.Text.ToString());
        model.Prize = this.txtPrize.Text;
        model.Depart = Int32.Parse(this.DropDownList1.SelectedValue.ToString());
        if (this.RadioButtonList1.SelectedValue == "")
        {
            this.lbwarning1.Text = "请选择专家类型！";
            this.lbwarning1.Visible = true;
            return;
        }
        else
        {
            model.PersonType = Int32.Parse(this.RadioButtonList1.SelectedValue.ToString());
        }
      
        if (Request.QueryString["WorkerId"] != null)
        {
            model.AddDate = DateTime.Parse(this.lbAddDate.Text.ToString());
            int workId = Int32.Parse(Request.QueryString["WorkerId"].ToString());
            model.ID = workId;
            dal.Update(model);
            if (this.RadioButtonList2.SelectedValue == "1" )
            {
                if (this.Label1.Text != "")
                {
                    if (dal1.Exists1(Int32.Parse(this.Label1.Text.ToString())) == true)//判断是否存在专家出诊信息，如果存在就进行更新，否则进行插入
                    {
                        model1.Name = this.txtName.Text;
                        model1.Characteristic = this.txtCharacter.Text;
                        model1.OutTime = this.txtOutTime.Text;
                        model1.AddedUserId = 1;
                        model1.Price = this.txtPrice.Text;
                        model1.AddDate = DateTime.Now;
                        model1.Type = 0;
                        if (this.txtSort.Text != "")
                        {
                            model1.Sort = Int32.Parse(this.txtSort.Text.ToString());
                        }
                        else
                        {
                            model1.Sort = 0;
                        }
                        model1.ID = Int32.Parse(this.Label1.Text.ToString());
                        dal1.Update(model1);
                    }
                }
                else
                {
                    model1.Name = this.txtName.Text;
                    model1.Characteristic = this.txtCharacter.Text;
                    model1.OutTime = this.txtOutTime.Text;
                    model1.AddedUserId = 1;
                    model1.Price = this.txtPrice.Text;
                    model1.AddDate = DateTime.Now;
                    dal1.Add(model1);
                }
            }
            else
            {
                bool result = dal1.CheckExpertOut(this.txtName.Text);
                if (result == true)
                {
                    dal1.Delete(this.txtName.Text);
                }
            }
            Response.Write("<Script>alert('你已成功修改！');location.href('WorkerList.aspx');</Script>");
        }
        else
        {

            model.AddDate = DateTime.Now;
         
            dal.Add(model);
            if (this.RadioButtonList2.SelectedValue == "1")
            {
                model1.Name = this.txtName.Text;
                model1.Characteristic = this.txtCharacter.Text;
                model1.OutTime = this.txtOutTime.Text;
                model1.AddedUserId = 1;
                model1.Price = this.txtPrice.Text;
                model1.AddDate = DateTime.Now;
                if (this.txtSort.Text != "")
                {
                    model1.Sort = Int32.Parse(this.txtSort.Text.ToString());
                }
                else
                {
                    model1.Sort = 0;
                }
                dal1.Add(model1);
            }
            Response.Write("<Script>alert('你已成功添加！');location.href('WorkerList.aspx');</Script>");
        }
    }

   
    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.RadioButtonList2.SelectedValue == "1")
        {
            this.bb.Visible = true;
        }
        else
        {
            this.bb.Visible = false;
        }
    }
}
