<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cunwutj.aspx.cs" Inherits="Swgk_cunwutj" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>村务公开电子测评</title>
   
     <script type="text/javascript" src="../SysAdmin/js/calendar.js"></script>
      <script>
          function openWinDialog(url, arg) {
              if (url.lastIndexOf('?') == -1) url += '?';
              else url += '&';
              url += 'rnd=' + Math.random();
              return window.showModalDialog(url, arg, 'edge:raised;scroll:0;status:0;help:0;center:1;resizable:1;dialogWidth:900px;dialogHeight:650px;');
          }
     </script>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
        }
        .style3
        {
            width: 146px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table cellSpacing="0" cellPadding="0" width="800" border="0" align="center">
				<tr><td height="10px"></td></tr>
				<tr id="trSearchTop" runat="server">
										<td width="70%" 
                                            style="font-size: x-large; font-weight: bold; text-align: center;">村务公开电子测评</td>
									
					</tr>
				<tr id="dd" runat="server">
										<td width="70%" 
                                            style=" text-align: center;">
                                            <table class="style1">
                                                <tr>
                                                    <td class="style2" colspan="3">
                                                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                                                            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                                                            onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:DropDownList ID="DropDownList3" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="style3">
                                                        统计时间：</td>
                                                    <td>
                                                        <asp:DropDownList ID="DropDownList4" runat="server">
                                                            <asp:ListItem>2010</asp:ListItem>
                                                            <asp:ListItem>2011</asp:ListItem>
                                                            <asp:ListItem>2012</asp:ListItem>
                                                            <asp:ListItem>2013</asp:ListItem>
                                                            <asp:ListItem>2014</asp:ListItem>
                                                            <asp:ListItem>2015</asp:ListItem>
                                                        </asp:DropDownList>
                                                        年<asp:DropDownList ID="DropDownList5" runat="server">
                                                            <asp:ListItem>1</asp:ListItem>
                                                            <asp:ListItem>2</asp:ListItem>
                                                            <asp:ListItem>3</asp:ListItem>
                                                            <asp:ListItem>4</asp:ListItem>
                                                            <asp:ListItem>5</asp:ListItem>
                                                            <asp:ListItem>6</asp:ListItem>
                                                            <asp:ListItem>7</asp:ListItem>
                                                            <asp:ListItem>8</asp:ListItem>
                                                            <asp:ListItem>9</asp:ListItem>
                                                            <asp:ListItem>10</asp:ListItem>
                                                            <asp:ListItem>11</asp:ListItem>
                                                            <asp:ListItem>12</asp:ListItem>
                                                        </asp:DropDownList>
                                                        月&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text=" 统 计 " />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style2">
                                                        &nbsp;</td>
                                                    <td class="style2">
                                                        &nbsp;</td>
                                                    <td class="style2" colspan="2">
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
									
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
                    <asp:TemplateField HeaderText="警告牌">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Bind("f0") %>' /> 
                        </ItemTemplate>
                       
                    </asp:TemplateField>
				<asp:BoundField HeaderText="区名称"  DataField="f1"/>
				<asp:BoundField HeaderText="镇名称" DataField="f2" />
				    <asp:BoundField DataField="f3" HeaderText="村名称" />
                    <asp:BoundField DataField="f4" HeaderText="实际公开得分" />
                    <asp:BoundField DataField="f5" HeaderText="村应该公开得分" />
				    <asp:BoundField HeaderText="村平均分" DataField="f6" />
				    <asp:BoundField DataField="f7" HeaderText="镇考核得分" />
				</Columns>
                    <PagerSettings Visible="False" />
				</asp:GridView></td></tr>
				<tr><td align="center">
                    提示：0-59分为红牌警告、60-96分为黄牌警告、96分以上为绿牌。 &nbsp;</td></tr>
				</table>
    </div>
    </form>
</body>
</html>
