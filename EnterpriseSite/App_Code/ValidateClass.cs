using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Xml;
using System.Text;
using System.Management;
using System.Security.Cryptography;

/// <summary>
/// 通用验证
/// </summary>
public class ValidateClass
{
    //授权文件路径
    public static string RegFilePath = Path.Combine(SysConfigs.baseDirectory, string.Format("Ap{0}ata \\Gr{1}er{2}ml", "p_D", "antC", "t.x"));

    public ValidateClass()
	{
        //构造函数逻辑
	}

    /// <summary>
    /// 读取授权文件某个节点的值
    /// </summary>
    /// <param name="NotePath"></param>
    /// <param name="CName"></param>
    /// <returns></returns>
    public static string ReadXMLNodeText(string notePath)
    {
        if (File.Exists(RegFilePath))
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(RegFilePath);
            XmlNode node = xml.SelectSingleNode(notePath);
            if (node == null)
            {
                return "";
            }
            else
            {
                return node.InnerText;
            }
        }
        else
        {
            
            return "授权文件不存在，请使用注册程序导入授权文件！";
        }

    }
    public static string ReadXMLNodeText(string notePath, string CName)
    {
        return ReadXMLNodeText(string.Format("{0}/{1}", notePath, CName));
    }

    /// <summary>
    /// 提取授权文件中某张表
    /// </summary>
    /// <param name="tableName"></param>
    /// <param name="filter"></param>
    /// <returns></returns>
    public static DataRow[] GetRegRows(string tableName, string filter)
    {
        return GetRegTable(tableName).Select(filter);
    }
    public static DataRow[] GetRegRows(string tableName, string filter, string sort)
    {
        return GetRegTable(tableName).Select(filter, sort);
    }
    public static DataTable GetRegTable(string tableName)
    {
        if (File.Exists(RegFilePath))
        {
            DataSet RegInfoDS = new DataSet("FinancialDB");
            RegInfoDS.ReadXml(RegFilePath);
            return RegInfoDS.Tables[tableName];
        }
        else
        {
            
            return null;
        }
    }

    /// <summary>
    /// 获取授权信息
    /// </summary>
    /// <returns></returns>
    public static DataSet GetRegDataSet(System.Web.UI.Page page)
    {
        if (File.Exists(RegFilePath))
        {
            DataSet RegInfoDS = new DataSet("FinancialDB");
            RegInfoDS.ReadXml(RegFilePath);
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //服务器端验证
            string SignRegInfo = RegInfoDS.Tables["RegInfo"].Rows[0]["RegInfoSign"].ToString();
            string RegInfoHash = RegInfoDS.Tables["RegInfo"].Rows[0]["RegInfoHash"].ToString();
            RegInfoDS.Tables["RegInfo"].Rows[0]["RegInfoSign"] = "";
            RegInfoDS.Tables["RegInfo"].Rows[0]["RegInfoHash"] = "";
            string _RegInfoHash = FormsAuthentication.HashPasswordForStoringInConfigFile(RegInfoDS.GetXml(), "sha1");
            RegInfoDS.Tables["RegInfo"].Rows[0]["RegInfoHash"] = RegInfoHash;
            //授权文件完整性验证
            if (RegInfoHash == _RegInfoHash && VerifySignedHash(RegInfoDS.GetXml(), SignRegInfo))
            {
                //版本校验
                if (RegInfoDS.Tables["RegInfo"].Rows[0]["VersionType"].ToString() != "CS")
                {
                    
                    Maticsoft.Common.MessageBox.Show(page, "您的授权文件不是当前版本的授权文件！");
                    return null;
                }
                ////本机合法验证
                //if (RegInfoDS.Tables["RegInfo"].Rows[0]["ClientHDid"].ToString().IndexOf(GetMachineCode()) == -1)
                //{
                //    PageClass.UrlRedirect("您的授权文件不是本机的授权文件！", 0);
                //    return null;
                //}
                //系统日期校验
                string lastModify = RegInfoDS.Tables["RegInfo"].Rows[0]["LastModify"].ToString();
                DateTime LastModify = Convert.ToDateTime(lastModify);
                if (DateTime.Now.CompareTo(LastModify) < 0)
                {
                    Maticsoft.Common.MessageBox.Show(page, string.Format("服务器的系统日期不正确，请修改至〖[0]font color=red[1]{0}[0]/font[1]〗之后！", lastModify));
                   // PageClass.UrlRedirect(string.Format("服务器的系统日期不正确，请修改至〖[0]font color=red[1]{0}[0]/font[1]〗之后！", lastModify), 0);
                    return null;
                }
                //使用期限校验
                DateTime AccountDate = System.DateTime.Now;
                //if (!DateTime.TryParse(MainClass.GetTableValue("CW_Account", "AccountDate", "1=1 order by AccountDate desc"), out AccountDate))
                //{
                //    return RegInfoDS;
                //}
                DateTime UseDate = Convert.ToDateTime(RegInfoDS.Tables["RegInfo"].Rows[0]["UseDate"].ToString());
                if (string.Compare(UseDate.ToString("yyyy-MM"), AccountDate.ToString("yyyy-MM")) < 0)
                {
                    Maticsoft.Common.MessageBox.Show(page, "您当前所使用的软件已到期，请致电我公司更换授权文件！");
                    
                    return null;
                }
                //返回注册信息
                return RegInfoDS;
            }
            else
            {
                Maticsoft.Common.MessageBox.Show(page, "软件授权文件已被篡改，请致电我公司更换授权文件！");
                
                return null;
            }
        }
        else
        {
            Maticsoft.Common.MessageBox.Show(page, "授权文件不存在，请使用注册程序导入授权文件！");
           
            return null;
        }
    }

    /// <summary>
    /// 验证使用日期
    /// </summary>
    /// <param name="page"></param>
    /// <returns></returns>
    public static bool ValidateUseDate()
    {
        //系统日期校验
        string lastModify = ReadXMLNodeText("FinancialDB/RegInfo/LastModify");
        DateTime LastModify = Convert.ToDateTime(lastModify);
        if (DateTime.Now.CompareTo(LastModify) < 0)
        {
            PageClass.UrlRedirect(string.Format("服务器的系统日期不正确，请修改至〖[0]font color=red[1]{0}[0]/font[1]〗之后！", lastModify), 0);
            return false;
        }
        //使用期限校验
        DateTime AccountDate = System.DateTime.Now;
        
        DateTime UseDate = Convert.ToDateTime(ReadXMLNodeText("FinancialDB/RegInfo/UseDate"));
        if (string.Compare(UseDate.ToString("yyyy-MM"), AccountDate.ToString("yyyy-MM")) < 0)
        {
            PageClass.UrlRedirect("您当前所使用的软件已到期，请致电我公司更换授权文件！", 0);
            return false;
        }
        return true;
    }

   

   

    

    /// <summary>
    /// 获取机器码
    /// </summary>
    /// <returns></returns>
    public static string GetMachineCode()
    {
        bool GetCodeFlag = false;
        string ClientHDid = string.Empty;
        try
        {
            ClientHDid = GetDiskInfo32.GetHardDiskInfo();
            GetCodeFlag = true;
        }
        catch { }
        if (!GetCodeFlag || ClientHDid.Trim().Length == 0)
        {
            try
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"] == true) { ClientHDid = mo["MacAddress"].ToString(); }
                }
                GetCodeFlag = true;
            }
            catch { }
        }
        if (!GetCodeFlag || ClientHDid.Trim().Length == 0) { ClientHDid = "FEFD9A06-F69A-44B4-AE60-EE612261FF2C"; }
        MD5 md5 = MD5.Create();
        byte[] s = md5.ComputeHash(UTF8Encoding.Default.GetBytes(ClientHDid));
        return BitConverter.ToString(s, 4, 8).Replace("-", "");
    }

    /// <summary>
    /// 验证数字签名
    /// </summary>
    /// <param name="str_VerifyFile"></param>
    /// <param name="str_SignedData"></param>
    /// <returns></returns>
    public static bool VerifySignedHash(string str_VerifyFile, string str_SignedData)
    {
        try
        {
            ASCIIEncoding ByteConverter = new ASCIIEncoding();
            RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();
            string str_Public_Key = "BgIAAACkAABSU0ExAAQAAAEAAQBJ9zOlU9waLfG4Ah8pDXqaltveNqnWmhFIsFY+ibAXaTIQg0cNOPLr9WmIBCADc85Czcjt2u2Mq9Bx7jdSNvElXy+eQ8jZAf31pKSj+bOwOweubDpOGBd+U3ZOhQNDbBVFYWSnMWWBe2M1PIDl+VY2iiOWuQJ2Z+BeWa6yxbQHog==";
            RSAalg.ImportCspBlob(Convert.FromBase64String(str_Public_Key));
            byte[] SignedData = Convert.FromBase64String(str_SignedData);
            byte[] DataToVerify = ByteConverter.GetBytes(str_VerifyFile);
            return RSAalg.VerifyData(DataToVerify, new SHA1CryptoServiceProvider(), SignedData);
        }
        catch
        {
            return false;
        }
    }
}
