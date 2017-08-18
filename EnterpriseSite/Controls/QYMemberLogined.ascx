<%@ Control Language="C#" AutoEventWireup="true" CodeFile="QYMemberLogined.ascx.cs" Inherits="Controls_QYMemberLogined" %>
<script language="javascript" type="text/javascript">
// <!CDATA[



// ]]>
</script>

<table width="182" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td height="98" valign="top" background="../images/hy.jpg"><table width="91" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="91" height="10"></td>
      </tr>
    </table>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td height="25" align="center" class="font4">企业用户登录</td>
        </tr>
      </table>
      <table width="91" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="91" height="5"></td>
        </tr>
      </table>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td align="center" class="font1" style="height: 25px"><span class="height">欢迎您：<asp:Label ID="lbCompany" runat="server" Text=""></asp:Label></span></td>
        </tr>
        <tr>
          <td height="25" align="center"><a href="LoginExit1.aspx"></a>
              <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="注销登录" /></td>
        </tr>
      </table></td>
  </tr>
  <tr>
    <td valign="top"><img src="../images/hy1.jpg" width="182" height="18" /></td>
  </tr>
  <tr>
    <td valign="top">
     <table width="100%" border="0" cellspacing="0" cellpadding="0">
       <tr>
          <td width="2%" height="25">&nbsp;</td>
          <td ><iframe marginheight="0" marginwidth="0" scrolling="no" width="100%" height="180" frameborder="0"  src='<%=this.ResolveClientUrl("~/indexcontrols/GWorRCSS.aspx")%>'></iframe></td>
        </tr>
      </table>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td height="25" colspan="2" align="center" bgcolor="#0472C1"><span class="font4">人才登记信息维护</span></td>
        </tr>
        <tr>
          <td height="8" colspan="2" align="center"></td>
        </tr>
        <tr>
          <td width="12%" height="25">&nbsp;</td>
          <td width="88%">·<a href="../Web/QYMemberInfo.aspx">单位基本信息</a></td>
        </tr>
        <tr>
          <td height="25">&nbsp;</td>
          <td>·<a href="../Web/QYMemberZP.aspx">添加招聘岗位</a></td>
        </tr>
        <tr>
          <td height="25">&nbsp;</td>
          <td>·<a href="../Web/QYMemberZPGL.aspx">招聘岗位管理</a></td>
        </tr>
        <tr>
          <td height="25">&nbsp;</td>
          <td>·<a href="../Web/QYMemberYPGL1.aspx">应聘人才管理</a></td>
        </tr>
        <tr>
          <td height="25">&nbsp;</td>
          <td>·<a href="../Web/QYMemberPWD.aspx">修改密码</a></td>
        </tr>
        <tr>
          <td height="25">&nbsp;</td>
          <td>·<a href="../Web/QYMemberCZSM.aspx">操作说明 </a></td>
        </tr>
      </table>
     
      <table width="91" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="91" height="5"></td>
        </tr>
      </table></td>
  </tr>
  
</table>