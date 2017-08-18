<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PostList.aspx.cs" Inherits="SysAdmin_Job_PostList" %>
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
                    <strong><span style="color: #0a7ec5">招聘信息列表：</span></strong></td></tr>
         <tr>
             <td style="height: 1px">
                 <strong><span style="color: #0a7ec5">根据招聘单位名称查询：<asp:TextBox ID="txtName" runat="server"
                     Width="224px"></asp:TextBox>
                     <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查询" /></span></strong></td>
         </tr>
				<tr><td >
				<asp:GridView ID="gvPostList" runat="server" AutoGenerateColumns="False"  BackColor="#D1E3FE" ForeColor="Blue" BorderColor="#1AA0D4" Width="100%" AllowPaging="True" PagerSettings-Visible="false" >
							
							<AlternatingRowStyle BackColor="#ECF4FF" />
							<RowStyle Font-Names="宋体" HorizontalAlign="Center" Height="25px" BackColor="#F7F9FF" />
					
							<HeaderStyle HorizontalAlign="Center" Height="25px" ForeColor="#0066FF" CssClass="unnamed1" VerticalAlign="Middle"
								BackColor="#D1E3FE"></HeaderStyle>
				<Columns>
				<asp:BoundField HeaderText="招聘单位"  DataField="CompanyName"/>
				<asp:BoundField HeaderText="招聘职位" DataField="Description" />
				<asp:BoundField HeaderText="招聘人数" DataField="PersonNum" />
				<asp:BoundField HeaderText="发布日期" DataField="AddedDate" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="False"/>
                    <asp:TemplateField HeaderText="审核" Visible="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnApprove" runat="server" CommandArgument='<%#Eval("PostId") %>'
                                OnCommand="lbtnApprove_Command" Text='<%#Eval("Approved").ToString()=="1"?"是":"否" %>'
                                Visible="<%#this.AllowApprove%>"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                     
				<asp:TemplateField HeaderText="操作">
				<ItemTemplate>
				<a href='<%#"AddPost.aspx?PostId="+Eval("PostId") %>' title="查看" id="linkEdit" runat="server" visible="true"><img src="../images/ny/edit.gif" border="0" /></a>
				&nbsp;<asp:ImageButton ID="ibtnDel" runat="server" visible="<%#this.AllowDel %>" ToolTip="删除"  ImageUrl="../images/ny/del.gif" CommandArgument='<%#Eval("PostId")%>'  OnCommand="ibtnDel_Command" OnClientClick="return confirm('你确认要删除吗!');"/>
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