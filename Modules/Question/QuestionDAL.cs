using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CommonUtility.DBUtility;

namespace Modules.Question
{
   public class QuestionDAL     
    {
       public QuestionDAL()
       { }
       #region  成员方法
       /// <summary>
       /// 是否存在该记录
       /// </summary>
       public bool Exists(int ID)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select count(1) from T_Online");
           strSql.Append(" where ID= @ID");
           SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
           parameters[0].Value = ID;
           return SQLHelper.Exists(strSql.ToString(), parameters);
       }


       /// <summary>
       /// 增加一条数据
       /// </summary>
       public void Add(QusetionModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into T_Online(");
           strSql.Append("Name,Age,Sex,Pid,Tel,LookTime,Info,State,AddDate,RegistID,Email,Title,Type,History)");
           strSql.Append(" values (");
           strSql.Append("@Name,@Age,@Sex,@Pid,@Tel,@LookTime,@Info,@State,@AddDate,@RegistID,@Email,@Title,@Type,@History)");
           SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,100),
					new SqlParameter("@Age", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@Pid", SqlDbType.VarChar,50),
					new SqlParameter("@Tel", SqlDbType.VarChar,50),
					new SqlParameter("@LookTime", SqlDbType.DateTime),
					new SqlParameter("@Info", SqlDbType.Text),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@RegistID", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,100),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@Type", SqlDbType.Int,4),
                    new SqlParameter("@History",SqlDbType.VarChar,1000)
           };
           parameters[0].Value = model.Name;
           parameters[1].Value = model.Age;
           parameters[2].Value = model.Sex;
           parameters[3].Value = model.Pid;
           parameters[4].Value = model.Tel;
           parameters[5].Value = model.LookTime;
           parameters[6].Value = model.Info;
           parameters[7].Value = model.State;
           parameters[8].Value = model.AddDate;
           parameters[9].Value = model.RegistID;
           parameters[10].Value = model.Email;
           parameters[11].Value = model.Title;
           parameters[12].Value = model.Type;
           parameters[13].Value = model.History;
           SQLHelper.ExecuteSql(strSql.ToString(), parameters);
       }
       /// <summary>
       /// 更新一条数据
       /// </summary>
       public void Update(QusetionModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update T_Online set ");
           strSql.Append("Name=@Name,");
           strSql.Append("Age=@Age,");
           strSql.Append("Sex=@Sex,");
           strSql.Append("Pid=@Pid,");
           strSql.Append("Tel=@Tel,");
           strSql.Append("LookTime=@LookTime,");
           strSql.Append("Info=@Info,");
           strSql.Append("State=@State,");
           strSql.Append("AddDate=@AddDate,");
           strSql.Append("RegistID=@RegistID,");
           strSql.Append("Email=@Email,");
           strSql.Append("Title=@Title,");
           strSql.Append("Type=@Type");
           strSql.Append("History=@History");
           strSql.Append(" where ID=@ID");
           SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.VarChar,100),
					new SqlParameter("@Age", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@Pid", SqlDbType.VarChar,50),
					new SqlParameter("@Tel", SqlDbType.VarChar,50),
					new SqlParameter("@LookTime", SqlDbType.DateTime),
					new SqlParameter("@Info", SqlDbType.Text),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@RegistID", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,100),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@Type", SqlDbType.Int,4),
                    new SqlParameter("@History",SqlDbType.VarChar,1000)
           };
           parameters[0].Value = model.ID;
           parameters[1].Value = model.Name;
           parameters[2].Value = model.Age;
           parameters[3].Value = model.Sex;
           parameters[4].Value = model.Pid;
           parameters[5].Value = model.Tel;
           parameters[6].Value = model.LookTime;
           parameters[7].Value = model.Info;
           parameters[8].Value = model.State;
           parameters[9].Value = model.AddDate;
           parameters[10].Value = model.RegistID;
           parameters[11].Value = model.Email;
           parameters[12].Value = model.Title;
           parameters[13].Value = model.Type;
           parameters[14].Value = model.History;
           SQLHelper.ExecuteSql(strSql.ToString(), parameters);
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public void Delete(int ID)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete T_Online ");
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
       public QusetionModel GetModel(int ID)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select * from T_Online ");
           strSql.Append(" where ID=@ID");
           SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
           parameters[0].Value = ID;
           QusetionModel model = new QusetionModel();
           DataSet ds = SQLHelper.Query(strSql.ToString(), parameters);
           model.ID = ID;
           if (ds.Tables[0].Rows.Count > 0)
           {
               model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
               model.Age = ds.Tables[0].Rows[0]["Age"].ToString();
               if (ds.Tables[0].Rows[0]["Sex"].ToString() != "")
               {
                   model.Sex = int.Parse(ds.Tables[0].Rows[0]["Sex"].ToString());
               }
               model.Pid = ds.Tables[0].Rows[0]["Pid"].ToString();
               model.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
               if (ds.Tables[0].Rows[0]["LookTime"].ToString() != "")
               {
                   model.LookTime = DateTime.Parse(ds.Tables[0].Rows[0]["LookTime"].ToString());
               }
               model.Info = ds.Tables[0].Rows[0]["Info"].ToString();
               if (ds.Tables[0].Rows[0]["State"].ToString() != "")
               {
                   model.State = int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
               }
               if (ds.Tables[0].Rows[0]["AddDate"].ToString() != "")
               {
                   model.AddDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
               }
               model.RegistID = ds.Tables[0].Rows[0]["RegistID"].ToString();
               model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
               model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
               if (ds.Tables[0].Rows[0]["Type"].ToString() != "")
               {
                   model.Type = int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
               }
               model.History = ds.Tables[0].Rows[0]["History"].ToString();
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
       //public DataSet GetList(string strWhere,int i)
    　　public DataSet GetList(string strWhere)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select * from T_Online ");
           if (strWhere.Trim() != "")
           {
               strSql.Append(" where " + strWhere);
           }
           //switch (i)
           //{
           //    //按序号升序排列
           //    case 1: strSql.Append(" order by ID "); break;
           //    //按预约时间降序排列
           //    case 2: strSql.Append("order by LookTime desc"); break;
           //    case 3: strSql.Append("order by Email desc"); break;
           //}
           strSql.Append("order by ADDDate desc"); 
           return SQLHelper.Query(strSql.ToString());
       }

       

       //更改审核状态
       public void ChangeState(string Id,string State)
       {
           string s = string.Empty;
           if (State == "0")
           {
               s ="1";
           }
           else
           {
               s = "0";
           }
           string sql = "Update T_Online set State='"+s+"' where ID='"+Id+"'";
           SQLHelper.ExecuteSql(sql);
       }

       //通过挂号单编号取得挂号信息
       public DataSet GetRegistInfoByRegistId(string registid)
       {
           string sql = "select * from T_Online where RegistID='" + registid + "'";
           return SQLHelper.Query(sql);
       }

        //得到已有回复的信息列表
       public DataSet GetRepeatInfo(int Type)
       {
           string sql = "select * from V_RepeatList  where Type=" + Type + " order by AddDate desc";
           return SQLHelper.Query(sql);
       }

       //根据问题编号取得回复信息及问题信息
       public DataSet GetARInfo(int QuestionId)
       {
           string sql = "select * from V_RepeatList where ID=" + QuestionId + "";
          return SQLHelper.Query(sql);
       }
      
       //更新回复状态
       public int UpdateState(string Id)
       {
           string sql = "Update T_Online set State=1 where ID='" + Id + "'";
           return SQLHelper.ExecuteSql(sql);
       }
       #endregion  成员方法
    }
}
