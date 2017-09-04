<%@ page language="C#" autoeventwireup="true" inherits="SysAdmin_Bmfw_list, App_Web_ahdciwu4" %>
<%@ Register TagPrefix="uc1" TagName="Pagination" Src="~/Controls/Pagination.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../../SysAdmin/Css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
					<table width="800" align="center">
					<tr>
						<td >
                            <span style="color: #0a7ec5"><strong>便民服务信息列表：</strong></span></td>
					</tr>
                        <tr>
                            <td >
                   
						<asp:GridView ID="gvOptions" runat="server" AutoGenerateColumns="False"  
                                    BackColor="#D1E3FE" ForeColor="Blue" BorderColor="#1AA0D4" Width="100%" 
                                    EnableModelValidation="True">
							<AlternatingRowStyle BackColor="#ECF4FF" />
							<RowStyle Font-Names="宋体" HorizontalAlign="Center" Height="25px" BackColor="#F7F9FF" />
							<HeaderStyle HorizontalAlign="Center" Height="25px" ForeColor="#0066FF" CssClass="unnamed1" VerticalAlign="Middle"
								BackColor="#D1E3FE"></HeaderStyle>
				<Columns>
				<asp:BoundField HeaderText="村级名称" DataField="title" />
                    <asp:TemplateField HeaderText="是否有便民服务大厅">
                        <ItemTemplate>
                           <%#Eval("state")%>
                        </ItemTemplate>
                    </asp:TemplateField>
				    <asp:BoundField DataField="bz" HeaderText="备注" />
				<asp:TemplateField HeaderText="操作">
				<ItemTemplate>
				    &nbsp;<asp:Button ID="Button1" runat="server"  Text="编辑" 
                        CommandArgument='<%#Eval("id") %>' CommandName="edit" onclick="Button1_Click" />
                    &nbsp;
                    <asp:Button ID="Button2" runat="server" Text="删除"  OnClientClick="return confirm('您确认要删除吗？');" CommandArgument='<%#Eval("id") %>' CommandName="del" />
				
				</ItemTemplate>
				</asp:TemplateField>
				</Columns>
				</asp:GridView>
                            </td>
                        </tr>
					<tr><td align="left" style="width: 1206px">
                        <uc1:Pagination id="pageBar" runat="server" OnPageIndexChanged="pageBar_PageIndexChanged"
                            PageSize="15"></uc1:Pagination></td></tr>
				</table>
				
    </div>
    </form>
</body>
</html>
