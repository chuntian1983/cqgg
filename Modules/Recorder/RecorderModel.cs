using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Recorder
{
   public class RecorderModel
    {
       public RecorderModel()
       { }
       #region Model
       private int _id;
       private string _recorderid;
       private string _name;
       private string _degree;
       private string _gradetimeschool;
       private string _speciality;
       private string _zzqk;
       private string _zcqk;
       private string _zcid;
       private string _companyinfo;
       private string _tcf;
       private string _tcid;
       private string _gzqk;
       private string _pay;
       private string _ydw;
       private string _xdw;
       private DateTime _addtime;
       /// <summary>
       /// 
       /// </summary>
       public int ID
       {
           set { _id = value; }
           get { return _id; }
       }
       /// <summary>
       /// 档案号
       /// </summary>
       public string RecorderID
       {
           set { _recorderid = value; }
           get { return _recorderid; }
       }
       /// <summary>
       /// 姓名
       /// </summary>
       public string Name
       {
           set { _name = value; }
           get { return _name; }
       }
       /// <summary>
       /// 学历
       /// </summary>
       public string Degree
       {
           set { _degree = value; }
           get { return _degree; }
       }
       /// <summary>
       /// 毕业时间与院校
       /// </summary>
       public string GradeTimeSchool
       {
           set { _gradetimeschool = value; }
           get { return _gradetimeschool; }
       }
       /// <summary>
       /// 毕业专业
       /// </summary>
       public string Speciality
       {
           set { _speciality = value; }
           get { return _speciality; }
       }
       /// <summary>
       /// 转正情况
       /// </summary>
       public string ZZQK
       {
           set { _zzqk = value; }
           get { return _zzqk; }
       }
       /// <summary>
       /// 职称情况
       /// </summary>
       public string ZCQK
       {
           set { _zcqk = value; }
           get { return _zcqk; }
       }
       /// <summary>
       /// 职称证书编号
       /// </summary>
       public string ZCID
       {
           set { _zcid = value; }
           get { return _zcid; }
       }
       /// <summary>
       /// 工作单位情况
       /// </summary>
       public string CompanyInfo
       {
           set { _companyinfo = value; }
           get { return _companyinfo; }
       }
       /// <summary>
       /// 统筹费
       /// </summary>
       public string TCF
       {
           set { _tcf = value; }
           get { return _tcf; }
       }
       /// <summary>
       /// 统筹编号
       /// </summary>
       public string TCID
       {
           set { _tcid = value; }
           get { return _tcid; }
       }
       /// <summary>
       /// 工资情况
       /// </summary>
       public string GZQK
       {
           set { _gzqk = value; }
           get { return _gzqk; }
       }
       /// <summary>
       /// 档管费
       /// </summary>
       public string Pay
       {
           set { _pay = value; }
           get { return _pay; }
       }
       /// <summary>
       /// 调出单位
       /// </summary>
       public string YDW
       {
           set { _ydw = value; }
           get { return _ydw; }
       }
       /// <summary>
       /// 调入单位
       /// </summary>
       public string XDW
       {
           set { _xdw = value; }
           get { return _xdw; }
       }
       /// <summary>
       /// 添加时间
       /// </summary>
       public DateTime AddTime
       {
           set { _addtime = value; }
           get { return _addtime; }
       }
       #endregion Model
   }
}
