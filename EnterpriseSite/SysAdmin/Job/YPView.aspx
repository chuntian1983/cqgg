<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YPView.aspx.cs" Inherits="SysAdmin_Job_YPView" %>

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
					<td align="left"><font color="#0a7ec5"><b>&nbsp;应聘情况简单信息</b></font></td>
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
											<TD align="center" bgcolor="#f6f9ff"  width="15%" style="height: 22px"><span class="STYLE1"> 招聘单位名称</span></TD>
											<TD width="35%" style="height: 22px">
                                                <asp:Label ID="lbCommpany" runat="server"></asp:Label></TD>
											<td align="center" bgcolor="#f6f9ff" width="15%" style="height: 22px"><span class="STYLE1"> 岗位名称</span></td>
											<td width="35%" style="height: 22px">
                                                <asp:Label ID="lbJobName" runat="server"></asp:Label></td>
										</TR>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" style="height: 22px">
                                                <span style="color: #ff6531">招聘人数</span></td>
                                            <td style="height: 22px">
                                                <asp:Label ID="lbCount" runat="server"></asp:Label></td>
                                            <td align="center" bgcolor="#f6f9ff" style="height: 22px">
                                                <span style="color: #ff6531">发布时间</span></td>
                                            <td style="height: 22px">
                                                <asp:Label ID="lbFillTime" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" style="height: 22px">
                                                <span style="color: #ff6531"> 应聘人姓名</span></td>
                                            <td style="height: 22px">
                                                <asp:Label ID="lbPersonName" runat="server"></asp:Label></td>
                                            <td align="center" bgcolor="#f6f9ff" style="height: 22px">
                                                <span style="color: #ff6531"> 性 别</span></td>
                                            <td style="height: 22px">
                                                <asp:Label ID="lbSex" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">学 历</span></td>
                                            <td>
                                                <asp:Label ID="lbDegree" runat="server"></asp:Label></td>
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">专 业</span></td>
                                            <td>
                                                <asp:Label ID="lbSubject" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">出生日期</span></td>
                                            <td>
                                                <asp:Label ID="lbBirthDay" runat="server"></asp:Label></td>
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">投简历时间</span></td>
                                            <td>
                                                <asp:Label ID="lbSendDate" runat="server"></asp:Label></td>
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


