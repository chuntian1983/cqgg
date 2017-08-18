using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Web;

namespace Modules.Picture
{
    public class PictureBLL
    {
        public int AddUploadPic(PictureDetail detail)
        {
            return new PictureDAL().AddUploadPic(detail);
        }

        public bool UpdateUploadPic(PictureDetail detail)
        {
            return new PictureDAL().UpdateUploadPic(detail);
        }

        public PictureDetail GetPictureDetail(int pictureId)
        {
            return new PictureDAL().GetPicDetail(pictureId);
        }
        public DataSet GetList(string userid,string where)
        {
            return new PictureDAL().GetList(userid,where);
        }
        public DataSet GetList(int deptid, string where)
        {
            return new PictureDAL().GetList(deptid, where);
        }
        public DataSet GetAllPicDetailInfo()
        {
            return new PictureDAL().GetAllPicDetailInfo();
        }
        /// <summary>
        /// 根据部门id获取上传的图片
        /// </summary>
        /// <param name="deptid"></param>
        /// <returns></returns>
        public DataSet GetAllPicDetailInfo(string deptid)
        {
            return new PictureDAL().GetAllPicDetailInfo(deptid);
        }
        public DataSet GetAllPicDetailInfo(string deptid, string imglb)
        {
            return new PictureDAL().GetAllPicDetailInfo(deptid, imglb);
        }
        public bool DeleteUploadPic(int pictureId)
        {
            PictureDAL picture = new PictureDAL();
            PictureDetail detail = picture.GetPicDetail(pictureId);
            string smallPicPath = ConfigurationSettings.AppSettings["smallPicPath"];
            string originalPicPath = ConfigurationSettings.AppSettings["originalPicPath"];
            if (picture.DeleteUploadPic(pictureId))
            {
                try
                {
                    System.IO.File.Delete(HttpContext.Current.Server.MapPath(originalPicPath + detail.OriginalPicPath));
                    System.IO.File.Delete(HttpContext.Current.Server.MapPath(smallPicPath + detail.SmallPicPath));
                }
                catch
                { }
                return true;
            }
            else return false;
            

        }
        public DataSet GetPicList(string fields, string filter, string sort, int currentPageIndex, int pageSize, out int recordCount)
        {
            return new PictureDAL().GetPicList(fields, filter, sort, currentPageIndex, pageSize, out recordCount);
        }
        public DataRow GetPicView(int pictureId)
        {
            return new PictureDAL().GetPicView(pictureId);
        }
    }
}
