<%@ Page Language="C#" AutoEventWireup="true" CodeFile="left.aspx.cs" Inherits="jubao_left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <img src="images/jbmain_r2_c1.jpg" alt="" name="jbmain_r2_c1" width="216" height="607" border="0" usemap="#jbmain_r2_c1Map" id="jbmain_r2_c1" />
    <map name="jbmain_r2_c1Map" id="jbmain_r2_c1Map"><area shape="rect" 
        coords="7, 35, 207, 66" href="#1" />
<area shape="rect" coords="8, 70, 203, 102" href="StatisticalAnalysisChart.aspx?pid=<%=pid %>" target="mainFrame" />
<area shape="rect" coords="8, 108, 202, 139" href="ProblemsWarning.aspx?pid=<%=pid %>" target="mainFrame" />
<area shape="rect" coords="4, 146, 202, 176" href="jbmanage.aspx?pid=<%=pid %>"  
        target="mainFrame" /></map>
    </div>
    </form>
</body>
</html>
