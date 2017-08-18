<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogList.aspx.cs" Inherits="SysAdmin_Account_Log_LogList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <LINK href="../Css/css.css" type="text/css" rel="stylesheet">
     <script type="text/javascript" src="../JS/calendar.js"></script>
      <script>
      function openWinDialog(url,arg)
      {
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
										<td width="70%">操作发生日期：<asp:textbox id="txtStart" Columns="10" onFocus="this.blur();"
												Runat="server"></asp:textbox>&nbsp;<img  onclick="meizz_calendar(document.getElementById('txtStart'))"
                                                               style="cursor:pointer;" src="../images/calendar.gif" /> 到	<asp:textbox id="txtEnd" Columns="10" onFocus="this.blur();" 
												Runat="server"></asp:textbox>&nbsp;<img  onclick="meizz_calendar(document.getElementById('txtEnd'))"
                                                               style="cursor:pointer;" src="../images/calendar.gif" /></td>
									
					</tr>
					<tr id="trSearchButtom" runat="server"><td> 用户昵称：<asp:TextBox ID="txtNickname" runat="server" ></asp:TextBox> IP地址：<asp:TextBox ID="txtIP" runat="server" ></asp:TextBox> &nbsp;<asp:Button ID="btnFind" runat="server" Text="查询" OnClick="btnFind_Click" /></td></tr>
						<tr><td height="10px"></td></tr>
				<tr><td >
				<asp:GridView ID="gvLogList" runat="server" AutoGenerateColumns="false"  BackColor="#D1E3FE" ForeColor="Blue" BorderColor="#1AA0D4" Width="100%" >
							
							<AlternatingRowStyle BackColor="#ECF4FF" />
							<RowStyle Font-Names="宋体" HorizontalAlign="Center" Height="25px" BackColor="#F7F9FF" />
					
							<HeaderStyle HorizontalAlign="Center" Height="25px" ForeColor="#0066FF" CssClass="unnamed1" VerticalAlign="Middle"
								BackColor="#D1E3FE"></HeaderStyle>
				<Columns>
				<asp:BoundField HeaderText="行为描述"  DataField="Description"/>
				<asp:BoundField HeaderText="操作的页面地址" DataField="Url" />
				<asp:BoundField HeaderText="操作时间" DataField="OperationDate" />
				<asp:BoundField HeaderText="操作人IP" DataField="IP" />
				<asp:BoundField HeaderText="操作人" DataField="Nickname" />
				</Columns>
				</asp:GridView></td></tr>
               <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
            OnPageChanged="AspNetPager1_PageChanged" ShowBoxThreshold="1" 
            FirstPageText="首页 " LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" 
            ShowPageIndexBox="Never" ShowCustomInfoSection="Left">
    </webdiyer:AspNetPager>
				<tr><td align="center"> </td></tr>
				</table>
    </div>
    </form>
</body>
</html>
