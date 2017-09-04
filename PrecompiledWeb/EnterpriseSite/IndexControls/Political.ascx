<%@ control language="C#" autoeventwireup="true" inherits="Controls_Political, App_Web_szj1oefn" %>
<table width="175" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td height="30" background="images/left6.gif"><table width="91" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="91" height="6"></td>
      </tr>
    </table>
        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td width="6%">&nbsp;</td>
            <td width="66%" class="font4">| 政策法规</td>
              <td width="28%"><a href="Web/GardenList.aspx?NewsType=3" class="white">更多...</a></td>
          </tr>
      </table></td>
  </tr>
  <tr>
    <td height="33" background="images/left7.jpg"><table width="91" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="91" height="5"></td>
      </tr>
    </table>
        <table width="92%" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td>   
            <asp:DataList ID="DlPolitical" runat="server" Width="100%">
                <ItemTemplate>
                <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                  <td width="84%" height="25">·<a href="Web/News_View.aspx?NewsID=<%#Eval("NewsID") %>" target="_blank"> <%# getSubString(Eval("Title").ToString(),10)%></a></td>
                </tr>
              </table>
                </ItemTemplate>
                </asp:DataList>
                </td>
          </tr>
      </table></td>
  </tr>
  <tr>
    <td><img src="images/left9.gif" width="175" height="10" /></td>
  </tr>
</table>
<table width="91" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="91" height="6"></td>
  </tr>
</table>
