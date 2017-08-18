using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Modules.Department
{
    public　class DepartmentBLL
    {
        public DepartmentDetail GetDepartmentDetail(int DepartId)
        {
            return new DepartmentDAL().GetDepartmentDetail(DepartId);
        }

        public int Add(DepartmentDetail detail)
        {
            DepartmentDAL depart = new DepartmentDAL();

            int categoryId = detail.CategoryId;
            DepartmentCategoryDetail categoryDetail = new DepartmentCategoryDAL().GetCategoryDetail(categoryId);
            //if (categoryDetail.Type == 1)
            //    return new DepartmentDAL().Add(detail);
            //else
            //{
                int count = depart.GetRecordCount(String.Format("CategoryId={0}", categoryId));
                if (count == 0)
                    return new DepartmentDAL().Add(detail);
                else return -2;
           // }

        }

        public bool Update(DepartmentDetail detail)
        {
            return new DepartmentDAL().Update(detail);
        }

        public DataSet GetAllDepartmentDetailes()
        {
            return new DepartmentDAL().GetDepartmentDetailList(String.Empty, "DepartId desc");
        }
        public DataSet GetDepartmentDetailList(string filter, string sort)
        {
            return new DepartmentDAL().GetDepartmentDetailList(filter, sort);
        }
        public bool DeleteDepartment(int departId)
        {
            return new DepartmentDAL().DeleteDepartment(departId);
        }
        public void ChangeApprovedStatus(int departId)
        {
            DepartmentDAL depart = new DepartmentDAL();
            int status = depart.GetDepartmentDetail(departId).Approved;
            if (status == 0) depart.ApproveDepartment(departId, true);
            else depart.ApproveDepartment(departId, false);
        }
        public DataSet GetDepartmentList(string fields, string filter, string sort, int currentPageIndex, int pageSize, out int recordCount)
        {
            return new DepartmentDAL().GetDepartmentList(fields, filter, sort, currentPageIndex, pageSize, out recordCount);
        }

    }
}
