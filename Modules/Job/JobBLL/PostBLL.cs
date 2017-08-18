using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Modules.Job
{
    public class PostBLL
    {
        /// <summary>
        /// ������ҵ��Ա���ȡ����Ƹ��Ϣ
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
        /// ����ӵġ�����������λ�����071112 Yj
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
        /// ����ӵġ�����������λ���Ƽ�071115 Yj
        /// </summary>
        /// <param name="postId"></param>
        public void ChangeTjStatus(int postId)
        {
            PostDAL post = new PostDAL();
            int status = post.GetPostDetail(postId).Tj;
            if (status == 0) post.TjPost(postId, true);
            else post.TjPost(postId, false);
        }


        //���ݹ�˾���Ʋ�ѯ
        public DataSet GetCommpanyInfo(string where)
        {
            return new PostDAL().GetCommpanyInfo(where);
        }

        //���ݸ�λ���ȡ�ø�λ��Ϣ
        public DataSet GetGWInfo(int postId)
        {
            return new PostDAL().GetGWInfo(postId);
        }

        //������ҵ��Ա���ȡ�ù�˾��Ƹ��Ϣ�б�
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
