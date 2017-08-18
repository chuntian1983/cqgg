<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ArticleList.aspx.cs" Inherits="SysAdmin_Article_ArticleList" %>
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
				<asp:GridView ID="gvArticleList" runat="server" AutoGenerateColumns="false"  BackColor="#D1E3FE" ForeColor="Blue" BorderColor="#1AA0D4" Width="100%" AllowPaging="true" PagerSettings-Visible="false" >
							
							<AlternatingRowStyle BackColor="#ECF4FF" />
							<RowStyle Font-Names="宋体" HorizontalAlign="Center" Height="25px" BackColor="#F7F9FF" />
					
							<HeaderStyle HorizontalAlign="Center" Height="25px" ForeColor="#0066FF" CssClass="unnamed1" VerticalAlign="Middle"
								BackColor="#D1E3FE"></HeaderStyle>
				<Columns>
				<asp:BoundField HeaderText="文章标识"  DataField="ArticleId"/>
				<asp:BoundField HeaderText="标    题" DataField="Title" />
				<asp:BoundField HeaderText="作　　者" DataField="PublicationUnit" />
				<asp:BoundField HeaderText="文章类型" DataField="CategoryName" />
				<asp:TemplateField HeaderText="审核" Visible="False">
				<ItemTemplate>
				   <asp:LinkButton ID="lbtnApprove" runat="server" Text='<%#Eval("Approved").ToString()=="1"?"是":"否" %>' CommandArgument='<%#Eval("ArticleId") %>' OnCommand="lbtnApprove_Command" Visible="<%#this.AllowApprove%>"></asp:LinkButton>
				    <span id="spanApprove" runat="server" visible="<%#!this.AllowApprove%>"><%#Eval("Approved").ToString()=="1"?"是":"否" %></span>
				</ItemTemplate>
				</asp:TemplateField>
				<asp:BoundField HeaderText="添 加 人" DataField="Nickname" />
				<asp:BoundField HeaderText="发布时间" DataField="ReleaseDate"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="False"/>
				<asp:TemplateField HeaderText="操作">
				<ItemTemplate>
				 <asp:HyperLink ID="HyperLink1" runat="server"  visible="<%#this.AllowEdit%>" ImageUrl="../images/ny/edit.gif" NavigateUrl='<%#"AddArticle.aspx?ArticleId="+Eval("ArticleId")%>' Text="修改">
                                    </asp:HyperLink>
			
				&nbsp;<asp:ImageButton ID="ibtnDel" runat="server" ToolTip="删除" visible="<%#this.AllowDel%>"  ImageUrl="../images/ny/del.gif" OnClientClick="javascript:return confirm('你确实要删除吗');" CommandArgument='<%#Eval("ArticleId")%>'  OnCommand="ibtnDel_Command"/>
				&nbsp;<asp:ImageButton ID="approve" runat="server" ToolTip="审核" visible="<%#this.AllowApprove%>"  ImageUrl="../images/ny/modiy.gif" OnClientClick="javascript:return confirm('你确实要进行操作吗');" CommandArgument='<%#Eval("ArticleId")%>'  OnCommand="lbtnApprove_Command"/>
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