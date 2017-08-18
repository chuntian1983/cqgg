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
using Modules.File;
using Modules.Account;
using CommonUtility;
using System.IO;
using System.Data.SqlClient;

public partial class SysAdmin_DownLoad_RecordList : System.Web.UI.Page
{
    private FileBLL _file = new FileBLL();
    private string _mainPath = ConfigurationSettings.AppSettings["uploadFilePath"];
    private string conn1 = ConfigurationSettings.AppSettings["adoConstr"];
  
    private FileCategoryBLL _category = new FileCategoryBLL();

    public bool AllowEdit
    {
        get { return Convert.ToBoolean(ViewState["AllowEdit"]); }
        set { ViewState["AllowEdit"] = value; }
    }

    public bool AllowDel
    {
        get { return Convert.ToBoolean(ViewState["AllowDel"]); }
        set { ViewState["AllowDel"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomPrincipal p = CustomPrincipal.CurrentRequestPrincipal;
            p.Demand(38);
            this.AllowDel = p.HasPermission(53);
            this.AllowEdit = p.HasPermission(51);
            this.gvFileList.Columns[5].Visible = p.HasPermission(54);
            this.gvFileList.Columns[6].Visible = this.AllowEdit || this.AllowDel;
            Bind(0);
        }
    }

    private void Bind(int pageIndex)
    {
        DataSet ds = this._file.GetFileByCategoryName("档案资料");
        this.gvFileList.PageIndex = pageIndex;
        this.gvFileList.PageSize = this.pageBar.PageSize;
        this.gvFileList.DataSource = ds;
        this.gvFileList.DataBind();

        this.pageBar.RecordCount = ds.Tables[0].Rows.Count;
    }
    protected void ibtnDel_Command(object sender, CommandEventArgs e)
    {
        int fileId = Convert.ToInt32(e.CommandArgument);
        string path = this._mainPath + this._file.GetFileDetail(fileId).FilePath;
        if (this._file.DeleteUploadFile(fileId))
        {
            try
            {
                File.Delete(Server.MapPath(path));
            }
            catch
            { throw; }
        }
        Bind(this.pageBar.PageIndex);
    }
    protected void pageBar_PageIndexChanged(object sender, PageIndexChangedEventArguments e)
    {
        Bind(e.NewPageIndex);
    }

    protected void lbtnDownload_Command(object sender, CommandEventArgs e)
    {
        int fileId = Convert.ToInt32(e.CommandArgument);
        bool isSuccess = true;
        FileDetail detail = this._file.GetFileDetail(fileId);
        string extensionName = detail.FilePath.Substring(detail.FilePath.LastIndexOf("."));
        string fileName = String.Format("attachment; filename=\"{0}{1}\"", HttpUtility.UrlEncode(detail.FileName), extensionName);
        string path = Server.MapPath(this._mainPath + detail.FilePath);
        try
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", fileName);
            Response.AddHeader("Content-Length", fs.Length.ToString());
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);
            Response.BinaryWrite(buffer);
        }
        catch (Exception ex)
        {
            isSuccess = false;
            Context.Response.ClearHeaders();
            Context.Response.Clear();
            Context.Response.ContentType = "text/html";
            //Context.Response.Write("<script>alert('" + ex.Message + "');</script>");
            JSUtility.Alert(ex.Message);
        }
        if (isSuccess) Context.Response.End();
    }

  
    protected void lbtnIntoSQL_Command(object sender, CommandEventArgs e)
    {
        int fileId = Convert.ToInt32(e.CommandArgument);
        //SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=;database=NewDataBase");
        SqlConnection conn = new SqlConnection(conn1);
         conn.Open();
         //try
        // {
             string path =Server.MapPath (this._mainPath + this._file.GetFileDetail(fileId).FilePath);//获得Excel文件路径
             string fileurl = typename(path);
             if (fileurl == "")
             {
                 Response.Write("<script language='javascript'>alert('导入文件格式不对!');</script>");
                 return;
             }

             DataSet ds = new DataSet();//取得数据集
             ds = xsldata(fileurl);
             
             int errorcount = 0;//记录错误信息条数
             int insertcount = 0;//记录插入成功条数
             int updatecount = 0;//记录更新信息条数
             for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
             {
                 #region 数据库字段
                 string RecorderID = ds.Tables[0].Rows[i][0].ToString();//档号
                 string Name = ds.Tables[0].Rows[i][1].ToString();//姓名
                 string Pay = ds.Tables[0].Rows[i][2].ToString();//档管费
                 string YDW = ds.Tables[0].Rows[i][3].ToString();//调出单位
                 string XDW = ds.Tables[0].Rows[i][4].ToString();//调入单位

                 string ZZQK = "";//转正情况
                 string ZCQK = "";//职称情况
                 string ZCID = "";//职称证书编号
                 string CompanyInfo = "";//工作单位情况
                 string TCF = "";//统筹费
                 string TCID = "";//统筹编号
                 string GZQK = "";//工资情况
                 string Degree ="";//学历
                 string GradeTimeSchool = "";//毕业时间与院校
                 string Speciality = "";//毕业专业
                 #endregion

                 if (RecorderID != "" && Name != "")//1
                 {
                     SqlCommand selectcmd = new SqlCommand("select count(*) from T_RecorderInfo  where RecorderID='" + RecorderID + "'and Name='" + Name + "'", conn);
                     int count = Convert.ToInt32(selectcmd.ExecuteScalar());
                     #region if
                     if (count > 0)
                     {
                         SqlCommand updatecmd = new SqlCommand("update T_RecorderInfo set  Name='" + Name + "',Degree='" + Degree + "',GradeTimeSchool='" + GradeTimeSchool + "',Speciality='" + Speciality + "',ZZQK='" + ZZQK + "',ZCQK='" + ZCQK + "',ZCID='" + ZCID + "',CompanyInfo='" + CompanyInfo + "',TCF='" + TCF + "',TCID='" + TCID + "',GZQK='" + GZQK + "',Pay='" + Pay + "',YDW='" + YDW + "',XDW='" + XDW + "'  where RecorderID='" + RecorderID + "'", conn);
                         updatecmd.ExecuteNonQuery();
                         updatecount++;
                     }
                     else
                     {
                         SqlCommand insertcmd = new SqlCommand("insert into T_RecorderInfo(RecorderID,Name,Degree,GradeTimeSchool,Speciality,ZZQK,ZCQK,ZCID,CompanyInfo,TCF,TCID,GZQK,Pay,YDW,XDW)   values('" + RecorderID + "','" + Name + "','" + Degree + "','" + GradeTimeSchool + "','" + Speciality + "','" + ZZQK + "','" + ZCQK + "','" + ZCID + "','" + CompanyInfo + "','" + TCF + "','" + TCID + "','" + GZQK + "','" + Pay + "','" + YDW + "','" + XDW + "')", conn);
                         insertcmd.ExecuteNonQuery();
                         insertcount++;
                     }
                     #endregion
                 }
                 //else
                 //{
                 //    Response.Write("<script language='javascript'>alert('档号或姓名出错！导入失败！请检查！');</script>");
                 //    errorcount++;
                 //    break;
                 //}
             }
             Response.Write("<script language='javascript'>alert('" + insertcount + "条数据导入成功！" + updatecount + "条数据更新成功！');</script>");
        // }
       //  catch (Exception aa)
        // {
             //Response.Write("<script language='javascript'>alert('导入失败！');</script>");
       //  }

        //finally
        //{
        //    conn.Close();
        //}    
    }

    //判断要导入的文件是否为Excel文件

    private string typename(string path)
    {
        string filename = path.Substring(path.LastIndexOf("\\") + 1);
        string type = path.Substring(path.LastIndexOf(".") + 1);
        string murl = "";

        if (type != "xls")
        { 
            return murl;
        }
        else
        {
            return path;
        }
       

    }

   //把excel数据读入dataset返回l数据集
    private DataSet xsldata(string filepath)
    {
        string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extended Properties='Excel 8.0;IMEX=1'";
        System.Data.OleDb.OleDbConnection Conn = new System.Data.OleDb.OleDbConnection(strCon);
        string strCom = "SELECT * FROM [Sheet1$]";
        Conn.Open();
        System.Data.OleDb.OleDbDataAdapter myCommand = new System.Data.OleDb.OleDbDataAdapter(strCom, Conn);
        DataSet ds = new DataSet();
        myCommand.Fill(ds, "[Sheet1$]");
        Conn.Close();
        return ds;
    } 



}