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
       #region  ��Ա����
       /// <summary>
       /// �Ƿ���ڸü�¼,�������������ȡ���ж�
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
       /// �Ƿ���ڸü�¼,�����û�ע��ʱ���ж��Ƿ�������
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
       ///  ����һ������
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
       /// ����һ������
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
       /// ɾ��һ������(T_Member��)
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
       /// �õ�һ������ʵ��
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
       /// ��������б�(��ҵ��Ա)
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
       /// ��������б�(���˻�Ա)
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
      

       //�ı����״̬
       public void ApproveMember(int memberId, bool isApproved)
       {
           string sql = String.Format("update T_Member set Approved={0} where MemberId={1}", isApproved ? 1 : 0, memberId);
           SQLHelper.ExecuteSql(sql);
       }


       //������ҵ��Ա���ȡ����ҵ��Ա��Ϣ 2007-11-26
       public DataSet GetCompanyInfo(int memberId)
       {
           string sql = "select * from V_CompanyInfo where UserId=" + memberId + "";
           return SQLHelper.Query(sql);
       }
       //������ҵ��Ա�û���,����ȡ���û���Ϣ
       public DataSet GetCompanyInfo1(string nickname, string pwd)
       {
           string sql = "select * from T_Member where NickName='" + nickname + "' and PassWord='" + pwd + "' and Approved=1 and RegisterType=1";
           return SQLHelper.Query(sql);
       }

       //���ݸ��˻�Ա���ȡ�ø��˻�Ա��Ϣ��2007-11-26
       public DataSet GetPersonalInfo(int memberId)
       {
           string sql = "select * from V_PersonalInfo where MemberId="+memberId+"";
           return SQLHelper.Query(sql);
       }
       //���ݸ��˻�Ա�û���,����ȡ���û���Ϣ
       public DataSet GetPersonalInfo1(string nickname,string pwd)
       {
           string sql = "select * from T_Member where NickName='" + nickname + "' and Password='" + pwd + "' and Approved=1 and RegisterType=0";
           return SQLHelper.Query(sql);
       }

       //���ݻ�Ա���ȡ�û�Ա����
       public int GetType(int MemberID)
       {
           string sql = "select RegisterType from T_Member where MemberId=" + MemberID + "";
           return Int32.Parse(SQLHelper.GetSingle(sql).ToString());
       }
      
       //�����û�����(���������ȡ��)
       public void UpDateMemberPwd(string nickname,string pwd,string Remark)
       {
           string sql = "update T_Member set Password='" + pwd + "',Remark='" + Remark + "' where NickName='" + nickname + "'";
           SQLHelper.ExecuteSql(sql);
       }

       //�����û�����
       public void UpDateMemberPwd1(int MemberId, string pwd, string Remark)
       {
           string sql = "update T_Member set Password='" + pwd + "',Remark='" + Remark + "' where MemberId=" + MemberId + "";
           SQLHelper.ExecuteSql(sql);
       }

       //�����û���ȡ���û������ѯ����������ѯ��
       public DataSet GetPassWord(string nickname)
       {
           string sql = "select * from T_Member where NickName='" + nickname + "'";
           return SQLHelper.Query(sql);
       }

       //�����ʼ�
       public void SentEmail(string nickname,string email)
       {
               //try
               //{
                   myjmail.Message Jmail = new myjmail.Message();
               
                       DateTime t = DateTime.Now;
                       String Subject = "���������ݹ����˲�������������Ϣ������";
                       String body = "�𾴵��û���" +" "+nickname +"" + "<br>" + "���ĵ�¼�����ѱ������趨Ϊ��123456,Ϊ�˱�֤�������밲ȫ���뾡���¼��վ�޸ģ�" + "<br>" + "<a href='http://www.sina.com.cn' target='_blank'>" + "�޸���������" + "</a>" + "<br>";
                       String FromEmail = "cattle_12345@163.com";
                       //String ToEmail = "zhuping@hzqts.gov.cn";
                       String ToEmail = email;
                       //Silent���ԣ��������Ϊtrue,JMail�����׳��������. JMail. Send( () ����ݲ����������true��false
                       Jmail.Silent = false;
                       //Jmail��������־��ǰ��loging��������Ϊtrue
                       Jmail.Logging = true;
                       //�ַ�����ȱʡΪ"US-ASCII"
                       Jmail.Charset = "GB2312";
                       //�ż���contentype. ȱʡ��"text/plain"�� : �ַ����������HTML��ʽ�����ʼ�, ��Ϊ"text/html"���ɡ�
                       Jmail.ContentType = "text/html";
                       //����ռ���
                       Jmail.AddRecipient(ToEmail, "", "");
                       Jmail.From = FromEmail;
                       //�������ʼ��û���
                       Jmail.MailServerUserName = "cattle_12345";
                       //�������ʼ�����
                       Jmail.MailServerPassWord = "12345";
                       //�����ʼ�����
                       Jmail.Subject = Subject;
                       //�ʼ���Ӹ���,(�฽���Ļ��������ټ�һ��Jmail.AddAttachment( "c:\\test.jpg",true,null);)�Ϳ��Ը㶨�ˡ���ע�ݣ����˸��������������Jmail.ContentType="text/html";ɾ������������ʼ���������롣
                       //Jmail.AddAttachment( "c:\\test.jpg",true,null);
                       //�ʼ�����
                       Jmail.Body = body + t.ToString();
                       //Jmail���͵ķ���
                 
                   Jmail.Send("smtp.163.com", false);
                   Jmail.Close();
   
                   //Response.Write("<script>alert('�µ������ѷ������������䣡��');</script>");
              //}
               //catch
               //{
               //   // Response.Write("<script>alert('��Ϣ����ʧ�ܣ���');</script>");
               //}
       }
       #endregion  ��Ա����


       #region 20071210���޸ĵ�����
       /// <summary>
       /// ����ע���û�������ȡ��������Ա�б�
       /// </summary>
       /// <param name="RegisterType"></param>
       /// <returns></returns>
       public DataSet GetMemberListByRegisterType(int RegisterType)
       {
           string sql = "select * from T_Member where RegisterType="+RegisterType+" order by MemberId asc";
           return SQLHelper.Query(sql);
       }

       //ȡ����ҵ��Ա�б�
       public DataSet GetCompanyList()
       {
           string sql = "select a.*,b.Tj1,b.Tj2 from T_Member a left join T_CompanyInfo b on a.MemberId=b.UserId  where a.RegisterType=1 order by MemberId desc";
           return SQLHelper.Query(sql);
       }

       //ȡ�ø��˻�Ա�б�
       public DataSet GetPersonList()
       {
           string sql = "select a.*,b.* from T_Member a left join T_PersonalInfo b on a.MemberId=b.UserId  where a.RegisterType=0 order by MemberId desc";
           return SQLHelper.Query(sql);
       }

       /// <summary>
       /// �����û����ȡ���û���
       /// </summary>
       /// <param name="MemberId"></param>
       /// <returns></returns>
       public string GetNickNameByMemberId(int MemberId)
       {
           string sql = "select NickName from T_Member where MemberId=" + MemberId + "";
           return SQLHelper.GetSingle(sql).ToString();
       }

       /// <summary>
       /// ȡ���Ƽ���λ 
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
