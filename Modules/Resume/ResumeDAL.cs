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
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
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
        /// 增加一条数据
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
        /// 更新一条数据
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
        /// 删除一条数据
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
        /// 得到一个对象实体(全部)
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

        //根据个人会员编号取得会员详细简历(包括求职意向和个人简历以及会员个人信息)
        public DataSet GetAllResumeByID(int UserId)
        {
            string sql = "select * from V_GRResume where UserID='"+UserId+"'";
            return SQLHelper.Query(sql);
        }


        /// <summary>
        /// 得到一个对象实体(已审核的)
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
        /// 获得数据列表
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


        //改变审核状态
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

        #endregion  成员方法
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
        /// 用户编号和T_Member中的ID关联
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 培训经历
        /// </summary>
        public string TrainInfo
        {
            set { _traininfo = value; }
            get { return _traininfo; }
        }
        /// <summary>
        /// 工作经历
        /// </summary>
        public string WorkInfo
        {
            set { _workinfo = value; }
            get { return _workinfo; }
        }
        /// <summary>
        /// 专业技能
        /// </summary>
        public string SpecialSkill
        {
            set { _specialskill = value; }
            get { return _specialskill; }
        }
        /// <summary>
        /// 工作业绩
        /// </summary>
        public string WorkResult
        {
            set { _workresult = value; }
            get { return _workresult; }
        }
        /// <summary>
        /// 自我评价
        /// </summary>
        public string PersonAssess
        {
            set { _personassess = value; }
            get { return _personassess; }
        }
        /// <summary>
        ///  特长
        /// </summary>
        public string Prefer
        {
            set { _prefer = value; }
            get { return _prefer; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Plus
        {
            set { _plus = value; }
            get { return _plus; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime FillTime
        {
            set { _filltime = value; }
            get { return _filltime; }
        }
        /// <summary>
        /// 审核状态
        /// </summary>
        public int Approved
        {
            set { _approved = value; }
            get { return _approved; }
        }
        /// <summary>
        /// 简历刷新时间
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
