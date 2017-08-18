using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Job
{
    public class PersonModel
    {
        public PersonModel()
        { 
            
        }
        #region 应聘人员Model
        private int _seekerid;
        private string _name;
        private int _sex;
        private DateTime _birthday;
        private string _diploma;
        private string _specialty;
        private string _englishlevel;
        private string _school;
        private string _id;
        private string _city;
        private string _address;
        private string _email;
        private string _tel;
        private string _wantedpay;
        private string _selfintro;
        private string _experience;
        private string _skill;
        private string _polity;
        private string _bplace;
        private string _mobile;
        private DateTime _checktime;
        private string _height;
        private int _marry;
        private string _graduatetime;
        private string _certificateno;
        private string _recordplace;
        private string _familystate;
        private string _request;
        /// <summary>
        /// 
        /// </summary>
        public int SeekerId
        {
            set { _seekerid = value; }
            get { return _seekerid; }
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
        public int Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Birthday
        {
            set { _birthday = value; }
            get { return _birthday; }
        }
        /// <summary>
        /// 学历
        /// </summary>
        public string Diploma
        {
            set { _diploma = value; }
            get { return _diploma; }
        }
        /// <summary>
        /// 专业
        /// </summary>
        public string Specialty
        {
            set { _specialty = value; }
            get { return _specialty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EnglishLevel
        {
            set { _englishlevel = value; }
            get { return _englishlevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string School
        {
            set { _school = value; }
            get { return _school; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string City
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 期望待遇
        /// </summary>
        public string WantedPay
        {
            set { _wantedpay = value; }
            get { return _wantedpay; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SelfIntro
        {
            set { _selfintro = value; }
            get { return _selfintro; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Experience
        {
            set { _experience = value; }
            get { return _experience; }
        }
        /// <summary>
        /// 技能/特长
        /// </summary>
        public string Skill
        {
            set { _skill = value; }
            get { return _skill; }
        }
        /// <summary>
        /// 政治面貌
        /// </summary>
        public string Polity
        {
            set { _polity = value; }
            get { return _polity; }
        }
        /// <summary>
        /// 户口所在地
        /// </summary>
        public string BPlace
        {
            set { _bplace = value; }
            get { return _bplace; }
        }
        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 可报到时间
        /// </summary>
        public DateTime CheckTime
        {
            set { _checktime = value; }
            get { return _checktime; }
        }
        /// <summary>
        /// 身高
        /// </summary>
        public string Height
        {
            set { _height = value; }
            get { return _height; }
        }
        /// <summary>
        /// 0:未婚，1:已婚
        /// </summary>
        public int Marry
        {
            set { _marry = value; }
            get { return _marry; }
        }
        /// <summary>
        /// 毕业时间
        /// </summary>
        public string GraduateTime
        {
            set { _graduatetime = value; }
            get { return _graduatetime; }
        }
        /// <summary>
        /// 毕业证书号
        /// </summary>
        public string CertificateNo
        {
            set { _certificateno = value; }
            get { return _certificateno; }
        }
        /// <summary>
        /// 档案所在地
        /// </summary>
        public string RecordPlace
        {
            set { _recordplace = value; }
            get { return _recordplace; }
        }
        /// <summary>
        /// 家庭状况
        /// </summary>
        public string FamilyState
        {
            set { _familystate = value; }
            get { return _familystate; }
        }
        /// <summary>
        /// 工作内容
        /// </summary>
        public string Request
        {
            set { _request = value; }
            get { return _request; }
        }
        #endregion Model
    }
}
