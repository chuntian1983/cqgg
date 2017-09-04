<%@ page language="C#" autoeventwireup="true" inherits="SysAdmin_boot_list, App_Web_tre30cr3" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
<title></title>

   
    <link href="../../css/bootstrap.min.css" rel="stylesheet" />
      <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/bootstrap.min.js"></script>

 <script type="text/javascript">
     function OnCheckBoxClick() {
         var checkbox = document.getElementById('cboxnb'); //

         if (checkbox.checked) {
             $("#dataTab input:checkbox").each(function () { this.checked = true; });
         } else {
             $("#dataTab input:checkbox").each(function () { this.checked = false; });
         }

     }       
 </script>
 <script type="text/javascript">


        var tt = 0;
        $(function () {
            function show() {
                tt = tt + 1;
                for (var i = 0; i < $('tr').length; i++) {
                    //var starttime = new Date($('tr').eq(i).find('td').eq(0).text()).getTime();
                    var starttime = new Date();
                    var endtime = new Date($('tr').eq(i).find('td').eq(6).text()).getTime()
                    var overtime = endtime - starttime - tt * 1000;
                    // var overtime = endtime - starttime;  
                    var fz = parseInt(overtime / 60000);
                    var mz = parseInt((overtime - (fz * 60000)) / 1000);
                    var str = '0分0秒';
                    var str1 = fz + '分' + mz + '秒';
                    if (overtime <= 0) {
                        $('tr').eq(i).find('td').eq(7).html("<span style='color:red'>" + str + "</span>");
                    }
                    else {
                        $('tr').eq(i).find('td').eq(7).html("<span style='color:red'>" + str1 + "</span>");
                    }


                }


            }
            setInterval(show, 1000); // 注意函数名没有引号和括弧！  
            // 使用setInterval("show()",3000);会报“缺少对象”  


        });  
</script>
</head>
<body>
<form runat="server" id="form1">
 
<div class="panel panel-default">
  <div class="panel-heading">竞价项目信息搜索</div>
  <div class="panel-body">
    
            竞价项目信息标题：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            
            
            <asp:Button ID="Button5" CssClass="btn btn-primary "  runat="server" Text="搜  索" onclick="Button5_Click" />
  </div>
</div>

<div class="panel panel-default">
  <div class="panel-heading">
    <h3 class="panel-title">竞价项目信息列表</h3>
  </div>
  <div class="panel-body">
   <div class="btn-group">
	
          <asp:Button ID="Button1" runat="server" Text="新建" CssClass="btn btn-primary"  
                CausesValidation="False" onclick="Button1_Click" />
                <asp:Button ID="btnedit" runat="server" Text="竞  价" CssClass="btn btn-primary" 
                onclick="btnedit_Click" />
		 <asp:Button ID="btndel" runat="server" Text="删除" Visible="false" CssClass="btn btn-primary"  OnClientClick="return confirm('你确认要删除所选项，删除后不可恢复！')"
                onclick="btndel_Click" />
		
		
</div>
<div class="t_title">
	<table class="table table-bordered"  border="0" cellpadding="0" cellspacing="0" id="dataTab">
		  <thead>
              <tr>

			<th style=" text-align:center;"><input type="checkbox" name="cboxGroup" id="cboxnb" value="0"   onclick="OnCheckBoxClick();" /></th>
			<th class="t_cow1">编号</th>
			<th>项目名称</th>
			<th class="t_cow2">权属</th>
			<th class="t_cow2">竞价起价</th>
			<th >竞价状态</th>
			<th class="t_cow3">竞价截止时间</th>
            <th >竞价倒计时</th>
			</tr>
		</thead>
        <tbody>
        <asp:Repeater ID="rep" runat="server" >
                    <ItemTemplate>
                        <tr>
                            <td  style="text-align:center;">
                            <asp:Label ID="lbid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"id")%>' Visible="false" ></asp:Label>
                                
                                    <asp:CheckBox ID="cbx" runat="server"  />
                            </td>
                            <td>
                                <%# Eval("id")%>
                            </td>
                            <td>
                                <%# Eval("bidname")%>
                            </td>
                            <td>
                                <asp:Label ID="lbxwlx" runat="server" Text='<%# Eval("Ownership")%>'></asp:Label>
                            </td>
                            <td>
                                <%# Eval("Jbqbj")%>
                            </td>
                            
                            <td>
                                <asp:Label ID="lbxmzt" runat="server" Text='<%# Eval("Jbzt")%>'></asp:Label>
                            </td>
                           
                            <td>
                                <%#DateTime.Parse(Eval("Jbjzsj").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%>
                            </td>
                            <td></td>
                            
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
		
        </tbody>

	</table>

</div>
<div class="panelBar pager">
            <webdiyer:AspNetPager ID="pg" OnPageChanged="Pager_PageChanged" runat="server" ShowBoxThreshold="5" ShowCustomInfoSection="Left"
                HorizontalAlign="Right"  CustomInfoClass="pager-1"
                CustomInfoTextAlign="Left" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"
                PrevPageText="上一页" CustomInfoHTML="数据：%RecordCount%条  第%CurrentPageIndex%/%PageCount%页 "
                AlwaysShow="true" PageIndexBoxClass="homeLogin" PageSize="20" PageIndexBoxStyle="pagerindexbox"
                PageIndexBoxType="TextBox" ShowPageIndexBox="Always" SubmitButtonText="Go">
            </webdiyer:AspNetPager>
            <asp:HiddenField ID="hdpage" runat="server" Value="1" />
        </div>
  </div>
</div>
</form>
   
</body>
</html>
