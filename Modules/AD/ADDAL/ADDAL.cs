using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonUtility.DBUtility;
using Modules.Files;

namespace Modules.AD
{
    
   public class ADDetail
    {
        public ADDetail()
		{}
        AdoHelper helper = AdoHelper.CreateHelper();
        #region 广告管理

        /// <summary>
        /// 根据广告位获取广告
        /// </summary>
        /// <param name="MaxAds"></param>
        /// <param name="BoardID"></param>
        /// <returns></returns>
        public DataSet GetAdListByBoard(int MaxAds, int BoardID)
        { 
            StringBuilder SQL = new StringBuilder();
            SQL.Append("select top " + MaxAds.ToString() + " a.*, b.Flag from T_ADList a inner join T_ADBoard b on a.BoardID=b.ID where a.BoardID=" + BoardID + " order by a.StartTime desc ");
            DataSet ds = helper.ExecuteDataset(SQL.ToString());
            return ds;
        }

        public admodel GetADOne(int ID)
        {
            StringBuilder SQL = new StringBuilder();
            SQL.Append("select a.* ,b.BoardName, b.FitWidth, b.FitHeight, ");
            SQL.Append("case b.Flag ");
            SQL.Append("when 'static' then '普通静态广告' ");
            SQL.Append("when 'float' then '任意漂浮广告' ");
            SQL.Append("when 'leftroll' then '左侧滚动广告' ");
            SQL.Append("when 'rightroll' then '右侧滚动广告' ");
            SQL.Append("when 'leftpair' then '左侧对联广告' ");
            SQL.Append("when 'rightpair' then '右侧对联广告' ");
            SQL.Append("when 'pop' then '弹出广告'");
            SQL.Append("end as Flag ");
            SQL.Append("from T_ADList a ");
            SQL.Append("inner join T_ADBoard b on a.BoardID = b.ID ");
            SQL.Append("where a.ID=" + ID);
            DataSet ds = helper.ExecuteDataset(SQL.ToString());

            admodel model = new admodel();
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ADID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                if (ds.Tables[0].Rows[0]["BoardID"].ToString() != "")
                {
                    model.BoardID = int.Parse(ds.Tables[0].Rows[0]["BoardID"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Url = ds.Tables[0].Rows[0]["Url"].ToString();
                model.PicUrl = ds.Tables[0].Rows[0]["PicUrl"].ToString();
                model.Readme = ds.Tables[0].Rows[0]["Readme"].ToString();
                model.AdCode = ds.Tables[0].Rows[0]["AdCode"].ToString();

                if (ds.Tables[0].Rows[0]["FitHeight"].ToString() != "")
                {
                    model.FitHeight = Int32.Parse(ds.Tables[0].Rows[0]["FitHeight"].ToString());//推荐高度
                }
                if (ds.Tables[0].Rows[0]["FitWidth"].ToString() != "")
                {
                    model.FitWidth = Int32.Parse(ds.Tables[0].Rows[0]["FitWidth"].ToString());//推荐宽度
                }
                //				model.FitHeight = ds.Tables[0].Rows[0]["FitHeight"].ToString();//推荐高度
                //				model.FitWidth = ds.Tables[0].Rows[0]["FitWidth"].ToString();//推荐宽度
                if (ds.Tables[0].Rows[0]["Height"].ToString() != "")
                {
                    model.Height = int.Parse(ds.Tables[0].Rows[0]["Height"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Width"].ToString() != "")
                {
                    model.Width = int.Parse(ds.Tables[0].Rows[0]["Width"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Topmargin"].ToString() != "")
                {
                    model.Topmargin = int.Parse(ds.Tables[0].Rows[0]["Topmargin"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Sidemargin"].ToString() != "")
                {
                    model.Sidemargin = int.Parse(ds.Tables[0].Rows[0]["Sidemargin"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StartTime"].ToString() != "")
                {
                    model.StartTime = DateTime.Parse(ds.Tables[0].Rows[0]["StartTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PicOrFlash"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["PicOrFlash"].ToString() == "1") || (ds.Tables[0].Rows[0]["PicOrFlash"].ToString().ToLower() == "true"))
                    {
                        model.PicOrFlash = true;
                    }
                    else
                    {
                        model.PicOrFlash = false;
                    }
                }

                if (ds.Tables[0].Rows[0]["BoardID"].ToString() != "")
                {
                    model.BoardID = int.Parse(ds.Tables[0].Rows[0]["BoardID"].ToString());
                }
                model.BoardName = ds.Tables[0].Rows[0]["BoardName"].ToString();
                model.Flag = ds.Tables[0].Rows[0]["Flag"].ToString();
                if (ds.Tables[0].Rows[0]["FitWidth"].ToString() != "")
                {
                    model.FitWidth = int.Parse(ds.Tables[0].Rows[0]["FitWidth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FitHeight"].ToString() != "")
                {
                    model.FitHeight = int.Parse(ds.Tables[0].Rows[0]["FitHeight"].ToString());
                }

                model.IsLock = ds.Tables[0].Rows[0]["IsLock"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取广告
        /// </summary>
        /// <param name="M_ID">广告类型</param>
        /// <returns></returns>
        public DataSet GetADList(string ADShow, string ADFlag, int ADBoard)
        {
            StringBuilder SQL = new StringBuilder();
            SQL.Append("select a.*, b.ID as BoardID, b.BoardName as BoardName, ");
            SQL.Append("case b.Flag ");
            SQL.Append("when 'static' then '普通静态广告' ");
            SQL.Append("when 'float' then '任意漂浮广告' ");
            SQL.Append("when 'leftroll' then '左侧滚动广告' ");
            SQL.Append("when 'rightroll' then '右侧滚动广告' ");
            SQL.Append("when 'leftpair' then '左侧对联广告' ");
            SQL.Append("when 'rightpair' then '右侧对联广告' ");
            SQL.Append("when 'pop' then '弹出广告'");
            SQL.Append("end as Flag, ");
            SQL.Append("b.Flag as ADFlag from T_ADList a ");
            SQL.Append("inner join T_ADBoard b on a.BoardID = b.ID ");

            if (ADShow != "0")
            {
                SQL.Append("and a.IsLock = '" + ADShow + "' ");
            }

            if (ADBoard != 0)
            {
                SQL.Append("and a.BoardID = " + ADBoard + "  ");
            }

            if (ADFlag != "0")
            {
                SQL.Append("and b.Flag='" + ADFlag + "' ");
            }

            SQL.Append("order by a.ID ");
            string SQL1 = SQL.ToString().Replace("a.BoardID = b.ID and", "a.BoardID = b.ID where");
            DataSet ds = helper.ExecuteDataset(SQL1); ;
            return ds;
        }

        /// <summary>
        /// 广告显示操作
        /// </summary>
        /// <param name="Flag"></param>
        /// <param name="ID"></param>
        public void Show(string Flag, string ID)
        {
            string IsLock = string.Empty;
            string SQL = string.Empty;
            if (Flag == "0")
            {
                IsLock = "显示";
            }
            else if (Flag == "1")
            {
                IsLock = "未显示";
            }
            SQL = "update T_ADList set IsLock ='" + IsLock + "' where ID in (" + ID + ") and IsLock <> '" + IsLock + "'";
            helper.ExecuteNonQuery(SQL);

            SQL = "select BoardID from T_ADList where ID in (" + ID + ")";
            DataSet ds =helper.ExecuteDataset(SQL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    CreateJS(int.Parse(ds.Tables[0].Rows[i]["BoardID"].ToString()));
                }
            }
        }

        /// <summary>
        /// 修改一则广告
        /// </summary>
        /// <param name="model"></param>
        public void EditAD(admodel model)
        {
            StringBuilder SQL = new StringBuilder();
            SQL.Append("update T_ADList set ");
            SQL.Append("Title = '" + model.Title + "', ");
            SQL.Append("Url = '" + model.Url + "',");
            SQL.Append("PicUrl = '" + model.PicUrl + "', ");
            SQL.Append("Readme = '" + model.Readme + "', ");
            SQL.Append("AdCode = '" + model.AdCode + "', ");
            SQL.Append("Width = " + model.Width + ", ");
            SQL.Append("Height = " + model.Height + ", ");
            SQL.Append("Topmargin = " + model.Topmargin + ", ");
            SQL.Append("Sidemargin = " + model.Sidemargin + ", ");
            SQL.Append("StartTime = '" + model.StartTime.ToString() + "', ");
            SQL.Append("PicOrFlash = ");
            if (model.PicOrFlash == true)
                SQL.Append("1, ");
            else
                SQL.Append("0, ");
            SQL.Append("IsLock = '" + model.IsLock + "' ");
            SQL.Append("where ID = " + model.ADID);

            helper.ExecuteNonQuery(SQL.ToString());
            this.CreateJS(model.BoardID);
        }


        /// <summary>
        /// 删除一条广告
        /// </summary>
        /// <param name="ID"></param>
        public void DelAD(string ID)
        {
            string SQL = "delete from T_ADList where ID in (" + ID + ")";
            helper.ExecuteNonQuery(SQL);

            SQL = "select PicUrl from T_ADList where ID in (" + ID + ")";
            DataSet ds = helper.ExecuteDataset(SQL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                System.Web.HttpContext.Current.Response.Write(ds.Tables[0].Rows.Count.ToString() + "<br>");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    FileOper.DelFile(GetUrl(ds.Tables[0].Rows[i]["PicUrl"].ToString()));
                }
            }
        }

        #endregion

        #region 广告位管理
        /// <summary>
        /// 获取单个广告位记录
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public admodel GetADBoardOne(int ID)
        {
            admodel model = new admodel();
            string SQL = "select * from T_ADBoard where ID=" + ID;
            DataSet ds = helper.ExecuteDataset(SQL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.BoardID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                model.BoardName = ds.Tables[0].Rows[0]["BoardName"].ToString();
                model.FileName = ds.Tables[0].Rows[0]["FileName"].ToString();
                model.Flag = ds.Tables[0].Rows[0]["Flag"].ToString();
                if (ds.Tables[0].Rows[0]["AdRate"].ToString() != "")
                {
                    model.AdRate = int.Parse(ds.Tables[0].Rows[0]["AdRate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Maxads"].ToString() != "")
                {
                    model.Maxads = int.Parse(ds.Tables[0].Rows[0]["Maxads"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获取广告位
        /// </summary>
        /// <returns></returns>
        public DataSet GetADBoardList()
        {
            string SQL = "select * from T_ADBoard order by ID asc";
            DataSet ds =helper.ExecuteDataset(SQL);
            return ds;
        }
        #endregion

        #region 生成广告JS
        /// <summary>
        /// 生成广告JS
        /// </summary>
        /// <param name="BoardID">ID</param>
        public void CreateJS(int ID)
        {
            if (ID == 0)
            {
                DataSet ds = this.GetADBoardList();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    CreateJSFile(int.Parse(ds.Tables[0].Rows[i]["ID"].ToString()));
                }
            }
            else
            {
                CreateJSFile(ID);
            }
        }

        /// <summary>
        /// 生成JS文件
        /// </summary>
        /// <param name="BoardID">广告位ID</param>
        private void CreateJSFile(int BoardID)
        {
            string JsFileName = string.Empty;
            int MaxAdNum;

            string strFloat = string.Empty, strRollLeft = string.Empty, strRollRight = string.Empty, strMargin = string.Empty;
            string strFlashAndPic = string.Empty, strClick = string.Empty, strFollow1 = string.Empty, strFollow = string.Empty;
            string popurl = string.Empty, strRunCode = string.Empty;
            string strCommon = string.Empty, strTemp = string.Empty;

            admodel model = new admodel();
            model = this.GetADBoardOne(BoardID);
            if (model == null)
            {
                JsFileName = "ADFile/ad.js";
                MaxAdNum = 1;
            }
            else
            {
                JsFileName = "ADFile/" + model.FileName;
                MaxAdNum = model.Maxads;
            }

            DataSet ds = this.GetAdListByBoard(MaxAdNum, BoardID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    model.ADID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                    model.Url = ds.Tables[0].Rows[i]["Url"].ToString();
                    model.PicUrl = ds.Tables[0].Rows[i]["PicUrl"].ToString();
                    if (ds.Tables[0].Rows[0]["Height"].ToString() != "")
                    {
                        model.Height = int.Parse(ds.Tables[0].Rows[0]["Height"].ToString());
                    }
                    if (ds.Tables[0].Rows[0]["Width"].ToString() != "")
                    {
                        model.Width = int.Parse(ds.Tables[0].Rows[0]["Width"].ToString());
                    }
                    if (ds.Tables[0].Rows[0]["Topmargin"].ToString() != "")
                    {
                        model.Topmargin = int.Parse(ds.Tables[0].Rows[0]["Topmargin"].ToString());
                    }
                    if (ds.Tables[0].Rows[0]["Sidemargin"].ToString() != "")
                    {
                        model.Sidemargin = int.Parse(ds.Tables[0].Rows[0]["Sidemargin"].ToString());
                    }
                    model.Readme = ds.Tables[0].Rows[i]["Readme"].ToString();
                    if (ds.Tables[0].Rows[0]["PicOrFlash"].ToString() != "")
                    {
                        if ((ds.Tables[0].Rows[0]["PicOrFlash"].ToString() == "1") || (ds.Tables[0].Rows[0]["PicOrFlash"].ToString().ToLower() == "true"))
                        {
                            model.PicOrFlash = true;
                        }
                        else
                        {
                            model.PicOrFlash = false;
                        }
                    }
                    model.IsLock = ds.Tables[0].Rows[i]["IsLock"].ToString();

                    switch (ds.Tables[0].Rows[i]["Flag"].ToString())
                    {
                        case "float":
                            if (model.IsLock != "显示")
                                strFloat = "";
                            else
                                strFloat = ReadFlashAndPic(model);
                            break;
                        case "leftroll":
                            if (model.IsLock != "显示")
                                strRollLeft = "";
                            else
                                strRollLeft = ReadFlashAndPic(model);
                            break;
                        case "rightroll":
                            if (model.IsLock != "显示")
                                strRollRight = "";
                            else
                                strRollRight = ReadFlashAndPic(model);
                            break;
                        case "leftpair":
                        case "rightpair":
                            if (model.IsLock == "显示")
                            {
                                if (ds.Tables[0].Rows[i]["Flag"].ToString() == "leftpair")
                                    strMargin = "style='position: absolute; width: " + model.Width + "; height: " + model.Height + "; z-index: " + i + "; left: " + model.Sidemargin + "; top: " + model.Topmargin + "; '";
                                else if (ds.Tables[0].Rows[i]["Flag"].ToString() == "rightpair")
                                    strMargin = "style='position: absolute; width: " + model.Width + "; height: " + model.Height + "; z-index: " + i + "; right: " + model.Sidemargin + "; top: " + model.Topmargin + "; '";

                                strFlashAndPic = ReadFlashAndPic(model);
                                strClick = "<a href='#' onClick=JBLStatic" + model.ADID + ".style.visibility='hidden'; style='font-size:12px; color:#000000; '>关闭</a>";
                                strFollow1 = "<div id='JBLStatic" + model.ADID + "' " + strMargin + "><p align='center'>" + strClick + "<br>" + strFlashAndPic + "</p></div>";
                                strFollow = strFollow + "document.writeln(\"" + strFollow1 + "\");" + System.Environment.NewLine;
                            }
                            else
                            {
                                strFollow = "";
                            }
                            break;
                        case "pop":
                            if (model.IsLock == "显示")
                            {
                                popurl = GetUrl("Ad/Popads.aspx?id=" + model.ADID);
                                strRunCode = strRunCode + "window.open('" + popurl + "','popads" + model.ADID + "','toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=0,resizable=no,width=" + model.Width + ",height=" + model.Height + ",top=" + model.Topmargin + ",left=" + model.Sidemargin + "');" + System.Environment.NewLine;
                            }
                            else
                            {
                                strRunCode = "";
                            }
                            break;
                        default:
                            if (model.IsLock == "显示")
                            {
                                strFlashAndPic = ReadFlashAndPic(model);//生成html方法
                                strCommon = strCommon + "document.writeln(\"" + strFlashAndPic + "\");" + System.Environment.NewLine;
                            }
                            else
                            {
                                strCommon = "";
                            }
                            break;
                    }
                }
            }
            else
            {
                return;
            }

            strTemp = string.Empty;
            strTemp = strCommon;
            if (strFollow.Trim() != "" && strFollow != string.Empty)
            {
                strTemp = strTemp + strFollow;
            }

            if (strRollLeft.Trim() != "" && strRollLeft != string.Empty)
            {
                strTemp += FileOper.ReadFile(GetUrl("AD/Template/advleft.inc"));
                strTemp = strTemp.Replace("{$Roll1Code}", strRollLeft);
            }

            if (strRollRight.Trim() != "" && strRollRight != string.Empty)
            {
                strTemp += FileOper.ReadFile(GetUrl("AD/Template/advright.inc"));
                strTemp = strTemp.Replace("{$Roll2Code}", strRollRight);
            }

            if (strFloat.Trim() != "" && strFloat != string.Empty)
            {
                strTemp += FileOper.ReadFile(GetUrl("AD/Template/float.inc"));
                strTemp = strTemp.Replace("{$FloatCode}", strFloat);
            }
            strTemp += strRunCode;

            FileOper.CreateFile(JsFileName, strTemp);
        }

        /// <summary>
        /// 生成html代码   9月19日
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private string ReadFlashAndPic(admodel model)
        {
            string strTemp = string.Empty;

            if (model.PicOrFlash == true)
            {//flash广告
                strTemp = "<embed src='" + GetUrl(model.PicUrl) + "' quality='high' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash' width='" + model.Width + "' height='" + model.Height + "'></embed>";
            }
            else
            {//图片广告 
                if (model.Url.Trim() == "")
                {//为空时，没有链接
                    strTemp = "<img src='" + GetUrl(model.PicUrl) + "' width='" + model.Width + "' height='" + model.Height + "' border='0' alt='" + model.Readme + "'>";
                }
                else
                {//有链接
                    strTemp = "<a href='" + model.Url + "' target='_blank'><img src='" + GetUrl(model.PicUrl) + "' width='" + model.Width + "' height='" + model.Height + "' border='0' alt='" + model.Readme + "'></a>";
                }

            }
            return strTemp;
        }

        private string GetUrl(string strurl)
        {
            if (System.Web.HttpContext.Current.Request.ApplicationPath == "/")
            {
                return "/SysAdmin/" + strurl;
            }
            else
            {
                return System.Web.HttpContext.Current.Request.ApplicationPath.ToString() + "/SysAdmin/" + strurl;
            }
        }
        #endregion


    }
    public class admodel
    {
        public admodel()
        {

        }

        #region 广告位
        private int _boardid;
        private string _boardname;
        private string _filename;
        private string _flag;
        private int _adrate;
        private int _maxads;
        private int _useup;
        private int _fitwidth;
        private int _fitheight;

        /// <summary>
        /// 广告位ID
        /// </summary>
        public int BoardID
        {
            set { _boardid = value; }
            get { return _boardid; }
        }
        /// <summary>
        /// 广告位名称
        /// </summary>
        public string BoardName
        {
            set { _boardname = value; }
            get { return _boardname; }
        }
        /// <summary>
        /// JS文件
        /// </summary>
        public string FileName
        {
            set { _filename = value; }
            get { return _filename; }
        }
        /// <summary>
        /// 广告类型
        /// </summary>
        public string Flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
        /// <summary>
        /// 价格
        /// </summary>
        public int AdRate
        {
            set { _adrate = value; }
            get { return _adrate; }
        }
        /// <summary>
        /// 最多广告条数
        /// </summary>
        public int Maxads
        {
            set { _maxads = value; }
            get { return _maxads; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int UseUp
        {
            set { _useup = value; }
            get { return _useup; }
        }

        public int FitWidth
        {
            set { _fitwidth = value; }
            get { return _fitwidth; }
        }

        public int FitHeight
        {
            set { _fitheight = value; }
            get { return _fitheight; }
        }
        #endregion

        #region 广告
        private int _adid;
        private string _title;
        private string _url;
        private string _picurl;
        private string _readme;
        private string _adcode;
        private int _height;
        private int _width;
        private int _topmargin;
        private int _sidemargin;
        private DateTime _starttime;
        private bool _picorflash;
        private string _islock;
        /// <summary>
        /// 
        /// </summary>
        public int ADID
        {
            set { _adid = value; }
            get { return _adid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PicUrl
        {
            set { _picurl = value; }
            get { return _picurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Readme
        {
            set { _readme = value; }
            get { return _readme; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AdCode
        {
            set { _adcode = value; }
            get { return _adcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Height
        {
            set { _height = value; }
            get { return _height; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Width
        {
            set { _width = value; }
            get { return _width; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Topmargin
        {
            set { _topmargin = value; }
            get { return _topmargin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Sidemargin
        {
            set { _sidemargin = value; }
            get { return _sidemargin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime StartTime
        {
            set { _starttime = value; }
            get { return _starttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool PicOrFlash
        {
            set { _picorflash = value; }
            get { return _picorflash; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IsLock
        {
            set { _islock = value; }
            get { return _islock; }
        }
        #endregion
    }


}
