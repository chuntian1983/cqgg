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
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ADId)
		{
			return dal.Exists(ADId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(AdvertisementModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(AdvertisementModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ADId)
		{
			dal.Delete(ADId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public AdvertisementModel GetModel(int ADId)
		{
			return dal.GetModel(ADId);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

      
        /// <summary>
        /// ȡ����ҳ����б�
        /// </summary>
        public DataSet GetADList(int Num, int State)
        {
            return dal.GetADList(Num, State);
        }

        /// <summary>
        /// ȡ���Ƽ�����б�
        /// </summary>
        public DataSet GetTJADList(int Num)
        {
            return dal.GetTJADList(Num);
        }
        

        /// <summary>
        /// �ı����״̬
        /// </summary>
        /// <param name="memberId">�û���ʶ</param>
        public void ChangeApprovedStatus(int ADId)
        {
            AdvertisementDAL ad = new AdvertisementDAL();
            int status = ad.GetModel(ADId).Approved;
            if (status == 0) ad.ChangeApprovedStatus(ADId, true);
            else ad.ChangeApprovedStatus(ADId, false);
        }


        //��÷�ҳ�б�
        public DataSet GetArticleList(string fields, string filter, string sort, int currentPageIndex, int pageSize, out int recordCount)
        {
            return dal.GetArticleList(fields, filter, sort, currentPageIndex, pageSize, out recordCount);
        }
		#endregion  ��Ա����
	}
}
