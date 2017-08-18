using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonUtility.DBUtility;

namespace Modules.Department
{
    public class DepartmentDetail
    {
        public int DepartId;
        public string Title;
        public string Body;
        public int AddedUserId;
        public DateTime AddedDate;
        public int CategoryId;
        public int Approved;
        public int ViewCount;
        public string ImgLink;
    }

    internal class DepartmentDAL
    {
        public DataRow GetDepartmentRow(int DepartId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder query = new StringBuilder();
            query.Append("select * from T_DepartInfo a inner join T_DepartCategory b on a.CategoryId=b.CategoryId");
            query.AppendFormat(" where a.DepartId={0}", DepartId);
            DataSet result = helper.ExecuteDataset(query.ToString());
            if (result.Tables[0].Rows.Count == 1) return result.Tables[0].Rows[0];
            return null;
        }

        public DepartmentDetail GetDepartmentDetail(int DepartId)
        {
            DataRow info = this.GetDepartmentRow(DepartId);
            return this.GetDepartmentDetailFromDataRow(info);
        }

        private DepartmentDetail GetDepartmentDetailFromDataRow(DataRow departInfo)
        {
            if (departInfo == null) return null;
            DepartmentDetail detail = new DepartmentDetail();
            detail.DepartId = (int)departInfo["DepartId"];
            detail.Title = departInfo["Title"].ToString();
            detail.Body = departInfo["Body"].ToString();
            detail.AddedUserId = (int)departInfo["AddedUserId"];
            detail.AddedDate = Convert.ToDateTime(departInfo["AddedDate"]);
            detail.CategoryId = (int)departInfo["CategoryId"];
            detail.Approved = (int)departInfo["Approved"];
            detail.ViewCount = (int)departInfo["ViewCount"];
            detail.ImgLink = departInfo["ImgLink"].ToString();
            return detail;

        }

        public int Add(string title, string body,
                    int categoryId, int approved,
                    int viewCount, int addedUserId, string imgLink)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            IDataParameter[] paras = new IDataParameter[8];
            paras[0] = helper.GetParameter("@Title", title);
            paras[1] = helper.GetParameter("@Body", body);
            paras[2] = helper.GetParameter("@CategoryId", categoryId);
            paras[3] = helper.GetParameter("@Approved", approved);
            paras[4] = helper.GetParameter("@ViewCount", viewCount);
            paras[5] = helper.GetParameter("@AddedUserId", addedUserId);
            paras[6] = helper.GetParameter("@ImgLink", imgLink);
            paras[7] = helper.GetParameter("@DepartId", DbType.Int32, 4, ParameterDirection.Output);
            helper.ExecuteNonQuery("sp_Depart_Add", paras);
            return Convert.ToInt32(paras[7].Value);
        }

        public int Add(DepartmentDetail detail)
        {
            return this.Add(detail.Title, detail.Body,
                            detail.CategoryId, detail.Approved, detail.ViewCount, detail.AddedUserId, detail.ImgLink);
        }

        public bool Update(int departId, string title, string body,
                       
                         int categoryId, int approved, int viewCount, string imgLink)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("update T_DepartInfo set Title='{0}',Body='{1}',", title, body);
            sql.AppendFormat("CategoryId={0},", categoryId);
            sql.AppendFormat("ImgLink='{0}',", imgLink);
            sql.AppendFormat("Approved={0},ViewCount={1} where DepartId={2}", approved, viewCount, departId);
            return helper.ExecuteNonQuery(sql.ToString()) > 0;
        }

        public bool Update(DepartmentDetail detail)
        {
            return this.Update(detail.DepartId, detail.Title, detail.Body,
                               detail.CategoryId, detail.Approved, detail.ViewCount, detail.ImgLink);
        }

        public DataSet GetDepartmentDetailes()
        {
            return GetDepartmentDetailList(String.Empty, "DepartId desc");
        }
        public DataSet GetDepartmentList(string fields, string filter, string sort, int currentPageIndex, int pageSize, out int recordCount)
        {
            return CommonUtility.PaginationUtility.GetPaginationList(fields, "V_Depart", filter, sort, currentPageIndex, pageSize, out recordCount);
        }

        public DataSet GetDepartmentDetailList(string filter, string sort)
        {
            filter = filter.Trim();
            sort = sort.Trim();
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder sql = new StringBuilder();
            sql.Append("select a.*,b.Title as CategoryTitle,c.Nickname ");
            sql.Append("from T_DepartInfo a inner join T_DepartCategory b on a.CategoryId=b.CategoryId ");
            sql.Append(" inner join T_User c on a.AddedUserId=c.UserId");
            if (filter != String.Empty) sql.AppendFormat(" where {0} ", filter);
            if (sort != String.Empty) sql.AppendFormat(" order by {0}", sort);
            return helper.ExecuteDataset(sql.ToString());
        }

        public bool DeleteDepartment(int departId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string sql = String.Format("delete T_DepartInfo where DepartId={0}", departId);
            return helper.ExecuteNonQuery(sql) > 0;
        }
        public void ApproveDepartment(int departId, bool isApproved)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string sql = String.Format("update T_DepartInfo set Approved={0} where DepartId={1}", isApproved ? 1 : 0, departId);
            helper.ExecuteNonQuery(sql);
        }
        public int GetRecordCount(string filter)
        {
            filter = filter.Trim();
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder sql = new StringBuilder();
            sql.Append("select count(*) from T_DepartInfo");
            if (filter != String.Empty)
                sql.AppendFormat(" where {0}", filter);
            return Convert.ToInt32(helper.ExecuteScalar(sql.ToString()));
        }
    }
}