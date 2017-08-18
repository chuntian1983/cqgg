using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.IO;

namespace Modules.Files
{
    public class FileOper
    {
        public FileOper()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }

        /// <summary>
        /// ��ȡһ���ļ��ڵ�����
        /// </summary>
        /// <param name="FromPath"></param>
        /// <returns></returns>
        public static string ReadFile(string FromPath)
        {

            string filename = System.Web.HttpContext.Current.Server.MapPath(FromPath);

            StreamReader reader = null;
            try
            {
                reader = new StreamReader(filename, Encoding.GetEncoding("gb2312"));
                string temp1 = reader.ReadToEnd();
                reader.Close();
             return temp1;
             }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// ���½�һ���ĵ��ַ���д���ĵ�
        /// </summary>
        /// <param name="FromPath"></param>
        /// <param name="Body"></param>
        public static void CreateFile(string FromPath, string Body)
        {
            string filename = System.Web.HttpContext.Current.Server.MapPath(FromPath);

            try
            {
                StreamWriter sw = null;
                sw = new StreamWriter(filename, false, Encoding.GetEncoding("utf-8")); ;
                sw.Write(Body);
                sw.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DelFile(string FromPath)
        {
            string filename = System.Web.HttpContext.Current.Server.MapPath(FromPath);

            try
            {
                System.IO.File.Delete(filename);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
