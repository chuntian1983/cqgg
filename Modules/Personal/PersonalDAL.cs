using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CommonUtility.DBUtility;

namespace Modules.Personal
{
    public class PersonalDAL
    {
        public PersonalDAL()
        {}
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_PersonalInfo");
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
        public void Add(T_PersonalModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_PersonalInfo(");
            strSql.Append("UserID,UserName,Sex,Birthday,PaperType,PaperNO,Political,Marry,School,GraduateTime,Levels,Speciality,Height,Weight,Home,Place,Contact,Post,Tel,Linkman,Email,Img)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@UserName,@Sex,@Birthday,@PaperType,@PaperNO,@Political,@Marry,@School,@GraduateTime,@Levels,@Speciality,@Height,@Weight,@Home,@Place,@Contact,@Post,@Tel,@Linkman,@Email,@Img)");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@PaperType", SqlDbType.Int,4),
					new SqlParameter("@PaperNO", SqlDbType.VarChar,200),
					new SqlParameter("@Political", SqlDbType.Int,4),
					new SqlParameter("@Marry", SqlDbType.Int,4),
					new SqlParameter("@School", SqlDbType.VarChar,200),
					new SqlParameter("@GraduateTime", SqlDbType.VarChar,200),
					new SqlParameter("@Levels", SqlDbType.Int,4),
					new SqlParameter("@Speciality", SqlDbType.VarChar,200),
					new SqlParameter("@Height", SqlDbType.VarChar,50),
					new SqlParameter("@Weight", SqlDbType.VarChar,50),
					new SqlParameter("@Home", SqlDbType.VarChar,200),
					new SqlParameter("@Place", SqlDbType.VarChar,200),
					new SqlParameter("@Contact", SqlDbType.VarChar,200),
					new SqlParameter("@Post", SqlDbType.VarChar,50),
					new SqlParameter("@Tel", SqlDbType.VarChar,200),
					new SqlParameter("@Linkman", SqlDbType.VarChar,200),
					new SqlParameter("@Email", SqlDbType.VarChar,200),
                    new SqlParameter("@Img", SqlDbType.VarChar,200)
            };
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.Sex;
            parameters[3].Value = model.Birthday;
            parameters[4].Value = model.PaperType;
            parameters[5].Value = model.PaperNO;
            parameters[6].Value = model.Political;
            parameters[7].Value = model.Marry;
            parameters[8].Value = model.School;
            parameters[9].Value = model.GraduateTime;
            parameters[10].Value = model.Levels;
            parameters[11].Value = model.Speciality;
            parameters[12].Value = model.Height;
            parameters[13].Value = model.Weight;
            parameters[14].Value = model.Home;
            parameters[15].Value = model.Place;
            parameters[16].Value = model.Contact;
            parameters[17].Value = model.Post;
            parameters[18].Value = model.Tel;
            parameters[19].Value = model.Linkman;
            parameters[20].Value = model.Email;
            parameters[21].Value = model.Img;

            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(T_PersonalModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_PersonalInfo set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("Birthday=@Birthday,");
            strSql.Append("PaperType=@PaperType,");
            strSql.Append("PaperNO=@PaperNO,");
            strSql.Append("Political=@Political,");
            strSql.Append("Marry=@Marry,");
            strSql.Append("School=@School,");
            strSql.Append("GraduateTime=@GraduateTime,");
            strSql.Append("Levels=@Levels,");
            strSql.Append("Speciality=@Speciality,");
            strSql.Append("Height=@Height,");
            strSql.Append("Weight=@Weight,");
            strSql.Append("Home=@Home,");
            strSql.Append("Place=@Place,");
            strSql.Append("Contact=@Contact,");
            strSql.Append("Post=@Post,");
            strSql.Append("Tel=@Tel,");
            strSql.Append("Linkman=@Linkman,");
            strSql.Append("Email=@Email,");
            strSql.Append("Img=@Img");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@PaperType", SqlDbType.Int,4),
					new SqlParameter("@PaperNO", SqlDbType.VarChar,200),
					new SqlParameter("@Political", SqlDbType.Int,4),
					new SqlParameter("@Marry", SqlDbType.Int,4),
					new SqlParameter("@School", SqlDbType.VarChar,200),
					new SqlParameter("@GraduateTime", SqlDbType.VarChar,200),
					new SqlParameter("@Levels", SqlDbType.Int,4),
					new SqlParameter("@Speciality", SqlDbType.VarChar,200),
					new SqlParameter("@Height", SqlDbType.VarChar,50),
					new SqlParameter("@Weight", SqlDbType.VarChar,50),
					new SqlParameter("@Home", SqlDbType.VarChar,200),
					new SqlParameter("@Place", SqlDbType.VarChar,200),
					new SqlParameter("@Contact", SqlDbType.VarChar,200),
					new SqlParameter("@Post", SqlDbType.VarChar,50),
					new SqlParameter("@Tel", SqlDbType.VarChar,200),
					new SqlParameter("@Linkman", SqlDbType.VarChar,200),
					new SqlParameter("@Email", SqlDbType.VarChar,200),
                    new SqlParameter("@Img", SqlDbType.VarChar,200)
            };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.Birthday;
            parameters[5].Value = model.PaperType;
            parameters[6].Value = model.PaperNO;
            parameters[7].Value = model.Political;
            parameters[8].Value = model.Marry;
            parameters[9].Value = model.School;
            parameters[10].Value = model.GraduateTime;
            parameters[11].Value = model.Levels;
            parameters[12].Value = model.Speciality;
            parameters[13].Value = model.Height;
            parameters[14].Value = model.Weight;
            parameters[15].Value = model.Home;
            parameters[16].Value = model.Place;
            parameters[17].Value = model.Contact;
            parameters[18].Value = model.Post;
            parameters[19].Value = model.Tel;
            parameters[20].Value = model.Linkman;
            parameters[21].Value = model.Email;
            parameters[22].Value = model.Img;


            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete T_PersonalInfo ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
            parameters[0].Value = ID;
            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public T_PersonalModel GetModel(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_PersonalInfo ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = UserID;
            T_PersonalModel model = new T_PersonalModel();
            DataSet ds = SQLHelper.Query(strSql.ToString(), parameters);
            model.ID = UserID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                if (ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    model.Sex = int.Parse(ds.Tables[0].Rows[0]["Sex"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Birthday"].ToString() != "")
                {
                    model.Birthday = DateTime.Parse(ds.Tables[0].Rows[0]["Birthday"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PaperType"].ToString() != "")
                {
                    model.PaperType = int.Parse(ds.Tables[0].Rows[0]["PaperType"].ToString());
                }
                model.PaperNO = ds.Tables[0].Rows[0]["PaperNO"].ToString();
                if (ds.Tables[0].Rows[0]["Political"].ToString() != "")
                {
                    model.Political = int.Parse(ds.Tables[0].Rows[0]["Political"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Marry"].ToString() != "")
                {
                    model.Marry = int.Parse(ds.Tables[0].Rows[0]["Marry"].ToString());
                }
                model.School = ds.Tables[0].Rows[0]["School"].ToString();
                model.GraduateTime = ds.Tables[0].Rows[0]["GraduateTime"].ToString();
                if (ds.Tables[0].Rows[0]["Levels"].ToString() != "")
                {
                    model.Levels = int.Parse(ds.Tables[0].Rows[0]["Levels"].ToString());
                }
                model.Speciality = ds.Tables[0].Rows[0]["Speciality"].ToString();
                model.Height = ds.Tables[0].Rows[0]["Height"].ToString();
                model.Weight = ds.Tables[0].Rows[0]["Weight"].ToString();
                model.Home = ds.Tables[0].Rows[0]["Home"].ToString();
                model.Place = ds.Tables[0].Rows[0]["Place"].ToString();
                model.Contact = ds.Tables[0].Rows[0]["Contact"].ToString();
                model.Post = ds.Tables[0].Rows[0]["Post"].ToString();
                model.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
                model.Linkman = ds.Tables[0].Rows[0]["Linkman"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.Img = ds.Tables[0].Rows[0]["Img"].ToString();
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
            strSql.Append("select * from T_PersonalInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID ");
            return SQLHelper.Query(strSql.ToString());
        }

        //上传个人照片
        public void UpdatePic(int UserId,string Src)
        {
            string sql = "Update T_PersonalInfo set Img='" + Src + "' where UserId=" + UserId + "";
            SQLHelper.ExecuteSql(sql);
        }

        //获得个人照片
        public string GetPic(int UserId)
        {
            string sql = "select Img from T_PersonalInfo where UserId='" + UserId + "'";
            return SQLHelper.GetSingle(sql).ToString();
        }
        #endregion  成员方法

    }
    #region T_PersonalModel
    public class T_PersonalModel
    {
        public T_PersonalModel()
        { }
        #region Model
        private int _id;
        private int _userid;
        private string _username;
        private int _sex;
        private DateTime _birthday;
        private int _papertype;
        private string _paperno;
        private int _political;
        private int _marry;
        private string _school;
        private string _graduatetime;
        private int _levels;
        private string _speciality;
        private string _height;
        private string _weight;
        private string _home;
        private string _place;
        private string _contact;
        private string _post;
        private string _tel;
        private string _linkman;
        private string _email;
        private string _img;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 和T_Member中的ID关联
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 0:男 1:女
        /// </summary>
        public int Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 出生年月
        /// </summary>
        public DateTime Birthday
        {
            set { _birthday = value; }
            get { return _birthday; }
        }
        /// <summary>
        /// 证件类型
        /// </summary>
        public int PaperType
        {
            set { _papertype = value; }
            get { return _papertype; }
        }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string PaperNO
        {
            set { _paperno = value; }
            get { return _paperno; }
        }
        /// <summary>
        /// 政治面貌
        /// </summary>
        public int Political
        {
            set { _political = value; }
            get { return _political; }
        }
        /// <summary>
        /// 婚姻状况
        /// </summary>
        public int Marry
        {
            set { _marry = value; }
            get { return _marry; }
        }
        /// <summary>
        /// 毕业学校
        /// </summary>
        public string School
        {
            set { _school = value; }
            get { return _school; }
        }
        /// <summary>
        /// 毕业时间
        /// </summary>
        public string GraduateTime
        {
            set { _graduatetime = value; }
            get { return _graduatetime; }
        }
        /// <summary>
        /// 最高学历
        /// </summary>
        public int Levels
        {
            set { _levels = value; }
            get { return _levels; }
        }
        /// <summary>
        /// 所学专业
        /// </summary>
        public string Speciality
        {
            set { _speciality = value; }
            get { return _speciality; }
        }
        /// <summary>
        /// 身高
        /// </summary>
        public string Height
        {
            set { _height = value; }
            get { return _height; }
        }
        /// <summary>
        /// 体重
        /// </summary>
        public string Weight
        {
            set { _weight = value; }
            get { return _weight; }
        }
        /// <summary>
        /// 户口所在地
        /// </summary>
        public string Home
        {
            set { _home = value; }
            get { return _home; }
        }
        /// <summary>
        /// 当前所在地
        /// </summary>
        public string Place
        {
            set { _place = value; }
            get { return _place; }
        }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string Contact
        {
            set { _contact = value; }
            get { return _contact; }
        }
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string Post
        {
            set { _post = value; }
            get { return _post; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string Linkman
        {
            set { _linkman = value; }
            get { return _linkman; }
        }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 个人照片
        /// </summary>
        public string Img
        {
            set { _img = value; }
            get { return _img; }
        }
        #endregion Model

    }
    #endregion
}
