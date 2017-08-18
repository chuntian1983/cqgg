using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonUtility.DBUtility;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Modules.Department
{
    public class DepartmentCategoryDetail
    {
        public Int32 CategoryId;
        public string Title;
        public Int32 Sort;
        public Int32 ParentCategoryId;
        public Int32 AddedUserId;
        public string AddedDate;
        public string detpimg;
    }
    class DepartmentCategoryDAL
    {
        public DataSet GetAllCategoryItems()
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string query = "select * from T_DepartCategory ";
            return helper.ExecuteDataset(query);
        }
        public DataSet GetChildCategoryItems(Int32 parentCategoryId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string query = String.Format("select * from T_DepartCategory where ParentCategoryId={0}", parentCategoryId);
            return helper.ExecuteDataset(query);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DepartmentCategoryDetail model)
        {AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_DepartCategory(");
            strSql.Append("Title,Sort,ParentCategoryId,AddedUserId,AddedDate,deptimg)");
            strSql.Append(" values (");
            strSql.Append("@Title,@Sort,@ParentCategoryId,@AddedUserId,@AddedDate,@deptimg)");
            
            MySqlParameter[] parameters = {
					new MySqlParameter("@Title", MySqlDbType.VarChar,50),
					new MySqlParameter("@Sort", MySqlDbType.Int32,4),
					new MySqlParameter("@ParentCategoryId", MySqlDbType.Int32,4),
					new MySqlParameter("@AddedUserId", MySqlDbType.Int32,4),
					new MySqlParameter("@AddedDate", MySqlDbType.VarChar),
					new MySqlParameter("@deptimg", MySqlDbType.VarChar,500)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.Sort;
            parameters[2].Value = model.ParentCategoryId;
            parameters[3].Value = model.AddedUserId;
            parameters[4].Value = model.AddedDate;
            parameters[5].Value = model.detpimg;

            object obj =helper.ExecuteNonQuery(helper.connectionString,CommandType.Text, strSql.ToString(), parameters);
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
        public bool Update(DepartmentCategoryDetail model)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_DepartCategory set ");
            strSql.Append("Title=@Title,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("ParentCategoryId=@ParentCategoryId,");
            strSql.Append("AddedUserId=@AddedUserId,");
            strSql.Append("AddedDate=@AddedDate,");
            strSql.Append("deptimg=@deptimg");
            strSql.Append(" where CategoryId=@CategoryId");
            MySqlParameter[] parameters = {
					new MySqlParameter("@Title", MySqlDbType.VarChar,50),
					new MySqlParameter("@Sort", MySqlDbType.Int32,4),
					new MySqlParameter("@ParentCategoryId", MySqlDbType.Int32,4),
					new MySqlParameter("@AddedUserId", MySqlDbType.Int32,4),
					new MySqlParameter("@AddedDate", MySqlDbType.VarChar),
					new MySqlParameter("@deptimg", MySqlDbType.VarChar,500),
					new MySqlParameter("@CategoryId", MySqlDbType.Int32,4)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.Sort;
            parameters[2].Value = model.ParentCategoryId;
            parameters[3].Value = model.AddedUserId;
            parameters[4].Value = model.AddedDate;
            parameters[5].Value = model.detpimg;
            parameters[6].Value = model.CategoryId;

            Int32 rows =helper.ExecuteNonQuery(helper.connectionString,CommandType.Text, strSql.ToString(), parameters);
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
        public DepartmentCategoryDetail GetModel(Int32 CategoryId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   CategoryId,Title,Sort,ParentCategoryId,AddedUserId,AddedDate,deptimg from T_DepartCategory ");
            strSql.Append(" where CategoryId=@CategoryId");
            MySqlParameter[] parameters = {
					new MySqlParameter("@CategoryId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = CategoryId;

            DepartmentCategoryDetail model = new DepartmentCategoryDetail();
            DataSet ds = helper.ExecuteDataset(helper.connectionString,CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CategoryId"] != null && ds.Tables[0].Rows[0]["CategoryId"].ToString() != "")
                {
                    model.CategoryId = Int32.Parse(ds.Tables[0].Rows[0]["CategoryId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Title"] != null && ds.Tables[0].Rows[0]["Title"].ToString() != "")
                {
                    model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Sort"] != null && ds.Tables[0].Rows[0]["Sort"].ToString() != "")
                {
                    model.Sort = Int32.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentCategoryId"] != null && ds.Tables[0].Rows[0]["ParentCategoryId"].ToString() != "")
                {
                    model.ParentCategoryId = Int32.Parse(ds.Tables[0].Rows[0]["ParentCategoryId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddedUserId"] != null && ds.Tables[0].Rows[0]["AddedUserId"].ToString() != "")
                {
                    model.AddedUserId = Int32.Parse(ds.Tables[0].Rows[0]["AddedUserId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddedDate"] != null && ds.Tables[0].Rows[0]["AddedDate"].ToString() != "")
                {
                    model.AddedDate = ds.Tables[0].Rows[0]["AddedDate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["deptimg"] != null && ds.Tables[0].Rows[0]["deptimg"].ToString() != "")
                {
                    model.detpimg = ds.Tables[0].Rows[0]["deptimg"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        public Int32 AddCategory(string title, Int32 sort, Int32 parentCategoryId, Int32 addedUserId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            IDataParameter[] paras = new IDataParameter[5];
            paras[0] = helper.GetParameter("@Title", title);
            paras[1] = helper.GetParameter("@Sort", sort);
            paras[2] = helper.GetParameter("@ParentCategoryId", parentCategoryId);
            paras[3] = helper.GetParameter("@AddedUserId", addedUserId);
            paras[4] = helper.GetParameter("@CategoryId", DbType.Int32, 4, ParameterDirection.Output);
            helper.ExecuteNonQuery("sp_Depart_AddCategory", paras);
            return Convert.ToInt32(paras[4].Value);
        }
        public Int32 AddCategory(DepartmentCategoryDetail detail)
        {
            return AddCategory(detail.Title, detail.Sort,detail.ParentCategoryId, detail.AddedUserId);
        }

        public bool UpdateCategory(Int32 categoryId, string title, Int32 sort, Int32 parentCategoryId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("Update T_DepartCategory Set Title='{0}',Sort={1},ParentCategoryId={2}", title, sort, parentCategoryId);
            sql.AppendFormat(" where CategoryId={0}", categoryId);
            return helper.ExecuteNonQuery(sql.ToString()) > 0;
        }

        public bool UpdateCategory(DepartmentCategoryDetail detail)
        {
            return UpdateCategory(detail.CategoryId, detail.Title, detail.Sort, detail.ParentCategoryId);
        }

        public bool DeleteCategory(Int32[] categoryIds)
        {
            Int32 count = 0;
            foreach (Int32 categoryId in categoryIds)
            {
                //if (DeleteCategory(categoryId)) count++;
                if (DEL(categoryId)) count++;
            }
            return count == categoryIds.Length;
        }

        public bool DeleteCategory(Int32 categoryId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            IDataParameter[] paras = new IDataParameter[2];
            paras[0] = helper.GetParameter("@CategoryId", categoryId);
            paras[1] = helper.GetParameter("@Return", DbType.Int32, 4, ParameterDirection.Output);
            helper.ExecuteNonQuery("sp_Depart_DelCategory", paras);
            return Convert.ToBoolean(paras[1].Value);
        }
        public bool DEL(int cid)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
          
            string strsql = " delete from T_DepartCategory where CategoryId='"+cid+"'";
            int i= helper.ExecuteNonQuery(helper.connectionString, CommandType.Text, strsql);
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public DepartmentCategoryDetail GetCategoryDetail(Int32 categoryId)
        {
            return GetCategoryDetailFromDataRow(GetCategoryDataRow(categoryId));
        }
        public DataRow GetCategoryDataRow(Int32 categoryId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string query = String.Format("Select * from T_DepartCategory where CategoryId={0}", categoryId);
            DataSet ds = helper.ExecuteDataset(query);
            if (ds.Tables[0].Rows.Count == 1) return ds.Tables[0].Rows[0];
            return null;
        }
        private DepartmentCategoryDetail GetCategoryDetailFromDataRow(DataRow info)
        {
            if (info != null)
            {
                DepartmentCategoryDetail detail = new DepartmentCategoryDetail();
                detail.CategoryId = (Int32)info["CategoryId"];
                detail.Title = info["Title"].ToString();
                detail.Sort = (Int32)info["Sort"];
                detail.ParentCategoryId = (Int32)info["ParentCategoryId"];
                detail.AddedUserId = (Int32)info["AddedUserId"];
                detail.AddedDate = info["AddedDate"].ToString();
                detail.detpimg = info["deptimg"].ToString();
                return detail;
            }
            return null;
        }
    }
}

