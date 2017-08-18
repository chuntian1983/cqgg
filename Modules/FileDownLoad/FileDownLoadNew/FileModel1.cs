using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.File
{
   public  class FileModel1
    {
       public FileModel1()
       { }
       #region Model
       private int _fileid;
       private string _description;
       private string _filename;
       private string _filepath;
       private int _downloadcount;
       private int _filecategoryid;
       private int _uploaduserid;
       private DateTime _uploaddate;
       private int _sort;
       private int _newsId;
       /// <summary>
       /// 
       /// </summary>
       public int FileId
       {
           set { _fileid = value; }
           get { return _fileid; }
       }
       /// <summary>
       /// 
       /// </summary>
       public string Description
       {
           set { _description = value; }
           get { return _description; }
       }
       /// <summary>
       /// 
       /// </summary>
       public string FileName
       {
           set { _filename = value; }
           get { return _filename; }
       }
       /// <summary>
       /// 
       /// </summary>
       public string FilePath
       {
           set { _filepath = value; }
           get { return _filepath; }
       }
       /// <summary>
       /// 
       /// </summary>
       public int DownloadCount
       {
           set { _downloadcount = value; }
           get { return _downloadcount; }
       }
       /// <summary>
       /// 
       /// </summary>
       public int FileCategoryId
       {
           set { _filecategoryid = value; }
           get { return _filecategoryid; }
       }
       /// <summary>
       /// 
       /// </summary>
       public int UploadUserId
       {
           set { _uploaduserid = value; }
           get { return _uploaduserid; }
       }
       /// <summary>
       /// 
       /// </summary>
       public DateTime UploadDate
       {
           set { _uploaddate = value; }
           get { return _uploaddate; }
       }
       /// <summary>
       /// 
       /// </summary>
       public int Sort
       {
           set { _sort = value; }
           get { return _sort; }
       }

       public int NewsId
       {
           set { _newsId = value; }
           get { return _newsId; }
       }
       #endregion Model
    }
}
