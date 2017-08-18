<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YPList.aspx.cs" Inherits="SysAdmin_Job_YPList" %>
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
				<tr><td style="height: 1px">
                    <strong><span style="color: #0a7ec5">应聘信息列表：</span></strong></td></tr>
         <tr>
             <td style="height: 1px">
                 <strong><span style="color: #0a7ec5">根据个人会员姓名查询:<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                     <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查询" /></span></strong></td>
         </tr>
				<tr><td >
				<asp:GridView ID="gvSeekerList" runat="server" AutoGenerateColumns="False"  BackColor="#D1E3FE" ForeColor="Blue" BorderColor="#1AA0D4" Width="100%" AllowPaging="True" PagerSettings-Visible="false" >
							
							<AlternatingRowStyle BackColor="#ECF4FF" />
							<RowStyle Font-Names="宋体" HorizontalAlign="Center" Height="25px" BackColor="#F7F9FF" />
					
							<HeaderStyle HorizontalAlign="Center" Height="25px" ForeColor="#0066FF" CssClass="unnamed1" VerticalAlign="Middle"
								BackColor="#D1E3FE"></HeaderStyle>
				<Columns>
				<asp:BoundField HeaderText="应聘人姓名"  DataField="UserName"/>
				<asp:BoundField HeaderText="学历" DataField="Levels"  Visible="false"/>
                    <asp:BoundField DataField="CompanyName" HeaderText="应聘单位" />
				<asp:BoundField HeaderText="应聘岗位" DataField="Description" />
				<asp:BoundField HeaderText="投简历时间" DataField="SendDate" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="False"/>
				<asp:TemplateField HeaderText="操作">
				<ItemTemplate>
                   <asp:HyperLink id="Hyperlink2" runat="server" NavigateUrl='<%# "PersonInfo.aspx?PersonID=" + DataBinder.Eval(Container.DataItem, "SendOfferId") %>' Text="查看" ImageUrl="../images/ny/edit.gif" Visible="false">
											</asp:HyperLink>
				<asp:ImageButton ID="ibtnDel" runat="server" ToolTip="删除"  ImageUrl="../images/ny/del.gif" CommandArgument='<%#Eval("SendOfferId")%>'  OnCommand="ibtnDel_Command"  OnClientClick="return confirm('你确认要删除吗!');"/>
				</ItemTemplate>
				</asp:TemplateField>
				</Columns>
                    <PagerSettings Visible="False" />
				</asp:GridView></td></tr>
				<tr><td align="left"><uc1:Pagination ID="pageBar" runat="server" PageSize="15"   OnPageIndexChanged="pageBar_PageIndexChanged"/> </td></tr>
				</table>
    </div>
    </form>
</body>
</html>