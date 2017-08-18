using System;
using System.Collections.Generic;
using System.Text;
using CommonUtility.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace Modules.Weather
{
   public class WeatherDAL
    {
       public WeatherDAL()
       { }
       #region  成员方法

       /// <summary>
       /// 是否存在该记录
       /// </summary>
       public bool Exists(WeatherModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select * from T_Weather where Place=@Place and DateDiff(day,FillTime,@FillTime)=0");
   
           SqlParameter[] parameters = {
					new SqlParameter("@Place",  SqlDbType.VarChar,500),
                    new SqlParameter("@FillTime", SqlDbType.DateTime)   
				};
           parameters[0].Value = model.Place;
           parameters[1].Value = model.FillTime;
           return SQLHelper.Exists(strSql.ToString(), parameters);
         
       }

       /// <summary>
       /// 增加一条数据
       /// </summary>
       public void Add(WeatherModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into system_Weather(");
           strSql.Append("Place,WeatherType,LowTemperature,HighTemperature,Content,dtFillTime,Windy,TomWeatherType,TomLowTemperature,TomHighTemperature,TomContent,TomWindy,ThirdWeatherType,ThirdLowTemperature,ThirdHighTemperature,ThirdContent,ThirdWindy)");
           strSql.Append(" values (");
           strSql.Append("@Place,@WeatherType,@LowTemperature,@HighTemperature,@Content,@dtFillTime,@Windy,@TomWeatherType,@TomLowTemperature,@TomHighTemperature,@TomContent,@TomWindy,@ThirdWeatherType,@ThirdLowTemperature,@ThirdHighTemperature,@ThirdContent,@ThirdWindy)");
           SqlParameter[] parameters = {
					new SqlParameter("@Place", SqlDbType.VarChar,100),
					new SqlParameter("@WeatherType", SqlDbType.VarChar,100),
					new SqlParameter("@LowTemperature", SqlDbType.VarChar,100),
					new SqlParameter("@HighTemperature", SqlDbType.VarChar,100),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@dtFillTime", SqlDbType.DateTime),
					new SqlParameter("@Windy", SqlDbType.VarChar,100),
					new SqlParameter("@TomWeatherType", SqlDbType.VarChar,100),
					new SqlParameter("@TomLowTemperature", SqlDbType.VarChar,100),
					new SqlParameter("@TomHighTemperature", SqlDbType.VarChar,100),
					new SqlParameter("@TomContent", SqlDbType.Text),
					new SqlParameter("@TomWindy", SqlDbType.VarChar,100),
					new SqlParameter("@ThirdWeatherType", SqlDbType.VarChar,100),
					new SqlParameter("@ThirdLowTemperature", SqlDbType.VarChar,100),
					new SqlParameter("@ThirdHighTemperature", SqlDbType.VarChar,100),
					new SqlParameter("@ThirdContent", SqlDbType.Text),
					new SqlParameter("@ThirdWindy", SqlDbType.VarChar,100)
					};
           parameters[0].Value = model.Place;
           parameters[1].Value = model.WeatherType;
           parameters[2].Value = model.LowTemperature;
           parameters[3].Value = model.HighTemperature;
           parameters[4].Value = model.Content;
           parameters[5].Value = model.dtFillTime;
           parameters[6].Value = model.Windy;
           parameters[7].Value = model.TomWeatherType;
           parameters[8].Value = model.TomLowTemperature;
           parameters[9].Value = model.TomHighTemperature;
           parameters[10].Value = model.TomContent;
           parameters[11].Value = model.TomWindy;
           parameters[12].Value = model.ThirdWeatherType;
           parameters[13].Value = model.ThirdLowTemperature;
           parameters[14].Value = model.ThirdHighTemperature;
           parameters[15].Value = model.ThirdContent;
           parameters[16].Value = model.ThirdWindy;
         

           SQLHelper.ExecuteSql(strSql.ToString(), parameters);
       }
       /// <summary>
       /// 更新一条数据
       /// </summary>
       public void Update(WeatherModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update T_Weather set ");
          // strSql.Append("Place=@Place,");
           strSql.Append("WeatherType=@WeatherType,");
           strSql.Append("LowTemperature=@LowTemperature,");
           strSql.Append("HighTemperature=@HighTemperature,");
           strSql.Append("Content=@Content,");
           strSql.Append("dtFillTime=@dtFillTime,");
           strSql.Append("Windy=@Windy,");
           strSql.Append("TomWeatherType=@TomWeatherType,");
           strSql.Append("TomLowTemperature=@TomLowTemperature,");
           strSql.Append("TomHighTemperature=@TomHighTemperature,");
           strSql.Append("TomContent=@TomContent,");
           strSql.Append("TomWindy=@TomWindy,");
           strSql.Append("ThirdWeatherType=@ThirdWeatherType,");
           strSql.Append("ThirdLowTemperature=@ThirdLowTemperature,");
           strSql.Append("ThirdHighTemperature=@ThirdHighTemperature,");
           strSql.Append("ThirdContent=@ThirdContent,");
           strSql.Append("ThirdWindy=@ThirdWindy,");
          // strSql.Append("FillTime=@FillTime");
           strSql.Append(" where Place=@Place and DateDiff(day,FillTime,@FillTime)=0");
           SqlParameter[] parameters = {
					//new SqlParameter("@ID", SqlDbType.Decimal,9),
					new SqlParameter("@Place", SqlDbType.VarChar,100),
					new SqlParameter("@WeatherType", SqlDbType.VarChar,100),
					new SqlParameter("@LowTemperature", SqlDbType.VarChar,100),
					new SqlParameter("@HighTemperature", SqlDbType.VarChar,100),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@dtFillTime", SqlDbType.DateTime),
					new SqlParameter("@Windy", SqlDbType.VarChar,100),
					new SqlParameter("@TomWeatherType", SqlDbType.VarChar,100),
					new SqlParameter("@TomLowTemperature", SqlDbType.VarChar,100),
					new SqlParameter("@TomHighTemperature", SqlDbType.VarChar,100),
					new SqlParameter("@TomContent", SqlDbType.Text),
					new SqlParameter("@TomWindy", SqlDbType.VarChar,100),
					new SqlParameter("@ThirdWeatherType", SqlDbType.VarChar,100),
					new SqlParameter("@ThirdLowTemperature", SqlDbType.VarChar,100),
					new SqlParameter("@ThirdHighTemperature", SqlDbType.VarChar,100),
					new SqlParameter("@ThirdContent", SqlDbType.Text),
					new SqlParameter("@ThirdWindy", SqlDbType.VarChar,100),
					new SqlParameter("@FillTime", SqlDbType.DateTime)};
           //parameters[0].Value = model.ID;
           parameters[0].Value = model.Place;
           parameters[1].Value = model.WeatherType;
           parameters[2].Value = model.LowTemperature;
           parameters[3].Value = model.HighTemperature;
           parameters[4].Value = model.Content;
           parameters[5].Value = model.dtFillTime;
           parameters[6].Value = model.Windy;
           parameters[7].Value = model.TomWeatherType;
           parameters[8].Value = model.TomLowTemperature;
           parameters[9].Value = model.TomHighTemperature;
           parameters[10].Value = model.TomContent;
           parameters[11].Value = model.TomWindy;
           parameters[12].Value = model.ThirdWeatherType;
           parameters[13].Value = model.ThirdLowTemperature;
           parameters[14].Value = model.ThirdHighTemperature;
           parameters[15].Value = model.ThirdContent;
           parameters[16].Value = model.ThirdWindy;
           parameters[17].Value = model.FillTime;


           SQLHelper.ExecuteSql(strSql.ToString(), parameters);
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public void Delete(decimal ID)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete system_Weather ");

           strSql.Append(" where ID=@ID");
           SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)
				};
           parameters[0].Value = ID;
           SQLHelper.ExecuteSql(strSql.ToString(), parameters);
       }


       //根据传入的条件来删除记录
       public void Delete1(string timeType)
       {
           StringBuilder strSql = new StringBuilder();
           if(timeType!="")
             strSql.Append("delete from t_weather where datediff(" + timeType + ",filltime,'" + System.DateTime.Now.ToShortDateString() + "')>0 ");
           else
               strSql.Append("delete system_Weather ");
      
           SQLHelper.ExecuteSql(strSql.ToString());
       }


       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public WeatherModel GetModel(decimal ID)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select * from T_Weather ");
           strSql.Append(" where ID=@ID");
           SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)};
           parameters[0].Value = ID;
           WeatherModel model = new WeatherModel();
           DataSet ds = SQLHelper.Query(strSql.ToString(), parameters);
           model.ID = ID;
           if (ds.Tables[0].Rows.Count > 0)
           {
               model.Place = ds.Tables[0].Rows[0]["Place"].ToString();
               model.WeatherType = ds.Tables[0].Rows[0]["WeatherType"].ToString();
               model.LowTemperature = ds.Tables[0].Rows[0]["LowTemperature"].ToString();
               model.HighTemperature = ds.Tables[0].Rows[0]["HighTemperature"].ToString();
               model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
               if (ds.Tables[0].Rows[0]["dtFillTime"].ToString() != "")
               {
                   model.dtFillTime = DateTime.Parse(ds.Tables[0].Rows[0]["dtFillTime"].ToString());
               }
               model.Windy = ds.Tables[0].Rows[0]["Windy"].ToString();
               model.TomWeatherType = ds.Tables[0].Rows[0]["TomWeatherType"].ToString();
               model.TomLowTemperature = ds.Tables[0].Rows[0]["TomLowTemperature"].ToString();
               model.TomHighTemperature = ds.Tables[0].Rows[0]["TomHighTemperature"].ToString();
               model.TomContent = ds.Tables[0].Rows[0]["TomContent"].ToString();
               model.TomWindy = ds.Tables[0].Rows[0]["TomWindy"].ToString();
               model.ThirdWeatherType = ds.Tables[0].Rows[0]["ThirdWeatherType"].ToString();
               model.ThirdLowTemperature = ds.Tables[0].Rows[0]["ThirdLowTemperature"].ToString();
               model.ThirdHighTemperature = ds.Tables[0].Rows[0]["ThirdHighTemperature"].ToString();
               model.ThirdContent = ds.Tables[0].Rows[0]["ThirdContent"].ToString();
               model.ThirdWindy = ds.Tables[0].Rows[0]["ThirdWindy"].ToString();
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
       /// 获得数据列表
       /// </summary>
       public DataSet GetList(string strWhere)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select * from system_Weather ");
           if (strWhere.Trim() != "")
           {
               strSql.Append(" where " + strWhere);
           }
           strSql.Append(" order by ID Desc");
           return SQLHelper.Query(strSql.ToString());
       }
       #endregion  成员方法

    }
}
