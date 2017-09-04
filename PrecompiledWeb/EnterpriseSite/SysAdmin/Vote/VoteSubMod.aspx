<%@ page language="C#" autoeventwireup="true" inherits="SysAdmin_Vote_VoteSubMod, App_Web_xentbuoo" %>

<%@ Register Src="../../Controls/TopButtons.ascx" TagName="TopButtons" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>投票主题修改</title>
    <link href="../Css/Login/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center" border="0" cellpadding="0" cellspacing="0" width="50%">
            <tr>
                <td colspan="4" height="5">
                </td>
            </tr>
            <tr align="right" >
                <td height="18">
                    <uc1:TopButtons ID="TopButtons1" runat="server" />
                </td>
            </tr>
            <tr align="right">
                <td height="18">
                </td>
            </tr>
        </table>
        <table align="center" border="0" cellpadding="0" cellspacing="0" style="width: 50%">
            <tr>
                <td align="left" width="5%">
                    &nbsp;<img alt="" height="23" src="../Images/dig.gif" width="23" />
                </td>
                <td align="left">
                    <font color="#0a7ec5"><b>&nbsp;<asp:label id="lbltitle" Runat="server"></asp:label>
							<asp:Label id="lbsubid" runat="server" Visible="False"></asp:Label></b></font></td>
            </tr>
        </table>
        <table align="center" bgcolor="#d1e3fe" border="0" cellpadding="0" cellspacing="0"
            width="50%">
            <tr>
                <td style="width: 93%" valign="top">
                    <table align="center" bgcolor="#ffffff" border="0" cellpadding="0" cellspacing="0"
                       width="100%">
                        <tr>
                            <td valign="top" width="100%">
                                <table align="center" bgcolor="#d1e3fe" border="0" cellpadding="0" cellspacing="1"
                                    width="100%">
                                    <tr bgcolor="#f6f9ff">
                                        <td align="right" bgcolor="#f6f9ff" height="22">
                                            <span class="STYLE1">调查项目</span></td>
                                        <td height="22" style="width: 372px">
												<asp:TextBox id="TextBox2" runat="server" Width="272px"></asp:TextBox></td>
                                    </tr>
                                    <tr bgcolor="#f6f9ff">
                                        <td align="right" bgcolor="#f6f9ff" height="22">
                                            <span class="STYLE1">是否推荐</span></td>
                                        <td height="22" style="width: 372px">
												<asp:RadioButtonList id="RadioButtonList1" runat="server" Width="136px" RepeatDirection="Horizontal">
													<asp:ListItem Value="0" Selected="True">推荐</asp:ListItem>
													<asp:ListItem Value="1">不推荐</asp:ListItem>
												</asp:RadioButtonList></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <font face="宋体"></font>
                                        </td>
                                    </tr>
                                    <tr bgcolor="#f6f9ff">
                                        <td align="center" colspan="4" height="30">
                                            <font face="宋体">
												<asp:Button id="Button1" runat="server" Text="确定" Width="61px" CssClass="input" OnClick="Button1_Click"></asp:Button>
                                                &nbsp; &nbsp;&nbsp;
												<asp:Button id="Button2" runat="server" Text="取消" Width="59px" CssClass="input" OnClick="Button2_Click"></asp:Button></font></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
    </div>
    </form>
</body>
</html>
