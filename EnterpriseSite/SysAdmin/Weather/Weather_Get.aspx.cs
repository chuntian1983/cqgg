using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Web.SessionState;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Net;
using System.Data.SqlClient;
using CommonUtility.DBUtility;
using Modules.Weather;
using Modules.City;



public partial class SysAdmin_Weather_Weather_Get : System.Web.UI.Page
{
    Modules.Weather.WeatherModel modal = new WeatherModel();
    WeatherDAL dal = new WeatherDAL();
    CityDAL dal1 = new CityDAL();

    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void btnStartGet_Click(object sender, EventArgs e)
    {
        //存储过程,获得城市名称
        DataSet ds = dal1.GetList("");
   
        DataTable tb = ds.Tables[0];

        for (int i = 0; i < tb.Rows.Count; i++)
        {
            if (tb.Rows[i]["Code1"].ToString() != "")
            {
                this.lblMsg.Text += "正在获取<strong>" + tb.Rows[i]["CityName"].ToString() + "</strong>天气...";
                GetWeather1(tb.Rows[i]["Code1"].ToString(), tb.Rows[i]["CityName"].ToString());
            }
            else
            {
                this.lblMsg.Text += "<font color='#00FF00'><strong>" + tb.Rows[i]["CityName"].ToString() + "</strong>的天气编码为空!</font><br>";
            }
        }
        this.lblMsg.Text += "<br>完成!";
    }

    private void GetWeather1(string code, string cityName)
    {
       
            string pageUrl = "http://www.weathercn.com/tqyb/detail.jsp?sta_id=" + code;
            WebRequest request = WebRequest.Create(pageUrl);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader read = new StreamReader(stream, System.Text.Encoding.Default);
            string pageCode = read.ReadToEnd();
            pageCode = pageCode.ToLower();
            MatchCollection matches = Regex.Matches(pageCode, @"<TD width=1 bgColor=#d5dae3>([^<]*)<\/TD>", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline);
            string[] fx = new string[matches.Count];
            for( int i=0;i<matches.Count;i++)
            {
                fx[i]=matches[i].Groups[1].Value;
            }
            for (int i = 1; i <= 3; i++)
            {       
                string date = string.Empty;
                pageCode = pageCode.Substring(pageCode.IndexOf("width=155 align=middle class=j12><strong>"));            
                string date1 = pageCode.Substring(pageCode.IndexOf("width=155 align=middle class=j12><strong>"), pageCode.IndexOf("</strong>"));
                date1 = date1.Substring(41);
                date = date1.Replace("年", "-");
                date=date.Replace("月", "-");
                date=date.Replace("日", "");
                

                pageCode = pageCode.Substring(pageCode.IndexOf("alt"));
                string wstate = pageCode.Substring(0, pageCode.IndexOf(" "));
                wstate = wstate.Substring(5);
                wstate = wstate.Substring(0, wstate.IndexOf("\""));

                pageCode = pageCode.Substring(pageCode.IndexOf("<strong>"));
                string temp1 = pageCode.Substring(pageCode.IndexOf("<strong>"), pageCode.IndexOf("℃"));
                temp1 = temp1.Substring(8);
                pageCode = pageCode.Substring(pageCode.IndexOf("℃"));

                pageCode = pageCode.Substring(pageCode.IndexOf("～"));
                string temp2 = pageCode.Substring(pageCode.IndexOf("～"), pageCode.IndexOf("℃"));
                temp2 = temp2.Substring(1);
                pageCode = pageCode.Substring(pageCode.IndexOf("℃"));

                
                //存储过程增加一条天气预报
               
                modal.Place = cityName;
                if (i == 1)
                {
                    modal.dtFillTime = DateTime.Parse(date);
                    modal.WeatherType = Convert.ToString(wstate);
                    modal.HighTemperature=Convert.ToString(temp1);
                    modal.LowTemperature=Convert.ToString(temp2);
                    modal.Windy = fx[i - 1];
                    modal.Windy = "";
                    modal.TomWeatherType = "";
                    modal.TomHighTemperature = "";
                    modal.TomLowTemperature = "";
                    modal.TomWindy = "";
                    modal.ThirdWeatherType = "";
                    modal.ThirdHighTemperature = "";
                    modal.ThirdLowTemperature = "";
                    modal.ThirdWindy = "";
                    modal.Content = "";
                    modal.TomContent = "";
                    modal.ThirdContent = "";
                    
                }
                else if (i == 2)
                {
                   modal.dtFillTime = DateTime.Parse(date);
                   modal.WeatherType = "";
                   modal.HighTemperature = "";
                   modal.LowTemperature = "";
                   modal.Windy = "";
                   modal.TomWeatherType=Convert.ToString(wstate);
                   modal.TomHighTemperature=Convert.ToString(temp1);
                   modal.TomLowTemperature=Convert.ToString(temp2);
                   //modal.TomWindy= Convert.ToString(wind);
                   modal.Windy = fx[i - 1];
                   modal.TomWindy = "";
                   modal.ThirdWeatherType = "";
                   modal.ThirdHighTemperature = "";
                   modal.ThirdLowTemperature = "";
                   modal.ThirdWindy = "";
                   modal.Content = "";
                   modal.TomContent = "";
                   modal.ThirdContent = "";
                   
                }
                else if (i == 3)
                {
                    modal.dtFillTime = DateTime.Parse(date);
                    modal.WeatherType = "";
                    modal.HighTemperature = "";
                    modal.LowTemperature = "";
                    modal.Windy = "";
                    modal.TomWeatherType ="";
                    modal.TomHighTemperature = "";
                    modal.TomLowTemperature = "";
                    modal.TomWindy ="";
                    modal.ThirdWeatherType = Convert.ToString(wstate);
                    modal.ThirdHighTemperature = Convert.ToString(temp1) ;
                    modal.ThirdLowTemperature = Convert.ToString(temp2);
                    //modal.ThirdWindy = Convert.ToString(wind);
                    modal.Windy = fx[i - 1];
                    modal.ThirdWindy = "";
                    modal.Content = "";
                    modal.TomContent = "";
                    modal.ThirdContent = "";
                    
                }
                dal.Add(modal);
            }
           

            this.lblMsg.Text += "成功!<br>";
            stream.Close();
            read.Close();
      //  }
        //catch
        //{
        //    this.lblMsg.Text += "<font color='#FF0000'>失败!</font><br>";
        //}
    }

   
}
