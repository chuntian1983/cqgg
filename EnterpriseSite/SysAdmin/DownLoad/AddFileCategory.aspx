<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddFileCategory.aspx.cs" Inherits="SysAdmin_DownLoad_AddFileCategory" %>

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
                                                        <font face="宋体">上传文件类别:</font></td>
                                                    <td align="left"  style="height: 14px">
                                                        <font face="宋体" color="#ff0033">
                                                            <asp:TextBox ID="txtType" runat="server" Width="200px" BorderStyle="Groove"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* 字段不能为空" ControlToValidate="txtType"></asp:RequiredFieldValidator></font></td>
                                                </tr>
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
