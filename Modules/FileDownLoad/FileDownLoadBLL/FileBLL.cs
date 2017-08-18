using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Modules.File
{
   public class FileBLL
    {
       public int AddUploadFile(FileDetail detail)
       {
           return new FileDAL().AddUploadFile(detail);
       }

       public bool UpdateUploadFile(FileDetail detail)
       {
           return new FileDAL().UpdateUploadFileInfo(detail);
       }

       public FileDetail GetFileDetail(int fileId)
       {
           return new FileDAL().GetFileDetail(fileId);
       }

       //20071213加 根据文件的类别号取得所属文件列表
       public DataSet GetFileByCategoryId(int CategoryId)
       {
           return new FileDAL().GetFileByCategoryId(CategoryId);
       }

       //20071213加 根据文件的类别名称取得所属文件列表
       public DataSet GetFileByCategoryName(string CategoryName)
       {
           return new FileDAL().GetFileByCategoryName(CategoryName);
       }

       public DataSet GetAllFilesDetailInfo()
       {
           return new FileDAL().GetAllFilesDetailInfo();
       }

       public bool DeleteUploadFile(int fileId)
       {
           return new FileDAL().DeleteUploadFile(fileId);
       }
    }
}
