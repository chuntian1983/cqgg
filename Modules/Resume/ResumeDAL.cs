using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CommonUtility.DBUtility;

namespace Modules.Resume
{
    public class ResumeDAL
    {
        public ResumeDAL()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_Resume");
            strSql.Append(" where UserID= @UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
				};
            parameters[0].Value = UserID;
            return SQLHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public void Add(T_ResumeModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Resume(");
            strSql.Append("UserID,TrainInfo,WorkInfo,SpecialSkill,WorkResult,PersonAssess,Prefer,Plus,FillTime,Approved,ChangeTime)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@TrainInfo,@WorkInfo,@SpecialSkill,@WorkResult,@PersonAssess,@Prefer,@Plus,@FillTime,@Approved,@ChangeTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@TrainInfo", SqlDbType.Text),
					new SqlParameter("@WorkInfo", SqlDbType.Text),
					new SqlParameter("@SpecialSkill", SqlDbType.Text),
					new SqlParameter("@WorkResult", SqlDbType.Text),
					new SqlParameter("@PersonAssess", SqlDbType.Text),
					new SqlParameter("@Prefer", SqlDbType.Text),
					new SqlParameter("@Plus", SqlDbType.Text),
					new SqlParameter("@FillTime", SqlDbType.DateTime),
					new SqlParameter("@Approved", SqlDbType.Int,4),
                    new SqlParameter("@ChangeTime", SqlDbType.DateTime)
            };
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.TrainInfo;
            parameters[2].Value = model.WorkInfo;
            parameters[3].Value = model.SpecialSkill;
            parameters[4].Value = model.WorkResult;
            parameters[5].Value = model.PersonAssess;
            parameters[6].Value = model.Prefer;
            parameters[7].Value = model.Plus;
            parameters[8].Value = model.FillTime;
            parameters[9].Value = model.Approved;
            parameters[10].Value = model.ChangeTime;

            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(T_ResumeModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Resume set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("TrainInfo=@TrainInfo,");
            strSql.Append("WorkInfo=@WorkInfo,");
            strSql.Append("SpecialSkill=@SpecialSkill,");
            strSql.Append("WorkResult=@WorkResult,");
            strSql.Append("PersonAssess=@PersonAssess,");
            strSql.Append("Prefer=@Prefer,");
            strSql.Append("Plus=@Plus,");
            strSql.Append("FillTime=@FillTime,");
            strSql.Append("Approved=@Approved,");
            strSql.Append("ChangeTime=@ChangeTime");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@TrainInfo", SqlDbType.Text),
					new SqlParameter("@WorkInfo", SqlDbType.Text),
					new SqlParameter("@SpecialSkill", SqlDbType.Text),
					new SqlParameter("@WorkResult", SqlDbType.Text),
					new SqlParameter("@PersonAssess", SqlDbType.Text),
					new SqlParameter("@Prefer", SqlDbType.Text),
					new SqlParameter("@Plus", SqlDbType.Text),
					new SqlParameter("@FillTime", SqlDbType.DateTime),
					new SqlParameter("@Approved", SqlDbType.Int,4),
                    new SqlParameter("@ChangeTime", SqlDbType.DateTime)
            };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.TrainInfo;
            parameters[3].Value = model.WorkInfo;
            parameters[4].Value = model.SpecialSkill;
            parameters[5].Value = model.WorkResult;
            parameters[6].Value = model.PersonAssess;
            parameters[7].Value = model.Prefer;
            parameters[8].Value = model.Plus;
            parameters[9].Value = model.FillTime;
            parameters[10].Value = model.Approved;
            parameters[11].Value = model.ChangeTime;

            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete T_Resume ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
				};
            parameters[0].Value = UserID;
            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// �õ�һ������ʵ��(ȫ��)
        /// </summary>
        public T_ResumeModel GetModel(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_Resume ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = UserID;
            T_ResumeModel model = new T_ResumeModel();
            DataSet ds = SQLHelper.Query(strSql.ToString(), parameters);
            model.UserID = UserID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.TrainInfo = ds.Tables[0].Rows[0]["TrainInfo"].ToString();
                model.WorkInfo = ds.Tables[0].Rows[0]["WorkInfo"].ToString();
                model.SpecialSkill = ds.Tables[0].Rows[0]["SpecialSkill"].ToString();
                model.WorkResult = ds.Tables[0].Rows[0]["WorkResult"].ToString();
                model.PersonAssess = ds.Tables[0].Rows[0]["PersonAssess"].ToString();
                model.Prefer = ds.Tables[0].Rows[0]["Prefer"].ToString();
                model.Plus = ds.Tables[0].Rows[0]["Plus"].ToString();
                if (ds.Tables[0].Rows[0]["FillTime"].ToString() != "")
                {
                    model.FillTime = DateTime.Parse(ds.Tables[0].Rows[0]["FillTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Approved"].ToString() != "")
                {
                    model.Approved = int.Parse(ds.Tables[0].Rows[0]["Approved"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ChangeTime"].ToString() != "")
                {
                    model.ChangeTime = DateTime.Parse(ds.Tables[0].Rows[0]["ChangeTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        //���ݸ��˻�Ա���ȡ�û�Ա��ϸ����(������ְ����͸��˼����Լ���Ա������Ϣ)
        public DataSet GetAllResumeByID(int UserId)
        {
            string sql = "select * from V_GRResume where UserID='"+UserId+"'";
            return SQLHelper.Query(sql);
        }


        /// <summary>
        /// �õ�һ������ʵ��(����˵�)
        /// </summary>
        public T_ResumeModel GetModel1(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_Resume ");
            strSql.Append(" where UserID=@UserID");
            //strSql.Append(" and Approved=1");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = UserID;
            T_ResumeModel model = new T_ResumeModel();
            DataSet ds = SQLHelper.Query(strSql.ToString(), parameters);
            model.UserID = UserID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.TrainInfo = ds.Tables[0].Rows[0]["TrainInfo"].ToString();
                model.WorkInfo = ds.Tables[0].Rows[0]["WorkInfo"].ToString();
                model.SpecialSkill = ds.Tables[0].Rows[0]["SpecialSkill"].ToString();
                model.WorkResult = ds.Tables[0].Rows[0]["WorkResult"].ToString();
                model.PersonAssess = ds.Tables[0].Rows[0]["PersonAssess"].ToString();
                model.Prefer = ds.Tables[0].Rows[0]["Prefer"].ToString();
                model.Plus = ds.Tables[0].Rows[0]["Plus"].ToString();
                if (ds.Tables[0].Rows[0]["FillTime"].ToString() != "")
                {
                    model.FillTime = DateTime.Parse(ds.Tables[0].Rows[0]["FillTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Approved"].ToString() != "")
                {
                    model.Approved = int.Parse(ds.Tables[0].Rows[0]["Approved"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ChangeTime"].ToString() != "")
                {
                    model.ChangeTime = DateTime.Parse(ds.Tables[0].Rows[0]["ChangeTime"].ToString());
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
            strSql.Append("select * from T_Resume ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID ");
            return SQLHelper.Query(strSql.ToString());
        }


        //�ı����״̬
        public void ApproveUserResume(int userId, bool isApproved)
        {
            string sql = String.Format("update T_Resume set Approved={0} where UserID={1}", isApproved ? 1 : 0, userId);
            SQLHelper.ExecuteSql(sql);
        }

        public int GetTotalResumeNum()
        {
            string sql = "select count(*) from V_GRResume";
            return Convert.ToInt32(SQLHelper.GetSingle(sql));
        }

        public int GetWeeklyResumeNum()
        {
            string sql = "select count(*) from V_GRResume where year(changetime)=year(getdate())  and datepart(week,changetime)=datepart(week,getdate())";
            return Convert.ToInt32(SQLHelper.GetSingle(sql));
        }

        #endregion  ��Ա����
    }
    #region T_ResumeModel
    public class T_ResumeModel
    {
        public T_ResumeModel()
        { }
        #region Model
        private int _id;
        private int _userid;
        private string _traininfo;
        private string _workinfo;
        private string _specialskill;
        private string _workresult;
        private string _personassess;
        private string _prefer;
        private string _plus;
        private DateTime _filltime;
        private int _approved;
        private DateTime _changetime;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// �û���ź�T_Member�е�ID����
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// ��ѵ����
        /// </summary>
        public string TrainInfo
        {
            set { _traininfo = value; }
            get { return _traininfo; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string WorkInfo
        {
            set { _workinfo = value; }
            get { return _workinfo; }
        }
        /// <summary>
        /// רҵ����
        /// </summary>
        public string SpecialSkill
        {
            set { _specialskill = value; }
            get { return _specialskill; }
        }
        /// <summary>
        /// ����ҵ��
        /// </summary>
        public string WorkResult
        {
            set { _workresult = value; }
            get { return _workresult; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string PersonAssess
        {
            set { _personassess = value; }
            get { return _personassess; }
        }
        /// <summary>
        ///  �س�
        /// </summary>
        public string Prefer
        {
            set { _prefer = value; }
            get { return _prefer; }
        }
        /// <summary>
        /// ��ע
        /// </summary>
        public string Plus
        {
            set { _plus = value; }
            get { return _plus; }
        }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime FillTime
        {
            set { _filltime = value; }
            get { return _filltime; }
        }
        /// <summary>
        /// ���״̬
        /// </summary>
        public int Approved
        {
            set { _approved = value; }
            get { return _approved; }
        }
        /// <summary>
        /// ����ˢ��ʱ��
        /// </summary>
        public DateTime ChangeTime
        {
            set { _changetime = value; }
            get { return _changetime; }
        }
        #endregion Model
    }

    #endregion
}
