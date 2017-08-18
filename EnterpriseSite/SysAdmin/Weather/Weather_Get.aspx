<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Weather_Get.aspx.cs" Inherits="SysAdmin_Weather_Weather_Get" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>获取天气</title>
    <link href="../../Css/Login/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        GetList<br />
    <asp:Button id="btnStartGet" runat="server"
				Text="开始获取" OnClick="btnStartGet_Click"></asp:Button>
			<br>
			<asp:Label ID="lblMsg" Runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
