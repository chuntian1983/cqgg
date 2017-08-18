using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;
using System.Data;

namespace Modules.Account
{
    public class CustomIdentity :IIdentity
    {
        //private string _nickname;
        //private string _password;
        private int _userId;

        // IIdentity interface requirments:
        // property AuthenticationType (string)
        // property IsAuthenticated (bool)
        // propertty Name (string)

        public string AuthenticationType
        {
            get
            {
                return "Custom Authentication";
            }
            set
            {
                // do nothing
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                // assumption: all instances of a SiteIdentity have already
                // been authenticated.
                return true;
            }
        }

        public string Name
        {
            get
            {
                return this._userId.ToString();
            }
        }

        // Constructors:

        //public CustomIdentity(string nickname)
        //{
        //    UserDAL dataUser = new UserDAL();
        //    DataRow userRow = dataUser.Retrieve(nickname);
        //    if (userRow != null)
        //    {
        //        this._nickname = userRow["Nickname"].ToString();
        //        this._password = userRow["Password"].ToString();
        //        this._userId = (int)userRow["UserId"];
        //    }
        //}

        public CustomIdentity(int userId)
        {
            //UserDAL dataUser = new UserDAL();
            //DataRow userRow = dataUser.Retrieve(userId);
            //if (userRow != null)
            //{
            //    this._nickname = userRow["Nickname"].ToString();
            //    this._password = userRow["Password"].ToString();
            //    this._userId = (int)userRow["UserId"];
            //}
            this._userId = userId;
        }

        //public string Nickname
        //{
        //    get { return this._nickname; }
        //}

        public int UserID
        {
            get
            {
                return this._userId;
            }
        }

        //public string Password
        //{
        //    get
        //    {
        //        return this._password;
        //    }
        //}
    }
}
