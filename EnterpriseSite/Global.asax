<%@ Application Language="C#" %>
<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // 在应用程序启动时运行的代码
        //string strcon=System.Configuration.ConfigurationSettings.AppSettings["adoConstr"].ToString();
        //System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(strcon);
        //string sql = "select count from T_Count where id=1";
        //conn.Open();
        //System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sql,conn);
        //Application["count"] = Convert.ToInt32(cmd.ExecuteScalar());
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  在应用程序关闭时运行的代码

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // 在出现未处理的错误时运行的代码

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // 在新会话启动时运行的代码
        // 在新会话启动时运行的代码
        //Application.Lock();
        //Application["count"] = Convert.ToInt32(Application["count"].ToString()) + 1;
        //string strcon = System.Configuration.ConfigurationSettings.AppSettings["adoConstr"].ToString();
        //System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(strcon);
        //conn.Open();
        //System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("update T_Count set Count=" + Convert.ToInt32(Application["count"].ToString()) + " where id=1", conn);
        //cmd.ExecuteNonQuery();
        //Application.UnLock();
    }

    void Session_End(object sender, EventArgs e) 
    {
        // 在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
        // 或 SQLServer，则不会引发该事件。

    }
       
</script>
