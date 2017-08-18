using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;

namespace Modules.Answer
{
    /// <summary>
    /// 数据访问类:T_Answer
    /// </summary>
    public partial class T_Answerdal
    {
        public T_Answerdal()
        { }
        #region  Method

        public string GetCount(string id,string xxid)
        {
            string strsql = "select count(*) from T_Answer where questionid='"+id+"' and content='"+xxid+"'";
            return DbHelperSQL.GetSingle(strsql).ToString();
 
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Modules.Answer.T_Answer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Answer(");
            strSql.Append("QuestionId,Content,Name,Business,AddDate,Title,State)");
            strSql.Append(" values (");
            strSql.Append("@QuestionId,@Content,@Name,@Business,@AddDate,@Title,@State)");
            strSql.Append(";select @@IDENTITY");
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

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Modules.Answer.T_Answer model)
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
					new SqlParameter("@QuestionId", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Business", SqlDbType.VarChar,100),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@AnswerId", SqlDbType.Int,4)};
            parameters[0].Value = model.QuestionId;
            parameters[1].Value = model.Content;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Business;
            parameters[4].Value = model.AddDate;
            parameters[5].Value = model.Title;
            parameters[6].Value = model.State;
            parameters[7].Value = model.AnswerId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int AnswerId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Answer ");
            strSql.Append(" where AnswerId=@AnswerId");
            SqlParameter[] parameters = {
					new SqlParameter("@AnswerId", SqlDbType.Int,4)
			};
            parameters[0].Value = AnswerId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string AnswerIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Answer ");
            strSql.Append(" where AnswerId in (" + AnswerIdlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Modules.Answer.T_Answer GetModel(int AnswerId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 AnswerId,QuestionId,Content,Name,Business,AddDate,Title,State from T_Answer ");
            strSql.Append(" where AnswerId=@AnswerId");
            SqlParameter[] parameters = {
					new SqlParameter("@AnswerId", SqlDbType.Int,4)
			};
            parameters[0].Value = AnswerId;

            Modules.Answer.T_Answer model = new Modules.Answer.T_Answer();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["AnswerId"] != null && ds.Tables[0].Rows[0]["AnswerId"].ToString() != "")
                {
                    model.AnswerId = int.Parse(ds.Tables[0].Rows[0]["AnswerId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["QuestionId"] != null && ds.Tables[0].Rows[0]["QuestionId"].ToString() != "")
                {
                    model.QuestionId = int.Parse(ds.Tables[0].Rows[0]["QuestionId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Content"] != null && ds.Tables[0].Rows[0]["Content"].ToString() != "")
                {
                    model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Name"] != null && ds.Tables[0].Rows[0]["Name"].ToString() != "")
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Business"] != null && ds.Tables[0].Rows[0]["Business"].ToString() != "")
                {
                    model.Business = ds.Tables[0].Rows[0]["Business"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AddDate"] != null && ds.Tables[0].Rows[0]["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Title"] != null && ds.Tables[0].Rows[0]["Title"].ToString() != "")
                {
                    model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["State"] != null && ds.Tables[0].Rows[0]["State"].ToString() != "")
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
            strSql.Append("select AnswerId,QuestionId,Content,Name,Business,AddDate,Title,State ");
            strSql.Append(" FROM T_Answer ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" AnswerId,QuestionId,Content,Name,Business,AddDate,Title,State ");
            strSql.Append(" FROM T_Answer ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM T_Answer ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.AnswerId desc");
            }
            strSql.Append(")AS Row, T.*  from T_Answer T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "T_Answer";
            parameters[1].Value = "AnswerId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}
