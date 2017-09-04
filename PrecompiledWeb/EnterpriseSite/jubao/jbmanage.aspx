<%@ page language="C#" autoeventwireup="true" inherits="jubao_jbmanage, App_Web_txwcgdum" %>
<%@ Register TagPrefix="uc1" TagName="Pagination" Src="~/Controls/Pagination.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
     <script>
         function openWinDialog(url, arg) {
             return window.showModalDialog(url, arg, 'edge:raised;scroll:0;status:0;help:0;resizable:1;center:1;dialogWidth:800px;dialogHeight:600px;');
         }
     </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td  style=" background-color:#E6E6E6; height=29px; font-size:14px;  color:Red; font-weight:bold;">
                    网上举报</td>
            </tr>
            <tr>
                <td style=" font:12px;">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        EnableModelValidation="True" onrowcreated="GridView1_RowCreated" 
                        Width=100% onrowdatabound="GridView1_RowDataBound" 
                        onrowcommand="GridView1_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="所属单位">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("title") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="lxname" HeaderText="问题类别" />
                            <asp:BoundField DataField="bfyr" HeaderText="姓名" />
                            <asp:BoundField DataField="zw" HeaderText="职务" />
                            <asp:BoundField DataField="greattime" DataFormatString="{0:d}" 
                                HeaderText="举报时间" />
                            <asp:BoundField HeaderText="受理部门" DataField="title" />
                            <asp:TemplateField HeaderText="处理进度">
                                <ItemTemplate>
                                   <a href='javascript:void(0);' onclick='openWinDialog(<%#"\"jbshouli.aspx?id="+Eval("id")+"\""%>);' style=" text-decoration:none" target=_blank><asp:Label ID="Label1" runat="server" Text='<%#Eval("zhuangtai") %>'></asp:Label></a>  
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="删除">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('您确认要删除吗？')" CommandName="del" runat="server">删  除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle Font-Size="12px" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
            <td style=" font-size:12px;">
            <uc1:Pagination ID="pageBar" runat="server" PageSize="10"   OnPageIndexChanged="pageBar_PageIndexChanged"/>
            </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
