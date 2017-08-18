using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Modules.Search
{
    public class SearchHelper
    {
        private SearchHelper()
        { }

        public static string GetFormSearchValue()
        {
            return HttpContext.Current.Request.Form["title"];
        }

        public static string GetFilterString(string[] searchFileds, string title)
        {
            StringBuilder ret =new StringBuilder();
            string[] keys=Regex.Split(title.Trim(), @"\s+", RegexOptions.Compiled);
            ret.Append("( ");
            for(int i=0;i<keys.Length;i++)
            {
                if(i!=0) ret.Append(" or ");
                ret.Append("( ");
                for(int j=0; j<searchFileds.Length;j++)
                { 
                      if(j!=0) ret.Append(" or ");
                      ret.AppendFormat("{0} like '%{1}%'", searchFileds[j], keys[i]);
                }
                ret.Append(") ");
            }
            ret.Append(") ");
            return ret.ToString();
        }
      
        public static string GetFilterString(string[] searchFileds)
        {
            return GetFilterString(searchFileds, GetFormSearchValue());
        }
    }
}
