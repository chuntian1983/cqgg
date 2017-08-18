using System;
using System.Text;
using System.Text.RegularExpressions;
namespace Maticsoft.Common
{
	/// <summary>
	/// 显示消息提示对话框。
    /// Copyright (C) Maticsoft
	/// </summary>
	public class MessageBox
	{		
		private  MessageBox()
		{			
		}
        public static string GetWeek(string dt)
        {
            string week = "星期一";
            //根据取得的英文单词返回汉字 
            switch (dt)
            {
                case "Monday":
                    week = "星期一";
                    break;
                case "Tuesday":
                    week = "星期二";
                    break;
                case "Wednesday":
                    week = "星期三";
                    break;
                case "Thursday":
                    week = "星期四";
                    break;
                case "Friday":
                    week = "星期五";
                    break;
                case "Saturday":
                    week = "星期六";
                    break;
                case "Sunday":
                    week = "星期日";
                    break;
            }
            return week;
        }
		/// <summary>
		/// 显示消息提示对话框
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="msg">提示信息</param>
		public static void  Show(System.Web.UI.Page page,string msg)
		{            
            page.ClientScript.RegisterStartupScript(page.GetType(),"message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
		}

		/// <summary>
		/// 控件点击 消息确认提示框
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="msg">提示信息</param>
		public static void  ShowConfirm(System.Web.UI.WebControls.WebControl Control,string msg)
		{
			//Control.Attributes.Add("onClick","if (!window.confirm('"+msg+"')){return false;}");
			Control.Attributes.Add("onclick", "return confirm('" + msg + "');") ;
		}

		/// <summary>
		/// 显示消息提示对话框，并进行页面跳转
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="msg">提示信息</param>
		/// <param name="url">跳转的目标URL</param>
		public static void ShowAndRedirect(System.Web.UI.Page page,string msg,string url)
		{			
            //Response.Write("<script>alert('帐户审核通过！现在去为企业充值。');window.location=\"" + pageurl + "\"</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg + "');window.location=\"" + url + "\"</script>");


		}
        /// <summary>
        /// 显示消息提示对话框，并进行页面跳转
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳转的目标URL</param>
        public static void ShowAndRedirects(System.Web.UI.Page page, string msg, string url)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript' defer>");
            Builder.AppendFormat("alert('{0}');", msg);
            Builder.AppendFormat("top.location.href='{0}'", url);
            Builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());

        }

		/// <summary>
		/// 输出自定义脚本信息
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="script">输出脚本</param>
		public static void ResponseScript(System.Web.UI.Page page,string script)
		{
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>" + script + "</script>");
             
		}
        public static string StripHT(string strHtml)
        {
            Regex regex = new Regex("<.+?>", RegexOptions.IgnoreCase);
            string strOutput = regex.Replace(strHtml, "");
            return strOutput;
        }

	}
}
