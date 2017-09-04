<%@ page language="C#" autoeventwireup="true" inherits="jubao_jbmaintop, App_Web_txwcgdum" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

    
<frameset rows="126,*" cols="*" frameborder="no" border="0" framespacing="0">
  <frame src="top.aspx" name="topFrame" scrolling="No" noresize="noresize" id="topFrame" title="topFrame" />
  <frameset cols="216,10,*" frameborder="no" border="0" framespacing="0" name="cen">
   <frame src="left.aspx?state=1&pid=<%=pid %>"  name="leftFrame" scrolling="No"   noresize="noresize" id="leftFrame"   title="leftFrame" />
   <frame src="center.aspx"  name="centerFrame" scrolling="No" noresize="noresize" id="centerFrame"   title="centerFrame" ></frame>
    <frame src="StatisticalAnalysisChart.aspx?pid=<%=pid %>" name="mainFrame" id="mainFrame" title="mainFrame" />
  </frameset>
</frameset>
<noframes>
</noframes>

</html>
