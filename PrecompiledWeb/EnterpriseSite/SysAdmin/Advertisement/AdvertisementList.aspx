<%@ page language="C#" autoeventwireup="true" inherits="SysAdmin_Advertisement_AdvertisementList, App_Web_a5ecsdj4" %>
<%@ Register TagPrefix="uc1" TagName="Pagination" Src="~/Controls/Pagination.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <LINK href="../Css/css.css" type="text/css" rel="stylesheet">
     <script>
      function openWinDialog(url,arg)
      {
        return window.showModalDialog(url,arg, 'edge:raised;scroll:0;status:0;help:0;resizable:1;center:1;dialogWidth:800px;dialogHeight:600px;');
      }
     </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table cellSpacing="0" cellPadding="0" width="800" border="0" align="center">
				<tr>
					<td align="left" style="height: 10px">
                        <strong><span style="color: #0a7ec5">广告列表：</span></strong></td>
				</tr>
				<tr><td>
				<asp:GridView ID="gvADList" runat="server" AutoGenerateColumns="False"  BackColor="#D1E3FE" ForeColor="Blue" BorderColor="#1AA0D4" Width="100%" >
							
							<AlternatingRowStyle BackColor="#ECF4FF" />
							<RowStyle Font-Names="宋体" HorizontalAlign="Center" Height="25px" BackColor="#F7F9FF" />
					
							<HeaderStyle HorizontalAlign="Center" Height="25px" ForeColor="#0066FF" CssClass="unnamed1" VerticalAlign="Middle"
								BackColor="#D1E3FE"></HeaderStyle>
				<Columns>
				<asp:BoundField HeaderText="排序号" DataField="Sort" />
				<asp:BoundField HeaderText="广告名称"  DataField="ADName"/>
				<asp:TemplateField HeaderText="审核">
				<ItemTemplate>
				    <asp:LinkButton ID="lbtnApprove" runat="server" visible="<%#this.AllowApprove %>" Text='<%#Eval("Approved").ToString()=="1"?"是":"否" %>' CommandArgument='<%#Eval("ADId") %>' OnCommand="lbtnApprove_Command"></asp:LinkButton>
				    <span id="spanApprove" runat="Server" visible="<%#!this.AllowApprove %>"><%#Eval("Approved").ToString()=="1"?"是":"否" %></span>
				</ItemTemplate>
				</asp:TemplateField>
				<asp:BoundField HeaderText="添加时间" DataField="FillTime" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="False" />
				<asp:TemplateField HeaderText="操作">
				<ItemTemplate>
				
				<a href="javascript:void(0);" onclick='openWinDialog(<%#"\"AdvertisementAdd.aspx?ADId="+Eval("ADId")+"\"" %>);' title="修改"><img src="../images/ny/view.gif" border="0" /></a>&nbsp;<asp:ImageButton ID="ibtnDel" runat="server" ToolTip="删除" Visible='<%#this.AllowDel%>' ImageUrl="../images/ny/del.gif" CommandArgument='<%#Eval("ADId")%>'  OnCommand="ibtnDel_Command" OnClientClick="return confirm('你确认要删除吗!');"/>
				</ItemTemplate>
				</asp:TemplateField>
				</Columns>
				</asp:GridView></td></tr>
				<tr><td align="left"><uc1:Pagination ID="pageBar" runat="server" PageSize="10"   OnPageIndexChanged="pageBar_PageIndexChanged"/> </td></tr>
				</table>
    </div>
    </form>
</body>
</html>
