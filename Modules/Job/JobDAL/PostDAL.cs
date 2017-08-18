using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonUtility.DBUtility;

namespace Modules.Job
{
    public class PostDetail
    {
        public int PostId;
        public string Description;
        public string PersonNum;
        public int Sex;
        public string Age;
        public string Age1;
        public int Diploma;
        public string Subject;//רҵ
        public string WorkPlace;
        public int WorkMode;
        public string Pay;
        public int IsThisYear;
        public string WorkAge;
        public int ViewCount;
        public string OtherRequests;
        public int DepartmentId;
        public int AddedUserId;
        public DateTime AddedDate;
        public DateTime ReleaseDate;
        public DateTime ExpireDate;
        public string ConnectTel;//��ϵ��ʽ
        public int Approved;//���
        public string CompanyName;//��λ����
        public int Tj;//�Ƽ�
        public int PostType;//��λ����
    }

    class PostDAL
    {
        //���ݳ�Ա���ȡ����Ƹ��Ϣ
        public DataRow GetPostRow(int postId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder query = new StringBuilder();
            query.Append("select * from V_ZPInfo");
            query.AppendFormat(" where PostId={0}", postId);
            DataSet result = helper.ExecuteDataset(query.ToString());
            if (result.Tables[0].Rows.Count == 1) return result.Tables[0].Rows[0];
            return null;
        }

        public PostDetail GetPostDetail(int postId)
        {
            DataRow info = this.GetPostRow(postId);
            return this.GetPostDetailFromDataRow(info);
        }

        private PostDetail GetPostDetailFromDataRow(DataRow postInfo)
        {
            if (postInfo == null) return null;
            PostDetail detail = new PostDetail();
            detail.PostId = (int)postInfo["PostId"];
            detail.Description = postInfo["Description"].ToString();
            detail.PersonNum = postInfo["PersonNum"].ToString();
            detail.Sex = (int)postInfo["Sex"];
            detail.Age = postInfo["Age"].ToString();
            detail.Age1 = postInfo["Age1"].ToString();
            detail.WorkMode = (int)postInfo["WorkMode"];
            detail.Pay = postInfo["Pay"].ToString();
            detail.WorkPlace = postInfo["WorkPlace"].ToString();
            detail.Diploma = (int)postInfo["Diploma"];
            detail.Subject = postInfo["Subject"].ToString();
            detail.WorkMode = (int)postInfo["WorkMode"];
            detail.IsThisYear = (int)postInfo["IsThisYear"];
            detail.WorkAge = postInfo["WorkAge"].ToString();
            detail.ViewCount = (int)postInfo["ViewCount"];
            detail.OtherRequests = postInfo["OtherRequests"].ToString();
            detail.DepartmentId = (int)postInfo["DepartmentId"];//��λ���
            detail.AddedUserId = (int)postInfo["AddedUserId"];
            detail.AddedDate = Convert.ToDateTime(postInfo["AddedDate"]);
            detail.ReleaseDate = Convert.ToDateTime(postInfo["ReleaseDate"]);
            detail.ExpireDate = Convert.ToDateTime(postInfo["ExpireDate"]);
            detail.ConnectTel = postInfo["ConnectTel"].ToString();//��ϵ��ʽ
            detail.CompanyName = postInfo["CompanyName"].ToString();//��λ����

            //�����ӵ���˹��� 071112 Yj
            detail.Approved = (int)postInfo["Approved"];
            detail.Tj = (int)postInfo["Tj"];//�Ƽ�
            detail.PostType = (int)postInfo["Type"];//��λ����
            return detail;
        }

        public int AddPost(string description, string personNum,
                       int sex, string age,string age1,int diploma,string subject,
                       string workPlace, int workMode,string pay,int isThisYear,
                       string workAge,
                       string otherRequests, int departmentId,
                       int addedUserId,
                       DateTime releaseDate, DateTime expireDate, string connectTel, int approved,int tj,int postType)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            IDataParameter[] paras = new IDataParameter[22];
            paras[0] = helper.GetParameter("@Description", description);
            paras[1] = helper.GetParameter("@PersonNum", personNum);
            paras[2] = helper.GetParameter("@Sex", sex);
            paras[3] = helper.GetParameter("@Age", age);
            paras[4] = helper.GetParameter("@Age1", age1);
            paras[5] = helper.GetParameter("@Diploma", diploma);
            paras[6] = helper.GetParameter("@Subject", subject);
            paras[7] = helper.GetParameter("@WorkPlace", workPlace);
            paras[8] = helper.GetParameter("@WorkMode", workMode);
            paras[9] = helper.GetParameter("@Pay", pay);
            paras[10] = helper.GetParameter("@IsThisYear", isThisYear);
            paras[11] = helper.GetParameter("@WorkAge", workAge);
            paras[12] = helper.GetParameter("@OtherRequests", otherRequests);
            paras[13] = helper.GetParameter("@DepartmentId", departmentId);
            paras[14] = helper.GetParameter("@AddedUserId", addedUserId);
            paras[15] = helper.GetParameter("@ReleaseDate", releaseDate);
            paras[16] = helper.GetParameter("@ExpireDate", expireDate);
            paras[17] = helper.GetParameter("@PostId", DbType.Int32, 4, ParameterDirection.Output);
            paras[18] = helper.GetParameter("@ConnectTel", connectTel);//��ϵ��ʽ
            paras[19] = helper.GetParameter("@Approved", approved);//���״̬
            paras[20] = helper.GetParameter("@Tj", tj);//�Ƽ�
            paras[21] = helper.GetParameter("@Type", postType);
            helper.ExecuteNonQuery("sp_Job_AddPost", paras);
            return Convert.ToInt32(paras[17].Value);
        }

        public int AddPost(PostDetail detail)
        {
            return this.AddPost(detail.Description, detail.PersonNum, detail.Sex, detail.Age,detail.Age1,detail.Diploma,detail.Subject,detail.WorkPlace,
                                detail.WorkMode,detail.Pay,detail.IsThisYear, detail.WorkAge, detail.OtherRequests, detail.DepartmentId,
                                detail.AddedUserId, detail.ReleaseDate, detail.ExpireDate, detail.ConnectTel,detail.Approved,detail.Tj,detail.PostType);
        }

        public bool UpdatePost(int postId, string description, string personNum, int sex, string age,string age1,int diploma,string subject,
                               string workPlace, int workMode,string pay, int isThisYear, string workAge, string otherRequests,
                               int departmentId, int viewCount,DateTime addedDate,DateTime releaseDate, DateTime expireDate, string connectTel,int approved,int tj,int postType)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("update T_Job_Post set Description='{0}',PersonNum='{1}',sex={2},Age='{3}',Age1='{4}',", description, personNum, sex, age,age1);
            sql.AppendFormat("Diploma={0},Subject='{1}',WorkMode={2},Pay='{3}',IsThisYear={4},WorkPlace='{5}',", diploma,subject, workMode, pay,isThisYear, workPlace);
            sql.AppendFormat("WorkAge='{0}',OtherRequests='{1}',DepartmentId={2},", workAge, otherRequests, departmentId);
            sql.AppendFormat("ViewCount={0},AddedDate='{1}',ReleaseDate='{2}',ExpireDate='{3}', ", viewCount,addedDate.ToString(),releaseDate.ToString(), expireDate.ToString());
            sql.AppendFormat("ConnectTel='{0}',Approved={1},Tj={2},type={3}", connectTel,approved,tj,postType);//��ϵ��ʽ,���״̬,�Ƽ�
            sql.AppendFormat(" Where PostId={0}", postId);
            return helper.ExecuteNonQuery(sql.ToString()) > 0;
        }

        public bool UpdatePost(PostDetail detail)
        {
            return this.UpdatePost(detail.PostId, detail.Description, detail.PersonNum, detail.Sex, detail.Age,detail.Age1,detail.Diploma,detail.Subject,
                                   detail.WorkPlace, detail.WorkMode,detail.Pay,detail.IsThisYear, detail.WorkAge, detail.OtherRequests,
                                   detail.DepartmentId, detail.ViewCount,detail.AddedDate,detail.ReleaseDate, detail.ExpireDate, detail.ConnectTel,detail.Approved,detail.Tj,detail.PostType);
        }


        //ȡ�����й�˾��Ƹ��Ϣ�б�
        public DataSet GetAllPostDetailes()
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from V_ZPInfo order by AddedDate desc");
            return helper.ExecuteDataset(sql.ToString());
        }



        //ɾ����Ƹ��Ϣ
        public bool DeletePost(int postId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string sql = String.Format("delete T_Job_Post where PostId={0}", postId);
            return helper.ExecuteNonQuery(sql) > 0;
        }
        //�����Ƹ��Ϣ
        public void ApprovePost(int postId, bool isApproved)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string sql = String.Format("update T_Job_Post set Approved={0} where postId={1}", isApproved ? 1 : 0, postId);
            helper.ExecuteNonQuery(sql);
        }

        //��Ƹ��Ϣ���Ƽ�
        public void TjPost(int postId, bool isTj)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string sql = String.Format("update T_Job_Post set Tj={0} where postId={1}", isTj ? 1 : 0, postId);
            helper.ExecuteNonQuery(sql);
        }

        //���ݹ�˾����ȡ�ù�˾��Ƹ��Ϣ�б�(ģ����ѯ)
        public DataSet GetCommpanyInfo(string where)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from V_ZPInfo where CompanyName like '%"+where+"%'");
            return helper.ExecuteDataset(sql.ToString());
        }
        //������ҵ��Ա���ȡ�ù�˾��Ƹ��Ϣ�б�
        public DataSet GetPostListByID(int MemberId)
        {
            string sql = "select * from V_ZPInfo where UserID=" + MemberId + " and Approved=1";
            return SQLHelper.Query(sql);
        }
   
        //���ݸ�λ���ȡ�ø�λ��Ϣ
        public DataSet GetGWInfo(int postId)
        {
            string sql = "select * from V_ZPInfo where PostId="+postId+"";
            return SQLHelper.Query(sql);
        }
        public int GetTotalPostNum()
        {
            string sql = "select count(*) from V_ZPInfo";
            return Convert.ToInt32(SQLHelper.GetSingle(sql));
        }

        public int GetWeeklyPostNum()
        {
            string sql = "select count(*) from V_ZPInfo where year(addeddate)=year(getdate())  and datepart(week,addeddate)=datepart(week,getdate())";
            return Convert.ToInt32(SQLHelper.GetSingle(sql));
        }

    }
}
