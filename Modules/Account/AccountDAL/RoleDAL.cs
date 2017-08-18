using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonUtility.DBUtility;
using System.Collections;

namespace Modules.Account
{
    /// <summary>
    /// ��ɫ����ϸ��Ϣ
    /// </summary>
    public class RoleDetail
    {
        /// <summary>
        /// ��ɫ��ʶ
        /// </summary>
        public int RoleID;
        /// <summary>
        /// ��ɫ����
        /// </summary>
        public string Name;
        /// <summary>
        /// ��ע
        /// </summary>
        public string Remark;
        /// <summary>
        /// �����
        /// </summary>
        public int Sort;
        /// <summary>
        /// ��ӽ�ɫ����
        /// </summary>
        public int AddedUserId;
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public string AddedDate;
        /// <summary>
        /// ����޸�ʱ��
        /// </summary>
        public string LastModifiedDate;
    }
    internal class RoleDAL
    {
        /// <summary>
        /// ��ӽ�ɫ
        /// </summary>
        /// <param name="name">��ɫ����</param>
        /// <param name="remark">��ע</param>
        /// <param name="sort">�����</param>
        /// <param name="addedUserId">��ӽ�ɫ����</param>
        /// <returns>��ɫ��ʶ</returns>
        public int Add(string name, string remark,int sort,int addedUserId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            IDataParameter[] paras = new IDataParameter[5];
            paras[0] = helper.GetParameter("@Name", name);
            paras[1] = helper.GetParameter("@Remark", remark);
            paras[2] = helper.GetParameter("@Sort", sort);
            paras[3] = helper.GetParameter("@AddedUserId", addedUserId);
            paras[4] = helper.GetParameter("@RoleId",DbType.Int32,4,ParameterDirection.Output);
            string strsql = @"INSERT T_Role  (Name,Remark,Sort,AddedUserId) VALUES (@Name,@Remark,@Sort,@AddedUserId)";
            helper.ExecuteNonQuery(helper.connectionString,CommandType.Text,strsql,paras);
            return (int)paras[3].Value;
        }

        /// <summary>
        /// ��ӽ�ɫ
        /// </summary>
        /// <param name="detail">��ɫ��Ϣ(RoleDetail��ʽ)</param>
        /// <returns>��ɫ��ʶ</returns>
        public int Add(RoleDetail detail)
        {
            return Add(detail.Name, detail.Remark, detail.Sort, detail.AddedUserId);
        }
        /// <summary>
        /// �޸Ľ�ɫ
        /// </summary>
        /// <param name="roleId">��ɫ��ʶ</param>
        /// <param name="name">��ɫ����</param>
        /// <param name="remark">��ע</param>
        /// <param name="sort">�����</param>
        /// <param name="LastModifiedDate">����޸�ʱ��</param>
        /// <returns>�ɹ� ����true</returns>
        public bool Update(int roleId, string name, string remark,int sort, string LastModifiedDate)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("Update T_Role Set Name='{0}',Remark='{1}',Sort={2},LastModifiedDate='{3}' ",name,remark,sort,LastModifiedDate.ToString());
            sql.AppendFormat("Where RoleId={0}",roleId);
            return helper.ExecuteNonQuery(sql.ToString()) > 0;
        }

        /// <summary>
        /// �޸Ľ�ɫ
        /// </summary>
        /// <param name="detail">��ɫ��Ϣ(RoleDetail��ʽ)</param>
        /// <returns>�ɹ� ����true</returns>
        public bool Update(RoleDetail detail)
        {
            return Update(detail.RoleID, detail.Name, detail.Remark, detail.Sort, detail.LastModifiedDate);
        }
        /// <summary>
        /// ɾ����ɫ
        /// </summary>
        /// <param name="roleId">��ɫ��ʶ</param>
        /// <returns>�ɹ� ����true</returns>
        public bool Delete(int roleId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            IDataParameter[] paras = new IDataParameter[1];
            paras[0] = helper.GetParameter("@RoleId", roleId);
            string strsql = @"Delete from R_UserRole where RoleId=@RoleId";
            
            string strsql1 = @"Delete from R_RolePermission where RoleId=@RoleId";
            string strsql2 = @"Delete from T_Role where RoleId=@RoleId";
            helper.ExecuteNonQuery(helper.connectionString, CommandType.Text, strsql1, paras);
            helper.ExecuteNonQuery(helper.connectionString, CommandType.Text, strsql2, paras);
            return helper.ExecuteNonQuery(helper.connectionString, CommandType.Text, strsql, paras) > 0;
        }

        /// <summary>
        /// ��ȡ��ɫ��Ϣ(DataRow��ʽ)
        /// </summary>
        /// <param name="roleId">��ɫ��ʶ</param>
        /// <returns>��ɫ��Ϣ(DataRow��ʽ)</returns>
        public DataRow GetRole(int roleId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string query = String.Format("select * from T_Role where RoleId={0}", roleId);
            DataSet roleInfo = helper.ExecuteDataset(query);
            if (roleInfo.Tables[0].Rows.Count == 1) return roleInfo.Tables[0].Rows[0];
            return null;
        }
        /// <summary>
        /// ��ȡ��ɫ��Ϣ(RoleDetail��ʽ)
        /// </summary>
        /// <param name="roleId">��ɫ��ʶ</param>
        /// <returns>��ɫ��Ϣ(RoleDetail��ʽ)</returns>
        public RoleDetail GetRoleDetail(int roleId)
        {
            DataRow role = GetRole(roleId);
            if (role != null) return GetRoleDetailFromDataRow(role);
            return null;
        }

        /// <summary>
        /// ��DataRow��ʽ��ɫ��Ϣת��ΪRoleDetail��ʽ��ɫ��Ϣ
        /// </summary>
        /// <param name="role">DataRow��ʽ��ɫ��Ϣ</param>
        /// <returns>RoleDetail��ʽ��ɫ��Ϣ</returns>
        private RoleDetail GetRoleDetailFromDataRow(DataRow role)
        {
            RoleDetail detail = new RoleDetail();
            detail.RoleID =(int) role["RoleId"];
            detail.Name = role["Name"].ToString();
            detail.Remark = role["Remark"].ToString();
            detail.Sort = (int)role["Sort"];
            detail.AddedUserId = (int)role["AddedUserId"];
            detail.AddedDate = role["AddedDate"].ToString();
            detail.LastModifiedDate = role["LastModifiedDate"].ToString();
            return detail;
        }

        /// <summary>
        /// ��ȡ���н�ɫ��Ϣ
        /// </summary>
        /// <returns>���н�ɫ��Ϣ</returns>
        public DataSet GetAllRoles()
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string query = "select * from T_Role order by Sort";
            return helper.ExecuteDataset(query);
        }

        /// <summary>
        ///  ����ɫ���Ȩ��
        /// </summary>
        /// <param name="roleId">��ɫ��ʶ</param>
        /// <param name="permissionId">Ȩ�ޱ�ʶ</param>
        /// <returns>�ɹ� ����true</returns>
        public bool AddPermission(int roleId,int permissionId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            IDataParameter[] paras = new IDataParameter[2];
            paras[0] = helper.GetParameter("@RoleId", roleId);
            paras[1] = helper.GetParameter("@PermissionId", permissionId);
            string strsql = @"Insert R_RolePermission (RoleId,PermissionId) Values(@RoleId,@PermissionId)";
            //return helper.ExecuteNonQuery("sp_Account_AddPermissionToRole", paras) > 0;
            return helper.ExecuteNonQuery(helper.connectionString,CommandType.Text,strsql,paras) > 0;
        }

        /// <summary>
        /// ɾ����ɫ
        /// </summary>
        /// <param name="roleId">��ɫ��ʶ</param>
        /// <param name="permissionId">Ȩ�ޱ�ʶ</param>
        /// <returns>�ɹ� ����true</returns>
        public bool DeletePermission(int roleId, int permissionId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            String sql = String.Format("delete from R_RolePermission where RoleId={0} and PermissionId={1}", roleId, permissionId);
            return helper.ExecuteNonQuery(sql) > 0;
        }

        /// <summary>
        /// ��ȡ��ɫ��Ȩ���б�
        /// </summary>
        /// <param name="roleId">��ɫ��ʶ</param>
        /// <returns>��ɫ��Ȩ���б�</returns>
        public ArrayList GetPermissionList(int roleId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string sql = String.Format("select PermissionId from R_RolePermission where RoleId={0}", roleId);
            DataSet ds = helper.ExecuteDataset(sql);
            ArrayList list = new ArrayList();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(dr["PermissionId"]);
            }
            return list;
        }
        /// <summary>
        /// ��ȡ��ɫ�Ĳ˵���Ȩ���б�
        /// </summary>
        /// <param name="roleId">��ɫ��ʶ</param>
        /// <returns>��ɫ�Ĳ˵���Ȩ���б�</returns>
        public ArrayList GetMenuPermissionList(int roleId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder query = new StringBuilder();
            query.Append("select a.PermissionId from R_RolePermission a inner join T_permission b on a.PermissionId=b.PermissionId");
            query.AppendFormat(" where b.PermissionTypeId=1 and a.RoleId={0}", roleId);
            DataSet ds = helper.ExecuteDataset(query.ToString());
            ArrayList list = new ArrayList();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(dr["PermissionId"]);
            }
            return list;
        }
        
    }
}
