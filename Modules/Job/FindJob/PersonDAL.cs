using System;
using System.Collections.Generic;
using System.Text;
using CommonUtility.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace Modules.Job
{
    public class PersonDAL
    {
        public PersonDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SeekerId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_Job_Seeker");
            strSql.Append(" where SeekerId= @SeekerId");
            SqlParameter[] parameters = {
					new SqlParameter("@SeekerId", SqlDbType.Int,4)
				};
            parameters[0].Value = SeekerId;
            return SQLHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(PersonModel model, string postID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Job_Seeker(");
            strSql.Append("Name,Sex,Birthday,Diploma,Specialty,EnglishLevel,School,ID,City,Address,Email,Tel,WantedPay,SelfIntro,Experience,Skill,Polity,BPlace,Mobile,CheckTime,Height,Marry,GraduateTime,CertificateNo,RecordPlace,FamilyState,Request)");
            strSql.Append(" values (");
            strSql.Append("@Name,@Sex,@Birthday,@Diploma,@Specialty,@EnglishLevel,@School,@ID,@City,@Address,@Email,@Tel,@WantedPay,@SelfIntro,@Experience,@Skill,@Polity,@BPlace,@Mobile,@CheckTime,@Height,@Marry,@GraduateTime,@CertificateNo,@RecordPlace,@FamilyState,@Request);SELECT @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@Diploma", SqlDbType.VarChar,50),
					new SqlParameter("@Specialty", SqlDbType.VarChar,50),
					new SqlParameter("@EnglishLevel", SqlDbType.VarChar,50),
					new SqlParameter("@School", SqlDbType.VarChar,50),
					new SqlParameter("@ID", SqlDbType.VarChar,50),
					new SqlParameter("@City", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,100),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@Tel", SqlDbType.VarChar,50),
					new SqlParameter("@WantedPay", SqlDbType.VarChar,50),
					new SqlParameter("@SelfIntro", SqlDbType.Text),
					new SqlParameter("@Experience", SqlDbType.Text),
					new SqlParameter("@Skill", SqlDbType.VarChar,1000),
					new SqlParameter("@Polity", SqlDbType.VarChar,200),
					new SqlParameter("@BPlace", SqlDbType.VarChar,200),
					new SqlParameter("@Mobile", SqlDbType.VarChar,50),
					new SqlParameter("@CheckTime", SqlDbType.DateTime),
					new SqlParameter("@Height", SqlDbType.VarChar,50),
					new SqlParameter("@Marry", SqlDbType.Int,4),
					new SqlParameter("@GraduateTime", SqlDbType.VarChar,50),
					new SqlParameter("@CertificateNo", SqlDbType.VarChar,100),
					new SqlParameter("@RecordPlace", SqlDbType.VarChar,100),
					new SqlParameter("@FamilyState", SqlDbType.Text),
					new SqlParameter("@Request", SqlDbType.Text)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Sex;
            parameters[2].Value = model.Birthday;
            parameters[3].Value = model.Diploma;
            parameters[4].Value = model.Specialty;
            parameters[5].Value = model.EnglishLevel;
            parameters[6].Value = model.School;
            parameters[7].Value = model.ID;
            parameters[8].Value = model.City;
            parameters[9].Value = model.Address;
            parameters[10].Value = model.Email;
            parameters[11].Value = model.Tel;
            parameters[12].Value = model.WantedPay;
            parameters[13].Value = model.SelfIntro;
            parameters[14].Value = model.Experience;
            parameters[15].Value = model.Skill;
            parameters[16].Value = model.Polity;
            parameters[17].Value = model.BPlace;
            parameters[18].Value = model.Mobile;
            parameters[19].Value = model.CheckTime;
            parameters[20].Value = model.Height;
            parameters[21].Value = model.Marry;
            parameters[22].Value = model.GraduateTime;
            parameters[23].Value = model.CertificateNo;
            parameters[24].Value = model.RecordPlace;
            parameters[25].Value = model.FamilyState;
            parameters[26].Value = model.Request;

            //SQLHelper.ExecuteSql(strSql.ToString(), parameters);
            DataSet ds = SQLHelper.Query(strSql.ToString(), parameters);

            string newID = string.Empty;

            if (ds != null && ds.Tables.Count == 1 && ds.Tables[0].Rows.Count == 1)
            {
                newID = ds.Tables[0].Rows[0][0].ToString();
            }
            if (newID != string.Empty)
            {
                string newSQL = "INSERT INTO R_Job_SendOffer(PostId,SeekerId) VALUES(" + newID + "," + postID + ")";
                SQLHelper.ExecuteSql(newSQL);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(PersonModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Job_Seeker set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("Birthday=@Birthday,");
            strSql.Append("Diploma=@Diploma,");
            strSql.Append("Specialty=@Specialty,");
            strSql.Append("EnglishLevel=@EnglishLevel,");
            strSql.Append("School=@School,");
            strSql.Append("ID=@ID,");
            strSql.Append("City=@City,");
            strSql.Append("Address=@Address,");
            strSql.Append("Email=@Email,");
            strSql.Append("Tel=@Tel,");
            strSql.Append("WantedPay=@WantedPay,");
            strSql.Append("SelfIntro=@SelfIntro,");
            strSql.Append("Experience=@Experience,");
            strSql.Append("Skill=@Skill,");
            strSql.Append("Polity=@Polity,");
            strSql.Append("BPlace=@BPlace,");
            strSql.Append("Mobile=@Mobile,");
            strSql.Append("CheckTime=@CheckTime,");
            strSql.Append("Height=@Height,");
            strSql.Append("Marry=@Marry,");
            strSql.Append("GraduateTime=@GraduateTime,");
            strSql.Append("CertificateNo=@CertificateNo,");
            strSql.Append("RecordPlace=@RecordPlace,");
            strSql.Append("FamilyState=@FamilyState,");
            strSql.Append("Request=@Request");
            strSql.Append(" where SeekerId=@SeekerId");
            SqlParameter[] parameters = {
					new SqlParameter("@SeekerId", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@Diploma", SqlDbType.VarChar,50),
					new SqlParameter("@Specialty", SqlDbType.VarChar,50),
					new SqlParameter("@EnglishLevel", SqlDbType.VarChar,50),
					new SqlParameter("@School", SqlDbType.VarChar,50),
					new SqlParameter("@ID", SqlDbType.VarChar,50),
					new SqlParameter("@City", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,100),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@Tel", SqlDbType.VarChar,50),
					new SqlParameter("@WantedPay", SqlDbType.VarChar,50),
					new SqlParameter("@SelfIntro", SqlDbType.Text),
					new SqlParameter("@Experience", SqlDbType.Text),
					new SqlParameter("@Skill", SqlDbType.VarChar,1000),
					new SqlParameter("@Polity", SqlDbType.VarChar,200),
					new SqlParameter("@BPlace", SqlDbType.VarChar,200),
					new SqlParameter("@Mobile", SqlDbType.VarChar,50),
					new SqlParameter("@CheckTime", SqlDbType.DateTime),
					new SqlParameter("@Height", SqlDbType.VarChar,50),
					new SqlParameter("@Marry", SqlDbType.Int,4),
					new SqlParameter("@GraduateTime", SqlDbType.VarChar,50),
					new SqlParameter("@CertificateNo", SqlDbType.VarChar,100),
					new SqlParameter("@RecordPlace", SqlDbType.VarChar,100),
					new SqlParameter("@FamilyState", SqlDbType.Text),
					new SqlParameter("@Request", SqlDbType.Text)};
            parameters[0].Value = model.SeekerId;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Sex;
            parameters[3].Value = model.Birthday;
            parameters[4].Value = model.Diploma;
            parameters[5].Value = model.Specialty;
            parameters[6].Value = model.EnglishLevel;
            parameters[7].Value = model.School;
            parameters[8].Value = model.ID;
            parameters[9].Value = model.City;
            parameters[10].Value = model.Address;
            parameters[11].Value = model.Email;
            parameters[12].Value = model.Tel;
            parameters[13].Value = model.WantedPay;
            parameters[14].Value = model.SelfIntro;
            parameters[15].Value = model.Experience;
            parameters[16].Value = model.Skill;
            parameters[17].Value = model.Polity;
            parameters[18].Value = model.BPlace;
            parameters[19].Value = model.Mobile;
            parameters[20].Value = model.CheckTime;
            parameters[21].Value = model.Height;
            parameters[22].Value = model.Marry;
            parameters[23].Value = model.GraduateTime;
            parameters[24].Value = model.CertificateNo;
            parameters[25].Value = model.RecordPlace;
            parameters[26].Value = model.FamilyState;
            parameters[27].Value = model.Request;

            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int SeekerId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete T_Job_Seeker ");
            strSql.Append(" where SeekerId=@SeekerId");
            SqlParameter[] parameters = {
					new SqlParameter("@SeekerId", SqlDbType.Int,4)
				};
            parameters[0].Value = SeekerId;
            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PersonModel GetModel(int SeekerId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_Job_Seeker ");
            strSql.Append(" where SeekerId=@SeekerId");
            SqlParameter[] parameters = {
					new SqlParameter("@SeekerId", SqlDbType.Int,4)};
            parameters[0].Value = SeekerId;
            PersonModel model = new PersonModel();
            DataSet ds = SQLHelper.Query(strSql.ToString(), parameters);
            model.SeekerId = SeekerId;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                if (ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    model.Sex = int.Parse(ds.Tables[0].Rows[0]["Sex"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Birthday"].ToString() != "")
                {
                    model.Birthday = DateTime.Parse(ds.Tables[0].Rows[0]["Birthday"].ToString());
                }
                model.Diploma = ds.Tables[0].Rows[0]["Diploma"].ToString();
                model.Specialty = ds.Tables[0].Rows[0]["Specialty"].ToString();
                model.EnglishLevel = ds.Tables[0].Rows[0]["EnglishLevel"].ToString();
                model.School = ds.Tables[0].Rows[0]["School"].ToString();
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.City = ds.Tables[0].Rows[0]["City"].ToString();
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
                model.WantedPay = ds.Tables[0].Rows[0]["WantedPay"].ToString();
                model.SelfIntro = ds.Tables[0].Rows[0]["SelfIntro"].ToString();
                model.Experience = ds.Tables[0].Rows[0]["Experience"].ToString();
                model.Skill = ds.Tables[0].Rows[0]["Skill"].ToString();
                model.Polity = ds.Tables[0].Rows[0]["Polity"].ToString();
                model.BPlace = ds.Tables[0].Rows[0]["BPlace"].ToString();
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                if (ds.Tables[0].Rows[0]["CheckTime"].ToString() != "")
                {
                    model.CheckTime = DateTime.Parse(ds.Tables[0].Rows[0]["CheckTime"].ToString());
                }
                model.Height = ds.Tables[0].Rows[0]["Height"].ToString();
                if (ds.Tables[0].Rows[0]["Marry"].ToString() != "")
                {
                    model.Marry = int.Parse(ds.Tables[0].Rows[0]["Marry"].ToString());
                }
                model.GraduateTime = ds.Tables[0].Rows[0]["GraduateTime"].ToString();
                model.CertificateNo = ds.Tables[0].Rows[0]["CertificateNo"].ToString();
                model.RecordPlace = ds.Tables[0].Rows[0]["RecordPlace"].ToString();
                model.FamilyState = ds.Tables[0].Rows[0]["FamilyState"].ToString();
                model.Request = ds.Tables[0].Rows[0]["Request"].ToString();
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
            strSql.Append("select * from T_Job_Seeker ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by SeekerId ");
            return SQLHelper.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}
