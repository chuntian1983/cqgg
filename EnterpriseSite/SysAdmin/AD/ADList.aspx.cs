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
using Modules.AD;


public partial class SysAdmin_AD_ADList : System.Web.UI.Page
{
    private int ADBoardValue;
    private string ADFlagValue = string.Empty;
    string ADShowValue = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {

        TopButtons1.PanelAdd = false;
        if (!Page.IsPostBack)
        {
            BindADFlag();
            BindADBoard();
        }
        ADBoardValue = int.Parse(ADBoard.SelectedValue);
        ADFlagValue = ADFlag.SelectedValue;
        ADShowValue = ADShow.SelectedValue;

        BindAD();
    }

    private void BindADFlag()
    {
        foreach (ListItem lt in Collection.ADFlag())
        {
            ADFlag.Items.Add(lt);
        }
    }

    private void BindADBoard()
    {
        ADDetail dal = new ADDetail();
        DataSet ds = dal.GetADBoardList();
        ADBoard.DataSource = ds.Tables[0].DefaultView;
        ADBoard.DataBind();
        ListItem lt = new ListItem("所有广告", "0");
        ADBoard.Items.Insert(0, lt);
    }


    private void BindAD()
    {
        ADDetail dal = new ADDetail();
        DataSet ds = dal.GetADList(ADShowValue, ADFlagValue, ADBoardValue);
        ds.Tables[0].Columns.Add("Pic");
        int Width, Height, nWidth, nHeight;
        string strPicUrl, strShowPic;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            Width = int.Parse(ds.Tables[0].Rows[i]["Width"].ToString());
            Height = int.Parse(ds.Tables[0].Rows[i]["Height"].ToString());
            strPicUrl = "../AD/" + ds.Tables[0].Rows[i]["PicUrl"].ToString();
            if (ds.Tables[0].Rows[i]["Flag"].ToString() == "弹出广告")
            {
                ds.Tables[0].Rows[i]["Pic"] = "";
            }
            else
            {
                if (Width > 400)
                    nWidth = 400;
                else
                    nWidth = Width;
                if (Height > 100)
                    nHeight = 100;
                else
                    nHeight = Height;
                if (strPicUrl != "../")
                {
                    if (strPicUrl.Substring(strPicUrl.LastIndexOf(".") + 1, 3).ToString() == "swf")
                    {
                        strShowPic = "<embed src='" + strPicUrl + "' quality='high' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash' width='" + nWidth + "' height='" + Height + "'></embed>";
                    }
                    else
                    {
                        strShowPic = "<a href='" + strPicUrl + "'><img src='" + strPicUrl + "' width='" + nWidth + "' height='" + nHeight + "' border='0'></a>";
                    }
                }
                else
                {
                    strShowPic = "";
                }
                ds.Tables[0].Rows[i]["Pic"] = strShowPic;
            }

            ds.Tables[0].Rows[i]["BoardName"] = "<a href='#' onclick='CreateJS(" + ds.Tables[0].Rows[i]["ID"].ToString() + ")' title='生成此广告位JS文件'><font color=red>" + ds.Tables[0].Rows[i]["BoardName"] + "</font></a>";
            ds.Tables[0].Rows[i]["Flag"] = "<font color=blue>" + ds.Tables[0].Rows[i]["Flag"].ToString() + "</font>";
            if (ds.Tables[0].Rows[i]["IsLock"].ToString() == "显示")
                ds.Tables[0].Rows[i]["IsLock"] = "<a href='#' onclick='Show_Node(1," + ds.Tables[0].Rows[i]["ID"].ToString() + ")'><font color=red>" + ds.Tables[0].Rows[i]["IsLock"].ToString() + "</font></a>";
            else if (ds.Tables[0].Rows[i]["IsLock"].ToString() == "未显示")
                ds.Tables[0].Rows[i]["IsLock"] = "<a href='#' onclick='Show_Node(0," + ds.Tables[0].Rows[i]["ID"].ToString() + ")'><font color=green>" + ds.Tables[0].Rows[i]["IsLock"].ToString() + "</font></a>";
        }

        //调用分页代码并邦定数据
        Pagination1.MaxPerPage = 15;
        Pagination1.DataGrid1 = AD;
        Pagination1.ds = ds;
    }

    protected void AD_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ((HtmlInputCheckBox)e.Item.FindControl("selid")).Value = e.Item.Cells[1].Text;

            ((System.Web.UI.WebControls.Image)e.Item.FindControl("Edit")).Attributes.Add("onclick", "location.reload('ADEdit.aspx?id=" + e.Item.Cells[1].Text + "')");
            ((System.Web.UI.WebControls.Image)e.Item.FindControl("Edit")).Attributes.Add("style", "cursor:hand;");
        }
    }

    protected void AD_SortCommand1(object source, DataGridSortCommandEventArgs e)
    {
        AD.Attributes["SortDataField"] = e.SortExpression;
        if (AD.Attributes["SortDirection"] == "ASC")
        {
            AD.Attributes["SortDirection"] = "DESC";
        }
        else
        {
            AD.Attributes["SortDirection"] = "ASC";
        }

        BindAD();
        Pagination1.Bind();
    }
    protected void AD_ItemCreated(object sender, DataGridItemEventArgs e)
    {
        e.Item.Attributes.Add("onmouseover", "this.style.backgroundColor='white'");
        e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor='#F6F9FF'");

        if (AD.Attributes["SortDirection"] != null && AD.Attributes["SortDataField"] != null)
        {
            string SortDirection = AD.Attributes["SortDirection"];
            string SortDataField = AD.Attributes["SortDataField"];
            string SortOrder = (SortDirection == "ASC" ? "5" : "6");
            if (e.Item.ItemType == ListItemType.Header)
            {
                for (int i = 0; i < AD.Columns.Count; i++)
                {
                    if (SortDataField == AD.Columns[i].SortExpression)
                    {
                        TableCell cell = e.Item.Cells[i];
                        Label lblSorted = new Label();
                        lblSorted.Font.Name = "webdings";
                        lblSorted.Font.Size = FontUnit.Parse("10px");
                        lblSorted.Text = SortOrder;
                        cell.Controls.Add(lblSorted);
                    }
                }
            }
        }
    }
   

   
    protected void ADFlag_SelectedIndexChanged1(object sender, EventArgs e)
    {
        AD.CurrentPageIndex = 0;
        BindAD();
        Pagination1.Bind();
    }
    protected void ADBoard_SelectedIndexChanged1(object sender, EventArgs e)
    {
        AD.CurrentPageIndex = 0;
        BindAD();
        Pagination1.Bind();
    }
    protected void ADShow_SelectedIndexChanged(object sender, EventArgs e)
    {
        AD.CurrentPageIndex = 0;
        BindAD();
        Pagination1.Bind();
    }
}
