using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Workers
{
   public class ExpertOutModel
    {
       public ExpertOutModel()
       { }
       #region 专家出诊Model
       private int _id;
       private string _name;
       private string _characteristic;
       private int _addeduserid;
       private string _outtime;
       private string _price;
       private DateTime _adddate;
       private int _type;
       private int _sort;
       /// <summary>
       /// 专家出诊表
       /// </summary>
       public int ID
       {
           set { _id = value; }
           get { return _id; }
       }
       /// <summary>
       /// 专家名字
       /// </summary>
       public string Name
       {
           set { _name = value; }
           get { return _name; }
       }
       /// <summary>
       /// 专家特色
       /// </summary>
       public string Characteristic
       {
           set { _characteristic = value; }
           get { return _characteristic; }
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
       /// 
       /// </summary>
       public string OutTime
       {
           set { _outtime = value; }
           get { return _outtime; }
       }
       /// <summary>
       /// 挂号费用
       /// </summary>
       public string Price
       {
           set { _price = value; }
           get { return _price; }
       }
       /// <summary>
       /// 
       /// </summary>
       public DateTime AddDate
       {
           set { _adddate = value; }
           get { return _adddate; }
       }

       /// <summary>
       /// 类型　专家出诊0 医师出诊 1
       /// </summary>
       public int Type
       {
           set { _type = value; }
           get { return _type; }
       }

       /// <summary>
       /// 排序
       /// </summary>
       public int Sort
       {
           set { _sort = value; }
           get { return _sort; }
       }
       #endregion Model
    }
}
