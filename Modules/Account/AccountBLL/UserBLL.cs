using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace Modules.Account
{
    /// <summary>
    /// 用户业务逻辑层
    /// </summary>
    public class UserBLL
    {
        /// <summary>
        /// 获取用户详细信息
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <returns>用户详细信息</returns>
        public UserDetail GetUserDetail(int userId)
        {
           return new UserDAL().GetUserDetail(userId);
        }
        /// <summary>
        /// 获取用户的角色标识列表
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <returns>角色标识列表</returns>
        public ArrayList GetUserRoles(int userId)
        {
            return new UserDAL().GetUserRoles(userId);
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="detail">用户详细信息（UserDetail形式）</param>
        /// <returns>用户标识</returns>
        public int Add(UserDetail detail)
        {
            return new UserDAL().Add(detail);
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="detail">用户详细信息（UserDetail形式）</param>
        /// <returns>成功 返回true</returns>
        public bool Update(UserDetail detail)
        {
            return new UserDAL().Update(detail);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <returns>成功 返回true</returns>
        public bool Delete(int userId)
        {
            return new UserDAL().DeleteUser(userId);
        }
        /// <summary>
        /// 删除用户改变标识
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <returns>成功 返回true</returns>
        public bool DeleteUserChange(int userId)
        {
            return new UserDAL().DeleteUserChange(userId);
        }
        /// <summary>
        /// 改变用户的角色
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <param name="roleId">角色表示</param>
        public void ChangeUserRole(int userId, int roleId)
        {
            UserDAL user = new UserDAL();
            user.DeleteAllRoles(userId);
            user.AddRole(userId, roleId);
        }
        /// <summary>
        /// 取下级部门id和本级部门id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetDeptid(string id)
        {
            return new UserDAL().GetDeptid(id);
        }
        /// <summary>
        /// 获取符合条件的用户
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <param name="sort">排序</param>
        /// <returns>用户集</returns>
        public DataSet GetUserList(string filter, string sort)
        {
            return new UserDAL().GetUsers(filter, sort);
        }
        /// <summary>
        /// 改变审核状态
        /// </summary>
        /// <param name="userId">用户标识</param>
        public void ChangeApprovedStatus(int userId)
        {
            UserDAL user = new UserDAL();
            int status=user.GetUserDetail(userId).Approved;
            if (status == 0) user.Approve(userId, true);
            else user.Approve(userId, false);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <param name="pwd">原始密码</param>
        /// <returns>成功 返回 true</returns>
        public bool ModifyPwd(int userId, string pwd)
        {
            return new UserDAL().ModifyPwd(userId, CustomPrincipal.EncryptPassword(pwd));
        }

        /// <summary>
        /// 验证输入的密码
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <param name="pwd">原始密码</param>
        /// <returns>验证成功 返回true</returns>
        public bool ValidatePwd(int userId, string pwd)
        {
            UserDAL user = new UserDAL();
            UserDetail detail = user.GetUserDetail(userId);
            string encPwd = CustomPrincipal.EncryptPassword(pwd);
            return encPwd.Equals(detail.Password);
        }
        public bool ExistNickname(string nickname)
        {
            return new UserDAL().GetUserDetail(nickname) != null;
        }
        public DataSet GetUsers(string where)
        {
            return new UserDAL().GetUsers(where);
        }
        
    }
}
