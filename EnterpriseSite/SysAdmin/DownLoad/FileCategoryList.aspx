﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileCategoryList.aspx.cs" Inherits="SysAdmin_DownLoad_FileCategoryList" %>

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
				<tr><td height="10px"></td></tr>
				<tr><td>
				<asp:GridView ID="gvFileCategoryList" runat="server" AutoGenerateColumns="false"  BackColor="#D1E3FE" ForeColor="Blue" BorderColor="#1AA0D4" Width="100%" >
							
							<AlternatingRowStyle BackColor="#ECF4FF" />
							<RowStyle Font-Names="宋体" HorizontalAlign="Center" Height="25px" BackColor="#F7F9FF" />
					
							<HeaderStyle HorizontalAlign="Center" Height="25px" ForeColor="#0066FF" CssClass="unnamed1" VerticalAlign="Middle"
								BackColor="#D1E3FE"></HeaderStyle>
				<Columns>
				<asp:BoundField HeaderText="类别标识"  DataField="FileCategoryId"/>
				<asp:BoundField HeaderText="上传类别" DataField="Title" />
				<asp:BoundField HeaderText="添 加 人" DataField="Nickname" />
				<asp:BoundField HeaderText="添加时间" DataField="AddedDate"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false"/>
				<asp:TemplateField HeaderText="操作">
				<ItemTemplate>
				<a href='<%#"AddFileCategory.aspx?CategoryId="+Eval("FileCategoryId") %>' title="修改" id="linkEdit" runat="server" visible="<%#this.AllowEdit %>"><img src="../images/ny/edit.gif" border="0" /></a>
				&nbsp;<asp:ImageButton ID="ibtnDel" runat="server" ToolTip="删除"  ImageUrl="../images/ny/del.gif"  visible="<%#this.AllowDel %>" OnClientClick="javascript:return confirm('删除类别将同时删除该类别下的文件,你确实要删除吗');" CommandArgument='<%#Eval("FileCategoryId")%>'  OnCommand="ibtnDel_Command"/>
				</ItemTemplate>
				</asp:TemplateField>
				</Columns>
				</asp:GridView></td></tr>
				</table>
    </div>
    </form>
</body>
</html>