<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login2.aspx.cs" Inherits="jubao_login2" %>

<%@ Register assembly="ValidateCode" namespace="Mic" tagprefix="acoo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            height: 387px;
        }
        .style3
        {
            height: 387px;
            width: 576px;
        }
        .style4
        {
            width: 576px;
        }
        .style5
        {
            width: 576px;
            height: 30px;
        }
        .style6
        {
            height: 30px;
        }
        .style9
        {
            width: 576px;
            height: 33px;
        }
        .style10
        {
            height: 33px;
        }
        .style11
        {
            width: 576px;
            height: 52px;
        }
        .style12
        {
            height: 52px;
        }
        .style13
        {
            height: 387px;
            width: 248px;
        }
        .style14
        {
            height: 30px;
            width: 248px;
        }
        .style15
        {
            height: 33px;
            width: 248px;
        }
        .style16
        {
            height: 52px;
            width: 248px;
        }
        .style17
        {
            width: 248px;
        }
        .style18
        {
            width: 234px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" background-image:url('images/login20.jpg'); background-repeat:no-repeat; width:1024px; height:768px;">
    
        <table class="style1">
            <tr>
                <td class="style3">
                <table style="height: 286px">
                <tr>
                <td class="style18">
                      <a href="http://192.168.200.106" style=" text-decoration:none; width:100%; height:20px;" target=_blank>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a>&nbsp;</td>
                </tr>
                <tr>
                <td class="style18">
                    &nbsp;</td>
                </tr>
                <tr>
                <td class="style18">
                </td>
                </tr>
                <tr>
                <td class="style18">
                    &nbsp;</td>
                </tr>
                <tr>
                <td class="style18">
                    &nbsp;</td>
                </tr>
                <tr>
                <td class="style18">
                    &nbsp;</td>
                </tr>
                <tr>
                <td class="style18">
                    &nbsp;</td>
                </tr>
                <tr>
                <td class="style18" style=" text-align:right;">
               </td>
                </tr>
                <tr>
                <td class="style18">
                    &nbsp;</td>
                </tr>
                </table>
                </td>
                <td class="style13">
                    &nbsp;</td>
                <td class="style2">
                </td>
            </tr>
            <tr>
                <td class="style5">
                </td>
                <td class="style14">
       <asp:TextBox ID="txtName" runat="server" Width="65%" MaxLength="40"></asp:TextBox>
                </td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                </td>
                <td class="style15">
       <asp:TextBox ID="txtPassword" runat="server" Width="64%" MaxLength="40" 
           TextMode="Password"></asp:TextBox>
                </td>
                <td class="style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                </td>
                <td class="style15">
       <input id="Text1" type="text" runat="server" style=" width:50px;" 
           maxlength="10" /><acoo:imgcontrol id="Validnum" runat="server"></acoo:imgcontrol>
                </td>
                <td class="style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style11">
                </td>
                <td class="style16">
       <asp:ImageButton ID="ImageButton1" runat="server" 
           ImageUrl="images/denglu55.jpg" onclick="ImageButton1_Click" />
                </td>
                <td class="style12">
                </td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style17">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
