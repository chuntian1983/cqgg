<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DepartAdd.aspx.cs" Inherits="SysAdmin_Department_DepartAdd" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../Css/css.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="../JS/calendar.js"></script>

    <base target="_self" />
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
                        <%=_pageTitle%>
                    </b></font>
                </td>
            </tr>
        </table>
        <table cellspacing="1" cellpadding="0" width="80%" align="center" bgcolor="#d1e3fe"
            border="0">
            <tr bgcolor="#f6f9ff">
                <td align="right" height="22">
                    <font color="#ff6531">科室名称：</font></td>
                <td>
                    <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                    </asp:DropDownList><span style="color: #ff0000">请选择科室类别</span></td>
            </tr>
            <tr bgcolor="#f6f9ff">
                <td align="right" style="height: 23px">
                    <span style="color: #ff6531">
                        <asp:Label ID="lbTitle" runat="server" Text="文章标题"></asp:Label>：</span></td>
                <td style="height: 23px">
                    <asp:TextBox ID="txtTitle" runat="server" Width="432px"></asp:TextBox><span style="color: #ff0000">*</span></td>
            </tr>
            <tr bgcolor="#f6f9ff">
                <td align="right" height="22">
                    <font color="#ff6531">科室介绍：</font></td>
                <td>
                    
                    <textarea id="fckBody" runat="server"></textarea>
                </td>
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
