//code by D.

using System;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;
public class safe_360
{

    private const string StrRegex = @"<[^>]+?style=[\w]+?:expression\(|\b(alert|confirm|prompt)\b|^\+/v(8|9)|<[^>]*?=[^>]*?&#[^>]*?>|\b(and|or)\b.{1,6}?(=|>|<|\bin\b|\blike\b)|/\*.+?\*/|<\s*script\b|<\s*img\b|\bEXEC\b|UNION.+?SELECT|UPDATE.+?SET|INSERT\s+INTO.+?VALUES|(SELECT|DELETE).+?FROM|(CREATE|ALTER|DROP|TRUNCATE)\s+(TABLE|DATABASE)";

    public static bool PostData()
    {
        bool result = false;

        for (int i = 0; i < HttpContext.Current.Request.Form.Count; i++)
        {
            result = CheckData(HttpContext.Current.Request.Form[i].ToString());
            if (result)
            {
                break;
            }
        }
        return result;
    }

 
    public static bool GetData()
    {
        bool result = false;

        for (int i = 0; i < HttpContext.Current.Request.QueryString.Count; i++)
        {
            result = CheckData(HttpContext.Current.Request.QueryString[i].ToString());
            if (result)
            {
                break;
            }
        }
        return result;
    }


    public static bool CookieData()
    {
        bool result = false;
        for (int i = 0; i < HttpContext.Current.Request.Cookies.Count; i++)
        {
            result = CheckData(HttpContext.Current.Request.Cookies[i].Value.ToLower());
            if (result)
            {
                break;
            }
        }
        return result;
    
    }
    public static bool referer()
    {
        bool result = false;
        return result = CheckData(HttpContext.Current.Request.UrlReferrer.ToString());
    }

    public static bool CheckData(string inputData)
    {
        if (Regex.IsMatch(inputData, StrRegex))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// 判断是否非法字符true为合法
    /// </summary>
    /// <param name="str_char"></param>
    /// <returns></returns>
    public static bool CheckFromIn(string str_char)
    {
        if (str_char.IndexOf("'") >= 0)
        {
            return false;
        }
        else if (str_char.IndexOf("!") >= 0)
        {

            return false;
        }
        else if (str_char.IndexOf("or") >= 0)
        {

            return false;
        }
        else if (str_char.IndexOf("delete") >= 0)
        {
            return false;
        }
        else if (str_char.IndexOf("and") >= 0)
        {
            return false;
        }
        else if (str_char.IndexOf("update") >= 0)
        {
            return false;
        }
        else if (str_char.IndexOf("insert") >= 0)
        {
            return false;
        }
        else if (str_char.IndexOf(";") >= 0)
        {
            return false;
        }
        else if (str_char.IndexOf("master") >= 0)
        {
            return false;
        }
        else if (str_char.IndexOf("mid") >= 0)
        {
            return false;
        }
        else if (str_char.IndexOf("user") >= 0)
        {
            return false;
        }
        else if (str_char.IndexOf("db_name") >= 0)
        {
            return false;
        }
        else if (str_char.IndexOf("backup") >= 0)
        {
            return false;
        }
        else if (str_char.IndexOf("select") >= 0)
        {
            return false;
        }
        else if (str_char.IndexOf("char") >= 0)
        {
            return false;
        }
        else if (str_char.IndexOf("nchar") >= 0)
        {
            return false;
        }
        else if (str_char.IndexOf("xp_cmdshell") >= 0)
        {
            return false;
        }
        else if (str_char.IndexOf(",") >= 0)
        {
            return false;
        }
        else if (str_char.IndexOf("--") >= 0)
        {
            return false;
        }
        else if (str_char.IndexOf("exec") >= 0)
        {
            return false;
        }
        else if (str_char.IndexOf("from") >= 0)
        {
            return false;
        }
        else if (str_char.IndexOf("update") >= 0)
        {
            return false;
        }
        else if (str_char.IndexOf("count") >= 0)
        {
            return false;
        }
        else if (str_char.IndexOf("/") >= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}
