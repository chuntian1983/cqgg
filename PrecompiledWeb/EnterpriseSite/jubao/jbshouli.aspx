<%@ page language="C#" autoeventwireup="true" inherits="jubao_jbshouli, App_Web_txwcgdum" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <base target="_self"></base>
    <style type="text/css">
        .style1
        {
            width: 100%;
            
        }
        .tdy{ background-color:#E9EEF1; height:30px;  text-align:right;
               font-size:13px; width:70px;
              }
              .tdy2{ background-color:#E9EEF1; height:30px;  text-align:right;
               font-size:13px; width:120px;
        }
        .style2
        {
            background-color: #E9EEF1;
            height: 81px;
            text-align: right;
            font-size: 13px;
            width: 70px;
        }
        .style3
        {
            height: 81px;
        }
        .tdt{ height:31px; background-color:#ADD9FC; font-size:14px; font-weight:bold;
              color:#1243C4; text-align:left; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td>
                    <table class="style1">
                        <tr bgcolor="#319BE7">
                            <td height="30px" colspan="6">
                                <asp:Label ID="wtlx" runat="server" Text="Label" ForeColor="White"></asp:Label></td>
                        </tr>
                        <tr>
                            <td height="30px" class="tdy">
                                反映人：</td>
                            <td>
                                <asp:Label ID="fyr" runat="server" Text=" "></asp:Label>
                            </td>
                            <td class=tdy>
                                联系地址：</td>
                            <td>
                                <asp:Label ID="dizhi" runat="server" Text=" "></asp:Label>
                            </td>
                            <td class=tdy>
                                联系电话：</td>
                            <td>
                                <asp:Label ID="lxdh" runat="server" Text=" "></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="30px" class="tdy">
                                被反映人：</td>
                            <td>
                                <asp:Label ID="bfyr" runat="server" Text=" "></asp:Label>
                            </td>
                            <td class=tdy>
                                单位：</td>
                            <td>
                                <asp:Label ID="suozdw" runat="server" Text=" "></asp:Label>
                            </td>
                            <td class=tdy>
                                所在地区：</td>
                            <td>
                                <asp:Label ID="szdq" runat="server" Text=" "></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                举报内容：</td>
                            <td class="style3" colspan="5">
                                <asp:Label ID="wtnr" runat="server" Text=" "></asp:Label>
                            </td>
                        </tr>
                        </table>
                </td>
            </tr>
            <tr>
                <td style=" text-align:right;">
                    &nbsp;
                    <asp:ImageButton ID="ImageButton1" runat="server" 
                        ImageUrl="~/jubao/images/10_r2_c2.jpg" onclick="ImageButton1_Click" />
&nbsp;<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/jubao/images/10_r2_c4.jpg" 
                        onclick="ImageButton2_Click" />
&nbsp;<asp:ImageButton ID="ImageButton3" runat="server" 
                        OnClientClick="return confirm('您确认要直接办理吗？')" 
                        ImageUrl="~/jubao/images/10_r2_c6.jpg" onclick="ImageButton3_Click" />
&nbsp;<asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/jubao/images/10_r2_c8.jpg" 
                        onclick="ImageButton4_Click" />
                </td>
            </tr>
            <tr runat="server" id="trsq" visible=false>
                <td>
                    <table class="style1">
                        <tr>
                            <td  class=tdt>&nbsp;&nbsp;授权处理
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <table class="style1">
                                    <tr>
                                        <td class=tdy>
                                            授权：</td>
                                        <td>
                                            <asp:DropDownList ID="DropDownList1" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td class=tdy>
                                            完成期限：</td>
                                        <td>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                            个工作日</td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"  align="center">
                    <asp:ImageButton ID="ImageButton5" runat="server" 
                        ImageUrl="~/jubao/images/10_r2_c2.jpg" onclick="ImageButton5_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server" id="trzjcl" visible=false>
                <td>
                    <table class="style1">
                        <tr>
                            <td  class=tdt>&nbsp;&nbsp;直接处理
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <table class="style1">
                                    <tr>
                                        <td class=tdy2>
                                            处理人：</td>
                                        <td>
                                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                        </td>
                                        <td class=tdy2>
                                            处理期限：</td>
                                        <td>
                                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                            个工作日</td>
                                    </tr>
                                    <tr>
                                        <td class=tdy2>
                                            处理结果：</td>
                                        <td colspan="3">
                                            <asp:TextBox ID="TextBox4" runat="server" Height="73px" TextMode="MultiLine" 
                                                Width="727px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"  align="center">
                                            <asp:ImageButton ID="ImageButton6" runat="server" 
                                                ImageUrl="~/jubao/images/10_r2_c4.jpg" onclick="ImageButton6_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server" id="trjbfk" visible=false>
                <td>
                    <table class="style1">
                        <tr>
                            <td  class=tdt>&nbsp;&nbsp;举报反馈
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <table class="style1">
                                    <tr>
                                        <td class=tdy2>
                                            反映问题：</td>
                                        <td>
                                            <asp:Label ID="wtnr2" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class=tdy2>
                                            反馈结果：</td>
                                        <td>
                                            <asp:TextBox ID="TextBox7" runat="server" Height="73px" TextMode="MultiLine" 
                                                Width="727px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2"  align="center">
                                            <asp:ImageButton ID="ImageButton7" runat="server" 
                                                ImageUrl="~/jubao/images/10_r2_c8.jpg" onclick="ImageButton7_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
