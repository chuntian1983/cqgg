<%@ page language="C#" autoeventwireup="true" inherits="SysAdmin_Article_AddOrEditArticle, App_Web_dkmranqb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../Css/css.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../JS/calendar.js"></script>

    <script type="text/jscript" src="../js/prototype.js"></script>

    <script>
      function openWinDialog(url,arg)
      {
        return window.showModalDialog(url,arg, 'edge:raised;scroll:0;status:0;help:0;resizable:1;dialogWidth:800px;dialogHeight:600px;');
      }
      
      function selectPic(showReturnObj)
      {
            openWinDialog('../picture/selectpicture.aspx?rdn='+Math.random(),$(showReturnObj));
      }   
    </script>

    <base target="_self" />
</head>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="80%" align="center" border="0">
				<tr>
					<td align="center" colSpan="2" height="8"></td>
				</tr>
				<tr>
					<td align="left" width="5%">&nbsp;<IMG height="23" src="../Images/dig.gif" width="23"></td>
					<td align="left"><font color="#0a7ec5"><b><%=_pageTitle %></b></font></td>
				</tr>
			</table>
			<table cellSpacing="1" cellPadding="0" width="80%" align="center" bgColor="#d1e3fe" border="0">
				<tr bgColor="#f6f9ff">
					<td align="right" height="22"><font color="#ff6531">新闻标题：</font></td>
					<td><asp:textbox id="txtTitle" runat="server" Width="432px"></asp:textbox><FONT color="red">*</FONT></td>
				</tr>
				<tr bgColor="#f6f9ff">
					<td align="right" style="height: 23px"><font color="#ff6531">作 者：</font></td>
					<td style="height: 23px"><asp:textbox id="txtUnit" runat="server" Width="432px"></asp:textbox><FONT color="red">*</FONT></td>
				</tr>
				<tr bgColor="#f6f9ff">
					<td align="right" height="22"><font color="#ff6531">发布时间：</font></td>
					<td><asp:textbox id="txtReleaseDate" runat="server" Width="432px" onFocus="this.blur()"></asp:textbox>&nbsp;<img  onclick="meizz_calendar(document.getElementById('txtReleaseDate'))"
                                                               style="cursor:pointer;" src="../images/calendar.gif" /></td>
				</tr>
				<asp:panel ID="aa" Visible=false runat=server>
				<tr bgColor="#f6f9ff">
					<td align="right" height="22"><font color="#ff6531">过期时间：</font></td>
					<td><asp:textbox id="txtExpireDate" runat="server" Width="432px" onFocus="this.blur()"></asp:textbox>&nbsp;<img  onclick="meizz_calendar(document.getElementById('txtExpireDate'))"
                                                               style="cursor:pointer;" src="../images/calendar.gif" /></td>
				</tr></asp:panel>
                <tr bgcolor="#f6f9ff">
                    <td align="right" height="22">
                        <span style="color: #ff6531">信息类别：</span></td>
                    <td>
                        <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                </tr>
				<TR bgColor="#f6f9ff">
					<TD align="right" height="22"><FONT color="#ff6531">新闻内容：</FONT></TD>
					<TD>
                                        <textarea id="fckBody" runat="server"></textarea><FONT color="red">注：请尽量不要从Word中复制内容，以免发生不兼容的情况</FONT></TD>
				</TR>
				<tr bgColor="#f6f9ff">
					<td align="center" colSpan="2" style="height: 25px">
						<asp:button id="btnSubmit" runat="server" Width="80px" CssClass="input" Text="确定" OnClick="btnSubmit_Click"></asp:button>&nbsp;
						<span id="spanBack" runat="server" visible="false"><input type="button" value="返回" onclick="history.go(-1);" class="input" /></span>
						
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
