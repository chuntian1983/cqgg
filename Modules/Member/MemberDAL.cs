using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CommonUtility.DBUtility;
using myjmail;


namespace Modules.Member
{
   public class MemberDAL
    {
       public MemberDAL()
       { }
       #region  成员方法
       /// <summary>
       /// 是否存在该记录,用于遗忘密码的取回判断
       /// </summary>
       public bool Exists1(string Nickname,string Province,string City)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select count(1) from T_Member");
           strSql.Append(" where Nickname= @Nickname and Province=@Province and City=@City");
           SqlParameter[] parameters = {
					new SqlParameter("@Nickname", SqlDbType.VarChar,50),
                    new SqlParameter("@Province", SqlDbType.VarChar,500),
                    new SqlParameter("@City", SqlDbType.VarChar,500)
				};
           parameters[0].Value = Nickname;
           parameters[1].Value = Province;
           parameters[2].Value = City;
           return SQLHelper.Exists(strSql.ToString(), parameters);
       }

       /// <summary>
       /// 是否存在该记录,用于用户注册时候判断是否有重名
       /// </summary>
       public bool Exists(string Nickname)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select count(1) from T_Member");
           strSql.Append(" where Nickname= @Nickname");
           SqlParameter[] parameters = {
					new SqlParameter("@Nickname", SqlDbType.VarChar,50)
				};
           parameters[0].Value = Nickname;
           return SQLHelper.Exists(strSql.ToString(), parameters);
       }



       /// <summary>
       ///  增加一条数据
       /// </summary>
       public int Add(MemberModel model)
       {
           int rowsAffected;
           SqlParameter[] parameters = {
					new SqlParameter("@MemberId", SqlDbType.Int,4),
					new SqlParameter("@Nickname", SqlDbType.VarChar,50),
					new SqlParameter("@Password", SqlDbType.VarChar,50),
					new SqlParameter("@Realname", SqlDbType.VarChar,50),
					new SqlParameter("@Province", SqlDbType.VarChar,500),
					new SqlParameter("@City", SqlDbType.VarChar,500),
					new SqlParameter("@Address", SqlDbType.VarChar,100),
					new SqlParameter("@Postalcode", SqlDbType.VarChar,500),
					new SqlParameter("@Tel", SqlDbType.VarChar,500),
					new SqlParameter("@Email", SqlDbType.VarChar,500),
					new SqlParameter("@Remark", SqlDbType.VarChar,2000),
					new SqlParameter("@RegisterType", SqlDbType.Int,4),
					new SqlParameter("@AddedDate", SqlDbType.DateTime),
					new SqlParameter("@Approved", SqlDbType.Int,4)};
           parameters[0].Direction = ParameterDirection.Output;
           parameters[1].Value = model.Nickname;
           parameters[2].Value = model.Password;
           parameters[3].Value = model.Realname;
           parameters[4].Value = model.Province;
           parameters[5].Value = model.City;
           parameters[6].Value = model.Address;
           parameters[7].Value = model.Postalcode;
           parameters[8].Value = model.Tel;
           parameters[9].Value = model.Email;
           parameters[10].Value = model.Remark;
           parameters[11].Value = model.RegisterType;
           parameters[12].Value = model.AddedDate;
           parameters[13].Value = model.Approved;

           SQLHelper.RunProcedure("UP_T_Member_ADD", parameters, out rowsAffected);
           return (int)parameters[0].Value;
       }

       /// <summary>
       /// 更新一条数据
       /// </summary>
       public void Update(MemberModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update T_Member set ");
           strSql.Append("Nickname=@Nickname,");
           strSql.Append("Password=@Password,");
           strSql.Append("Realname=@Realname,");
           strSql.Append("Province=@Province,");
           strSql.Append("City=@City,");
           strSql.Append("Address=@Address,");
           strSql.Append("Postalcode=@Postalcode,");
           strSql.Append("Tel=@Tel,");
           strSql.Append("Email=@Email,");
           strSql.Append("Remark=@Remark,");
           strSql.Append("RegisterType=@RegisterType,");
           strSql.Append("AddedDate=@AddedDate,");
           strSql.Append("Approved=@Approved");
           strSql.Append(" where MemberId=@MemberId");
           SqlParameter[] parameters = {
					new SqlParameter("@MemberId", SqlDbType.Int,4),
					new SqlParameter("@Nickname", SqlDbType.VarChar,50),
					new SqlParameter("@Password", SqlDbType.VarChar,50),
					new SqlParameter("@Realname", SqlDbType.VarChar,50),
					new SqlParameter("@Province", SqlDbType.VarChar,50),
					new SqlParameter("@City", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,100),
					new SqlParameter("@Postalcode", SqlDbType.VarChar,50),
					new SqlParameter("@Tel", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,2000),
					new SqlParameter("@RegisterType", SqlDbType.Int,4),
					new SqlParameter("@AddedDate", SqlDbType.DateTime),
					new SqlParameter("@Approved", SqlDbType.Int,4)};
           parameters[0].Value = model.MemberId;
           parameters[1].Value = model.Nickname;
           parameters[2].Value = model.Password;
           parameters[3].Value = model.Realname;
           parameters[4].Value = model.Province;
           parameters[5].Value = model.City;
           parameters[6].Value = model.Address;
           parameters[7].Value = model.Postalcode;
           parameters[8].Value = model.Tel;
           parameters[9].Value = model.Email;
           parameters[10].Value = model.Remark;
           parameters[11].Value = model.RegisterType;
           parameters[12].Value = model.AddedDate;
           parameters[13].Value = model.Approved;

           SQLHelper.ExecuteSql(strSql.ToString(), parameters);
       }

       /// <summary>
       /// 删除一条数据(T_Member表)
       /// </summary>
       public void Delete(int MemberId)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete T_Member ");
           strSql.Append(" where MemberId=@MemberId");
           SqlParameter[] parameters = {
					new SqlParameter("@MemberId", SqlDbType.Int,4)
				};
           parameters[0].Value = MemberId;
           SQLHelper.ExecuteSql(strSql.ToString(), parameters);
       }

       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public MemberModel GetModel(int MemberId)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select * from T_Member ");
           strSql.Append(" where MemberId=@MemberId");
           SqlParameter[] parameters = {
					new SqlParameter("@MemberId", SqlDbType.Int,4)};
           parameters[0].Value = MemberId;
           MemberModel model = new MemberModel();
           DataSet ds = SQLHelper.Query(strSql.ToString(), parameters);
           model.MemberId = MemberId;
           if (ds.Tables[0].Rows.Count > 0)
           {
               model.Nickname = ds.Tables[0].Rows[0]["Nickname"].ToString();
               model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
               model.Realname = ds.Tables[0].Rows[0]["Realname"].ToString();
               model.Province = ds.Tables[0].Rows[0]["Province"].ToString();
               model.City = ds.Tables[0].Rows[0]["City"].ToString();
               model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
               model.Postalcode = ds.Tables[0].Rows[0]["Postalcode"].ToString();
               model.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
               model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
               model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
               if (ds.Tables[0].Rows[0]["RegisterType"].ToString() != "")
               {
                   model.RegisterType = int.Parse(ds.Tables[0].Rows[0]["RegisterType"].ToString());
               }
               if (ds.Tables[0].Rows[0]["AddedDate"].ToString() != "")
               {
                   model.AddedDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddedDate"].ToString());
               }
               if (ds.Tables[0].Rows[0]["Approved"].ToString() != "")
               {
                   model.Approved = int.Parse(ds.Tables[0].Rows[0]["Approved"].ToString());
               }
               return model;
           }
           else
           {
               return null;
           }
       }
        
       /// <summary>
       /// 获得数据列表(企业会员)
       /// </summary>
       public DataSet GetList(string strWhere)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select * from V_CompanyInfo ");
           if (strWhere.Trim() != "")
           {
               strSql.Append(" where " + strWhere);
           }
           strSql.Append(" order by MemberId desc");
           return SQLHelper.Query(strSql.ToString());
       }


       /// <summary>
       /// 获得数据列表(个人会员)
       /// </summary>
       public DataSet GetList1(string strWhere)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select * from V_PersonalInfo ");
           if (strWhere.Trim() != "")
           {
               strSql.Append(" where " + strWhere);
           }
           strSql.Append(" order by MemberId desc ");
           return SQLHelper.Query(strSql.ToString());
       }
      

       //改变审核状态
       public void ApproveMember(int memberId, bool isApproved)
       {
           string sql = String.Format("update T_Member set Approved={0} where MemberId={1}", isApproved ? 1 : 0, memberId);
           SQLHelper.ExecuteSql(sql);
       }


       //根据企业会员编号取得企业会员信息 2007-11-26
       public DataSet GetCompanyInfo(int memberId)
       {
           string sql = "select * from V_CompanyInfo where UserId=" + memberId + "";
           return SQLHelper.Query(sql);
       }
       //根据企业会员用户名,密码取得用户信息
       public DataSet GetCompanyInfo1(string nickname, string pwd)
       {
           string sql = "select * from T_Member where NickName='" + nickname + "' and PassWord='" + pwd + "' and Approved=1 and RegisterType=1";
           return SQLHelper.Query(sql);
       }

       //根据个人会员编号取得个人会员信息　2007-11-26
       public DataSet GetPersonalInfo(int memberId)
       {
           string sql = "select * from V_PersonalInfo where MemberId="+memberId+"";
           return SQLHelper.Query(sql);
       }
       //根据个人会员用户名,密码取得用户信息
       public DataSet GetPersonalInfo1(string nickname,string pwd)
       {
           string sql = "select * from T_Member where NickName='" + nickname + "' and Password='" + pwd + "' and Approved=1 and RegisterType=0";
           return SQLHelper.Query(sql);
       }

       //根据会员编号取得会员类型
       public int GetType(int MemberID)
       {
           string sql = "select RegisterType from T_Member where MemberId=" + MemberID + "";
           return Int32.Parse(SQLHelper.GetSingle(sql).ToString());
       }
      
       //更改用户密码(忘记密码的取回)
       public void UpDateMemberPwd(string nickname,string pwd,string Remark)
       {
           string sql = "update T_Member set Password='" + pwd + "',Remark='" + Remark + "' where NickName='" + nickname + "'";
           SQLHelper.ExecuteSql(sql);
       }

       //更改用户密码
       public void UpDateMemberPwd1(int MemberId, string pwd, string Remark)
       {
           string sql = "update T_Member set Password='" + pwd + "',Remark='" + Remark + "' where MemberId=" + MemberId + "";
           SQLHelper.ExecuteSql(sql);
       }

       //根据用户名取得用户密码查询问题和密码查询答案
       public DataSet GetPassWord(string nickname)
       {
           string sql = "select * from T_Member where NickName='" + nickname + "'";
           return SQLHelper.Query(sql);
       }

       //发送邮件
       public void SentEmail(string nickname,string email)
       {
               //try
               //{
                   myjmail.Message Jmail = new myjmail.Message();
               
                       DateTime t = DateTime.Now;
                       String Subject = "－－－杭州拱墅人才网密码重置信息－－－";
                       String body = "尊敬的用户：" +" "+nickname +"" + "<br>" + "您的登录密码已被重新设定为：123456,为了保证您的密码安全，请尽快登录网站修改！" + "<br>" + "<a href='http://www.sina.com.cn' target='_blank'>" + "修改密码请点击" + "</a>" + "<br>";
                       String FromEmail = "cattle_12345@163.com";
                       //String ToEmail = "zhuping@hzqts.gov.cn";
                       String ToEmail = email;
                       //Silent属性：如果设置为true,JMail不会抛出例外错误. JMail. Send( () 会根据操作结果返回true或false
                       Jmail.Silent = false;
                       //Jmail创建的日志，前提loging属性设置为true
                       Jmail.Logging = true;
                       //字符集，缺省为"US-ASCII"
                       Jmail.Charset = "GB2312";
                       //信件的contentype. 缺省是"text/plain"） : 字符串如果你以HTML格式发送邮件, 改为"text/html"即可。
                       Jmail.ContentType = "text/html";
                       //添加收件人
                       Jmail.AddRecipient(ToEmail, "", "");
                       Jmail.From = FromEmail;
                       //发件人邮件用户名
                       Jmail.MailServerUserName = "cattle_12345";
                       //发件人邮件密码
                       Jmail.MailServerPassWord = "12345";
                       //设置邮件标题
                       Jmail.Subject = Subject;
                       //邮件添加附件,(多附件的话，可以再加一条Jmail.AddAttachment( "c:\\test.jpg",true,null);)就可以搞定了。［注］：加了附件，讲把上面的Jmail.ContentType="text/html";删掉。否则会在邮件里出现乱码。
                       //Jmail.AddAttachment( "c:\\test.jpg",true,null);
                       //邮件内容
                       Jmail.Body = body + t.ToString();
                       //Jmail发送的方法
                 
                   Jmail.Send("smtp.163.com", false);
                   Jmail.Close();
   
                   //Response.Write("<script>alert('新的密码已发送至您的邮箱！！');</script>");
              //}
               //catch
               //{
               //   // Response.Write("<script>alert('信息发送失败！！');</script>");
               //}
       }
       #endregion  成员方法


       #region 20071210日修改的内容
       /// <summary>
       /// 根据注册用户的类型取得所属成员列表
       /// </summary>
       /// <param name="RegisterType"></param>
       /// <returns></returns>
       public DataSet GetMemberListByRegisterType(int RegisterType)
       {
           string sql = "select * from T_Member where RegisterType="+RegisterType+" order by MemberId asc";
           return SQLHelper.Query(sql);
       }

       //取得企业会员列表
       public DataSet GetCompanyList()
       {
           string sql = "select a.*,b.Tj1,b.Tj2 from T_Member a left join T_CompanyInfo b on a.MemberId=b.UserId  where a.RegisterType=1 order by MemberId desc";
           return SQLHelper.Query(sql);
       }

       //取得个人会员列表
       public DataSet GetPersonList()
       {
           string sql = "select a.*,b.* from T_Member a left join T_PersonalInfo b on a.MemberId=b.UserId  where a.RegisterType=0 order by MemberId desc";
           return SQLHelper.Query(sql);
       }

       /// <summary>
       /// 根据用户编号取得用户名
       /// </summary>
       /// <param name="MemberId"></param>
       /// <returns></returns>
       public string GetNickNameByMemberId(int MemberId)
       {
           string sql = "select NickName from T_Member where MemberId=" + MemberId + "";
           return SQLHelper.GetSingle(sql).ToString();
       }

       /// <summary>
       /// 取得推荐单位 
       /// </summary>
       /// <returns></returns>
       public DataSet GetTjCompanyInfo(int Num)
       {
           string sql = "select top " + Num + " UserId,CompanyName,ID,max(AddedDate) as AddDate from V_ZPInfo  where Approved=1 and Tj1=1 group by [id],companyName,UserId  order by max(AddedDate) desc";
           return SQLHelper.Query(sql);
       }
       #endregion
   }
}
