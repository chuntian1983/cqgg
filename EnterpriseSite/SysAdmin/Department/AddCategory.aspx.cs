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
using Modules.Department;
using CommonUtility;
using System.IO;

public partial class SysAdmin_Department_AddCategory : System.Web.UI.Page
{
    private string _categoryId = HttpContext.Current.Request["CategoryId"];
    private DepartmentCategoryBLL _category = new DepartmentCategoryBLL();
   
    private string _userId = HttpContext.Current.User.Identity.Name;
    protected string _pageTitle = "添加类别";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            BindParentCategory();
            if (this._categoryId != null)
            {
                p.Demand(182);
                int categoryId = Convert.ToInt32(this._categoryId);
                DepartmentCategoryDetail detail = this._category.GetCategoryDetail(categoryId);
                this.txtTitle.Text = detail.Title;
                this.txtSort.Text = detail.Sort.ToString();
                this.txturl.Text = detail.detpimg;
                this.ddlParentCategory.SelectedValue = detail.ParentCategoryId.ToString();
                this._pageTitle = "修改类别";
                this.spanBack.Visible = true;
            }
            else
            {
                p.Demand(180);
            }
        }
    }

    private void BindParentCategory()
    {
        ArrayList items=new ArrayList();
        if (Request.Cookies["__userinfo"]["deptid"] != null)
        {
            string dtid = Request.Cookies["__userinfo"]["deptid"].ToString();
            if (dtid == "0")
            {
                items = this._category.GetSortedDepartmentCategoryItems(3);
            }
            else
            {
                items = this._category.GetSortedDepartmentCategoryItems(dtid);
            }
        }
        else
        {
            items = this._category.GetSortedDepartmentCategoryItems(3);
        }
        IEnumerator e = items.GetEnumerator();
        while (e.MoveNext())
        {
            CategoryEntity item = (CategoryEntity)e.Current;
            this.ddlParentCategory.Items.Add(new ListItem(item.Name, item.Id));
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        DepartmentCategoryDetail detail = new DepartmentCategoryDetail();
        if (this._categoryId != null)
        {
            detail = this._category.Getmodel(int.Parse(this._categoryId));
        }
        detail.Title = this.txtTitle.Text.Trim();
        detail.Sort = Convert.ToInt32(this.txtSort.Text.Trim());
        detail.ParentCategoryId = Convert.ToInt32(this.ddlParentCategory.SelectedValue);
        if (this._categoryId != null)
        {
            
            detail.CategoryId = Convert.ToInt32(this._categoryId);
            string originalPicPath = ConfigurationManager.AppSettings["originalPicPath"].Trim();
            string smallPicPath = ConfigurationManager.AppSettings["smallPicPath"].Trim();
            string smallPicSize = ConfigurationManager.AppSettings["smallPicSize"].Trim();
            int width = Convert.ToInt32(smallPicSize.Split(",".ToCharArray())[0]);
            int height = Convert.ToInt32(smallPicSize.Split(",".ToCharArray())[1]);

            DateTime now = DateTime.Now;
            //HttpPostedFile pic = Request.Files["FileUpload1"];
            //string mime = pic.ContentType.ToLower();
            //if (pic.ContentLength>1)
            //{


                //if (mime != "image/pjpeg" && mime != "image/gif")
                //{
                //    JSUtility.Alert("上传图片格式不正确!");
                //    return;
                //}
                //string fullName = pic.FileName.Substring(pic.FileName.LastIndexOf(@"\") + 1);
                //string extensionName = fullName.Substring(fullName.LastIndexOf("."));

                //detail.detpimg = String.Format("{0}/{1}/{2}{3}", now.Year, now.Month, now.Ticks, extensionName);
                detail.detpimg=this.txturl.Text.Trim();
                detail.AddedUserId = Convert.ToInt32(this._userId);
                // this._category.AddCategory(detail);
                this._category.Update(detail);
                ////保存原始图片
                //string originalPath = Server.MapPath(originalPicPath + detail.detpimg);
                //string originalCategory = originalPath.Substring(0, originalPath.LastIndexOf(@"\"));
                //if (!Directory.Exists(originalCategory))
                //{
                //    Directory.CreateDirectory(originalCategory);
                //}
                //pic.SaveAs(originalPath);

            //}

            //JSUtility.Alert("图片上传成功!");
            this.ddlParentCategory.Items.Clear();
            BindParentCategory();

            this.txtSort.Text = String.Empty;
            this.txtTitle.Text = String.Empty;
            this.ddlParentCategory.SelectedIndex = 0;
            this.ddlType.SelectedIndex = 0;
            this._category.Update(detail);

            JSUtility.AlertAndRedirect("修改成功!", "CategoryTree.Aspx");

        }
        else
        {
            //string originalPicPath = ConfigurationManager.AppSettings["originalPicPath"].Trim();
            //string smallPicPath = ConfigurationManager.AppSettings["smallPicPath"].Trim();
            //string smallPicSize = ConfigurationManager.AppSettings["smallPicSize"].Trim();
            //int width = Convert.ToInt32(smallPicSize.Split(",".ToCharArray())[0]);
            //int height = Convert.ToInt32(smallPicSize.Split(",".ToCharArray())[1]);

            //DateTime now = DateTime.Now;
            //HttpPostedFile pic = Request.Files["FileUpload1"];
            //string mime = pic.ContentType.ToLower();
            ////if (mime != "image/pjpeg" && mime != "image/gif")
            ////{
            ////    JSUtility.Alert("上传图片格式不正确!");
            ////    return;
            ////}
            //string fullName = pic.FileName.Substring(pic.FileName.LastIndexOf(@"\") + 1);
            //string extensionName = fullName.Substring(fullName.LastIndexOf("."));
            
            //detail.detpimg = String.Format("{0}/{1}/{2}{3}", now.Year, now.Month, now.Ticks, extensionName);
            //detail.AddedUserId = Convert.ToInt32(this._userId);
           // this._category.AddCategory(detail);
            detail.AddedDate = System.DateTime.Now.ToString();
            this._category.Add(detail);
            ////保存原始图片
            //string originalPath = Server.MapPath(originalPicPath + detail.detpimg);
            //string originalCategory = originalPath.Substring(0, originalPath.LastIndexOf(@"\"));
            //if (!Directory.Exists(originalCategory))
            //{
            //    Directory.CreateDirectory(originalCategory);
            //}
            //pic.SaveAs(originalPath);


            JSUtility.Alert("保存成功!");
            this.ddlParentCategory.Items.Clear();
            BindParentCategory();

            this.txtSort.Text = String.Empty;
            this.txtTitle.Text = String.Empty;
            this.ddlParentCategory.SelectedIndex = 0;
            this.ddlType.SelectedIndex = 0;
        }
    }
}
