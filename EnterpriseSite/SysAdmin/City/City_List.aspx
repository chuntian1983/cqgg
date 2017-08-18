<%@ Page Language="C#" AutoEventWireup="true" CodeFile="City_List.aspx.cs" Inherits="SysAdmin_City_City_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../../SysAdmin/Css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellspacing="0" width="100%" border="0">
					<tr>
						<td width="10" height="25">&nbsp;</td>
						<td valign="bottom">位置：天气列表&nbsp;
						</td>
					</tr>
				</table>
				<table cellspacing="1" cellpadding="0" width="98%" align="center" border="0">
					<tr>
						<td class="row1">
							<table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
								<tr>
									<td valign="top">
										<table cellspacing="0" cellpadding="0" width="100%" border="0">
											<tr>
												<td align="center">
													<table cellspacing="0" cellpadding="0" width="100%" border="0">
														<tr>
															<td align="left" width="30">&nbsp;
															</td>
															<td align="left" height="30">&nbsp;
															</td>
															<td style="WIDTH: 10px" align="right" width="10"><font face="宋体"></font></td>
															<td align="center" width="65"><font face="宋体"><a href="City_Conf.aspx">添 加</a></font></td>
															<td width="10"><font face="宋体"></font></td>
														</tr>
													</table>
													<asp:datagrid id="DataGrid1" runat="server" Width="704px" AutoGenerateColumns="False" BackColor="White"
														BorderWidth="0px" CellSpacing="1" AllowPaging="True" PageSize="20" PagerStyle-Mode="NumericPages" OnItemCommand="DataGrid1_ItemCommand" OnPageIndexChanged="DataGrid1_PageIndexChanged">
														<AlternatingItemStyle BackColor="#F3F8FC"></AlternatingItemStyle>
														<ItemStyle HorizontalAlign="Center" BackColor="#EEF7FF"></ItemStyle>
														<HeaderStyle Font-Bold="True" HorizontalAlign="Center" Height="25px" ForeColor="Black" BackColor="#E7EFF8"></HeaderStyle>
														<FooterStyle HorizontalAlign="Left" BackColor="#E7EFF8"></FooterStyle>
														<Columns>
															<asp:BoundColumn DataField="CityName" HeaderText="城市名"></asp:BoundColumn>
															<asp:BoundColumn DataField="Code1" HeaderText="代码1"></asp:BoundColumn>
															<asp:BoundColumn DataField="Code2" HeaderText="代码2"></asp:BoundColumn>
															<asp:TemplateColumn HeaderText="操作">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Height="25px"></ItemStyle>
																<HeaderTemplate>
																	<font face="宋体">Operate</font>
																</HeaderTemplate>
																<ItemTemplate>
																	<FONT face="宋体">
																		<asp:HyperLink id="Hyperlink2" runat="server" ImageUrl="../Images/ny/edit.gif" NavigateUrl='<%# "City_Conf.aspx?CityID=" + DataBinder.Eval(Container.DataItem,"CityID") %>' Text="修改"></asp:HyperLink>
																		<asp:ImageButton ID="imgbDel" runat="server" ImageUrl="../Images/ny/del.gif" CommandName="del" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CityID")%>' AlternateText="删除">
																		</asp:ImageButton>
																	</FONT>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
														<PagerStyle NextPageText="下一页" Height="25px" PrevPageText="上一页" HorizontalAlign="Right" BackColor="#EEF7FF" Mode="NumericPages"></PagerStyle>
													</asp:datagrid>
												</td>
											</tr>
											<tr>
												<td>
													注：<br>
													代码1指向网站：<a href="http://www.weathercn.com">http://www.weathercn.com</a><br>
													代码2指向网站：暂无
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
