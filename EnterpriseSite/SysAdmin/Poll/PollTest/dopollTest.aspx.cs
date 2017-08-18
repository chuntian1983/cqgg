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

public partial class SysAdmin_Poll_PollTest_dopollTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            Control ucDoPoll = Page.LoadControl("~/Controls/poll/dopoll.ascx");
            ucDoPoll.GetType().GetProperty("PollId").SetValue(ucDoPoll, 2, null);
            this.pnlContainer.Controls.Add(ucDoPoll);
    }
}
