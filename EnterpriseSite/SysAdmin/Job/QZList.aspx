<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QZList.aspx.cs" Inherits="SysAdmin_Job_QZList" %>
<%@ Register TagPrefix="uc1" TagName="Pagination" Src="~/Controls/Pagination.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
     <script>
      function openWinDialog(url,arg)
      {
        return window.showModalDialog(url,arg, 'edge:raised;scroll:0;status:0;help:0;resizable:1;center:1;dialogWidth:800px;dialogHeight:600px;');
      }
     </script>
    <LINK href="../Css/css.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table cellSpacing="0" cellPadding="0" width="800" border="0" align="center">
				<tr><td style="height: 1px">
                    <strong><span style="color: #0a7ec5">求职信息列表：</span></strong></td></tr>
         <tr>
             <td style="height: 1px">
                 <strong><span style="color: #0a7ec5">根据个人会员姓名查询：<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                     <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查询" /></span></strong></td>
         </tr>
				<tr><td >
				<asp:GridView ID="gvQZList" runat="server" AutoGenerateColumns="False"  BackColor="#D1E3FE" ForeColor="Blue" BorderColor="#1AA0D4" Width="100%" AllowPaging="True" PagerSettings-Visible="false" >
							
							<AlternatingRowStyle BackColor="#ECF4FF" />
							<RowStyle Font-Names="宋体" HorizontalAlign="Center" Height="25px" BackColor="#F7F9FF" />
					
							<HeaderStyle HorizontalAlign="Center" Height="25px" ForeColor="#0066FF" CssClass="unnamed1" VerticalAlign="Middle"
								BackColor="#D1E3FE"></HeaderStyle>
				<Columns>
				<asp:BoundField HeaderText="求职人姓名"  DataField="UserName"/>
                   <asp:TemplateField HeaderText="学历" Visible="false">
                        <ItemTemplate>
                             <asp:Label ID="lbDiploma" runat="server" Text=""></asp:Label>
                             <asp:Label ID="lbDiploma1" runat="server" Text='<%#Eval("Levels") %>' Visible="false"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
				<asp:BoundField HeaderText="欲应聘岗位" DataField="JobName" />
				<asp:BoundField HeaderText="添加时间" DataField="FillTime" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="False"/>
                    <asp:TemplateField HeaderText="审核" Visible="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnApprove" runat="server" CommandArgument='<%#Eval("MemberId") %>'
                                OnCommand="lbtnApprove_Command" Text='<%#Eval("RApproved").ToString()=="1"?"是":"否" %>'
                                Visible="<%#this.AllowApprove%>"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
				<asp:TemplateField HeaderText="操作">
				<ItemTemplate>
   
					<a href="javascript:void(0);" onclick='openWinDialog(<%#"\"PersonInfo.aspx?PersonID="+Eval("MemberId")+"&rd="+new System.Random().Next()+"\"" %>);' title="查看"><img src="../images/ny/view.gif" border="0" /></a>&nbsp;
					<asp:ImageButton ID="ImageButton1" runat="server" ToolTip="删除" Visible='<%#this.AllowDel%>' ImageUrl="../images/ny/del.gif" CommandArgument='<%#Eval("MemberId")%>'  OnCommand="ibtnDel_Command" OnClientClick="return confirm('你确认要删除吗!');"/>
				</ItemTemplate>
				</asp:TemplateField>
				</Columns>
                    <PagerSettings Visible="False" />
				</asp:GridView></td></tr>
				<tr><td align="left"><uc1:Pagination ID="pageBar" runat="server" PageSize="15"   OnPageIndexChanged="pageBar_PageIndexChanged"/> </td></tr>
				</table>
    </div>
    </form>
</body>
</html>