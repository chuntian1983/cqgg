<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Page.ascx.cs" Inherits="Web_Controls_Page" %>
<table width="96%" border="0" align="center" cellpadding="0" cellspacing="0"  bgcolor="white">
	<tr>
		<td align="right" style="height: 25px" >
			<font color='#000000'>共</font>
			<asp:Label ID="lblRecordCount" runat="server" ForeColor="red"></asp:Label>
			
			<font color='#000000'>条记录共</font>
			<asp:Label id="lblPageCount" runat="server" ForeColor="red" font=33></asp:Label>
	        <font color='#000000'>页<!--第</font><font color='#ffffff'>
		<asp:Label id="lblPageNum"  runat="server"  ForeColor="White" CssClass="style1"></asp:Label>
			</font>
		<font color='#ffffff'>
				页-->直接到</font>
			<asp:dropdownlist id="ddlPageCount" runat="server" OnSelectedIndexChanged="ddlPageCount_SelectedIndexChanged"
				AutoPostBack="True"  ForeColor="#000000" Width="45px"></asp:dropdownlist>
		<font color='#000000'>页</font>
			<asp:HyperLink ID="hlFirst" CommandArgument="first" runat="server">
	    <font color='#000000'>首页</font></asp:HyperLink>&nbsp;
			<asp:HyperLink ID="hlPrev" CommandArgument="previous" runat="server">
		<font color='#000000'>前页</font></asp:HyperLink>&nbsp;
			<asp:HyperLink ID="hlNext" CommandArgument="next" runat="server">
	    <font color='#000000'>后页</font></asp:HyperLink>&nbsp;
			<asp:HyperLink ID="hlLast" CommandArgument="last" runat="server">
		<font color='#000000'>尾页</font></asp:HyperLink>
		</td>
	</tr>
</table>
