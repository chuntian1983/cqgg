<%@ page language="C#" autoeventwireup="true" inherits="SysAdmin_Department_DepartList, App_Web_nhlb5gor" %>
<%@ Register TagPrefix="uc1" TagName="Pagination" Src="~/Controls/Pagination.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <LINK href="../Css/css.css" type="text/css" rel="stylesheet">
     <script type="text/javascript" src="../JS/calendar.js"></script>
      <script>
      function openWinDialog(url,arg)
      {
        if(url.lastIndexOf('?')==-1) url+='?';
        else url+='&';
        url+='rnd='+Math.random();
        return window.showModalDialog(url,arg, 'edge:raised;scroll:0;status:0;help:0;center:1;resizable:1;dialogWidth:900px;dialogHeight:650px;');
      }
     </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table cellSpacing="0" cellPadding="0" width="800" border="0" align="center">
				<tr><td height="10px"></td></tr>
				<tr id="trSearchTop" runat="server">
										<td width="70%">添加日期：<asp:textbox id="txtStart" Columns="10" onFocus="this.blur();"
												Runat="server"></asp:textbox>&nbsp;<img  onclick="meizz_calendar(document.getElementById('txtStart'))"
                                                               style="cursor:pointer;" src="../images/calendar.gif" /> 到	<asp:textbox id="txtEnd" Columns="10" onFocus="this.blur();" 
												Runat="server"></asp:textbox>&nbsp;<img  onclick="meizz_calendar(document.getElementById('txtEnd'))"
                                                               style="cursor:pointer;" src="../images/calendar.gif" /></td>
									
					</tr>
					<tr id="trSearchButtom" runat="server"><td> 标题：<asp:TextBox ID="txtTitle" runat="server" ></asp:TextBox> 类型：<asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList>&nbsp;审核：<asp:DropDownList ID="ddlApproved" runat="server">
					<asp:ListItem Value="-1">--请选择--</asp:ListItem>
					<asp:ListItem Value="0">未审核</asp:ListItem>
					<asp:ListItem Value="1">审核通过</asp:ListItem>
					</asp:DropDownList>&nbsp;<asp:Button ID="btnFind" runat="server" Text="查询" OnClick="btnFind_Click" /></td></tr>
				<tr><td >
				<asp:GridView ID="gvArticleList" runat="server" AutoGenerateColumns="False"  BackColor="#D1E3FE" ForeColor="Blue" BorderColor="#1AA0D4" Width="100%" AllowPaging="True" PagerSettings-Visible="false" OnRowCreated="gvArticleList_RowCreated" >
							
							<AlternatingRowStyle BackColor="#ECF4FF" />
							<RowStyle Font-Names="宋体" HorizontalAlign="Center" Height="25px" BackColor="#F7F9FF" />
					
							<HeaderStyle HorizontalAlign="Center" Height="25px" ForeColor="#0066FF" CssClass="unnamed1" VerticalAlign="Middle"
								BackColor="#D1E3FE"></HeaderStyle>
				<Columns>
				<asp:BoundField HeaderText="文章标识"  DataField="DepartId"/>
				<asp:BoundField HeaderText="标    题" DataField="Title" />
				<asp:BoundField HeaderText="文章类型" DataField="CategoryName" />
				<asp:TemplateField HeaderText="审核" Visible="False">
				<ItemTemplate>
				 
				</ItemTemplate>
				</asp:TemplateField>
				<asp:BoundField HeaderText="添 加 人" DataField="Nickname" />
				<asp:TemplateField HeaderText="操作">
				<ItemTemplate>
				<a href='javascript:void(0);' onclick='<%#"openWinDialog(\"DepartAdd.aspx?DepartId="+Eval("DepartId")+"\");"%>' title="修改" id="linkEdit" runat="server" visible="<%#this.AllowEdit%>"><img src="../images/ny/edit.gif" border="0" /></a>
				&nbsp;<asp:ImageButton ID="ibtnDel" runat="server" ToolTip="删除" visible="<%#this.AllowDel%>"  ImageUrl="../images/ny/del.gif" OnClientClick="javascript:return confirm('你确实要删除吗');" CommandArgument='<%#Eval("DepartId")%>'  OnCommand="ibtnDel_Command"/>
				</ItemTemplate>
				</asp:TemplateField>
				</Columns>
                    <PagerSettings Visible="False" />
				</asp:GridView></td></tr>
				<tr><td align="center"><uc1:Pagination ID="pageBar" runat="server" PageSize="10"   OnPageIndexChanged="pageBar_PageIndexChanged"/> </td></tr>
				</table>
    </div>
    </form>
</body>
</html>
