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
    //�޸Ĺ��� yangjie ����ͶƱ������ID���ͶƱ�����Ϣ��������ͶƱ����ID���
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
		//�޸Ĺ��ġ�����ܣ�ͬʱҪ�޸Ĵ洢����  ����ͶƱ�����⣬ȡ�ø������µ�ͶƱ���
		public DataSet VoteTypeGetList1(int voteid)
		{
			SqlParameter[] parameters = {
											new SqlParameter("@VoteID", SqlDbType.Int,4)
										};
			parameters[0].Value = voteid;
            return SQLHelper.RunProcedure("UP_T_VoteType_GetList", parameters, "ds");
		}
		//��ӵģ���ܣ�Ҫ���һ���洢���̣������е�ͶƱ�����Ϣ��δ�õ�����Ҫʱ����ӣ�
		//-----------------------------------------------------------------------------
		public DataSet VoteTypeGetList()
		{
			SqlParameter[] parameters = {
										
										};

            return SQLHelper.RunProcedure("UP_T_VoteType_GetList1", parameters, "ds");
		}
		//-----------------------------------------------------------------------------

		//����ID��� ȡ�ø���ͶƱ�����Ϣ����ϸ����
		public DataSet VoteTypeGetList(string ID)
		{
			SqlParameter[] parameters = {
											new SqlParameter("@ID", SqlDbType.Int,4)
										};
			parameters[0].Value = ID;
            return SQLHelper.RunProcedure("UP_T_VoteType_GetListByID", parameters, "ds");
		}
		/// <summary>
		/// ���ߵ���
		/// </summary>
		/// <param name="ID"></param>
		/// <param name="Vouch"></param>
		//��������ͶƱ�����ͶƱƱ��
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

		//����ͶƱ�����ID��ɾ������ͶƱ�����Ϣ
		public void VoteTypeDelete(int ID)
		{

			int rowsAffected;
			SqlParameter[] parameters = {
											new SqlParameter("@ID", SqlDbType.Int,4)
										};
			parameters[0].Value = ID;
            SQLHelper.RunProcedure("UP_T_VoteType_Delete", parameters, out rowsAffected);
		}
		//�½��ķ�����ͬʱҪ�½�һ���洢����
		//����ͶƱ������VoteID��ɾ����ͶƱ�����µ�����ͶƱ�����Ϣ
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

       //�õ���һ���Ƽ���ͶƱ����
       public DataSet GetFirstSub()
       {
           string sql = "select top 1 * from T_Vote where Vouch=0 order by ID desc";
           return SQLHelper.Query(sql);
       }

       //����ͶƱ������ȡ��ͶƱ�������
       public DataSet GetVoteTypeBySubId(int ID)
       {
           string sql = "select * from T_VoteType where VoteID=" + ID + "and Vouch= 0 order by ID asc";
           return SQLHelper.Query(sql);
       }
        //����ͶƱ�����ŵõ�ͶƱ������
       public int GetSumTicket(int ID)
       {
           string sql = "SELECT  sum(VoteCount)as count FROM T_VoteType where Vouch='0'";
           return Int32.Parse(SQLHelper.GetSingle(sql).ToString());
       }
    }

}
