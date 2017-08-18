using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Modules.Job
{
    public class PostBLL
    {
        /// <summary>
        /// 根据企业会员编号取得招聘信息
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public PostDetail GetPostDetail(int postId)
        {
            return new PostDAL().GetPostDetail(postId);
        }

        public int AddPost(PostDetail detail)
        {
            return new PostDAL().AddPost(detail);
        }

        public bool UpdatePost(PostDetail detail)
        {
            return new PostDAL().UpdatePost(detail);
        }

        public DataSet GetAllPostDetailes()
        {
            return new PostDAL().GetAllPostDetailes();
        }
        public bool DeletePost(int postId)
        {
            return new PostDAL().DeletePost(postId);
        }
        /// <summary>
        /// 新添加的　发布工作岗位的审核071112 Yj
        /// </summary>
        /// <param name="postId"></param>
        public void ChangeApprovedStatus(int postId)
        {
            PostDAL post = new PostDAL();
            int status = post.GetPostDetail(postId).Approved;
            if (status == 0) post.ApprovePost(postId, true);
            else post.ApprovePost(postId, false);
        }
        /// <summary>
        /// 新添加的　发布工作岗位的推荐071115 Yj
        /// </summary>
        /// <param name="postId"></param>
        public void ChangeTjStatus(int postId)
        {
            PostDAL post = new PostDAL();
            int status = post.GetPostDetail(postId).Tj;
            if (status == 0) post.TjPost(postId, true);
            else post.TjPost(postId, false);
        }


        //根据公司名称查询
        public DataSet GetCommpanyInfo(string where)
        {
            return new PostDAL().GetCommpanyInfo(where);
        }

        //根据岗位编号取得岗位信息
        public DataSet GetGWInfo(int postId)
        {
            return new PostDAL().GetGWInfo(postId);
        }

        //根据企业会员编号取得公司招聘信息列表
        public DataSet GetPostListByID(int MemberId)
        {
            return new PostDAL().GetPostListByID(MemberId);
        }
        public int GetTotalPostNum()
        {
            return new PostDAL().GetTotalPostNum();
        }

        public int GetWeeklyPostNum()
        {
            return new PostDAL().GetWeeklyPostNum();
        }
    }
}
