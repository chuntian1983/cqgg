using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonUtility.DBUtility;

namespace Modules.Link
{
    public class LinkDetail
    {
        public int LinkId;
        public string Title;
        public string Link;
        public string Image;
        public int DisplayMode;
        public int Sort;
        public string deptid;
    }
    internal class LinkDAL
    {
        public DataRow GetLinkRow(int linkId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder query = new StringBuilder();
            query.Append("select * from T_Link ");
            query.AppendFormat(" where LinkId={0}", linkId);
            DataSet result = helper.ExecuteDataset(query.ToString());
            if (result.Tables[0].Rows.Count == 1) return result.Tables[0].Rows[0];
            return null;
        }

        public LinkDetail GetLinkDetail(int linkId)
        {
            DataRow info = this.GetLinkRow(linkId);
            return this.GetLinkDetailFromDataRow(info);
        }

        private LinkDetail GetLinkDetailFromDataRow(DataRow linkInfo)
        {
            if (linkInfo == null) return null;
            LinkDetail detail = new LinkDetail();
            detail.LinkId = (int)linkInfo["LinkId"];
            detail.Title = linkInfo["Title"].ToString();
            detail.Link = linkInfo["Link"].ToString();
            detail.Image = linkInfo["Image"].ToString();
            detail.DisplayMode = (int)linkInfo["DisplayMode"];
            detail.Sort = (int)linkInfo["Sort"];
            return detail;

        }

        public int AddLink(string title, string link,
                       string image, int displayMode,int sort,string deptid)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            IDataParameter[] paras = new IDataParameter[7];
            paras[0] = helper.GetParameter("@Title", title);
            paras[1] = helper.GetParameter("@Link", link);
            paras[2] = helper.GetParameter("@Image", image);
            paras[3] = helper.GetParameter("@DisplayMode", displayMode);
            paras[4] = helper.GetParameter("@Sort", sort);
            paras[5] = helper.GetParameter("@LinkId", DbType.Int32, 4, ParameterDirection.Output);
            paras[6] = helper.GetParameter("@deptid", deptid);
            string strsql = "Insert T_Link (Title,Link,Image,DisplayMode,Sort)Values (@Title,@Link,@Image,@DisplayMode,@Sort)";
            helper.ExecuteNonQuery(helper.connectionString,CommandType.Text,strsql, paras);
            return Convert.ToInt32(paras[5].Value);
        }

        public int AddLink(LinkDetail detail)
        {
            return this.AddLink(detail.Title,detail.Link,detail.Image,detail.DisplayMode,detail.Sort,detail.deptid);
        }

        public bool UpdateLink(int linkId, string title, string link,
                               string image, int displayMode,int sort)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("update T_Link set Title='{0}',Link='{1}',Image='{2}',", title, link, image);
            sql.AppendFormat("DisplayMode={0},Sort={1} where LinkId={2}", displayMode, sort, linkId);
            return helper.ExecuteNonQuery(sql.ToString()) > 0;
        }

        public bool UpdateLink(LinkDetail detail)
        {
            return this.UpdateLink(detail.LinkId,detail.Title,detail.Link,detail.Image,detail.DisplayMode,detail.Sort);
        }

        public DataSet GetAllLinkDetailes()
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from T_Link order by displaymode,sort");
            return helper.ExecuteDataset(sql.ToString());
        }
        public DataSet GetLinkList(string strwhere)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from T_Link");
            if (!string.IsNullOrEmpty(strwhere))
            {
                sql.Append(" where "+strwhere);
            }
            sql.Append("order by displaymode,sort");
            return helper.ExecuteDataset(sql.ToString());
        }
        public bool DeleteLink(int linkId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string sql = String.Format("delete from T_Link where LinkId='{0}'", linkId);
            return helper.ExecuteNonQuery(sql) > 0;
        }

        
    }
}
