<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SubMenu.aspx.cs" Inherits="SysAdmin_Desktop_Menu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <script type="text/javascript" src="../js/prototype.js"></script>
   <%-- <script type="text/javascript">
    function switchMenu(obj)
    {
        $A($('menuList').childNodes).each(function(table){
            $($(table).firstChild.firstChild).next().hide();});
        $(obj).next().show();     
    }
    function menuImageOver(obj)
    {
        $(obj).setStyle({border:'1px outset #ffffff'});
    }
    function menuImageOut(obj)
    {
        $(obj).setStyle({border:'1px none black'});
    }
    function go(link)
    {
        window.top.frames["mainFrame"].location.href=link;
    }
    </script>--%>
      <script type="text/javascript">
    var pars=document.URL.parseQuery();
    if(pars.s=='o')window.top.openMenu();
    if(pars.s=='c')window.top.closeMenu();

    function switchMenu(obj)
    {
        $A($('menuList').childNodes).each(function(table){
            $($(table).firstChild.firstChild).next().hide();});
        $(obj).next().show();     
    }
    function menuImageOver(obj)
    {
        $(obj).setStyle({border:'1px outset #ffffff'});
    }
    function menuImageOut(obj)
    {
        $(obj).setStyle({border:'1px none black'});
    }
    function go(link)
    {
        window.top.frames["mainFrame"].location.href=link;
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table  width="100%" border="0" cellspacing="0" cellpadding="0" height="100%" >
  <tr>
    <td bgcolor="<%=_backgroundColor %>"  height="<%=_height %>" style="border-style:solid;border-color:#4180C6;border-width:0px 1px;" align="center" valign="top" width="<%=_width %>">
      <span id="menuList" style="color:#ffffff;font-family:宋体;" >
     <%=_content %>
      </span> </td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>
