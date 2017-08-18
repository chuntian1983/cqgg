<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorksInfoAdd.aspx.cs" Inherits="SysAdmin_Department_WorksInfoAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../../SysAdmin/Css/css.css" rel="stylesheet" type="text/css" />
</head>
<body ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
        <table cellspacing="0" cellpadding="0" width="80%" align="center" border="0">
            <tr>
                <td align="center" colspan="2" height="8">
                </td>
            </tr>
            <tr>
                <td align="left" width="5%" style="height: 25px">
                    &nbsp;<img height="23" src="../Images/dig.gif" width="23"></td>
                <td align="left" style="height: 25px">
                    <font color="#0a7ec5"><b>
                        <asp:Label ID="Label1" runat="server" Text="添加专家门诊信息"></asp:Label></b></font></td>
            </tr>
        </table>
        <table cellspacing="1" cellpadding="0" width="80%" align="center" bgcolor="#d1e3fe"
            border="0">
            <tr bgcolor="#f6f9ff">
                <td align="right" height="22">
                    <font color="#ff6531">专科类别：</font></td>
                <td>
                    <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" >
                    </asp:DropDownList><span style="color: #ff0000"></span></td>
            </tr>
            <tr bgcolor="#f6f9ff">
                <td align="right" style="height: 23px">
                    <span style="color: #ff6531">医师姓名：</span></td>
                <td style="height: 23px">
                    <asp:TextBox ID="txtTitle" runat="server" Width="432px"></asp:TextBox><span style="color: #ff0000">*
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTitle"
                            ErrorMessage="* 名字不能为空"></asp:RequiredFieldValidator></span></td>
            </tr>
            <tr bgcolor="#f6f9ff">
                <td align="right" style="height: 23px">
                    <font color="#ff6531">出诊时间：</font></td>
                <td style="height: 23px">
                    <asp:TextBox ID="txtOutTime" runat="server" Width="431px"></asp:TextBox>
                    <span style="color: #ff0000">* </span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtOutTime"
                        ErrorMessage="* 出诊时间不能为空"></asp:RequiredFieldValidator></td>
            </tr>
            <tr bgcolor="#f6f9ff">
                <td align="right" height="22">
                    <span style="color: #ff6531">排序：</span></td>
                <td>
                    <asp:TextBox ID="txtSort" runat="server"></asp:TextBox>
                    <span style="color: #ff0000">*   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* 字段不能为空" ControlToValidate="txtSort"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSort" ErrorMessage="* 必须为数字字符" ValidationExpression="\d+"></asp:RegularExpressionValidator></span></td>
            </tr>
            <tr bgcolor="#f6f9ff">
                <td align="center" colspan="2" height="25">
                    <asp:Button ID="btnSubmit" runat="server" Width="80px" CssClass="input" Text="确定"
                        OnClick="btnSubmit_Click"></asp:Button>&nbsp; <span id="spanBack" runat="server"
                            visible="false">
                            <input type="button" value="返回" onclick="history.go(-1);" class="input" /></span>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
