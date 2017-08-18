<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VoteSubList.aspx.cs" Inherits="SysAdmin_Vote_VoteSubList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>投票主题列表</title>
    <link href="../Css/Login/css.css" rel="stylesheet" type="text/css" />
    	<script language="javascript" src="../js/btn_click.js" type="text/javascript"></script>
		<script language="javascript" id="aa" type="text/javascript">
			//判断--全选/全不选
			function SelectAll()
			{	
				var obj= document.all.allchk.checked;		   
				var chkList = document.getElementsByTagName("input");		      
				
				for(var i=0; i<chkList.length; i++)
				{
					if(chkList[i].type == 'checkbox')
					{	
						if(obj==true)
						{
						    chkList[i].checked = true;		                   
						}
						else if (obj==false)
						{
							chkList[i].checked = false;		                   
						}		
					}
				}			  
			}
			function MominateIndex_Node1(Flag,id)
			{
				var strxml="<root><ID>"+id+"</ID><Flag>"+Flag+"</Flag><UserAction>MominateIndex1</UserAction></root>";
				SaveXMLDom("VoteTypeAct.aspx",strxml,"VoteSubList.aspx");
			}
		</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellspacing="0" cellpadding="0" width="600px" border="0" align="center">
				<tr>
					<td align="right" bgcolor="#f6f9ff" height="23">
						<table  cellspacing="0" cellpadding="0" border="0">
							<tr>
								<td valign="bottom" width="23" height="18"><img alt=""　height="14" src="../images/ny/add.gif" width="14"/></td>
								<td valign="bottom" width="46" height="18">
									<asp:HyperLink id="HyperLink3" runat="server" NavigateUrl="VoteSub.aspx">添加</asp:HyperLink></td>
								<td valign="bottom" width="23" height="18"><img alt="" height="14" src="../images/ny/b_1.gif" width="14"/></td>
								<td valign="bottom" width="46" height="18"><a onclick="javascript:window.history.go(0)" href="#">刷新</a></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr class="tab1">
					<td align="center" bgcolor="#4180c6" height="1"></td>
				</tr>
				<tr>
					<td><asp:datagrid id="dgSub" runat="server" FooterStyle-Height="20" ItemStyle-Height="30" BackColor="#D1E3FE"
							ForeColor="Blue" BorderColor="#1AA0D4" AllowSorting="True" AutoGenerateColumns="False" Width="100%"
							BorderWidth="1px" CellPadding="0" PageSize="15" OnItemDataBound="dgSub_ItemDataBound">
							<AlternatingItemStyle BackColor="#ECF4FF"></AlternatingItemStyle>
							<ItemStyle Font-Names="宋体" HorizontalAlign="Center" Height="25px" BackColor="#F7F9FF"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" Height="25px" ForeColor="#0066FF" CssClass="unnamed1" VerticalAlign="Middle"
								BackColor="#D1E3FE"></HeaderStyle>
							<FooterStyle Height="20px"></FooterStyle>
							<Columns>
								<asp:TemplateColumn Visible="False">
									<ItemTemplate>
										<asp:Label id="LabId" runat="server" text='<%# DataBinder.Eval(Container.DataItem, "id") %>'>
										</asp:Label>
									</ItemTemplate>
                                    <HeaderStyle Width="0px" />
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="选择">
									<HeaderStyle HorizontalAlign="Center" ForeColor="#FF6633" Width="40px"></HeaderStyle>
									<ItemTemplate>
										<input id="chk" type="checkbox" name="chk" runat="server"/>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="ID" SortExpression="ID" HeaderText="ID">
									<HeaderStyle HorizontalAlign="Center" ForeColor="#FF6633" Width="40px"></HeaderStyle>
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" HorizontalAlign="Center" />
								</asp:BoundColumn>
								<asp:HyperLinkColumn  DataNavigateUrlField="ID" DataNavigateUrlFormatString="VoteTypeList.aspx?vid={0}"
									DataTextField="Vote" SortExpression="Vote" HeaderText="投票主题">
									<HeaderStyle HorizontalAlign="Center" ForeColor="#FF6633" Width="300px"></HeaderStyle>
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" HorizontalAlign="Center" />
								</asp:HyperLinkColumn>
								<asp:BoundColumn DataField="Vouch" SortExpression="Vouch" HeaderText="首页推荐">
									<HeaderStyle HorizontalAlign="Center" ForeColor="#FF6633" Width="60px"></HeaderStyle>
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" HorizontalAlign="Center" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FillTime" SortExpression="FillTime" HeaderText="发布时间" DataFormatString="{0:d}">
									<HeaderStyle HorizontalAlign="Center" ForeColor="#FF6633" Width="70px"></HeaderStyle>
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" HorizontalAlign="Center" />
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="操作">
									<HeaderStyle HorizontalAlign="Center" ForeColor="#FF6633" Width="90px" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink2" runat="server" NavigateUrl='<%# "VoteSubMod.aspx?id=" + DataBinder.Eval(Container.DataItem, "ID")%>' Text="修改" ImageUrl="../images/ny/edit.gif">修改</asp:HyperLink>&nbsp;
										<asp:HyperLink id="Hyperlink1" runat="server" NavigateUrl='<%# "VoteSubDel.aspx?id=" + DataBinder.Eval(Container.DataItem, "ID")%>' Text="删除" ImageUrl="../images/ny/del.gif">删除</asp:HyperLink>&nbsp;
										<asp:HyperLink id="Hyperlink4" runat="server" NavigateUrl='<%# "VoteTypeList.aspx?vid=" + DataBinder.Eval(Container.DataItem, "ID")%>' Text="查看投票类别" ImageUrl="../Images/ny/modiy.gif">查看投票类别</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
			</table>
			<table cellspacing="0" cellpadding="0" align="center" border="0" width="600px">
				<tr>
					<td>
						<table id="Table34" cellspacing="0" cellpadding="0" width="200" align="left" border="0">
							<tr>
								<td align="center" width="32" height="30"><input id="allchk" onclick="SelectAll()" type="checkbox" name="allchk" runat="server"/></td>
								<td style="WIDTH: 80px">全选/全不选</td>
								<td width="50">
									<asp:button id="ButDelAllInfo" runat="server" BorderStyle="None" Text="删除所选记录" OnClick="ButDelAllInfo_Click"></asp:button></td>
							</tr>
						</table>
					</td>
					<td align="right" width="500">
					</td>
				</tr>
			</table>
    </div>
    </form>
</body>
</html>
