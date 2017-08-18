using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.City
{
    public class CityModal
    {
        public CityModal()
        { }
        #region Model
        private int _cityid;
        private string _cityname;
        private string _code1;
        private string _code2;
        /// <summary>
        /// 
        /// </summary>
        public int CityID
        {
            set { _cityid = value; }
            get { return _cityid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CityName
        {
            set { _cityname = value; }
            get { return _cityname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Code1
        {
            set { _code1 = value; }
            get { return _code1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Code2
        {
            set { _code2 = value; }
            get { return _code2; }
        }
        #endregion Model
    }
}
