<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wztj.ascx.cs" Inherits="Controls_wztj" %>
<table width="175" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td height="30" background="../images/left6.gif"><table width="91" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="91" height="6"></td>
      </tr>
    </table>
        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td width="6%">&nbsp;</td>
            <td width="66%" class="font4">| 网站统计 </td>
            <td width="28%"><a href="#" class="white"></a></td>
          </tr>
      </table></td>
  </tr>
  <tr>
    <td height="33" background="../images/left7.jpg"><table width="91" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="91" height="5"></td>
      </tr>
    </table>
        <table width="92%" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td width="6%">&nbsp;</td>
            <td width="94%"><table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                  <td width="84%" height="25">
                      有效招聘岗位：<asp:Label ID="lblPostNumTotal" runat="Server"></asp:Label>个</td>
                </tr>
              </table>
                <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                  <tr>
                    <td width="84%" height="25">
                        本周新增岗位：<asp:Label ID="lblPostNumWeekly" runat="server"></asp:Label>个</td>
                  </tr>
                </table>
              <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                  <tr>
                    <td width="84%" height="25">
                        本周新增简历：<asp:Label ID="lblResumeNumWeekly" runat="server"></asp:Label>份</td>
                  </tr>
                </table>
              <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                  <tr>
                    <td width="84%" height="25">
                        本人才库简历：<asp:Label ID="lblResumeNumTotal" runat="server"></asp:Label>份</td>
                  </tr>
              </table></td>
          </tr>
      </table></td>
  </tr>
  <tr>
    <td><img src="../images/left9.gif" width="175" height="10" /></td>
  </tr>
</table>
