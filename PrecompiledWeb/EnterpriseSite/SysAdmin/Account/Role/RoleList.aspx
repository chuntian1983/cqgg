<%@ page language="C#" autoeventwireup="true" inherits="SysAdmin_Account_Role_RoleList, App_Web_vaji55f3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <LINK href="../../Css/css.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellSpacing="0" cellPadding="0" width="800" border="0" align="center">
				<tr><td height="10px"></td></tr>
				<tr><td>
				<asp:GridView ID="gvRoleList" runat="server" AutoGenerateColumns="false"  BackColor="#D1E3FE" ForeColor="Blue" BorderColor="#1AA0D4" Width="100%" >
							
							<AlternatingRowStyle BackColor="#ECF4FF" />
							<RowStyle Font-Names="宋体" HorizontalAlign="Center" Height="25px" BackColor="#F7F9FF" />
					
							<HeaderStyle HorizontalAlign="Center" Height="25px" ForeColor="#0066FF" CssClass="unnamed1" VerticalAlign="Middle"
								BackColor="#D1E3FE"></HeaderStyle>
				<Columns>
				<asp:BoundField HeaderText="排 序 号"  DataField="Sort"/>
				<asp:BoundField HeaderText="角色名称" DataField="Name" />
				<asp:BoundField HeaderText="描述" DataField="Remark" />
				<asp:TemplateField HeaderText="操作">
				<ItemTemplate>
				<a href='<%#"AssignPermission.aspx?RoleId="+Eval("RoleId") %>' id="linkAssign" runat="server" visible='<%#this.AllowAssign%>'>权限分配</a>&nbsp;
				<a href='<%#"addRole.aspx?RoleId="+Eval("RoleId") %>' title="修改" id="linkEdit" runat="server" visible='<%#this.AllowEdit%>'><img src="../../images/ny/edit.gif" border="0" /></a>&nbsp;
				<asp:ImageButton ID="ibtnDel" runat="server" ToolTip="删除" Visible='<%#(Eval("RoleId").ToString()!="1")&&this.AllowDel%>' ImageUrl="../../images/ny/del.gif" CommandArgument='<%#Eval("RoleId")%>' OnCommand="ibtnDel_Command" OnClientClick="return confirm('你确认要删除吗!');"/>
				</ItemTemplate>
				</asp:TemplateField>
				</Columns>
				</asp:GridView></td></tr>
				</table>
    </div>
    </form>
</body>
</html>
