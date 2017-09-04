<%@ page language="C#" autoeventwireup="true" inherits="jubao_center, App_Web_txwcgdum" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>农村集体经济组织清产核资管理系统</title>
<style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 1px;
	margin-right: 0px;
	margin-bottom: 0px;
	background-color: #FFFFFF;
}
html { overflow-x: ; overflow-y: ; border:0;} 
    #shleft
    {
        height: 701px;
    }
-->
</style>
<script type="text/javascript" src="../Scripts/jquery-1.4.1-vsdoc.js"></script>
<script>

    function shleft() {
        if (parent.cen.cols == "0,10,*") {
            parent.cen.cols = "216,10,*"
            document.getElementById("shleft").src = 'images/1_06.jpg';
        }
        else {
            parent.cen.cols = "0,10,*"
            document.getElementById("shleft").src = 'images/1_07.jpg';

        }
    }

</script>
<script language="javascript">
//    g_blnCheckUnload = true;
//    function RunOnBeforeUnload() {
//        if (g_blnCheckUnload) {
//            window.event.returnValue = '你确定已经保存信息并要关闭系统吗？';
//        }
//    }
</script>
</head>

<body>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td bgcolor="#e6f5ff"></td>
  </tr>
  <tr>
    <td><table width="768" height="700px" border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td valign="top"><img   id="shleft" src="images/1_06.jpg"  onclick="shleft();"  /></td>
      </tr>
    </table></td>
  </tr>
</table>
</body>
</html>
