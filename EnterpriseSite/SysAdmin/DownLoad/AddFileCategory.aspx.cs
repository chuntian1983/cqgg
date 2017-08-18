﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CommonUtility;
using Modules.File;
using Modules.Account;

public partial class SysAdmin_DownLoad_AddFileCategory : System.Web.UI.Page
{
    private FileCategoryBLL _category = new FileCategoryBLL();
    private string _categoryId = HttpContext.Current.Request["CategoryId"];
    private string _userId = HttpContext.Current.User.Identity.Name;
    protected string _pageTitle = "添加文件上传类别";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            if (this._categoryId != null)
            {
                p.Demand(133);
                int categoryId = Convert.ToInt32(this._categoryId);
                FileCategoryDetail detail = this._category.GetCategoryDetail(categoryId);
                this.txtType.Text = detail.Title;
                this._pageTitle = "修改文件上传类别";
            }
            else
            {
                p.Demand(35);
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        FileCategoryDetail detail = new FileCategoryDetail();
        detail.Title = this.txtType.Text.Trim();
        if (this._categoryId != null)
        {
            int categoryId = Convert.ToInt32(this._categoryId);
            detail.FileCategoryId = categoryId;
            this._category.UpdateCategory(detail);
            JSUtility.AlertAndRedirect("修改文件上传类别成功!", "FileCategoryList.aspx");
        }
        else
        {
            detail.AddedUserId = Convert.ToInt32(this._userId);
            this._category.AddCategory(detail);
            this.txtType.Text = String.Empty;
            JSUtility.Alert("添加文件上传类别成功!");
        }
    }
}
