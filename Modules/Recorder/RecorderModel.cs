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
       /// ������
       /// </summary>
       public string RecorderID
       {
           set { _recorderid = value; }
           get { return _recorderid; }
       }
       /// <summary>
       /// ����
       /// </summary>
       public string Name
       {
           set { _name = value; }
           get { return _name; }
       }
       /// <summary>
       /// ѧ��
       /// </summary>
       public string Degree
       {
           set { _degree = value; }
           get { return _degree; }
       }
       /// <summary>
       /// ��ҵʱ����ԺУ
       /// </summary>
       public string GradeTimeSchool
       {
           set { _gradetimeschool = value; }
           get { return _gradetimeschool; }
       }
       /// <summary>
       /// ��ҵרҵ
       /// </summary>
       public string Speciality
       {
           set { _speciality = value; }
           get { return _speciality; }
       }
       /// <summary>
       /// ת�����
       /// </summary>
       public string ZZQK
       {
           set { _zzqk = value; }
           get { return _zzqk; }
       }
       /// <summary>
       /// ְ�����
       /// </summary>
       public string ZCQK
       {
           set { _zcqk = value; }
           get { return _zcqk; }
       }
       /// <summary>
       /// ְ��֤����
       /// </summary>
       public string ZCID
       {
           set { _zcid = value; }
           get { return _zcid; }
       }
       /// <summary>
       /// ������λ���
       /// </summary>
       public string CompanyInfo
       {
           set { _companyinfo = value; }
           get { return _companyinfo; }
       }
       /// <summary>
       /// ͳ���
       /// </summary>
       public string TCF
       {
           set { _tcf = value; }
           get { return _tcf; }
       }
       /// <summary>
       /// ͳ����
       /// </summary>
       public string TCID
       {
           set { _tcid = value; }
           get { return _tcid; }
       }
       /// <summary>
       /// �������
       /// </summary>
       public string GZQK
       {
           set { _gzqk = value; }
           get { return _gzqk; }
       }
       /// <summary>
       /// ���ܷ�
       /// </summary>
       public string Pay
       {
           set { _pay = value; }
           get { return _pay; }
       }
       /// <summary>
       /// ������λ
       /// </summary>
       public string YDW
       {
           set { _ydw = value; }
           get { return _ydw; }
       }
       /// <summary>
       /// ���뵥λ
       /// </summary>
       public string XDW
       {
           set { _xdw = value; }
           get { return _xdw; }
       }
       /// <summary>
       /// ���ʱ��
       /// </summary>
       public DateTime AddTime
       {
           set { _addtime = value; }
           get { return _addtime; }
       }
       #endregion Model
   }
}
