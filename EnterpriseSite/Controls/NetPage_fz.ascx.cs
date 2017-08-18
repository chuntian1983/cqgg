using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Text.RegularExpressions;
using System.Data.SqlClient;


/// <summary>
///		NetPager 的摘要说明。
/// </summary>
public partial class Controls_NetPage_fz : System.Web.UI.UserControl
{


    //Database db = DatabaseFactory.CreateDatabase();
    //YWcjda.SysAdmin.DbHelperSQL db = new YWcjda.SysAdmin.DbHelperSQL();
    //Century.RealtyRecord.DbHelperSQL.DbHelperSQL db = new Century.RealtyRecord.DbHelperSQL.DbHelperSQL();

    //只写属性值,无默认值
    #region 需要绑定的控件名称
    /// <summary>
    /// 需要绑定的DG
    /// </summary>
    public string MyDataList
    {
        set { this.ViewState["MyDataList"] = value.Trim(); }
    }
    #endregion
    #region 排序的唯一标识
    /// <summary>
    /// 排序的唯一标识
    /// </summary>
    public string IDflag
    {
        set { this.ViewState["IDflag"] = value; }
    }
    #endregion
    #region 排序语句，不含 order by
    /// <summary>
    /// 排序语句，不含 order by
    /// </summary>
    public string Sort
    {
        set { this.ViewState["Sort"] = value; }
    }
    #endregion
    #region 查询的SQL
    /// <summary>
    /// 查询的SQL
    /// </summary>
    public string Sql
    {
        set { this.ViewState["Sql"] = value; }
    }
    #endregion

    //以下为属性值
    #region 控制是否需要在pagload事件中显示分页,如不需要在PageLoad中显示分页，将此值设为0
    private int showFlag = 1;
    /// <summary>
    /// 控制是否需要在pagload事件中显示分页,如不需要在PageLoad中显示分页，将此值设为0
    /// </summary>
    public int ShowFlag
    {
        get { return showFlag; }
        set { showFlag = value; }
    }
    #endregion
    #region 每页显示的行数
    private int pageSize = 15;
    /// <summary>
    /// 每页显示的行数
    /// </summary>
    public int PageSize
    {
        get { return pageSize; }
        set { this.ViewState["PageSize"] = value; }
    }
    #endregion
    #region 控件类型。DataGurid为0(默认),DataList为1
    private int webControlsType = 0;
    /// <summary>
    /// 控件类型。DataGurid为0(默认),DataList为1
    /// </summary>
    public int WebControlsType
    {
        get { return webControlsType; }
        set { this.ViewState["WebControlsType"] = value; }
    }

    private DataList uiList = new DataList();
    public DataList WebUiList
    {
        get { return uiList; }
        set { uiList = value; }
    }
    #endregion
    #region 序号标识别,默认为排序，不需要排序可将此值设为1,排序字段为P_Num
    private int snum = 0;
    /// <summary>
    /// 序号标识别,默认为排序，不需要排序可将此值设为1,排序字段为P_Num
    /// </summary>
    public int Snum
    {
        get { return snum; }
        set { this.ViewState["Snum"] = value; }
    }
    #endregion

    protected void Page_Load(object sender, System.EventArgs e)
    {
        //			Page.SmartNavigation = true;
        // 在此处放置用户代码以初始化页面
        if (!Page.IsPostBack)
        {
            try
            {
                if (ShowFlag == 1)
                {
                    if (!CheckViewState())
                    {
                        if (this.ViewState["WebControlsType"] == null)
                        {
                            this.BindDG(this.GetData(2, 0));
                        }
                        else if (int.Parse(this.ViewState["WebControlsType"].ToString()) == 1)
                        {
                            //this.BindDataList();
                            this.BindDL(this.GetData(2, 0));
                        }
                        else if (int.Parse(this.ViewState["WebControlsType"].ToString()) == 2)
                        {
                            this.BindDGV(this.GetData(2, 0));
                        }
                        else if (int.Parse(this.ViewState["WebControlsType"].ToString()) == 3)
                        {
                            //repeater
                            this.BindRPT(this.GetData(2, 0));
                        }
                    }
                    else
                        return;
                }
            }
            catch (Exception ex)
            {
                this.Response.Write("<Script>alert('" + ex.Message.ToString() + "')</Script>");
            }

        }



    }

    /// <summary>
    /// 绑定DataGurid,显示第一页数据，显示之前，请确保SQL语句已经赋值
    /// </summary>
    public void Bind()
    {
        try
        {
            if (!CheckViewState())
            {
                //BindDG(GetData(2, 0));

                if (this.ViewState["WebControlsType"] == null)
                {
                    this.BindDG(this.GetData(2, 0));
                }
                else if (int.Parse(this.ViewState["WebControlsType"].ToString()) == 1)
                {
                    //this.BindDataList();
                    this.BindDL(this.GetData(2, 0));
                }
                else if (int.Parse(this.ViewState["WebControlsType"].ToString()) == 2)
                {
                    this.BindDGV(this.GetData(2, 0));
                }
                else if (int.Parse(this.ViewState["WebControlsType"].ToString()) == 3)
                {
                    //repeater
                    this.BindRPT(this.GetData(2, 0));
                }
            }
            else
                return;
        }
        catch
        {
            //				throw new Exception(ex.Message);
        }
    }

    /// <summary>
    /// 绑定DataList,显示第一页数据，显示之前，请确保SQL语句已经赋值
    /// </summary>
    public void BindDataList()
    {
        try
        {
            if (!CheckViewState())
                this.BindDL(GetData(2, 0));
            else
                return;
        }
        catch
        { }
    }

    #region 获取每个分页后的数据
    /// <summary>
    /// 获取每个分页后的数据
    /// </summary>
    /// <param name="type">上一页0下一页1首页2末页3</param>
    /// <param name="Flag">0上下前后页按钮，1为go按钮</param>
    /// <returns></returns>
    private DataSet GetData(int type, int Flag)
    {
        int PageCount = this.GetPageCount();
        int newpage = 1;
        int CurrentPage = 1;
        if (Flag == 1)
        {
            if (txtsearch.Text.Trim() != "")
            {
                newpage = int.Parse(txtsearch.Text.Trim());
                if (newpage < 1)
                {
                    newpage = 1;
                }
                if (newpage > PageCount)
                {
                    newpage = PageCount;
                }
            }
        }
        else
        {
            if (lblcurrentpage.Text != "")
            {
                CurrentPage = int.Parse(lblcurrentpage.Text.Trim());
            }
            if (type == 0)
            {
                if (CurrentPage > 1)
                {
                    newpage = CurrentPage - 1;
                }
            }
            if (type == 1)
            {
                if (CurrentPage < PageCount)
                {
                    newpage = CurrentPage + 1;
                }
                else
                {
                    newpage = PageCount;
                }
            }
            if (type == 2)
            {
                newpage = 1;
            }
            if (type == 3)
            {
                newpage = PageCount;
            }
        }
        ////获取总页数
        this.txtsearch.Text = newpage.ToString();
        this.lblcurrentpage.Text = newpage.ToString();
        this.lblpagecount.Text = PageCount.ToString();


        SqlParameter[] parameters = {
											new SqlParameter("@SQL", SqlDbType.VarChar, 500),
											new SqlParameter("@Page", SqlDbType.Int),
											new SqlParameter("@RecsPerPage", SqlDbType.Int),
											new SqlParameter("@ID", SqlDbType.VarChar),
											new SqlParameter("@Sort", SqlDbType.VarChar,255),
											new SqlParameter("@DoCount", SqlDbType.Bit),
			};
        parameters[0].Value = this.ViewState["Sql"].ToString();
        parameters[1].Value = newpage;
        if (this.ViewState["PageSize"] != null)
        {
            parameters[2].Value = int.Parse(this.ViewState["PageSize"].ToString());
        }
        else
        {
            parameters[2].Value = PageSize;
        }
        parameters[3].Value = this.ViewState["IDflag"].ToString();
        parameters[4].Value = this.ViewState["Sort"].ToString();
        parameters[5].Value = 0;
        return CommonUtility.DBUtility.SQLHelper.RunProcedure("P_Pager", parameters, "ds");

        //return db.ExecuteDataSet(dbCommandWrapper);
    }
    #endregion

    #region 获取总页数
    /// <summary>
    /// 获取总页数
    /// </summary>
    /// <returns></returns>
    private int GetPageCount()
    {
        int ps = this.PageSize;
        if (this.ViewState["PageSize"] != null)
        {
            ps = int.Parse(this.ViewState["PageSize"].ToString());
        }
        //			DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("P_Pager");
        //			//输入项
        //			dbCommandWrapper.AddInParameter("@SQL",DbType.String,this.ViewState["Sql"].ToString());
        //			dbCommandWrapper.AddInParameter("@Page",DbType.Int32,0);
        //			dbCommandWrapper.AddInParameter("@RecsPerPage",DbType.Int32,ps);
        //			dbCommandWrapper.AddInParameter("@ID",DbType.String,this.ViewState["IDflag"].ToString());
        //			dbCommandWrapper.AddInParameter("@Sort",DbType.String,this.ViewState["Sort"].ToString());
        //			dbCommandWrapper.AddInParameter("@DoCount",DbType.Byte,1);

        //======================================
        SqlParameter[] parameters = {
											new SqlParameter("@SQL", SqlDbType.VarChar, 500),
											new SqlParameter("@Page", SqlDbType.Int),
											new SqlParameter("@RecsPerPage", SqlDbType.Int),
											new SqlParameter("@ID", SqlDbType.VarChar),
											new SqlParameter("@Sort", SqlDbType.VarChar,255),
											new SqlParameter("@DoCount", SqlDbType.Bit),
			};
        parameters[0].Value = this.ViewState["Sql"].ToString();
        parameters[1].Value = 0;
        parameters[2].Value = ps;
        parameters[3].Value = this.ViewState["IDflag"].ToString();
        parameters[4].Value = this.ViewState["Sort"].ToString();
        parameters[5].Value = 1;
        //=================================================
        //DataSet ds = db.RunProcedure("P_Pager",parameters,"ds");
        DataSet ds = CommonUtility.DBUtility.SQLHelper.RunProcedure("P_Pager", parameters, "ds");

        int RowCount = int.Parse(ds.Tables[0].Rows[0]["RowCounts"].ToString());

        this.lblDataCount.Text = RowCount.ToString();

        if (RowCount == 0)
        {
            RowCount++;
        }
        int PageCount = RowCount / ps;
        int overs = (RowCount) % (ps);
        if (overs != 0)
        {
            PageCount++;
        }
        return PageCount;
    }
    #endregion

    #region 按钮事件
    /// <summary>
    /// 按钮事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_OnClick(Object sender, CommandEventArgs e)
    {
        try
        {
            string Cmd = e.CommandName.ToString().Trim();
            DataSet ds = new DataSet();
            switch (Cmd.ToUpper())
            {
                case "FIRST":
                    ds = this.GetData(2, 0);
                    break;
                case "PREV":
                    ds = this.GetData(0, 0);
                    break;
                case "NEXT":
                    ds = this.GetData(1, 0);
                    break;
                case "LAST":
                    ds = this.GetData(3, 0);
                    break;
                case "GOTOPAGE":
                    ds = this.GetData(4, 1);
                    break;
                default:
                    break;
            }
            //判断是否为DG
            if (this.ViewState["WebControlsType"] == null)
            {
                this.BindDG(ds);
            }
            else if (int.Parse(this.ViewState["WebControlsType"].ToString()) == 1)
            {
                //this.BindDataList();
                this.BindDL(ds);
            }
            else if (int.Parse(this.ViewState["WebControlsType"].ToString()) == 2)
            {
                this.BindDGV(ds);
            }
            else if (int.Parse(this.ViewState["WebControlsType"].ToString()) == 3)
            {
                this.BindRPT(ds);
            }
        }
        catch
        {
        }
    }
    #endregion

    #region 绑定DataGurid显示数据
    /// <summary>
    /// 绑定DataGurid显示数据
    /// </summary>
    /// <param name="ds"></param>
    private void BindDG(DataSet ds)
    {
        if (lblcurrentpage.Text == lblpagecount.Text)
        {
            hlnext.Enabled = false;
            hllast.Enabled = false;
        }
        else
        {
            hlnext.Enabled = true;
            hllast.Enabled = true;
        }
        if (lblcurrentpage.Text == "1")
        {
            hlback.Enabled = false;
            hlfirst.Enabled = false;
        }
        else
        {
            hlback.Enabled = true;
            hlfirst.Enabled = true;
        }
        DataView dv = new DataView();
        int SerFlag = Snum;
        if (this.ViewState["Snum"] != null)
        {
            SerFlag = int.Parse(this.ViewState["Snum"].ToString());
        }

        if (SerFlag == 0)
        {
            DataTable dt = ds.Tables[0];
            dt.Columns.Add("P_Num", System.Type.GetType("System.Int32"));
            dv = new DataView(dt);
            for (int i = 0; i < dv.Count; )
            {
                dv[i].Row["P_Num"] = ((int.Parse(lblcurrentpage.Text) - 1) * pageSize) + (++i);
            }
        }
        else
        {
            dv = new DataView(ds.Tables[0]);
        }
        ((DataGrid)this.Page.FindControl(Convert.ToString(ViewState["MyDataList"]))).DataSource = dv;
        ((DataGrid)this.Page.FindControl(Convert.ToString(ViewState["MyDataList"]))).DataBind();
    }
    #endregion

    #region 绑定DataList
    /// <summary>
    /// 绑定DataList
    /// </summary>
    /// <param name="ds"></param>
    private void BindDL(DataSet ds)
    {
        if (lblcurrentpage.Text == lblpagecount.Text)
        {
            hlnext.Enabled = false;
            hllast.Enabled = false;
        }
        else
        {
            hlnext.Enabled = true;
            hllast.Enabled = true;
        }
        if (lblcurrentpage.Text == "1")
        {
            hlback.Enabled = false;
            hlfirst.Enabled = false;
        }
        else
        {
            hlback.Enabled = true;
            hlfirst.Enabled = true;
        }
        DataView dv = new DataView();
        int SerFlag = Snum;
        if (this.ViewState["Snum"] != null)
        {
            SerFlag = int.Parse(this.ViewState["Snum"].ToString());
        }

        if (SerFlag == 0)
        {
            DataTable dt = ds.Tables[0];
            dt.Columns.Add("P_Num", System.Type.GetType("System.Int32"));
            dv = new DataView(dt);
            for (int i = 0; i < dv.Count; )
            {
                dv[i].Row["P_Num"] = ((int.Parse(lblcurrentpage.Text) - 1) * pageSize) + (++i);
            }
        }
        else
        {
            dv = new DataView(ds.Tables[0]);
        }
        ((DataList)this.Page.FindControl(Convert.ToString(ViewState["MyDataList"]))).DataSource = ds;
        ((DataList)this.Page.FindControl(Convert.ToString(ViewState["MyDataList"]))).DataBind();
        //uiList.DataSource = ds;
        //uiList.DataBind();
    }
    #endregion

    #region 绑定GridView
    /// <summary>
    /// 绑定DataList
    /// </summary>
    /// <param name="ds"></param>
    private void BindDGV(DataSet ds)
    {
        if (lblcurrentpage.Text == lblpagecount.Text)
        {
            hlnext.Enabled = false;
            hllast.Enabled = false;
        }
        else
        {
            hlnext.Enabled = true;
            hllast.Enabled = true;
        }
        if (lblcurrentpage.Text == "1")
        {
            hlback.Enabled = false;
            hlfirst.Enabled = false;
        }
        else
        {
            hlback.Enabled = true;
            hlfirst.Enabled = true;
        }
        DataView dv = new DataView();
        int SerFlag = Snum;
        if (this.ViewState["Snum"] != null)
        {
            SerFlag = int.Parse(this.ViewState["Snum"].ToString());
        }

        if (SerFlag == 0)
        {
            DataTable dt = ds.Tables[0];
            dt.Columns.Add("P_Num", System.Type.GetType("System.Int32"));
            dv = new DataView(dt);
            for (int i = 0; i < dv.Count; )
            {
                dv[i].Row["P_Num"] = ((int.Parse(lblcurrentpage.Text) - 1) * pageSize) + (++i);
            }
        }
        else
        {
            dv = new DataView(ds.Tables[0]);
        }
        ((GridView)this.Page.FindControl(Convert.ToString(ViewState["MyDataList"]))).DataSource = ds;
        ((GridView)this.Page.FindControl(Convert.ToString(ViewState["MyDataList"]))).DataBind();
        //uiList.DataSource = ds;
        //uiList.DataBind();
    }
    #endregion

    #region 绑定Repeater
    /// <summary>
    /// 绑定Repeater
    /// </summary>
    /// <param name="ds"></param>
    private void BindRPT(DataSet ds)
    {
        if (lblcurrentpage.Text == lblpagecount.Text)
        {
            hlnext.Enabled = false;
            hllast.Enabled = false;
        }
        else
        {
            hlnext.Enabled = true;
            hllast.Enabled = true;
        }
        if (lblcurrentpage.Text == "1")
        {
            hlback.Enabled = false;
            hlfirst.Enabled = false;
        }
        else
        {
            hlback.Enabled = true;
            hlfirst.Enabled = true;
        }
        DataView dv = new DataView();
        int SerFlag = Snum;
        if (this.ViewState["Snum"] != null)
        {
            SerFlag = int.Parse(this.ViewState["Snum"].ToString());
        }

        if (SerFlag == 0)
        {
            DataTable dt = ds.Tables[0];
            dt.Columns.Add("P_Num", System.Type.GetType("System.Int32"));
            dv = new DataView(dt);
            for (int i = 0; i < dv.Count; )
            {
                dv[i].Row["P_Num"] = ((int.Parse(lblcurrentpage.Text) - 1) * pageSize) + (++i);
            }
        }
        else
        {
            dv = new DataView(ds.Tables[0]);
        }
        ((Repeater)this.Page.FindControl(Convert.ToString(ViewState["MyDataList"]))).DataSource = ds;
        ((Repeater)this.Page.FindControl(Convert.ToString(ViewState["MyDataList"]))).DataBind();
        //uiList.DataSource = ds;
        //uiList.DataBind();
    }
    #endregion

    #region 判断三个分页必须属性值是否存在
    private bool CheckViewState()
    {
        if (this.ViewState["Sql"] != null && this.ViewState["IDflag"] != null && this.ViewState["Sort"] != null && this.ViewState["MyDataList"] != null)
            return false;
        else
            return true;
    }
    #endregion
}




