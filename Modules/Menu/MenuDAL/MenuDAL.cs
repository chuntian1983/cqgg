using System;
using System.Collections.Generic;
using System.Text;
using CommonUtility.DBUtility;
using System.Data;
using CommonUtility;

namespace Modules.Menu
{
    /// <summary>
    /// �˵�����ϸ��Ϣ
    /// </summary>
    public class MenuDetail
    {
        /// <summary>
        /// �˵����ʶ
        /// </summary>
        public int MenuId;
        /// <summary>
        /// ��������
        /// </summary>
        public string Name;
        /// <summary>
        /// �˵�������ӵ�ַ
        /// </summary>
        public string MenuLink;
        /// <summary>
        /// ͼƬ�����ӵ�ַ
        /// </summary>
        public string ImageLink;
        /// <summary>
        /// �Ƿ���ʾ�ڲ˵���
        /// </summary>
        public int IsVisible;
        /// <summary>
        /// �����
        /// </summary>
        public int Sort;
        /// <summary>
        /// ���˵����ʶ
        /// </summary>
        public int ParentMenuId;
    }

    internal class MenuDAL
    {
        /// <summary>
        /// ��ȡ����վ������в˵���
        /// </summary>
        /// <returns>����վ������в˵���</returns>
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
        /// ��ȡָ���û��ĸ��˵�������������Ӳ˵���
        /// </summary>
        /// <param name="userId">�û���ʶ</param>
        /// <param name="parentMenuPermissionId">���˵����ʶ</param>
        /// <returns>ָ���û��ĸ��˵�������������Ӳ˵���</returns>
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
        /// ��Ӳ˵���
        /// </summary>
        /// <param name="name">����</param>
        /// <param name="menuLink">�˵�������</param>
        /// <param name="imageLink">ͼƬ����</param>
        /// <param name="sort">����</param>
        /// <param name="isVisible">�Ƿ�ɼ�</param>
        /// <param name="parentMenuId">���˵����ʶ</param>
        /// <returns>�´����Ĳ˵����ʶ</returns>
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
        /// ��Ӳ˵���
        /// </summary>
        /// <param name="detail">�˵�����ϸ��Ϣ</param>
        /// <returns>�´����Ĳ˵����ʶ</returns>
        public int Add(MenuDetail detail)
        {
            return Add(detail.Name,detail.MenuLink,detail.ImageLink,detail.Sort,detail.IsVisible,detail.ParentMenuId);
        }
        /// <summary>
        /// ��ȡ�˵������ϸ��Ϣ
        /// </summary>
        /// <param name="menuId">�˵����ʶ</param>
        /// <returns>�˵������ϸ��Ϣ</returns>
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
        /// ��ȡ�˵������ϸ��Ϣ
        /// </summary>
        /// <param name="menuEntity">DataRow��ʽ�Ĳ˵���</param>
        /// <returns>�˵������ϸ��Ϣ</returns>
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
        /// ���²˵���
        /// </summary>
        /// <param name="menuId">�˵����ʶ</param>
        /// <param name="name">����</param>
        /// <param name="menuLink">�˵�������</param>
        /// <param name="imageLink">ͼƬ����</param>
        /// <param name="sort">����</param>
        /// <param name="isVisible">�Ƿ�ɼ�</param>
        /// <param name="parentMenuId">���˵����ʶ</param>
        /// <returns>���³ɹ�������true</returns>
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
        /// ���²˵���
        /// </summary>
        /// <param name="detail">�˵�����ϸ��Ϣ</param>
        /// <returns>���³ɹ�������true</returns>
        public bool Update(MenuDetail detail)
        {
            return Update(detail.MenuId, detail.Name, detail.MenuLink,detail.ImageLink, detail.Sort,detail.IsVisible, detail.ParentMenuId);
        }

        /// <summary>
        /// ɾ��Ҷ�ڵ�˵������Ҷ�ڵ��޷�ɾ��
        /// </summary>
        /// <param name="menuIds">�˵����ʶ��</param>
        /// <returns>ȫ��ɾ�� ����true ,����false</returns>
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
        /// ɾ��Ҷ�ڵ�˵����Ҷ�ڵ��޷�ɾ��
        /// </summary>
        /// <param name="menuId">�˵����ʶ</param>
        /// <returns>ɾ�� ����true ,����false</returns>
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
