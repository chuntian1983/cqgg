using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CommonUtility.DBUtility;

namespace Modules.Company
{
    public class CompanyDAL
    {
        public CompanyDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_CompanyInfo");
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
        public void Add(T_CompanyInfoMoel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_CompanyInfo(");
            strSql.Append("UserID,CompanyName,CompanySize,CompanyCharacter,LicenseID,Organ,Locus,Address,Post,Linkman,Tel,Fax,Email,Web,CompanyInfo,Tj1)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@CompanyName,@CompanySize,@CompanyCharacter,@LicenseID,@Organ,@Locus,@Address,@Post,@Linkman,@Tel,@Fax,@Email,@Web,@CompanyInfo,@Tj1)");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@CompanyName", SqlDbType.VarChar,1000),
					new SqlParameter("@CompanySize", SqlDbType.Int,4),
					new SqlParameter("@CompanyCharacter", SqlDbType.Int,4),
					new SqlParameter("@LicenseID", SqlDbType.VarChar,200),
					new SqlParameter("@Organ", SqlDbType.VarChar,200),
					new SqlParameter("@Locus", SqlDbType.VarChar,200),
					new SqlParameter("@Address", SqlDbType.VarChar,200),
					new SqlParameter("@Post", SqlDbType.VarChar,50),
					new SqlParameter("@Linkman", SqlDbType.VarChar,100),
					new SqlParameter("@Tel", SqlDbType.VarChar,100),
					new SqlParameter("@Fax", SqlDbType.VarChar,100),
					new SqlParameter("@Email", SqlDbType.VarChar,200),
					new SqlParameter("@Web", SqlDbType.VarChar,500),
					new SqlParameter("@CompanyInfo", SqlDbType.Text),
                    new SqlParameter("@Tj1", SqlDbType.Int,4)
            };
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.CompanyName;
            parameters[2].Value = model.CompanySize;
            parameters[3].Value = model.CompanyCharacter;
            parameters[4].Value = model.LicenseID;
            parameters[5].Value = model.Organ;
            parameters[6].Value = model.Locus;
            parameters[7].Value = model.Address;
            parameters[8].Value = model.Post;
            parameters[9].Value = model.Linkman;
            parameters[10].Value = model.Tel;
            parameters[11].Value = model.Fax;
            parameters[12].Value = model.Email;
            parameters[13].Value = model.Web;
            parameters[14].Value = model.CompanyInfo;
            parameters[15].Value = model.Tj1;

            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(T_CompanyInfoMoel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_CompanyInfo set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("CompanyName=@CompanyName,");
            strSql.Append("CompanySize=@CompanySize,");
            strSql.Append("CompanyCharacter=@CompanyCharacter,");
            strSql.Append("LicenseID=@LicenseID,");
            strSql.Append("Organ=@Organ,");
            strSql.Append("Locus=@Locus,");
            strSql.Append("Address=@Address,");
            strSql.Append("Post=@Post,");
            strSql.Append("Linkman=@Linkman,");
            strSql.Append("Tel=@Tel,");
            strSql.Append("Fax=@Fax,");
            strSql.Append("Email=@Email,");
            strSql.Append("Web=@Web,");
            strSql.Append("CompanyInfo=@CompanyInfo,");
            strSql.Append("Tj1=@Tj1");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@CompanyName", SqlDbType.VarChar,1000),
					new SqlParameter("@CompanySize", SqlDbType.Int,4),
					new SqlParameter("@CompanyCharacter", SqlDbType.Int,4),
					new SqlParameter("@LicenseID", SqlDbType.VarChar,200),
					new SqlParameter("@Organ", SqlDbType.VarChar,200),
					new SqlParameter("@Locus", SqlDbType.VarChar,200),
					new SqlParameter("@Address", SqlDbType.VarChar,200),
					new SqlParameter("@Post", SqlDbType.VarChar,50),
					new SqlParameter("@Linkman", SqlDbType.VarChar,100),
					new SqlParameter("@Tel", SqlDbType.VarChar,100),
					new SqlParameter("@Fax", SqlDbType.VarChar,100),
					new SqlParameter("@Email", SqlDbType.VarChar,200),
					new SqlParameter("@Web", SqlDbType.VarChar,500),
					new SqlParameter("@CompanyInfo", SqlDbType.Text),
                    new SqlParameter("@Tj1", SqlDbType.Int,4)
            };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.CompanyName;
            parameters[3].Value = model.CompanySize;
            parameters[4].Value = model.CompanyCharacter;
            parameters[5].Value = model.LicenseID;
            parameters[6].Value = model.Organ;
            parameters[7].Value = model.Locus;
            parameters[8].Value = model.Address;
            parameters[9].Value = model.Post;
            parameters[10].Value = model.Linkman;
            parameters[11].Value = model.Tel;
            parameters[12].Value = model.Fax;
            parameters[13].Value = model.Email;
            parameters[14].Value = model.Web;
            parameters[15].Value = model.CompanyInfo;
            parameters[16].Value = model.Tj1;

            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete T_CompanyInfo ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
				};
            parameters[0].Value = UserID;
            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public T_CompanyInfoMoel GetModel(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_CompanyInfo ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = UserID;
            T_CompanyInfoMoel model = new T_CompanyInfoMoel();
            DataSet ds = SQLHelper.Query(strSql.ToString(), parameters);
            model.UserID = UserID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.CompanyName = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                if (ds.Tables[0].Rows[0]["CompanySize"].ToString() != "")
                {
                    model.CompanySize = int.Parse(ds.Tables[0].Rows[0]["CompanySize"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CompanyCharacter"].ToString() != "")
                {
                    model.CompanyCharacter =int.Parse(ds.Tables[0].Rows[0]["CompanyCharacter"].ToString());
                }
                model.LicenseID = ds.Tables[0].Rows[0]["LicenseID"].ToString();
                model.Organ = ds.Tables[0].Rows[0]["Organ"].ToString();
                model.Locus = ds.Tables[0].Rows[0]["Locus"].ToString();
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                model.Post = ds.Tables[0].Rows[0]["Post"].ToString();
                model.Linkman = ds.Tables[0].Rows[0]["Linkman"].ToString();
                model.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
                model.Fax = ds.Tables[0].Rows[0]["Fax"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.Web = ds.Tables[0].Rows[0]["Web"].ToString();
                model.CompanyInfo = ds.Tables[0].Rows[0]["CompanyInfo"].ToString();
                if (ds.Tables[0].Rows[0]["Tj1"].ToString() != "")
                {
                    model.Tj1 = int.Parse(ds.Tables[0].Rows[0]["Tj1"].ToString());
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
            strSql.Append("select * from T_CompanyInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID ");
            return SQLHelper.Query(strSql.ToString());
        }

        ///// <summary>
        ///// 根据成员编号取得企业会员详细信息
        ///// </summary>
        //public DataSet GetCompanyInfo(int MemberID)
        //{
        //    string sql = "select * from V_CompanyInfo where MemberID=" + MemberID + "";
        //    return SQLHelper.Query(sql);
        //}

        //企业会员的推荐状态的处理
        public void TjCompany(int UserID, bool isTj)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string sql = String.Format("update T_CompanyInfo set Tj1={0} where UserID={1}", isTj ? 1 : 0, UserID);
            helper.ExecuteNonQuery(sql);
        }
        #endregion  成员方法

        //08推荐
        public string Tj08(int UserId)
        {
            string sql="select Tj2 from T_CompanyInfo where UserID="+UserId+"";
            return SQLHelper.GetSingle(sql).ToString();
        }
        //企业会员的０８推荐状态的处理
        public void TjCompany08(int UserID, bool isTj1)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string sql = String.Format("update T_CompanyInfo set Tj2={0} where UserID={1}", isTj1 ? 1 : 0, UserID);
            helper.ExecuteNonQuery(sql);
        }
    }
    #region T_CompanyInfoModel
    public class T_CompanyInfoMoel
    {
        public T_CompanyInfoMoel()
        { }
        #region Model
        private int _id;
        private int _userid;
        private string _companyname;
        private int _companysize;
        private int _companycharacter;
        private string _licenseid;
        private string _organ;
        private string _locus;
        private string _address;
        private string _post;
        private string _linkman;
        private string _tel;
        private string _fax;
        private string _email;
        private string _web;
        private string _companyinfo;
        private int _tj1;
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
        /// 公司名称
        /// </summary>
        public string CompanyName
        {
            set { _companyname = value; }
            get { return _companyname; }
        }
        /// <summary>
        /// 公司规模
        /// </summary>
        public int CompanySize
        {
            set { _companysize = value; }
            get { return _companysize; }
        }
        /// <summary>
        /// 公司性质
        /// </summary>
        public int CompanyCharacter
        {
            set { _companycharacter = value; }
            get { return _companycharacter; }
        }
        /// <summary>
        /// 营业执照号
        /// </summary>
        public string LicenseID
        {
            set { _licenseid = value; }
            get { return _licenseid; }
        }
        /// <summary>
        /// 注册机构
        /// </summary>
        public string Organ
        {
            set { _organ = value; }
            get { return _organ; }
        }
        /// <summary>
        /// 所在地
        /// </summary>
        public string Locus
        {
            set { _locus = value; }
            get { return _locus; }
        }
        /// <summary>
        /// 公司地址
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
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
        /// 联系人
        /// </summary>
        public string Linkman
        {
            set { _linkman = value; }
            get { return _linkman; }
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
        /// 联系传真
        /// </summary>
        public string Fax
        {
            set { _fax = value; }
            get { return _fax; }
        }
        /// <summary>
        ///  电子邮箱
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 网址
        /// </summary>
        public string Web
        {
            set { _web = value; }
            get { return _web; }
        }
        /// <summary>
        /// 公司简介
        /// </summary>
        public string CompanyInfo
        {
            set { _companyinfo = value; }
            get { return _companyinfo; }
        }
        /// <summary>
        /// 推荐
        /// </summary>
        public int Tj1
        {
            set { _tj1 = value; }
            get { return _tj1; }
        }


        #endregion Model
    }
    #endregion 
}
