using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Modules.Job
{
    public class DepartmentBLL
    {
        public DataSet GetAllDepartments()
        {
            return new DepartmentDAL().GetAllDepartments();
        }
        public int AddDepartment(DepartmentDetail detail)
        {
            return new DepartmentDAL().AddDepartment(detail);
        }
        public bool DeleteDepartment(int departmentId)
        {
            return new DepartmentDAL().DeleteDepartment(departmentId);
        }
        public bool UpdateDepartment(DepartmentDetail detail)
        {
            return new DepartmentDAL().UpdateDepartment(detail);
        }

        public DepartmentDetail GetDepartmentDetail(int departmentId)
        {
            return new DepartmentDAL().GetDepartmentDetail(departmentId);
        }
    }
}
