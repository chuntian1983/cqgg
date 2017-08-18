using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Equipment
{
   public class EquipmentModel
    {
       public EquipmentModel()
       { 
       }
       #region Model
       private int _equipmentid;
       private string _equipmentname;
       private string _equipmentpic;
       private int _sort;
       private string _info;
       private DateTime _filltime;
       /// <summary>
       /// 设备编号
       /// </summary>
       public int EquipmentId
       {
           set { _equipmentid = value; }
           get { return _equipmentid; }
       }
       /// <summary>
       /// 设备名称
       /// </summary>
       public string EquipmentName
       {
           set { _equipmentname = value; }
           get { return _equipmentname; }
       }
       /// <summary>
       /// 产品图片
       /// </summary>
       public string EquipmentPic
       {
           set { _equipmentpic = value; }
           get { return _equipmentpic; }
       }
       /// <summary>
       /// 排序
       /// </summary>
       public int Sort
       {
           set { _sort = value; }
           get { return _sort; }
       }
       /// <summary>
       /// 产品介绍
       /// </summary>
       public string Info
       {
           set { _info = value; }
           get { return _info; }
       }
       /// <summary>
       /// 添加时间
       /// </summary>
       public DateTime FillTime
       {
           set { _filltime = value; }
           get { return _filltime; }
       }
       #endregion Model
    }
}
