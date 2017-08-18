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
using CommonUtility.DBUtility;

public partial class SysAdmin_Advertisement_temp_op : System.Web.UI.Page
{
    public delegate string MyJob(string values);
    private string operation = HttpContext.Current.Request["operation"] != null ? HttpContext.Current.Request["operation"].Trim() : String.Empty;
    private string values = HttpContext.Current.Request["values"] != null ? HttpContext.Current.Request["values"].Trim() : String.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write(Execop(operation, values));
        Response.End();
    }

    private string Execop(string operation, string values)
    {
        MyJob fun;
        switch (operation.ToLower())
        {
            case "getads": fun = new MyJob(GetADS); break;
            default: return "错误的operation";
        }
        return fun(values);
    }


    private string GetADS(string values)
    {
        AdoHelper helper = AdoHelper.CreateHelper();
        string sql = "select * from  T_Advertisement where Approved=1 and state in (3,4,5,6,7,8)";
        DataTable dt = helper.ExecuteDataset(sql).Tables[0];
        if (dt.Rows.Count == 0) return "[]";
        StringBuilder sb = new StringBuilder();
        DataColumnCollection dc = dt.Columns;
        sb.Append("[");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow row = dt.Rows[i];
            if (i != 0) sb.Append(",");
            sb.Append("{");
            for (int j = 0; j < dc.Count; j++)
            {
                if (j != 0) sb.Append(",");
                sb.AppendFormat("\"{0}\":\"{1}\"", dc[j].ColumnName.ToLower(), row[dc[j].ColumnName].ToString());
            }
            sb.Append("}");
        }
        sb.Append("]");
        return sb.ToString();
    }

}
