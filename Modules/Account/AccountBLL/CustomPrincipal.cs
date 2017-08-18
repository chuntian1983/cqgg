using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;
using System.Collections;
using System.Web.Security;
using System.Web;
using Modules.Log;

namespace Modules.Account
{
   
        public class CustomPrincipal : IPrincipal
        {
            protected IIdentity _identity;
            protected ArrayList _permissionList;
            protected ArrayList _roleList;

            // IPrincipal Interface Requirements:
            // property Identity (IIDentity)
            // property IsInRole (boolean)

            public IIdentity Identity
            {
                get
                {
                    return this._identity;
                }
                set
                {
                    this._identity = value;
                }
            }

            public bool IsInRole(string role)
            {
                if (this._roleList == null)
                {
                    int userId = Convert.ToInt32(this._identity.Name);
                    this._roleList = new UserDAL().GetUserRoles(userId);
                }
                return this._roleList.Contains(Convert.ToInt32(role));
            }

            public bool HasPermission(int permissionID)
            {
                if (this._permissionList == null)
                {
                    int userId = Convert.ToInt32(this._identity.Name);
                    this._permissionList = new UserDAL().GetEffectivePermissionList(userId);
                }
                return this._permissionList.Contains(permissionID);
            }

            public void Demand(int permissionId, string redirectUrl)
            {
                if (!this.HasPermission(permissionId))
                {
                    OperateLog.AddLog(String.Format("越权操作发生在权限标识{0}位置。", permissionId));
                    HttpContext.Current.Response.Redirect(redirectUrl, true);
                }
            }

            public void Demand(int permissionId)
            {
                this.Demand(permissionId, "~/sysadmin/nopermission.aspx");
            }

            public CustomPrincipal(int userID)
            {
                this._identity = new CustomIdentity(userID);
            }
            public CustomPrincipal(string userId):this(Convert.ToInt32(userId))
            {
               
            }

            public static CustomPrincipal CurrentRequestPrincipal
            {
                get
                {
                    if (!HttpContext.Current.User.Identity.IsAuthenticated)
                        return null;
                    string userId = HttpContext.Current.User.Identity.Name;
                    return new CustomPrincipal(userId);
                }
            }

            /// <summary>
            /// 验证用户凭证
            /// </summary>
            /// <param name="nickname">昵称</param>
            /// <param name="password">密码</param>
            /// <returns>成功返回用户标识，-1标识 未审核 或 审核未通过，-2标识 昵称或密码错误</returns>
            public static int ValidateLogin(string nickname, string password)
            {
                string cryptPassword = EncryptPassword(password);
                return new UserDAL().TestPassword(nickname, cryptPassword);
            }

            public static string EncryptPassword(string password)
            {
                return FormsAuthentication.HashPasswordForStoringInConfigFile(password, "sha1");
            }

        }
    }

