<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="SysAdmin_Account_User_AddUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <LINK href="../../Css/css.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="Form1" runat="server">
    <div>
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
					<td align="left" width="5%">&nbsp;<IMG height="23" src="../../Images/dig.gif" width="23"></td>
					<td align="left"><font color="#0a7ec5"><b><%=_pageTitle %></b></font></td>
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
                                                        <font face="宋体">用户昵称:</font></td>
                                                    <td align="left"  style="height: 14px">
                                                        <font face="宋体" color="#ff0033">
                                                            <asp:TextBox ID="txtNickname" runat="server" Width="200px" BorderStyle="Groove"></asp:TextBox><asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtNickname" ErrorMessage="* 该字段不能为空!" ></asp:RequiredFieldValidator></font></td>
                                                </tr>
                                                 <tr id="trPwd" runat="server">
                                                    <td align="right" style="height: 14px">
                                                        <font face="宋体">密码:</font></td>
                                                    <td align="left"  style="height: 14px">
                                                        <font face="宋体" color="#ff0033">
                                                            <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" Width="200px" BorderStyle="Groove"></asp:TextBox><asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtPwd" ErrorMessage="* 该字段不能为空!" ></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPwd"
                                                                ErrorMessage="* 密码长度不能少于6个字符" ValidationExpression="^\s*.{6,}\s*$"></asp:RegularExpressionValidator></font></td>
                                                </tr>
                                                <tr id="trPwdConfirm" runat="server">
                                                    <td align="right" style="height: 14px">
                                                        <font face="宋体">确认密码:</font></td>
                                                    <td align="left"  style="height: 14px">
                                                        <font face="宋体" color="#ff0033">
                                                            <asp:TextBox ID="txtPwdConfirm" runat="server" TextMode="Password" Width="200px" BorderStyle="Groove" ></asp:TextBox> <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="* 密码输入不一致"
                                                            ControlToCompare="txtPwd" ControlToValidate="txtPwdConfirm"></asp:CompareValidator></font></td>
                                                </tr>
                                                <tr >
                                                    <td align="right" style="height: 34px">
                                                        所属行政级别:</td>
                                                    <td align="left"  style="height: 34px">
                                                        <asp:DropDownList ID="ddlParentCategory" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr >
                                                    <td align="right" style="height: 34px">
                                                        <font face="宋体">系统角色:</font></td>
                                                    <td align="left"  style="height: 34px">
                                                        <font face="宋体">
                                                           <asp:DropDownList ID="ddlRole" runat="server" ></asp:DropDownList></font></td>
                                                </tr>
                                                <asp:panel ID="aa" runat="server" Visible="false">
                                                <tr >
                                                    <td align="right" style="height: 34px">
                                                        <font face="宋体">真实姓名:</font></td>
                                                    <td align="left"  style="height: 34px">
                                                        <font face="宋体">
                                                            <asp:TextBox ID="txtRealname" runat="server" Width="200px" BorderStyle="Groove"></asp:TextBox></font></td>
                                                </tr>
                                                 <tr >
                                                    <td align="right" style="height: 34px">
                                                        <font face="宋体">省份:</font></td>
                                                    <td align="left"  style="height: 34px">
                                                        <font face="宋体">
                                                            <asp:TextBox ID="txtProvince" runat="server" Width="200px" BorderStyle="Groove"></asp:TextBox></font></td>
                                                </tr>
                                                 <tr >
                                                    <td align="right" style="height: 34px">
                                                        <font face="宋体">城市:</font></td>
                                                    <td align="left"  style="height: 34px">
                                                        <font face="宋体">
                                                            <asp:TextBox ID="txtCity" runat="server" Width="200px" BorderStyle="Groove"></asp:TextBox></font></td>
                                                </tr>
                                                 <tr >
                                                    <td align="right" style="height: 34px">
                                                        <font face="宋体">住址:</font></td>
                                                    <td align="left"  style="height: 34px">
                                                        <font face="宋体">
                                                            <asp:TextBox ID="txtAddress" runat="server" Width="200px" BorderStyle="Groove"></asp:TextBox></font></td>
                                                </tr>
                                                 <tr >
                                                    <td align="right" style="height: 34px">
                                                        <font face="宋体">邮政编码:</font></td>
                                                    <td align="left"  style="height: 34px">
                                                        <font face="宋体">
                                                            <asp:TextBox ID="txtPostalcode" runat="server" Width="200px" BorderStyle="Groove"></asp:TextBox></font></td>
                                                </tr>
                                               <tr >
                                                    <td align="right" style="height: 34px">
                                                        <font face="宋体">联系电话:</font></td>
                                                    <td align="left"  style="height: 34px">
                                                        <font face="宋体">
                                                            <asp:TextBox ID="txtTel" runat="server" Width="200px" BorderStyle="Groove"></asp:TextBox></font></td>
                                                </tr>
                                                <tr >
                                                    <td align="right" style="height: 34px">
                                                        <font face="宋体">电子邮件:</font></td>
                                                    <td align="left"  style="height: 34px">
                                                        <font face="宋体">
                                                              <asp:TextBox ID="txtEmail" runat="server" Width="200px" BorderStyle="Groove"></asp:TextBox></font></td>
                                                </tr>
                                               
                                                <tr >
                                                    <td align="right" width="106"  height="20">
                                                        <font face="宋体">备注:</font></td>
                                                    <td align="left" >
                                                        <font face="宋体">
                                                            <asp:TextBox ID="txtRemark" runat="server" Columns="30" Rows="4" BorderStyle="Groove" TextMode="MultiLine"></asp:TextBox>
                                                        </font>
                                                    </td>
                                                </tr>
                                                </asp:panel>
                                               
                                                <tr  align="center">
                                                    <td align="center"  colspan="2">
                                                        <asp:Button ID="btnSave" runat="server"  Text="保存" OnClick="btnSave_Click" />
                                                          <input type="button" value="重置" onclick="javascript:document.Form1.reset();" />
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
    </div>
    </form>
</body>
</html>
