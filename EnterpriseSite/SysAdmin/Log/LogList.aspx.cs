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
using System.Text;
using Modules.Account;
using Modules.Log;


public partial class SysAdmin_Account_Log_LogList : System.Web.UI.Page
{
    private OperateLog _log = new OperateLog();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            p.Demand(135);
            BindLog();
        }
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
        string nickname = this.txtNickname.Text.Trim();
        string ipAddress = this.txtIP.Text.Trim();
        if (starDate != String.Empty) filter.AppendFormat(" and OperationDate>='{0}'", starDate);
        if (endDate != String.Empty) filter.AppendFormat(" and OperationDate<='{0}'", endDate);
        if (nickname != String.Empty) filter.AppendFormat(" and Nickname like '%{0}%'", nickname);
        if (ipAddress != String.Empty) filter.AppendFormat(" and IP='{0}'", ipAddress);
        ViewState["Filter"] = filter.ToString();
    }
    private void BindLog()
    {
        string filter = this.GetFilter();
        DataTable dts = this._log.Select("","").Tables[0];
        AspNetPager1.RecordCount = dts.Rows.Count;
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = dts.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.PageSize = AspNetPager1.PageSize;
        gvLogList.DataSource = pds;
        gvLogList.DataBind();
    }

    protected void AspNetPager1_PageChanged(object src, EventArgs e)
    {
        BindLog();
    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        this.SetFilter();
        BindLog();
    }
}
