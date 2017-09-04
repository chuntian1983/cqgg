<%@ page language="C#" autoeventwireup="true" inherits="SysAdmin_Vote_VoteTypeMod, App_Web_xentbuoo" %>

<%@ Register Src="../../Controls/TopButtons.ascx" TagName="TopButtons" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>投票类别修改</title>
    <link href="../Css/Login/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table height="14" cellSpacing="0" cellPadding="0" width="50%" align="center" border="0">
				<tr>
					<td colSpan="4" height="5"></td>
				</tr>
				<tr align="right" width="100%">
					<td height="18">
                        <uc1:TopButtons ID="TopButtons1" runat="server" />
                    </td>
				</tr>
				<tr align="right">
					<td height="18"></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="50%" align="center" border="0">
				<tr>
					<td align="left" width="5%">&nbsp;<IMG height="23" src="../Images/dig.gif" width="23">
					</td>
					<td align="left"><font color="#0a7ec5"><b><asp:label id="lbltitle" Runat="server"></asp:label>
								<asp:Label id="Label1" runat="server" Visible="False"></asp:Label></b></font></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="50%" align="center" bgColor="#d1e3fe" border="0">
				<tr>
					<td vAlign="top" style="width: 93%">
						<table height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center" bgColor="#ffffff"
							border="0">
							<tr>
								<td vAlign="top" width="100%">
									<table cellSpacing="1" cellPadding="0" width="100%" align="center" bgColor="#d1e3fe" border="0">
										<tr bgColor="#f6f9ff">
											<td bgColor="#f6f9ff" height="22" align="right"><span class="STYLE1">调查类别</span></td>
											<td height="22" style="width: 372px"><asp:textbox id="TextBox2" runat="server" Width="180px"></asp:textbox></td>
										</tr>
										<tr bgColor="#f6f9ff">
											<td bgColor="#f6f9ff" height="22" align="right"><span class="STYLE1">是否推荐</span></td>
											<td height="22" style="width: 372px">
												<asp:RadioButtonList id="RadioButtonList1" runat="server" Width="120px" RepeatDirection="Horizontal">
													<asp:ListItem Value="0" Selected="True">推荐</asp:ListItem>
													<asp:ListItem Value="1">不推荐</asp:ListItem>
												</asp:RadioButtonList></td>
										</tr>
										<tr>
											<td colSpan="4"><FONT face="宋体"></FONT></td>
										</tr>
										<tr bgColor="#f6f9ff">
											<td align="center" colSpan="4" height="30"><asp:button id="Button1" runat="server" Width="61px" Text="确定" CssClass="input" OnClick="Button1_Click"></asp:button><FONT face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												</FONT>
												<asp:Button id="Button2" runat="server" Text="取消" Width="59px" CssClass="input" OnClick="Button2_Click"></asp:Button></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
    </div>
    </form>
</body>
</html>
