using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Swgk_content : System.Web.UI.Page
{
    Modules.T_BMFW.BLL.T_BMFW bll = new Modules.T_BMFW.BLL.T_BMFW();
    Modules.Department.DepartmentCategoryBLL dbll = new Modules.Department.DepartmentCategoryBLL();
    
    public string deptid;
    protected void Page_Load(object sender, EventArgs e)
    {
        deptid = Request.QueryString["deptid"];
        if (!IsPostBack)
        {
            if (deptid != null)
            {

                bindData();

            }

        }
    }
    void bindData()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("title");
        dt.Columns.Add("state");
        dt.Columns.Add("f0");
        dt.Columns.Add("f1");
        DataTable dtdept = dbll.GetChildCategoryItems(int.Parse(deptid)).Tables[0];
        if (dtdept.Rows.Count > 0)
        {
            foreach (DataRow item in dtdept.Rows)
            {
                DataRow dr = dt.NewRow();
                dr[0] = item["title"];
                DataTable dts = bll.GetListcun("a.cunid='" + item["categoryid"] + "'").Tables[0];
                if (dts.Rows.Count > 0)
                {
                    dr["state"] = "是";
                }
                else
                {
                    dr["state"] = "否";
                }
                string strs = Cuntj(item["categoryid"].ToString());
                string[] strlist = strs.Split('|');
                dr["f0"] = strlist[0];
                dr["f1"] = strlist[1];
                dt.Rows.Add(dr);
            }
        }



        AspNetPager1.RecordCount = dt.Rows.Count;
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = dt.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.PageSize = AspNetPager1.PageSize;
        this.gvArticleList.DataSource = pds;
        this.gvArticleList.DataBind();

    }
    private string Getbm(string cunid)
    {
        string str = "";
        DataTable dts = bll.GetListcun("a.cunid='" + cunid + "'").Tables[0];
        if (dts.Rows.Count > 0)
        {
            str = "是";
        }
        else
        {
            str = "否";
        }
        return str;
    }
    /// <summary>
    /// 村分数统计
    /// </summary>
    /// <param name="times"></param>
    /// <returns></returns>
    public string Cuntj(string cunid)
    {
        int c = 0;//是
        int d = 0;
        Modules.Department.DepartmentCategoryBLL dbll = new Modules.Department.DepartmentCategoryBLL();
        DataTable dt = dbll.GetChildCategoryItems(int.Parse(cunid)).Tables[0];
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataTable dts = dbll.GetChildCategoryItems(int.Parse(dt.Rows[i]["CategoryId"].ToString())).Tables[0];
                if (dts.Rows.Count > 0)
                {
                    for (int j = 0; j < dts.Rows.Count; j++)
                    {
                        DataTable dst = dbll.GetChildCategoryItems(int.Parse(dt.Rows[j]["CategoryId"].ToString())).Tables[0];
                        if (dst.Rows.Count > 0)
                        {
                            string str = Getbm(dst.Rows[0]["CategoryId"].ToString());
                            if (str == "是")
                            {
                                c++;
                            }
                            else
                            {
                                d++;
                            }
                        }
                        else
                        {
                            string str = "";// Getbm(dst.Rows[i]["CategoryId"].ToString());
                            if (str == "是")
                            {
                                c++;
                            }
                            else
                            {
                                d++;
                            }
                        }
                    }
                }
                else
                {
                    string str = "";// Getbm(dt.Rows[i]["CategoryId"].ToString());
                    if (str == "是")
                    {
                        c++;
                    }
                    else
                    {
                        d++;
                    }
                }

            }
        }
        return c.ToString() + "|" + d.ToString();
    }
    protected void AspNetPager1_PageChanged(object src, EventArgs e)
    {
        bindData();
    }
}