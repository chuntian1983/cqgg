﻿<%@ page language="C#" autoeventwireup="true" inherits="SysAdmin_Link_AddLink, App_Web_io0wu5cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head >
    <title>无标题页</title>
    <LINK href="../Css/css.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="Form1" runat="server" method="post">
        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
            <tr>
                <td width="5" >
                </td>
                <td align="center" >
                    <table id="Table1" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td height="5">
                            </td>
                        </tr>
                    </table>
                  			<table cellSpacing="0" cellPadding="0" width="80%" align="center" border="0">
				<tr>
					<td align="center" colSpan="2" height="8"></td>
				</tr>
				<tr>
					<td align="left" width="5%">&nbsp;<IMG height="23" src="../Images/dig.gif" width="23"></td>
					<td align="left"><font color="#0a7ec5"><b><%=_pageTitle%></b></font></td>
				</tr>
			</table>
			<table cellSpacing="1" cellPadding="0" width="80%" align="center" bgColor="#d1e3fe" border="0">
			 <tr bgColor="#f6f9ff">
                            <td valign="top">
                                <table id="table3" cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td align="center">
                                            <table cellspacing="1" cellpadding="5" width="98%"  border="0" align="center">
                                                
                                                <tr >
                                                    <td align="right" style="height: 14px">
                                                        <font face="宋体">标题:</font></td>
                                                    <td align="left"  style="height: 14px">
                                                        <font face="宋体" color="#ff0033">
                                                            <asp:TextBox ID="txtTitle" runat="server" Width="200px" BorderStyle="Groove"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* 字段不能为空" ControlToValidate="txtTitle"></asp:RequiredFieldValidator></font></td>
                                                </tr>
                                                <tr >
                                                    <td align="right" style="height: 14px">
                                                        <font face="宋体">连接:</font></td>
                                                    <td align="left"  style="height: 14px">
                                                        <font face="宋体" color="#ff0033">
                                                            <asp:TextBox ID="txtLink" runat="server" Width="200px" BorderStyle="Groove"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* 字段不能为空" ControlToValidate="txtLink"></asp:RequiredFieldValidator></font></td>
                                                </tr>
                                                <asp:Panel ID="a" runat="server" Visible="false">
                                                <tr >
                                                    <td align="right" style="height: 14px">
                                                        <font face="宋体">图片地址:</font></td>
                                                    <td align="left"  style="height: 14px">
                                                        <font face="宋体" color="#ff0033">
                                                            <asp:TextBox ID="txtImage" runat="server" Width="200px" BorderStyle="Groove"></asp:TextBox></font></td>
                                                </tr>
                                                </asp:Panel>
                                                 <tr >
                                                    <td align="right" style="height: 14px">
                                                        <font face="宋体">排序号:</font></td>
                                                    <td align="left"  style="height: 14px">
                                                        <font face="宋体" color="#ff0033">
                                                            <asp:TextBox ID="txtSort" runat="server" Width="200px" BorderStyle="Groove"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="* 字段不能为空" ControlToValidate="txtSort"></asp:RequiredFieldValidator>
                                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSort"
                                                                ErrorMessage="* 请输入正整数" ValidationExpression="^\d+$"></asp:RegularExpressionValidator></font></td>
                                                </tr>
                                                <asp:Panel ID="b" runat="server" Visible="true">
                                                 <tr >
                                                    <td align="right" style="height: 14px">
                                                        <font face="宋体">公开链接类别:</font></td>
                                                    <td align="left"  style="height: 14px">
                                                        <font face="宋体" color="#ff0033">
                                                            <asp:DropDownList ID="ddlDisplayMode" runat="server">
                                                            <asp:ListItem Text="党务公开" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="政务公开" Value="1"></asp:ListItem>
                                                           
                                                            </asp:DropDownList></font></td>
                                                </tr>
                                                </asp:Panel>
                                                <tr  align="center">
                                                    <td align="center"  colspan="2">
                                                        <asp:Button ID="btnSave" runat="server"  Text="保存" OnClick="btnSave_Click" />
                                                              </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
			</table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>