<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Pagination.ascx.cs" Inherits="SysAdmin_AD_Pagination" %>
<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
	<tr>
		<td align="right" width="50%">
			记录:<asp:label id="RecCount" Runat="server"></asp:label>条&nbsp;&nbsp; 页次:<font color="red"><asp:Label ID="CurPage" Runat="server"></asp:Label></font>/<asp:label id="PagCount" Runat="server"></asp:label>&nbsp;&nbsp;
			<asp:linkbutton id="FirstPage" Runat="server" CommandArgument="First">[首页]</asp:linkbutton>&nbsp;&nbsp;
			<asp:linkbutton id="PreviousPage" Runat="server" CommandArgument="Previous">[前页]</asp:linkbutton>&nbsp;&nbsp;
			<asp:linkbutton id="NextPage" Runat="server" CommandArgument="Next">[后页]</asp:linkbutton>&nbsp;&nbsp;
			<asp:linkbutton id="LastPage" Runat="server" CommandArgument="Last">[末页]</asp:linkbutton>&nbsp;&nbsp;
		</td>
	</tr>
</table>