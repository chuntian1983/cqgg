<%@ control language="C#" autoeventwireup="true" inherits="Controls_NetPage_fz, App_Web_yqweqvkc" %>
<div align="right">
    <table border="0" cellpadding="0" cellspacing="0" align="right" bgcolor="DDF4FA" Width="100%">
        <tr>
            <td align="right" valign="bottom">
                共
                <asp:Label ID="lblDataCount" runat="server" CssClass="cheng" ForeColor="Red">1</asp:Label>
                条记录 | 页次:
                <asp:Label ID="lblcurrentpage" runat="server" ForeColor="Red">1</asp:Label>/
                <asp:Label ID="lblpagecount" runat="server" CssClass="cheng">1</asp:Label>页 
                [<asp:LinkButton ID="hlfirst" runat="server" CommandName="first" OnCommand="Page_OnClick">最前页</asp:LinkButton>]
                [<asp:LinkButton ID="hlback" runat="server" CommandName="prev" OnCommand="Page_OnClick">上一页</asp:LinkButton>]
                [<asp:LinkButton ID="hlnext" runat="server" CommandName="next" OnCommand="Page_OnClick">下一页</asp:LinkButton>]
                [<asp:LinkButton ID="hllast" runat="server" CommandName="last" OnCommand="Page_OnClick">最末页</asp:LinkButton>]
                转到 <asp:TextBox ID="txtsearch" runat="server" CssClass="form3" Width="20px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="跳转页码请输入数字！"
                    ControlToValidate="txtsearch" Display="None" ValidationExpression="\d{0,}"></asp:RegularExpressionValidator>
                <asp:Button ID="Go" Text="Go" CommandName="gotopage" OnCommand="Page_OnClick" runat="server"
                    CssClass="form1" />&nbsp;
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
        ShowSummary="False"></asp:ValidationSummary>
</div>