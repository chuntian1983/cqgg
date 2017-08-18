using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CommonUtility.DBUtility;

namespace Modules.Advertisement
{
   public class AdvertisementDAL
    {
       public AdvertisementDAL()
       { }
       	#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ADId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Advertisement");
			strSql.Append(" where ADId= @ADId");
			SqlParameter[] parameters = {
					new SqlParameter("@ADId", SqlDbType.Int,4)
				};
			parameters[0].Value = ADId;
		    return SQLHelper.Exists(strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(AdvertisementModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Advertisement(");
			strSql.Append("ADName,ADPic,Link,Sort,Plus,Type,State,Approved,FillTime)");
			strSql.Append(" values (");
			strSql.Append("@ADName,@ADPic,@Link,@Sort,@Plus,@Type,@State,@Approved,@FillTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@ADName", SqlDbType.VarChar,500),
					new SqlParameter("@ADPic", SqlDbType.VarChar,500),
					new SqlParameter("@Link", SqlDbType.VarChar,500),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Plus", SqlDbType.Text),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@Approved", SqlDbType.Int,4),
					new SqlParameter("@FillTime", SqlDbType.DateTime)};
			parameters[0].Value = model.ADName;
			parameters[1].Value = model.ADPic;
			parameters[2].Value = model.Link;
			parameters[3].Value = model.Sort;
			parameters[4].Value = model.Plus;
			parameters[5].Value = model.Type;
			parameters[6].Value = model.State;
			parameters[7].Value = model.Approved;
			parameters[8].Value = model.FillTime;

            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(AdvertisementModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Advertisement set ");
			strSql.Append("ADName=@ADName,");
			strSql.Append("ADPic=@ADPic,");
			strSql.Append("Link=@Link,");
			strSql.Append("Sort=@Sort,");
			strSql.Append("Plus=@Plus,");
			strSql.Append("Type=@Type,");
			strSql.Append("State=@State,");
			strSql.Append("Approved=@Approved,");
			strSql.Append("FillTime=@FillTime");
			strSql.Append(" where ADId=@ADId");
			SqlParameter[] parameters = {
					new SqlParameter("@ADId", SqlDbType.Int,4),
					new SqlParameter("@ADName", SqlDbType.VarChar,500),
					new SqlParameter("@ADPic", SqlDbType.VarChar,500),
					new SqlParameter("@Link", SqlDbType.VarChar,500),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Plus", SqlDbType.Text),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@Approved", SqlDbType.Int,4),
					new SqlParameter("@FillTime", SqlDbType.DateTime)};
			parameters[0].Value = model.ADId;
			parameters[1].Value = model.ADName;
			parameters[2].Value = model.ADPic;
			parameters[3].Value = model.Link;
			parameters[4].Value = model.Sort;
			parameters[5].Value = model.Plus;
			parameters[6].Value = model.Type;
			parameters[7].Value = model.State;
			parameters[8].Value = model.Approved;
			parameters[9].Value = model.FillTime;

            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ADId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete T_Advertisement ");
			strSql.Append(" where ADId=@ADId");
			SqlParameter[] parameters = {
					new SqlParameter("@ADId", SqlDbType.Int,4)
				};
			parameters[0].Value = ADId;
            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public AdvertisementModel GetModel(int ADId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from T_Advertisement ");
			strSql.Append(" where ADId=@ADId");
			SqlParameter[] parameters = {
					new SqlParameter("@ADId", SqlDbType.Int,4)};
			parameters[0].Value = ADId;
			AdvertisementModel model=new AdvertisementModel();
			DataSet ds=SQLHelper.Query(strSql.ToString(),parameters);
			model.ADId=ADId;
			if(ds.Tables[0].Rows.Count>0)
			{
				model.ADName=ds.Tables[0].Rows[0]["ADName"].ToString();
				model.ADPic=ds.Tables[0].Rows[0]["ADPic"].ToString();
				model.Link=ds.Tables[0].Rows[0]["Link"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				model.Plus=ds.Tables[0].Rows[0]["Plus"].ToString();
				if(ds.Tables[0].Rows[0]["Type"].ToString()!="")
				{
					model.Type=int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
				}
				if(ds.Tables[0].Rows[0]["State"].ToString()!="")
				{
					model.State=int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Approved"].ToString()!="")
				{
					model.Approved=int.Parse(ds.Tables[0].Rows[0]["Approved"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FillTime"].ToString()!="")
				{
					model.FillTime=DateTime.Parse(ds.Tables[0].Rows[0]["FillTime"].ToString());
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from T_Advertisement ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by Sort asc ");
            return SQLHelper.Query(strSql.ToString());
		}

        /// <summary>
        /// 取得首页广告列表
        /// </summary>
       public DataSet GetADList(int Num, int State)
       { 
            string sql="select top "+Num+" *  from T_Advertisement where State="+State+" and Approved=1 order by Sort Asc";
            return SQLHelper.Query(sql);
       }

       /// <summary>
       /// 取得推荐广告列表
       /// </summary>
       public DataSet GetTJADList(int Num)
       {
           string sql = "select top " + Num + " *  from T_Advertisement where Type=1 and Approved=1 and State=1 order by Sort Asc";
           return SQLHelper.Query(sql);
       }

        /// <summary>
        /// 改变审核状态
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="isApproved"></param>
       public void ChangeApprovedStatus(int ADId, bool isApproved)
        {
            string sql = String.Format("update T_Advertisement set Approved={0} where ADId={1}", isApproved ? 1 : 0, ADId);
            SQLHelper.ExecuteSql(sql);
        }

       //获得分页数据列表
       public DataSet GetArticleList(string fields, string filter, string sort, int currentPageIndex, int pageSize, out int recordCount)
       {
           return CommonUtility.PaginationUtility.GetPaginationList(fields, "T_Advertisement", filter, sort, currentPageIndex, pageSize, out recordCount);
       }
		#endregion  成员方法

    }
}
