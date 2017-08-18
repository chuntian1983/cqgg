using System;
using System.Collections.Generic;
using System.Text;
using CommonUtility.DBUtility;
using System.Data;
using CommonUtility;

namespace Modules.Menu
{
    /// <summary>
    /// 菜单项详细信息
    /// </summary>
    public class MenuDetail
    {
        /// <summary>
        /// 菜单项标识
        /// </summary>
        public int MenuId;
        /// <summary>
        /// 名称描述
        /// </summary>
        public string Name;
        /// <summary>
        /// 菜单项的连接地址
        /// </summary>
        public string MenuLink;
        /// <summary>
        /// 图片的连接地址
        /// </summary>
        public string ImageLink;
        /// <summary>
        /// 是否显示在菜单中
        /// </summary>
        public int IsVisible;
        /// <summary>
        /// 排序号
        /// </summary>
        public int Sort;
        /// <summary>
        /// 父菜单项标识
        /// </summary>
        public int ParentMenuId;
    }

    internal class MenuDAL
    {
        /// <summary>
        /// 获取整个站点的所有菜单项
        /// </summary>
        /// <returns>整个站点的所有菜单项</returns>
        public DataSet RetrieveAllMenuItem()
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder query = new StringBuilder();
            query.Append("select *");
            query.Append(" from T_Permission ");
            query.Append(" where PermissionTypeId=1");
            return helper.ExecuteDataset(query.ToString());
        }

        /// <summary>
        /// 获取指定用户的父菜单项下面的所有子菜单项
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <param name="parentMenuPermissionId">父菜单项标识</param>
        /// <returns>指定用户的父菜单项下面的所有子菜单项</returns>
        public DataSet RetrieveChildMenuItem(int userId, int parentMenuPermissionId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder query = new StringBuilder();
            query.Append("select distinct c.PermissionId,c.Description,c.MenuLink,c.Sort,c.ImageLink,c.IsVisible");
            query.Append(" from R_UserRole a inner join R_RolePermission b on a.RoleId=b.RoleId");
            query.Append(" inner join T_Permission c on b.PermissionId=c.PermissionId");
            query.AppendFormat(" where a.UserId={0} and c.PermissionTypeId=1 and c.IsVisible=1 and c.ParentMenuId={1}", userId, parentMenuPermissionId);
            query.Append(" order by c.Sort");
            return helper.ExecuteDataset(query.ToString());
        }

       
        /// <summary>
        /// 添加菜单项
        /// </summary>
        /// <param name="name">描述</param>
        /// <param name="menuLink">菜单项连接</param>
        /// <param name="imageLink">图片连接</param>
        /// <param name="sort">排序</param>
        /// <param name="isVisible">是否可见</param>
        /// <param name="parentMenuId">父菜单项标识</param>
        /// <returns>新创建的菜单项标识</returns>
        public int Add(string name,
                           string menuLink,
                           string imageLink,
                           int sort,
                           int isVisible,
                           int parentMenuId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            IDataParameter[] paras = new IDataParameter[7];
            paras[0] = helper.GetParameter("@Description", name);
            paras[1] = helper.GetParameter("@MenuLink", menuLink);
            paras[2] = helper.GetParameter("@ImageLink", imageLink);
            paras[3] = helper.GetParameter("@Sort", sort);
            paras[4] = helper.GetParameter("@IsVisible", isVisible);
            paras[5] = helper.GetParameter("@ParentMenuId", parentMenuId);
            paras[6] = helper.GetParameter("@MenuId", DbType.Int32, 4, ParameterDirection.Output);
            string strsql = "Insert Into T_Permission (Description,MenuLink,ImageLink,Sort,IsVisible,ParentMenuId,PermissionTypeId) values(@Description,@MenuLink,@ImageLink,@Sort,@IsVisible,@ParentMenuId,1)";
            helper.ExecuteNonQuery(helper.connectionString,CommandType.Text,strsql,paras);
            return Convert.ToInt32(paras[6].Value);
        }

        /// <summary>
        /// 添加菜单项
        /// </summary>
        /// <param name="detail">菜单项详细信息</param>
        /// <returns>新创建的菜单项标识</returns>
        public int Add(MenuDetail detail)
        {
            return Add(detail.Name,detail.MenuLink,detail.ImageLink,detail.Sort,detail.IsVisible,detail.ParentMenuId);
        }
        /// <summary>
        /// 获取菜单项的详细信息
        /// </summary>
        /// <param name="menuId">菜单项标识</param>
        /// <returns>菜单项的详细信息</returns>
        public MenuDetail GetMenuDetail(int menuId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder query = new StringBuilder();
            query.AppendFormat("select * from T_Permission where PermissionId={0} and PermissionTypeId=1", menuId);
            DataTable dt = helper.ExecuteDataset(query.ToString()).Tables[0];
            if (dt.Rows.Count == 1) return GetMenuDetailFromDataRow(dt.Rows[0]);
            return null;
        }
        /// <summary>
        /// 获取菜单项的详细信息
        /// </summary>
        /// <param name="menuEntity">DataRow形式的菜单项</param>
        /// <returns>菜单项的详细信息</returns>
        private MenuDetail GetMenuDetailFromDataRow(DataRow menuEntity)
        {
            MenuDetail detail = new MenuDetail();
            detail.MenuId = (int)menuEntity["PermissionId"];
            detail.Name = menuEntity["Description"].ToString();
            detail.MenuLink = menuEntity["MenuLink"].ToString();
            detail.ImageLink = menuEntity["ImageLink"].ToString();
            detail.Sort = (int)menuEntity["Sort"];
            detail.IsVisible = (int)menuEntity["IsVisible"];
            detail.ParentMenuId = (int)menuEntity["ParentMenuId"];
            return detail;
        }

       
        /// <summary>
        /// 更新菜单项
        /// </summary>
        /// <param name="menuId">菜单项标识</param>
        /// <param name="name">描述</param>
        /// <param name="menuLink">菜单项连接</param>
        /// <param name="imageLink">图片连接</param>
        /// <param name="sort">排序</param>
        /// <param name="isVisible">是否可见</param>
        /// <param name="parentMenuId">父菜单项标识</param>
        /// <returns>更新成功，返回true</returns>
        public bool Update(int menuId, string name, string menuLink,string imageLink, int sort,int isVisible, int parentMenuId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("update T_Permission set Description='{0}',MenuLink='{1}',ImageLink='{2}',Sort={3},IsVisible={4},ParentMenuId={5}", name, menuLink,imageLink, sort,isVisible, parentMenuId);
            sql.AppendFormat(" where PermissionId={0}", menuId);
            int rowsAffected=helper.ExecuteNonQuery(sql.ToString());
            return rowsAffected == 1;
        }

        /// <summary>
        /// 更新菜单项
        /// </summary>
        /// <param name="detail">菜单项详细信息</param>
        /// <returns>更新成功，返回true</returns>
        public bool Update(MenuDetail detail)
        {
            return Update(detail.MenuId, detail.Name, detail.MenuLink,detail.ImageLink, detail.Sort,detail.IsVisible, detail.ParentMenuId);
        }

        /// <summary>
        /// 删除叶节点菜单项集，非叶节点无法删除
        /// </summary>
        /// <param name="menuIds">菜单项标识集</param>
        /// <returns>全部删除 返回true ,否则false</returns>
        public bool Delete(int[] menuIds)
        {
            int count = 0;
            foreach (int menuId in menuIds)
            {
                if (Delete(menuId)) count++;
            }
            return count == menuIds.Length;
        }

        /// <summary>
        /// 删除叶节点菜单项，非叶节点无法删除
        /// </summary>
        /// <param name="menuId">菜单项标识</param>
        /// <returns>删除 返回true ,否则false</returns>
        public bool Delete(int menuId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            IDataParameter[] paras = new IDataParameter[2];
            paras[0] = helper.GetParameter("@MenuId", menuId);
            paras[1] = helper.GetParameter("@Return",DbType.Int32,4,ParameterDirection.Output);
            string strsql = @"delete from T_Permission where PermissionId=@MenuId and PermissionTypeId=1;
Delete from R_RolePermission where PermissionId=@MenuId";
            helper.ExecuteNonQuery(helper.connectionString,CommandType.Text,strsql,paras);
            return Convert.ToBoolean(paras[1].Value);
        }



    }
}
