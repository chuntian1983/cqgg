using System;
using System.Collections.Generic;
using System.Text;
using CommonUtility.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace Modules.City
{
   public class CityDAL
    {
       public CityDAL()
       { }

       //����ID,���һ�����е���Ϣ 
       public CityModal GetModel(int CityID)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select * from T_City ");
           strSql.Append(" where CityID=@CityID");
           SqlParameter[] parameters = {
					new SqlParameter("@CityID", SqlDbType.Int,4)};
           parameters[0].Value = CityID;
           CityModal model = new CityModal();
           DataSet ds = SQLHelper.Query(strSql.ToString(), parameters);
           model.CityID = CityID;
           if (ds.Tables[0].Rows.Count > 0)
           {
               model.CityName = ds.Tables[0].Rows[0]["CityName"].ToString();
               model.Code1 = ds.Tables[0].Rows[0]["Code1"].ToString();
               model.Code2 = ds.Tables[0].Rows[0]["Code2"].ToString();
               return model;
           }
           else
           {
               return null;
           }
       }

       //��������б�
       public DataSet GetList(string strWhere)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select * from T_City ");
           if (strWhere.Trim() != "")
           {
               strSql.Append(" where " + strWhere);
           }
           strSql.Append(" order by CityID ");
           return SQLHelper.Query(strSql.ToString());
       }

       //����һ������
       public void Add(CityModal model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into T_City(");
           strSql.Append("CityName,Code1,Code2)");
           strSql.Append(" values (");
           strSql.Append("@CityName,@Code1,@Code2)");
           SqlParameter[] parameters = {
					new SqlParameter("@CityName", SqlDbType.VarChar,100),
					new SqlParameter("@Code1", SqlDbType.VarChar,50),
					new SqlParameter("@Code2", SqlDbType.VarChar,50)};
           parameters[0].Value = model.CityName;
           parameters[1].Value = model.Code1;
           parameters[2].Value = model.Code2;

           SQLHelper.ExecuteSql(strSql.ToString(), parameters);
       }

       //����һ������
       public void Update(CityModal model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update T_City set ");
           strSql.Append("CityName=@CityName,");
           strSql.Append("Code1=@Code1,");
           strSql.Append("Code2=@Code2");
           strSql.Append(" where CityID=@CityID");
           SqlParameter[] parameters = {
					new SqlParameter("@CityID", SqlDbType.Int,4),
					new SqlParameter("@CityName", SqlDbType.VarChar,100),
					new SqlParameter("@Code1", SqlDbType.VarChar,50),
					new SqlParameter("@Code2", SqlDbType.VarChar,50)};
           parameters[0].Value = model.CityID;
           parameters[1].Value = model.CityName;
           parameters[2].Value = model.Code1;
           parameters[3].Value = model.Code2;

           SQLHelper.ExecuteSql(strSql.ToString(), parameters);
       }

       //ɾ��һ������
       public void Delete(int CityID)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete T_City ");
           strSql.Append(" where CityID=@CityID");
           SqlParameter[] parameters = {
					new SqlParameter("@CityID", SqlDbType.Int,4)
				};
           parameters[0].Value = CityID;
           SQLHelper.ExecuteSql(strSql.ToString(), parameters);
       }

    }
}
