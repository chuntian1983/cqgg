<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Swgk_Default3" %>

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
            background-repeat:no-repeat;
            background-image:url('../images/newswgk.jpg');
            width:1024px;
            height:754px;
            text-align:center;
            }
        #pmfwdt
        {
		text-align:center;
            background-image:url('../images/anniulan.png');
            
            top: 304px;
            left: 356px;
            width: 275px;
            height: 98px;
        }
        #spjk
        {
            background-image:url('../images/anniulan.png');
             top: 404px; 
left: 323px;
            
            width: 275px;
            height: 98px;
        }
        #myd
        {
          background-image:url('../images/anniulan.png');
            
            
            width: 275px;
            height: 98px;
            top: 508px;
            left: 331px;
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
        .style1
        {
            width: 100%;
            height: 755px;
        }
        .style2
        {
        }
        .style3
        {
            width: 313px;
            height: 474px;
        }
        .style4
        {
            height: 474px;
        }
        .style5
        {
            width: 379px;
        }
        .style6
        {
            width: 379px;
            height: 474px;
        }
        .style7
        {
            width: 100%;
            height: 758px;
        }
        .style8
        {
            height: 49px;
             font-weight:bold;
             font-size:x-large;
             color:White;
        }
        .style10
        {
            height: 78px;
        }
        .style12
        {
            height: 49px;
             font-weight:bold;
             font-size:x-large;
             color:White;
        }
        .style16
        {
            height: 54px;
        }
        .style17
        {
            height: 131px;
        }
        .style19
        {
            height: 51px;
        }
        .style21
        {
            height: 55px;
             font-weight:bold;
             font-size:x-large;
             color:White;
        }
        .style23
        {
            height: 24px;
        }
        .style24
        {
            height: 42px;
            font-weight: bold;
            font-size: x-large;
            color: White;
        }
        .style25
        {
            height: 69px;
        }
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
    <div   id="zhuti">
        <table class="style1">
            <tr>
                <td >
                <img src="../images/swgk66.jpg" border="0" usemap="#Map" />                </td>
               
            </tr>
   
        </table>
    </div>

    </form>

<map name="Map" id="Map"><area shape="rect" coords="399, 315, 625, 369" href="<%=dwurl %>" target=_blank />
    <area shape="rect" coords="395, 451, 623, 503" href="<%=zwgk %>" target=_blank /><area shape="rect" 
        coords="397, 577, 623, 632" href="<%=cwgk %>" target=_blank /></map></body>
</html>
