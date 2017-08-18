using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web;


namespace Modules.Page
{
   public class Page
    {
       public Page()
       { }
       /// <summary>
       ///	分页过程处理
       /// </summary>
       /// <param name="tb">数据源Table</param>
       /// <param name="pageSize">页大小</param>
       /// <param name="curPage">当前页码</param>
       /// <returns></returns>
       public static PagedDataSource GetPagerRecord(DataTable tb, int pageSize)
       {
           PagedDataSource pd = new PagedDataSource();
           pd.DataSource = tb.DefaultView;
           pd.AllowPaging = true;
           pd.PageSize = pageSize;

           int curPage = 1;
           if (HttpContext.Current.Request.Params["page"] != null)
               curPage = Convert.ToInt32(HttpContext.Current.Request.Params["page"]);

           if (curPage > pd.PageCount)
               curPage = 1;
           if (curPage < 1)
               curPage = 1;

           pd.CurrentPageIndex = curPage - 1;

           return pd;
       }

    }
}
