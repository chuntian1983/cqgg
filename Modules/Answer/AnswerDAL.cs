using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CommonUtility.DBUtility;

namespace Modules.Answer
{
    public class AnswerDAL
    {
        public AnswerDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int QuestionId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_Answer");
            strSql.Append(" where QuestionId= @QuestionId");
            SqlParameter[] parameters = {
					new SqlParameter("@QuestionId", SqlDbType.Int,4)
				};
            parameters[0].Value = QuestionId;
            return SQLHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(AnswerModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Answer(");
            strSql.Append("QuestionId,Content,Name,Business,AddDate,Title,State)");
            strSql.Append(" values (");
            strSql.Append("@QuestionId,@Content,@Name,@Business,@AddDate,@Title,@State)");
            SqlParameter[] parameters = {
					new SqlParameter("@QuestionId", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Business", SqlDbType.VarChar,100),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@State", SqlDbType.Int,4)};
            parameters[0].Value = model.QuestionId;
            parameters[1].Value = model.Content;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Business;
            parameters[4].Value = model.AddDate;
            parameters[5].Value = model.Title;
            parameters[6].Value = model.State;

            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(AnswerModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Answer set ");
            strSql.Append("QuestionId=@QuestionId,");
            strSql.Append("Content=@Content,");
            strSql.Append("Name=@Name,");
            strSql.Append("Business=@Business,");
            strSql.Append("AddDate=@AddDate,");
            strSql.Append("Title=@Title,");
            strSql.Append("State=@State");
            strSql.Append(" where AnswerId=@AnswerId");
            SqlParameter[] parameters = {
					new SqlParameter("@AnswerId", SqlDbType.Int,4),
					new SqlParameter("@QuestionId", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Business", SqlDbType.VarChar,100),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@State", SqlDbType.Int,4)};
            parameters[0].Value = model.AnswerId;
            parameters[1].Value = model.QuestionId;
            parameters[2].Value = model.Content;
            parameters[3].Value = model.Name;
            parameters[4].Value = model.Business;
            parameters[5].Value = model.AddDate;
            parameters[6].Value = model.Title;
            parameters[7].Value = model.State;

            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int QuestionId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete T_Answer ");
            strSql.Append(" where QuestionId=@QuestionId");
            SqlParameter[] parameters = {
					new SqlParameter("@QuestionId", SqlDbType.Int,4)
				};
            parameters[0].Value = QuestionId;
            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AnswerModel GetModel(int QuestionId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_Answer ");
            strSql.Append(" where QuestionId=@QuestionId");
            SqlParameter[] parameters = {
					new SqlParameter("@QuestionId", SqlDbType.Int,4)};
            parameters[0].Value = QuestionId;
            AnswerModel model = new AnswerModel();
            DataSet ds = SQLHelper.Query(strSql.ToString(), parameters);
            model.QuestionId = QuestionId;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["AnswerId"].ToString() != "")
                {
                    model.AnswerId = int.Parse(ds.Tables[0].Rows[0]["AnswerId"].ToString());
                }
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.Business = ds.Tables[0].Rows[0]["Business"].ToString();
                if (ds.Tables[0].Rows[0]["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                if (ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    model.State = int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
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
            strSql.Append("select * from T_Answer ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by AnswerId ");
            return SQLHelper.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}
