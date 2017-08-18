<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkerAdd.aspx.cs" Inherits="SysAdmin_Worker_WorkerAdd" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../../SysAdmin/Css/css.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="../JS/calendar.js"></script>
     <base target="_self"></base>
</head>
<body>
   <form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="80%" align="center" border="0">
				<tr>
					<td align="center" colSpan="2" height="8"></td>
				</tr>
				<tr>
					<td align="left" width="5%">&nbsp;<IMG height="23" src="../Images/dig.gif" width="23"></td>
					<td align="left"><font color="#0a7ec5"><b>专家门诊：</b></font></td>
				</tr>
			</table>
			<table cellSpacing="1" cellPadding="0" width="80%" align="center" bgColor="#d1e3fe" border="0">
				<tr bgColor="#f6f9ff">
					<td align="right" height="22"><font color="#ff6531">姓名：</font></td>
					<td style="width: 621px" ><asp:textbox id="txtName" runat="server" Width="192px"></asp:textbox><FONT color="red">*<asp:Label
                            ID="lbwarning" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label></FONT></td>
					<TD vAlign="top" width="110" rowSpan="8"><IMG id="uploadimage" style="WIDTH: 119px; HEIGHT: 165px" runat="server"></TD>
				</tr>
				<tr bgColor="#f6f9ff">
					<td align="right"><font color="#ff6531">职称：</font></td>
					<td style="width: 621px" ><asp:textbox id="txtBusiness" runat="server" Width="192px"></asp:textbox></td>
				</tr>
			
				<tr bgColor="#f6f9ff">
					<td  align="right" height="22"><font color="#ff6531">学历：</font></td>
					<td style="width: 621px" ><asp:textbox id="txtDegree" runat="server" Width="192px"></asp:textbox></td>
				</tr>
				<tr bgColor="#f6f9ff">
					<td  align="right" height="22"><font color="#ff6531">主攻学科：</font></td>
					<td style="width: 621px" ><asp:textbox id="txtScience" runat="server" Width="192px"></asp:textbox></td>
				</tr>
				<tr bgColor="#f6f9ff">
					<td align="right" height="22"><font color="#ff6531">研究方向：</font></td>
					<td style="width: 621px" ><asp:textbox id="txtArea" runat="server" Width="192px"></asp:textbox></td>
				</tr>
				<tr bgColor="#f6f9ff">
					<td  align="right" height="22"><font color="#ff6531">工作电话：</font></td>
					<td style="width: 621px" ><asp:textbox id="txtWorkTel" runat="server" Width="192px"></asp:textbox></td>
				</tr>
				<tr bgColor="#f6f9ff">
					<td align="right" height="22"><font color="#ff6531">工作邮箱：</font></td>
					<td style="width: 621px"><asp:textbox id="txtEmail" runat="server" Width="192px"></asp:textbox></td>
				</tr>
				
				<TR bgColor="#f6f9ff">
					<TD align="right"><FONT color="#ff6531">简历：</FONT></TD>
					<TD colSpan="2" >
                        &nbsp;<FCKeditorV2:FCKeditor ID="txtResume" runat="server" BasePath="../../FCKEditor/"
                            Height="400px">
                        </FCKeditorV2:FCKeditor>
                    </TD>
				</TR>
                <tr bgcolor="#f6f9ff">
                    <td align="right" style="width: 88px; height: 43px;">
                        <span style="color: #ff6531">照片：</span></td>
                    <td colspan="2" style="height: 43px">
                        <INPUT id="FileUp" type="file" onChange="javascript:FileChange(this.value);" size="40"
							name="FileURL" runat="server" clsss="input"><span style="color: #ff0000">*上传文件类型仅限 jpg | 
							gif | swf 格式<asp:textbox id="txtpicurlhide" runat="server" Visible="False"></asp:textbox></span></td>
                </tr>
                <tr bgcolor="#f6f9ff">
                    <td align="right" height="22" style="width: 88px">
                        <span style="color: #ff6531">专家类型：</span></td>
                    <td colspan="2">
                        &nbsp;<asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                            Width="250px">
                            <asp:ListItem Value="1">普通专家</asp:ListItem>
                            <asp:ListItem Value="2">博士专家</asp:ListItem>
                        </asp:RadioButtonList>&nbsp; <span style="color: #ff0000">*<asp:Label ID="lbwarning1" runat="server"
                            Visible="False"></asp:Label></span></td>
                </tr>
                <tr bgcolor="#f6f9ff">
                    <td align="right" height="22" style="width: 88px">
                        <span style="color: #ff6531">所属科室：</span></td>
                    <td colspan="2">
                        <asp:DropDownList ID="DropDownList1" runat="server" Width="150px">
                        </asp:DropDownList></td>
                </tr>
                <tr bgcolor="#f6f9ff">
                    <td align="right" height="22" style="width: 88px">
                        <span style="color: #ff6531">所获奖项：</span></td>
                    <td colspan="2">
                        <asp:TextBox ID="txtPrize" runat="server" Width="272px"></asp:TextBox></td>
                </tr>
                <tr bgcolor="#f6f9ff">
                    <td align="right" style="width: 88px; height: 23px;">
                        <span style="color: #ff6531">门诊时间：</span></td>
                    <td colspan="2" style="height: 23px">
                        <asp:TextBox ID="txtLookTime" runat="server" Width="273px"></asp:TextBox></td>
                </tr>
                <tr bgcolor="#f6f9ff">
                    <td align="right" style="width: 88px; height: 23px">
                        <span style="color: #ff6531">门诊电话：</span></td>
                    <td colspan="2" style="height: 23px">
                        <asp:TextBox ID="txtMZTel" runat="server" Width="272px"></asp:TextBox></td>
                </tr>
                <tr bgcolor="#f6f9ff">
                    <td align="right" style="width: 88px; height: 24px">
                        <span style="color: #ff6531">办公室电话：</span></td>
                    <td colspan="2" style="height: 24px">
                        <asp:TextBox ID="txtOfficeTel" runat="server" Width="272px"></asp:TextBox>
                        <asp:Label ID="lbAddDate" runat="server" Visible="False"></asp:Label></td>
                </tr>
                <tr bgcolor="#f6f9ff">
                    <td align="right" style="width: 88px; height: 23px">
                        <span style="color: #ff6531">排列顺序：</span></td>
                    <td colspan="2" style="height: 23px">
                        <asp:textbox id="txtSortID" runat="server" Width="88px">0</asp:textbox></td>
                </tr>
                <tr bgcolor="#f6f9ff">
                    <td align="right" style="width: 88px; height: 23px">
                        <span style="color: #ff6531">专家出诊：</span></td>
                    <td colspan="2" style="height: 23px">
                        &nbsp;<asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True"
                            OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" RepeatDirection="Horizontal"
                            Width="128px">
                            <asp:ListItem Value="1">是</asp:ListItem>
                            <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                <asp:panel ID="bb" runat="server" Visible=false>
                <tr bgcolor="#f6f9ff">
                    <td align="right" style="width: 88px; height: 23px">
                        <span style="color: #ff6531">专家特色：</span></td>
                    <td colspan="2" style="height: 23px">
                        <asp:TextBox ID="txtCharacter" runat="server" Width="322px"></asp:TextBox></td>
                </tr>
                <tr bgcolor="#f6f9ff">
                    <td align="right" style="width: 88px; height: 23px">
                        <span style="color: #ff6531">出诊时间：</span></td>
                    <td colspan="2" style="height: 23px">
                        <asp:TextBox ID="txtOutTime" runat="server" Width="321px"></asp:TextBox></td>
                </tr>
                <tr bgcolor="#f6f9ff">
                    <td align="right" style="width: 88px; height: 23px">
                        <span style="color: #ff6531">挂号费用：</span></td>
                    <td colspan="2" style="height: 23px">
                        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox></td>
                </tr>
                 <tr bgcolor="#f6f9ff">
                    <td align="right" style="width: 88px; height: 23px">
                        <span style="color: #ff6531">排序号：</span></td>
                    <td colspan="2" style="height: 23px">
                        <asp:TextBox ID="txtSort" runat="server"></asp:TextBox></td>
                </tr>
                </asp:panel>
				<tr bgColor="#f6f9ff">
					<td align="center" colSpan="3" height="25"><asp:button id="Button2" runat="server" Width="65" CssClass="input" Text="确定" OnClick="Button2_Click"></asp:button>
						<input class="input" type="reset" value=" 重 填 " name="reset">
					</td>
				</tr>
				<TR bgColor="#f6f9ff">
					<TD align="left" colSpan="3" height="25"></TD>
				</TR>
			</table>
		</form>
</body>
</html>
