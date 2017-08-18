using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Modules.Applyforjob;

namespace Modules.Applyforjob
{
   public class ApplyforjobBLL
    {
       ApplyforjobDAL dal = new ApplyforjobDAL();
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
       public bool Exists(int UserID)
        {
            return dal.Exists(UserID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(T_ApplyforJobModel model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
       public void Update(T_ApplyforJobModel model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
       public void Delete(int UserID)
        {
            dal.Delete(UserID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
       public T_ApplyforJobModel GetModel(int UserID)
        {
            return dal.GetModel(UserID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 得到求职会员应聘信息(包括:求职意向和求职简历)列表(用于后台)
        /// </summary>
        public DataSet GetPersonInfoList(string strWhere)
        {
            return dal.GetPersonInfoList(strWhere);
        }

        /// <summary>
        /// 根据会员编号得到单个求职会员详细信息(包括:求职意向和求职简历)
        /// </summary>
       public DataSet GetOnePersonInfo(int MemberId)
        {
            return dal.GetOnePersonInfo(MemberId);
        }

       /// <summary>
       /// 取得个人会员应聘信息列表
       /// </summary>
       public DataSet GetYPList(string where)
       {
           return dal.GetYPList(where);
       }

       /// <summary>
       ///  取得个人会员应聘信息
       /// </summary>
       public DataSet GetYPInfo(int YPId)
       {
           return dal.GetYPInfo(YPId);         
       }

       /// <summary>
       /// 删除个人会员应聘信息(企业用户删除)
       /// </summary>
       public void DeleteYPInfo(int SenderOfferId)
       {
           dal.DeleteYPInfo(SenderOfferId);
       }
       /// <summary>
       /// 删除个人会员应聘信息(个人用户删除)
       /// </summary>
       public void DeleteYPInfo1(int CollectId)
       {
           dal.DeleteYPInfo1(CollectId);
       }
       /// <summary>
       /// 邀请应聘人员面试
       /// </summary>
       /// <param name="seekerId"></param>
       public void ChangeApprovedStatus(int SendOfferId)
       {
          int status=dal.GetState(SendOfferId);
          dal.ChangeApprovedStatus(SendOfferId, status);
        }

       /// <summary>
       /// 获得首页求职信息列表 取前N条
       /// </summary>
       /// <returns></returns>
       public DataSet GetIndexQZList(int Num)
       {
           return dal.GetIndexQZList(Num);
       }

       /// <summary>
       /// //得到首页招聘信息列表的单位名称(去除重复) 取前N条
       /// </summary>
       /// <returns></returns>
       public DataSet GetIndexYPList(int Num)
       {
           return dal.GetIndexYPList(Num);
       }

       /// <summary>
       /// 08推荐
       /// </summary>
       /// <returns></returns>
       public DataSet GetYPList1(int Num)
       {
           return dal.GetYPList1(Num);
       }

      
       /// <summary>
       /// 根据招聘信息表ID编号取得岗位信息(首页)
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
       public DataSet GetGwNameByID(int Id)
       {
           return dal.GetGwNameByID(Id);
       }
       /// <summary>
       /// 根据招聘信息表ID编号取得岗位信息(控件)
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
       public DataSet GetGwNameByID1(int Id)
       {
           return dal.GetGwNameByID1(Id);
       }
        #endregion  成员方法
    }
}
