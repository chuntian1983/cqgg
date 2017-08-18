<%@ Page Language="C#" AutoEventWireup="true"   CodeFile="Weather_Add.aspx.cs" Inherits="SysAdmin_Weather_Weather_Add" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>天气添加</title>
    <link href="../../SysAdmin/Css/css.css" rel="stylesheet" type="text/css" />
   
  
</head>
<BODY>
    <form id="form1" runat="server">
    <div>
   <table width="100%" border="0" cellspacing="0">
					<tr>
						<td width="10" height="25">&nbsp;</td>
						<td valign="bottom">
							位置：&nbsp;添加天气</td>
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
											
												
													<tr>
														<td align="right" width="100" class="FormTd1" bgColor="#c4d4de" height="30">城市：</td>
														<td colspan="2" class="FormTd2" bgColor="#f3f8fc" height="30" align=left>
                                                           
															<asp:DropDownList id="dpl_City" runat="server"></asp:DropDownList>
														</td>
													</tr>
													<tr>
														<td align="right" width="100" class="FormTd1" bgColor="#c4d4de" height="30">今天：</td>
														<td colspan="2" class="FormTd2" bgColor="#f3f8fc" height="30" align=left>
                                                           &nbsp; <font face="宋体">天气：
																<asp:TextBox id="txt_WeatherType" runat="server" Width="96px"></asp:TextBox>最低温度：
																<asp:TextBox id="txt_LowTemperature" runat="server" Width="48px"></asp:TextBox>最高温度：
																<asp:TextBox id="txt_HighTemperature" runat="server" Width="40px"></asp:TextBox>风力：
																<asp:TextBox id="txt_Windy" runat="server" Width="96px"></asp:TextBox></font>
														</td>
													</tr>
													<tr>
														<td align="right" width="100" class="FormTd1" bgColor="#c4d4de" height="30">明天：</td>
														<td colspan="2" class="FormTd2" bgColor="#f3f8fc" height="30" align=left>&nbsp;&nbsp;<font face="宋体">天气：
																<asp:TextBox id="txt_TomWeatherType" runat="server" Width="96px"></asp:TextBox>最低温度：
																<asp:TextBox id="txt_TomLowTemperature" runat="server" Width="48px"></asp:TextBox>最高温度：
																<asp:TextBox id="txt_TomHighTemperature" runat="server" Width="40px"></asp:TextBox>风力：
																<asp:TextBox id="txt_TomWindy" runat="server" Width="96px"></asp:TextBox></font>
														</td>
													</tr>
													<tr>
														<td align="right" width="100" class="FormTd1" bgColor="#c4d4de" height="30" vAlign="top">后天：</td>
														<td colspan="2" class="FormTd2" bgColor="#f3f8fc" height="30" align="left">&nbsp;&nbsp;<font face="宋体">天气：
																<asp:TextBox id="txt_ThirdWeatherType" runat="server" Width="96px"></asp:TextBox>最低温度：
																<asp:TextBox id="txt_ThirdLowTemperature" runat="server" Width="48px"></asp:TextBox>最高温度：
																<asp:TextBox id="txt_ThirdHighTemperature" runat="server" Width="40px"></asp:TextBox>风力：
																<asp:TextBox id="txt_ThirdWindy" runat="server" Width="96px"></asp:TextBox></font>
														</td>
													</tr>
													<tr>
														<td align="right" width="100" class="FormTd1" height="30" bgColor="#c4d4de">&nbsp;</td>
														<td height="30" colspan="2" align="center" class="FormTd2" bgColor="#f3f8fc">
															<asp:button id="btnAdd" runat="server" Text=" 确定 " CssClass="redButtonCss" ></asp:button>&nbsp;&nbsp;
															<input class="redButtonCss" id="Reset1" type="reset" value=" 重置 " name="Reset1">&nbsp;&nbsp; 
															&nbsp;<input class="redButtonCss" id="btn_cancel" onclick="history.go(-1)" type="button" value=" 返回 "
																name="btn_cancel">&nbsp;&nbsp;&nbsp;&nbsp;
														</td>
													</tr>
											
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
