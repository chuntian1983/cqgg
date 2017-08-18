using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Modules.Applyforjob
{
    public class CollectBLL
    {
        CollectDAL dal = new CollectDAL();
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int CollectId)
        {
            return dal.Exists(CollectId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(R_Job_CollectModel model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(R_Job_CollectModel model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int CollectId)
        {
            dal.Delete(CollectId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public R_Job_CollectModel GetModel(int CollectId)
        {
            return dal.GetModel(CollectId);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 如果个人会员申请该岗位，则对应聘信息记录插入
        /// </summary>
        /// <param name="ID"></param>
        public void InsertSent(int UserId, int PostId)
        {
            dal.InsertSent(UserId, PostId);
        }


        /// <summary>
        ///根据用户名编号和岗位编号得到记录的类型(0:已收藏 1:已申请)
        /// </summary>
        /// <param name="MemberId"></param>
        /// <param name="PostId"></param>
        /// <returns></returns>
        public DataSet CheceCollectInfo(int MemberId, int PostId)
        {
            return dal.CheceCollectInfo(MemberId, PostId);
        }

        #endregion  成员方法
    }
}
