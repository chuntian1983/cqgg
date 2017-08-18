using System;
using System.Collections.Generic;
using System.Text;
using CommonUtility.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace Modules.Product
{
    public class ProductDAL1
    {
  
    public ProductDAL1()
    { }

    #region  产品成员方法
    /// <summary>
    /// 是否存在该记录
    /// </summary>
        public bool Exists(int ProductId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_Product");
            strSql.Append(" where ProductId= @ProductId");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductId", SqlDbType.Int,4)
				};
            parameters[0].Value = ProductId;
            return SQLHelper.Exists(strSql.ToString(), parameters);
        }

        //查看产品的所有类别
        public DataSet GetProductSort()
        {
            string sql = "select * from T_Product_Category where ParentCategoryId=0";
            return SQLHelper.Query(sql);
        }
    
    /// <summary>
    /// 增加一条数据
    /// </summary>
        public void Add(ProductModel1 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Product(");
            strSql.Append("Name,Sort,ImageLink,Price,Remark,CategoryId,AddedDate,AddedUserId,Main,lasts,PicMain,Info)");
            strSql.Append(" values (");
            strSql.Append("@Name,@Sort,@ImageLink,@Price,@Remark,@CategoryId,@AddedDate,@AddedUserId,@Main,@lasts,@PicMain,@Info)");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@ImageLink", SqlDbType.VarChar,150),
					new SqlParameter("@Price", SqlDbType.Float,8),
					new SqlParameter("@Remark", SqlDbType.Text),
					new SqlParameter("@CategoryId", SqlDbType.Int,4),
					new SqlParameter("@AddedDate", SqlDbType.DateTime),
					new SqlParameter("@AddedUserId", SqlDbType.Int,4),
					new SqlParameter("@Main", SqlDbType.Int,4),
					new SqlParameter("@lasts", SqlDbType.Int,4),
					new SqlParameter("@PicMain", SqlDbType.VarChar,150),
					new SqlParameter("@Info", SqlDbType.Text)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Sort;
            parameters[2].Value = model.ImageLink;
            parameters[3].Value = model.Price;
            parameters[4].Value = model.Remark;
            parameters[5].Value = model.CategoryId;
            parameters[6].Value = model.AddedDate;
            parameters[7].Value = model.AddedUserId;
            parameters[8].Value = model.Main;
            parameters[9].Value = model.lasts;
            parameters[10].Value = model.PicMain;
            parameters[11].Value = model.Info;

            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }
    /// <summary>
    /// 更新一条数据
    /// </summary>
        public void Update(ProductModel1 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Product set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("ImageLink=@ImageLink,");
            strSql.Append("Price=@Price,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("CategoryId=@CategoryId,");
            strSql.Append("AddedDate=@AddedDate,");
            strSql.Append("AddedUserId=@AddedUserId,");
            strSql.Append("Main=@Main,");
            strSql.Append("lasts=@lasts,");
            strSql.Append("PicMain=@PicMain,");
            strSql.Append("Info=@Info");
            strSql.Append(" where ProductId=@ProductId");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductId", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@ImageLink", SqlDbType.VarChar,150),
					new SqlParameter("@Price", SqlDbType.Float,8),
					new SqlParameter("@Remark", SqlDbType.Text),
					new SqlParameter("@CategoryId", SqlDbType.Int,4),
					new SqlParameter("@AddedDate", SqlDbType.DateTime),
					new SqlParameter("@AddedUserId", SqlDbType.Int,4),
					new SqlParameter("@Main", SqlDbType.Int,4),
					new SqlParameter("@lasts", SqlDbType.Int,4),
					new SqlParameter("@PicMain", SqlDbType.VarChar,150),
					new SqlParameter("@Info", SqlDbType.Text)};
            parameters[0].Value = model.ProductId;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Sort;
            parameters[3].Value = model.ImageLink;
            parameters[4].Value = model.Price;
            parameters[5].Value = model.Remark;
            parameters[6].Value = model.CategoryId;
            parameters[7].Value = model.AddedDate;
            parameters[8].Value = model.AddedUserId;
            parameters[9].Value = model.Main;
            parameters[10].Value = model.lasts;
            parameters[11].Value = model.PicMain;
            parameters[12].Value = model.Info;

            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }
    /// <summary>
    /// 删除一条数据
    /// </summary>
        public void Delete(int ProductId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete T_Product ");
            strSql.Append(" where ProductId=@ProductId");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductId", SqlDbType.Int,4)
				};
            parameters[0].Value = ProductId;
            SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        }

    /// <summary>
    /// 得到一个对象实体
    /// </summary>
        public ProductModel1 GetModel(int ProductId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_Product ");
            strSql.Append(" where ProductId=@ProductId");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductId", SqlDbType.Int,4)};
            parameters[0].Value = ProductId;
            ProductModel1 model = new ProductModel1();
            DataSet ds = SQLHelper.Query(strSql.ToString(), parameters);
            model.ProductId = ProductId;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                if (ds.Tables[0].Rows[0]["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
                }
                model.ImageLink = ds.Tables[0].Rows[0]["ImageLink"].ToString();
                if (ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                if (ds.Tables[0].Rows[0]["CategoryId"].ToString() != "")
                {
                    model.CategoryId = int.Parse(ds.Tables[0].Rows[0]["CategoryId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddedDate"].ToString() != "")
                {
                    model.AddedDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddedDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddedUserId"].ToString() != "")
                {
                    model.AddedUserId = int.Parse(ds.Tables[0].Rows[0]["AddedUserId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Main"].ToString() != "")
                {
                    model.Main = int.Parse(ds.Tables[0].Rows[0]["Main"].ToString());
                }
                if (ds.Tables[0].Rows[0]["lasts"].ToString() != "")
                {
                    model.lasts = int.Parse(ds.Tables[0].Rows[0]["lasts"].ToString());
                }
                model.PicMain = ds.Tables[0].Rows[0]["PicMain"].ToString();
                model.Info = ds.Tables[0].Rows[0]["Info"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

    /// <summary>
    ///取得产品的类别名称
    /// </summary>
    public string GetSortName(int SortID)
    {
        string sql = "select Description from T_Product_Category where CategoryId=" + SortID + "";
        return SQLHelper.GetSingle(sql).ToString();
    }

    //取得首页推荐的产品的信息（一条）
        public DataSet GetIndexProduct(string Type)
        {
            string sql = "select top 1 a.* ,b.Description from T_Product a right join T_Product_Category b on a.CategoryId=b.CategoryId where a.Main=1 and b.Description='" + Type + "'";
            return SQLHelper.Query(sql);
        }
        
        //取得首页显示的产品图片 07.7.20
        public DataSet GetIndexProductPic(int num)
        {
            string sql = "select top " + num + " * from T_Product where  lasts=1 order by AddedDate desc";
            return SQLHelper.Query(sql);
        }


        //Top 中显示车套锁产品的列表名称
        public DataSet GetProductName()
        {
            string sql = "select  top 8 b.Description,a.* from T_Product_Category b right join T_Product a on b.CategoryId=a.CategoryId where b.Description='车套锁系列' order by ProductId asc";
            return SQLHelper.Query(sql);
        }
         
        //查找产品
        public DataSet SearchProduct(string pname)
        {
            string sql = @"select * from T_Product where 1=1 and  Name like '%" + pname + "%' order by AddedDate desc";
            return SQLHelper.Query(sql);
        }
    /// <summary>
    /// 获得数据列表
    /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_Product ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by AddedDate  desc");
            return SQLHelper.Query(strSql.ToString());
        }
    #endregion  成员方法

  }
}
