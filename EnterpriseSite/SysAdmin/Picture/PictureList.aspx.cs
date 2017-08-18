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
using Modules.Picture;
using Modules.Log;
using CommonUtility;
using System.Text;

public partial class SysAdmin_Picture_PictureList : System.Web.UI.Page
{
    private PictureBLL _picture = new PictureBLL();
    private PictureCategoryBLL _category = new PictureCategoryBLL();
    protected string originalPicPath = ConfigurationManager.AppSettings["originalPicPath"];
    private string _userId = HttpContext.Current.User.Identity.Name;
    public bool AllowDel
    {
        get { return Convert.ToBoolean(ViewState["AllowDel"]); }
        set { ViewState["AllowDel"] = value; }
    }
    public bool AllowEdit
    {
        get { return Convert.ToBoolean(ViewState["AllowEdit"]); }
        set { ViewState["AllowEdit"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            p.Demand(67);
            this.AllowDel = p.HasPermission(69);
            this.AllowEdit = p.HasPermission(68);
            this.trQueryButtom.Visible = this.trQueryTop.Visible = p.HasPermission(118);
            BindCategory();
            bindData();
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

    //private void BindPic()
    //{
    //    int count;
    //    string filter=this.GetFilter();
    //    string sort="PictureId desc";
    //    int index=this.pageBar.PageIndex;
    //    int size=this.pageBar.PageSize;
    //    this.dlPic.DataSource = this._picture.GetPicList("*", filter, sort, index, size, out count);
    //    this.dlPic.DataBind();
    //    this.pageBar.RecordCount = count;
    //}
    void bindData()
    {
        string filter = this.GetFilter();
        Modules.Picture.PictureBLL pbll = new PictureBLL();

        if (Request.Cookies["__UserInfo"]["deptid"] != null)
        {


            string deptid = Request.Cookies["__UserInfo"]["deptid"].ToString();
            DataTable dts = pbll.GetList(int.Parse( deptid), filter).Tables[0];
            AspNetPager1.RecordCount = dts.Rows.Count;
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dts.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;
            dlPic.DataSource = pds;
            dlPic.DataBind();
        }
        //string filter = this.GetFilter();
        //Modules.Picture.PictureBLL pbll = new PictureBLL();



        //DataTable dts = pbll.GetList(_userId, filter).Tables[0];
        //AspNetPager1.RecordCount = dts.Rows.Count;
        //PagedDataSource pds = new PagedDataSource();
        //pds.DataSource = dts.DefaultView;
        //pds.AllowPaging = true;
        //pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        //pds.PageSize = AspNetPager1.PageSize;
        //dlPic.DataSource = pds;
        //dlPic.DataBind();
    }
    protected void AspNetPager1_PageChanged(object src, EventArgs e)
    {
        bindData();
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
        StringBuilder filter=new StringBuilder();
        filter.Append("1=1");
        string starDate = this.txtStart.Text.Trim();
        string endDate = this.txtEnd.Text.Trim();
        string type = this.ddlCategory.SelectedValue;
        if (starDate != String.Empty) filter.AppendFormat(" and UploadDate>='{0}'", starDate);
        if (endDate != String.Empty) filter.AppendFormat(" and UploadDate<='{0}'", endDate);
        if (type != "0") filter.AppendFormat(" and CategoryId={0}", type);
        ViewState["Filter"] = filter.ToString();
    }
    protected void btnFind_Click(object sender, EventArgs e)
    {
        SetFilter();
        bindData();
    }
   

    protected void lbtnDel_Command(object sender, CommandEventArgs e)
    {
        int pictureId = Convert.ToInt32(e.CommandArgument);
        this._picture.DeleteUploadPic(pictureId);
       // OperateLog.AddLog(String.Format("删除图片 图片标识:{0}", pictureId));
        bindData();
    }
}
