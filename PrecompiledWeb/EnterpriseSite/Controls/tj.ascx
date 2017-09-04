<%@ control language="C#" autoeventwireup="true" inherits="Controls_tj, App_Web_nwnxy2ch" %>
<table width="175" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td height="30" background="../images/left61.gif"><table width="91" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="91" height="5"></td>
      </tr>
    </table>
        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td width="6%">&nbsp;</td>
            <td width="66%" class="font4">| 名企推荐</td>
            <td width="28%"><a href="#" class="white"></a></td>
          </tr>
    </table></td>
  </tr>
  <tr>
    <td height="33" background="../images/left71.jpg"><table width="91" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="91" height="5"></td>
      </tr>
    </table>
        <table width="93%" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td>
              <table width="98%" border="0" cellpadding="2" cellspacing="0">
                <tr>
                 <td valign="top">
                     <asp:DataList ID="DataList1" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" Width="100%">
                     <ItemTemplate>
                     <table width="49%" border="0" cellpadding="2" cellspacing="0">
              <tr>
                <td width="84%" height="32" align="center"><a href="<%#Eval("Link") %>" target="_blank"><img width="80" height="25" id="IMG1" runat="server" src='<%#this.ResolveClientUrl(this.imagePath+Eval("ADPic"))%>' border="0"/></a></td>
               
              </tr>
            </table>
                     </ItemTemplate>
                     </asp:DataList></td>
                </tr>
              </table>
              </td>
          </tr>
    </table></td>
  </tr>
  <tr>
    <td><img src="../images/left91.gif" width="175" height="10" /></td>
  </tr>
</table>
<table width="91" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="91" height="5"></td>
  </tr>
</table>
