<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="SysAdmin_Account_User_UserList" %>

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
				<tr id="trcx" runat=server visible=false><td height="20px">
                    用户名：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <asp:Button ID="Button1"
                        runat="server" Text="查询" onclick="Button1_Click" /></td></tr>
				<tr><td>
				<asp:GridView ID="gvUserList" runat="server" AutoGenerateColumns="False"  BackColor="#D1E3FE" ForeColor="Blue" BorderColor="#1AA0D4" Width="100%" >
							
							<AlternatingRowStyle BackColor="#ECF4FF" />
							<RowStyle Font-Names="宋体" HorizontalAlign="Center" Height="25px" BackColor="#F7F9FF" />
					
							<HeaderStyle HorizontalAlign="Center" Height="25px" ForeColor="#0066FF" CssClass="unnamed1" VerticalAlign="Middle"
								BackColor="#D1E3FE"></HeaderStyle>
				<Columns>
                <asp:BoundField HeaderText="所属单位"  DataField="deptname"/>
				<asp:BoundField HeaderText="用 户 名"  DataField="Nickname"/>
				<asp:BoundField HeaderText="真实姓名" DataField="Realname" Visible="False" />
				<asp:BoundField HeaderText="电子邮箱" DataField="Email" Visible="False" />
				<asp:BoundField HeaderText="联系电话" DataField="Tel" Visible="False" />
				<asp:TemplateField HeaderText="状态">
				<ItemTemplate>
				    <asp:LinkButton ID="lbtnApprove" runat="server" Text='<%#Eval("Approved").ToString()=="1"?"启用":"停用" %>' CommandArgument='<%#Eval("UserId") %>' OnCommand="lbtnApprove_Command" Visible="<%#this.AllowApprove%>"></asp:LinkButton>
				    <span id="spanApprove" runat="server" visible="<%#!this.AllowApprove%>"><%#Eval("Approved").ToString()=="1"?"启用":"停用" %></span>
				</ItemTemplate>
				</asp:TemplateField>
				<asp:BoundField HeaderText="注册时间" DataField="AddedDate" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="False" />
				<asp:TemplateField HeaderText="操作">
				<ItemTemplate>
				
				<a href='<%#"AddUser.aspx?UserId="+Eval("UserId") %>' id="linkEdit" runat="server" visible="<%#this.AllowEdit%>" title="修改"><img src="../../images/ny/edit.gif" border="0" /></a>&nbsp;<asp:ImageButton ID="ibtnDel" runat="server" ToolTip="删除" Visible='<%#(Eval("UserId").ToString()!="1")&&this.AllowDel%>' ImageUrl="../../images/ny/del.gif" CommandArgument='<%#Eval("UserId")%>'  OnCommand="ibtnDel_Command" OnClientClick="return confirm('你确认要删除吗!');"/>
				</ItemTemplate>
				</asp:TemplateField>
				</Columns>
				</asp:GridView></td></tr>
				</table>
    </div>
    </form>
</body>
</html>
