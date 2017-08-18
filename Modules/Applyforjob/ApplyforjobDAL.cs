using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CommonUtility.DBUtility;

namespace Modules.Applyforjob
{
   public class ApplyforjobDAL
    {
       public ApplyforjobDAL()
       { }
       #region  ��Ա����
       /// <summary>
       /// �Ƿ���ڸü�¼
       /// </summary>
       public bool Exists(int UserID)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select count(1) from T_ApplyforJob");
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
       public void Add(T_ApplyforJobModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into T_ApplyforJob(");
           strSql.Append("UserID,JobType,JobName,WorkNow,CompanyTypeNow,CompanyType,WorkYear,WorkYearNow,Place,PlaceNow,PayBegin,PayEnd,CompanyNow,Other,WorkOntime,FillTime)");
           strSql.Append(" values (");
           strSql.Append("@UserID,@JobType,@JobName,@WorkNow,@CompanyTypeNow,@CompanyType,@WorkYear,@WorkYearNow,@Place,@PlaceNow,@PayBegin,@PayEnd,@CompanyNow,@Other,@WorkOntime,@FillTime)");
           SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@JobType", SqlDbType.Int,4),
					new SqlParameter("@JobName", SqlDbType.VarChar,200),
					new SqlParameter("@WorkNow", SqlDbType.VarChar,200),
					new SqlParameter("@CompanyTypeNow", SqlDbType.Int,4),
					new SqlParameter("@CompanyType", SqlDbType.Int,4),
					new SqlParameter("@WorkYear", SqlDbType.VarChar,200),
					new SqlParameter("@WorkYearNow", SqlDbType.VarChar,200),
					new SqlParameter("@Place", SqlDbType.VarChar,200),
					new SqlParameter("@PlaceNow", SqlDbType.VarChar,200),
					new SqlParameter("@PayBegin", SqlDbType.VarChar,200),
					new SqlParameter("@PayEnd", SqlDbType.VarChar,200),
					new SqlParameter("@CompanyNow", SqlDbType.VarChar,200),
					new SqlParameter("@Other", SqlDbType.VarChar,500),
					new SqlParameter("@WorkOntime", SqlDbType.Int,4),
					new SqlParameter("@FillTime", SqlDbType.DateTime)};
           parameters[0].Value = model.UserID;
           parameters[1].Value = model.JobType;
           parameters[2].Value = model.JobName;
           parameters[3].Value = model.WorkNow;
           parameters[4].Value = model.CompanyTypeNow;
           parameters[5].Value = model.CompanyType;
           parameters[6].Value = model.WorkYear;
           parameters[7].Value = model.WorkYearNow;
           parameters[8].Value = model.Place;
           parameters[9].Value = model.PlaceNow;
           parameters[10].Value = model.PayBegin;
           parameters[11].Value = model.PayEnd;
           parameters[12].Value = model.CompanyNow;
           parameters[13].Value = model.Other;
           parameters[14].Value = model.WorkOntime;
           parameters[15].Value = model.FillTime;

           SQLHelper.ExecuteSql(strSql.ToString(), parameters);
       }
       /// <summary>
       /// ����һ������
       /// </summary>
       public void Update(T_ApplyforJobModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update T_ApplyforJob set ");
           strSql.Append("UserID=@UserID,");
           strSql.Append("JobType=@JobType,");
           strSql.Append("JobName=@JobName,");
           strSql.Append("WorkNow=@WorkNow,");
           strSql.Append("CompanyTypeNow=@CompanyTypeNow,");
           strSql.Append("CompanyType=@CompanyType,");
           strSql.Append("WorkYear=@WorkYear,");
           strSql.Append("WorkYearNow=@WorkYearNow,");
           strSql.Append("Place=@Place,");
           strSql.Append("PlaceNow=@PlaceNow,");
           strSql.Append("PayBegin=@PayBegin,");
           strSql.Append("PayEnd=@PayEnd,");
           strSql.Append("CompanyNow=@CompanyNow,");
           strSql.Append("Other=@Other,");
           strSql.Append("WorkOntime=@WorkOntime,");
           strSql.Append("FillTime=@FillTime");
           strSql.Append(" where ID=@ID");
           SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@JobType", SqlDbType.Int,4),
					new SqlParameter("@JobName", SqlDbType.VarChar,200),
					new SqlParameter("@WorkNow", SqlDbType.VarChar,200),
					new SqlParameter("@CompanyTypeNow", SqlDbType.Int,4),
					new SqlParameter("@CompanyType", SqlDbType.Int,4),
					new SqlParameter("@WorkYear", SqlDbType.VarChar,200),
					new SqlParameter("@WorkYearNow", SqlDbType.VarChar,200),
					new SqlParameter("@Place", SqlDbType.VarChar,200),
					new SqlParameter("@PlaceNow", SqlDbType.VarChar,200),
					new SqlParameter("@PayBegin", SqlDbType.VarChar,200),
					new SqlParameter("@PayEnd", SqlDbType.VarChar,200),
					new SqlParameter("@CompanyNow", SqlDbType.VarChar,200),
					new SqlParameter("@Other", SqlDbType.VarChar,500),
					new SqlParameter("@WorkOntime", SqlDbType.Int,4),
					new SqlParameter("@FillTime", SqlDbType.DateTime)};
           parameters[0].Value = model.ID;
           parameters[1].Value = model.UserID;
           parameters[2].Value = model.JobType;
           parameters[3].Value = model.JobName;
           parameters[4].Value = model.WorkNow;
           parameters[5].Value = model.CompanyTypeNow;
           parameters[6].Value = model.CompanyType;
           parameters[7].Value = model.WorkYear;
           parameters[8].Value = model.WorkYearNow;
           parameters[9].Value = model.Place;
           parameters[10].Value = model.PlaceNow;
           parameters[11].Value = model.PayBegin;
           parameters[12].Value = model.PayEnd;
           parameters[13].Value = model.CompanyNow;
           parameters[14].Value = model.Other;
           parameters[15].Value = model.WorkOntime;
           parameters[16].Value = model.FillTime;

           SQLHelper.ExecuteSql(strSql.ToString(), parameters);
       }

       /// <summary>
       /// ɾ��һ������
       /// </summary>
       public void Delete(int UserID)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete T_ApplyforJob ");
           strSql.Append(" where UserID=@UserID");
           SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
				};
           parameters[0].Value = UserID;
           SQLHelper.ExecuteSql(strSql.ToString(), parameters);
       }


       /// <summary>
       /// �õ�һ������ʵ��
       /// </summary>
       public T_ApplyforJobModel GetModel(int UserID)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select * from T_ApplyforJob ");
           strSql.Append(" where UserID=@UserID");
           SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
           parameters[0].Value = UserID;
           T_ApplyforJobModel model = new T_ApplyforJobModel();
           DataSet ds = SQLHelper.Query(strSql.ToString(), parameters);
           model.UserID = UserID;
           if (ds.Tables[0].Rows.Count > 0)
           {
               if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
               {
                   model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
               }
               model.JobType =int.Parse(ds.Tables[0].Rows[0]["JobType"].ToString());
               model.JobName = ds.Tables[0].Rows[0]["JobName"].ToString();
               model.WorkNow = ds.Tables[0].Rows[0]["WorkNow"].ToString();
               model.CompanyTypeNow =int.Parse(ds.Tables[0].Rows[0]["CompanyTypeNow"].ToString());
               model.CompanyType = int.Parse(ds.Tables[0].Rows[0]["CompanyType"].ToString());
               model.WorkYear = ds.Tables[0].Rows[0]["WorkYear"].ToString();
               model.WorkYearNow = ds.Tables[0].Rows[0]["WorkYearNow"].ToString();
               model.Place = ds.Tables[0].Rows[0]["Place"].ToString();
               model.PlaceNow = ds.Tables[0].Rows[0]["PlaceNow"].ToString();
               model.PayBegin = ds.Tables[0].Rows[0]["PayBegin"].ToString();
               model.PayEnd = ds.Tables[0].Rows[0]["PayEnd"].ToString();
               model.CompanyNow = ds.Tables[0].Rows[0]["CompanyNow"].ToString();
               model.Other = ds.Tables[0].Rows[0]["Other"].ToString();
               model.WorkOntime =int.Parse(ds.Tables[0].Rows[0]["WorkOntime"].ToString());
               if (ds.Tables[0].Rows[0]["FillTime"].ToString() != "")
               {
                   model.FillTime = DateTime.Parse(ds.Tables[0].Rows[0]["FillTime"].ToString());
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
           strSql.Append("select * from T_ApplyforJob ");
           if (strWhere.Trim() != "")
           {
               strSql.Append(" where " + strWhere);
           }
           strSql.Append(" order by ID ");
           return SQLHelper.Query(strSql.ToString());
       }

       //��ø�����ְ��Ϣ(������ְ�������ְ����)
       public DataSet GetPersonalView(int memberId)
       {
           string sql = "select * from V_Personal_View where MemberId=" + memberId + "";
           return SQLHelper.Query(sql);
       }

        /// <summary>
        /// ȡ�ø��˻�ԱӦƸ��Ϣ�б�
        /// </summary>
       public DataSet GetYPList(string strWhere)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select * from V_YPList ");
           if (strWhere.Trim() != "")
           {
               strSql.Append(" where " + strWhere);
           }
           strSql.Append(" order by SendDate desc ");
           return SQLHelper.Query(strSql.ToString());
       }

       /// <summary>
       /// ȡ�ø��˻�ԱӦƸ��Ϣ
       /// </summary>
       public DataSet GetYPInfo(int YPId)
       {
           string sql = "select * from V_YPList where SendOfferId=" + YPId + "";
           return SQLHelper.Query(sql);
       }
        /// <summary>
        /// ɾ�����˻�ԱӦƸ��Ϣ(��ҵ�û�ɾ��)
        /// </summary>
       public void DeleteYPInfo(int SenderOfferId)
       {
           string sql = "delete from R_Job_SendOffer where SendOfferId=" + SenderOfferId + "";
           SQLHelper.ExecuteSql(sql);
       }
       /// <summary>
       /// ɾ�����˻�ԱӦƸ��Ϣ(�����û�ɾ��)
       /// </summary>
       public void DeleteYPInfo1(int CollectId)
       {
           string sql = "delete from R_Job_Collect where CollectId=" + CollectId + "";
           SQLHelper.ExecuteSql(sql);
       }
       /// <summary>
       /// ��ø��˻�ԱӦƸ״̬(�Ƿ���������)
       /// </summary>
       public int GetState(int YPId)
       {
           string sql = "select Approved from R_Job_SendOffer where SendOfferId=" + YPId + "";
           return Int32.Parse(SQLHelper.GetSingle(sql).ToString());
       }

       /// <summary>
       /// ����ӦƸ��Ա����(�ı�Approved1״̬Ϊ1)
       /// </summary>
       public void ChangeApprovedStatus(int OfferId, int status)
       {
           string sql = string.Empty;
           if (status == 0)
           {
               sql = "update R_Job_SendOffer set Approved=1 where SendOfferId=" + OfferId + "";
           }
           else
           {
               sql = "update R_Job_SendOffer set Approved=0 where SendOfferId=" + OfferId + "";
           }
           SQLHelper.ExecuteSql(sql);
       }

       //�õ���ҳ��ְ��Ϣ�б� ȡǰN��
       public DataSet GetIndexQZList(int Num)
       {
           string sql = "select top " + Num + " * from V_Personal_View where RApproved=1 order by ApplyFillTime desc";
           return SQLHelper.Query(sql);
       }

       //�õ���ҳ��Ƹ��Ϣ�б�ĵ�λ����(ȥ���ظ�) ȡǰN��
       //"select top " + Num + "  CompanyName,ID,UserId  from V_ZPInfo a where  exists (select distinct CompanyName,ID,UserId from V_ZPInfo b where a.ID=b.ID and a.Approved=1) order by AddedDate desc";
       public DataSet GetIndexYPList(int Num)
       {
           string sql = "select top " + Num + " UserId,CompanyName,ID,max(AddedDate) as AddDate from V_ZPInfo  where Approved=1 and Tj1=1 group by [id],companyName,UserId  order by max(AddedDate)  desc"; 
           return SQLHelper.Query(sql);
       }


       //08�Ƽ�
       public DataSet GetYPList1(int Num)
       {
           string sql = "select top " + Num + " UserId,CompanyName,ID,max(AddedDate) as AddDate from V_ZPInfo  where Approved=1 and Tj2=1 group by [id],companyName,UserId  order by max(AddedDate)  desc";
           return SQLHelper.Query(sql);
       }


       //������Ƹ��Ϣ��ID���ȡ�ø�λ��Ϣ
       public DataSet GetGwNameByID(int Id)
       {
           string sql = "select top 3 * from V_ZPInfo where ID=" + Id + " order by AddedDate desc";
           return SQLHelper.Query(sql);
       }
       public DataSet GetGwNameByID1(int Id)
       {
           string sql = "select top 1 * from V_ZPInfo where ID=" + Id + " order by AddedDate desc";
           return SQLHelper.Query(sql);
       }
       #endregion  ��Ա����
       #region �õ���ְ��ԱӦƸ��Ϣ(����:��ְ�������ְ����)�б�
       public DataSet GetPersonInfoList(string strWhere)
       {
           string sql = "select * from V_Personal_View ";
           if (strWhere != "")
           {
               sql += "where " + strWhere;
           }
           sql+=" order by MemberId asc";
           return SQLHelper.Query(sql);
       }
       #endregion

       #region ���ݻ�Ա��ŵõ�������ְ��Ա��ϸ��Ϣ(����:��ְ�������ְ����)
       public DataSet GetOnePersonInfo(int MemberId)
       {
           string sql = "select  * from V_Personal_View where MemberId="+MemberId+"";
           return SQLHelper.Query(sql);
       }
       #endregion
   }

    #region T_ApplyforJobModel
    public class T_ApplyforJobModel
    {
        public T_ApplyforJobModel()
       { }
        #region Model
        private int _id;
        private int _userid;
        private int _jobtype;
        private string _jobname;
        private string _worknow;
        private int _companytypenow;
        private int _companytype;
        private string _workyear;
        private string _workyearnow;
        private string _place;
        private string _placenow;
        private string _paybegin;
        private string _payend;
        private string _companynow;
        private string _other;
        private int _workontime;
        private DateTime _filltime;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// �û���ź�T_Member�е�ID�ֶι���
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// ��ӦƸ��������
        /// </summary>
        public int JobType
        {
            set { _jobtype = value; }
            get { return _jobtype; }
        }
        /// <summary>
        /// ��ӦƸְλ
        /// </summary>
        public string JobName
        {
            set { _jobname = value; }
            get { return _jobname; }
        }
        /// <summary>
        /// ��ְҵ
        /// </summary>
        public string WorkNow
        {
            set { _worknow = value; }
            get { return _worknow; }
        }
        /// <summary>
        /// ������λ����
        /// </summary>
        public int CompanyTypeNow
        {
            set { _companytypenow = value; }
            get { return _companytypenow; }
        }
        /// <summary>
        /// ӦƸ��λ����
        /// </summary>
        public int CompanyType
        {
            set { _companytype = value; }
            get { return _companytype; }
        }
        /// <summary>
        /// �μӹ���ʱ��
        /// </summary>
        public string WorkYear
        {
            set { _workyear = value; }
            get { return _workyear; }
        }
        /// <summary>
        /// �����ֹ���ʱ��
        /// </summary>
        public string WorkYearNow
        {
            set { _workyearnow = value; }
            get { return _workyearnow; }
        }
        /// <summary>
        /// Ҫ��������
        /// </summary>
        public string Place
        {
            set { _place = value; }
            get { return _place; }
        }
        /// <summary>
        /// �ֹ�������
        /// </summary>
        public string PlaceNow
        {
            set { _placenow = value; }
            get { return _placenow; }
        }
        /// <summary>
        /// ����Ҫ��(ʼ)
        /// </summary>
        public string PayBegin
        {
            set { _paybegin = value; }
            get { return _paybegin; }
        }
        /// <summary>
        /// ����Ҫ��(��)
        /// </summary>
        public string PayEnd
        {
            set { _payend = value; }
            get { return _payend; }
        }
        /// <summary>
        /// �ֹ�����λ
        /// </summary>
        public string CompanyNow
        {
            set { _companynow = value; }
            get { return _companynow; }
        }
        /// <summary>
        /// ����Ҫ��
        /// </summary>
        public string Other
        {
            set { _other = value; }
            get { return _other; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public int WorkOntime
        {
            set { _workontime = value; }
            get { return _workontime; }
        }
        /// <summary>
        /// ��дʱ��
        /// </summary>
        public DateTime FillTime
        {
            set { _filltime = value; }
            get { return _filltime; }
        }
        #endregion Model

    }
    #endregion
}
