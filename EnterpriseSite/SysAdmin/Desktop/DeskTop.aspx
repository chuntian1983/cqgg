<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeskTop.aspx.cs" Inherits="SysAdmin_Desktop_DeskTop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<title>网站自助管理平台</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="../css/css.css" rel="stylesheet" type="text/css">
		  <script type="text/javascript" src="../js/prototype.js"></script>
   <script type="text/javascript">
		var showMenu=true;
		function toggle()
		{
		    if(showMenu)
		    {
		        showMenu=false;
		        $('SubMenu').setStyle({display:'none'});
		        $('rightMain').setStyle({width:'99%'});
		        $('imgToggle').src='../Images/1_07.jpg';
		    }else
		    {
		        showMenu=true;
		        $('SubMenu').setStyle({display:''});
		        $('leftFrame').setStyle({width:'140px',height:'492px'});
		        $('rightMain').setStyle({width:'88%'});
		        $('imgToggle').src='../Images/1_06.jpg';
		    }
		}
		function closeMenu()
		{
		    showMenu=true;
		    toggle();
		}
		function openMenu()
		{
		    showMenu=false;
		    toggle();
		}
		</script>
		
	</HEAD>
	<body scroll="no">
		<form id="form1" runat="server">
			<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td height="33" valign="top">
						<table width="100%" border="0" background="../images/top/top_bg_3.gif">
							<tr>
								<td width="255" height="30" align="center"><img src="../Images/Top/logo.jpg" width="243" height="30"></td>
								<td width="187">&nbsp;</td>
								<td width="577">&nbsp;</td>
							</tr>
						</table>
						<table width="100%" height="5" border="0" cellpadding="0" cellspacing="0" bgcolor="#4180c6">
							<tr>
								<td></td>
							</tr>
						</table>
						<table width="100%" height="33" border="0" cellpadding="0" cellspacing="0" background="../Images/top/bg_2.gif"
							class="font12">
							<tr>
								<td width="20" align="center">&nbsp;</td>
								<td align="left"><strong>当前用户</strong>: [<font color="#ff6633"><%=_nickname %></font>]</td>
								<td align="center">
									<table width="100%" height="33" border="0" cellpadding="0" cellspacing="0" class="font12">
										<tr width="100%">
											<td align="right"><a href="Desktop.aspx">返回首页&nbsp;&nbsp;</a></td>
											<%=_topMenu%>
											<td width="1" valign="top"><img src="../images/top/xian.gif" width="1" height="24"></td>
											<td width="70">&nbsp;&nbsp;<asp:LinkButton ID="lnkbtnLogout" runat="server" OnClick="lnkbtnLogout_Click">退出系统</asp:LinkButton></td>
											<td width="40"></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%">
							<tr>
								<td width="144" height="520" align="center">
									<iframe   id="leftFrame" name="leftFrame" marginWidth="0"  src="SubMenu.aspx?MenuId=<%=meid %>"
										frameBorder="0" noResize style="Z-INDEX: 2;  WIDTH: 144px; HEIGHT: 100%"
										scrolling="no"></iframe>
								</td>
								<td width="88%" align="center"><iframe style="Z-INDEX: 2;WIDTH: 100%; HEIGHT: 520px;overflow-x:hidden"   id="mainFrame" name="mainFrame"
										src="default.aspx" frameborder="0" noresize ></iframe>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td height="30" valign="top">
						<table width="100%" height="30" border="0" cellpadding="0" cellspacing="0" background="../images/top/bg_3.gif">
							<tr>
								<td height="30">
									<table width="100%" border="0" cellpadding="0" cellspacing="0">
										<tr>
											<td width="40%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 版权所有：农友软件
											</td>
											<td width="30%"></td>
											<td width="30%">技术支持：<A href="http://www.nongyou.com.cn" target="_blank">农友软件</A></td>
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
</HTML>
