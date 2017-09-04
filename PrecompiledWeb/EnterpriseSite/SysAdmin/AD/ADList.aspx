<%@ page language="C#" autoeventwireup="true" inherits="SysAdmin_AD_ADList, App_Web_3yvetyry" %>

<%@ Register Src="Pagination.ascx" TagName="Pagination" TagPrefix="uc3" %>

<%@ Register Src="../../Controls/TopButtons.ascx" TagName="TopButtons" TagPrefix="uc1" %>
<%@ Register Src="../../Controls/Pagination.ascx" TagName="Pagination" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../../Css/Login/css.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../Script/btn_click.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">			
			function Add_Node()
			{
				location.reload('ADAdd.aspx');
			}
			
			function ConfirmDel(){
				if (confirm('是否确定删除？')){
					return true;
				}
				else{
					return false;
				}
			}
			
			function Del_Node(id)
			{
				if (confirm('是否确定删除？'))
				{	
					var strxml="<root><ID>"+id+"</ID><UserAction>DelAD</UserAction></root>";
					SaveXMLDom("ADAct.aspx",strxml,"");
				}
			}
			
			function Del_Node1(){
				if (confirm('是否确定删除？')){	
					var e=document.getElementsByTagName("input");
					var id="";
					var j=0
					for(var i=0;i<e.length;i++){
						if (e[i].type=="checkbox" && e[i].id != "selall"){	
							if (e[i].checked==true){
								if(j==0)
									id=e[i].value;
								else
									id+=", " + e[i].value;
								j++;
							}
						}
					}
					if (id != ''){
						var strxml="<root><ID>"+id+"</ID><UserAction>DelAD</UserAction></root>";
						SaveXMLDom("ADAct.aspx",strxml,"");
					}
					else{
						alert("请至少选择一项！");
					}
				}
			}
			
			function Show_Node1(flag){
				var strconfirm="";
				if (flag==0){
					strconfirm="是否确认显示该Logo？";
				}
				else{
					strconfirm="是否确认取消显示？";
				}
				
				if (confirm(strconfirm)){	
					var e=document.getElementsByTagName("input");
					var id="";
					var j=0
					for(var i=0;i<e.length;i++){
						if (e[i].type=="checkbox" && e[i].id != "selall"){	
							if (e[i].checked==true){
								if(j==0)
									id=e[i].value;
								else
									id+=", " + e[i].value;
								j++;
							}
						}
					}
					if (id != ''){
						var strxml="<root><ID>"+id+"</ID><Flag>"+flag+"</Flag><UserAction>Show</UserAction></root>";
						//alert(strxml);
						SaveXMLDom1("ADAct.aspx",strxml,"操作成功！");
					}
					else{
						alert("请至少选择一项！");
					}
				}				
			}
			
			function Show_Node(Flag,id){
				var strxml="<root><ID>"+id+"</ID><Flag>"+Flag+"</Flag><UserAction>Show</UserAction></root>";
				SaveXMLDom1("ADAct.aspx",strxml,"操作成功！");
			}
			
			function CreateJS(id)
			{
				var strxml="<root><ID>"+id+"</ID><UserAction>CreateJS</UserAction></root>";
				SaveXMLDom1("ADAct.aspx",strxml,"操作成功");
			}	
		</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:TopButtons ID="TopButtons1" runat="server" />
			<table cellspacing="0" cellpadding="0" width="98%" border="0">
				<tr>
					<td align="center" colspan="2" height="8"></td>
				</tr>
				<tr>
					<td align="left" width="5%">&nbsp;<img height="23"alt='' src="../Images/dig.gif" width="23"/>
					</td>
					<td align="left" width="10%"><font color="#0a7ec5"><b>广告管理</b></font></td>
					<td align="right" width="90%">
						<input type="button" id="CreateAllJS" value="生成所有广告JS" class="input" style="CURSOR:hand"
							onclick="if (confirm('重新生成所有广告位的JS文件，确定执行此操作吗?')){CreateJS(0);return true;}else{return false;}"/>
						&nbsp; <strong>显示状态</strong>
						<asp:DropDownList ID="ADShow" Runat="server" AutoPostBack="True" OnSelectedIndexChanged="ADShow_SelectedIndexChanged">
							<asp:ListItem Value="0">所有广告</asp:ListItem>
							<asp:ListItem Value="显示">显示</asp:ListItem>
							<asp:ListItem Value="未显示">未显示</asp:ListItem>
						</asp:DropDownList>
						&nbsp; <strong>广告类型</strong>
						<asp:dropdownlist id="ADFlag" Runat="server" DataValueField="ID" DataTextField="TypeName" AutoPostBack="True" OnSelectedIndexChanged="ADFlag_SelectedIndexChanged1"></asp:dropdownlist>
						&nbsp; <strong>广告位置</strong>
						<asp:dropdownlist id="ADBoard" Runat="server" DataValueField="ID" DataTextField="BoardName" AutoPostBack="True" OnSelectedIndexChanged="ADBoard_SelectedIndexChanged1"></asp:dropdownlist>
					</td>
				</tr>
			</table>
			<asp:datagrid id="AD" runat="server" AllowSorting="True" PagerStyle-Visible="False" AutoGenerateColumns="False"
				AllowPaging="True" BorderWidth="0px" HorizontalAlign="Center" CellSpacing="1" CellPadding="2"
				BackColor="#D1E3FE" width="98%" OnItemCreated="AD_ItemCreated" OnItemDataBound="AD_ItemDataBound" OnSortCommand="AD_SortCommand1">
				<ItemStyle Height="22px" BackColor="#F6F9FF"></ItemStyle>
				<HeaderStyle HorizontalAlign="Center" Height="22px" ForeColor="#FF6633"></HeaderStyle>
				<Columns>
					<asp:TemplateColumn HeaderText="选择">
						<HeaderStyle HorizontalAlign="Center" ForeColor="#FF6633" Width="4%" CssClass="unnamed1"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<input type="checkbox" runat="server" id="selid" name="selid"/>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="ID" HeaderText="ID" SortExpression="ID" Visible="False">
						<HeaderStyle HorizontalAlign="Center" ForeColor="#FF6633" Width="4%" CssClass="unnamed1"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:HyperLinkColumn DataNavigateUrlField="Url" DataNavigateUrlFormatString="{0}" DataTextField="Title"
						SortExpression="Title" HeaderText="链接网站名称" DataTextFormatString="&#183;{0}">
						<HeaderStyle ForeColor="#FF6633" Width="12%" CssClass="unnamed1"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:HyperLinkColumn>
					<asp:BoundColumn DataField="Pic" HeaderText="广告图片" SortExpression="Pic">
						<HeaderStyle ForeColor="#FF6633" Width="50%" CssClass="unnamed1"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="BoardName" SortExpression="BoardName" HeaderText="广告位置">
						<HeaderStyle ForeColor="#FF6633" Width="8%" CssClass="unnamed1"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Flag" SortExpression="Flag" HeaderText="广告类型">
						<HeaderStyle ForeColor="#FF6633" Width="8%" CssClass="unnamed1"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="IsLock" SortExpression="IsLock" HeaderText="状态">
						<HeaderStyle ForeColor="#FF6633" Width="8%" CssClass="unnamed1"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="操作">
						<HeaderStyle HorizontalAlign="Center" ForeColor="#FF6633" Width="6%" CssClass="unnamed1"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:Image ImageUrl="../images/ny/edit.gif" AlternateText="修改" ID="Edit" Runat="server" Width="14"
								Height="14" BorderWidth="0"></asp:Image>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle Visible="False"></PagerStyle>
			</asp:datagrid>
			<table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
				<tr>
					<td align="center" height="30" style="width: 6%"><input id="selall" onclick="SelectAll()" type="checkbox"/>全选/反选
					</td>
					<td align="left" style="width: 7%"><input class="input" onclick="Show_Node1(0)" type="button" value="显示"/>&nbsp;
						<input class="input" onclick="Show_Node1(1)" type="button" value="不显示"/>&nbsp;
					</td>
					<td align="right" width="50%">
                        <uc3:Pagination id="Pagination1" runat="server">
                        </uc3:Pagination>&nbsp;</td>
				</tr>
			</table>
    </div>
    </form>
</body>
</html>
