using System;
using System.Collections.Generic;
using System.Text;
using CommonUtility.DBUtility;
using System.Data;
using System.Collections;

namespace Modules.Account
{
    /// <summary>
    /// 用户的详细信息
    /// </summary>
    public class UserDetail
    {
        /// <summary>
        /// 用户标识
        /// </summary>
        public int UserId;
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password;
        /// <summary>
        /// 审核 0:未审核,1:审核过
        /// </summary>
        public int Approved;
        /// <summary>
        /// 真名
        /// </summary>
        public string Realname;
        /// <summary>
        /// 省份
        /// </summary>
        public string Province;
        /// <summary>
        /// 城市
        /// </summary>
        public string City;
        /// <summary>
        /// 住址
        /// </summary>
        public string Address;
        /// <summary>
        /// 电话
        /// </summary>
        public string Tel;
        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email;
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string Postalcode;
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark;
        /// <summary>
        /// 注册类型 0:前台注册的会员,1:后台注册的用户
        /// </summary>
        public int RegisterType;
        /// <summary>
        /// 添加时间
        /// </summary>
        public string AddedDate;
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public string LastModifiedDate;
    }
    internal class UserDAL
    {
        /// <summary>
        /// 获取用户详细信息
        /// </summary>
        /// <param name="UserId">用户标识</param>
        /// <returns>用户详细信息</returns>
        public UserDetail GetUserDetail(int UserId)
        { 
            string query=String.Format("select * from T_User where UserId={0}",UserId);
            DataSet ds=AdoHelper.CreateHelper().ExecuteDataset(query);
            if (ds.Tables[0].Rows.Count == 1)
            {
               return GetUserDetailFromDataRow(ds.Tables[0].Rows[0]);
            }
            return null;
        }
        /// <summary>
        /// 获取用户详细信息
        /// </summary>
        /// <param name="nickname">用户昵称</param>
        /// <returns>用户详细信息</returns>
        public UserDetail GetUserDetail(string nickname)
        {
            string query = String.Format("select * from T_User where Nickname='{0}'", nickname);
            DataSet ds = AdoHelper.CreateHelper().ExecuteDataset(query);
            if (ds.Tables[0].Rows.Count == 1)
            {
                return GetUserDetailFromDataRow(ds.Tables[0].Rows[0]);
            }
            return null;
        }
        private UserDetail GetUserDetailFromDataRow(DataRow userInfo)
        {
            UserDetail detail = new UserDetail();
            detail.UserId = (int)userInfo["UserId"];
            detail.Nickname = userInfo["Nickname"].ToString();
            detail.Password = userInfo["Password"].ToString();
            detail.Realname = userInfo["Realname"].ToString();
            detail.Province = userInfo["Province"].ToString();
            detail.City = userInfo["City"].ToString();
            detail.Address = userInfo["Address"].ToString();
            detail.Tel = userInfo["Tel"].ToString();
            detail.Email = userInfo["Email"].ToString();
            detail.Postalcode = userInfo["Postalcode"].ToString();
            detail.Remark = userInfo["Remark"].ToString();
            detail.Approved = (int)userInfo["Approved"];
            detail.RegisterType = (int)userInfo["RegisterType"];
            detail.AddedDate = userInfo["AddedDate"].ToString();
            detail.LastModifiedDate = userInfo["LastModifiedDate"].ToString();
            return detail;
        }
        public DataRow Retrieve(int UserId)
        { 
            string query=String.Format("select * from T_User where UserId={0}",UserId);
            DataSet ds=AdoHelper.CreateHelper().ExecuteDataset(query);
            if (ds.Tables[0].Rows.Count == 1)
            {
                return ds.Tables[0].Rows[0];
            }
            return null;
        }
        public DataRow Retrieve(string nickname)
        {
            string query = String.Format("select * from T_User where Nickname='{0}'", nickname);
            DataSet ds = AdoHelper.CreateHelper().ExecuteDataset(query);
            if (ds.Tables[0].Rows.Count == 1)
            {
                return ds.Tables[0].Rows[0];
            }
            return null;
        }

        public ArrayList GetEffectivePermissionList(int userId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder query=new StringBuilder();
            query.Append("select distinct b.PermissionId ");
            query.Append("from R_UserRole a inner join R_RolePermission b on a.RoleId=b.RoleId");
            query.AppendFormat(" where a.UserId={0}",userId);
            IDataReader dr = helper.ExecuteReader(query.ToString());
            ArrayList permissionList = new ArrayList();
            while (dr.Read())
            {
                permissionList.Add(dr["permissionId"]);
            }
            return permissionList;
        }
        /// <summary>
        /// 获取用户的角色标识列表
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <returns>角色标识列表</returns>
        public ArrayList GetUserRoles(int userId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            String query = String.Format("select RoleId from R_UserRole where UserId={0}", userId);
            IDataReader dr=helper.ExecuteReader(query);
            ArrayList roleList = new ArrayList();
            while (dr.Read())
            {
                roleList.Add(dr["RoleId"]);
            }
            return roleList;
        }
        public int TestPassword(int userid, string cryptPassword)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string query = String.Format("select UserId,Password from T_User where UserId={0}", userid);
            IDataReader dr=helper.ExecuteReader(query);
            if (dr.Read())
            {
                int currentUserId = (int)dr["UserId"];
                string currentPassword=dr["Password"].ToString();
                if (currentUserId == userid && currentPassword == cryptPassword) return userid;
            }
            return -1;
        }
        public int TestPassword(string nickname, string cryptPassword)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string query = String.Format("select UserId,Nickname,Password,Approved from T_User where Nickname='{0}'", nickname);
            IDataReader dr = helper.ExecuteReader(query);
            if (dr.Read())
            {
                int currentUserId = (int)dr["UserId"];
                string currentNickname = dr["Nickname"].ToString();
                string currentPassword = dr["Password"].ToString();
                int approved = (int)dr["Approved"];
                if (currentNickname == nickname && currentPassword == cryptPassword)
                {
                    if (approved == 1) return currentUserId;
                    else return -1;//未审核 或 审核未通过
                }
            }
            return -2;//用户名或密码错误
        }
        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="where">选择条件</param>
        /// <param name="order">排序条件</param>
        /// <returns>满足指定条件的记录集</returns>
        public DataSet GetUsers(string where, string order)
        {
            where = where.Trim();
            order = order.Trim();
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder query = new StringBuilder();
            query.Append("select * from T_User ");
            if (where != String.Empty) query.AppendFormat("where {0} ", where);
            if (order != String.Empty) query.AppendFormat("order by {0}", order); 
            return helper.ExecuteDataset(query.ToString());
        }
        /// <summary>
        /// 取下级部门id和本级部门id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetDeptid(string id)
        {
            string str = "";
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from T_DepartCategory where CategoryId='" + id + "' or ParentCategoryId='"+id+"'");
            DataTable dt = helper.ExecuteDataset(sb.ToString()).Tables[0];
            if (dt.Rows.Count>0)
            {
                str.Trim();
                foreach (DataRow item in dt.Rows)
                {
                    str += item["CategoryId"] + ",";
                }
            }
            return str.TrimEnd(',');
        }
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="nickname">昵称</param>
        /// <param name="password">密码</param>
        /// <param name="realname">真名</param>
        /// <param name="remark">备注</param>
        /// <param name="province">省份</param>
        /// <param name="city">城市</param>
        /// <param name="address">住址</param>
        /// <param name="postalcode">邮政编码</param>
        /// <param name="tel">电话</param>
        /// <param name="email">电子邮件</param>
        /// <param name="approved">审核</param>
        /// <param name="AddedDate">添加时间</param>
        /// <returns>用户标识</returns>
        public int Add(string nickname, string password,
                       string realname, string remark,
                       string province, string city,
                       string address, string postalcode,
                       string tel, string email,
                       int approved,int registerType)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            IDataParameter[] paras = new IDataParameter[12];
            paras[0] = helper.GetParameter("@Nickname", nickname);
            paras[1] = helper.GetParameter("@Password", password);
            paras[2] = helper.GetParameter("@Realname", realname);
            paras[3] = helper.GetParameter("@Remark", remark);
            paras[4] = helper.GetParameter("@Province", province);
            paras[5] = helper.GetParameter("@City", city);
            paras[6] = helper.GetParameter("@Address", address);
            paras[7] = helper.GetParameter("@Postalcode", postalcode);
            paras[8] = helper.GetParameter("@Tel", tel);
            paras[9] = helper.GetParameter("@Email", email);
            paras[10] = helper.GetParameter("@Approved", approved);
            paras[11] = helper.GetParameter("@RegisterType", registerType);
           // paras[12] = helper.GetParameter("@UserId",DbType.Int32,4,ParameterDirection.Output);
            string strsql = @"Insert into T_User (Nickname,Password,Realname,Remark,Province,City,Address,Postalcode,Tel,Email,Approved,RegisterType) 
Values(@Nickname,@Password,@Realname,@Remark,@Province,@City,@Address,@Postalcode,@Tel,@Email,@Approved,@RegisterType)";
            return helper.ExecuteNonQuery(helper.connectionString, CommandType.Text,strsql, paras);
            //helper.ExecuteNonQuery("sp_Account_AddUser", paras);
            //return (int)(paras[12].Value);
        }

        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="detail">用户信息(UserDetail形式)</param>
        /// <returns>用户标识</returns>
        public int Add(UserDetail detail)
        {
            return Add(detail.Nickname, detail.Password, detail.Realname,
                       detail.Remark, detail.Province, detail.City,
                       detail.Address, detail.Postalcode, detail.Tel,
                       detail.Email, detail.Approved,detail.RegisterType);
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <param name="nickname">昵称</param>
        /// <param name="password">密码</param>
        /// <param name="realname">真名</param>
        /// <param name="remark">备注</param>
        /// <param name="province">省份</param>
        /// <param name="city">城市</param>
        /// <param name="address">住址</param>
        /// <param name="postalcode">邮政编码</param>
        /// <param name="tel">电话</param>
        /// <param name="email">电子邮件</param>
        /// <param name="approved">审核</param>
        /// <param name="lastModifiedDate">最后修改时间</param>
        /// <returns>成功 返回true</returns>
        public bool Update(int userId, string nickname, 
                           string password,string realname, 
                           string remark, string province,
                           string city, string address,
                           string postalcode,string tel,
                           string email,int approved,
                           string lastModifiedDate)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("Update T_User Set Nickname='{0}',Password='{1}',Realname='{2}',", nickname, password, realname);
            sql.AppendFormat("Remark='{0}',Province='{1}',City='{2}',Address='{3}',", remark, province, city,address);
            sql.AppendFormat("Postalcode='{0}',Tel='{1}',Email='{2}',",postalcode,tel,email);
            sql.AppendFormat("Approved={0},LastModifiedDate='{1}' ",approved,lastModifiedDate.ToString());
            sql.AppendFormat("Where UserId={0}",userId);
            return helper.ExecuteNonQuery(sql.ToString())>0;
        }

        /// <summary>
        ///  修改用户信息
        /// </summary>
        /// <param name="detail">用户信息(UserDetail形式)</param>
        /// <returns>成功 返回true</returns>
        public bool Update(UserDetail detail)
        {
            return Update(detail.UserId, detail.Nickname, detail.Password,
                          detail.Realname, detail.Remark, detail.Province,
                          detail.City, detail.Address, detail.Postalcode,
                          detail.Tel, detail.Email, detail.Approved, detail.LastModifiedDate);
        }

        /// <summary>
        /// 删除用户所有角色
        /// </summary>
        /// <param name="userId">用户标识</param>
        public void DeleteAllRoles(int userId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string sql = String.Format("delete from  R_UserRole where UserId={0}", userId);
            helper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 给用户添加一个角色
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <param name="roleId">角色标识</param>
        public void AddRole(int userId, int roleId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string sql = String.Format("insert R_UserRole(UserId,RoleId) values({0},{1})", userId, roleId);
            helper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 用户审核
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <param name="isApproved">审核通过 为true</param>
        public void Approve(int userId, bool isApproved)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string sql = String.Format("update T_User set Approved={0} where UserId={1}", isApproved ? 1 : 0, userId);
            helper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <returns>成功 返回true</returns>
        public bool DeleteUser(int userId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            IDataParameter[] paras=new IDataParameter[1];
            paras[0]=helper.GetParameter("@UserId",userId);
            return helper.ExecuteNonQuery("sp_Account_DelUser", paras)>0;
        }
        /// <summary>
        /// 删除用户改变标识
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <returns>成功 返回true</returns>
        public bool DeleteUserChange(int userId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder sb = new StringBuilder();
            sb.Append("update t_user set RegisterType='0' where UserId='"+userId+"'");
           
            return helper.ExecuteNonQuery(sb.ToString()) > 0;
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <param name="pwd">加密后的密码</param>
        /// <returns>成功 返回 true</returns>
        public bool ModifyPwd(int userId, string pwd)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string sql = String.Format("update T_User set Password='{0}' where UserId={1}", pwd, userId);
            return helper.ExecuteNonQuery(sql) > 0;
        }
        public DataSet GetUsers(string where)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT a.*,b.Title as deptname  FROM T_User a,T_DepartCategory b where a.email=b.CategoryId");
            if (where != string.Empty)
            {
                builder.AppendFormat(" and {0} ", where);
            }
            return helper.ExecuteDataset(builder.ToString());
        }

 

    }
}
