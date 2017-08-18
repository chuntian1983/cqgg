using System;
using System.Collections.Generic;
using System.Text;
using CommonUtility.DBUtility;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CommonUtility
{
    public static class CommClass
    {
        /// <summary>
        /// 总访问量
        /// </summary>
        public static string Getzs()
        {
            string fwl = "";
            AdoHelper helper = AdoHelper.CreateHelper();
            helper.ExecuteNonQuery("update t_zs set zs=zs+385");
            DataTable dtfwl = helper.ExecuteDataset("select * from t_zs").Tables[0];
            fwl = dtfwl.Rows[0]["zs"].ToString();
            return fwl;
           
        }
        /// <summary>
        /// 今日访问量
        /// </summary>
        /// <returns></returns>
        public static string Getjrs()
        {
            string jts = "";
            AdoHelper helper = AdoHelper.CreateHelper();
            string jtime = System.DateTime.Now.ToString("yyyy-MM-dd");
            DataTable jrdt = new DataTable();
            jrdt = helper.ExecuteDataset("select * from t_jrs where sj='" + jtime + "'").Tables[0];
            if (jrdt.Rows.Count > 0)
            {
                helper.ExecuteNonQuery("update t_jrs set jrs=jrs+27 where sj='" + jtime + "'");
                jrdt = new DataTable();
                jrdt = helper.ExecuteDataset("select * from t_jrs where sj='" + jtime + "'").Tables[0];
                jts = jrdt.Rows[0]["jrs"].ToString();
            }
            else
            {
                helper.ExecuteNonQuery("insert into t_jrs (jrs,sj)  values(1348,'" + jtime + "')");
                jrdt = new DataTable();
                jrdt = helper.ExecuteDataset("select * from t_jrs where sj='" + jtime + "'").Tables[0];
                jts = jrdt.Rows[0]["jrs"].ToString();
            }
            return jts;
        }
        /// <summary>
        /// 添加修改页面取值
        /// 
        /// </summary>
        /// <param name="cc"></param>
        /// <returns></returns>
        public static Dictionary<string, string> Add(System.Web.UI.ControlCollection cc)
        {
            Dictionary<string, string> dc = new Dictionary<string, string>();
            foreach (Control c in cc)
            {
                if (c is TextBox)
                {
                    TextBox tb = c as TextBox;
                    dc.Add(tb.ID, tb.Text.Trim());

                }
                else if (c is DropDownList)
                {
                    DropDownList tb = c as DropDownList;
                    dc.Add(tb.ID, tb.SelectedValue);

                }
                else if (c is System.Web.UI.HtmlControls.HtmlInputText)
                {
                    HtmlInputText ht = c as HtmlInputText;
                    dc.Add(ht.ID, ht.Value);
                }
                else if (c is RadioButtonList)
                {
                    RadioButtonList tb = c as RadioButtonList;
                    dc.Add(tb.ID, tb.SelectedValue);
                }
            }
            return dc;
        }
        /// <summary>
        /// 添加修改页面取值
        /// 
        /// </summary>
        /// <param name="cc"></param>
        /// <returns></returns>
        public static  void Addnull(System.Web.UI.ControlCollection cc)
        {
           
            foreach (Control c in cc)
            {
                if (c is TextBox)
                {
                    TextBox tb = c as TextBox;
                    tb.Text = "";

                }
               
            }
            
        }
        /// <summary>
        /// 显示页面赋值
        /// </summary>
        /// <param name="cc"></param>
        /// <returns></returns>
        public static void ViewPage(System.Web.UI.ControlCollection cc, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                foreach (Control c in cc)
                {
                    if (c is TextBox)
                    {
                        TextBox tb = (TextBox)c;
                        tb.Text = dt.Rows[0][tb.ID] == null ? "" : dt.Rows[0][tb.ID].ToString();
                    }
                    else if (c is DropDownList)
                    {
                        DropDownList tb = (DropDownList)c;
                        tb.SelectedValue = dt.Rows[0][tb.ID] == null ? "" : dt.Rows[0][tb.ID].ToString();
                    }
                    else if (c is System.Web.UI.HtmlControls.HtmlInputText)
                    {
                        HtmlInputText tb = c as HtmlInputText;
                        tb.Value = dt.Rows[0][tb.ID] == null ? "" : dt.Rows[0][tb.ID].ToString();

                    }
                    else if (c is RadioButtonList)
                    {
                        RadioButtonList tb = c as RadioButtonList;
                        tb.SelectedValue = dt.Rows[0][tb.ID] == null ? "" : dt.Rows[0][tb.ID].ToString();
                    }
                    else if (c is Label)
                    {
                        Label tb = c as Label;
                        tb.Text = dt.Rows[0][tb.ID] == null ? "" : dt.Rows[0][tb.ID].ToString();
                        
                    }
                }

            }
        }
        public static void ViewPage(System.Web.UI.ControlCollection cc, DataTable dt, bool ismyargs)
        {
            foreach (Control c in cc)
            {
                switch (c.GetType().Name)
                {
                    case "TextBox": TextBox tb = c as TextBox;
                        tb.Text = dt.Rows[0][tb.ID] == null ? "" : dt.Rows[0][tb.ID].ToString();
                        break;
                    case "DropDownList":
                        DropDownList tb1 = (DropDownList)c;
                        tb1.SelectedValue = dt.Rows[0][tb1.ID] == null ? "" : dt.Rows[0][tb1.ID].ToString();
                        break;
                    case "Label":
                        Label tb2 = (Label)c;
                        tb2.Text = dt.Rows[0][tb2.ID] == null ? "" : dt.Rows[0][tb2.ID].ToString();
                        break;
                    case "RadioButtonList":
                        RadioButtonList tb3 = c as RadioButtonList;
                        tb3.SelectedValue = dt.Rows[0][tb3.ID] == null ? "" : dt.Rows[0][tb3.ID].ToString();
                        break;
                    default:
                        break;
                }
            }

        }

        private static char[] constant =   
      {   
        '0','1','2','3','4','5','6','7','8','9',  
        'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',   
        'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'   
      };
        public static string GenerateRandomNumber(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(62);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(62)]);
            }
            return newRandom.ToString();
        }
    }
}
