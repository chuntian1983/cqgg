<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkerList.aspx.cs" Inherits="SysAdmin_Worker_WorkerList" %>

<%@ Register Src="../../Controls/Pagination.ascx" TagName="Pagination" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../../SysAdmin/Css/css.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript" src="../JS/calendar.js"></script>
     <script>
      function openWinDialog(url,arg)
      {
        return window.showModalDialog(url,arg, 'edge:raised;scroll:1;status:0;help:0;center:1;resizable:1;dialogWidth:900px;dialogHeight:650px;');
      }
     </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table cellSpacing="0" cellPadding="0" width="800" border="0" align="center">
				<tr><td >
                    专家列表：</td></tr>
				<tr><td align="center">
				<asp:GridView ID="gvWorkerList" runat="server" AutoGenerateColumns="False"  BackColor="#D1E3FE" ForeColor="Blue" BorderColor="#1AA0D4" Width="100%" AllowPaging="True" PagerSettings-Visible="false" >
							
							<AlternatingRowStyle BackColor="#ECF4FF" />
							<RowStyle Font-Names="宋体" HorizontalAlign="Center" Height="25px" BackColor="#F7F9FF" />
					
							<HeaderStyle HorizontalAlign="Center" Height="25px" ForeColor="#0066FF" CssClass="unnamed1" VerticalAlign="Middle"
								BackColor="#D1E3FE"></HeaderStyle>
				<Columns>
                    <asp:BoundField DataField="Name" HeaderText="姓名" />
                    <asp:BoundField DataField="Business" HeaderText="职位" />
                    <asp:BoundField DataField="DepartName" HeaderText="所属科室" />
				<asp:TemplateField HeaderText="操作">
				<ItemTemplate>
				
					 <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="../images/ny/edit.gif" NavigateUrl='<%#"WorkerAdd.aspx?WorkerId="+Eval("ID")%>' Text="修改">
                                    </asp:HyperLink>
				&nbsp;<asp:ImageButton ID="ibtnDel" runat="server" ToolTip="删除"   ImageUrl="../images/ny/del.gif" OnClientClick="javascript:return confirm('你确实要删除吗');" CommandArgument='<%#Eval("ID")%>'  OnCommand="ibtnDel_Command"/>
				
				</ItemTemplate>
				</asp:TemplateField>
				</Columns>
                    <PagerSettings Visible="False" />
				</asp:GridView> 
                    <uc1:Pagination ID="pageBar" runat="server" PageSize="10"   OnPageIndexChanged="pageBar_PageIndexChanged"/>
                    
                </td></tr>
				</table>
    </div>
    </form>
</body>
</html>
