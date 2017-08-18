<%@ Control Language="C#" AutoEventWireup="true" CodeFile="zpxx.ascx.cs" Inherits="Controls_zpxx" %>
<table width="175" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td height="26" background="../images/zp.gif">
            <table width="91" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="91" height="4">
                    </td>
                </tr>
            </table>
            <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="32%">
                        &nbsp;</td>
                    <td width="40%" class="font4">
                        推荐职位</td>
                    <td width="28%">
                        <a href="#" class="white"></a>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td height="33" background="../images/zp2.jpg">
            <table width="91" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="91" height="5">
                    </td>
                </tr>
            </table>
            <table width="93%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
                <tr>
                    <td>
                        <asp:DataList ID="DlZP" runat="server"
                            Width="100%">
                            <ItemTemplate>
                                <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="25" colspan="2">
                                            ·<a  href="../Web/QYMemberView.aspx?MemberId=<%#Eval("UserId") %>" target="_blank"><%#Eval("CompanyName")%></a><asp:Label ID="LabId" runat="server" Text='<%# Eval("ID")%>' Visible="false"> </asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td width="87%">
                                            <asp:DataList ID="DlZP1" runat="server"  Width="100%" RepeatColumns="1" RepeatDirection="Horizontal">
                                                <ItemTemplate>
                                                    <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td height="25">
                                                                &nbsp;</td>
                                                            <td>
                                                                <span class="font5">诚聘：</span><a href="/Web/GWInfo.aspx?PostId=<%#Eval("PostId") %>" target="_blank" class="yellow"><%#Eval("Description") %></a></td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="1" colspan="2" background="../images/line.gif">
                                        </td>
                                    </tr>
                                  
                                </table>
                            </ItemTemplate>
                        </asp:DataList></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <img src="../images/zp1.gif" width="175" height="6" /></td>
    </tr>
</table>
<table width="91" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td width="91" height="5">
        </td>
    </tr>
</table>
