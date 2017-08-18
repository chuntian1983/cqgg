using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Modules.File
{
  public  class FileCategoryBLL
    {
        public DataSet GetAllFileCategories()
        {
            return new FileCategoryDAL().GetAllFileCategories();
        }
        public int AddCategory(FileCategoryDetail detail)
        {
            return new FileCategoryDAL().AddCategory(detail);
        }
        public bool DeleteCategory(int fileCategoryId)
        {
            return new FileCategoryDAL().DeleteCategory(fileCategoryId);
        }
      public bool UpdateCategory(FileCategoryDetail detail)
        {
            return new FileCategoryDAL().UpdateCategory(detail);
        }

      public FileCategoryDetail GetCategoryDetail(int fileCategoryId)
        {
            return new FileCategoryDAL().GetFileCategoryDetail(fileCategoryId);
        }
    }
}
