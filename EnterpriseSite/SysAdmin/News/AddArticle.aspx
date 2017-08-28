<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddArticle.aspx.cs" ValidateRequest="false" Inherits="SysAdmin_News_AddOrEditArticle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../Css/css.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js" ></script>
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
     <link rel="stylesheet" href="../kindeditor/themes/default/default.css" />
	<link rel="stylesheet" href="../kindeditor/plugins/code/prettify.css" />
	<script charset="utf-8" src="../kindeditor/kindeditor-all-min.js"></script>
	<script charset="utf-8" src="../kindeditor/lang/zh-CN.js"></script>
	<script charset="utf-8" src="../kindeditor/plugins/code/prettify.js"></script>
	<script>
	    KindEditor.ready(function (K) {
	        var editor1 = K.create('#content1', {
	            cssPath: '../kindeditor/plugins/code/prettify.css',
	            uploadJson: '../kindeditor/asp.net/upload_json.ashx',
	            fileManagerJson: '../kindeditor/asp.net/file_manager_json.ashx',
	            allowFileManager: true,
	            afterCreate: function () {
	                var self = this;
	                K.ctrl(document, 13, function () {
	                    self.sync();
	                    K('form[name=example]')[0].submit();
	                });
	                K.ctrl(self.edit.doc, 13, function () {
	                    self.sync();
	                    K('form[name=example]')[0].submit();
	                });
	            }
	        });
	        prettyPrint();
	    });
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
                <tr bgcolor="#f6f9ff">
                    <td align="right" height="22" style="width: 219px">
                        <span style="color: #ff6531">信息类别：</span></td>
                    <td>
                        <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"></asp:DropDownList><font color="#ff6531">请选择信息类别</font></td>
                </tr>
				<tr bgColor="#f6f9ff">
					<td align="right" height="22" style="width: 219px"><font color="#ff6531">
                        <asp:Label ID="Label1" runat="server" Text="新闻标题"></asp:Label>：</font></td>
					<td><asp:textbox id="txtTitle" runat="server" Width="432px"></asp:textbox><FONT color="red">*</FONT></td>
				</tr>
				<asp:Panel ID="aa" Visible="false" runat="server">
                <tr bgcolor="#f6f9ff">
                    <td align="right" style="width: 219px; height: 22px">
                        <span style="color: #ff6531">是否添加首页新闻图片：</span></td>
                    <td style="height: 22px">
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="是" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" /></td>
                </tr>
               </asp:Panel>
                <asp:Panel ID="bb" Visible="false" runat="server">
                <tr bgcolor="#f6f9ff">
                    <td align="right" style="width: 219px; height: 22px">
                        <span style="color: #ff6531">首页新闻图片：</span></td>
                    <td style="height: 22px">
                        <asp:TextBox ID="txtImageLink" runat="server" onfocus="this.blur();" Width="432px"></asp:TextBox><span
                            style="color: #ff0000">*</span><input id="Button1" runat="server" onclick="openWinDialog('../picture/UploadPicture.aspx');"
                                title="上传图片" type="button" value="上传图片" /><input onclick="selectPic('txtImageLink');"
                                    title="选择图片" type="button" value="选择图片" /></td>
                </tr>
                </asp:Panel>
                
				<tr bgColor="#f6f9ff">
					<td align="right" style="height: 23px; width: 219px;"><font color="#ff6531">作 者：</font></td>
					<td style="height: 23px"><asp:textbox id="txtUnit" runat="server" Width="432px"></asp:textbox><FONT color="red">*</FONT></td>
				</tr>
				<tr bgColor="#f6f9ff">
					<td align="right" height="22" style="width: 219px"><font color="#ff6531">发布时间：</font></td>
					<td><asp:textbox id="txtReleaseDate" runat="server" Width="432px" onclick="WdatePicker()" class="Wdate"></asp:textbox>&nbsp;<br />
                        <span style="color: #ff0000">注：发布时间请不要超出当前时间。</span></td>
				</tr>
				<asp:panel ID="cc" Visible="false" runat="server">
				<tr bgColor="#f6f9ff">
					<td align="right" height="22"><font color="#ff6531">过期时间：</font></td>
					<td><asp:textbox id="txtExpireDate" runat="server" Width="432px" onFocus="this.blur()"></asp:textbox>&nbsp;<img  onclick="meizz_calendar(document.getElementById('txtExpireDate'))"
                                                               style="cursor:pointer;" src="../images/calendar.gif" /></td>
				</tr></asp:panel>
				<asp:panel ID="a" runat="server" Visible="false">
                <tr bgcolor="#f6f9ff">
                    <td align="right" height="22">
                        <span style="color: #ff6531">医疗服务价格：</span></td>
                    <td>
                        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox></td>
                </tr>
                </asp:panel>
				<TR bgColor="#f6f9ff">
					<TD align="right" height="22" style="width: 219px"><FONT color="#ff6531">新闻内容：</FONT></TD>
					<TD>
                    <textarea id="content1" cols="100" rows="8" style="width:700px;height:200px;visibility:hidden;" runat="server"></textarea>
                    </TD>
				</TR>
                <tr bgcolor="#f6f9ff" style="display:none">
                    <td align="right" height="22" style="width: 219px">
                        <span style="color: #ff6531">上传附件：</span></td>
                    <td>
                        <input id="fileUpload" runat="server" name="fileUpload" type="file" />
                        </td>
                </tr>
                <tr bgcolor="#f6f9ff" style="display:none">
                    <td align="right" style="width: 219px; height: 20px">
                        <span style="color: #ff6531">文件名称：</span></td>
                    <td style="height: 20px">
                        <asp:TextBox ID="txtFileName" runat="server" BorderStyle="Groove"></asp:TextBox>
                        </td>
                </tr>
                <tr bgcolor="#f6f9ff" style="display:none">
                    <td align="right" style="width: 219px; height: 20px">
                        <span style="color: #ff6531">描述：</span></td>
                    <td style="height: 20px">
                        <asp:TextBox ID="txtDescription" runat="server" BorderStyle="Groove" Height="54px"
                            TextMode="MultiLine" Width="212px"></asp:TextBox>
                        <asp:Button ID="btnSave" runat="server" OnClick="Button1_Click" Text="保存" /></td>
                </tr>
				<tr bgColor="#f6f9ff" >
					<td align="center" colSpan="2" height="25">
						<asp:button id="btnSubmit" runat="server" Width="80px" CssClass="input" Text="确定" OnClick="btnSubmit_Click"></asp:button>&nbsp;
						<span id="spanBack" runat="server" visible="false"><input type="button" value="返回" onclick="history.go(-1);" class="input" /></span>
						
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
