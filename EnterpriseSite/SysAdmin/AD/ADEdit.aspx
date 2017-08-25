<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ADEdit.aspx.cs" Inherits="SysAdmin_AD_ADEdit" %>

<%@ Register Src="../../Controls/TopButtons.ascx" TagName="TopButtons" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../../Css/Login/css.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">					
			function Save_Body()
			{
				if (document.getElementById("LinkName").value=="")
				{
					alert('友情链接名称不能为空！');
					document.getElementById("LinkName").focus();
					return false;
				}
				if (document.getElementById("LinkUrl").value=="")
				{
					alert('友情链接地址URL不能为空！');
					document.getElementById("LinkUrl").focus();
					return false;
				}
				if (/^\d+$/.test(document.getElementById("OrderID").value)==false)
				{
					alert('排序必须是数字！');
					document.getElementById("OrderID").focus();
					return false;
				}
				var strNode="";
				if (document.getElementById("LinkTypeType").value=="1")
				{				
					strNode="UserAction,LinkTypeID,LinkName,LinkUrl,OrderID,LinkTypeType";
				}
				else if (document.getElementById("LinkTypeType").value=="2") 
				{
					strNode="UserAction,LinkTypeID,LinkName,LinkUrl,OrderID,ImageUrl,LinkTypeType";
				}
				var strxml=CreateDom(strNode,'');
				SaveXMLDom("LinkAct.aspx",strxml.xml,"");
			}
		</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:TopButtons ID="TopButtons1" runat="server" />
			<table cellspacing="0" cellpadding="0" width="80%" align="center" border="0">
				<tr>
					<td align="center" colspan="2" height="8"></td>
				</tr>
				<tr>
					<td align="left" width="5%">&nbsp;<img height="23" src="../Images/dig.gif" width="23"></td>
					<td align="left"><font color="#0a7ec5"><b>广告修改</b></font></td>
				</tr>
			</table>
			<table cellspacing="1" cellpadding="0" width="80%" align="center" bgcolor="#d1e3fe" border="0">
				<tr bgcolor="#f6f9ff">
					<td align="right" height="22"><font color="#ff6531">广告类型：</font></td>
					<td>&nbsp;&nbsp;
						<asp:label id="ADFlag" runat="server"></asp:label></td>
				</tr>
				<tr bgcolor="#f6f9ff">
					<td align="right" width="25%" height="22"><font color="#ff6531">广告位置：</font></td>
					<td width="75%">&nbsp;&nbsp;
						<asp:label id="ADBoard" runat="server"></asp:label></td>
				</tr>
				<asp:panel id="ADmargin" Visible="True" Runat="server">
					<tr bgcolor="#f6f9ff">
						<td align="right" height="22"><font color="#ff6531">广告设置：</font></td>
						<td>&nbsp;&nbsp; 左边距<input class="input" id="Sidemargin" type="text" maxlength="5" size="4" runat="server">
							&nbsp;&nbsp; 上边距<input class="input" id="Topmargin" type="text" maxlength="5" size="4" runat="server">
						</td>
					</tr>
				</asp:panel>
				<tr bgcolor="#f6f9ff">
					<td align="right" height="22"><font color="#ff6531">广告名称：</font></td>
					<td>&nbsp;&nbsp;<input class="input" id="Title" type="text" maxlength="500" size="30" runat="server"/></td>
				</tr>
				<asp:panel id="NotADPop" Visible="True" Runat="server">
					<tr bgcolor="#f6f9ff">
						<td align="right" height="22"><font color="#ff6531">广告链接地址：</font></td>
						<td>&nbsp;&nbsp;<input class="input" id="Url" type="text" maxlength="500" size="30" runat="server"/><font face="宋体" color="red">地址为空，广告没有链接</font></td>
					</tr>
					<tr bgcolor="#f6f9ff">
						<td align="right" height="22"><font color="#ff6531">广告注释：</font></td>
						<td>&nbsp;&nbsp;<input class="input" id="Readme" type="text" maxlength="255" size="50" runat="server"/></td>
					</tr>
					<tr bgcolor="#f6f9ff">
						<td align="right" height="22"><font color="#ff6531">图片/Flash：</font></td>
						<td>&nbsp;&nbsp;<input class="input" id="ImageUrl" type="text" maxlength="500" size="50" runat="server"/><font face="宋体" color="red">推荐宽度
								<asp:Label id="lblFitWidth" runat="server"></asp:Label>，高度
								<asp:Label id="lblFitHeight" runat="server"></asp:Label></font></td>
					</tr>
					<tr bgcolor="#f6f9ff">
						<td align="right" style="height: 78px"><font color="#ff6531">图片上传：</font></td>
						<td style="height: 78px">&nbsp;&nbsp;<iframe id="if1" marginwidth="0" marginheight="0" src="upload.aspx?UploadType=Ad" frameborder="0"
								width="90%" scrolling="auto" height="50" style="width: 96%; height:100px"></iframe>
						</td>
					</tr>
		           </asp:panel>
				
				<asp:panel id="IsADPop" Visible="false" Runat="server">
					<tr bgcolor="#f6f9ff">
						<td align="right" height="22"><font color="#ff6531">弹出广告内容：</font></td>
						<td align="left" height="22">
                        <textarea id="fckBody" runat="server"></textarea>
                         
							</td>
					</tr>
					</asp:panel>
				
			
				<tr bgcolor="#f6f9ff">
					<td align="right" height="22"><font color="#ff6531">图片/Flash/弹出窗口尺寸：</font></td>
					<td>&nbsp;&nbsp; 宽度<input class="input" id="Width" type="text" maxlength="5" size="4" runat="server">
						&nbsp; 高度<input class="input" id="Height" type="text" maxlength="5" size="4" runat="server">
					</td>
				</tr>
			
			
				<tr bgColor="#f6f9ff">
					<td align="right" height="22"><font color="#ff6531">是否显示广告：</font></td>
					<td>&nbsp;&nbsp;<input id="Show1" type="radio" check value="1" name="Show" runat="server"/>显示&nbsp;&nbsp;&nbsp;&nbsp;<input id="Show2" type="radio" value="2" name="Show" runat="server"/>不显示</td>
				</tr>
				<tr bgColor="#f6f9ff">
					<td colSpan="2" height="22">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <input id="ADBoardID" type="hidden" runat="server">
						<asp:button id="Button1" Runat="server" CssClass="input" Text=" 确 定 " OnClick="Button1_Click"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<input class="input" type="reset" value=" 重 填 " name="reset">
					</td>
				</tr>
			</table>
    </div>
    </form>
</body>
</html>
