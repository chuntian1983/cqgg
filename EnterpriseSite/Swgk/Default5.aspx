<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default5.aspx.cs" Inherits="Swgk_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />


    <title>三务公开平台</title>
    <style type="text/css">




        body{ PADDING-RIGHT: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-TOP: 0px; TEXT-ALIGN: center; vertical-align:middle;
}
        #main{ text-align:center;margin-left:auto; margin-right: auto;margin:0 auto;
}
        #zhuti
        {
            background-image:url(../images/sanwubj.jpg);
            width:1024px;
            height:768px;
            text-align:center;
            }
        #pmfwdt
        {
		text-align:center;
            background-image:url('../images/anniulan.png');
            position: absolute;
            top: 325px;
            left: 555px;
            width: 275px;
            height: 98px;
        }
        #spjk
        {
            background-image:url('../images/anniulan.png');
            position: absolute; top: 427px; left: 555px;
            
            width: 275px;
            height: 98px;
        }
        #myd
        {
          background-image:url('../images/anniulan.png');
            
            
            width: 275px;
            height: 98px;
            top: 528px;
            left: 555px;
        }
        #neirong
        {
            position:relative;
             top: -5px; 
left: 10; 
width: 120px; height: 29px; margin-top: 36px;
              font-weight:bold; font-size:18px;
            }
        #neirong2
        {
            position: relative; width: 165px;
            top: 32px;
            left: 10;
            font-weight:bold; font-size:18px;
        }
        #neirong3
        {
            position: relative;
            top: 31px;
            left: 2px;
            width: 165px;
            font-weight:bold; font-size:18px;
        }
        a{color:#FFFFFF;text-decoration:none; font-weight:bolder; font-size:20px; }
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
    <div id="zhuti">
     <div id="pmfwdt" style="position: absolute">
     <div id="neirong" >
    <a href="<%=dwurl %>" target="_blank">党务公开</a></div>
    </div>
    <div id="spjk">
     <div id="neirong2"  >
   <a href="http://www.taian.gov.cn/zwgk/" target="_blank">政务公开</a></div>
    </div>
     <div id="myd" style="position: absolute">
     <div id="neirong3"  >
   <a href="main.aspx?deptid=<%=deptid %>&st=<%=st %>" target="_blank">村务公开</a></div>
    </div>
    </div>
    </div>
    </form>
</body>
</html>
