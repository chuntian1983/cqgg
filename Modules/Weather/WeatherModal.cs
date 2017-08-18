using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Weather
{
    public class WeatherModel
    {
        public WeatherModel()
        { }
        #region Model
        private decimal _id;
        private string _place;
        private string _weathertype;
        private string _lowtemperature;
        private string _hightemperature;
        private string _content;
        private DateTime _dtfilltime;
        private string _windy;
        private string _tomweathertype;
        private string _tomlowtemperature;
        private string _tomhightemperature;
        private string _tomcontent;
        private string _tomwindy;
        private string _thirdweathertype;
        private string _thirdlowtemperature;
        private string _thirdhightemperature;
        private string _thirdcontent;
        private string _thirdwindy;
        private DateTime _filltime;
        /// <summary>
        /// 
        /// </summary>
        public decimal ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Place
        {
            set { _place = value; }
            get { return _place; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WeatherType
        {
            set { _weathertype = value; }
            get { return _weathertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LowTemperature
        {
            set { _lowtemperature = value; }
            get { return _lowtemperature; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HighTemperature
        {
            set { _hightemperature = value; }
            get { return _hightemperature; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime dtFillTime
        {
            set { _dtfilltime = value; }
            get { return _dtfilltime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Windy
        {
            set { _windy = value; }
            get { return _windy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TomWeatherType
        {
            set { _tomweathertype = value; }
            get { return _tomweathertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TomLowTemperature
        {
            set { _tomlowtemperature = value; }
            get { return _tomlowtemperature; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TomHighTemperature
        {
            set { _tomhightemperature = value; }
            get { return _tomhightemperature; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TomContent
        {
            set { _tomcontent = value; }
            get { return _tomcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TomWindy
        {
            set { _tomwindy = value; }
            get { return _tomwindy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ThirdWeatherType
        {
            set { _thirdweathertype = value; }
            get { return _thirdweathertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ThirdLowTemperature
        {
            set { _thirdlowtemperature = value; }
            get { return _thirdlowtemperature; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ThirdHighTemperature
        {
            set { _thirdhightemperature = value; }
            get { return _thirdhightemperature; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ThirdContent
        {
            set { _thirdcontent = value; }
            get { return _thirdcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ThirdWindy
        {
            set { _thirdwindy = value; }
            get { return _thirdwindy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime FillTime
        {
            set { _filltime = value; }
            get { return _filltime; }
        }
        #endregion Model
    }
}
