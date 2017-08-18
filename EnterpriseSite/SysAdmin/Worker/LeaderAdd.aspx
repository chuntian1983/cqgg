<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeaderAdd.aspx.cs" Inherits="SysAdmin_Worker_LeaderAdd" %>

<%@ Register Src="../../Controls/Pagination.ascx" TagName="Pagination" TagPrefix="uc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../../SysAdmin/Css/css.css" rel="stylesheet" type="text/css" />
      <script type="text/javascript" src="../JS/calendar.js"></script>
     <script type="text/javascript">
      function openWinDialog(url,arg)
      {
        return window.showModalDialog(url,arg, 'edge:raised;scroll:1;status:0;help:0;center:1;resizable:1;dialogWidth:900px;dialogHeight:650px;');
      }
     </script>
      <base target="_self"></base>
</head>
<body>
   <form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="80%" align="center" border="0">
				<tr>
					<td align="center" colSpan="2" height="8"></td>
				</tr>
				<tr>
					<td align="left" width="5%"><IMG height="23" src="../Images/dig.gif" width="23"></td>
					<td align="left"><font color="#0a7ec5"><b>领导介绍：</b></font></td>
				</tr>
			</table>
			<table cellSpacing="1" cellPadding="0" width="80%" align="center" bgColor="#d1e3fe" border="0">
				<tr bgColor="#f6f9ff">
					<td align="right" height="22"><font color="#ff6531">姓名：</font></td>
					<td style="width: 621px" ><asp:textbox id="txtName" runat="server" Width="192px"></asp:textbox><FONT color="red">*<asp:Label
                            ID="lbwarning" runat="server" Visible="False"></asp:Label></FONT></td>
					<TD vAlign="top" width="110" rowSpan="7"><IMG id="uploadimage" style="WIDTH: 119px; HEIGHT: 143px" runat="server"></TD>
				</tr>
				<tr bgColor="#f6f9ff">
					<td align="right"><font color="#ff6531">职位：</font></td>
					<td style="width: 621px" ><asp:textbox id="txtBusiness" runat="server" Width="192px"></asp:textbox></td>
				</tr>
			
				<tr bgColor="#f6f9ff">
					<td  align="right" style="height: 23px"><font color="#ff6531">电话：</font></td>
					<td style="width: 621px; height: 23px;" ><asp:textbox id="txtTel" runat="server" Width="192px"></asp:textbox></td>
				</tr>
				<tr bgColor="#f6f9ff">
					<td  align="right" height="22"><font color="#ff6531">电子邮件：</font></td>
					<td style="width: 621px" ><asp:textbox id="txtEmail" runat="server" Width="192px"></asp:textbox></td>
				</tr>
				<tr bgColor="#f6f9ff">
					<td align="right" height="22"><font color="#ff6531">分管范围：</font></td>
					<td style="width: 621px" ><asp:textbox id="txtArea" runat="server" Width="192px"></asp:textbox></td>
				</tr>
				<tr bgColor="#f6f9ff">
					<td  align="right" height="22"><font color="#ff6531">学术专长：</font></td>
					<td style="width: 621px" ><asp:textbox id="txtScience" runat="server" Width="192px"></asp:textbox></td>
				</tr>
				
				<TR bgColor="#f6f9ff">
					<TD align="right"><FONT color="#ff6531">简历：</FONT></TD>
					<TD colSpan="2" >
                        <FCKeditorV2:FCKeditor ID="txtResume" runat="server" BasePath="../../FCKEditor/"
                            Height="400px">
                        </FCKeditorV2:FCKeditor>
                       
                    </TD>
				</TR>
                <tr bgcolor="#f6f9ff">
                    <td align="right" height="22" style="width: 88px">
                        <span style="color: #ff6531">照片：</span></td>
                    <td colspan="2">
                        <INPUT id="FileUp" type="file" onChange="javascript:FileChange(this.value);" size="40"
							name="FileURL" runat="server" clsss="input"><span style="color: #ff0000">*上传文件类型仅限 jpg | 
							gif | swf 格式<asp:textbox id="txtpicurlhide" runat="server" Visible="False"></asp:textbox></span></td>
                </tr>
                <tr bgcolor="#f6f9ff">
                    <td align="right" style="width: 88px; height: 23px">
                        <span style="color: #ff6531">排列顺序：</span></td>
                    <td colspan="2" style="height: 23px">
                        <asp:textbox id="txtSortID" runat="server" Width="88px">0</asp:textbox>
                        <asp:Label ID="lbAddDate" runat="server" Visible="False"></asp:Label></td>
                </tr>
				<tr bgColor="#f6f9ff">
					<td align="center" colSpan="3" height="25"><asp:button id="Button2" runat="server" Width="65" CssClass="input" Text="确定" OnClick="Button2_Click"></asp:button>
						<input class="input" type="reset" value=" 重 填 " name="reset">
                        </td>
				</tr>
				<TR bgColor="#f6f9ff">
					<TD align="left" colSpan="3" height="25">
                        <asp:GridView ID="gvArticleList" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            BackColor="#D1E3FE" BorderColor="#1AA0D4" ForeColor="Blue"
                            PagerSettings-Visible="false" Width="100%" Visible="False">
                            <PagerSettings Visible="False" />
                            <Columns>
                                <asp:BoundField DataField="Title" HeaderText="标    题" />
                                <asp:BoundField DataField="PublicationUnit" HeaderText="作　　　者" />
                                <asp:BoundField DataField="ReleaseDate" DataFormatString="{0:yyyy-MM-dd}" HeaderText="发　布　时　间"
                                    HtmlEncode="False" />
                                <asp:TemplateField HeaderText="操　　作">
                                    <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="../images/ny/edit.gif" NavigateUrl='<%#"LeadSpeakAdd.aspx?ArticleId="+Eval("ArticleId")%>' Text="修改">
                                    </asp:HyperLink>
                                    &nbsp;<asp:ImageButton ID="ibtnDel"
                                                runat="server" CommandArgument='<%#Eval("ArticleId")%>' ImageUrl="../images/ny/del.gif"
                                                OnClientClick="javascript:return confirm('你确实要删除吗');" OnCommand="ibtnDel_Command"
                                                ToolTip="删除" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle BackColor="#F7F9FF" Font-Names="宋体" Height="25px" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#D1E3FE" CssClass="unnamed1" ForeColor="#0066FF" Height="25px"
                                HorizontalAlign="Center" VerticalAlign="Middle" />
                            <AlternatingRowStyle BackColor="#ECF4FF" />
                        </asp:GridView>
                        <uc1:Pagination ID="pageBar" runat="server" PageSize="10"   OnPageIndexChanged="pageBar_PageIndexChanged"/>
                    </TD>
				</TR>
			</table>
		</form>
</body>
</html>
