<%@ Page Language="C#" AutoEventWireup="true" CodeFile="upload.aspx.cs" Inherits="SysAdmin_AD_upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>上传文件</title>

    <script type="text/jscript" language="javascript">			
		function FileChange(Value)
		{
            flag=false;
            document.all.uploadimage.alt="";
            document.all.uploadimage.src=Value;
        }		
    </script>


    <link href="../../Css/Login/css.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table id="table1" cellspacing="0" cellpadding="0" width="100%" align="center">
                <tr>
                    <td>
                        <table id="table2" cellspacing="0" cellpadding="0" width="100%" align="center">
                            
                                <asp:panel id="FileInfo" runat="server" Visible="false">
                                    <tr>
                                        <td style="height: 14px">
                                            文件上传成功!</td>
                                    </tr>
                                    <tr>
                                        <td style="height: 18px">
                                            文件大小：
                                            <asp:Label ID="FSize" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            文件名称：
                                            <asp:Label ID="FName" runat="server"></asp:Label></td>
                                    </tr>
                                    </asp:panel>
                        </table>
                        <table id="table3" cellspacing="0" cellpadding="0" width="100%" align="center">
                           
                               <asp:panel id="PanelUp" runat="server" Visible="True">
                                    <tr>
                                        <td>
                                            <input id="FileUp" type="file" onchange="javascript:FileChange(this.value);" size="40"
                                                name="FileURL" runat="server" clsss="input"/>&nbsp;
                                            <asp:Button ID="Upload" OnClick="UploadFile" runat="server" CssClass="input" Text="上传">
                                            </asp:Button></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <font color="red">*上传文件类型仅限 jpg | gif | swf 格式</font>
                                        </td>
                                    </tr>
                             </asp:panel>
                            </table>
                    </td>
                    <td valign="top">
                        &nbsp;
                    </td>
       </tr>
               </table>
        </div>
    </form>
</body>
</html>
