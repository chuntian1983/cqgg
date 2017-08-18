using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CommonUtility.DBUtility;

namespace Modules.Applyforjob
{
   public class CollectDAL
    {
       public CollectDAL()
       { }
       #region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int CollectId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from R_Job_Collect");
			strSql.Append(" where CollectId= @CollectId");
			SqlParameter[] parameters = {
					new SqlParameter("@CollectId", SqlDbType.Int,4)
				};
			parameters[0].Value = CollectId;
		return SQLHelper.Exists(strSql.ToString(), parameters);
		}


        /// <summary>
        /// ������˻�Ա����ø�λ�����ӦƸ��Ϣ��¼����
        /// </summary>
        /// <param name="ID"></param>
       public void InsertSent(int UserId, int PostId)
       {
           string sql = "Insert into R_Job_SendOffer (SeekerId,PostId) values(" + UserId + "," + PostId + ")";
           SQLHelper.ExecuteSql(sql);
       }


		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(R_Job_CollectModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into R_Job_Collect(");
			strSql.Append("PostId,UsetId,SendDate,CollectDate,Type)");
			strSql.Append(" values (");
			strSql.Append("@PostId,@UsetId,@SendDate,@CollectDate,@Type)");
			SqlParameter[] parameters = {
					new SqlParameter("@PostId", SqlDbType.Int,4),
					new SqlParameter("@UsetId", SqlDbType.Int,4),
					new SqlParameter("@SendDate", SqlDbType.DateTime),
					new SqlParameter("@CollectDate", SqlDbType.DateTime),
					new SqlParameter("@Type", SqlDbType.Int,4)};
			parameters[0].Value = model.PostId;
			parameters[1].Value = model.UsetId;
			parameters[2].Value = model.SendDate;
			parameters[3].Value = model.CollectDate;
			parameters[4].Value = model.Type;

            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
       public void Update(R_Job_CollectModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update R_Job_Collect set ");
			strSql.Append("PostId=@PostId,");
			strSql.Append("UsetId=@UsetId,");
			strSql.Append("SendDate=@SendDate,");
			strSql.Append("CollectDate=@CollectDate,");
			strSql.Append("Type=@Type");
			strSql.Append(" where CollectId=@CollectId");
			SqlParameter[] parameters = {
					new SqlParameter("@CollectId", SqlDbType.Int,4),
					new SqlParameter("@PostId", SqlDbType.Int,4),
					new SqlParameter("@UsetId", SqlDbType.Int,4),
					new SqlParameter("@SendDate", SqlDbType.DateTime),
					new SqlParameter("@CollectDate", SqlDbType.DateTime),
					new SqlParameter("@Type", SqlDbType.Int,4)};
			parameters[0].Value = model.CollectId;
			parameters[1].Value = model.PostId;
			parameters[2].Value = model.UsetId;
			parameters[3].Value = model.SendDate;
			parameters[4].Value = model.CollectDate;
			parameters[5].Value = model.Type;

            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int CollectId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete R_Job_Collect ");
			strSql.Append(" where CollectId=@CollectId");
			SqlParameter[] parameters = {
					new SqlParameter("@CollectId", SqlDbType.Int,4)
				};
			parameters[0].Value = CollectId;
            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
       public R_Job_CollectModel GetModel(int CollectId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from R_Job_Collect ");
			strSql.Append(" where CollectId=@CollectId");
			SqlParameter[] parameters = {
					new SqlParameter("@CollectId", SqlDbType.Int,4)};
			parameters[0].Value = CollectId;
            R_Job_CollectModel model = new R_Job_CollectModel();
            DataSet ds = SQLHelper.Query(strSql.ToString(), parameters);
			model.CollectId=CollectId;
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["PostId"].ToString()!="")
				{
					model.PostId=int.Parse(ds.Tables[0].Rows[0]["PostId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UsetId"].ToString()!="")
				{
					model.UsetId=int.Parse(ds.Tables[0].Rows[0]["UsetId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SendDate"].ToString()!="")
				{
					model.SendDate=DateTime.Parse(ds.Tables[0].Rows[0]["SendDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CollectDate"].ToString()!="")
				{
					model.CollectDate=DateTime.Parse(ds.Tables[0].Rows[0]["CollectDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type"].ToString()!="")
				{
					model.Type=int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
				}
				return model;
			}
			else
			{
			return null;
			}
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from R_Job_Collect ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by CollectId ");
            return SQLHelper.Query(strSql.ToString());
		}

        /// <summary>
        /// �����û�����ź͸�λ��ŵõ���¼������(0:���ղ� 1:������)
        /// </summary>
        /// <param name="MemberId"></param>
        /// <param name="PostId"></param>
        /// <returns></returns>
        public DataSet CheceCollectInfo(int MemberId, int PostId)
        {
            string sql = "select * from V_YPGRList where UserID=" + MemberId + " and PostId=" + PostId + "";
            return SQLHelper.Query(sql);
        }
		#endregion  ��Ա����
	
   }

    #region R_Job_CollectModel
    public class R_Job_CollectModel
    {
        public R_Job_CollectModel()
        { }
        #region Model
        private int _collectid;
        private int _postid;
        private int _usetid;
        private DateTime _senddate;
        private DateTime _collectdate;
        private int _type;
        /// <summary>
        /// ���˻�Ա��λ(�ղ�/����)
        /// </summary>
        public int CollectId
        {
            set { _collectid = value; }
            get { return _collectid; }
        }
        /// <summary>
        /// ӦƸ��λ���
        /// </summary>
        public int PostId
        {
            set { _postid = value; }
            get { return _postid; }
        }
        /// <summary>
        /// �û����
        /// </summary>
        public int UsetId
        {
            set { _usetid = value; }
            get { return _usetid; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime SendDate
        {
            set { _senddate = value; }
            get { return _senddate; }
        }
        /// <summary>
        /// �ղ�ʱ��
        /// </summary>
        public DateTime CollectDate
        {
            set { _collectdate = value; }
            get { return _collectdate; }
        }
        /// <summary>
        /// 0:�ղ� 1:����
        /// </summary>
        public int Type
        {
            set { _type = value; }
            get { return _type; }
        }
        #endregion Model
    }
    #endregion
}
