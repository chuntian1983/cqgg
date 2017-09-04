<%@ page language="C#" autoeventwireup="true" inherits="SysAdmin_Search_Search, App_Web_xoiximou" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>MemberShow</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Css/css.css" type="text/css" rel="stylesheet">
		<style type="text/css">.break { WORD-BREAK: break-all }
	.STYLE1 { COLOR: #ff6531 }
		</style>
		<script type="text/javascript" src="../js/prototype.js"></script>
		<script>
		var urls={product:'ProductSearchResult.aspx',member:'MemberSearchResult.aspx',news:'NewsSearchResult.aspx'};
		var submitUrl=urls.member;
		function select(obj)
		{
		    submitUrl=urls[obj.id];
		    $A( $(obj).siblings()).each(function(node){
                $(node).setStyle({color:'#004194',fontWeight:'normal'});});
		    $(obj).setStyle({color:'#FF7F00',fontWeight:'bold'});
		}
		function search()
		{
		    if(check())
		    {
		        var form=$('siteSearch');
		        form.action=submitUrl;
		        form.submit();
		    }
		}
		function check()
		{
		    if($('title').value.length>20) 
		    {
		        alert('搜索字符串长度不能超过20个字符!');
		        return false;
		    }
		    return true;
		}
		</script>
	</HEAD>
	<body >
		<form id="siteSearch" method="post"  >
			<table cellSpacing="0" cellPadding="0" width="80%" align="center" border="0">
				<tr>
					<td align="center" colSpan="2" height="8"><FONT face="宋体"></FONT></td>
				</tr>
				<tr>
					<td align="left" width="5%">&nbsp;<IMG height="23" src="../Images/dig.gif" width="23">
					</td>
					<td align="left"><font color="#0a7ec5"><b>站内搜索</b></font></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="80%" align="center" bgColor="#d1e3fe" border="0">
			<tr><td>&nbsp;<a href="javascript:void(0);" id="member" onclick="select(this);">会员</a> | <a href="javascript:void(0);" id="product" onclick="select(this);">产品</a> | <a href="javascript:void(0);" id="news" onclick="select(this);">新闻</a></td></tr>
			<script>$('member').setStyle({color:'#FF7F00',fontWeight:'bold'});</script>
				<tr><td height="4px"></td></tr>
				<tr>
					<td vAlign="top" width="100%">
						&nbsp;search:<input type="text" id="title" name="title" /> <input type="button" value="搜索" onclick="search();" />
					</td>
				</tr>
				<tr><td height="3px"></td></tr>
			</table>
		</form>
	</body>
</HTML>

