
using System;
using System.Collections.Generic;
using System.Text;
using CommonUtility.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace Modules.Vote
{
   public class VoteSubDAL
    {
       public VoteSubDAL()
       { }
       #region  成员方法

       //添加投票主题，并返回投票主题的编号
       public int Add(VoteSubModel model)
       {
           StringBuilder strSql = new StringBuilder();
           //strSql.Append("declare @ID;");
           strSql.Append("insert into T_Vote(");
           strSql.Append("Vote,FillTime,Vouch)");
           strSql.Append(" values (");
           strSql.Append("@Vote,@FillTime,@Vouch);");
           strSql.Append("select @@identity");

           SqlParameter[] parameters = {
											new SqlParameter("@ID", SqlDbType.Int,4),
											new SqlParameter("@Vote", SqlDbType.VarChar,50),
											new SqlParameter("@FillTime", SqlDbType.DateTime),
											new SqlParameter("@Vouch", SqlDbType.Int,4)};
           parameters[0].Direction = ParameterDirection.Output;
           parameters[1].Value = model.Vote;
           parameters[2].Value = model.FillTime;
           parameters[3].Value = model.Vouch;



           return Int32.Parse((SQLHelper.GetSingle(strSql.ToString(), parameters).ToString()));

       }
       /// <summary>
       /// 更新一条数据
       /// </summary>
       public void Update(VoteSubModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update T_Vote set ");
           strSql.Append("Vote=@Vote,");
           strSql.Append("FillTime=@FillTime,");
           strSql.Append("Vouch=@Vouch");
           strSql.Append(" where ID=@ID");
           SqlParameter[] parameters = {
											new SqlParameter("@ID", SqlDbType.Int,4),
											new SqlParameter("@Vote", SqlDbType.VarChar,50),
											new SqlParameter("@FillTime", SqlDbType.DateTime),
											new SqlParameter("@Vouch", SqlDbType.Int,4)};
           parameters[0].Value = model.ID;
           parameters[1].Value = model.Vote;
           parameters[2].Value = model.FillTime;
           parameters[3].Value = model.Vouch;

           SQLHelper.ExecuteSql(strSql.ToString(), parameters);
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public void Delete(int ID)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete T_Vote ");
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
       public VoteSubModel GetModel(int ID)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select * from T_Vote ");
           strSql.Append(" where ID=@ID");
           SqlParameter[] parameters = {
											new SqlParameter("@ID", SqlDbType.Int,4)};
           parameters[0].Value = ID;
           VoteSubModel model = new VoteSubModel();
           DataSet ds = SQLHelper.Query(strSql.ToString(), parameters);
           model.ID = ID;
           if (ds.Tables[0].Rows.Count > 0)
           {
               model.Vote = ds.Tables[0].Rows[0]["Vote"].ToString();
               if (ds.Tables[0].Rows[0]["FillTime"].ToString() != "")
               {
                   model.FillTime = DateTime.Parse(ds.Tables[0].Rows[0]["FillTime"].ToString());
               }
               if (ds.Tables[0].Rows[0]["Vouch"].ToString() != "")
               {
                   model.Vouch = int.Parse(ds.Tables[0].Rows[0]["Vouch"].ToString());
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
           strSql.Append("select * from T_Vote ");
           if (strWhere.Trim() != "")
           {
               strSql.Append(" where " + strWhere);
           }
           strSql.Append(" order by ID ");
           return SQLHelper.Query(strSql.ToString());
       }

       //得到首页显示的投票主题
       public DataSet GetIndexSub()
       {
           string sql = "select a.Vote, b.* from T_Vote a inner join T_VoteType b on a.ID=b.VoteID where b.vouch=0 and a.Vouch=0";
           return SQLHelper.Query(sql);

       }

       //更新投票票数
       public int UpdateVoteCount(int id)
       {
           string sql = "update T_VoteType set VoteCount = VoteCount+1 where ID="+id+"";
            return  SQLHelper.ExecuteSql(sql);
       }


       #endregion  成员方法
    }
}
