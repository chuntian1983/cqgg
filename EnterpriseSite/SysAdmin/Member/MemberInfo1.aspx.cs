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
using Modules.Member;

public partial class SysAdmin_Member_MemberInfo1 : System.Web.UI.Page
{
    private MemberBLL _member = new MemberBLL();
    private string _memberId = HttpContext.Current.Request["MemberId"];
    public string imagePath = ConfigurationSettings.AppSettings["PersonPicPath"];

    protected void Page_Load(object sender, EventArgs e)
    {
    if (!IsPostBack)
        {
            if (this._memberId != null)
            {
                int memberId = Convert.ToInt32(this._memberId);
                DataSet ds = _member.GetPersonalInfo(memberId);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    this.lbName.Text = ds.Tables[0].Rows[0]["Nickname"].ToString();
                    this.lbRealName.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
                    this.lbSex.Text = ds.Tables[0].Rows[0]["Sex"].ToString()=="0"?"男":"女";
                    this.lbBirthday.Text = DateTime.Parse(ds.Tables[0].Rows[0]["Birthday"].ToString()).ToShortDateString();
                    switch (ds.Tables[0].Rows[0]["PaperType"].ToString())
                    {
                        case "1": this.lbPaperType.Text = "身份证"; break;
                        case "2": this.lbPaperType.Text = "军官证"; break;
                        case "3": this.lbPaperType.Text = "护照"; break;
                        case "4": this.lbPaperType.Text = "其他"; break;
                    }
                    this.lbPaperNO.Text = ds.Tables[0].Rows[0]["PaperNO"].ToString();
                    switch (ds.Tables[0].Rows[0]["Political"].ToString())
                    {
                        case "0": this.lbPolitical.Text = "党员"; break;
                        case "1": this.lbPolitical.Text = "团员"; break;
                        case "2": this.lbPolitical.Text = "其它民主党派"; break;
                        case "3": this.lbPolitical.Text = "无党派"; break;
                        case "4": this.lbPolitical.Text = "群众"; break;
                    }
                    switch (ds.Tables[0].Rows[0]["Marry"].ToString())
                    {
                        case "0": this.lbMarry.Text = "未婚"; break;
                        case "1": this.lbMarry.Text = "已婚"; break;
                        case "2": this.lbMarry.Text = "离异"; break;
                        case "3": this.lbMarry.Text = "丧偶"; break;
                    }
                    this.lbSchool.Text = ds.Tables[0].Rows[0]["School"].ToString();
                    this.lbGraduateTime.Text = ds.Tables[0].Rows[0]["GraduateTime"].ToString();
                    switch (ds.Tables[0].Rows[0]["Levels"].ToString())
                    {
                        case "0": lbLevels.Text = "初中"; break;
                        case "1": lbLevels.Text = "高中"; break;
                        case "2": lbLevels.Text = "中技"; break;
                        case "3": lbLevels.Text = "中专"; break;
                        case "4": lbLevels.Text = "大专"; break;
                        case "5": lbLevels.Text = "本科"; break;
                        case "6": lbLevels.Text = "硕士"; break;
                        case "7": lbLevels.Text = "博士"; break;
                        case "8": lbLevels.Text = "其他"; break;
                    }



                    switch (ds.Tables[0].Rows[0]["Speciality"].ToString())
                    {
                        case "0101": lbSpeciality.Text = "行政管理"; break;
                        case "0102": lbSpeciality.Text = "土地管理"; break;
                        case "0103": lbSpeciality.Text = "经济管理"; break;
                        case "0104": lbSpeciality.Text = "企业管理"; break;
                        case "0105": lbSpeciality.Text = "工商管理"; break;
                        case "0106": lbSpeciality.Text = "物业管理"; break;
                        case "0107": lbSpeciality.Text = "饭店管理"; break;
                        case "0108": lbSpeciality.Text = "旅游管理"; break;
                        case "0109": lbSpeciality.Text = "劳教管理"; break;
                        case "0110": lbSpeciality.Text = "治安管理"; break;
                        case "0111": lbSpeciality.Text = "交通管理"; break;
                        case "0112": lbSpeciality.Text = "信息管理"; break;
                        case "0113": lbSpeciality.Text = "资产管理"; break;
                        case "0114": lbSpeciality.Text = "教育管理"; break;
                        case "0115": lbSpeciality.Text = "工程管理"; break;
                        case "0116": lbSpeciality.Text = "机电管理"; break;

                        case "0201": lbSpeciality.Text = "地矿"; break;
                        case "0202": lbSpeciality.Text = "材料"; break;
                        case "0203": lbSpeciality.Text = "冶金"; break;
                        case "0204": lbSpeciality.Text = "机械"; break;
                        case "0205": lbSpeciality.Text = "工业设计"; break;
                        case "0206": lbSpeciality.Text = "机电一体化"; break;
                        case "0207": lbSpeciality.Text = "仪器仪表"; break;
                        case "0208": lbSpeciality.Text = "能源"; break;
                        case "0209": lbSpeciality.Text = "电机电工"; break;
                        case "0210": lbSpeciality.Text = "工业自动化"; break;
                        case "0211": lbSpeciality.Text = "计算机"; break;
                        case "0212": lbSpeciality.Text = "信息科学"; break;
                        case "0213": lbSpeciality.Text = "通信"; break;
                        case "0214": lbSpeciality.Text = "电子"; break;
                        case "0215": lbSpeciality.Text = "建筑"; break;
                        case "0216": lbSpeciality.Text = "城市规划"; break;
                        case "0217": lbSpeciality.Text = "给排水"; break;
                        case "0218": lbSpeciality.Text = "道路与桥梁"; break;
                        case "0219": lbSpeciality.Text = "工民建"; break;
                        case "0220": lbSpeciality.Text = "水利"; break;
                        case "0221": lbSpeciality.Text = "港航"; break;
                        case "0222": lbSpeciality.Text = "测绘"; break;
                        case "0223": lbSpeciality.Text = "环境"; break;
                        case "0224": lbSpeciality.Text = "化工"; break;
                        case "0225": lbSpeciality.Text = "制药"; break;
                        case "0226": lbSpeciality.Text = "轻工"; break;
                        case "0227": lbSpeciality.Text = "食品"; break;
                        case "0228": lbSpeciality.Text = "农业工程"; break;
                        case "0229": lbSpeciality.Text = "林业工程"; break;
                        case "0230": lbSpeciality.Text = "纺织"; break;
                        case "0231": lbSpeciality.Text = "服装"; break;
                        case "0232": lbSpeciality.Text = "交通运输"; break;
                        case "0233": lbSpeciality.Text = "航空航天"; break;
                        case "0234": lbSpeciality.Text = "兵器"; break;
                        case "0235": lbSpeciality.Text = "工程力学"; break;

                        case "0301": lbSpeciality.Text = "经济学"; break;
                        case "0302": lbSpeciality.Text = "贸易经济"; break;
                        case "0303": lbSpeciality.Text = "国际贸易"; break;
                        case "0304": lbSpeciality.Text = "货币银行学"; break;
                        case "0305": lbSpeciality.Text = "统计"; break;
                        case "0306": lbSpeciality.Text = "会计"; break;
                        case "0307": lbSpeciality.Text = "审计"; break;
                        case "0308": lbSpeciality.Text = "金融"; break;
                        case "0309": lbSpeciality.Text = "国际金融"; break;
                        case "0310": lbSpeciality.Text = "税务"; break;
                        case "0311": lbSpeciality.Text = "保险"; break;
                        case "0312": lbSpeciality.Text = "财政"; break;
                        case "0313": lbSpeciality.Text = "证券期货"; break;
                        case "0314": lbSpeciality.Text = "报关与国际货运"; break;
                        case "0315": lbSpeciality.Text = "市场营销"; break;
                        case "0316": lbSpeciality.Text = "商品学"; break;
                        case "0317": lbSpeciality.Text = "房地产"; break;
                        case "0318": lbSpeciality.Text = "资产评估"; break;

                        case "0401": lbSpeciality.Text = "法学"; break;
                        case "0402": lbSpeciality.Text = "经济法"; break;
                        case "0403": lbSpeciality.Text = "国际法"; break;
                        case "0404": lbSpeciality.Text = "社会学"; break;
                        case "0405": lbSpeciality.Text = "政治学/哲学"; break;
                        case "0406": lbSpeciality.Text = "公安学"; break;

                        case "0501": lbSpeciality.Text = "教育学"; break;
                        case "0502": lbSpeciality.Text = "幼师"; break;
                        case "0503": lbSpeciality.Text = "思想政治教育"; break;
                        case "0504": lbSpeciality.Text = "体育学"; break;
                        case "0505": lbSpeciality.Text = "职业技术教育"; break;

                        case "0601": lbSpeciality.Text = "中国语言文学"; break;
                        case "0602": lbSpeciality.Text = "编辑"; break;
                        case "0603": lbSpeciality.Text = "文秘"; break;
                        case "0604": lbSpeciality.Text = "外国语言文学"; break;
                        case "0605": lbSpeciality.Text = "英语"; break;
                        case "0606": lbSpeciality.Text = "日语"; break;
                        case "0607": lbSpeciality.Text = "德语"; break;
                        case "0608": lbSpeciality.Text = "法语"; break;
                        case "0609": lbSpeciality.Text = "俄语"; break;
                        case "0610": lbSpeciality.Text = "其它外语"; break;
                        case "0611": lbSpeciality.Text = "新闻学"; break;
                        case "0612": lbSpeciality.Text = "历史.档案"; break;
                        case "0613": lbSpeciality.Text = "图书馆学"; break;
                        case "0614": lbSpeciality.Text = "播音"; break;
                        case "0615": lbSpeciality.Text = "摄影"; break;
                        case "0616": lbSpeciality.Text = "音乐"; break;
                        case "0617": lbSpeciality.Text = "乐器"; break;
                        case "0618": lbSpeciality.Text = "美术"; break;
                        case "0619": lbSpeciality.Text = "工艺美术"; break;
                        case "0620": lbSpeciality.Text = "绘画"; break;
                        case "0621": lbSpeciality.Text = "戏居舞蹈"; break;
                        case "0622": lbSpeciality.Text = "舞台灯光"; break;
                        case "0623": lbSpeciality.Text = "电影电视"; break;
                        case "0624": lbSpeciality.Text = "广告策划"; break;

                        case "0701": lbSpeciality.Text = "数学"; break;
                        case "0702": lbSpeciality.Text = "物理学"; break;
                        case "0703": lbSpeciality.Text = "化学"; break;
                        case "0704": lbSpeciality.Text = "天文学"; break;
                        case "0705": lbSpeciality.Text = "地质学"; break;
                        case "0706": lbSpeciality.Text = "地球物理学"; break;
                        case "0707": lbSpeciality.Text = "大气科学"; break;
                        case "0708": lbSpeciality.Text = "海洋科学"; break;
                        case "0709": lbSpeciality.Text = "心理学"; break;
                        case "0710": lbSpeciality.Text = "生物科学"; break;
                        case "0711": lbSpeciality.Text = "地理科学"; break;

                        case "0801": lbSpeciality.Text = "预防医学"; break;
                        case "0802": lbSpeciality.Text = "临床医学"; break;
                        case "0803": lbSpeciality.Text = "口腔医学"; break;
                        case "0804": lbSpeciality.Text = "中医"; break;
                        case "0805": lbSpeciality.Text = "法医"; break;
                        case "0806": lbSpeciality.Text = "护理"; break;
                        case "0807": lbSpeciality.Text = "药学"; break;

                        case "0901": lbSpeciality.Text = "农学"; break;
                        case "0902": lbSpeciality.Text = "林学"; break;
                        case "0903": lbSpeciality.Text = "园艺"; break;
                        case "0904": lbSpeciality.Text = "园林"; break;
                        case "0905": lbSpeciality.Text = "动物生产与兽医"; break;
                        case "0906": lbSpeciality.Text = "水产"; break;
                        case "0907": lbSpeciality.Text = "农业推广"; break;
                        case "9900": lbSpeciality.Text = "其他"; break;
                    }

               
                    this.lbHeight.Text = ds.Tables[0].Rows[0]["Height"].ToString();
                    this.lbWeight.Text = ds.Tables[0].Rows[0]["Weight"].ToString();
                    this.lbHome.Text = ds.Tables[0].Rows[0]["Weight"].ToString();
                    this.lbPlace.Text = ds.Tables[0].Rows[0]["Place"].ToString();
                    this.lbContact.Text = ds.Tables[0].Rows[0]["Contact"].ToString();
                    this.lbPost.Text = ds.Tables[0].Rows[0]["Post"].ToString();
                    this.lbTel.Text = ds.Tables[0].Rows[0]["Tel"].ToString();
                    this.lbLinkman.Text = ds.Tables[0].Rows[0]["Linkman"].ToString();
                    this.lbEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    this.lbAddDate.Text = DateTime.Parse(ds.Tables[0].Rows[0]["AddedDate"].ToString()).ToShortDateString();
                    this.lbQuestion.Text = ds.Tables[0].Rows[0]["PassQuestion"].ToString();
                    this.lbAnswer.Text = ds.Tables[0].Rows[0]["PassAnswer"].ToString();
                    this.lbPassEmail.Text = ds.Tables[0].Rows[0]["PassEmail"].ToString();
                    this.lbpwd.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
                    if (ds.Tables[0].Rows[0]["Img"].ToString().Trim() != "")
                    {
                        this.Image1.ImageUrl = imagePath + ds.Tables[0].Rows[0]["Img"].ToString();
                    }
                }
            }

        }
    }
}
