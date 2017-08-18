<%@ Control Language="C#" AutoEventWireup="true" CodeFile="top.ascx.cs" Inherits="Controls_top" %>
<table width="778" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td><table width="778" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
      <tr>
        <td width="263"><embed src="http://a.alimama.cn/widget/yr1/yr1any.swf?r=0.13431620144624728" flashvars="count=20&catid=50000671&h_h=124&h_w=778&sz=9999&type=1&i=mm_10589914_0_0&st_tc=3366CC&st_bgc=FFFFFF&st_bdc=CCCCCC&st_pc=434343&st_lg=0&st_pb=0&r=0.8514314889441632" width="778" height="124" quality="high" wmode="transparent" bgcolor="#ffffff" align="middle" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" /></td>
        </tr>
    </table>
      <table width="778" border="0" cellspacing="0" cellpadding="0" >
        <tr>
          <td height="74" valign="top" background="../images/dh.jpg"><table width="778" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="13" rowspan="2">&nbsp;</td>
                <td width="78" rowspan="2" valign="bottom"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td height="32" align="center"><a href="../Index.aspx" class="bule">首 页</a></td>
                    </tr>
                </table></td>
                <td width="687" height="25"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td width="14%" height="20" align="center" valign="bottom"><a href="../Web/ZPList.aspx" class="white">男人频道</a></td>
                      <td width="14%" align="center" valign="bottom"><a href="../Web/QZList.aspx" class="white">女人频道</a></td>
                      <td width="16%" align="center" valign="bottom"><a href="../Web/GardenList.aspx?NewsType=0" class="white">数码频道</a></td>
                      <td width="14%" align="center" valign="bottom"><a href="../Web/DynamicList.aspx?NewsType=0" class="white">母婴频道</a></td>
                      <td width="14%" align="center" valign="bottom"><a href="../Web/Operation.aspx" class="white">美容频道</a></td>
                      <td width="14%" align="center" valign="bottom"><a href="../Web/GardenList.aspx?NewsType=1" class="white">食品频道</a></td>
                      <td width="14%" align="center" valign="bottom"><a href="../Web/GardenList.aspx?NewsType=2" class="white">饰品频道</a></td>
                    </tr>
                </table></td>
              </tr>
              <tr>
                <td height="25"><table width="91" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="91" height="6"></td>
                  </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td width="14%" height="15" align="center" valign="bottom"><a href="../Web/GardenList.aspx?NewsType=3" class="white">政策法规</a></td>
                      <td width="14%" align="center" valign="bottom"><a href="../Web/PoliticalList.aspx?NewsType=0" class="white">党建园地</a></td>
                      <td width="16%" align="center" valign="bottom"><a href="../Web/WorkFlow.aspx" class="white">办事指南</a></td>
                      <td width="14%" align="center" valign="bottom"><a href="../Web/Service.aspx?ArticleType=0" class="white">服务天地</a></td>
                      <td width="14%" align="center" valign="bottom"><a href="../Web/Refer.aspx" class="white">咨询中心</a></td>
                      <td width="14%" align="center" valign="bottom"><a href="../Web/AboutUs.aspx?ArticleType=0" class="white">关于我们</a></td>
                      <td width="14%" align="center" valign="bottom"><a href="/bbs/" class="white" target="_blank">人才论坛</a></td>
                    </tr>
                </table></td>
              </tr>
              <tr>
                <td height="24" colspan="3"><table width="91" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="91" height="5"></td>
                  </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="31%" align="center" class="font2" >
                        今天是：<asp:Label ID="lbYear" runat="server" Text=""></asp:Label>年<asp:Label
                            ID="lbMonth" runat="server" Text=""></asp:Label>月<asp:Label ID="lbDay" runat="server"
                                Text=""></asp:Label>日
                        <asp:Label ID="lbweakDay" runat="server" Text=""></asp:Label></td>
                    <td class="font2" >公告：</td>
                    <td width="64%" >
                   <asp:DataList id="DataListGG" runat="server" Width="100%" RepeatLayout="Flow" RepeatDirection="Horizontal"><ItemTemplate>
                                <marquee direction="left" scrollamount="1"  width="99%" scrolldelay="3" onmouseover="this.stop()" onmouseout="this.start()">·<a href='../Web/News_View.aspx?NewsID=<%#Eval("NewsID") %>' target="_blank"><%# Eval("Title") %></a> </marquee>    
</ItemTemplate>
</asp:DataList>
</td>
                  </tr>
                </table></td>
              </tr>
          </table></td>
        </tr>
      </table></td>
  </tr>
</table>
