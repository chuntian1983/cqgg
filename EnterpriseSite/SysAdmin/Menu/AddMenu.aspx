<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddMenu.aspx.cs" Inherits="SysAdmin_MenuManager_AddOrEditMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head >
    <title>无标题页</title>
    <LINK href="../Css/css.css" type="text/css" rel="stylesheet">
     <script type="text/jscript" src="../js/prototype.js"></script>
      <script>
      function openWinDialog(url,arg)
      {
        return window.showModalDialog(url, arg, 'edge:raised;scroll:0;status:0;help:0;resizable:1;dialogWidth:420px;dialogHeight:205px;')
      }
      
      function selectPic(showReturnValueObj)
      {
          openWinDialog('../menu/selecticon.aspx',$(showReturnValueObj));
      }   
     </script>
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
                                                        <font face="宋体">菜单名称:</font></td>
                                                    <td align="left"  style="height: 14px">
                                                        <font face="宋体" color="#ff0033">
                                                            <asp:TextBox ID="txtMenuName" runat="server" Width="200px" BorderStyle="Groove"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* 字段不能为空" ControlToValidate="txtMenuName"></asp:RequiredFieldValidator></font></td>
                                                </tr>
                                                
                                                <tr >
                                                    <td align="right" style="height: 34px">
                                                        <font face="宋体">菜单连接地址:</font></td>
                                                    <td align="left"  style="height: 34px">
                                                        <font face="宋体">
                                                            <asp:TextBox ID="txtMenuLink" runat="server" Width="200px" BorderStyle="Groove"></asp:TextBox></font></td>
                                                </tr>
                                               <tr >
                                                    <td align="right" style="height: 34px">
                                                        <font face="宋体">图片地址:</font></td>
                                                    <td align="left"  style="height: 34px">
                                                        <font face="宋体">
                                                            <asp:TextBox ID="txtImageLink" runat="server" Width="200px" BorderStyle="Groove" onFocus="this.blur();"></asp:TextBox></font> <input  type="button" value="选择图标" onclick="selectPic('txtImageLink');" title='选择图标' /></td>
                                                </tr>
                                                <tr >
                                                    <td align="right" style="height: 34px">
                                                        <font face="宋体">可 见 性:</font></td>
                                                    <td align="left"  style="height: 34px">
                                                        <font face="宋体">
                                                            <asp:CheckBox ID="cbIsVisible" runat="server" Text="在菜单中显示" /></font></td>
                                                </tr>
                                                <tr >
                                                    <td align="right" height="20">
                                                        <font face="宋体">上级菜单:</font></td>
                                                    <td align="left" >
                                                        <asp:DropDownList ID="ddlParentMenu" runat="server">
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr >
                                                    <td align="right" width="106"  height="20">
                                                        <font face="宋体">排列序号:</font></td>
                                                    <td align="left" >
                                                        <font face="宋体">
                                                            <asp:TextBox ID="txtSort" runat="server" Width="80px" BorderStyle="Groove"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* 字段不能为空" ControlToValidate="txtSort"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSort"
                                                                ErrorMessage="* 请输入正整数" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                        </font>
                                                    </td>
                                                </tr>
                                               
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
    </form>
</body>
</html>
