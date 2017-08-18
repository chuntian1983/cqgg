using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using Maticsoft.DBUtility;

public partial class jubao_ProblemsWarning : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HPid.Value = Request.QueryString["pid"] == null ? "0" : Request.QueryString["pid"];
            BindData();
            GetAllClass();
        }
    }

    private void GetAllClass()
    {
        string sql = string.Format("select * from [T_Jb_type] ", "");
        DataTable dt = DbHelperSQL.Query(sql).Tables[0];
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count;i++ )
            {
                BindQuestionList(dt.Rows[i]["id"].ToString(), dt.Rows[i]["lxname"].ToString());
            }
        }
    }
    private void AddData(string[] array)
    {
        int i = 0;
        foreach (HtmlTableRow tr in QuestionList.Rows)
        {
            AddCell(tr, array[i], "");
            i++;
        }
    }
    private void BindQuestionList(string classType,string className)
    {
        string limit = string.Empty;
        if (FromTime.Text.Trim().Length > 0 && EndTime.Text.Trim().Length > 0)
        {
            limit = string.Format(" and greattime between '{0}' and '{1}'", FromTime.Text.Trim(), EndTime.Text.Trim());
        }
        else
        {
            if (FromTime.Text.Trim().Length > 0 && EndTime.Text.Trim().Length == 0)
            {
                limit = string.Format(" and greattime >= '{0}'", FromTime.Text.Trim());
            }
            if (FromTime.Text.Trim().Length == 0 && EndTime.Text.Trim().Length > 0)
            {
                limit = string.Format(" and greattime <='{0}' ", EndTime.Text.Trim());
            }
        }
        bool argLoad = false;
        bool IsLoad = true;
        string[] array=new string[100];
        string sql = string.Format("select * from T_DepartCategory where ParentCategoryId='{0}' order by CategoryId", HPid.Value);
        DataTable dt = DbHelperSQL.Query(sql).Tables[0];
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sql = string.Format("select * from [T_Jb_info] where szdq='{0}' and [wtlx]='{1}' {2}", dt.Rows[i]["CategoryId"].ToString(), classType, limit);
                DataTable dList = DbHelperSQL.Query(sql).Tables[0];
                if (dList != null && dList.Rows.Count > 0)
                {
                    argLoad = true;
                    DataRow[] IG = dList.Select("zhuangtai<>'2'");
                    switch (IG.Length)
                    {
                        case 0:
                            array[i + 1] = "<img src='images/lv.png' />";
                            break;
                        case 1:
                        case 2:
                        case 3:
                            array[i + 1] = "<img src='images/huang.png' />";
                            break;
                        default:
                            array[i + 1] = "<img src='images/huang.png' />";
                            break;
                    }
                    if (IsLoad)
                    {
                        array[0] = className;
                    }
                    else
                    {
                        IsLoad = false;
                    }
                }
                else
                {
                    //if (argLoad)
                    //{
                        array[i + 1] = "<img src='images/lv.png' />";
                    //}
                }
            }
        }
        if (argLoad)  AddData(array);
    }

    private void AddBlankRow()
    {
        HtmlTableRow trQ = new HtmlTableRow();
        AddCell(trQ, "单位", "");
        QuestionList.Rows.Add(trQ);
    }

    private void BindData()
    {
        AddBlankRow();
        string sql = string.Format("select * from T_DepartCategory where ParentCategoryId='{0}' order by sort", HPid.Value);
        DataTable dt = DbHelperSQL.Query(sql).Tables[0];
        if (dt != null && dt.Rows.Count > 0)
        {  
            HtmlTableRow tr = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HtmlTableRow trQ = new HtmlTableRow();
                AddCell(trQ, dt.Rows[i]["Title"].ToString(), "");
                QuestionList.Rows.Add(trQ);
                if (i % 10 == 0)
                {
                    if (i != 0) UnitList.Rows.Add(tr);
                    tr = new HtmlTableRow();
                }
                AddCell(tr, dt.Rows[i]["Title"].ToString(),dt.Rows[i]["CategoryId"].ToString());
            }
            if (dt.Rows.Count % 10 != 0)
                UnitList.Rows.Add(tr);
        }
    }

    private void AddCell(HtmlTableRow tr, string text,string href)
    {
        HtmlTableCell tc = new HtmlTableCell();
        tc.Width = "6%";
        tc.InnerHtml = text;
        if (href.Length > 0) tc.Attributes["onclick"] = "javascript:window.location.href='ProblemsWarning.aspx?pid=" + href + "'";
        tc.Attributes["class"] = "ListCellRow2";
        tr.Cells.Add(tc);
    }
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        BindData();
        GetAllClass();
    }
}