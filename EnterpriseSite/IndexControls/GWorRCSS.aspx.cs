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

public partial class Controls_GWorRCSS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindType();
    }

    private void BindType()
    {
        string[] postType = new string[43] { "高级管理类", "品质管理类" ,"工厂/生产类","营销/销售类","公关/媒介类","人力资源类","计算机类","电子/电器/仪器仪表类",
                "通信技术类","财务/审计/税务类","证券/金融/投资类","银行类","贸易类","物流/仓储类","机械类","动力电气类","房地产/建筑类","化工类","轻工类",
                "外语类","文秘类","教师类","新闻/艺术类","法律类","广告/艺术/设计类","行政/后勤类","技工类","服务类","医学药学类","咨询/顾问类","中介服务类",
                "生物工程类","环境保护类","园林/园艺类","交通运输类","理科类","能源水利类","地矿冶金类","测绘技术类","材料类","农林渔牧类","社会科学/文学类","其它类"};
        for (int i = 0; i < postType.Length; i++)
        {
            ListItem li = new ListItem(postType[i], (i + 1).ToString());
            this.ddlType.Items.Add(li);
        }
    }
}
