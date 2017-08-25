using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.DBUtility;
using MySql.Data.MySqlClient;
using System.Data;

namespace Modules.News
{
    /// <summary>
    /// 类t_articlecategory。
    /// </summary>
    [Serializable]
    public partial class t_articlecategory
    {
        public t_articlecategory()
        { }
        #region Model
        private int _categoryid;
        private string _title;
        private int _sort;
        private int _type;
        private int _parentcategoryid;
        private int _addeduserid;
        private string _addeddate;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int CategoryId
        {
            set { _categoryid = value; }
            get { return _categoryid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ParentCategoryId
        {
            set { _parentcategoryid = value; }
            get { return _parentcategoryid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AddedUserId
        {
            set { _addeduserid = value; }
            get { return _addeduserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AddedDate
        {
            set { _addeddate = value; }
            get { return _addeddate; }
        }
        #endregion Model


        #region  Method

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public t_articlecategory(int CategoryId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CategoryId,Title,Sort,Type,ParentCategoryId,AddedUserId,AddedDate ");
            strSql.Append(" FROM t_articlecategory ");
            strSql.Append(" where CategoryId=@CategoryId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@CategoryId", MySqlDbType.Int32)};
            parameters[0].Value = CategoryId;

            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CategoryId"] != null && ds.Tables[0].Rows[0]["CategoryId"].ToString() != "")
                {
                    this.CategoryId = int.Parse(ds.Tables[0].Rows[0]["CategoryId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Title"] != null)
                {
                    this.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Sort"] != null && ds.Tables[0].Rows[0]["Sort"].ToString() != "")
                {
                    this.Sort = int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Type"] != null && ds.Tables[0].Rows[0]["Type"].ToString() != "")
                {
                    this.Type = int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentCategoryId"] != null && ds.Tables[0].Rows[0]["ParentCategoryId"].ToString() != "")
                {
                    this.ParentCategoryId = int.Parse(ds.Tables[0].Rows[0]["ParentCategoryId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddedUserId"] != null && ds.Tables[0].Rows[0]["AddedUserId"].ToString() != "")
                {
                    this.AddedUserId = int.Parse(ds.Tables[0].Rows[0]["AddedUserId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddedDate"] != null)
                {
                    this.AddedDate = ds.Tables[0].Rows[0]["AddedDate"].ToString();
                }
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int CategoryId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_articlecategory");
            strSql.Append(" where CategoryId=@CategoryId ");

            MySqlParameter[] parameters = {
					new MySqlParameter("@CategoryId", MySqlDbType.Int32)};
            parameters[0].Value = CategoryId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_articlecategory (");
            strSql.Append("Title,Sort,Type,ParentCategoryId,AddedUserId,AddedDate)");
            strSql.Append(" values (");
            strSql.Append("@Title,@Sort,@Type,@ParentCategoryId,@AddedUserId,@AddedDate)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@Title", MySqlDbType.VarChar,50),
					new MySqlParameter("@Sort", MySqlDbType.Int32,11),
					new MySqlParameter("@Type", MySqlDbType.Int32,11),
					new MySqlParameter("@ParentCategoryId", MySqlDbType.Int32,11),
					new MySqlParameter("@AddedUserId", MySqlDbType.Int32,11),
					new MySqlParameter("@AddedDate", MySqlDbType.VarChar,0)};
            parameters[0].Value = Title;
            parameters[1].Value = Sort;
            parameters[2].Value = Type;
            parameters[3].Value = ParentCategoryId;
            parameters[4].Value = AddedUserId;
            parameters[5].Value = AddedDate;

            DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_articlecategory set ");
            strSql.Append("Title=@Title,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("Type=@Type,");
            strSql.Append("ParentCategoryId=@ParentCategoryId,");
            strSql.Append("AddedUserId=@AddedUserId,");
            strSql.Append("AddedDate=@AddedDate");
            strSql.Append(" where CategoryId=@CategoryId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@Title", MySqlDbType.VarChar,50),
					new MySqlParameter("@Sort", MySqlDbType.Int32,11),
					new MySqlParameter("@Type", MySqlDbType.Int32,11),
					new MySqlParameter("@ParentCategoryId", MySqlDbType.Int32,11),
					new MySqlParameter("@AddedUserId", MySqlDbType.Int32,11),
					new MySqlParameter("@AddedDate", MySqlDbType.VarChar,0),
					new MySqlParameter("@CategoryId", MySqlDbType.Int32,11)};
            parameters[0].Value = Title;
            parameters[1].Value = Sort;
            parameters[2].Value = Type;
            parameters[3].Value = ParentCategoryId;
            parameters[4].Value = AddedUserId;
            parameters[5].Value = AddedDate;
            parameters[6].Value = CategoryId;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int CategoryId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_articlecategory ");
            strSql.Append(" where CategoryId=@CategoryId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@CategoryId", MySqlDbType.Int32)};
            parameters[0].Value = CategoryId;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
        public void GetModel(int CategoryId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CategoryId,Title,Sort,Type,ParentCategoryId,AddedUserId,AddedDate ");
            strSql.Append(" FROM t_articlecategory ");
            strSql.Append(" where CategoryId=@CategoryId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@CategoryId", MySqlDbType.Int32)};
            parameters[0].Value = CategoryId;

            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CategoryId"] != null && ds.Tables[0].Rows[0]["CategoryId"].ToString() != "")
                {
                    this.CategoryId = int.Parse(ds.Tables[0].Rows[0]["CategoryId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Title"] != null)
                {
                    this.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Sort"] != null && ds.Tables[0].Rows[0]["Sort"].ToString() != "")
                {
                    this.Sort = int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Type"] != null && ds.Tables[0].Rows[0]["Type"].ToString() != "")
                {
                    this.Type = int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentCategoryId"] != null && ds.Tables[0].Rows[0]["ParentCategoryId"].ToString() != "")
                {
                    this.ParentCategoryId = int.Parse(ds.Tables[0].Rows[0]["ParentCategoryId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddedUserId"] != null && ds.Tables[0].Rows[0]["AddedUserId"].ToString() != "")
                {
                    this.AddedUserId = int.Parse(ds.Tables[0].Rows[0]["AddedUserId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddedDate"] != null)
                {
                    this.AddedDate = ds.Tables[0].Rows[0]["AddedDate"].ToString();
                }
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM t_articlecategory ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        #endregion  Method
    }
}
