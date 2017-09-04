<%@ page language="C#" autoeventwireup="true" inherits="SysAdmin_Member_MemberInfo1, App_Web_g2aq3kzd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>个人会员详细信息</title>
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
					<td align="left"><font color="#0a7ec5"><b>个人会员详细信息</b></font></td>
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
                                          <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">个人照片</span></td>
                                            <td colspan="3">
                                              <asp:Image ID="Image1" runat="server" Height="150px" ImageUrl="~/images/w.jpg" Width="120px" /></td>
                                        </tr>
										<TR bgcolor="#f6f9ff">
											<TD align="center" bgcolor="#f6f9ff"  width="15%" style="height: 22px"><span class="STYLE1"> 用户名&nbsp; </span>
											</TD>
											<TD width="35%" style="height: 22px">
                                                <asp:Label ID="lbName" runat="server"></asp:Label></TD>
											<td align="center" bgcolor="#f6f9ff" width="15%" style="height: 22px"><span class="STYLE1"> 真实姓名</span></td>
											<td width="35%" style="height: 22px">
                                                <asp:Label ID="lbRealName" runat="server"></asp:Label></td>
										</TR>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" style="height: 22px">
                                                <span style="color: #ff6531">性 别</span></td>
                                            <td style="height: 22px">
                                                <asp:Label ID="lbSex" runat="server"></asp:Label></td>
                                            <td align="center" bgcolor="#f6f9ff" style="height: 22px">
                                                <span style="color: #ff6531">出生年月</span></td>
                                            <td style="height: 22px">
                                                <asp:Label ID="lbBirthday" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">证件类型</span></td>
                                            <td>
                                                <asp:Label ID="lbPaperType" runat="server"></asp:Label></td>
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">证件号码</span></td>
                                            <td>
                                                <asp:Label ID="lbPaperNO" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">政治面貌</span></td>
                                            <td>
                                                <asp:Label ID="lbPolitical" runat="server"></asp:Label></td>
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">婚姻状况</span></td>
                                            <td>
                                                <asp:Label ID="lbMarry" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">毕业学校</span></td>
                                            <td>
                                                <asp:Label ID="lbSchool" runat="server"></asp:Label></td>
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">毕业时间</span></td>
                                            <td>
                                                <asp:Label ID="lbGraduateTime" runat="server"></asp:Label></td>
                                        </tr>
										<tr bgColor="#f6f9ff">
											<td align="center" bgColor="#f6f9ff" style="height: 22px"><span class="STYLE1">最高学历</span></td>
											<td style="height: 22px">
                                                <asp:Label ID="lbLevels" runat="server"></asp:Label></td>
											<td align="center" bgColor="#f6f9ff" style="height: 22px"><span class="STYLE1"><SPAN class="STYLE1">所学专业</SPAN></span></td>
											<td style="height: 22px"><FONT face="宋体">
                                                <asp:Label ID="lbSpeciality" runat="server"></asp:Label></FONT></td>
										</tr>
										<tr bgColor="#f6f9ff">
											<TD align="center" bgColor="#f6f9ff" style="HEIGHT: 14px"><span class="STYLE1"><SPAN class="STYLE1">身 高</SPAN></span></TD>
											<TD style="HEIGHT: 14px"><FONT face="宋体">
                                                <asp:Label ID="lbHeight" runat="server"></asp:Label>CM</FONT></TD>
											<TD align="center" bgColor="#f6f9ff" style="height: 14px"><span class="STYLE1">体 重</span></TD>
											<TD style="height: 14px"><FONT face="宋体">
                                                <asp:Label ID="lbWeight" runat="server"></asp:Label>KG</FONT></TD>
										</tr>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" height="21" style="height: 21px">
                                                <span style="color: #ff6531">户口所在地</span></td>
                                            <td style="height: 21px">
                                                <asp:Label ID="lbHome" runat="server"></asp:Label></td>
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">当前所在地</span></td>
                                            <td>
                                                <asp:Label ID="lbPlace" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" height="21" style="height: 21px">
                                                <span style="color: #ff6531">联系方式</span></td>
                                            <td style="height: 21px">
                                                <asp:Label ID="lbContact" runat="server"></asp:Label></td>
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">邮政编码</span></td>
                                            <td>
                                                <asp:Label ID="lbPost" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" height="21" style="height: 21px">
                                                <span style="color: #ff6531">联系电话</span></td>
                                            <td style="height: 21px">
                                                <asp:Label ID="lbTel" runat="server"></asp:Label></td>
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">联系人</span></td>
                                            <td>
                                                <asp:Label ID="lbLinkman" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" height="21" style="height: 21px">
                                                <span style="color: #ff6531">电子邮箱</span></td>
                                            <td style="height: 21px">
                                                <asp:Label ID="lbEmail" runat="server"></asp:Label></td>
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">注册时间</span></td>
                                            <td>
                                                <asp:Label ID="lbAddDate" runat="server"></asp:Label></td>
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
