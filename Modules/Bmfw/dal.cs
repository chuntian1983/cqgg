using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Data;
using Maticsoft.DBUtility;//Please add references

namespace Modules.T_BMFW.DAL
{
    /// <summary>
    /// 数据访问类:T_BMFW
    /// </summary>
    public partial class T_BMFW
    {
        public T_BMFW()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_BMFW");
            strSql.Append(" where id=@id");
             MySqlParameter[] parameters = {
					new MySqlParameter("@id",MySqlDbType.Int32,4)
			};
            
            parameters[0].Value = id;

            return DbHelperMySQLnew.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Modules.T_BMFW.Model.T_BMFW model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_BMFW(");
            strSql.Append("cunid,imgurl,state,bz)");
            strSql.Append(" values (");
            strSql.Append("@cunid,@imgurl,@state,@bz)");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
					new MySqlParameter("@cunid", MySqlDbType.Int32,4),
					new MySqlParameter("@imgurl", MySqlDbType.VarChar,500),
					new MySqlParameter("@state", MySqlDbType.VarChar,50),
					new MySqlParameter("@bz", MySqlDbType.VarChar,100)};
            parameters[0].Value = model.cunid;
            parameters[1].Value = model.imgurl;
            parameters[2].Value = model.state;
            parameters[3].Value = model.bz;

            object obj = DbHelperMySQLnew.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(Modules.T_BMFW.Model.T_BMFW model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_BMFW set ");
            strSql.Append("cunid=@cunid,");
            strSql.Append("imgurl=@imgurl,");
            strSql.Append("state=@state,");
            strSql.Append("bz=@bz");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@cunid", MySqlDbType.Int32,4),
					new MySqlParameter("@imgurl", MySqlDbType.VarChar,500),
					new MySqlParameter("@state", MySqlDbType.VarChar,50),
					new MySqlParameter("@bz", MySqlDbType.VarChar,100),
					new MySqlParameter("@id", MySqlDbType.Int32,4)};
            parameters[0].Value = model.cunid;
            parameters[1].Value = model.imgurl;
            parameters[2].Value = model.state;
            parameters[3].Value = model.bz;
            parameters[4].Value = model.id;

            int rows = DbHelperMySQLnew.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_BMFW ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32,4)
			};
            parameters[0].Value = id;

            int rows = DbHelperMySQLnew.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_BMFW ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperMySQLnew.ExecuteSql(strSql.ToString());
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
        public Modules.T_BMFW.Model.T_BMFW GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,cunid,imgurl,state,bz from T_BMFW ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32,4)
			};
            parameters[0].Value = id;

            Modules.T_BMFW.Model.T_BMFW model = new Modules.T_BMFW.Model.T_BMFW();
            DataSet ds = DbHelperMySQLnew.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cunid"] != null && ds.Tables[0].Rows[0]["cunid"].ToString() != "")
                {
                    model.cunid = int.Parse(ds.Tables[0].Rows[0]["cunid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["imgurl"] != null && ds.Tables[0].Rows[0]["imgurl"].ToString() != "")
                {
                    model.imgurl = ds.Tables[0].Rows[0]["imgurl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["state"] != null && ds.Tables[0].Rows[0]["state"].ToString() != "")
                {
                    model.state = ds.Tables[0].Rows[0]["state"].ToString();
                }
                if (ds.Tables[0].Rows[0]["bz"] != null && ds.Tables[0].Rows[0]["bz"].ToString() != "")
                {
                    model.bz = ds.Tables[0].Rows[0]["bz"].ToString();
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
            strSql.Append("select id,cunid,imgurl,state,bz ");
            strSql.Append(" FROM T_BMFW ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQLnew.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表(村级名称)
        /// </summary>
        public DataSet GetListcun(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,cunid,imgurl,state,bz,b.title,b.ParentCategoryId FROM T_BMFW a,t_departcategory b where a.cunid=b.categoryid ");
            
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            return DbHelperMySQLnew.Query(strSql.ToString());
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
            strSql.Append(" id,cunid,imgurl,state,bz ");
            strSql.Append(" FROM T_BMFW ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperMySQLnew.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM T_BMFW ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperMySQLnew.GetSingle(strSql.ToString());
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
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from T_BMFW T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperMySQLnew.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            MySqlParameter[] parameters = {
                    new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("@PageSize", MySqlDbType.Int),
                    new MySqlParameter("@PageIndex", MySqlDbType.Int),
                    new MySqlParameter("@IsReCount", MySqlDbType.Bit),
                    new MySqlParameter("@OrderType", MySqlDbType.Bit),
                    new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "T_BMFW";
            parameters[1].Value = "id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQLnew.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}
