<%@ page language="C#" autoeventwireup="true" inherits="SysAdmin_Search_MemberSearchResult, App_Web_xoiximou" %>
<%@ Register TagPrefix="uc1" TagName="Pagination" Src="~/Controls/Pagination.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <LINK href="../Css/css.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table cellSpacing="0" cellPadding="0" width="800" border="0" align="center">
				
				<tr>
					<td align="center"  height="10"></td>
				</tr>
				<tr><td>
				<asp:GridView ID="gvMemberList" runat="server" AutoGenerateColumns="false"  BackColor="#D1E3FE" ForeColor="Blue" BorderColor="#1AA0D4" Width="100%" >
							
							<AlternatingRowStyle BackColor="#ECF4FF" />
							<RowStyle Font-Names="宋体" HorizontalAlign="Center" Height="25px" BackColor="#F7F9FF" />
					
							<HeaderStyle HorizontalAlign="Center" Height="25px" ForeColor="#0066FF" CssClass="unnamed1" VerticalAlign="Middle"
								BackColor="#D1E3FE"></HeaderStyle>
				<Columns>
				<asp:BoundField HeaderText="用 户 名"  DataField="Nickname"/>
				<asp:BoundField HeaderText="真实姓名" DataField="Realname" />
				<asp:BoundField HeaderText="电子邮箱" DataField="Email" />
				<asp:BoundField HeaderText="联系电话" DataField="Tel" />
				<asp:TemplateField HeaderText="审核">
				<ItemTemplate>
				    <asp:LinkButton ID="lbtnApprove" runat="server" Text='<%#Eval("Approved").ToString()=="1"?"是":"否" %>' CommandArgument='<%#Eval("UserId") %>' OnCommand="lbtnApprove_Command"></asp:LinkButton>
				</ItemTemplate>
				</asp:TemplateField>
				<asp:BoundField HeaderText="注册时间" DataField="AddedDate" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false" />
				<asp:TemplateField HeaderText="操作">
				<ItemTemplate>
				
				<a href='../Member/MemberInfo.aspx?UserId=<%#Eval("UserId") %>' title="查看"><img src="../images/ny/view.gif" border="0" /></a>&nbsp;<asp:ImageButton ID="ibtnDel" runat="server" ToolTip="删除" Visible='<%#Eval("UserId").ToString()!="1"%>' ImageUrl="../images/ny/del.gif" CommandArgument='<%#Eval("UserId")%>'  OnCommand="ibtnDel_Command"/>
				</ItemTemplate>
				</asp:TemplateField>
				</Columns>
				</asp:GridView></td></tr>
				<tr><td align="left"><uc1:Pagination ID="pageBar" runat="server" PageSize="15"   OnPageIndexChanged="pageBar_PageIndexChanged"/> </td></tr>
				</table>
    </div>
    </form>
</body>
</html>
