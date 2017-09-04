<%@ page language="C#" autoeventwireup="true" inherits="SysAdmin_Poll_PollList, App_Web_kk505s5k" %>
<%@ Register Src="~/controls/Pagination.ascx" TagName="Pagination" TagPrefix="uc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table><tr><td><asp:GridView ID="gvPollList" runat="server" AutoGenerateColumns="false" AllowPaging="true"></asp:GridView></td></tr></table>
    </div>
    </form>
</body>
</html>
