<%@ page language="C#" autoeventwireup="true" inherits="SysAdmin_City_City_Conf, App_Web_f4421hlk" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../../SysAdmin/Css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    	<table width="100%" border="0" cellspacing="0">
					<tr>
						<td width="10" height="25">&nbsp;</td>
						<td valign="bottom">
							位置：&nbsp;城市设置</td>
					</tr>
				</table>
				<table border="0" width="100%" cellpadding="0" cellspacing="0">
					<tr>
						<td valign="top">
							<table border="0" width="100%" cellpadding="0" cellspacing="0">
								<tr>
									<td align="center">
										<table width="98%" cellpadding="3" cellspacing="1" border="0" bgcolor="#ffffff" align="center"
											class="FormTable">
											<form action="product_action.asp" method="post" enctype="multipart/form-data" name="form1"
												onsubmit="return check()">
												
													<tr>
														<td align="right" width="100" class="FormTd1" bgcolor="#c4d4de" height="30">城市：</td>
														<td colspan="2" class="FormTd2" bgcolor="#f3f8fc" height="30">&nbsp;
														</td>
													</tr>
													<tr>
														<td align="right" width="100" class="FormTd1" bgcolor="#c4d4de" height="30">城市名：</td>
														<td colspan="2" class="FormTd2" bgcolor="#f3f8fc" height="30" align=left>
                                                            &nbsp;&nbsp; <font face="宋体">
																<asp:TextBox id="txtCityName" runat="server" Width="96px"></asp:TextBox>
																<asp:TextBox id="txtCityID" runat="server" Width="96px" Visible="False"></asp:TextBox></font>
														</td>
													</tr>
													<tr>
														<td align="right" width="100" class="FormTd1" bgcolor="#c4d4de" height="30">代码1：</td>
														<td colspan="2" class="FormTd2" bgcolor="#f3f8fc" height="30" align=left>
                                                            &nbsp;&nbsp;<font face="宋体">
																<asp:TextBox id="txtCode1" runat="server" Width="96px"></asp:TextBox></font>
														</td>
													</tr>
													<tr>
														<td align="right" width="100" class="FormTd1" bgcolor="#c4d4de" height="30" valign="top">代码2：</td>
														<td colspan="2" class="FormTd2" bgcolor="#f3f8fc" height="30" align="left">&nbsp;&nbsp;<font face="宋体">
																<asp:TextBox id="txtCode2" runat="server" Width="96px"></asp:TextBox></font>
														</td>
													</tr>
													<tr>
														<td align="right" width="100" class="FormTd1" height="30" bgcolor="#c4d4de">&nbsp;</td>
														<td height="30" colspan="2" align="center" class="FormTd2" bgcolor="#f3f8fc">
															<asp:button id="btnAdd" runat="server" Text=" 确定 " CssClass="redButtonCss" OnClick="btnAdd_Click"></asp:button>&nbsp;&nbsp;
															<input class="redButtonCss" id="Reset1" type="reset" value=" 重置 " name="Reset1"/>&nbsp;&nbsp; 
															&nbsp;<input class="redButtonCss" id="btn_cancel" onclick="history.go(-1)" type="button" value=" 返回 "
																name="btn_cancel"/>&nbsp;&nbsp;&nbsp;&nbsp;
														</td>
													</tr>
											</form>
										</table>
									</td>
								</tr>
							</table>
						</td>
					</tr>
					</table>
    </div>
    </form>
</body>
</html>
