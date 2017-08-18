using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Modules.Picture
{
   public class PictureCategoryBLL
    {
        public DataSet GetAllPicCategories()
        {
            return new PictureCategoryDAL().GetAllPictureCategories();
        }
        public int AddCategory(PictureCategoryDetail detail)
        {
            return new PictureCategoryDAL().AddCategory(detail);
        }
        public bool DeleteCategory(int categoryId)
        {
            return new PictureCategoryDAL().DeleteCategory(categoryId);
        }
       public bool UpdateCategory(PictureCategoryDetail detail)
        {
            return new PictureCategoryDAL().UpdateCategory(detail);
        }

       public PictureCategoryDetail GetCategoryDetail(int categoryId)
        {
            return new PictureCategoryDAL().GetPictureCategoryDetail(categoryId);
        }
    }
}
