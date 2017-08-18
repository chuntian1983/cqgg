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
using Modules.Picture;
using CommonUtility;
using System.Text;

public partial class SysAdmin_Picture_PictureList1 : System.Web.UI.Page
{
    private PictureBLL _picture = new PictureBLL();
    private PictureCategoryBLL _category = new PictureCategoryBLL();
    protected string originalPicPath = ConfigurationManager.AppSettings["originalPicPath"];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCategory();
            BindPic();
        }

    }
    private void BindCategory()
    {
        this.ddlCategory.DataSource = this._category.GetAllPicCategories();
        this.ddlCategory.DataTextField = "Title";
        this.ddlCategory.DataValueField = "CategoryId";
        this.ddlCategory.DataBind();
        this.ddlCategory.Items.Insert(0, new ListItem("--请选择类别--", "0"));
    }

    private void BindPic()
    {
        int count;
        string filter = this.GetFilter();
        string sort = "PictureId desc";
        int index = this.pageBar.PageIndex;
        int size = this.pageBar.PageSize;
        this.dlPic.DataSource = this._picture.GetPicList("*", filter, sort, index, size, out count);
        this.dlPic.DataBind();
        this.pageBar.RecordCount = count;
    }
    private string GetFilter()
    {
        if (ViewState["Filter"] == null)
        {
            ViewState["Filter"] = "1=1";
        }
        return this.ViewState["Filter"].ToString();
    }
    private void SetFilter()
    {
        StringBuilder filter = new StringBuilder();
        filter.Append("1=1");
        string starDate = this.txtStart.Text.Trim();
        string endDate = this.txtEnd.Text.Trim();
        string type = this.ddlCategory.SelectedValue;
        if (starDate != String.Empty) filter.AppendFormat(" and UploadDate>='{0}'", starDate);
        if (endDate != String.Empty) filter.AppendFormat(" and UploadDate<='{0}'", endDate);
        if (type != "0") filter.AppendFormat(" and CategoryId={0}", type);
        ViewState["Filter"] = filter.ToString();
    }

    protected void pageBar_PageIndexChanged(object sender, PageIndexChangedEventArguments e)
    {
        BindPic();
    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        SetFilter();
        this.pageBar.PageIndex = 0;
        BindPic();
    }
}
