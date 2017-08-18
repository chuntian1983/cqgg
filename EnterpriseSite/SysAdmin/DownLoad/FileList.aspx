<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileList.aspx.cs" Inherits="SysAdmin_DownLoad_FileList" %>
<%@ Register TagPrefix="uc1" TagName="Pagination" Src="~/Controls/Pagination.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <LINK href="../Css/css.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table cellSpacing="0" cellPadding="0" width="800" border="0" align="center">
				<tr><td height="10px">
                    &nbsp;<strong><span style="color: #0a7ec5">已上传文件列表：</span></strong></td></tr>
         <tr>
             <td height="10">
                 <strong><span style="color: #0a7ec5">
                     <asp:Label ID="Label1" runat="server" Text="根据文件类别查询："></asp:Label></span></strong>
                 <asp:DropDownList ID="ddlFileType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFileType_SelectedIndexChanged">
                 </asp:DropDownList></td>
         </tr>
				<tr><td >
				<asp:GridView ID="gvFileList" runat="server" AutoGenerateColumns="false"  BackColor="#D1E3FE" ForeColor="Blue" BorderColor="#1AA0D4" Width="100%" AllowPaging="true" PagerSettings-Visible="false"  >
							
							<AlternatingRowStyle BackColor="#ECF4FF" />
							<RowStyle Font-Names="宋体" HorizontalAlign="Center" Height="25px" BackColor="#F7F9FF" />
					
							<HeaderStyle HorizontalAlign="Center" Height="25px" ForeColor="#0066FF" CssClass="unnamed1" VerticalAlign="Middle"
								BackColor="#D1E3FE"></HeaderStyle>
				<Columns>
				<asp:BoundField HeaderText="文 件 名" DataField="FileName" />
				<asp:BoundField HeaderText="描    述" DataField="Description" />
				<asp:BoundField HeaderText="文件类别" DataField="CategoryName" />
				<asp:BoundField HeaderText="上 传 人" DataField="Nickname" />
				<asp:BoundField HeaderText="上传时间" DataField="upLoadDate"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false"/>
				<asp:TemplateField HeaderText="下    载">
				<ItemTemplate>
				<asp:LinkButton ID="lbtnDownload" runat="server" Text="下载" CommandArgument='<%#Eval("FileId")%>'  OnCommand="lbtnDownload_Command"></asp:LinkButton>
				</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="操    作">
				<ItemTemplate>
				<a href='<%#"FileUpload.aspx?FileId="+Eval("FileId") %>' id="linkEdit" runat="server" visible="<%#this.AllowEdit %>" title="修改"><img src="../images/ny/edit.gif" border="0" /></a>
				&nbsp;<asp:ImageButton ID="ibtnDel" runat="server"  ToolTip="删除"  ImageUrl="../images/ny/del.gif" CommandArgument='<%#Eval("FileId")%>'  OnCommand="ibtnDel_Command" visible="<%#this.AllowDel %>"/>
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