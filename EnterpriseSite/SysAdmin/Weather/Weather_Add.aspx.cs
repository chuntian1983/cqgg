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
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.SessionState;
using CommonUtility.DBUtility;
using Modules.Weather;
using Modules.City;


public partial class SysAdmin_Weather_Weather_Add : System.Web.UI.Page
{
    public int id=0;
    WeatherDAL dal = new WeatherDAL();
    Modules.Weather.WeatherModel modal = new WeatherModel();
    
    CityDAL dal1 = new CityDAL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindCity();
            if (Request.QueryString["ID"] != null)
            {
                id = Int32.Parse(Request.QueryString["ID"].ToString());
                GetWeatherInfo(id);
            }
        }
    }

    private void BindCity()
    {
        //得到城市名称
        DataSet ds = dal1.GetList("");
        dpl_City.DataSource = ds;
        dpl_City.DataTextField = "CityName";
        dpl_City.DataValueField = "CityID";
        dpl_City.DataBind();
    }

    private void GetWeatherInfo(int id)
    {
        //根据ID取得某条天气预报
        //DataSet ds =dal.GetList(id);
        string sql = "select * from T_Weather_new where ID=" + id + "";
        DataSet ds= SQLHelper.Query(sql);

        if (ds.Tables[0].Rows.Count == 1)
        {
            DataRow dr = ds.Tables[0].Rows[0];

            dpl_City.SelectedValue = dr["Place"].ToString();
            txt_WeatherType.Text = dr["WeatherType"].ToString();
            txt_LowTemperature.Text = dr["LowTemperature"].ToString();
            txt_HighTemperature.Text = dr["HighTemperature"].ToString();
            txt_Windy.Text = dr["Windy"].ToString();
            txt_TomWeatherType.Text = dr["TomWeatherType"].ToString();
            txt_TomLowTemperature.Text = dr["TomLowTemperature"].ToString();
            txt_TomHighTemperature.Text = dr["TomHighTemperature"].ToString();
            txt_TomWindy.Text = dr["TomWindy"].ToString();
            txt_ThirdWeatherType.Text = dr["ThirdWeatherType"].ToString();
            txt_ThirdLowTemperature.Text = dr["ThirdLowTemperature"].ToString();
            txt_ThirdHighTemperature.Text = dr["ThirdHighTemperature"].ToString();
            txt_ThirdWindy.Text = dr["ThirdWindy"].ToString();
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {


        if(Request.QueryString["ID"]!=null)
			{
				id=Int32.Parse(Request.QueryString["ID"].ToString());
			}
			else
			{
				id=0;
			}
			if(id==0)
			{
				try
				{
                    //如果数据库中没记录，就增加一条天气预报
                    modal.Place = dpl_City.SelectedValue.ToString();
                    modal.WeatherType = txt_WeatherType.Text;
                    modal.LowTemperature = txt_LowTemperature.Text;
                    modal.HighTemperature = txt_HighTemperature.Text;
                    modal.Windy = txt_Windy.Text;
                    modal.TomWeatherType = txt_TomWeatherType.Text;
                    modal.TomLowTemperature = txt_TomLowTemperature.Text;
                    modal.TomHighTemperature = txt_TomHighTemperature.Text;
                    modal.TomWindy = txt_TomWindy.Text;
                    modal.ThirdWeatherType = txt_ThirdWeatherType.Text;
                    modal.ThirdLowTemperature = txt_ThirdLowTemperature.Text;
                    modal.ThirdHighTemperature = txt_ThirdHighTemperature.Text;
                    modal.ThirdWindy = txt_ThirdWindy.Text;
                    modal.FillTime = DateTime.Now;
                    dal.Add(modal);
					Response.Redirect("Weather_List.aspx");
				}
				catch(Exception ex)
				{
					Response.Write(ex.ToString());
				}
			}
			else
			{
				try
				{
                    //如果数据库中有记录，就更新该条天气预报
                    modal.ID = id;
                    modal.Place = dpl_City.SelectedValue.ToString();
                    modal.WeatherType = txt_WeatherType.Text;
                    modal.LowTemperature = txt_LowTemperature.Text;
                    modal.HighTemperature = txt_HighTemperature.Text;
                    modal.Windy = txt_Windy.Text;
                    modal.TomWeatherType = txt_TomWeatherType.Text;
                    modal.TomLowTemperature = txt_TomLowTemperature.Text;
                    modal.TomHighTemperature = txt_TomHighTemperature.Text;
                    modal.TomWindy = txt_TomWindy.Text;
                    modal.ThirdWeatherType = txt_ThirdWeatherType.Text;
                    modal.ThirdLowTemperature = txt_ThirdLowTemperature.Text;
                    modal.ThirdHighTemperature = txt_ThirdHighTemperature.Text;
                    modal.ThirdWindy = txt_ThirdWindy.Text;
                    dal.Update(modal);
					Response.Redirect("Weather_List.aspx");
				}
				catch(Exception ex)
				{
					Response.Write(ex.ToString());
				}
			}
		}
    }

