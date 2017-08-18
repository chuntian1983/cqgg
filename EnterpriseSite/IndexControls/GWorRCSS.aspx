<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GWorRCSS.aspx.cs" Inherits="Controls_GWorRCSS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title><link href="../css/css1.css" rel="stylesheet" type="text/css" />
</head>
<body style="margin:0;">
    <form id="form1" runat="server">
   <table width="175" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><table width="175" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td><img src="../images/right.jpg" width="96" height="34" onclick="switchSearch('tblPost')" style="cursor:pointer;"/></td>
        <td><img src="../images/right1.jpg" width="79" height="34"  onclick="switchSearch('tblSeeker')" style="cursor:pointer;"/></td>
      </tr>
    </table>
        <table width="175" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td height="148" valign="top" background="../images/right_bg.jpg"><table width="91" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td width="91" height="3"></td>
                </tr>
              </table>
                <table  id="tblSeeker" style="display:none;" width="175" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td height="25" align="center">  <SELECT id="selSpec" class="input_2" >
                    <option value="" selected>所学专业不限</OPTION>
                    <%--<option value='0100'>---管理类---</OPTION>--%><optgroup disabled  label="---管理类---"></optgroup>
<option value='0101'>行政管理</OPTION> 
<option value='0102'>土地管理</OPTION> 
<option value='0103'>经济管理</OPTION> 
<option value='0104'>企业管理</OPTION> 
<option value='0105'>工商管理</OPTION> 
<option value='0106'>物业管理</OPTION> 
<option value='0107'>饭店管理</OPTION> 
<option value='0108'>旅游管理</OPTION> 
<option value='0109'>劳教管理</OPTION> 
<option value='0110'>治安管理</OPTION> 
<option value='0111'>交通管理</OPTION> 
<option value='0112'>信息管理</OPTION> 
<option value='0113'>资产管理</OPTION> 
<option value='0114'>教育管理</OPTION> 
<option value='0115'>工程管理</OPTION> 
<option value='0116'>机电管理</OPTION> 
<%--<option value='0200'>---工科类---</OPTION> --%><optgroup disabled  label="---工科类---"></optgroup>
<option value='0201'>地矿</OPTION> 
<option value='0202'>材料</OPTION> 
<option value='0203'>冶金</OPTION> 
<option value='0204'>机械</OPTION> 
<option value='0205'>工业设计</OPTION> 
<option value='0206'>机电一体化</OPTION> 
<option value='0207'>仪器仪表</OPTION> 
<option value='0208'>能源</OPTION> 
<option value='0209'>电机电工</OPTION> 
<option value='0210'>工业自动化</OPTION> 
<option value='0211'>计算机</OPTION> 
<option value='0212'>信息科学</OPTION> 
<option value='0213'>通信</OPTION> 
<option value='0214'>电子</OPTION> 
<option value='0215'>建筑</OPTION> 
<option value='0216'>城市规划</OPTION> 
<option value='0217'>给排水</OPTION> 
<option value='0218'>道路与桥梁</OPTION> 
<option value='0219'>工民建</OPTION> 
<option value='0220'>水利</OPTION> 
<option value='0221'>港航</OPTION> 
<option value='0222'>测绘</OPTION> 
<option value='0223'>环境</OPTION> 
<option value='0224'>化工</OPTION> 
<option value='0225'>制药</OPTION> 
<option value='0226'>轻工</OPTION> 
<option value='0227'>食品</OPTION> 
<option value='0228'>农业工程</OPTION> 
<option value='0229'>林业工程</OPTION> 
<option value='0230'>纺织</OPTION> 
<option value='0231'>服装</OPTION> 
<option value='0232'>交通运输</OPTION> 
<option value='0233'>航空航天</OPTION> 
<option value='0234'>兵器</OPTION> 
<option value='0235'>工程力学</OPTION> 
<%--<option value='0300'>---财经类---</OPTION> --%><optgroup disabled  label="---财经类---"></optgroup>
<option value='0301'>经济学</OPTION> 
<option value='0302'>贸易经济</OPTION> 
<option value='0303'>国际贸易</OPTION> 
<option value='0304'>货币银行学</OPTION> 
<option value='0305'>统计</OPTION> 
<option value='0306'>会计</OPTION> 
<option value='0307'>审计</OPTION> 
<option value='0308'>金融</OPTION> 
<option value='0309'>国际金融</OPTION> 
<option value='0310'>税务</OPTION> 
<option value='0311'>保险</OPTION> 
<option value='0312'>财政</OPTION> 
<option value='0313'>证券期货</OPTION> 
<option value='0314'>报关与国际货运</OPTION> 
<option value='0315'>市场营销</OPTION> 
<option value='0316'>商品学</OPTION> 
<option value='0317'>房地产</OPTION> 
<option value='0318'>资产评估</OPTION> 
<%--<option value='0400'>---政法类---</OPTION>--%> <optgroup disabled  label="---政法类---"></optgroup>
<option value='0401'>法学</OPTION> 
<option value='0402'>经济法</OPTION> 
<option value='0403'>国际法</OPTION> 
<option value='0404'>社会学</OPTION> 
<option value='0405'>政治学/哲学</OPTION> 
<option value='0406'>公安学</OPTION> 
<%--<option value='0500'>---教育类---</OPTION>--%> <optgroup disabled  label="---教育类---"></optgroup>
<option value='0501'>教育学</OPTION> 
<option value='0502'>幼师</OPTION> 
<option value='0503'>思想政治教育</OPTION> 
<option value='0504'>体育学</OPTION> 
<option value='0505'>职业技术教育</OPTION> 
<%--<option value='0600'>---文学类---</OPTION>--%> <optgroup disabled  label="---文学类---"></optgroup>
<option value='0601'>中国语言文学</OPTION> 
<option value='0602'>编辑</OPTION> 
<option value='0603'>文秘</OPTION> 
<option value='0604'>外国语言文学</OPTION> 
<option value='0605'>英语</OPTION> 
<option value='0606'>日语</OPTION> 
<option value='0607'>德语</OPTION> 
<option value='0608'>法语</OPTION> 
<option value='0609'>俄语</OPTION> 
<option value='0610'>其它外语</OPTION> 
<option value='0611'>新闻学</OPTION> 
<option value='0612'>历史.档案</OPTION> 
<option value='0613'>图书馆学</OPTION> 
<option value='0614'>播音</OPTION> 
<option value='0615'>摄影</OPTION> 
<option value='0616'>音乐</OPTION> 
<option value='0617'>乐器</OPTION> 
<option value='0618'>美术</OPTION> 
<option value='0619'>工艺美术</OPTION> 
<option value='0620'>绘画</OPTION> 
<option value='0621'>戏居舞蹈</OPTION> 
<option value='0622'>舞台灯光</OPTION> 
<option value='0623'>电影电视</OPTION> 
<option value='0624'>广告策划</OPTION> 
<%--<option value='0700'>---理学类---</OPTION>--%> <optgroup disabled  label="---理学类---"></optgroup>
<option value='0701'>数学</OPTION> 
<option value='0702'>物理学</OPTION> 
<option value='0703'>化学</OPTION> 
<option value='0704'>天文学</OPTION> 
<option value='0705'>地质学</OPTION> 
<option value='0706'>地球物理学</OPTION> 
<option value='0707'>大气科学</OPTION> 
<option value='0708'>海洋科学</OPTION> 
<option value='0709'>心理学</OPTION> 
<option value='0710'>生物科学</OPTION> 
<option value='0711'>地理科学</OPTION> 
<%--<option value='0800'>---医学类---</OPTION>--%> <optgroup disabled  label="---医学类---"></optgroup>
<option value='0801'>预防医学</OPTION> 
<option value='0802'>临床医学</OPTION> 
<option value='0803'>口腔医学</OPTION> 
<option value='0804'>中医</OPTION> 
<option value='0805'>法医</OPTION> 
<option value='0806'>护理</OPTION> 
<option value='0807'>药学</OPTION> 
<%--<option value='0900'>---农学类---</OPTION>--%> <optgroup disabled   label="---农学类---"></optgroup>
<option value='0901'>农学</OPTION> 
<option value='0902'>林学</OPTION> 
<option value='0903'>园艺</OPTION> 
<option value='0904'>园林</OPTION> 
<option value='0905'>动物生产与兽医</OPTION> 
<option value='0906'>水产</OPTION> 
<option value='0907'>农业推广</OPTION> 
<option value='9900' >---其它类---</OPTION> 
</SELECT></td>
                  </tr>
                  <tr>
                    <td height="25" align="center"><select id="selSex" class="input_2">
                  <option value=''>性别不限</option>
                  <option value='0'>男</option>
                  <option value='1'>女</option>
              </select></td>
                  </tr>
                  <tr>
                    <td height="25" align="center"> <select id="selPublicShowDate" class="input_2">
                    <option value="" selected>登记时间不限</option>
                    <option value="1">一个星期以内</option>
                    <option value="2">两个星期以内</option>
                    <option value="3">一个月以内</option>
                    <option value="4" >三个月以内</option>
                    <option value="5">半年以内</option>
                  </select></td>
                  </tr>
                 <tr><td align="left">&nbsp;&nbsp;关键字：</td></tr>
                  <tr>
                    <td height="25" align="center"><input id="txtKeyWord" type="text" class="input_1" size="23" /></td>
                  </tr>
                  <tr>
                    <td align="center"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                          <td height="25" align="center"><a href="javascript:void(0);" onclick="searchSeeker();"><img src="../images/ss.jpg" width="66" height="20" border="0" /></a></td>
                        </tr>
                    </table></td>
                  </tr>
            </table>
             <table id="tblPost" width="175" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td height="25" align="center">    <asp:DropDownList ID="ddlWorkPlace" runat="server" CssClass="input_2">
                  <asp:ListItem Value="工作地点不限">工作地点不限</asp:ListItem>
                  <asp:ListItem Value="杭州上城区">杭州上城区</asp:ListItem>
                  <asp:ListItem Value="杭州下城区">杭州下城区</asp:ListItem>
                  <asp:ListItem Value="杭州江干区">杭州江干区</asp:ListItem>
                  <asp:ListItem Value="杭州拱墅区">杭州拱墅区</asp:ListItem>
                  <asp:ListItem Value="杭州西湖区">杭州西湖区</asp:ListItem>
                  <asp:ListItem Value="杭州滨江区">杭州滨江区</asp:ListItem>
                  <asp:ListItem Value="杭州经济开发区">杭州经济开发区</asp:ListItem>
                  <asp:ListItem Value="杭州萧山区">杭州萧山区</asp:ListItem>
                  <asp:ListItem Value="杭州余杭区">杭州余杭区</asp:ListItem>
                  <asp:ListItem Value="杭州桐庐县">杭州桐庐县</asp:ListItem>
                  <asp:ListItem Value="杭州富阳市">杭州富阳市</asp:ListItem>
                  <asp:ListItem Value="杭州临安市">杭州临安市</asp:ListItem>
                  <asp:ListItem Value="杭州建德市">杭州建德市</asp:ListItem>
                  <asp:ListItem Value="杭州淳安县">杭州淳安县</asp:ListItem>
                  </asp:DropDownList></td>
                  </tr>
                  <tr>
                    <td height="25" align="center"> <asp:DropDownList ID="ddlType" runat="server" CssClass="input_2">
                    <asp:ListItem Value="0">岗位不限</asp:ListItem>
                    </asp:DropDownList></td>
                  </tr>
                  <tr>
                    <td height="25" align="center"> <asp:DropDownList ID="ddlDate" runat="server" CssClass="input_2">
                    <asp:ListItem Value="0">时间不限</asp:ListItem>
                    <asp:ListItem Value="1">一月以内</asp:ListItem>
                    <asp:ListItem Value="2">两周以内</asp:ListItem>
                    <asp:ListItem Value="3">一周以内</asp:ListItem>
                    <asp:ListItem Value="4">两天以内</asp:ListItem>
                    <asp:ListItem Value="5">今天</asp:ListItem>
                    </asp:DropDownList></td>
                  </tr>
               <tr><td align="left">&nbsp;&nbsp;单位或岗位关键字：</td></tr>
                  <tr>
                    <td height="25" align="center"><input id="txtKey" type="text" class="input_1" size="23" /></td>
                  </tr>
                  <tr>
                    <td align="center"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                          <td height="25" align="center"><a href="javascript:void(0);" onclick="searchPost();"><img src="../images/ss.jpg" width="66" height="20" border="0" /></a></td>
                        </tr>
                    </table></td>
                  </tr>
            </table>
            </td>
          </tr>
          <tr>
            <td><img src="../images/right2.jpg" width="175" height="8" /></td>
          </tr>
      </table></td>
  </tr>
</table>
<%--<table width="91" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="91" height="3"></td>
  </tr>
</table>--%>
<script type="text/javascript">
function switchSearch(strCtrlName)
{
    document.getElementById('tblSeeker').style.display='none';
    document.getElementById('tblPost').style.display='none';
    var temp=document.getElementById(strCtrlName);
    if(temp)
    {
        temp.style.display='';
    }
}
function searchPost()
{
    var workPlace=document.getElementById('ddlWorkPlace');
    var workPlaceVal=workPlace.options[workPlace.options.selectedIndex].value;
    var postType=document.getElementById('ddlType');
    var postTypeVal=postType.options[postType.selectedIndex].value;
    var releaseDate=document.getElementById('ddlDate');
    var releaseDateVal=releaseDate.options[releaseDate.selectedIndex].value;
    var keyWord=document.getElementById('txtKey').value;
    var url='../web/zplist.aspx?workPlace='+encodeURIComponent(workPlaceVal)+'&postType='+encodeURIComponent(postTypeVal)+'&releaseDate='+encodeURIComponent(releaseDateVal)+'&keyWord='+encodeURIComponent(keyWord);
    window.open(url);
}
function searchSeeker()
{
    var selSpec=document.getElementById('selSpec');
    var selSpecVal=selSpec.options[selSpec.options.selectedIndex].value;
    var selSex=document.getElementById('selSex');
    var selSexVal=selSex.options[selSex.selectedIndex].value;
    var selPublicShowDate=document.getElementById('selPublicShowDate');
    var selPublicShowDateVal=selPublicShowDate.options[selPublicShowDate.selectedIndex].value;
    var txtKeyWord=document.getElementById('txtKeyWord').value;
    var url='../web/qzlist.aspx?Spec='+encodeURIComponent(selSpecVal)+'&Sex='+encodeURIComponent(selSexVal)+'&PublicShowDate='+encodeURIComponent(selPublicShowDateVal)+'&KeyWord='+encodeURIComponent(txtKeyWord);
    window.open(url);
}
</script>
    </form>
</body>
</html>
