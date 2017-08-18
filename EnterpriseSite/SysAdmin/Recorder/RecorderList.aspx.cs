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
using CommonUtility.DBUtility;
using Modules.Recorder;
using Modules.Account;

public partial class SysAdmin_Recorder_RecorderList : System.Web.UI.Page
{
    private RecorderBLL _recorder = new RecorderBLL();
    private int PageIndex = 0;

    public bool AllowDel
    {
        get { return Convert.ToBoolean(ViewState["AllowDel"]); }
        set { ViewState["AllowDel"] = value; }
    }
    public bool AllowModify
    {
        get { return Convert.ToBoolean(ViewState["AllowModify"]); }
        set { ViewState["AllowModify"] = value; }
    }
   

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            p.Demand(273);
            this.AllowDel = p.HasPermission(277);
            this.AllowModify = p.HasPermission(276);
            this.gvRecorderList.Columns[3].Visible = this.AllowDel || this.AllowModify;
            Bind();
        }
    }

    private void Bind()
    {
        string filter = "1=1";
        string sort = "ID asc";
        int pageIndex = this.pageBar.PageIndex;
        int pageSize = this.pageBar.PageSize;
        int count;
        DataSet ds = this._recorder.GetArticleList("*", filter, sort, pageIndex, pageSize, out count);
        this.gvRecorderList.DataSource = ds;
        this.gvRecorderList.DataBind();
        this.pageBar.RecordCount = count;
    }



    protected void ibtnDel_Command(object sender, CommandEventArgs e)
    {
        int postId = Convert.ToInt32(e.CommandArgument);
        this._recorder.Delete(postId);
        Bind();
    }
    protected void pageBar_PageIndexChanged(object sender, PageIndexChangedEventArguments e)
    {
        Bind();
    }

    //根据姓名查询
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.txtName.Text.Trim() != "")
        {
            string name = this.txtName.Text.Trim();
            DataSet ds = _recorder.GetList("Name='" + name + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gvRecorderList.DataSource = ds;
                this.gvRecorderList.DataBind();
            }
        }
    }
}

