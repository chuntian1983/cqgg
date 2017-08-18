<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TopButtons.ascx.cs" Inherits="Controls_TopButtons" %>
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
	<tr>
		<td height="23" align="right" bgcolor="#f6f9ff" style="width: 926px">
			<table height="14" border="0" cellpadding="0" cellspacing="0">
				<tr>
				<tr>
					<asp:Panel ID="_PaneAdd" Runat="server" Visible="False">
						<TD vAlign="bottom" width="23" height="18"><IMG height="14" src="../images/ny/add.gif" width="14"></TD>
						<TD vAlign="bottom" width="46" height="18"><A onclick="javascript:Add_Node();return false;" href="#">添加</A></TD>
					</asp:Panel>
					<td width="23" height="18" valign="bottom"><img src="../images/ny/b_1.gif" width="14" height="14"></td>
					<td width="46" height="18" valign="bottom"><a href="#" onclick="javascript:window.history.go(0)">刷新</a></td>
					<td width="23" height="18" valign="bottom"><img src="../images/ny/b_2.gif" width="14" height="14"></td>
					<td width="46" height="18" valign="bottom"><a href="#" onclick="javascript:window.history.go(-1)">返回</a></td>
				</tr>
			</table>
		</td>
	</tr>
	<tr class="tab1">
		<td height="1" align="center" bgcolor="#4180c6" style="width: 926px"></td>
	</tr>
</table>
