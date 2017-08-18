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
        #region  成员方法
        /// <summary>
        /// 是否存在该记录,用于遗忘密码的取回判断
        /// </summary>
        public bool Exists1(string Nickname, string Province,string City)
        {
            return dal.Exists1(Nickname, Province,City);
        }

        /// <summary>
        /// 是否存在该记录,用于用户注册时候判断是否有重名
        /// </summary>
        public bool Exists(string Nickname)
        {
            return dal.Exists(Nickname);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MemberModel model)
        {
          return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(MemberModel model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int MemberId)
        {
            dal.Delete(MemberId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MemberModel GetModel(int MemberId)
        {
            return dal.GetModel(MemberId);
        }

        //得到企业会员详细信息 2007-11-26
        public DataSet GetCompanyInfo(int MemberId)
        {
            return dal.GetCompanyInfo(MemberId);
        }

        //得到个人会员详细信息 2007-11-26
        public DataSet GetPersonalInfo(int MemberId)
        {
            return dal.GetPersonalInfo(MemberId);
        }
        /// <summary>
        /// 获得数据列表(企业会员)
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表(个人会员)
        /// </summary>
        public DataSet GetList1(string strWhere)
        {
            return dal.GetList1(strWhere);
        }
        /// <summary>
        /// 改变审核状态
        /// </summary>
        /// <param name="memberId">用户标识</param>
        public void ChangeApprovedStatus(int memberId)
        {
            MemberDAL member = new MemberDAL();
            int status = member.GetModel(memberId).Approved;
            if (status == 0) member.ApproveMember(memberId, true);
            else member.ApproveMember(memberId, false);
        }

        /// <summary>
        /// 根据会员编号取得会员类型
        /// </summary>
        /// <param name="MemberID"></param>
        /// <returns></returns>
        public int GetType(int MemberID)
        {
            return dal.GetType(MemberID);
        }

        /// <summary>
        /// 判断企业会员用户名和密码是否正确
        /// </summary>
        public DataSet GetCompanyInfo1(string nickname,string pwd)
        {
           return dal.GetCompanyInfo1(nickname,pwd);
        }

        /// <summary>
        /// 判断个人会员用户名和密码是否正确
        /// </summary>
        public DataSet GetPersonalInfo1(string nickname,string pwd)
        {
            return dal.GetPersonalInfo1(nickname,pwd);
        }

        /// <summary>
        /// 更改用户密码(忘记密码的取回)
        /// </summary>
        /// <param name="MemberId"></param>
        public void UpdateMemberPWD(string NickName,string pwd,string Remark)
        {
            dal.UpDateMemberPwd(NickName, pwd,Remark);
        }

        /// <summary>
        /// 更改密码
        /// </summary>
        /// <param name="MemberId"></param>
        public void UpdateMemberPWD1(int MemberId, string pwd,string Remark)
        {
            dal.UpDateMemberPwd1(MemberId, pwd, Remark);
        }

        /// <summary>
        /// 根据用户名取得用户信息
        /// </summary>
        public DataSet GetPassWord(string nickname)
        {
            return dal.GetPassWord(nickname);
        }

        //发送邮件
        public void SentEmail(string nickname,string email)
        {
            dal.SentEmail(nickname,email);
        }
        #endregion  成员方法


        #region  20071210日修改的内容
        /// <summary>
        /// 根据注册用户的类型取得所属成员列表
        /// </summary>
        /// <param name="RegisterType"></param>
        /// <returns></returns>
        public DataSet GetMemberListByRegisterType(int RegisterType)
        {
            return dal.GetMemberListByRegisterType(RegisterType);
        }
        /// <summary>
        /// 得到企业会员列表
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet GetCompanyList()
        {
            return dal.GetCompanyList();
        }

        /// <summary>
        /// 取得个人会员列表
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet GetPersonList()
        {
            return dal.GetPersonList();
        }

        

        /// <summary>
        /// 根据用户编号取得用户名
        /// </summary>
        /// <param name="MemberId"></param>
        /// <returns></returns>
        public string GetNickNameByMemberId(int MemberId)
        {
            return dal.GetNickNameByMemberId(MemberId);
        }

        /// <summary>
        /// 取得推荐单位 
        /// </summary>
        /// <returns></returns>
        public DataSet GetTjCompanyInfo(int Num)
        {
            return dal.GetTjCompanyInfo(Num);
        }
      
        #endregion
    }
}
