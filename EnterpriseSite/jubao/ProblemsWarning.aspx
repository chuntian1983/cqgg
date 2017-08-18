<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProblemsWarning.aspx.cs" Inherits="jubao_ProblemsWarning" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" /> 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    body{ background-color:#e6f2ff;}
　　.table_title {
	font-weight: bold;
	color: #FFFF00;
	letter-spacing: 5px;
    }　
    .ListCellRow
    {
	    FONT-FAMILY: Arial, Helvetica, sans-serif;
	    FONT-SIZE: 9pt;
	    BACKGROUND: #4F7DD5;
	    BORDER-BOTTOM: 2px groove #000000;
	    LINE-HEIGHT: 200%;
	    color: #FFFFFF;
	    filter: Shadow(Color=#000000, Direction=);
	    border-right-width: 2px;
	    border-right-style: groove;
	    border-right-color: #000000;
    }
    .ListCellRow2
    {
	    FONT-FAMILY: Arial, Helvetica, sans-serif;
	    FONT-SIZE: 9pt;
	    BACKGROUND: #FFFFFF;
	    LINE-HEIGHT: 200%;
	    color: #000000;
	    border: 1px outset #CCCCCC;
	    text-align:center;
	    cursor:hand;
    }
    </style>
    <script language="javascript" type="text/javascript" src="./My97DatePicker/WdatePicker.js" defer="true"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="">
        <div class="table_title"  style=" background-image:url(./images/system1.gif); text-align:center;" >山东省举报预警系统</div>
         <div  style=" margin-top:5px;"> <span style="color:Red;">开始时间：</span> <asp:TextBox runat="server" ID="FromTime" onclick="WdatePicker()" class="Wdate"></asp:TextBox> &nbsp; &nbsp; &nbsp; <span style="color:Red;">结束时间：</span> <asp:TextBox runat="server" ID="EndTime" onclick="WdatePicker()" class="Wdate"></asp:TextBox>&nbsp;
                <asp:Button  runat="server" Text="搜索" CssClass="style3" Width="78px" 
                 onclick="Unnamed1_Click" />  
             <br />
             <span style=" font-size:12px; color:Red;">
             备注：绿灯：全部举报已处理；黄灯：1-3次举报未处理；红灯：3次以上举报未处理。</span></div>
            <div id="switcher" style="background-color:#fff;">
                <table width="100%" runat="server"  id = "UnitList"  style="border 1px solid #DDF4FF; margin-top:5px;"  cellpadding="2" cellspacing="2">
                </table>
            </div>
            <div style="background-color:#fff;">
                <table width="100%" runat="server"  id = "QuestionList"  border=1 cellPadding=0 cellSpacing=0 borderColorLight=#c0c0c0 borderColorDark=#ffffff bgcolor="#FFFFFF">
                </table>
            </div>
       </div>
    </div>
    <asp:HiddenField runat="server"  ID="HPid"  />
    </form>
</body>
</html>
