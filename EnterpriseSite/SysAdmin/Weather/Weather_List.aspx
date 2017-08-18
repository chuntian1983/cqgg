<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Weather_List.aspx.cs" Inherits="SysAdmin_Weather_Weather_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>天气预报列表</title>
    <link href="../../Css/Login/css.css" rel="stylesheet" type="text/css" />
    <link href="../../SysAdmin/Css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        GetList<table cellSpacing="0" width="100%" border="0">
					<tr>
						<td width="10" height="25">&nbsp;</td>
						<td vAlign="bottom">位置：天气列表&nbsp;
						</td>
					</tr>
				</table>
				<table cellSpacing="1" cellPadding="0" width="98%" align="center" border="0">
					<tr>
						<td class="row1">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
								<TR>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD align="center">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD align="left" width="30">&nbsp;
															</TD>
															<TD align="left" height="30">&nbsp;
																<asp:Button id="btnDel1" runat="server" Text="删除昨天及以前" OnClick="btnDel1_Click"></asp:Button>
																<asp:Button id="btnDel2" runat="server" Text="删除上月及以前" OnClick="btnDel2_Click"></asp:Button>
																<asp:Button id="btn3" runat="server" Text="删除去年及以前" OnClick="btn3_Click"></asp:Button>
																<asp:Button id="btnDel4" runat="server" Text="全部删除" OnClick="btnDel4_Click"></asp:Button>
															</TD>
															<TD style="WIDTH: 10px" align="right" width="10"><FONT face="宋体"></FONT></TD>
															<TD align="center" style="width: 65px"><FONT face="宋体"><a href="Weather_Add.aspx">添 加</a></FONT></TD>
															<td width="10"><FONT face="宋体"></FONT></td>
														</TR>
													</TABLE>
													<asp:datagrid id="dg_Weather" runat="server" PageSize="15" AllowPaging="True" CellSpacing="1"
														BorderWidth="0px" BackColor="White" AutoGenerateColumns="False" Width="772px" OnPageIndexChanged="dg_Weather_PageIndexChanged">
														<AlternatingItemStyle BackColor="#F3F8FC"></AlternatingItemStyle>
														<ItemStyle HorizontalAlign="Center" BackColor="#EEF7FF"></ItemStyle>
														<HeaderStyle Font-Bold="True" HorizontalAlign="Center" Height="25px" ForeColor="Black" BackColor="#E7EFF8"></HeaderStyle>
														<FooterStyle HorizontalAlign="Left" BackColor="#E7EFF8"></FooterStyle>
														<Columns>
															<asp:BoundColumn DataField="Place" HeaderText="城市"></asp:BoundColumn>
															<asp:BoundColumn DataField="WeatherType" HeaderText="天气1" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
															<asp:BoundColumn DataField="LowTemperature" HeaderText="最低温1"></asp:BoundColumn>
															<asp:BoundColumn DataField="HighTemperature" HeaderText="最高温1"></asp:BoundColumn>
															<asp:BoundColumn DataField="Windy" HeaderText="风力1"></asp:BoundColumn>
															<asp:BoundColumn DataField="TomWeatherType" HeaderText="天气2"></asp:BoundColumn>
															<asp:BoundColumn DataField="TomLowTemperature" HeaderText="最低温2"></asp:BoundColumn>
															<asp:BoundColumn DataField="TomHighTemperature" HeaderText="最高温2"></asp:BoundColumn>
															<asp:BoundColumn DataField="TomWindy" HeaderText="风力2"></asp:BoundColumn>
															<asp:BoundColumn DataField="ThirdWeatherType" HeaderText="天气3"></asp:BoundColumn>
															<asp:BoundColumn DataField="ThirdLowTemperature" HeaderText="最低温3"></asp:BoundColumn>
															<asp:BoundColumn DataField="ThirdHighTemperature" HeaderText="最高温3"></asp:BoundColumn>
															<asp:BoundColumn DataField="ThirdWindy" HeaderText="风力3"></asp:BoundColumn>
															<asp:BoundColumn DataField="dtFillTime" HeaderText="日期" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
															<asp:TemplateColumn HeaderText="Operate">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Height="25px"></ItemStyle>
																<HeaderTemplate>
																	<FONT face="宋体">Operate</FONT>
																</HeaderTemplate>
																<ItemTemplate>
																	<FONT face="宋体">
																		<asp:HyperLink id=Hyperlink2 runat="server" ImageUrl="../Images/ny/edit.gif" NavigateUrl='<%# "Weather_Add.aspx?ID=" + DataBinder.Eval(Container.DataItem,"ID") %>' Text="修改"></asp:HyperLink>
																		<asp:HyperLink id=Hyperlink1 runat="server" ImageUrl="../Images/ny/del.gif" NavigateUrl='<%# "javascript:if(window.confirm(\"确定删除吗？\")) window.location.replace(\"Weather_Del.aspx?ID=" + DataBinder.Eval(Container.DataItem,"ID") + "\")" %>' Text="删除"></asp:HyperLink>
																	</FONT>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
														<PagerStyle NextPageText="下一页" Height="25px" PrevPageText="上一页" HorizontalAlign="Right" BackColor="#EEF7FF"></PagerStyle>
													</asp:datagrid></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</td>
					</tr>
				</table>
    </div>
    </form>
</body>
</html>
