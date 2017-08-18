<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddPoll.aspx.cs" Inherits="SysAdmin_Poll_AddPoll" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
   <asp:Panel ID="plQuestion" runat="server">
    <table><tr>
    <td>提示问题:</td><td><asp:TextBox ID="txtQuestion" runat="server"></asp:TextBox></td></tr>
    <tr><td colspan="2"><asp:Button ID="btnSubmitQuestion" runat="server" Text="提交问题" OnClick="btnSubmitQuestion_Click" /></td>
    </tr></table>
    </asp:Panel>
    <asp:Panel ID="plAnswer" runat="server">
    <table><tr><td>答案1：</td><td><asp:TextBox ID="txtAns1" runat="server"></asp:TextBox></td></tr>
    <tr><td>答案2：</td><td><asp:TextBox ID="txtAns2" runat="server"></asp:TextBox></td></tr>
    <tr><td>答案3：</td><td><asp:TextBox ID="txtAns3" runat="server"></asp:TextBox></td></tr>
    <tr><td>答案4：</td><td><asp:TextBox ID="txtAns4" runat="server"></asp:TextBox></td></tr>
    <tr><td colspan="2"><asp:Button ID="btnSubmitAnswer" runat="server" Text="提交答案" OnClick="btnSubmitAnswer_Click" /><asp:Button ID="btnCreateNextQuestion" runat="server" Text="提交并在创建一个问题" OnClick="btnCreateNextQuestion_Click" /><input type="button" value="返回" /></td></tr></table>
    </asp:Panel>
    </form>
</body>
</html>
