<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="jubao_login" %>
<%@ Register assembly="ValidateCode" namespace="Mic" tagprefix="acoo" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>山东明镜农廉网预警监控系统</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<style type="text/css">td img {display: block;}</style>
<!--Fireworks 8 Dreamweaver 8 target.  Created Fri Aug 17 15:08:35 GMT+0800 2012-->
</head>
<body bgcolor="#ffffff">
    <form id="form1" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="1024">
<!-- fwtable fwsrc="未命名" fwbase="login1.jpg" fwstyle="Dreamweaver" fwdocid = "1980458945" fwnested="0" -->
  <tr>
   <td><img src="images/spacer.gif" width="574" height="1" border="0" alt="" /></td>
   <td><img src="images/spacer.gif" width="6" height="1" border="0" alt="" /></td>
   <td><img src="images/spacer.gif" width="105" height="1" border="0" alt="" /></td>
   <td><img src="images/spacer.gif" width="37" height="1" border="0" alt="" /></td>
   <td><img src="images/spacer.gif" width="302" height="1" border="0" alt="" /></td>
   <td><img src="images/spacer.gif" width="1" height="1" border="0" alt="" /></td>
  </tr>

  <tr>
   <td colspan="5"><img name="login1_r1_c1" src="images/login1_r1_c1.jpg" width="1024" height="396" border="0" id="login1_r1_c1" alt="" /></td>
   <td><img src="images/spacer.gif" width="1" height="396" border="0" alt="" /></td>
  </tr>
  <tr>
   <td rowspan="7" background="" ><img name="login1_r2_c1" src="images/login1_r2_c1.jpg" width="574" height="372" border="0" id="login1_r2_c1" alt="" /></td>
   <td colspan="3" style=" background-image:url('images/login1_r2_c2.jpg')">
       <asp:TextBox ID="txtName" runat="server" Width="99%" MaxLength="40"></asp:TextBox>
      </td>
   <td rowspan="7"><img name="login1_r2_c5" src="images/login1_r2_c5.jpg" width="302" height="372" border="0" id="login1_r2_c5" alt="" /></td>
   <td><img src="images/spacer.gif" width="1" height="23" border="0" alt="" /></td>
  </tr>
  <tr>
   <td colspan="3" style=" background-image:url('images/login1_r4_c2.jpg')" 
          rowspan="2">
       <asp:TextBox ID="txtPassword" runat="server" Width="96%" MaxLength="40" 
           TextMode="Password"></asp:TextBox>
      </td>
   <td><img src="images/spacer.gif" width="1" height="22" border="0" alt="" /></td>
  </tr>
  <tr>
   <td><img src="images/spacer.gif" width="1" height="12" border="0" alt="" /></td>
  </tr>
  <tr>
   <td colspan="3" style=" background-image:url('images/login1_r6_c2.jpg')">
   <table>
   <tr>
   <td>
       <input id="Text1" type="text" runat="server" style=" width:50px;" 
           maxlength="10" />
   </td>
   <td><acoo:imgcontrol id="Validnum" runat="server"></acoo:imgcontrol></td>
   </tr>
   </table>
   </td>
   <td><img src="images/spacer.gif" width="1" height="19" border="0" alt="" /></td>
  </tr>
  <tr>
   <td colspan="3"><img name="login1_r7_c2" src="images/login1_r7_c2.jpg" width="148" height="31" border="0" id="login1_r7_c2" alt="" /></td>
   <td><img src="images/spacer.gif" width="1" height="31" border="0" alt="" /></td>
  </tr>
  <tr>
   <td rowspan="2"><img name="login1_r8_c2" src="images/login1_r8_c2.jpg" width="6" height="252" border="0" id="login1_r8_c2" alt="" /></td>
   <td>
       <asp:ImageButton ID="ImageButton1" runat="server" 
           ImageUrl="images/login1_r8_c3.jpg" onclick="ImageButton1_Click" /></td>
   <td rowspan="2"><img name="login1_r8_c4" src="images/login1_r8_c4.jpg" width="37" height="252" border="0" id="login1_r8_c4" alt="" /></td>
   <td><img src="images/spacer.gif" width="1" height="35" border="0" alt="" /></td>
  </tr>
  <tr>
   <td><img name="login1_r9_c3" src="images/login1_r9_c3.jpg" width="105" height="217" border="0" id="login1_r9_c3" alt="" /></td>
   <td><img src="images/spacer.gif" width="1" height="217" border="0" alt="" /></td>
  </tr>
</table>
    </form>
</body>
</html>
