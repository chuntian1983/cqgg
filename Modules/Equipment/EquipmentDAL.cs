using System;
using System.Collections.Generic;
using System.Text;
using CommonUtility.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace Modules.Equipment
{
  public  class EquipmentDAL
    {
      public EquipmentDAL()
      {}
      #region  ��Ա����
      /// <summary>
      /// �Ƿ���ڸü�¼
      /// </summary>
      public bool Exists(int EquipmentId)
      {
          StringBuilder strSql = new StringBuilder();
          strSql.Append("select count(1) from T_Equipmnet");
          strSql.Append(" where EquipmentId= @EquipmentId");
          SqlParameter[] parameters = {
					new SqlParameter("@EquipmentId", SqlDbType.Int,4)
				};
          parameters[0].Value = EquipmentId;
          return SQLHelper.Exists(strSql.ToString(), parameters);
      }


      /// <summary>
      /// ����һ������
      /// </summary>
      public void Add(EquipmentModel model)
      {
          StringBuilder strSql = new StringBuilder();
          strSql.Append("insert into T_Equipmnet(");
          strSql.Append("EquipmentName,EquipmentPic,Sort,Info,FillTime)");
          strSql.Append(" values (");
          strSql.Append("@EquipmentName,@EquipmentPic,@Sort,@Info,@FillTime)");
          SqlParameter[] parameters = {
					new SqlParameter("@EquipmentName", SqlDbType.VarChar,500),
					new SqlParameter("@EquipmentPic", SqlDbType.VarChar,500),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Info", SqlDbType.Text),
					new SqlParameter("@FillTime", SqlDbType.DateTime)};
          parameters[0].Value = model.EquipmentName;
          parameters[1].Value = model.EquipmentPic;
          parameters[2].Value = model.Sort;
          parameters[3].Value = model.Info;
          parameters[4].Value = model.FillTime;

          SQLHelper.ExecuteSql(strSql.ToString(), parameters);
      }
      /// <summary>
      /// ����һ������
      /// </summary>
      public void Update(EquipmentModel model)
      {
          StringBuilder strSql = new StringBuilder();
          strSql.Append("update T_Equipmnet set ");
          strSql.Append("EquipmentName=@EquipmentName,");
          strSql.Append("EquipmentPic=@EquipmentPic,");
          strSql.Append("Sort=@Sort,");
          strSql.Append("Info=@Info,");
          strSql.Append("FillTime=@FillTime");
          strSql.Append(" where EquipmentId=@EquipmentId");
          SqlParameter[] parameters = {
					new SqlParameter("@EquipmentId", SqlDbType.Int,4),
					new SqlParameter("@EquipmentName", SqlDbType.VarChar,500),
					new SqlParameter("@EquipmentPic", SqlDbType.VarChar,500),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Info", SqlDbType.Text),
					new SqlParameter("@FillTime", SqlDbType.DateTime)};
          parameters[0].Value = model.EquipmentId;
          parameters[1].Value = model.EquipmentName;
          parameters[2].Value = model.EquipmentPic;
          parameters[3].Value = model.Sort;
          parameters[4].Value = model.Info;
          parameters[5].Value = model.FillTime;

          SQLHelper.ExecuteSql(strSql.ToString(), parameters);
      }

      /// <summary>
      /// ɾ��һ������
      /// </summary>
      public void Delete(int EquipmentId)
      {
          StringBuilder strSql = new StringBuilder();
          strSql.Append("delete T_Equipmnet ");
          strSql.Append(" where EquipmentId=@EquipmentId");
          SqlParameter[] parameters = {
					new SqlParameter("@EquipmentId", SqlDbType.Int,4)
				};
          parameters[0].Value = EquipmentId;
          SQLHelper.ExecuteSql(strSql.ToString(), parameters);
      }


      /// <summary>
      /// �õ�һ������ʵ��
      /// </summary>
      public EquipmentModel GetModel(int EquipmentId)
      {
          StringBuilder strSql = new StringBuilder();
          strSql.Append("select * from T_Equipmnet ");
          strSql.Append(" where EquipmentId=@EquipmentId");
          SqlParameter[] parameters = {
					new SqlParameter("@EquipmentId", SqlDbType.Int,4)};
          parameters[0].Value = EquipmentId;
          EquipmentModel model = new EquipmentModel();
          DataSet ds = SQLHelper.Query(strSql.ToString(), parameters);
          model.EquipmentId = EquipmentId;
          if (ds.Tables[0].Rows.Count > 0)
          {
              model.EquipmentName = ds.Tables[0].Rows[0]["EquipmentName"].ToString();
              model.EquipmentPic = ds.Tables[0].Rows[0]["EquipmentPic"].ToString();
              if (ds.Tables[0].Rows[0]["Sort"].ToString() != "")
              {
                  model.Sort = int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
              }
              model.Info = ds.Tables[0].Rows[0]["Info"].ToString();
              if (ds.Tables[0].Rows[0]["FillTime"].ToString() != "")
              {
                  model.FillTime = DateTime.Parse(ds.Tables[0].Rows[0]["FillTime"].ToString());
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
          StringBuilder strSql = new StringBuilder();
          strSql.Append("select * from T_Equipmnet ");
          if (strWhere.Trim() != "")
          {
              strSql.Append(" where " + strWhere);
          }
          strSql.Append(" order by FillTime desc ");
          return SQLHelper.Query(strSql.ToString());
      }
      #endregion  ��Ա����

    }
}
