<%@ page language="C#" autoeventwireup="true" inherits="SysAdmin_Picture_PictureList, App_Web_0vt0lpz3" %>
<%@ Register TagPrefix="uc1" TagName="Pagination" Src="~/Controls/Pagination.ascx" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <LINK href="../Css/css.css" type="text/css" rel="stylesheet">
     <script type="text/javascript" src="../JS/calendar.js"></script>
     <script>
      function openWinDialog(url,arg)
      {
        return window.showModalDialog(url,arg,'edge:raised;scroll:0;status:0;help:0;resizable:1;center:1;dialogWidth:800px;dialogHeight:600px;');
      }
     </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="100%">
					<tr>
						<td colSpan="7">
							<table>
								<TBODY>
									<tr id="trQueryTop" runat="server">
										<td width="70%">上传日期：<asp:textbox id="txtStart" Columns="10" onFocus="this.blur();"
												Runat="server"></asp:textbox>&nbsp;<img  onclick="meizz_calendar(document.getElementById('txtStart'))"
                                                               style="cursor:pointer;" src="../images/calendar.gif" /> 到	<asp:textbox id="txtEnd" Columns="10" onFocus="this.blur();" 
												Runat="server"></asp:textbox>&nbsp;<img  onclick="meizz_calendar(document.getElementById('txtEnd'))"
                                                               style="cursor:pointer;" src="../images/calendar.gif" /></td>
									
					</tr>
					<tr  id="trQueryButtom" runat="server"><td> 图片类型:<asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList>&nbsp;<asp:Button ID="btnFind" runat="server" Text="查询" OnClick="btnFind_Click" /></td></tr>
					</TBODY>
					</table>
					<table >
					<tr>
						<td>
						<table width="780" style="border:#bbbbbb solid 1px;background-color:#f0f0f0;">
						<tr><td  id="td1">
						<asp:datalist id="dlPic" Runat="server" RepeatColumns="8" RepeatDirection="Horizontal">
								<ItemTemplate>
								<table><tr><td><a href='javascript:void(0);' onclick='openWinDialog(<%#"\"picturedetail.aspx?PictureId="+Eval("PictureID")+"\""%>);' title='<%#Eval("PicName")%>'> 
									<img src='<%#this.ResolveClientUrl(originalPicPath+Eval("OriginalPicPath").ToString())%>' border="0" width="87" height="66"></a></td></tr>
									<tr><td><a href="javascript:void(0);" onclick='<%#"openWinDialog(\"uploadpicture.aspx?PictureId="+Eval("PictureID")+"\");"%>' id="linkEdit" runat="server" visible="<%#this.AllowEdit %>">编辑</a>&nbsp;<asp:LinkButton ID="lbtnDel" runat="server"  Text="删除" CommandArgument='<%#Eval("PictureId")%>' OnCommand="lbtnDel_Command" OnClientClick="return confirm('你确认要删除吗!');" Visible="<%#this.AllowDel %>"></asp:LinkButton></td></tr></table>
									
								</ItemTemplate>
							</asp:datalist></td></tr>
							<tr><td align="left"><webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
            OnPageChanged="AspNetPager1_PageChanged" PageSize="15" ShowBoxThreshold="1">
    </webdiyer:AspNetPager> </td></tr>
							</table>
						</td>
					</tr>
					
				</table>
				</TD></TR></TABLE>
    </div>
    </form>
</body>
</html>
