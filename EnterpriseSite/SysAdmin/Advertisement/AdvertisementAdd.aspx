<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdvertisementAdd.aspx.cs" Inherits="SysAdmin_Advertisement_AdvertisementAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>广告管理</title>
    <LINK href="../Css/css.css" type="text/css" rel="stylesheet">
    <script type="text/javascript" src="../JS/calendar.js"></script>
     <script type="text/jscript" src="../js/prototype.js"></script>
      <script>
      function openWinDialog(url,arg)
      {
        return window.showModalDialog(url,arg, 'edge:raised;scroll:0;status:0;help:0;resizable:1;dialogWidth:600px;dialogHeight:300px;');
      }
      
      function selectPic(showReturnObj)
      {
            openWinDialog('../picture/selectpicture.aspx?rdn='+Math.random(),$(showReturnObj));
      }   
   
     </script>
     <base target="_self"></base>
</head>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="80%" align="center" border="0">
				<tr>
					<td align="center" colSpan="2" height="8"></td>
				</tr>
				<tr>
					<td align="left" width="5%">&nbsp;<IMG height="23" src="../Images/dig.gif" width="23"></td>
					<td align="left"><font color="#0a7ec5"><b>
                        <asp:Label ID="lbType" runat="server"></asp:Label>广告信息<asp:Label ID="lbID" runat="server" Visible="False"></asp:Label></b></font></td>
				</tr>
			</table>
			<table cellSpacing="1" cellPadding="0" width="80%" align="center" bgColor="#d1e3fe" border="0">
             
				<tr bgColor="#f6f9ff">
					<td align="right" style="height: 23px"><font color="#ff6531">名称：</font></td>
					<td style="height: 23px"><asp:textbox id="txtName" runat="server" Width="432px"></asp:textbox><FONT color="red">*</FONT></td>
				</tr>
				
                <tr bgcolor="#f6f9ff">
                    <td align="right" height="22">
                        <span style="color: #ff6531">图片：</span></td>
                    <td>
                        <asp:textbox id="txtImageLink" runat="server" Width="432px" onfocus="this.blur();"></asp:textbox><span
                            style="color: #ff0000">*</span><input id="btnUploadPic" runat="server" type="button" value="上传图片" onclick="openWinDialog('../picture/UploadPicture.aspx');" title='上传图片' />
					    <input  type="button" value="选择图片" onclick="selectPic('txtImageLink');" title='选择图片' /></td>
                </tr>
				<tr bgColor="#f6f9ff">
					<td align="right" height="22"><font color="#ff6531">链接地址：</font></td>
					<td>
                        <asp:TextBox ID="txtLink" runat="server" Width="432px"></asp:TextBox><span style="color: #ff0000">*<asp:Label
                            ID="lbFillTime" runat="server" Visible="False"></asp:Label></span></td>
				</tr>
				  
				<tr bgColor="#f6f9ff">
					<td align="right" height="22"><font color="#ff6531">排序号：</font></td>
					<td><asp:textbox id="txtSort" runat="server" Width="432px">0</asp:textbox><FONT color="red">*</FONT></td>
				</tr>
                <tr bgcolor="#f6f9ff">
                    <td align="right" height="22">
                        <span style="color: #ff6531">推荐状态：</span></td>
                    <td>
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="是" /></td>
                </tr>
				
				<TR bgColor="#f6f9ff">
					<TD align="right" height="22"><FONT color="#ff6531">备注：</FONT></TD>
					<TD><textarea id="fckRemark" runat="server"></textarea> </TD>
				</TR>
                <tr bgcolor="#f6f9ff">
                    <td align="right" height="22">
                        <span style="color: #ff6531">广告类型：</span></td>
                    <td>
                        <asp:DropDownList ID="DrADState" runat="server" Width="121px">
                            <asp:ListItem Value="0">--请选择广告类型--</asp:ListItem>
                            <asp:ListItem Value="1">普通上</asp:ListItem>
                            <asp:ListItem Value="2">普通下</asp:ListItem>
                              <asp:ListItem Value="3">弹出</asp:ListItem>
                            <asp:ListItem Value="4">左对联</asp:ListItem>
                              <asp:ListItem Value="5">右对联</asp:ListItem>
                            <asp:ListItem Value="6">左浮动</asp:ListItem>
                              <asp:ListItem Value="7">右浮动</asp:ListItem>
                            <asp:ListItem Value="8">漂浮</asp:ListItem>
                        </asp:DropDownList><span style="color: #ff0000">*</span></td>
                </tr>
              
                
				<tr bgColor="#f6f9ff">
					<td align="left" colSpan="2" height="25">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						&nbsp;&nbsp;&nbsp;
						<asp:button id="btnSubmit" runat="server" Width="80px" CssClass="input" Text="确定" OnClick="btnSubmit_Click"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<input class="input" type="reset" value=" 重 填 " name="reset">
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>