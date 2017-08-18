<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectIcon.aspx.cs" Inherits="SysAdmin_Menu_SelectIcon" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>选择菜单项图标</title>
     <script>
     function getPic(obj)
     {       
        var imgUrl = obj.src;
        var iconName=imgUrl.substr(imgUrl.lastIndexOf('/'));     
        window.dialogArguments.value = '../images/menu/left/logo'+iconName;
        window.close();
     }
     </script>
     <base target="_self"  ></base>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="420px" style="border:#bbbbbb solid 1px;background-color:#f0f0f0;">
						<tr><td  id="td1">
						<asp:datalist id="dlIcon" Runat="server" RepeatColumns="10" RepeatDirection="Horizontal">
								<ItemTemplate>
								<table><tr><td>
									<img style="cursor:hand;" onclick='getPic(this);'  src='<%#Container.DataItem%>' border="0" width="32" height="32">
									</td></tr>
								</table>
								</ItemTemplate>
							</asp:datalist></td></tr>
							</table>
    </div>
    </form>
</body>
</html>
