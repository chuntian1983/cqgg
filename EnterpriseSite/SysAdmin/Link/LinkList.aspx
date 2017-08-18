<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LinkList.aspx.cs" Inherits="SysAdmin_Link_LinkList" %>

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
				<tr><td style="height: 10px">
                    <span style="color: #0a7ec5"><strong>友情链接列表：</strong></span></td></tr>
				<tr><td >
				<asp:GridView ID="gvLinkList" runat="server" AutoGenerateColumns="False"  BackColor="#D1E3FE" ForeColor="Blue" BorderColor="#1AA0D4" Width="100%" AllowPaging="True" PagerSettings-Visible="false" >
							
							<AlternatingRowStyle BackColor="#ECF4FF" />
							<RowStyle Font-Names="宋体" HorizontalAlign="Center" Height="25px" BackColor="#F7F9FF" />
					
							<HeaderStyle HorizontalAlign="Center" Height="25px" ForeColor="#0066FF" CssClass="unnamed1" VerticalAlign="Middle"
								BackColor="#D1E3FE"></HeaderStyle>
				<Columns>
				<asp:BoundField HeaderText="标题"  DataField="Title"/>
				<asp:BoundField HeaderText="连接" DataField="Link" />
				<asp:BoundField HeaderText="排序" DataField="Sort" />
				<asp:TemplateField HeaderText="操作">
				<ItemTemplate>
				<a href='<%#"AddLink.aspx?LinkId="+Eval("LinkId") %>' id="linkEdit" runat="server" visible="<%#this.AllowEdit %>" title="修改"><img src="../images/ny/edit.gif" border="0" /></a>
				&nbsp;<asp:ImageButton ID="ibtnDel" runat="server" ToolTip="删除"  ImageUrl="../images/ny/del.gif" CommandArgument='<%#Eval("LinkId")%>' Visible="<%#this.AllowDel %>"  OnCommand="ibtnDel_Command"/>
				</ItemTemplate>
				</asp:TemplateField>
				</Columns>
                    <PagerSettings Visible="False" />
				</asp:GridView>
                    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label></td></tr>
				</table>
    </div>
    </form>
</body>
</html>