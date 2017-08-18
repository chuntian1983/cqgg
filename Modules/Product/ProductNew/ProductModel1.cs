using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Product
{
   public class ProductModel1
   {

    public ProductModel1()
    { }
    #region Model
    private int _productid;
    private string _name;
    private int _sort;
    private string _imagelink;
    private decimal _price;
    private string _remark;
    private int _categoryid;
    private DateTime _addeddate;
    private int _addeduserid;
    private int _main;
    private int _lasts;
    private string _picmain;
    private string _info;
    private string _plus;
    /// <summary>
    /// 
    /// </summary>
    public int ProductId
    {
        set { _productid = value; }
        get { return _productid; }
    }
    /// <summary>
    /// 
    /// </summary>
    public string Name
    {
        set { _name = value; }
        get { return _name; }
    }
    /// <summary>
    /// 
    /// </summary>
    public int Sort
    {
        set { _sort = value; }
        get { return _sort; }
    }
    /// <summary>
    /// 
    /// </summary>
    public string ImageLink
    {
        set { _imagelink = value; }
        get { return _imagelink; }
    }
    /// <summary>
    /// 
    /// </summary>
    public decimal Price
    {
        set { _price = value; }
        get { return _price; }
    }
    /// <summary>
    /// 
    /// </summary>
    public string Remark
    {
        set { _remark = value; }
        get { return _remark; }
    }
    /// <summary>
    /// 
    /// </summary>
    public int CategoryId
    {
        set { _categoryid = value; }
        get { return _categoryid; }
    }
    /// <summary>
    /// 
    /// </summary>
    public DateTime AddedDate
    {
        set { _addeddate = value; }
        get { return _addeddate; }
    }
    /// <summary>
    /// 
    /// </summary>
    public int AddedUserId
    {
        set { _addeduserid = value; }
        get { return _addeduserid; }
    }
    /// <summary>
    /// 首页推荐（0:不推荐1:推荐）
    /// </summary>
    public int Main
    {
        set { _main = value; }
        get { return _main; }
    }
    /// <summary>
    /// 最新推荐(0:不推荐1:推荐)
    /// </summary>
    public int lasts
    {
        set { _lasts = value; }
        get { return _lasts; }
    }
    /// <summary>
    /// 
    /// </summary>
    public string PicMain
    {
        set { _picmain = value; }
        get { return _picmain; }
    }
    /// <summary>
    /// 
    /// </summary>
    public string Info
    {
        set { _info = value; }
        get { return _info; }
    }
    /// <summary>
    /// 相关产品
    /// </summary>
    public string Plus
    {
        set { _plus = value; }
        get { return _plus; }
    }
    #endregion Model
    }
}