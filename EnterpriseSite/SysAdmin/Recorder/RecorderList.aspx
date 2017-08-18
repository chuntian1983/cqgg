<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecorderList.aspx.cs" Inherits="SysAdmin_Recorder_RecorderList" %>
<%@ Register TagPrefix="uc1" TagName="Pagination" Src="~/Controls/Pagination.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>档案资料</title>
     <LINK href="../Css/css.css" type="text/css" rel="stylesheet">
       <script type="text/javascript" src="../JS/calendar.js"></script>
     <script type="text/jscript" src="../js/prototype.js"></script>
      <script>
      function openWinDialog(url,arg)
      {
        return window.showModalDialog(url,arg, 'edge:raised;scroll:0;status:0;help:0;resizable:1;dialogWidth:800px;dialogHeight:300px;');
      }
      
      function selectPic(showReturnObj)
      {
//            openWinDialog('../DownLoad/FileList.aspx?CategoryName=<%=HttpUtility.UrlEncode("档案资料") %>',$(showReturnObj));
            openWinDialog('../DownLoad/RecordList.aspx?rdn='+Math.random(),$(showReturnObj));
                
      }   
   
     </script>
    <base target="_self"></base>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table cellSpacing="0" cellPadding="0" width="800" border="0" align="center">
				<tr><td style="height: 1px">
                    <strong><span style="color: #0a7ec5">个人档案信息列表：</span></strong></td></tr>
         <tr>
             <td style="height: 1px">
                 <strong><span style="color: #0a7ec5">按姓名查询：<asp:TextBox ID="txtName" runat="server" Width="75px"></asp:TextBox>
                     <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="确定" />
                     <asp:TextBox ID="txtImageLink" runat="server" onfocus="this.blur();" Width="239px"></asp:TextBox>
                     <input id="btnUploadPic" runat="server" onclick="openWinDialog('../DownLoad/FileUpLoad.aspx');"
                         title="上传Excel文件" type="button" value="上传Excel文件" />
                     <input onclick="selectPic('txtImageLink');" title="选择文件" type="button" value="选择Excel文件,导入数据库" />
                    
         </tr>
				<tr><td >
				<asp:GridView ID="gvRecorderList" runat="server" AutoGenerateColumns="False"  BackColor="#D1E3FE" ForeColor="Blue" BorderColor="#1AA0D4" Width="100%" AllowPaging="True" PagerSettings-Visible="false" >
							
							<AlternatingRowStyle BackColor="#ECF4FF" />
							<RowStyle Font-Names="宋体" HorizontalAlign="Center" Height="25px" BackColor="#F7F9FF" />
					
							<HeaderStyle HorizontalAlign="Center" Height="25px" ForeColor="#0066FF" CssClass="unnamed1" VerticalAlign="Middle"
								BackColor="#D1E3FE"></HeaderStyle>
				<Columns>
				<asp:BoundField HeaderText="档案号"  DataField="RecorderID"/>
				<asp:BoundField HeaderText="姓名" DataField="Name" />
				<asp:BoundField HeaderText="添加时间" DataField="AddTime" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="False"/>
				<asp:TemplateField HeaderText="操作">
				<ItemTemplate>
                    &nbsp;<asp:HyperLink id="Hyperlink2" runat="server" NavigateUrl='<%# "RecorderAdd.aspx?RecorderId=" + DataBinder.Eval(Container.DataItem, "ID") %>' Visible="<%#this.AllowModify%>" Text="查看＆修改" ImageUrl="../images/ny/edit.gif">
											</asp:HyperLink>
				<asp:ImageButton ID="ibtnDel" runat="server" ToolTip="删除"  ImageUrl="../images/ny/del.gif" CommandArgument='<%#Eval("ID")%>'  OnCommand="ibtnDel_Command" Visible="<%#this.AllowDel%>" OnClientClick="return confirm('你确认要删除吗!');"/>
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
