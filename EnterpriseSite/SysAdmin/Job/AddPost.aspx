<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddPost.aspx.cs" Inherits="SysAdmin_Job_AddPost" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <LINK href="../Css/css.css" type="text/css" rel="stylesheet">
    <script type="text/javascript" src="../JS/calendar.js"></script>
</head>
	<body >
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="80%" align="center" border="0">
				<tr>
					<td align="center" colSpan="2" height="8"></td>
				</tr>
				<tr>
					<td align="left" width="5%">&nbsp;<IMG height="23" src="../Images/dig.gif" width="23"></td>
					<td align="left"><font color="#0a7ec5"><b>招聘单位名称：</b></font></td>
				</tr>
			</table>
			<table cellSpacing="1" cellPadding="0" width="80%" align="center" bgColor="#d1e3fe" border="0">
                <tr bgcolor="#f6f9ff">
                    <td align="right" height="22">
                        <span style="color: #ff6531">单位名称：</span></td>
                    <td>
                        <asp:Label ID="lbCompanyName" runat="server"></asp:Label></td>
                </tr>
				<tr bgColor="#f6f9ff">
					<td align="right" height="22" ><font color="#ff6531">岗位名称：</font></td>
					<td>
                        <asp:Label ID="lbJobName" runat="server"></asp:Label></td>
				</tr>
				<tr bgColor="#f6f9ff">
					<td align="right" style="height: 21px" ><font color="#ff6531">招聘人数：</font></td>
					<td style="height: 21px">
                        <asp:Label ID="lbNum" runat="server"></asp:Label></td>
				</tr>
				<tr bgColor="#f6f9ff">
					<td align="right" height="22" ><font color="#ff6531">性别要求：</font></td>
					<td>
                        <asp:Label ID="lbSex" runat="server"></asp:Label></td>
				</tr>
                <tr bgcolor="#f6f9ff">
                    <td align="right" height="22">
                        <span style="color: #ff6531">学 &nbsp;&nbsp; 历：</span></td>
                    <td>
                        <asp:Label ID="lbDegree" runat="server"></asp:Label></td>
                </tr>
                <tr bgcolor="#f6f9ff">
                    <td align="right" height="22">
                        <span style="color: #ff6531">年 &nbsp;&nbsp; 龄：</span></td>
                    <td>
                        从<asp:Label ID="lbAge" runat="server" Text=""></asp:Label>岁到<asp:Label ID="lbAg1"
                            runat="server" Text=""></asp:Label>岁</td>
                </tr>
                <tr bgcolor="#f6f9ff">
                    <td align="right" height="22">
                        <span style="color: #ff6531">专业要求：</span></td>
                    <td>
                        <asp:Label ID="lbSubject" runat="server" Text=""></asp:Label></td>
                </tr>
				<tr bgColor="#f6f9ff">
					<td align="right" height="22"><font color="#ff6531"><span class="font13">工作地点：</span></font></td>
					<td>
                        <asp:Label ID="lbWorkPlace" runat="server" Text=""></asp:Label></td>
				</tr>
				<tr bgColor="#f6f9ff">
					<td align="right" style="height: 23px"><font color="#ff6531">工作类型：</font></td>
					<td style="height: 23px">
                        <asp:Label ID="lbWorkType" runat="server"></asp:Label></td>
				</tr>
		
				<tr bgColor="#f6f9ff">
					<td align="right" style="height: 22px"><font color="#ff6531"><span class="TDForm">薪金(年薪)</span>：</font></td>
					<td style="height: 22px">
                        <asp:Label ID="lbPayYear" runat="server" Text=""></asp:Label>元</td>
				</tr>
				<tr bgColor="#f6f9ff">
					<td align="right" height="22" ><font color="#ff6531">发布时间：</font></td>
					<td>
                        <asp:Label ID="lbStartTime" runat="server"></asp:Label></td>
				</tr>
				<tr bgColor="#f6f9ff">
					<td align="right" style="height: 22px" ><font color="#ff6531">截止时间：</font></td>
					<td style="height: 22px">
                        <asp:Label ID="lbEndTime" runat="server"></asp:Label></td>
				</tr>
				<TR bgColor="#f6f9ff">
					<TD align="right" height="22" ><FONT color="#ff6531">其他要求：</FONT></TD>
					<TD>
                        <asp:Literal ID="liContent" runat="server"></asp:Literal></TD>
				</TR>
				<tr bgColor="#f6f9ff">
					<td  colSpan="2" style="height: 25px" align="center">
						<input class="input" type="reset" value="返　回" name="reset"  onclick="javascript:window.history.go(-1);">
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>