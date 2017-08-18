<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VoteType.aspx.cs" Inherits="SysAdmin_Vote_VoteType" %>

<%@ Register Src="../../Controls/TopButtons.ascx" TagName="TopButtons" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>调查类别添加</title>
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
					<td vAlign="top" width="100%">
						<table height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center" bgColor="#ffffff"
							border="0">
							<tr>
								<td vAlign="top" width="100%">
									<table cellSpacing="1" cellPadding="0" width="100%" align="center" bgColor="#d1e3fe" border="0">
										<tr bgColor="#f6f9ff">
											<td align="center" width="100" bgColor="#f6f9ff" style="height: 22px"><span class="STYLE1">调查类别</span></td>
											<td style="height: 22px"><asp:textbox id="TextBox2" runat="server" Width="280px"></asp:textbox></td>
										</tr>
										<TR>
											<TD align="center" width="100" bgColor="#f6f9ff" height="22"><span class="STYLE1">是否推荐</span></TD>
											<TD height="22" bgColor="#f6f9ff">
												<asp:RadioButtonList id="RadioButtonList1" runat="server" Width="120px" RepeatDirection="Horizontal">
													<asp:ListItem Value="0" Selected="True">推荐</asp:ListItem>
													<asp:ListItem Value="1">不推荐</asp:ListItem>
												</asp:RadioButtonList></TD>
										</TR>
										<tr>
											<td colSpan="4"></td>
										</tr>
										<tr bgColor="#f6f9ff">
											<td align="center" colSpan="2" height="30"><asp:button id="Button1" runat="server" Width="61px" CssClass="input" Text="确定" OnClick="Button1_Click"></asp:button><FONT face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												</FONT>
												<asp:button id="Button2" runat="server" Width="59px" CssClass="input" Text="取消" OnClick="Button2_Click"></asp:button></td>
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
