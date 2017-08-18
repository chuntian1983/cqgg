using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Modules.Product
{
    public class ProductBLL
    {
        public ProductDetail GetProductDetail(int productId)
        {
            return new ProductDAL().GetProductDetail(productId);
        }

        public int AddProduct(ProductDetail detail)
        {
            return new ProductDAL().AddProduct(detail);
        }

        public bool UpdateProduct(ProductDetail detail)
        {
            return new ProductDAL().UpdateProduct(detail);
        }

        public bool DeleteProduct(int productId)
        {

            return new ProductDAL().DeleteProduct(productId);


        }


        public DataSet GetProductList(string fields, string filter, string sort, int currentPageIndex, int pageSize, out int recordCount)
        {
            return new ProductDAL().GetProductList(fields, filter, sort, currentPageIndex, pageSize, out recordCount);
        }
    }
}
