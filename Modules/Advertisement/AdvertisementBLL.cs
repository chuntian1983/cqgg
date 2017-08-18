using System;
using System.Collections.Generic;
using System.Text;
using Modules.Advertisement;
using System.Data;

namespace Modules.Advertisement
{
    public class AdvertisementBLL
    {
        AdvertisementDAL dal=new AdvertisementDAL();
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ADId)
		{
			return dal.Exists(ADId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(AdvertisementModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(AdvertisementModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ADId)
		{
			dal.Delete(ADId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public AdvertisementModel GetModel(int ADId)
		{
			return dal.GetModel(ADId);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

      
        /// <summary>
        /// 取得首页广告列表
        /// </summary>
        public DataSet GetADList(int Num, int State)
        {
            return dal.GetADList(Num, State);
        }

        /// <summary>
        /// 取得推荐广告列表
        /// </summary>
        public DataSet GetTJADList(int Num)
        {
            return dal.GetTJADList(Num);
        }
        

        /// <summary>
        /// 改变审核状态
        /// </summary>
        /// <param name="memberId">用户标识</param>
        public void ChangeApprovedStatus(int ADId)
        {
            AdvertisementDAL ad = new AdvertisementDAL();
            int status = ad.GetModel(ADId).Approved;
            if (status == 0) ad.ChangeApprovedStatus(ADId, true);
            else ad.ChangeApprovedStatus(ADId, false);
        }


        //获得分页列表
        public DataSet GetArticleList(string fields, string filter, string sort, int currentPageIndex, int pageSize, out int recordCount)
        {
            return dal.GetArticleList(fields, filter, sort, currentPageIndex, pageSize, out recordCount);
        }
		#endregion  成员方法
	}
}
