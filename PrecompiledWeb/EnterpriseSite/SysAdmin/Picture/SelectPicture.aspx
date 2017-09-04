<%@ page language="C#" autoeventwireup="true" inherits="SysAdmin_Picture_PictureList1, App_Web_0vt0lpz3" %>
<%@ Register TagPrefix="uc1" TagName="Pagination" Src="~/Controls/Pagination.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>选择图片</title>
    <LINK href="../Css/css.css" type="text/css" rel="stylesheet">
     <script type="text/javascript" src="../JS/calendar.js"></script>
     <script>
     function getPic(obj)
     {       
        var imgUrl = obj.src;
        var tmpUrl = imgUrl.substring(0,imgUrl.lastIndexOf("/"));
        tmpUrl = tmpUrl.substring(0,tmpUrl.lastIndexOf("/"));
        tmpUrl = tmpUrl.substring(0,tmpUrl.lastIndexOf("/"));
        var len = tmpUrl.length;
        window.dialogArguments.value = imgUrl.substring(len + 1, imgUrl.length);       
        window.close();
     }
     </script>
     <base target="_self"  ></base>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table width="100%">
					<tr>
						<td colSpan="7">
							<table>
								<TBODY>
									<tr>
										<td width="70%">上传日期：<asp:textbox id="txtStart" Columns="10" onFocus="this.blur();"
												Runat="server"></asp:textbox>&nbsp;<img  onclick="meizz_calendar(document.getElementById('txtStart'))"
                                                               style="cursor:pointer;" src="../images/calendar.gif" /> 到	<asp:textbox id="txtEnd" Columns="10" onFocus="this.blur();" 
												Runat="server"></asp:textbox>&nbsp;<img  onclick="meizz_calendar(document.getElementById('txtEnd'))"
                                                               style="cursor:pointer;" src="../images/calendar.gif" /></td>
									
					</tr>
					<tr><td> 图片类型:<asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList>&nbsp;<asp:Button ID="btnFind" runat="server" Text="查询" OnClick="btnFind_Click" /></td></tr>
					</TBODY>
					</table>
					<table >
					<tr>
						<td>
						<table width="780px" style="border:#bbbbbb solid 1px;background-color:#f0f0f0;">
						<tr><td  id="td1">
						<asp:datalist id="dlPic" Runat="server" RepeatColumns="8" RepeatDirection="Horizontal">
								<ItemTemplate>
								<table><tr><td>
									<img style="cursor:hand;" onclick='getPic(this);' title='<%#Eval("PicName")%>' src='<%#ResolveClientUrl(originalPicPath+Eval("OriginalPicPath").ToString())%>' border="0" width="87" height="66">
									</td></tr>
								</table>
								</ItemTemplate>
							</asp:datalist></td></tr>
							<tr><td align="left"><uc1:Pagination ID="pageBar" runat="server" PageSize="40"   OnPageIndexChanged="pageBar_PageIndexChanged" /> </td></tr>
							</table>
						</td>
					</tr>
					
				</table>
				</TD></TR></TABLE>
    </div>
    </form>
</body>
</html>
