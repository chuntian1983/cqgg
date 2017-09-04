<%@ control language="C#" autoeventwireup="true" inherits="Controls_Service, App_Web_yqweqvkc" %>
<table width="175" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td height="26" background="../images/zp.gif"><table width="91" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="91" height="4"></td>
      </tr>
    </table>
        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td width="32%">&nbsp;</td>
            <td width="40%" class="font4">服务天地</td>
            <td width="28%"></td>
          </tr>
      </table></td>
  </tr>
  <tr>
    <td height="33" background="../images/zp2.jpg"><table width="91" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="91" height="10"></td>
      </tr>
    </table>
        <table width="93%" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td><table width="148" border="0" align="center" cellpadding="0" cellspacing="0">
              <tr>
                <td width="84%" height="26" align="center" valign="top" background="../images/zp1.jpg"><table width="91" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="91" height="5"></td>
                  </tr>
                </table>
                  <table width="50%" border="0" align="center" cellpadding="0" cellspacing="0">
                  <tr>
                    <td width="24%"><img src="../images/zp3.jpg" width="10" height="10" /></td>
                    <td width="76%"><a href="../Web/Service.aspx?ArticleType=0">收费标准</a></td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td align="center" valign="top" height=5></td>
              </tr>
            </table>
              <table width="148" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                  <td width="84%" height="26" align="center" valign="top" background="../images/zp1.jpg"><table width="91" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td width="91" height="5"></td>
                      </tr>
                    </table>
                      <table width="50%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                          <td width="24%"><img src="../images/zp3.jpg" width="10" height="10" /></td>
                          <td width="76%"><a href="../Web/FileDown.aspx">资料下载</a></td>
                        </tr>
                      </table></td>
                </tr>
                <tr>
                  <td align="center" valign="top" height="5">
                      <asp:DataList ID="DlZP" runat="server" Width="100%">
                          <ItemTemplate>
                              <table align="center" border="0" cellpadding="0" cellspacing="0" width="98%">
                                  <tr>
                                      <td colspan="2" height="25">
                                          <font face="宋体">·<a href='../Web/FileDown.aspx?TypeId=<%#Eval("FileCategoryId") %>' ><%#Eval("Title")%></a></font></td>
                                  </tr>
                                  <tr>
                                      <td width="87%">
                                          <asp:DataList ID="DlZP1" runat="server" RepeatColumns="1" RepeatDirection="Horizontal"
                                              Width="100%">
                                              <ItemTemplate>
                                                  <table align="center" border="0" cellpadding="0" cellspacing="0" width="98%">
                                                      <tr>
                                                          <td height="25">
                                                              &nbsp;</td>
                                                          <td>
                                                              <span class="font5">诚聘：</span><a class="yellow" href='/Web/GWInfo.aspx?PostId=<%#Eval("PostId") %>'
                                                                  target="_blank"><%#Eval("Description") %></a></td>
                                                      </tr>
                                                  </table>
                                              </ItemTemplate>
                                          </asp:DataList>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td background="../images/line.gif" colspan="2" height="1">
                                      </td>
                                  </tr>
                              </table>
                          </ItemTemplate>
                      </asp:DataList></td>
                </tr>
              </table>
              <table width="148" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                  <td width="84%" height="26" align="center" valign="top" background="../images/zp1.jpg"><table width="91" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td width="91" height="5"></td>
                      </tr>
                    </table>
                      <table width="50%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                          <td width="24%"><img src="../images/zp3.jpg" width="10" height="10" /></td>
                          <td width="76%"><a href="../Web/Question.aspx">常见问题</a></td>
                        </tr>
                    </table></td>
                </tr>
                <tr>
                  <td align="center" valign="top" height="5"></td>
                </tr>
              </table></td>
          </tr>
      </table></td>
  </tr>
  <tr>
    <td><img src="../images/zp1.gif" width="175" height="6" /></td>
  </tr>
</table>
<table width="91" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="91" height="5"></td>
  </tr>
</table>