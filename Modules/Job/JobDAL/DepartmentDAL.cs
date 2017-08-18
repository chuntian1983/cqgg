using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonUtility.DBUtility;

namespace Modules.Job
{
        public class DepartmentDetail
        {
            public int DepartmentId;
            public string Name;
            public string Introduce;
            public string Manager;
        }
    
    internal class DepartmentDAL
    {
        public DataSet GetAllDepartments()
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string query = "select * from T_Job_Department ";
            return helper.ExecuteDataset(query);
        }
        public DepartmentDetail GetDepartmentDetail(int departmentId)
        {
            return GetDepartmentDetailFromDataRow(GetDepartmentDataRow(departmentId));
        }
        public DataRow GetDepartmentDataRow(int departmentId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string query = String.Format("select * from T_Job_Department where DepartmentId={0}", departmentId);
            DataSet ds = helper.ExecuteDataset(query);
            if (ds.Tables[0].Rows.Count == 1) return ds.Tables[0].Rows[0];
            return null;
        }
        private DepartmentDetail GetDepartmentDetailFromDataRow(DataRow info)
        {
            if (info != null)
            {
                DepartmentDetail detail = new DepartmentDetail();
                detail.Name = info["Name"].ToString();
                detail.DepartmentId = (int)info["DepartmentId"];
                detail.Introduce = info["Introduce"].ToString();
                detail.Manager = info["Manager"].ToString();
                return detail;
            }
            else
                return null;
        }

        public int AddDepartment(string name, string introduce,string manager)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            IDataParameter[] paras = new IDataParameter[4];
            paras[0] = helper.GetParameter("@Name", name);
            paras[1] = helper.GetParameter("@Introduce", introduce);
            paras[2] = helper.GetParameter("@Manager", manager);
            paras[3] = helper.GetParameter("@DepartmentId", DbType.Int32, 4, ParameterDirection.Output);
            helper.ExecuteNonQuery("sp_Job_AddDepartment", paras);
            return Convert.ToInt32(paras[3].Value);
        }
        public int AddDepartment(DepartmentDetail detail)
        {
            return AddDepartment(detail.Name,detail.Introduce,detail.Manager);
        }
        public bool DeleteDepartment(int departmentId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string sql = String.Format("delete T_Job_Department where DepartmentId={0}", departmentId);
            return helper.ExecuteNonQuery(sql) > 0;
        }

        public bool UpdateDepartment(int departmentId, string name,string introduce,string manager)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("Update T_Job_Department Set Name='{0}',Introduce='{1}',Manager='{2}' ", name, introduce, manager);
            sql.AppendFormat("Where DepartmentId={0}", departmentId);
            return helper.ExecuteNonQuery(sql.ToString()) > 0;
        }

        public bool UpdateDepartment(DepartmentDetail detail)
        {
            return UpdateDepartment(detail.DepartmentId,detail.Name,detail.Introduce,detail.Manager);
        }
    }
}
