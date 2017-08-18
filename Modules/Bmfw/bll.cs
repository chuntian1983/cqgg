using System;
using System.Collections.Generic;
using System.Text;
using Modules.T_BMFW.Model;
using System.Data;
namespace Modules.T_BMFW.BLL
{
    /// <summary>
    /// T_BMFW
    /// </summary>
    public partial class T_BMFW
    {
        private readonly Modules.T_BMFW.DAL.T_BMFW dal = new Modules.T_BMFW.DAL.T_BMFW();
        public T_BMFW()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Modules.T_BMFW.Model.T_BMFW model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Modules.T_BMFW.Model.T_BMFW model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 获得数据列表(村级名称)
        /// </summary>
        public DataSet GetListcun(string strWhere)
        {
            return dal.GetListcun(strWhere);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Modules.T_BMFW.Model.T_BMFW GetModel(int id)
        {

            return dal.GetModel(id);
        }

        ///// <summary>
        ///// 得到一个对象实体，从缓存中
        ///// </summary>
        //public Modules.T_BMFW.Model.T_BMFW GetModelByCache(int id)
        //{

        //    string CacheKey = "T_BMFWModel-" + id;
        //    object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(id);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch { }
        //    }
        //    return (Modules.T_BMFW.Model.T_BMFW)objModel;
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Modules.T_BMFW.Model.T_BMFW> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Modules.T_BMFW.Model.T_BMFW> DataTableToList(DataTable dt)
        {
            List<Modules.T_BMFW.Model.T_BMFW> modelList = new List<Modules.T_BMFW.Model.T_BMFW>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Modules.T_BMFW.Model.T_BMFW model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Modules.T_BMFW.Model.T_BMFW();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["cunid"] != null && dt.Rows[n]["cunid"].ToString() != "")
                    {
                        model.cunid = int.Parse(dt.Rows[n]["cunid"].ToString());
                    }
                    if (dt.Rows[n]["imgurl"] != null && dt.Rows[n]["imgurl"].ToString() != "")
                    {
                        model.imgurl = dt.Rows[n]["imgurl"].ToString();
                    }
                    if (dt.Rows[n]["state"] != null && dt.Rows[n]["state"].ToString() != "")
                    {
                        model.state = dt.Rows[n]["state"].ToString();
                    }
                    if (dt.Rows[n]["bz"] != null && dt.Rows[n]["bz"].ToString() != "")
                    {
                        model.bz = dt.Rows[n]["bz"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method
    }
}
