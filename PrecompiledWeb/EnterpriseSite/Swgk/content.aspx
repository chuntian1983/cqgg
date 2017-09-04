<%@ page language="C#" autoeventwireup="true" inherits="Swgk_content, App_Web_hizfs4zj" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    
     <script type="text/javascript" src="../JS/calendar.js"></script>
      <script>
          function openWinDialog(url, arg) {
              if (url.lastIndexOf('?') == -1) url += '?';
              else url += '&';
              url += 'rnd=' + Math.random();
              return window.showModalDialog(url, arg, 'edge:raised;scroll:0;status:0;help:0;center:1;resizable:1;dialogWidth:900px;dialogHeight:650px;');
          }
     </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table cellSpacing="0" cellPadding="0" width="800" border="0" align="center">
				<tr><td height="10px"></td></tr>
				<tr id="trSearchTop" runat="server">
										<td width="70%" 
                                            style="font-size: x-large; font-weight: bold; text-align: center;">村务公开监管</td>
									
					</tr>
					<tr id="trSearchButtom" runat="server"><td> &nbsp;</td></tr>
				<tr><td >
				<asp:GridView ID="gvArticleList" runat="server" AutoGenerateColumns="False"  
                        BackColor="#D1E3FE" ForeColor="Blue" BorderColor="#1AA0D4" Width="100%" 
                        AllowPaging="True" PagerSettings-Visible="false" 
                         EnableModelValidation="True" >
							
							<AlternatingRowStyle BackColor="#ECF4FF" />
							<RowStyle Font-Names="宋体" HorizontalAlign="Center" Height="25px" />
					
							<HeaderStyle HorizontalAlign="Center" Height="25px" ForeColor="#0066FF" CssClass="unnamed1" VerticalAlign="Middle"
								BackColor="#D1E3FE"></HeaderStyle>
				<Columns>
				<asp:BoundField HeaderText="行政级别"  DataField="title"/>
				<asp:BoundField HeaderText="阳光村务是否入户" DataField="state" />
				    <asp:BoundField DataField="f0" HeaderText="阳光村务入户村数" />
                    <asp:BoundField DataField="f1" HeaderText="阳光村务未入户的村数" />
				</Columns>
                    <PagerSettings Visible="False" />
				</asp:GridView></td></tr>
				<tr><td align="center">
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
                        onpagechanged="AspNetPager1_PageChanged" ShowCustomInfoSection="Left" 
                        ShowPageIndexBox="Always">
                    </webdiyer:AspNetPager>
                    </td></tr>
				</table>
    </div>
    </form>
</body>
</html>
