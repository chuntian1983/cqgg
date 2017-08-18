using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Modules.Resume
{
    public class ResumeBLL
    {
        ResumeDAL dal = new ResumeDAL();
    
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
            public void Add(T_ResumeModel model)
            {
                dal.Add(model);
            }

            /// <summary>
            /// 更新一条数据
            /// </summary>
            public void Update(T_ResumeModel model)
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
            /// 得到一个对象实体(全部)
            /// </summary>
            public T_ResumeModel GetModel(int UserID)
            {
                return dal.GetModel(UserID);
            }

            /// <summary>
            /// 得到一个对象实体(已审核)
            /// </summary>
            public T_ResumeModel GetModel1(int UserID)
            {
                return dal.GetModel1(UserID);
            }

            /// <summary>
            /// 获得数据列表
            /// </summary>
            public DataSet GetList(string strWhere)
            {
                return dal.GetList(strWhere);
            }

            // <summary>
            ///修改个人会员的求职简历的审核状态
            /// </summary>
            /// <param name="postId"></param>
            public void ChangeApprovedStatus(int UserID)
            {
                int status = dal.GetModel(UserID).Approved;
                if (status == 0)dal.ApproveUserResume(UserID, true);
                else dal.ApproveUserResume(UserID, false);
            }

            /// <summary>
            /// //根据个人会员编号取得会员详细简历(包括求职意向和个人简历以及会员个人信息)
            /// </summary>
            /// <param name="UserId"></param>
            /// <returns></returns>
            public DataSet GetAllResumeByID(int UserId)
            {
                return dal.GetAllResumeByID(UserId);
            }


        public int GetWeeklyResumeNum()
        {
            return dal.GetWeeklyResumeNum();
        }

        public int GetTotalResumeNum()
        {
            return dal.GetTotalResumeNum();
        }
            #endregion  成员方法

        }
}
