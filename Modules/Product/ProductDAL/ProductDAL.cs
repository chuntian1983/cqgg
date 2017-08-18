using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonUtility;
using CommonUtility.DBUtility;

namespace Modules.Product
{
    public class ProductDetail
    {
        public int ProductId;
        public string Name;
        public double Price;
        public string ImageLink;
        public int Sort;
        public string Remark;
        public int CategoryId;
        public int AddedUserId;
        public DateTime AddedDate;
        public int Main;//
        public int lasts;//
        public string PicMain;//
        public string Info;//
        public string Plus;//

    }
    internal class ProductDAL
    {
        public ProductDetail GetProductDetail(int productId)
        {
            return GetProductDetailFromDataRow(GetProductDataRow(productId));
        }
        public DataRow GetProductDataRow(int productId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string query = String.Format("Select * from T_Product where ProductId={0}", productId);
            DataSet ds = helper.ExecuteDataset(query);
            if (ds.Tables[0].Rows.Count == 1) return ds.Tables[0].Rows[0];
            return null;
        }

        private ProductDetail GetProductDetailFromDataRow(DataRow info)
        {
            if (info != null)
            {
                ProductDetail detail = new ProductDetail();
                detail.ProductId = (int)info["ProductId"];
                detail.Name = info["Name"].ToString();
                detail.Price = (double)info["Price"];
                detail.Sort = (int)info["Sort"];
                detail.ImageLink = info["ImageLink"].ToString();
                detail.Remark = info["Remark"].ToString();
                detail.CategoryId = (int)info["CategoryId"];
                detail.AddedUserId = (int)info["AddedUserId"];
                detail.AddedDate = Convert.ToDateTime(info["AddedDate"]);
                detail.Main = (int)info["Main"];//
                detail.lasts = (int)info["lasts"];//
                detail.PicMain = info["PicMain"].ToString();//
                detail.Info = info["Info"].ToString();//
                detail.Plus = info["Plus"].ToString();//

                return detail;
            }
            return null;
        }

        public int AddProduct(string name, double price, string imageLink, int sort,
                              int categoryId, string remark, int addedUserId, int main, int lasts, string picmain, string info, string plus)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            IDataParameter[] paras = new IDataParameter[13];
            paras[0] = helper.GetParameter("@Name", name);
            paras[1] = helper.GetParameter("@Price", price);
            paras[2] = helper.GetParameter("@ImageLink", imageLink);
            paras[3] = helper.GetParameter("@Sort", sort);
            paras[4] = helper.GetParameter("@CategoryId", categoryId);
            paras[5] = helper.GetParameter("@Remark", remark);
            paras[6] = helper.GetParameter("@AddedUserId", addedUserId);
            paras[7] = helper.GetParameter("@ProductId", DbType.Int32, 4, ParameterDirection.Output);
            paras[8] = helper.GetParameter("@Main", main);
            paras[9] = helper.GetParameter("@lasts", lasts);
            paras[10] = helper.GetParameter("@PicMain", picmain);
            paras[11] = helper.GetParameter("@Info", info);
            paras[12] = helper.GetParameter("@Plus", plus);

            helper.ExecuteNonQuery("sp_Product_AddProduct", paras);
            return Convert.ToInt32(paras[7].Value);
        }
        public int AddProduct(ProductDetail detail)
        {
            return AddProduct(detail.Name, detail.Price, detail.ImageLink, detail.Sort, detail.CategoryId,
                              detail.Remark, detail.AddedUserId, detail.Main, detail.lasts, detail.PicMain, detail.Info, detail.Plus);
        }

        public bool UpdateProduct(int productId, string name, double price, string imageLink,
                                  int sort, int categoryId, string remark, int main, int lasts, string picmain, string info, string plus)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("Update T_Product Set Name='{0}',Price={1},", name, price);
            sql.AppendFormat("ImageLink='{0}',Sort={1},CategoryId={2} ,", imageLink, sort, categoryId);
            sql.AppendFormat("Main={0},lasts={1},PicMain='{2}',", main, lasts, picmain);//
            sql.AppendFormat("Remark='{0}',Info='{1}',Plus='{2}'", remark, info, plus);//

            sql.AppendFormat("Where ProductId={0}", productId);
            return helper.ExecuteNonQuery(sql.ToString()) > 0;
        }

        public bool UpdateProduct(ProductDetail detail)
        {
            return UpdateProduct(detail.ProductId, detail.Name, detail.Price, detail.ImageLink,
                                 detail.Sort, detail.CategoryId, detail.Remark, detail.Main, detail.lasts, detail.PicMain, detail.Info, detail.Plus);
        }
        public DataSet GetProductList(string fields, string filter, string sort, int currentPageIndex, int pageSize, out int recordCount)
        {
            return PaginationUtility.GetPaginationList(fields, "V_Product", filter, sort, currentPageIndex, pageSize, out recordCount);
        }

        public bool DeleteProduct(int productId)
        {
            AdoHelper helper = AdoHelper.CreateHelper();
            string sql = String.Format("delete from T_Product where ProductId={0}", productId);
            return helper.ExecuteNonQuery(sql) > 0;
        }
    }
}
