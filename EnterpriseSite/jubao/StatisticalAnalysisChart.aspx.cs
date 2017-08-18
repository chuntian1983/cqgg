using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.DBUtility;
using System.Web.UI.HtmlControls;
using InfoSoftGlobal;
using System.Text;

public partial class jubao_StatisticalAnalysisChart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HPid.Value = Request.QueryString["pid"] == null ? "0" : Request.QueryString["pid"];
            BindData();
            BindChart();
        }
    }

    private string  BindProblem(string unitid)
    {
        string sql = string.Format("select * from T_Jb_info where szdq='{0}'", unitid);
        DataTable dt = DbHelperSQL.Query(sql).Tables[0];
        if (dt != null && dt.Rows.Count > 0)
        {
            DataRow[] dr = dt.Select("zhuangtai='2'");
            return string.Format(" <set value='{0}' />", dt.Rows.Count.ToString()) + "|" + string.Format(" <set value='{0}' />", dr.Length);
        }
        else
        {
            return string.Format(" <set value='{0}' />", 0) + "|" + string.Format(" <set value='{0}' />", 0);
        }
    }
    private string BindProblem(string unitid, string limit)
    {
        string sql = string.Format("select * from T_Jb_info where szdq='{0}' {1}", unitid, limit);
        DataTable dt = DbHelperSQL.Query(sql).Tables[0];
        if (dt != null && dt.Rows.Count > 0)
        {
            DataRow[] dr = dt.Select("zhuangtai='2'");
            return string.Format(" <set value='{0}' />", dt.Rows.Count.ToString()) + "|" + string.Format(" <set value='{0}' />", dr.Length);
        }
        else
        {
            return string.Format(" <set value='{0}' />", 0) + "|" + string.Format(" <set value='{0}' />", 0);
        }
    }
    private void BindData()
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
        StringBuilder strXML = new StringBuilder();
        StringBuilder strXML1 = new StringBuilder();
        StringBuilder strXML2 = new StringBuilder();
        string sql = string.Format("select * from T_DepartCategory where ParentCategoryId='{0}' order by sort", HPid.Value);
        DataTable dt = DbHelperSQL.Query(sql).Tables[0];
        if (dt != null && dt.Rows.Count > 0)
        {
            HtmlTableRow tr = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i % 10 == 0)
                {
                    if (i != 0) UnitList.Rows.Add(tr);
                    tr = new HtmlTableRow();
                    
                }
                AddCell(tr, dt.Rows[i]["Title"].ToString(), dt.Rows[i]["CategoryId"].ToString());
                strXML.Append(string.Format(" <category label='{0}' /> ",dt.Rows[i]["Title"].ToString()));
                string tempXML = BindProblem(dt.Rows[i]["CategoryId"].ToString(), limit);
                strXML1.Append(BindProblem(dt.Rows[i]["CategoryId"].ToString()).Split('|')[0]);
                strXML2.Append(BindProblem(dt.Rows[i]["CategoryId"].ToString()).Split('|')[1]);
            }
            if (dt.Rows.Count % 10 != 0) UnitList.Rows.Add(tr);
        }
        Unit.Value = strXML.ToString();
        Value1.Value = strXML1.ToString();
        Value2.Value = strXML2.ToString();
    }

    private void AddCell(HtmlTableRow tr, string text, string href)
    {
        HtmlTableCell tc = new HtmlTableCell();
        tc.Width = "10%";
        tc.InnerHtml = text;
        if (href.Length > 0) tc.Attributes["onclick"] = "javascript:window.location.href='StatisticalAnalysisChart.aspx?pid=" + href + "'";
        tc.Attributes["class"] = "ListCellRow2";
        tr.Cells.Add(tc);
    }

    private void BindChart()
    {
        StringBuilder strXML = new StringBuilder();
        strXML.Append("<chart palette='2' caption='被举报情况图表分析'  showYAxisValues='0' showValues='1' numVDivLines='10' drawAnchors='0' ");
        strXML.Append(" divLineAlpha='30' alternateHGridAlpha='20'  setAdaptiveYMin='1' outCnvBaseFontSize='14' >");
        strXML.Append("<categories>");
        strXML.Append(Unit.Value);
        strXML.Append("</categories>");
        strXML.Append("<dataset seriesName='举报数' color='FF0000'>");
        strXML.Append(Value1.Value);

        strXML.Append("</dataset>");
        strXML.Append("<dataset seriesName='办结数' color='00FF00'>");
        strXML.Append(Value2.Value);

        strXML.Append("</dataset>");
        strXML.Append("<styles>");
        strXML.Append("	<definition>");
        strXML.Append("	<style name='XScaleAnim' type='ANIMATION' duration='1' start='0' param='_xScale' />");
        strXML.Append("	<style name='YScaleAnim' type='ANIMATION' duration='1' start='0' param='_yscale' />");
        strXML.Append("	<style name='XAnim' type='ANIMATION' duration='1' start='0' param='_yscale' />");
        strXML.Append("	<style name='AlphaAnim' type='ANIMATION' duration='1' start='0' param='_alpha' />");
        strXML.Append("</definition>");

        strXML.Append("<application>");
        strXML.Append("<apply toObject='CANVAS' styles='XScaleAnim, YScaleAnim,AlphaAnim' />");
        strXML.Append("<apply toObject='DIVLINES' styles='XScaleAnim,AlphaAnim' />");
        strXML.Append("<apply toObject='VDIVLINES' styles='YScaleAnim,AlphaAnim' />");
        strXML.Append("<apply toObject='HGRID' styles='YScaleAnim,AlphaAnim' />");
        strXML.Append("</application>");

        strXML.Append("</styles>");
        strXML.Append("  </chart>");
        
        Literal1.Text = FusionCharts.RenderChart("./fushioncharts/MSColumn3D.swf", "", strXML.ToString(), "FactoryDetailed", "860", "500", false, true, false);
    }
    protected void chartLink_Click(object sender, EventArgs e)
    {
        Response.Redirect("StatisticalAnalysis.aspx");
    }
}