<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AssignPermission.aspx.cs" Inherits="SysAdmin_Account_Role_AssignPermission" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <LINK href="~/sysadmin/Css/css.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table cellspacing="2" cellpadding="2" width="98%" align="center" border="0" bgcolor="#f6f9ff">
    <tr>
					<td align="right" bgColor="#f6f9ff" height="23">
						<table height="14" cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td vAlign="bottom" width="70" height="18"><asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" /></td>
								<td vAlign="bottom" width="70" height="18"><IMG height="14" src="../../images/ny/b_2.gif" width="14"><a href="rolelist.aspx" >返回</a></td>
								
						</table>
					</td>
				</tr>
				<tr><td><span style="color:Red;">栏目授权
“√”表示肯定授权，空表示否定授权。</span></td></tr>
                                                    <tr bgcolor="#f6f9ff">
                                                        <td valign="top" align="left">
                                                            <asp:TreeView ID="treeMenu" runat="server" ExpandDepth="1" ShowLines="True" >
                                                            </asp:TreeView>
                                                        </td>
                                                    </tr>
                                                </table>
    </div>
    </form>
</body>
</html>
