using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Modules.Link
{
    public class LinkBLL
    {
        public LinkDetail GetLinkDetail(int linkId)
        {
            return new LinkDAL().GetLinkDetail(linkId);
        }

        public int AddLink(LinkDetail detail)
        {
            return new LinkDAL().AddLink(detail);
        }

        public bool UpdateLink(LinkDetail detail)
        {
            return new LinkDAL().UpdateLink(detail);
        }

        public DataSet GetAllLinkDetailes()
        {
            return new LinkDAL().GetAllLinkDetailes();
        }
        public DataSet GetLinkList(string strwhere)
        {
            return new LinkDAL().GetLinkList(strwhere);
        }
        public bool DeleteLink(int linkId)
        {
            return new LinkDAL().DeleteLink(linkId);
        }
    }
}
