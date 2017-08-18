using System;
using System.Collections.Generic;
using System.Text;
using CommonUtility.DBUtility;
using System.Data;

namespace CommonUtility
{
    public class PaginationUtility
    {
        private PaginationUtility()
        { }
        public static DataSet GetPaginationList(string fields, string viewtablesql, string filter, string sort, int currentPageIndex, int pageSize, out int recordCount)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            IDataParameter[] paras = new IDataParameter[7];
            paras[0] = helper.GetParameter("@RecordCount", DbType.Int32, 4, ParameterDirection.Output);
            paras[1] = helper.GetParameter("@QueryStr", viewtablesql);
            paras[2] = helper.GetParameter("@FdShow", fields);
            paras[3] = helper.GetParameter("@FdOrder", "order by "+sort);
            paras[4] = helper.GetParameter("@Where", "where "+filter);
            paras[5] = helper.GetParameter("@PageCurrent", currentPageIndex+1);
            paras[6] = helper.GetParameter("@PageSize", pageSize);
            DataSet list = helper.ExecuteDataset(helper.connectionString, "sp_list", paras);
            recordCount = Convert.ToInt32(paras[0].Value);
            return list;
        }

    }
}
