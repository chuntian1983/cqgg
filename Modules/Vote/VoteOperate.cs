using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CommonUtility.DBUtility;

namespace Modules.Vote
{
   public  class VoteOperate
    {
      
       public VoteOperate()
       { }
    //修改过的 yangjie 根据投票主题编号ID添加投票类别信息，并返回投票类别的ID编号
		public int VoteTypeAdd(string VoteType,int voteID,int vouch)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
											new SqlParameter("@ID", SqlDbType.Int,4),
											new SqlParameter("@VoteType", SqlDbType.VarChar,50),
											new SqlParameter("@VoteID", SqlDbType.Int,4),
											new SqlParameter("@Vouch", SqlDbType.Int,4)
										};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = VoteType;
			parameters[2].Value = voteID;	
			parameters[3].Value = vouch;
            SQLHelper.RunProcedure("UP_T_VoteType_ADD", parameters, out rowsAffected);
			return (int)parameters[0].Value;
		}
		//修改过的　，杨杰，同时要修改存储过程  根据投票的主题，取得该主题下的投票类别
		public DataSet VoteTypeGetList1(int voteid)
		{
			SqlParameter[] parameters = {
											new SqlParameter("@VoteID", SqlDbType.Int,4)
										};
			parameters[0].Value = voteid;
            return SQLHelper.RunProcedure("UP_T_VoteType_GetList", parameters, "ds");
		}
		//添加的，杨杰，要添加一个存储过程，得所有的投票类别信息（未用到，需要时可添加）
		//-----------------------------------------------------------------------------
		public DataSet VoteTypeGetList()
		{
			SqlParameter[] parameters = {
										
										};

            return SQLHelper.RunProcedure("UP_T_VoteType_GetList1", parameters, "ds");
		}
		//-----------------------------------------------------------------------------

		//根据ID编号 取得该条投票类别信息的详细资料
		public DataSet VoteTypeGetList(string ID)
		{
			SqlParameter[] parameters = {
											new SqlParameter("@ID", SqlDbType.Int,4)
										};
			parameters[0].Value = ID;
            return SQLHelper.RunProcedure("UP_T_VoteType_GetListByID", parameters, "ds");
		}
		/// <summary>
		/// 在线调查
		/// </summary>
		/// <param name="ID"></param>
		/// <param name="Vouch"></param>
		//用来更新投票类别表的投票票数
		public void VoteTypeUpdate(int ID,string Vouch,string VoteType)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
											new SqlParameter("@ID", SqlDbType.Int,4),											
											new SqlParameter("@Vouch", SqlDbType.VarChar,50),
											new SqlParameter("@VoteType", SqlDbType.VarChar,50)
										};
			parameters[0].Value = ID;		
			parameters[1].Value = Vouch;
			parameters[2].Value = VoteType;

            SQLHelper.RunProcedure("UP_T_VoteType_Vouch_Update", parameters, out rowsAffected);
		}

		//根据投票类别表的ID，删除该条投票类别信息
		public void VoteTypeDelete(int ID)
		{

			int rowsAffected;
			SqlParameter[] parameters = {
											new SqlParameter("@ID", SqlDbType.Int,4)
										};
			parameters[0].Value = ID;
            SQLHelper.RunProcedure("UP_T_VoteType_Delete", parameters, out rowsAffected);
		}
		//新建的方法，同时要新建一个存储过程
		//根据投票主题编号VoteID，删除该投票主题下的所有投票类别信息
		public void VoteTypeDelete1(int VID)
		{

			int rowsAffected;
			SqlParameter[] parameters = {
											new SqlParameter("@VID", SqlDbType.Int,4)
										};
			parameters[0].Value = VID;
            SQLHelper.RunProcedure("UP_T_VoteType_Delete1", parameters, out rowsAffected);
		}

       public DataSet VoteTypeSumGetList()
       {
           SqlParameter[] parameters = { };
           return SQLHelper.RunProcedure("UP_T_VoteType_Sum_GetList", parameters, "ds");
       }

       //得到第一个推荐的投票主题
       public DataSet GetFirstSub()
       {
           string sql = "select top 1 * from T_Vote where Vouch=0 order by ID desc";
           return SQLHelper.Query(sql);
       }

       //根据投票主题编号取得投票类别名称
       public DataSet GetVoteTypeBySubId(int ID)
       {
           string sql = "select * from T_VoteType where VoteID=" + ID + "and Vouch= 0 order by ID asc";
           return SQLHelper.Query(sql);
       }
        //根据投票主题编号得到投票的总数
       public int GetSumTicket(int ID)
       {
           string sql = "SELECT  sum(VoteCount)as count FROM T_VoteType where Vouch='0'";
           return Int32.Parse(SQLHelper.GetSingle(sql).ToString());
       }
    }

}
