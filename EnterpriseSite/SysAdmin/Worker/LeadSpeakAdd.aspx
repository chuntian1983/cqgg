<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeadSpeakAdd.aspx.cs" Inherits="SysAdmin_Worker_LeadSpeakAdd" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../../SysAdmin/Css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../JS/calendar.js"></script>
    <base target="_self" />
</head>
<body>
 
    
    <body MS_POSITIONING="GridLayout">
		<form id="Form2" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="80%" align="center" border="0">
				<tr>
					<td align="center" colSpan="2" height="8"></td>
				</tr>
				<tr>
					<td align="left" width="5%">&nbsp;<IMG height="23" src="../Images/dig.gif" width="23"></td>
					<td align="left"><font color="#0a7ec5"><b>领导讲话</b></font></td>
				</tr>
			</table>
			<table cellSpacing="1" cellPadding="0" width="80%" align="center" bgColor="#d1e3fe" border="0">
				<tr bgColor="#f6f9ff">
					<td align="right" height="22"><font color="#ff6531">标题：</font></td>
					<td style="width: 722px"><asp:textbox id="txtTitle" runat="server" Width="432px"></asp:textbox><FONT color="red">*<asp:Label
                            ID="lbWarning" runat="server" Visible="False"></asp:Label></FONT></td>
				</tr>
				<tr bgColor="#f6f9ff">
					<td align="right" height="22"><font color="#ff6531">发言人：</font></td>
					<td style="width: 722px">
                        <asp:Label ID="lbSpeaker" runat="server"></asp:Label></td>
				</tr>
				<tr bgColor="#f6f9ff">
					<td align="right" height="22"><font color="#ff6531">生效时间：</font></td>
					<td style="width: 722px"><asp:textbox id="txtReleaseDate" runat="server" Width="432px" onFocus="this.blur()"></asp:textbox>&nbsp;<img  onclick="meizz_calendar(document.getElementById('txtReleaseDate'))"
                                                               style="cursor:pointer;" src="../images/calendar.gif" />
                        <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label></td>
				</tr>
				<TR bgColor="#f6f9ff">
					<TD align="right" style="height: 402px"><FONT color="#ff6531">新闻内容：</FONT></TD>
					<TD style="width: 722px; height: 402px;">
                        <fckeditorv2:fckeditor id="txtContent" runat="server" basepath="../../FCKEditor/" height="400px">
                                        </fckeditorv2:fckeditor>
                    </TD>
				</TR>
				<tr bgColor="#f6f9ff">
					<td align="center" colSpan="2" style="height: 25px">
						<asp:button id="btnSubmit" runat="server" Width="80px" CssClass="input" Text="确定" OnClick="btnSubmit_Click"></asp:button>&nbsp;
						<span id="spanBack" runat="server" visible="false"><input type="button" value="返回" onclick="history.go(-1);" class="input" style="width: 82px" /></span>
						
					</td>
				</tr>
			</table>
		</form>
	</body>
   
</body>
</html>
