using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Modules.LoginRecorder;

namespace Modules.LoginRecorder
{
    public class LoginRecorderBLL
    {
        LoginRecorderDAL dal = new LoginRecorderDAL();
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(T_LoginRecorderModel model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(T_LoginRecorderModel model)
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
        public T_LoginRecorderModel GetModel(int MemberID)
        {
            return dal.GetModel(MemberID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        //根据成员编号取得成员用户名
        public string GetNickName(int MemberId)
        {
            return dal.GetNickName(MemberId);
        }
        
        #endregion  成员方法
    }
}
