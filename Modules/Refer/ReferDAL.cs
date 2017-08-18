using System;
using System.Collections.Generic;
using System.Text;
using CommonUtility.DBUtility;
using System.Data;
using System.Data.SqlClient;


namespace Modules.Refer
{
    public class ReferDAL
    {
        public ReferDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int OpinionID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_Opinions");
            strSql.Append(" where OpinionID= @OpinionID");
            SqlParameter[] parameters = {
					new SqlParameter("@OpinionID", SqlDbType.Int,4)
				};
            parameters[0].Value = OpinionID;
            return SQLHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ReferModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Opinions(");
            strSql.Append("OpName,OpTel,OpEmail,OpTitle,OpContent,FillTime,OpType)");
            strSql.Append(" values (");
            strSql.Append("@OpName,@OpTel,@OpEmail,@OpTitle,@OpContent,@FillTime,@OpType)");
            SqlParameter[] parameters = {
					new SqlParameter("@OpName", SqlDbType.VarChar,50),
					new SqlParameter("@OpTel", SqlDbType.VarChar,50),
					new SqlParameter("@OpEmail", SqlDbType.VarChar,50),
					new SqlParameter("@OpTitle", SqlDbType.VarChar,200),
					new SqlParameter("@OpContent", SqlDbType.VarChar,1000),
					new SqlParameter("@FillTime", SqlDbType.DateTime),
                    new SqlParameter("@OpType", SqlDbType.Int,4),
                    new SqlParameter("@OpPost", SqlDbType.VarChar,50),
                    new SqlParameter("@OpAddress", SqlDbType.VarChar,200)
            };
            parameters[0].Value = model.OpName;
            parameters[1].Value = model.OpTel;
            parameters[2].Value = model.OpEmail;
            parameters[3].Value = model.OpTitle;
            parameters[4].Value = model.OpContent;
            parameters[5].Value = model.FillTime;
            parameters[6].Value = model.OpType;
            parameters[7].Value = model.OpPost;
            parameters[8].Value = model.OpAddress;

            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ReferModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Opinions set ");
            strSql.Append("OpName=@OpName,");
            strSql.Append("OpTel=@OpTel,");
            strSql.Append("OpEmail=@OpEmail,");
            strSql.Append("OpTitle=@OpTitle,");
            strSql.Append("OpContent=@OpContent,");
            strSql.Append("FillTime=@FillTime");
            strSql.Append("OpType=@OpType");
            strSql.Append(" where OpinionID=@OpinionID");
            SqlParameter[] parameters = {
					new SqlParameter("@OpinionID", SqlDbType.Int,4),
					new SqlParameter("@OpName", SqlDbType.VarChar,50),
					new SqlParameter("@OpTel", SqlDbType.VarChar,50),
					new SqlParameter("@OpEmail", SqlDbType.VarChar,50),
					new SqlParameter("@OpTitle", SqlDbType.VarChar,200),
					new SqlParameter("@OpContent", SqlDbType.VarChar,1000),
					new SqlParameter("@FillTime", SqlDbType.DateTime),
                    new SqlParameter("@OpType", SqlDbType.Int,4),
                    new SqlParameter("@OpPost", SqlDbType.VarChar,50),
                    new SqlParameter("@OpAddress", SqlDbType.VarChar,200)
            };
            parameters[0].Value = model.OpinionID;
            parameters[1].Value = model.OpName;
            parameters[2].Value = model.OpTel;
            parameters[3].Value = model.OpEmail;
            parameters[4].Value = model.OpTitle;
            parameters[5].Value = model.OpContent;
            parameters[6].Value = model.FillTime;
            parameters[7].Value = model.OpType;
            parameters[8].Value = model.OpPost;
            parameters[9].Value = model.OpAddress;

            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int OpinionID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete T_Opinions ");
            strSql.Append(" where OpinionID=@OpinionID");
            SqlParameter[] parameters = {
					new SqlParameter("@OpinionID", SqlDbType.Int,4)
				};
            parameters[0].Value = OpinionID;
            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ReferModel GetModel(int OpinionID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_Opinions ");
            strSql.Append(" where OpinionID=@OpinionID");
            SqlParameter[] parameters = {
					new SqlParameter("@OpinionID", SqlDbType.Int,4)};
            parameters[0].Value = OpinionID;
            ReferModel model = new ReferModel();
            DataSet ds = SQLHelper.Query(strSql.ToString(), parameters);
            model.OpinionID = OpinionID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.OpName = ds.Tables[0].Rows[0]["OpName"].ToString();
                model.OpTel = ds.Tables[0].Rows[0]["OpTel"].ToString();
                model.OpEmail = ds.Tables[0].Rows[0]["OpEmail"].ToString();
                model.OpTitle = ds.Tables[0].Rows[0]["OpTitle"].ToString();
                model.OpContent = ds.Tables[0].Rows[0]["OpContent"].ToString();
                if (ds.Tables[0].Rows[0]["OpType"].ToString() != "")
                {
                    model.OpType = int.Parse(ds.Tables[0].Rows[0]["OpType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FillTime"].ToString() != "")
                {
                    model.FillTime = DateTime.Parse(ds.Tables[0].Rows[0]["FillTime"].ToString());
                }
                model.OpPost = ds.Tables[0].Rows[0]["OpPost"].ToString();
                model.OpAddress = ds.Tables[0].Rows[0]["OpAddress"].ToString();
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
            strSql.Append("select * from T_Opinions ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by OpinionID ");
            return SQLHelper.Query(strSql.ToString());
        }


        //获得已经回复的咨询详细信息
        public DataSet GetRepeatInfo(int OpinionID)
        {
            string sql = "select * from V_RepeatList where OpinionID=" + OpinionID + " and OpType=1";
            return SQLHelper.Query(sql);
        }

        //更新回复状态
        public int UpdateState(int OpinionID)
        {
            string sql = "Update T_Opinions set OpType=1 where OpinionID=" + OpinionID + "";
            return SQLHelper.ExecuteSql(sql);
        }

        #endregion  成员方法
      
    }
}
