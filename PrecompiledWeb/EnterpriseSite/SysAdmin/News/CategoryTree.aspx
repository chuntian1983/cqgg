<%@ page language="C#" autoeventwireup="true" inherits="SysAdmin_News_CategoryList1, App_Web_ytad3va2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../Css/css.css" rel="stylesheet" type="text/css" />
</head>
<body bgcolor="#f6f9ff">
    <form id="form1" runat="server">
    <table cellspacing="2" cellpadding="2" width="98%" align="center" border="0" >
   <tr>
					<td align="right" bgColor="#f6f9ff" height="23">
						<table height="14" cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td vAlign="bottom" width="55" height="18"><IMG height="14" id="imgEdit" runat="server" src="../images/ny/edit.gif" width="14"> <asp:LinkButton ID="lbtnEdit" runat="server" Text="修改" OnClick="lbtnEdit_Click"></asp:LinkButton></td>
								<td vAlign="bottom" width="55" height="18"><IMG height="14" id="imgDel" runat="server" src="../images/ny/del.gif" width="14"> <asp:LinkButton ID="lbtnDel" runat="server" Text="删除" OnClick="lbtnDel_Click"></asp:LinkButton></td>
								<td width="10px"></td>
							</tr>
						</table>
					</td>
				</tr>
                                                    <tr>
                                                        <td valign="top" align="left">
                                                            <asp:TreeView ID="treeCategory" runat="server" ExpandDepth="1" ShowLines="True" >
                                                            </asp:TreeView>
                                                        </td>
                                                    </tr>
                                                </table>
    </form>
</body>
</html>
