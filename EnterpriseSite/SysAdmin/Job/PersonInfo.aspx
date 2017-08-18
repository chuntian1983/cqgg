<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonInfo.aspx.cs" Inherits="SysAdmin_Job_PersonInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>个人求职具体信息</title>
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
					<td align="left"><font color="#0a7ec5"><b>
                                                <asp:Label ID="lbName" runat="server"></asp:Label>
                        个人求职具体信息</b></font></td>
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
                                            <td align="left" bgcolor="#f6f9ff" height="22" colspan="4">
                                                
                                                    <img height="9" src="../images/icon.gif" width="16" />
                                                   <strong><span class="font10">简历编号:<asp:Label ID="lbResumeId" runat="server"></asp:Label></span></strong>
                                                       <span style="color: #0a7ec5"> [刷新简历时间:<asp:Label ID="lbChangeTime" runat="server"></asp:Label>]</span></td>
                                        </tr>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="left" bgcolor="#f6f9ff" colspan="4" height="22">
                                                <strong><span style="color: #0a7ec5">(1)求职意向</span></strong></td>
                                        </tr>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="left" bgcolor="#f6f9ff" colspan="4" height="22">
                                                <strong><span style="color: #0a7ec5">a.欲应聘岗位</span></strong></td>
                                        </tr>
										<TR bgcolor="#f6f9ff">
											<TD align="center" bgcolor="#f6f9ff"  width="15%" style="height: 22px"><span class="STYLE1"> 工作类型&nbsp;</span></TD>
											<TD width="35%" style="height: 22px">
                                                <asp:Label ID="lbJobType" runat="server"></asp:Label></TD>
											<td align="center" bgcolor="#f6f9ff" width="15%" style="height: 22px"><span class="STYLE1"> 职 位</span></td>
											<td width="35%" style="height: 22px">
                                                <asp:Label ID="lbJobName" runat="server"></asp:Label></td>
										</TR>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="left" bgcolor="#f6f9ff" style="height: 22px" colspan="4">
                                                <span style="color: #ff6531"></span>
                                                <span style="color: #ff6531"><span style="color: #0a7ec5"><strong>b.工作要求</strong></span></span></td>
                                        </tr>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" style="height: 22px">
                                                <span style="color: #ff6531">现职业</span></td>
                                            <td style="height: 22px">
                                                <asp:Label ID="lbWorkNow" runat="server"></asp:Label></td>
                                            <td align="center" bgcolor="#f6f9ff" style="height: 22px">
                                                <span style="color: #ff6531">现工作单位性质</span></td>
                                            <td style="height: 22px">
                                                <asp:Label ID="lbCompanyTypeNow" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" style="height: 22px">
                                                <span style="color: #ff6531">应聘单位性质</span></td>
                                            <td style="height: 22px">
                                                <asp:Label ID="lbCompanyType" runat="server"></asp:Label></td>
                                            <td align="center" bgcolor="#f6f9ff" style="height: 22px">
                                                <span style="color: #ff6531">参加工作时间</span></td>
                                            <td style="height: 22px">
                                                <asp:Label ID="lbWorkYear" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">从事现工作时间</span></td>
                                            <td>
                                                <asp:Label ID="lbWorkYearNow" runat="server"></asp:Label></td>
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">要求工作地区</span></td>
                                            <td>
                                                <asp:Label ID="lbPlace" runat="server"></asp:Label></td>
                                        </tr>
										<tr bgColor="#f6f9ff">
											<td align="center" bgColor="#f6f9ff" style="height: 22px"><span class="STYLE1">现工作地区</span></td>
											<td style="height: 22px">
                                                <asp:Label ID="lbPlaceNow" runat="server"></asp:Label></td>
											<td align="center" bgColor="#f6f9ff" style="height: 22px"><span class="STYLE1"><SPAN class="STYLE1">收入要求</SPAN></span></td>
											<td style="height: 22px"><FONT face="宋体">
                                                <asp:Label ID="lbPayBegin" runat="server"></asp:Label>到<asp:Label ID="lbPayEnd" runat="server"></asp:Label>元</FONT></td>
										</tr>
										<tr bgColor="#f6f9ff">
											<TD align="center" bgColor="#f6f9ff" height="21" style="HEIGHT: 21px"><span class="STYLE1"><SPAN class="STYLE1">现工作单位</SPAN></span></TD>
											<TD style="HEIGHT: 21px"><FONT face="宋体">
                                                <asp:Label ID="lbCompanyNow" runat="server"></asp:Label></FONT></TD>
											<TD align="center" bgColor="#f6f9ff" height="22"><span class="STYLE1">到岗时间</span></TD>
											<TD><FONT face="宋体">
                                                <asp:Label ID="lbWorkOntime" runat="server"></asp:Label></FONT></TD>
										</tr>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">其他要求</span></td>
                                            <td colspan="3">
                                                <asp:Label ID="lbOther" runat="server"></asp:Label></td>
                                        </tr>
										<tr bgColor="#f6f9ff">
											<TD align="left" bgColor="#f6f9ff" height="22" colspan="4"><span class="STYLE1" style="color: #0a7ec5"><strong>(2)求职简历&nbsp; </strong></span></TD>
										</tr>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">培训经历</span></td>
                                            <td colspan="3">
                                                <asp:Literal ID="liTrainInfo" runat="server"></asp:Literal></td>
                                        </tr>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" style="height: 22px">
                                                <span style="color: #ff6531">工作经历</span></td>
                                            <td colspan="3" style="height: 22px">
                                                <asp:Literal ID="liWorkInfo" runat="server"></asp:Literal></td>
                                        </tr>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">专业技能</span></td>
                                            <td colspan="3">
                                                <asp:Literal ID="liSpecialSkill" runat="server"></asp:Literal></td>
                                        </tr>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">工作业绩</span></td>
                                            <td colspan="3">
                                                <asp:Literal ID="liWorkResult" runat="server"></asp:Literal></td>
                                        </tr>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">自我评价</span></td>
                                            <td colspan="3">
                                                <asp:Literal ID="liPersonAssess" runat="server"></asp:Literal></td>
                                        </tr>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">特 长</span></td>
                                            <td colspan="3">
                                                <asp:Literal ID="liPrefer" runat="server"></asp:Literal></td>
                                        </tr>
                                        <tr bgcolor="#f6f9ff">
                                            <td align="center" bgcolor="#f6f9ff" height="22">
                                                <span style="color: #ff6531">备 注</span></td>
                                            <td colspan="3">
                                                <asp:Literal ID="liPlus" runat="server"></asp:Literal></td>
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

