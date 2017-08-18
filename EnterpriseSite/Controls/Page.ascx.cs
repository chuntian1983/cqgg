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

public partial class Web_Controls_Page : System.Web.UI.UserControl
{
    public int recordCount;
    public int pageSize;
    public int page;
    private string frontUrl = "";
    private string newBehindUrl = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            InitPage();
    }

    public void InitPage()
    {
        string rawUrl = Request.RawUrl;
        string behindUrl = "";
        int a = rawUrl.IndexOf("?");
        if (a > -1)
        {
            //URL前半部分，带"?"
            frontUrl = rawUrl.Substring(0, a + 1);
            behindUrl = rawUrl.Substring(a + 1);
            string[] para = behindUrl.Split('&');
            //去掉page=x的字符串，同时组成新URL后半部分
            for (int i = 0; i < para.Length; i++)
            {
                if (para[i].IndexOf("page=") > -1)
                    para[i] = "";
                else
                    newBehindUrl += para[i] + "&";
            }
        }
        else
        {
            frontUrl = rawUrl + "?";
        }

        int count = 0;
        if (this.recordCount > 0 && this.pageSize > 0)
            count = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(this.recordCount) / Convert.ToDouble(this.pageSize)));
        string html = "";

        //设置相关显示
        for (int i = 1; i <= count; i++)
        {
            ddlPageCount.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
        if (page > count)
            page = 1;
        lblPageCount.Text = recordCount.ToString();
        int startRecord = (page - 1) * pageSize + 1;
        int endRecord = startRecord - 1 + pageSize;
        //lblCurRecord.Text = startRecord.ToString() + "-" + endRecord.ToString();
        lblPageCount.Text = count.ToString();
        try
        {
            this.ddlPageCount.SelectedValue = page.ToString();
        }
        catch
        {

        }
        //设置分页链接
        //页数只有一页时，不显示分页
        if (count <= 1)
        {
            this.Visible = false;
        }
        else
        {
            int startPage, endPage;
            if (count < 10)
            {
                startPage = 1;
                endPage = count;
            }
            else
            {
                if (page >= 5)
                {
                    startPage = page - 4;
                    endPage = page + 4;
                }
                else
                {
                    startPage = 1;
                    endPage = 9;
                }
            }
            for (int i = startPage; i <= endPage; i++)
            {
                html += @"<a href=" + frontUrl + newBehindUrl + "page=" + i + ">" + i + @"</a>&nbsp;";
            }
            lblPageNum.Text = html;

            if (page > 1)
            {
                this.hlPrev.Visible = true;
                this.hlPrev.NavigateUrl = frontUrl + newBehindUrl + "page=" + Convert.ToString(page - 1);
                this.hlFirst.Visible = true;
                this.hlFirst.NavigateUrl = frontUrl + newBehindUrl + "page=" + "1";
                this.hlLast.Visible = true;
                this.hlLast.NavigateUrl = frontUrl + newBehindUrl + "page=" + lblPageCount.Text;



            }
            else
            {
                hlPrev.Visible = false;
                hlFirst.Visible = false;
                hlLast.Visible = false;
            }

            if (page < count)
            {
                this.hlNext.Visible = true;
                this.hlNext.NavigateUrl = frontUrl + newBehindUrl + "page=" + Convert.ToString(page + 1);
                //首页不可见
                this.hlFirst.Visible = true;
                this.hlFirst.NavigateUrl = frontUrl + newBehindUrl + "page=" + "1";

                //尾页不可见
                this.hlLast.Visible = true;
                this.hlLast.NavigateUrl = frontUrl + newBehindUrl + "page=" + lblPageCount.Text;

            }
            else
            {
                hlNext.Visible = false;

            }
        }
        this.ViewState["MainUrl"] = frontUrl + newBehindUrl;
        lblRecordCount.Text = this.recordCount.ToString();
    }

    protected void ddlPageCount_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect(this.ViewState["MainUrl"].ToString() + "page=" + ddlPageCount.SelectedValue, true);
    }
}
