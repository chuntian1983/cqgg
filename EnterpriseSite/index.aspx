<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

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
<div class="main">
    <div class="notice">
    	<a  href="content.aspx?p=<%=toutiaoid %>" target="_blank"><h1><%=toutiaot %></h1></a> 
    	<p><%=toutiaonr %>
       </p>
    </div>
    <div class="hotnews spacing clearfix">
    	<div class="article">
    	    <div class="article_pic">
    	    	<%=strtupian %>
    	    </div>
    	    <div class="article_bot clearfix">
    	        <div class="article_word">
    	        	<%=strtupianzi %>
    	        </div>
    	    	<div class="article_nav">
    	    		<!-- <b></b>
    	    		<b></b>
    	    		<b></b>
    	    		<b></b> -->
    	    	</div>
    	    </div>
    		
    	</div>
		<div class="adide newsbg">
		<a href="list.aspx?lb=261" target="_blank"><span class="span">工作动态</span></a>	
			<h1><%=gzdtBiaoti %></h1>
			<p><%=gzdtMiaoshu %></p>
			<b>[ <a href='content.aspx?p=<%=gzdtId %>'>详细信息</a> ]</b>
			<ul class="spacing">
				<%=gzdtList %>
				
			</ul>
		</div>
    </div>
    <div class="banner spacing">
    	<img src="html/images/banner.jpg">
    </div>
    <!-- 新闻 -->
    <div class="newslist spacing clearfix">
    	<div class="newsbg newslist_index">
    		<a href="list.aspx?lb=275" target="_blank"><span class="span span_zcfg">政策法规</span></a>
			<h1><%=zcfgBiaoti %></h1>
			<p><%=zcfgMiaoshu %></p>
			<b>[ <a href='content.aspx?p=<%=zcfgId %>'>详细信息</a> ]</b>
			<ul class="spacing">
				<%=zcfgList %>
			</ul>
    	</div>
    	<div class="newsbg newslist_index">
    		<a href="list.aspx?lb=260" target="_blank"><span class="span span_hnzc">惠农政策</span></a>
			<h1><%=hnzcBiaoti %></h1>
			<p><%=hnzcMiaoshu %></p>
			<b>[ <a href='content.aspx?p=<%=hnzcId %>'>详细信息</a> ]</b>
			<ul class="spacing">
				<%=hnzcList %>
			</ul>
    	</div>
    	<div class="newsbg newslist_index">
    		<a href="list.aspx?lb=262" target="_blank"><span class="span span_jyjl">经验交流</span></a>
			<h1><%=jyjlBiaoti %></h1>
			<p><%=jyjlMiaoshu %></p>
			<b>[ <a href='content.aspx?p=<%=jyjlId %>'>详细信息</a> ]</b>
			<ul class="spacing">
				<%=jyjlList %>
			</ul>
    	</div>
    </div>
	<!-- 友情链接 -->
	<div class="link spacing">
		<a href="http://www.tangyin.gov.cn/" target="_blank"><img src="html/images/ty.jpg"></a>
		<a href="http://www.anyang.gov.cn/" target="_blank"><img src="html/images/ay.jpg"></a>
		<a href="http://www.hqqagri.gov.cn/" target="_blank"><img src="html/images/nyj.jpg"></a>
		<a href="http://www.henan.gov.cn/" target="_blank"><img src="html/images/hn.jpg"></a>
		<a href="http://www.moa.gov.cn/" target="_blank"><img src="html/images/nyb.jpg"></a>
	</div>
</div>
<!-- 底部 -->
<div class="footer">
	<div class="footer_left"><img src="html/images/red.png"></div>
	<div class="footer_center">
		汤阴县农业局版权所有</br> 
汤阴县农业局管理维护  豫ICP备14014946号  </br> 
  电话：(0372)2550645  2550642 电子邮箱：ayxxgk@163.com   </br> 
技术支持: 山东农友软件有限公司 </br>   
建议使用IE8以上浏览器

	</div>
	<div class="footer_left"><img src="html/images/jiucuo.png"></div>
	
</div>

<!-- 微信 -->
<div class="weixin">
	<ul>
		<li><img src="html/images/ewm.jpg"></li>
		<li><img src="html/images/ewm.jpg"></li>
		<li><img src="html/images/backtop.png"></li>
	</ul>
</div>
</body>
</html>


<script src='html/js/jquery.js'></script>
