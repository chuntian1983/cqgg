using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonUtility.DBUtility;

namespace Modules.Account
{
    internal class PermissionDetail
    {
        internal int PermissionId;
        internal string Description;
        internal string MenuLink;
        internal int Sort;
        internal int ParentId;
        internal int PermissionTypeId;
    }
    internal class PermissionDAL
    {
        public PermissionDetail Retrieve(int PermissionId)
        {
            string query = String.Format("select * from T_Permission where PermissionId={0}", PermissionId);
            DataSet ds = AdoHelper.CreateHelper().ExecuteDataset(query);
            if (ds.Tables[0].Rows.Count == 1)
            {
                PermissionDetail permissionInfo = new PermissionDetail();
                DataRow dr = ds.Tables[0].Rows[0];
                permissionInfo.PermissionId = (int)dr["PermissionId"];
                permissionInfo.Description = dr["Description"].ToString();
                permissionInfo.ParentId = dr["ParentId"].Equals(DBNull.Value) ? 0 : (int)dr["ParentId"];
                permissionInfo.MenuLink = dr["MenuLink"].Equals(DBNull.Value) ? String.Empty : dr["MenuLink"].ToString();
                permissionInfo.Sort = (int)dr["Sort"];
                permissionInfo.PermissionTypeId = (int)dr["PermissionTypeId"];
                return permissionInfo;
            }
            return null;
        }
        public DataRow RetrieveRow(int PermissionId)
        {
            string query = String.Format("select * from T_Permission where PermissionId={0}", PermissionId);
            DataSet ds = AdoHelper.CreateHelper().ExecuteDataset(query);
            if (ds.Tables[0].Rows.Count == 1)
                return ds.Tables[0].Rows[0];
            return null;
        }
        public DataSet GetPermissionList(int roleId, int permissionType)
        {
            return new DataSet();
        }
        public void Add()
        { }
    }
}
