<%@ page language="C#" autoeventwireup="true" inherits="IndexControls_YQLJ, App_Web_szj1oefn" %>
<style>td,th {font-family: 宋体;font-size: 12px;color: #333333;}
body {margin: 0px;font-family: 宋体;font-size: 12px;color: #333333;
        scrollbar-3dlight-color :#ffffff;
        scrollbar-highlight-color : #FFFFFF;
        scrollbar-face-color : #E5F2FA;
        scrollbar-arrow-color : #027BC4; 
		scrollbar-shadow-color : #FFFFFF;
		scrollbar-darkshadow-color : #FFFFFF;
		scrollbar-base-color : #FFFFFF;
		scrollbar-track-color : #FFFFFF;
}

a:link {color: #1E1E1E;text-decoration: none;}
a:visited {text-decoration: none;color: #1E1E1E;}
a:hover {text-decoration: underline;color: #FF6205;}
a:active {text-decoration: none;color: #FF6205;}</style>


<table width="92%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
  <tr>
    <td width="2%">&nbsp;</td>
    <td width="98%">
        <asp:DataList ID="DataList1" runat="server" Width="100%">
        <ItemTemplate>
        <table width="98%" border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td width="84%" height="25">·<a href='<%#Eval("Link") %>' target="_blank"><%#Eval("Title") %></a></td>
      </tr>
    </table>
        </ItemTemplate>
        </asp:DataList></td>
  </tr>
</table>
   
