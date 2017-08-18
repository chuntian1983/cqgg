<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="taishan1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML 
xmlns="http://www.w3.org/1999/xhtml"><HEAD><META content="IE=11.0000" 
http-equiv="X-UA-Compatible">
<TITLE>广西农村产权制度改革公开平台 </TITLE> 
<META http-equiv="Content-Type" content="text/html; charset=utf-8">
<STYLE type="text/css">
.shititle{background:#d4ecfc;border:1px solid #d4ecfc;height:25px;font-size:15px;font-weight:bold}
.shititle img{margin-right:5px;margin-left:5px}
.xianlist{border:1px solid #d4ecfc}
.xianlist li{float:left;text-align:center;vertical-align:middle;width:130px;height:34px; line-height:34px;margin-right:20px;margin-top:8px;background:url(images/danweibg2.jpg)}
.xianlist a{font-size:13px}
.shititle a{font-size:15px;font-weight:bold}
</STYLE>
 
<META name="GENERATOR" content="MSHTML 11.00.9600.18739"></HEAD> 
<BODY style="margin: 0px; text-align: center; font-size: 13px;">
<FORM name="form1" id="form1" action="sanzigk.aspx" method="post">
<DIV><INPUT name="__VIEWSTATE" id="__VIEWSTATE" type="hidden" value="/wEPDwUJOTU4MjMyMzI1ZGQ="> 
</DIV>
<DIV style=" width:1004px; margin:0 auto;">
<TABLE border="0" cellspacing="0" cellpadding="0">
  <TBODY>
  <TR>
    <TD style='width: 1003px; height: 122px; text-align: right; vertical-align: top; background-image: url("images/szgk.jpg");'>
      			&nbsp;</TD></TR>
  <TR>
    <TD style='width: 1003px; height: 12px; background-image: url("images/neiye01.jpg");'></TD></TR>
  <TR>
    <TD style='width: 1003px; height: 460px; text-align: left; vertical-align: top; background-image: url("images/neiye02.jpg");'>
      <TABLE style="width: 95%; margin-left: 20px;" border="0" cellspacing="0" 
      cellpadding="0">
        <TBODY>
        <asp:Repeater runat="server"  ID="rep1" onitemdatabound="rep1_ItemDataBound">
        <ItemTemplate>
        <TR>
          <TD class="shititle"><IMG src="images/21.gif"><%#Eval("title") %></TD></TR>
        <TR>
        <TR>
          <TD class="xianlist">
            <UL>
            <asp:Repeater runat="server" ID="rep2">
            <ItemTemplate>
            <LI><A href='<%#Eval("deptimg") %>'
              target="_blank"><%#Eval("title") %></A></LI>
            </ItemTemplate>
            </asp:Repeater>
              </UL><BR><BR></TD></TR>
        </ItemTemplate>
        </asp:Repeater>
      
  <TR>
    <TD style='width: 1003px; height: 15px; background-image: url("images/neiye03.jpg");'></TD></TR></TBODY></TABLE></DIV></FORM></BODY></HTML>
