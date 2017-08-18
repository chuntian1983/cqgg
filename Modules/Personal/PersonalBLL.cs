using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Modules.Personal;

namespace Modules.Personal
{
    public class PersonalBLL
    {
        PersonalDAL dal = new PersonalDAL();
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
        public void Add(T_PersonalModel model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(T_PersonalModel model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {
            dal.Delete(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public T_PersonalModel GetModel(int UserID)
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
        /// 上传个人照片
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="Src"></param>
        public void UpdatePic(int UserId, string Src)
        {
            dal.UpdatePic(UserId,Src);
        }

        /// <summary>
        /// 获得个人照片
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public string GetPic(int UserId)
        {
            return dal.GetPic(UserId);
        }
        #endregion  成员方法
    }
}
