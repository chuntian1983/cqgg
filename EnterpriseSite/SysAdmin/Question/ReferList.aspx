<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReferList.aspx.cs" Inherits="SysAdmin_Question_ReferList" %>
<%@ Register TagPrefix="uc1" TagName="Pagination" Src="~/Controls/Pagination.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../../SysAdmin/Css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
					<table width="800" align="center">
					<tr>
						<td >
                            <span style="color: #0a7ec5"><strong>咨询信息列表：</strong></span></td>
					</tr>
                        <tr>
                            <td >
                   
						<asp:GridView ID="gvOptions" runat="server" AutoGenerateColumns="False"  BackColor="#D1E3FE" ForeColor="Blue" BorderColor="#1AA0D4" Width="100%">
							<AlternatingRowStyle BackColor="#ECF4FF" />
							<RowStyle Font-Names="宋体" HorizontalAlign="Center" Height="25px" BackColor="#F7F9FF" />
							<HeaderStyle HorizontalAlign="Center" Height="25px" ForeColor="#0066FF" CssClass="unnamed1" VerticalAlign="Middle"
								BackColor="#D1E3FE"></HeaderStyle>
				<Columns>
				<asp:BoundField HeaderText="咨询人姓名" DataField="OpName" />
                    <asp:BoundField DataField="OpTitle" HeaderText="咨询主题" />
				<asp:BoundField HeaderText="发布时间" DataField="FillTime"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="False"/>
                    <asp:TemplateField HeaderText="是否回复">
                        <ItemTemplate>
                           <%#Eval("OpType").ToString()=="0"?"<font color='red'>否</font>":"<font color='green'>是</font>" %>
                        </ItemTemplate>
                    </asp:TemplateField>
				<asp:TemplateField HeaderText="操作">
				<ItemTemplate>
				<a href='ReferView.aspx?ReferId=<%#Eval("OpinionID") %>' title="查看/回复" Visible="<%#this.AllowModify%>"><img src="../images/ny/edit.gif" border="0" /></a>
				
				<asp:HyperLink id="Hyperlink1" runat="server" Text="删除" ImageUrl="../images/ny/del.gif"  Visible="<%#this.AllowDel%>"  NavigateUrl='<%# "ReferDel.aspx?ReferId=" + DataBinder.Eval(Container.DataItem, "OpinionID") %>'>
										</asp:HyperLink>	
				
				</ItemTemplate>
				</asp:TemplateField>
				</Columns>
				</asp:GridView>
                            </td>
                        </tr>
					<tr><td align="left" style="width: 1206px">
                        <uc1:Pagination id="pageBar" runat="server" OnPageIndexChanged="pageBar_PageIndexChanged"
                            PageSize="15"></uc1:Pagination></td></tr>
				</table>
				
    </div>
    </form>
</body>
</html>