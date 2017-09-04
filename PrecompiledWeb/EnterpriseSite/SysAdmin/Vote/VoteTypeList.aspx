<%@ page language="C#" autoeventwireup="true" inherits="SysAdmin_Vote_VoteTypeList, App_Web_xentbuoo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>投票类别列表</title>
    	<script  type="text/jscript" language="javascript" src="../Script/btn_click.js"></script>
		<script type="text/jscript" language="javascript" id="aa">
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
				var strxml="<root><ID>"+id+"</ID><Flag>"+Flag+"</Flag><UserAction>MominateIndex</UserAction></root>";
				SaveXMLDom("VoteTypeAct.aspx",strxml,"VoteTypeList.aspx");
			}
		</script>

    <link href="../Css/Login/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellspacing="0" cellpadding="0" width="600px" align="center" border="0">
        <tr>
            <td align="left" bgcolor="#f6f9ff" height="23">
                投票类别列表：</td>
        </tr>
				<tr>
					<td align="right" bgcolor="#f6f9ff" height="23"><asp:label id="lbvoteid" runat="server" Visible="False"></asp:label>
						<table cellspacing="0" cellpadding="0" border="0">
							<tr>
								<td valign="bottom" width="23" height="18"><img alt="添加"　height="14" src="../images/ny/add.gif" width="14"/></td>
								<td valign="bottom" width="46" height="18"><asp:linkbutton id="LinkButton1" runat="server" OnClick="LinkButton1_Click">添加</asp:linkbutton></td>
								<td valign="bottom" width="23" height="18"><img alt="刷新" height="14" src="../images/ny/b_1.gif" width="14"/></td>
								<td valign="bottom" width="46" height="18"><a onclick="javascript:window.history.go(0)" href="#">刷新</a></td>
								<td valign="bottom" width="23" height="18"><img alt="" height="14" src="../images/ny/add.gif" width="14"/></td>
								<td valign="bottom" width="46" height="18">
									<asp:HyperLink id="Hyperlink5" runat="server" NavigateUrl="VoteSubList.aspx">返回</asp:HyperLink></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr class="tab1">
					<td align="center" bgcolor="#4180c6" height="1"></td>
				</tr>
				<tr>
					<td><asp:datagrid id="dgType" runat="server" PageSize="15" CellPadding="0" BorderWidth="1px" Width="100%"
							AutoGenerateColumns="False" AllowSorting="True" BorderColor="#1AA0D4" ForeColor="Blue" BackColor="#D1E3FE"
							ItemStyle-Height="30" FooterStyle-Height="20" OnItemDataBound="dgType_ItemDataBound">
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
                                <asp:TemplateColumn HeaderText="类别名称">
                                    <ItemTemplate>
                                        &nbsp;<asp:HyperLink ID="HyperLink3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"VoteType") %>' NavigateUrl='<%# "VoteTypeMod.aspx?id=" + DataBinder.Eval(Container.DataItem, "ID")+"&amp;vid="+DataBinder.Eval(Container.DataItem,"VoteID")  %>'></asp:HyperLink>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        &nbsp;
                                    </EditItemTemplate>
                                    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" ForeColor="#FF6633" Width="230px" />
                                </asp:TemplateColumn>
								<asp:BoundColumn DataField="VoteCount" SortExpression="VoteCount" HeaderText="票数">
									<HeaderStyle HorizontalAlign="Center" ForeColor="#FF6633" Width="80px"></HeaderStyle>
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" HorizontalAlign="Center" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Vouch" SortExpression="Vouch" HeaderText="首页推荐">
									<HeaderStyle HorizontalAlign="Center" ForeColor="#FF6633" Width="60px"></HeaderStyle>
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" HorizontalAlign="Center" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FillTime" SortExpression="FillTime" HeaderText="发布时间" DataFormatString="{0:d}">
									<HeaderStyle HorizontalAlign="Center" ForeColor="#FF6633" Width="90px"></HeaderStyle>
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" HorizontalAlign="Center" />
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="操作">
									<HeaderStyle HorizontalAlign="Center" ForeColor="#FF6633" Width="60px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink2" runat="server" Text="修改" ImageUrl="../images/ny/edit.gif" NavigateUrl='<%# "VoteTypeMod.aspx?id=" + DataBinder.Eval(Container.DataItem, "ID")+"&amp;vid="+DataBinder.Eval(Container.DataItem,"VoteID")  %>'>修改
										</asp:HyperLink>&nbsp;
										<asp:HyperLink id="Hyperlink1" runat="server" Text="删除" ImageUrl="../images/ny/del.gif" NavigateUrl='<%# "VoteTypeDel.aspx?id=" + DataBinder.Eval(Container.DataItem, "ID")+"&amp;vid="+DataBinder.Eval(Container.DataItem,"VoteID")  %>'>删除</asp:HyperLink>
                                        &nbsp;
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
