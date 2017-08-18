using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Modules.Member;

namespace Modules.Member
{ 
    public class MemberBLL
    {
        MemberDAL dal = new MemberDAL();
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼,�������������ȡ���ж�
        /// </summary>
        public bool Exists1(string Nickname, string Province,string City)
        {
            return dal.Exists1(Nickname, Province,City);
        }

        /// <summary>
        /// �Ƿ���ڸü�¼,�����û�ע��ʱ���ж��Ƿ�������
        /// </summary>
        public bool Exists(string Nickname)
        {
            return dal.Exists(Nickname);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(MemberModel model)
        {
          return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(MemberModel model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int MemberId)
        {
            dal.Delete(MemberId);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public MemberModel GetModel(int MemberId)
        {
            return dal.GetModel(MemberId);
        }

        //�õ���ҵ��Ա��ϸ��Ϣ 2007-11-26
        public DataSet GetCompanyInfo(int MemberId)
        {
            return dal.GetCompanyInfo(MemberId);
        }

        //�õ����˻�Ա��ϸ��Ϣ 2007-11-26
        public DataSet GetPersonalInfo(int MemberId)
        {
            return dal.GetPersonalInfo(MemberId);
        }
        /// <summary>
        /// ��������б�(��ҵ��Ա)
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ��������б�(���˻�Ա)
        /// </summary>
        public DataSet GetList1(string strWhere)
        {
            return dal.GetList1(strWhere);
        }
        /// <summary>
        /// �ı����״̬
        /// </summary>
        /// <param name="memberId">�û���ʶ</param>
        public void ChangeApprovedStatus(int memberId)
        {
            MemberDAL member = new MemberDAL();
            int status = member.GetModel(memberId).Approved;
            if (status == 0) member.ApproveMember(memberId, true);
            else member.ApproveMember(memberId, false);
        }

        /// <summary>
        /// ���ݻ�Ա���ȡ�û�Ա����
        /// </summary>
        /// <param name="MemberID"></param>
        /// <returns></returns>
        public int GetType(int MemberID)
        {
            return dal.GetType(MemberID);
        }

        /// <summary>
        /// �ж���ҵ��Ա�û����������Ƿ���ȷ
        /// </summary>
        public DataSet GetCompanyInfo1(string nickname,string pwd)
        {
           return dal.GetCompanyInfo1(nickname,pwd);
        }

        /// <summary>
        /// �жϸ��˻�Ա�û����������Ƿ���ȷ
        /// </summary>
        public DataSet GetPersonalInfo1(string nickname,string pwd)
        {
            return dal.GetPersonalInfo1(nickname,pwd);
        }

        /// <summary>
        /// �����û�����(���������ȡ��)
        /// </summary>
        /// <param name="MemberId"></param>
        public void UpdateMemberPWD(string NickName,string pwd,string Remark)
        {
            dal.UpDateMemberPwd(NickName, pwd,Remark);
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="MemberId"></param>
        public void UpdateMemberPWD1(int MemberId, string pwd,string Remark)
        {
            dal.UpDateMemberPwd1(MemberId, pwd, Remark);
        }

        /// <summary>
        /// �����û���ȡ���û���Ϣ
        /// </summary>
        public DataSet GetPassWord(string nickname)
        {
            return dal.GetPassWord(nickname);
        }

        //�����ʼ�
        public void SentEmail(string nickname,string email)
        {
            dal.SentEmail(nickname,email);
        }
        #endregion  ��Ա����


        #region  20071210���޸ĵ�����
        /// <summary>
        /// ����ע���û�������ȡ��������Ա�б�
        /// </summary>
        /// <param name="RegisterType"></param>
        /// <returns></returns>
        public DataSet GetMemberListByRegisterType(int RegisterType)
        {
            return dal.GetMemberListByRegisterType(RegisterType);
        }
        /// <summary>
        /// �õ���ҵ��Ա�б�
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet GetCompanyList()
        {
            return dal.GetCompanyList();
        }

        /// <summary>
        /// ȡ�ø��˻�Ա�б�
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet GetPersonList()
        {
            return dal.GetPersonList();
        }

        

        /// <summary>
        /// �����û����ȡ���û���
        /// </summary>
        /// <param name="MemberId"></param>
        /// <returns></returns>
        public string GetNickNameByMemberId(int MemberId)
        {
            return dal.GetNickNameByMemberId(MemberId);
        }

        /// <summary>
        /// ȡ���Ƽ���λ 
        /// </summary>
        /// <returns></returns>
        public DataSet GetTjCompanyInfo(int Num)
        {
            return dal.GetTjCompanyInfo(Num);
        }
      
        #endregion
    }
}
