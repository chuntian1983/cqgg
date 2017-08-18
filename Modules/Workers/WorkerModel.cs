using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Workers
{
    public class WorkerModel
    {
        public WorkerModel()
        { }
        #region 专家/领导Model
        private int _id;
        private string _name;
        private string _business;
        private string _degree;
        private string _worktel;
        private string _mztel;
        private string _officetel;
        private string _email;
        private string _area;
        private string _science;
        private string _resume;
        private string _imglink;
        private string _looktime;
        private string _prize;
        private int _persontype;
        private int _sort;
        private DateTime _adddate;
        private int _depart;
        /// <summary>
        /// 领导/专家表
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
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
        /// 职位/职称
        /// </summary>
        public string Business
        {
            set { _business = value; }
            get { return _business; }
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
        /// 工作电话/领导电话
        /// </summary>
        public string WorkTel
        {
            set { _worktel = value; }
            get { return _worktel; }
        }
        /// <summary>
        /// 门诊电话
        /// </summary>
        public string MZTel
        {
            set { _mztel = value; }
            get { return _mztel; }
        }
        /// <summary>
        /// 办公室电话
        /// </summary>
        public string OfficeTel
        {
            set { _officetel = value; }
            get { return _officetel; }
        }
        /// <summary>
        /// 电子邮件/工作邮箱
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 分管范围/研究方向
        /// </summary>
        public string Area
        {
            set { _area = value; }
            get { return _area; }
        }
        /// <summary>
        /// 学术专长/主攻学科
        /// </summary>
        public string Science
        {
            set { _science = value; }
            get { return _science; }
        }
        /// <summary>
        /// 简历
        /// </summary>
        public string Resume
        {
            set { _resume = value; }
            get { return _resume; }
        }
        /// <summary>
        /// 照片
        /// </summary>
        public string ImgLink
        {
            set { _imglink = value; }
            get { return _imglink; }
        }
        /// <summary>
        /// 门诊时间
        /// </summary>
        public string LookTime
        {
            set { _looktime = value; }
            get { return _looktime; }
        }
        /// <summary>
        /// 所货奖项
        /// </summary>
        public string Prize
        {
            set { _prize = value; }
            get { return _prize; }
        }
        /// <summary>
        /// 0:领导 1:专家
        /// </summary>
        public int PersonType
        {
            set { _persontype = value; }
            get { return _persontype; }
        }
        /// <summary>
        /// 排序字段
        /// </summary>
        public int Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        /// <summary>
        /// 部门
        /// </summary>
        public int Depart
        {
            set { _depart = value; }
            get { return _depart; }
        }
        #endregion Model
    }
}
