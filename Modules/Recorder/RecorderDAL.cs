using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CommonUtility.DBUtility;

namespace Modules.Recorder
{
    public class RecorderDAL
    {
        public RecorderDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_RecorderInfo");
            strSql.Append(" where ID= @ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
            parameters[0].Value = ID;
            return SQLHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(RecorderModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_RecorderInfo(");
            strSql.Append("RecorderID,Name,Degree,GradeTimeSchool,Speciality,ZZQK,ZCQK,ZCID,CompanyInfo,TCF,TCID,GZQK,Pay,YDW,XDW,AddTime)");
            strSql.Append(" values (");
            strSql.Append("@RecorderID,@Name,@Degree,@GradeTimeSchool,@Speciality,@ZZQK,@ZCQK,@ZCID,@CompanyInfo,@TCF,@TCID,@GZQK,@Pay,@YDW,@XDW,@AddTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@RecorderID", SqlDbType.VarChar,200),
					new SqlParameter("@Name", SqlDbType.VarChar,200),
					new SqlParameter("@Degree", SqlDbType.VarChar,200),
					new SqlParameter("@GradeTimeSchool", SqlDbType.VarChar,200),
					new SqlParameter("@Speciality", SqlDbType.VarChar,200),
					new SqlParameter("@ZZQK", SqlDbType.VarChar,200),
					new SqlParameter("@ZCQK", SqlDbType.VarChar,200),
					new SqlParameter("@ZCID", SqlDbType.VarChar,200),
					new SqlParameter("@CompanyInfo", SqlDbType.VarChar,200),
					new SqlParameter("@TCF", SqlDbType.VarChar,200),
					new SqlParameter("@TCID", SqlDbType.VarChar,200),
					new SqlParameter("@GZQK", SqlDbType.VarChar,200),
					new SqlParameter("@Pay", SqlDbType.VarChar,200),
					new SqlParameter("@YDW", SqlDbType.VarChar,200),
					new SqlParameter("@XDW", SqlDbType.VarChar,200),
					new SqlParameter("@AddTime", SqlDbType.DateTime)};
            parameters[0].Value = model.RecorderID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Degree;
            parameters[3].Value = model.GradeTimeSchool;
            parameters[4].Value = model.Speciality;
            parameters[5].Value = model.ZZQK;
            parameters[6].Value = model.ZCQK;
            parameters[7].Value = model.ZCID;
            parameters[8].Value = model.CompanyInfo;
            parameters[9].Value = model.TCF;
            parameters[10].Value = model.TCID;
            parameters[11].Value = model.GZQK;
            parameters[12].Value = model.Pay;
            parameters[13].Value = model.YDW;
            parameters[14].Value = model.XDW;
            parameters[15].Value = model.AddTime;

            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(RecorderModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_RecorderInfo set ");
            strSql.Append("RecorderID=@RecorderID,");
            strSql.Append("Name=@Name,");
            strSql.Append("Degree=@Degree,");
            strSql.Append("GradeTimeSchool=@GradeTimeSchool,");
            strSql.Append("Speciality=@Speciality,");
            strSql.Append("ZZQK=@ZZQK,");
            strSql.Append("ZCQK=@ZCQK,");
            strSql.Append("ZCID=@ZCID,");
            strSql.Append("CompanyInfo=@CompanyInfo,");
            strSql.Append("TCF=@TCF,");
            strSql.Append("TCID=@TCID,");
            strSql.Append("GZQK=@GZQK,");
            strSql.Append("Pay=@Pay,");
            strSql.Append("YDW=@YDW,");
            strSql.Append("XDW=@XDW,");
            strSql.Append("AddTime=@AddTime");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@RecorderID", SqlDbType.VarChar,200),
					new SqlParameter("@Name", SqlDbType.VarChar,200),
					new SqlParameter("@Degree", SqlDbType.VarChar,200),
					new SqlParameter("@GradeTimeSchool", SqlDbType.VarChar,200),
					new SqlParameter("@Speciality", SqlDbType.VarChar,200),
					new SqlParameter("@ZZQK", SqlDbType.VarChar,200),
					new SqlParameter("@ZCQK", SqlDbType.VarChar,200),
					new SqlParameter("@ZCID", SqlDbType.VarChar,200),
					new SqlParameter("@CompanyInfo", SqlDbType.VarChar,200),
					new SqlParameter("@TCF", SqlDbType.VarChar,200),
					new SqlParameter("@TCID", SqlDbType.VarChar,200),
					new SqlParameter("@GZQK", SqlDbType.VarChar,200),
					new SqlParameter("@Pay", SqlDbType.VarChar,200),
					new SqlParameter("@YDW", SqlDbType.VarChar,200),
					new SqlParameter("@XDW", SqlDbType.VarChar,200),
					new SqlParameter("@AddTime", SqlDbType.DateTime)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.RecorderID;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Degree;
            parameters[4].Value = model.GradeTimeSchool;
            parameters[5].Value = model.Speciality;
            parameters[6].Value = model.ZZQK;
            parameters[7].Value = model.ZCQK;
            parameters[8].Value = model.ZCID;
            parameters[9].Value = model.CompanyInfo;
            parameters[10].Value = model.TCF;
            parameters[11].Value = model.TCID;
            parameters[12].Value = model.GZQK;
            parameters[13].Value = model.Pay;
            parameters[14].Value = model.YDW;
            parameters[15].Value = model.XDW;
            parameters[16].Value = model.AddTime;

            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete T_RecorderInfo ");
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
        public RecorderModel GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_RecorderInfo ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;
            RecorderModel model = new RecorderModel();
            DataSet ds = SQLHelper.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.RecorderID = ds.Tables[0].Rows[0]["RecorderID"].ToString();
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.Degree = ds.Tables[0].Rows[0]["Degree"].ToString();
                model.GradeTimeSchool = ds.Tables[0].Rows[0]["GradeTimeSchool"].ToString();
                model.Speciality = ds.Tables[0].Rows[0]["Speciality"].ToString();
                model.ZZQK = ds.Tables[0].Rows[0]["ZZQK"].ToString();
                model.ZCQK = ds.Tables[0].Rows[0]["ZCQK"].ToString();
                model.ZCID = ds.Tables[0].Rows[0]["ZCID"].ToString();
                model.CompanyInfo = ds.Tables[0].Rows[0]["CompanyInfo"].ToString();
                model.TCF = ds.Tables[0].Rows[0]["TCF"].ToString();
                model.TCID = ds.Tables[0].Rows[0]["TCID"].ToString();
                model.GZQK = ds.Tables[0].Rows[0]["GZQK"].ToString();
                model.Pay = ds.Tables[0].Rows[0]["Pay"].ToString();
                model.YDW = ds.Tables[0].Rows[0]["YDW"].ToString();
                model.XDW = ds.Tables[0].Rows[0]["XDW"].ToString();
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
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
            strSql.Append("select * from T_RecorderInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID ");
            return SQLHelper.Query(strSql.ToString());
        }

        public DataSet GetArticleList(string fields, string filter, string sort, int currentPageIndex, int pageSize, out int recordCount)
        {
            return CommonUtility.PaginationUtility.GetPaginationList(fields, "T_RecorderInfo", filter, sort, currentPageIndex, pageSize, out recordCount);
        }
        #endregion  成员方法
    }
}
