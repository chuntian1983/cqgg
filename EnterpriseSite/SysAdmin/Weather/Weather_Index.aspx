<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Weather_Index.aspx.cs" Inherits="SysAdmin_Weather_Weather_Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <script type="text/javascript" language="javascript">
		<!--
		function OpeninFrame(FrameName,Url)
		{
		document.frames[FrameName].location.href=Url;
		}
		
		function MenuControl(menu){
			var obj = eval("document.all." + menu);
			if(obj.style.display == "none"){
				obj.style.display = "block";
			}
			else{
				obj.style.display = "none";
			}
		}
		-->
		</script>

    <link href="../../SysAdmin/Css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
			
					<tr>
						<td height="30">
							<table cellspacing="0" cellpadding="0" width="100%" border="0">
								<tr>
									<td bgcolor="#333333" height="1"></td>
								</tr>
								<tr>
									<td bgcolor="#ffffff" height="2">&nbsp;</td>
								</tr>
								<tr>
									<td bgcolor="#ffffff" height="2"></td>
								</tr>
								<tr>
									<td bgcolor="#dfdfdf">
										<table cellspacing="0" cellpadding="0" width="100%" border="0">
											<tr>
												<td>&nbsp;</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td bgcolor="#ffffff">
										<table cellspacing="0" cellpadding="0" width="100%" border="0">
											<tr>
												<td align="right">
													<table  cellspacing="0" cellpadding="0" width="100%" border="0">
														<tr bgcolor="#6694bd">
															<td>&nbsp;</td>
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
					<tr>
						<td valign="top" style="height: 257px">
							<table  cellspacing="0" cellpadding="0" width="100%" border="0">
					
									<tr>
										<td id="DyLeft" valign="top" align="center" style="width: 182px; height: 242px;"><table  cellspacing="0" cellpadding="0" width="100%" border="0">
												<tr>
													<td height="10"></td>
												</tr>
												<tr>
													<td valign="top" width="200">
														<table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
															<tr>
																<td bgcolor="#6694bd" colspan="3" height="1"></td>
															</tr>
															<tr bgcolor="#eeeeee">
																<td width="5%"></td>
																<td class="LineHeight1" style="CURSOR: hand" onclick='MenuControl("menu1");' width="95%"
																	height="24">杭州思达天气预报</td>
																<td></td>
															</tr>
															<tr id="menu1" style="DISPLAY: block">
																<td></td>
																<td class="LineHeight1">
																	<table cellspacing="0" cellpadding="0" width="100%" align="right" border="0"  >
																		<tr >
																			<td  height="1"></td>
																		</tr>
																		<tr>
																			<td class="LineHeight1" height="24"><img alt="" height="5" src="../Images/arrow.gif" width="5"/><a class="LineHeight1" href="Weather_List.aspx" target="mainFrame">
																					&nbsp;天气预报列表</a></td>
																		</tr>
																		<tr>
																			<td  height="1"><font face="宋体"></font></td>
																		</tr>
																		<tr>
																			<td class="LineHeight1" height="24"><img alt="" height="5" src="../Images/arrow.gif" width="5"/><a class="LineHeight1" href="Weather_Add.aspx" target="mainFrame">&nbsp; 
																					添加天气预报</a></td>
																		</tr>
																		<tr>
																			<td  height="1"><font face="宋体"></font></td>
																		</tr>
																		<tr>
																			<td class="LineHeight1" height="24"><img  alt="" height="5" src="../Images/arrow.gif" width="5"/><a class="LineHeight1" href="Weather_Get.aspx" target="mainFrame">&nbsp; 
																					获取天气预报</a></td>
																		</tr>
																		<tr>
																			<td style="height: 1px"><font face="宋体"></font></td>
																		</tr>
																		<tr>
																			<td class="LineHeight1" height="24"><img alt="" height="5" src="../Images/arrow.gif" width="5"/><a class="LineHeight1" href="../City/City_List.aspx" target="mainFrame">&nbsp; 
																					城市管理</a></td>
																		</tr>
																		<tr>
																			<td  height="1"><font face="宋体"></font></td>
																		</tr>
																		<tr>
																			<td class="LineHeight1" height="24"></td>
																		</tr>
																	</table>
																</td>
																<td><font face="宋体"></font></td>
															</tr>
														</table>
													</td>
												</tr>
												<tr>
													<td align="center"></td>
												</tr>
											</table>
										</td>
										
										
											
										<td align="center" style="height: 242px">
                                            <iframe frameborder="0" name="mainFrame" src="" style="visibility: inherit; width: 100%;
                                                height: 304%"></iframe>
                                            &nbsp;</td>
									</tr>
								
							</table>
						</td>
					</tr>
				
			</table>
    </div>
    </form>
</body>
</html>
