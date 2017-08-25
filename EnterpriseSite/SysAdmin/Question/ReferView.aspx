<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReferView.aspx.cs" Inherits="SysAdmin_Question_ReferView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../../SysAdmin/Css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table cellspacing="0" cellpadding="0" width="80%" align="center" border="0">
                <tr>
                    <td align="center" colspan="2" height="8">
                    </td>
                </tr>
                <tr>
                    <td align="left" width="5%">
                        &nbsp;<img height="23" src="../Images/dig.gif" width="23"></td>
                    <td align="left">
                        <font color="#0a7ec5"><b>咨询详细信息</b></font></td>
                </tr>
            </table>
            <table cellspacing="1" cellpadding="0" width="80%" align="center" bgcolor="#d1e3fe"
                border="0">
                <tr bgcolor="#f6f9ff">
                    <td align="right" style="width: 147px; height: 22px">
                        <font color="#ff6531">咨询人姓名：</font></td>
                    <td width="80%" style="height: 22px">
                        <asp:Label ID="lblName" runat="server"></asp:Label></td>
                </tr>
                <tr bgcolor="#f6f9ff">
                    <td align="right" height="22" style="width: 147px">
                        <font color="#ff6531">电子邮件：</font></td>
                    <td>
                        <asp:Label ID="lbEmail" runat="server"></asp:Label></td>
                </tr>
                <tr bgcolor="#f6f9ff">
                    <td align="right" style="width: 147px; height: 22px;">
                        <font color="#ff6531">联系电话：</font></td>
                    <td style="height: 22px">
                        <asp:Label ID="lbTel" runat="server"></asp:Label></td>
                </tr>
                <tr bgcolor="#f6f9ff">
                    <td align="right" style="width: 147px; height: 22px">
                        <span style="color: #ff6531">联系地址：</span></td>
                    <td style="height: 22px">
                        <asp:Label ID="lbAddress" runat="server"></asp:Label></td>
                </tr>
                <tr bgcolor="#f6f9ff">
                    <td align="right" style="width: 147px; height: 22px">
                        <span style="color: #ff6531">邮 编：</span></td>
                    <td style="height: 22px">
                        <asp:Label ID="lbPost" runat="server"></asp:Label></td>
                </tr>
                <tr bgcolor="#f6f9ff">
                    <td align="right" style="width: 147px; height: 22px;">
                        <font color="#ff6531">咨询主题：</font></td>
                    <td style="height: 22px">
                        <asp:Label ID="lbTitle" runat="server"></asp:Label></td>
                </tr>
                <tr bgcolor="#f6f9ff">
                    <td align="right" height="22" style="width: 147px">
                        <span style="color: #ff6531">咨询内容：</span></td>
                    <td>
                        <asp:Literal ID="lbcontent" runat="server"></asp:Literal></td>
                </tr>
                <tr bgcolor="#f6f9ff">
                    <td align="right" style="width: 147px; height: 22px;">
                        <span style="color: #ff6531">发布时间：</span></td>
                    <td style="height: 22px">
                        <asp:Label ID="lbtime" runat="server"></asp:Label></td>
                </tr>
                <asp:panel ID="aa" runat="server" Visible="true">
                <tr bgcolor="#f6f9ff">
                    <td align="right" height="22" style="width: 147px">
                        <span style="color: #ff6531">回复人姓名：</span></td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                </tr>
               
                   <tr bgcolor="#f6f9ff">
                                <td align="right" style="width: 147px; height: 22px">
                                    <font color="#ff6531">回复内容：</font></td>
                                <td width="80%" style="height: 22px">
                                    &nbsp; <textarea id="Textarea1" runat="server"></textarea></td>
                    </tr>   
                    </asp:panel>      
                       <asp:panel ID="bb" runat="server" Visible="false">   
                            <tr bgcolor="#f6f9ff">
                                <td align="right" style="width: 147px; height: 22px">
                                    <span style="color: #ff6531">回复人姓名：</span></td>
                                <td style="height: 22px" width="80%">
                                    <asp:Label ID="lbRName" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#f6f9ff">
                                <td align="right" style="width: 147px; height: 22px">
                                    <span style="color: #ff6531">回复时间：</span></td>
                                <td style="height: 22px" width="80%">
                                    <asp:Label ID="lbRTime" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#f6f9ff">
                                <td align="right" style="width: 147px; height: 22px">
                                    <span style="color: #ff6531">回复内容：</span></td>
                                <td style="height: 22px" width="80%">
                                    <asp:Literal ID="liRContent" runat="server"></asp:Literal></td>
                            </tr>
                      </asp:panel>
              
                <tr bgcolor="#f6f9ff">
                    <td colspan="2" height="25" align="center">
                        <asp:Button ID="bthuifu" runat="server" Width="65" CssClass="input" Text="回复" OnClick="bthuifu_Click">
                        </asp:Button>
                        <asp:Button ID="Button2" runat="server" CssClass="input" 
                            Text="返 回" Width="65" OnClick="Button2_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
