using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data;
using Maticsoft.DBUtility;

/// <summary>
///WebService 的摘要说明
/// </summary>
[WebService(Namespace = "nongyou")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    [WebMethod]
    public DataTable Getquery(string strsql)
    {
        DataTable dt = new DataTable();
        //dt = DbHelperSQL.Query(strsql).Tables[0];
        return dt;
    }
}
