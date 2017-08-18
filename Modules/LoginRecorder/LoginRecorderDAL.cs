using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CommonUtility.DBUtility;

namespace Modules.LoginRecorder
{
    public class LoginRecorderDAL
    {
        public LoginRecorderDAL()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_LoginRecorder");
            strSql.Append(" where ID= @ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
            parameters[0].Value = ID;
            return SQLHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public void Add(T_LoginRecorderModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_LoginRecorder(");
            strSql.Append("MemberID,LoginTimeLast,LoginTimeNow,LoginCount)");
            strSql.Append(" values (");
            strSql.Append("@MemberID,@LoginTimeLast,@LoginTimeNow,@LoginCount)");
            SqlParameter[] parameters = {
					new SqlParameter("@MemberID", SqlDbType.Int,4),
					new SqlParameter("@LoginTimeLast", SqlDbType.DateTime),
                    new SqlParameter("@LoginTimeNow", SqlDbType.DateTime),
					new SqlParameter("@LoginCount", SqlDbType.Int,4)};
            parameters[0].Value = model.MemberID;
            parameters[1].Value = model.LoginTimeLast;
            parameters[2].Value = model.LoginTimeNow;
            parameters[3].Value = model.LoginCount;

            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(T_LoginRecorderModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_LoginRecorder set ");
            strSql.Append("MemberID=@MemberID,");
            strSql.Append("LoginTimeLast=@LoginTimeLast,");
            strSql.Append("LoginTimeNow=@LoginTimeNow,");
            strSql.Append("LoginCount=@LoginCount");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@MemberID", SqlDbType.Int,4),
					new SqlParameter("@LoginTimeLast", SqlDbType.DateTime),
                    new SqlParameter("@LoginTimeNow", SqlDbType.DateTime),
					new SqlParameter("@LoginCount", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.MemberID;
            parameters[2].Value = model.LoginTimeLast;
            parameters[3].Value = model.LoginTimeNow;
            parameters[4].Value = model.LoginCount;

            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete T_LoginRecorder ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
            parameters[0].Value = ID;
            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public T_LoginRecorderModel GetModel(int MemberID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_LoginRecorder ");
            strSql.Append(" where MemberID=@MemberID");
            SqlParameter[] parameters = {
					new SqlParameter("@MemberID", SqlDbType.Int,4)};
            parameters[0].Value = MemberID;
            T_LoginRecorderModel model = new T_LoginRecorderModel();
            DataSet ds = SQLHelper.Query(strSql.ToString(), parameters);
            model.MemberID = MemberID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LoginTimeLast"].ToString() != "")
                {
                    model.LoginTimeLast = DateTime.Parse(ds.Tables[0].Rows[0]["LoginTimeLast"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LoginTimeNow"].ToString() != "")
                {
                    model.LoginTimeNow = DateTime.Parse(ds.Tables[0].Rows[0]["LoginTimeNow"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LoginCount"].ToString() != "")
                {
                    model.LoginCount = int.Parse(ds.Tables[0].Rows[0]["LoginCount"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_LoginRecorder ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID ");
            return SQLHelper.Query(strSql.ToString());
        }

        //���ݳ�Ա���ȡ�ó�Ա�û���
        public string GetNickName(int MemberId)
        {
            string sql = "select NickName from T_Member where MemberId=" + MemberId + "";
            return SQLHelper.GetSingle(sql).ToString();
        }
        #endregion  ��Ա����
    }
    #region T_LoginRecorderModel
    public class T_LoginRecorderModel
    {
        public T_LoginRecorderModel()
        { }
        #region Model
        private int _id;
        private int _memberid;
        private DateTime _logintimelast;
        private DateTime _logintimenow;
        private int _logincount;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// ��T_Member����
        /// </summary>
        public int MemberID
        {
            set { _memberid = value; }
            get { return _memberid; }
        }
        /// <summary>
        /// �û��ϴε�¼ʱ��
        /// </summary>
        public DateTime LoginTimeLast
        {
            set { _logintimelast = value; }
            get { return _logintimelast; }
        }
        /// <summary>
        /// �û����ε�¼ʱ��
        /// </summary>
        public DateTime LoginTimeNow
        {
            set { _logintimenow = value; }
            get { return _logintimenow; }
        }
        /// <summary>
        /// ��¼����
        /// </summary>
        public int LoginCount
        {
            set { _logincount = value; }
            get { return _logincount; }
        }
        #endregion Model
    }
    #endregion T_LoginRecorderModel
}
