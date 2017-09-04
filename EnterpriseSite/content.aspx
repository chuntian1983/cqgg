<%@ Page Language="C#" AutoEventWireup="true" CodeFile="content.aspx.cs" Inherits="content" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
	<meta charset="utf-8">
	<title>汤阴县三资管理平台</title>
	<script src='html/js/jquery-1.11.3.js'></script>
	<link rel="stylesheet" type="text/css" href="html/css/base.css">
	<link rel="stylesheet" type="text/css" href="html/css/main.css">
</head>
<body>
<form runat="server" id="form1">
	<div class="header">
		
	</div>
	<div class="nav">
		<a href="index.aspx">网站首页</a>
		<a href="list.aspx?lb=261">工作动态</a>
		<a href="list.aspx?lb=275">政策法规</a>
		<a href="list.aspx?lb=260">惠农政策</a>
		<a href="list.aspx?lb=262">经验交流</a>
		<a href="<%=szjg %>" target="_blank">三资管理</a>
		<a href="<%=szcx %>" target="_blank">三资公开</a>
	</div>

<!-- 列表开始 -->
	<div class="main">
		<div class="list">
			<p><a href="index.aspx"> 网站首页</a> -> 工作动态</p>
			<h2>
                <%=strtou %></h2>
			<h3>时间：<%=strshijian %>   来源：<%=strzuozhe %></h3>
			<div class="content">
				<img src="<%=strimg %>"></br>
				    <%=strneirong %>
			</div>
		
		</div>



		<div class="list_adide">
			<div class="newsbg">
				<span class="span span_xxjs">信息检索</span>
				<div class="spacing sreach">
					<input type="text" name="txtgjc" id="txtgjc" value='请输入关键词' runat="server" />
                    <asp:Button ID="btnsearch" runat="server" Text="检索" CssClass="button" 
                        onclick="btnsearch_Click" />
					
				</div>
		 	</div>
		 	<div class="newsbg spacing">
				<span class="span">工作动态</span>
				<ul class="spacing">
					<%=strgzdtList %>
				</ul>
		 	</div>



		</div>
		

	</div>
</form>
</body>
</html>
