<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecorderAdd.aspx.cs" Inherits="SysAdmin_Recorder_RecorderAdd" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <LINK href="../Css/css.css" type="text/css" rel="stylesheet">
    <script type="text/javascript" src="../JS/calendar.js"></script>
　　<script type="text/jscript" src="../js/prototype.js"></script>
</head>
	<body >
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="80%" align="center" border="0">
				<tr>
					<td align="center" colSpan="2" height="8"></td>
				</tr>
				<tr>
					<td align="left" width="5%" style="height: 25px">&nbsp;<IMG height="23" src="../Images/dig.gif" width="23"></td>
					<td align="left" style="height: 25px"><font color="#0a7ec5"><b>个人档案信息<asp:Label ID="lbState" runat="server"></asp:Label>：<asp:Label
                            ID="lbID" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="lbAddDate" runat="server" Visible="False"></asp:Label></b></font></td>
				</tr>
			</table>
			<table cellSpacing="1" cellPadding="0" width="80%" align="center" bgColor="#d1e3fe" border="0">
				<tr bgColor="#f6f9ff">
					<td align="right" height="22" ><font color="#ff6531">档案号：</font></td>
					<td>
                        <asp:TextBox ID="txtRecorderId" runat="server" Width="268px"></asp:TextBox></td>
				</tr>
				<tr bgColor="#f6f9ff">
					<td align="right" style="height: 21px" ><font color="#ff6531">姓 名：</font></td>
					<td style="height: 21px">
                        <asp:TextBox ID="txtName" runat="server" Width="268px"></asp:TextBox></td>
				</tr>
				<asp:panel id="aa" Visible="false" runat="server" >
				<tr bgColor="#f6f9ff">
					<td align="right" style="height: 23px" ><font color="#ff6531">学历：</font></td>
					<td style="height: 23px">
                        <asp:TextBox ID="txtDegree" runat="server" Width="268px"></asp:TextBox></td>
				</tr>
				
				<tr bgColor="#f6f9ff">
					<td align="right" height="22"><font color="#ff6531">毕业时间与院校：</font></td>
					<td>
                        <asp:TextBox ID="txtGTSchool" runat="server" Width="268px"></asp:TextBox></td>
				</tr>
                <tr bgcolor="#f6f9ff">
                    <td align="right" style="height: 23px">
                        <font color="#ff6531">毕业专业：</font></td>
                    <td style="height: 23px">
                        <asp:TextBox ID="txtSubject" runat="server" Width="267px"></asp:TextBox></td>
                </tr>
                <tr bgcolor="#f6f9ff">
                    <td align="right" style="height: 23px">
                        <font color="#ff6531">转正情况：</font></td>
                    <td style="height: 23px">
                        <asp:TextBox ID="txtZZQK" runat="server" Width="267px"></asp:TextBox></td>
                </tr>
                <tr bgcolor="#f6f9ff">
                    <td align="right" style="height: 23px">
                        <font color="#ff6531">职称情况：</font></td>
                    <td style="height: 23px">
                        <asp:TextBox ID="txtZCQK" runat="server" Width="267px"></asp:TextBox></td>
                </tr>
                <tr bgcolor="#f6f9ff">
                    <td align="right" style="height: 23px">
                        <font color="#ff6531">职称证书编号：</font></td>
                    <td style="height: 23px">
                        <asp:TextBox ID="txtZSID" runat="server" Width="267px"></asp:TextBox></td>
                </tr>
                <tr bgcolor="#f6f9ff">
                    <td align="right" style="height: 23px">
                        <font color="#ff6531">工作单位情况：</font></td>
                    <td style="height: 23px">
                        <asp:TextBox ID="txtCompanyInfo" runat="server" Width="267px"></asp:TextBox></td>
                </tr>
                <tr bgcolor="#f6f9ff">
                    <td align="right" style="height: 23px">
                        <font color="#ff6531">统筹费：</font></td>
                    <td style="height: 23px">
                        <asp:TextBox ID="txtTCF" runat="server" Width="267px"></asp:TextBox></td>
                </tr>
                <tr bgcolor="#f6f9ff">
                    <td align="right" style="height: 23px">
                        <font color="#ff6531">统筹编号：</font></td>
                    <td style="height: 23px">
                        <asp:TextBox ID="txtTCID" runat="server" Width="267px"></asp:TextBox></td>
                </tr>
                <tr bgcolor="#f6f9ff">
                    <td align="right" style="height: 23px">
                        <font color="#ff6531">工资情况：</font></td>
                    <td style="height: 23px">
                        <asp:TextBox ID="txtGZQK" runat="server" Width="267px"></asp:TextBox></td>
                </tr>
                </asp:panel>
                <tr bgcolor="#f6f9ff">
                    <td align="right" style="height: 23px">
                        <font color="#ff6531">档案费：</font></td>
                    <td style="height: 23px">
                        <asp:TextBox ID="txtPay" runat="server" Width="267px"></asp:TextBox></td>
                </tr>
				<tr bgColor="#f6f9ff">
					<td align="right" height="22"><font color="#ff6531">调入前单位：</font></td>
					<td>
                        <asp:TextBox ID="txtYDW" runat="server" Width="267px"></asp:TextBox>&nbsp;
                    </td>
				</tr>
				<tr bgColor="#f6f9ff">
					<td align="right" style="height: 23px"><font color="#ff6531">现单位：</font></td>
					<td style="height: 23px">
                        <asp:TextBox ID="txtXDW" runat="server" Width="267px"></asp:TextBox></td>
				</tr>
				<tr bgColor="#f6f9ff">
					<td  colSpan="2" style="height: 25px" align="center">
                        <asp:Button ID="Button1" runat="server" CssClass="input" Text="提　交" OnClick="Button1_Click" />
						<input class="input" type="reset" value="返　回" name="reset"  onclick="javascript:window.history.go(-1);/">
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>