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

public partial class SysAdmin_AD_Pagination : System.Web.UI.UserControl
{

    private System.Web.UI.WebControls.DataGrid _DataGrid1;
    private System.Data.DataSet _ds;
    private int _MaxPerPage;
    private DataView _dv;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Bind();
        }
    }

    public DataGrid DataGrid1
    {
        set { _DataGrid1 = value; }
        get { return _DataGrid1; }
    }

    public DataSet ds
    {
        set { _ds = value; }
        get { return _ds; }
    }

    public int MaxPerPage
    {
        set { _MaxPerPage = value; }
        get { return _MaxPerPage; }
    }

    private void PagerButtonClick(object sender, System.EventArgs e)
    {
        //获得LinkButton的参数值
        string arg = ((LinkButton)sender).CommandArgument;
        switch (arg)
        {
            case ("Next"):
                if (_DataGrid1.CurrentPageIndex < (_DataGrid1.PageCount - 1))
                    _DataGrid1.CurrentPageIndex++;
                break;
            case ("Previous"):
                if (_DataGrid1.CurrentPageIndex > 0)
                    _DataGrid1.CurrentPageIndex--;
                break;
            case ("First"):
                _DataGrid1.CurrentPageIndex = 0;
                break;
            case ("Last"):
                _DataGrid1.CurrentPageIndex = (_DataGrid1.PageCount - 1);
                break;
            default:
                //本页值
                _DataGrid1.CurrentPageIndex = Convert.ToInt32(arg);
                break;
        }
        Bind();
    }

    public void Bind()
    {
        string SortDirection = string.Empty;
        string SortDataField = string.Empty;
        _dv = _ds.Tables[0].DefaultView;
        if (_DataGrid1.Attributes["SortDirection"] != null && _DataGrid1.Attributes["SortDataField"] != null)
        {
            SortDirection = _DataGrid1.Attributes["SortDirection"];
            SortDataField = _DataGrid1.Attributes["SortDataField"];
            _dv.Sort = SortDataField + " " + SortDirection;
        }

        _DataGrid1.PageSize = _MaxPerPage;
        _DataGrid1.DataSource = _dv;
        _DataGrid1.DataBind();
        RecCount.Text = _ds.Tables[0].Rows.Count.ToString();
        CurPage.Text = (_DataGrid1.CurrentPageIndex + 1).ToString();
        PagCount.Text = _DataGrid1.PageCount.ToString();
    }
}
