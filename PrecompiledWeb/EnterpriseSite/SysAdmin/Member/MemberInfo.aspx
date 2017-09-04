<%@ page language="C#" autoeventwireup="true" inherits="SysAdmin_Member_MemberInfo, App_Web_g2aq3kzd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>企业会员详细信息</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Css/css.css" type="text/css" rel="stylesheet">
		<style type="text/css">
		    .break { WORD-BREAK: break-all }
	        .STYLE1 { COLOR: #ff6531 }
		</style>
		<base  target="_self"></base>
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			
			<table cellSpacing="0" cellPadding="0" width="90%" align="center" border="0">
			<tr><td height="10px"></td></tr>
				<tr>
					<td align="center" colSpan="2" height="8"><FONT face="宋体"></FONT></td>
				</tr>
				<tr>
					<td align="left" width="5%">&nbsp;<IMG height="23" src="../Images/dig.gif" width="23">
					</td>
					<td align="left"><font color="#0a7ec5"><b>企业会员详细信息</b></font></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="80%" align="center" bgColor="#d1e3fe" border="0">
				<tr>
					<td vAlign="top" width="100%">
						<table height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center" bgColor="#ffffff"
							border="0">
							<tr>
								<td vAlign="top" width="100%">
									<table cellSpacing="1" cellPadding="0" width="100%" align="center" bgColor="#d1e3fe" border="0">
										<TR bgcolor="#f6f9ff">
											<TD align="center" bgcolor="#f6f9ff"  width="15%" style="height: 22px"><span class="STYLE1"> 用户名&nbsp; </span>
											</TD>
											<TD width="35%" style="height: 22px">
                                                <asp:Label ID="lbName" runat="server"></asp:Label></TD>
											<td align="center" bgcolor="#f6f9ff" width="15%" style="height: 22px"><span class="STYLE1"> 公司名称</span></td>
											<td width="35%" style="height: 22px">
                                                <asp:Label ID="lbCompany" runat="server"></asp:Label></td>
										</TR>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" style="height: 22px">
                                                <span style="color: #ff6531">公司规模</span></td>
                                            <td style="height: 22px">
                                                <asp:Label ID="lbSize" runat="server"></asp:Label></td>
                                            <td align="center" bgcolor="#f6f9ff" style="height: 22px">
                                                <span style="color: #ff6531">公司性质</span></td>
                                            <td style="height: 22px">
                                                <asp:Label ID="lbCharacter" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">营业执照号</span></td>
                                            <td>
                                                <asp:Label ID="lbLicenseID" runat="server"></asp:Label></td>
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">注册机构</span></td>
                                            <td>
                                                <asp:Label ID="lbOrgan" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">所在地</span></td>
                                            <td>
                                                <asp:Label ID="lbLocus" runat="server"></asp:Label></td>
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">公司地址</span></td>
                                            <td>
                                                <asp:Label ID="lbAddress" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">邮政编码</span></td>
                                            <td>
                                                <asp:Label ID="lbPost" runat="server"></asp:Label></td>
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">联系人</span></td>
                                            <td>
                                                <asp:Label ID="lbLinkman" runat="server"></asp:Label></td>
                                        </tr>
										<tr bgColor="#f6f9ff">
											<td align="center" bgColor="#f6f9ff" style="height: 22px"><span class="STYLE1">联系电话</span></td>
											<td style="height: 22px">
                                                <asp:Label ID="lbTel" runat="server"></asp:Label></td>
											<td align="center" bgColor="#f6f9ff" style="height: 22px"><span class="STYLE1"><SPAN class="STYLE1">联系传真</SPAN></span></td>
											<td style="height: 22px"><FONT face="宋体">
                                                <asp:Label ID="lbFax" runat="server"></asp:Label></FONT></td>
										</tr>
										<tr bgColor="#f6f9ff">
											<TD align="center" bgColor="#f6f9ff" height="21" style="HEIGHT: 21px"><span class="STYLE1"><SPAN class="STYLE1">电子邮箱</SPAN></span></TD>
											<TD style="HEIGHT: 21px"><FONT face="宋体">
                                                <asp:Label ID="lbEmail" runat="server"></asp:Label></FONT></TD>
											<TD align="center" bgColor="#f6f9ff" height="22"><span class="STYLE1">网 址</span></TD>
											<TD><FONT face="宋体">
                                                <asp:Label ID="lbWeb" runat="server"></asp:Label></FONT></TD>
										</tr>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">注册时间</span></td>
                                            <td colspan="3">
                                                <asp:Label ID="lbAddDate" runat="server"></asp:Label></td>
                                        </tr>
										<tr bgColor="#f6f9ff">
											<TD align="center" bgColor="#f6f9ff" height="22"><span class="STYLE1">公司简介</span></TD>
											<TD colspan="3"><FONT face="宋体">
                                                <asp:Literal ID="liCompanyInfo" runat="server"></asp:Literal></FONT></TD>
										</tr>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">用户密码</span></td>
                                            <td colspan="3">
                                                <asp:Label ID="lbpwd" runat="server" Text=""></asp:Label></td>
                                        </tr>
										
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">密码提示问题</span></td>
                                            <td colspan="3">
                                                <asp:Label ID="lbQuestion" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">密码查询答案</span></td>
                                            <td colspan="3">
                                                <asp:Label ID="lbAnswer" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">安全邮箱(用于接收密码信息)</span></td>
                                            <td colspan="3">
                                                <asp:Label ID="lbPassEmail" runat="server"></asp:Label></td>
                                        </tr>
                                     
										<tr><td colspan="4" align="center"><input type="button" value="关闭" onclick="window.close();" /></td></tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
