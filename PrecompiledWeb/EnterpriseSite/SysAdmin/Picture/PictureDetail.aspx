<%@ page language="C#" autoeventwireup="true" inherits="SysAdmin_Picture_PictureDetail, App_Web_0vt0lpz3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>图片查看</title>
    <LINK href="../Css/css.css" type="text/css" rel="stylesheet">
	<script>
		var oImg=new Image();
		oImg.src='<%=_picPath%>';
		function makesize(oImg)
		{	
			if(oImg.width!=0&&oImg.height!=0)
			{
				var swidth=720;
				var obj=document.getElementById("imgBre");
				var rate=oImg.height/oImg.width;
				if(oImg.width<=swidth) {obj.src=oImg.src;return;}
				oImg.height=rate*swidth;oImg.width=swidth;
				obj.width=oImg.width;obj.height=oImg.height;obj.src=oImg.src;	
			}
			else
			{	
				setTimeout("makesize(oImg)",10);
			}
		}
		</script>
		<base target="_self"></base>
	</HEAD>
	<body  onload="makesize(oImg);" >
		<form id="Form1" method="post" runat="server">
			<table width="98%" style="BORDER:#87b3d0 1px solid;"
					cellpadding="1" cellspacing="1" bgcolor="#dbeaf5" align="center">
				<tbody>	<tr style="BACKGROUND-COLOR:#87b3d0">
						<td colspan="4" height="35"><span style="FONT-WEIGHT:bold;FONT-SIZE:14px;color:white;">&nbsp;图片详细信息</span></td>
					</tr>
					
					
					<tr>
						<td   colspan="4">
						<table border="0" cellspacing="0" cellpadding="0" >
										<tr>
											<td width="10" height="10"><img src="../images/aul06.gif" width="10" height="10"></td>
											<td background="../images/aul07.gif"></td>
											<td width="10" height="10" ><img src="../images/aul08.gif" width="10" height="10"></td>
										</tr>
										<tr>
											<td background="../images/aul09.gif"></td>
											<td >
											<img ID="imgBre" >
											</td>
											<td background="../images/aul10.gif" ></td>
										</tr>
										<tr>
											<td width="10" height="10"><img src="../images/aul11.gif" width="10" height="10"></td>
											<td background="../images/aul12.gif"></td>
											<td width="10" height="10" background="../images/aul13.gif" ></td>
										</tr>
									</table>
						</td>
					</tr>
					
					<tr>
						<td><span style="FONT-WEIGHT:bold">图片ID：</span><asp:Label ID="lblPictureID" Runat="server" /></td>
						<td><span style="FONT-WEIGHT:bold">图片名称：</span><asp:Label ID="lblPicName" Runat="server" /></td>
						<td><span style="FONT-WEIGHT:bold">类型：</span><asp:Label ID="lblCategory" Runat="server" /></td>
						<td></td>
					</tr>
					<tr><td colspan="4"><span style="FONT-WEIGHT:bold">描述：</span><asp:Label ID="lblDescription" Runat="server" /></td></tr>
					<tr>
						<td colspan="4"><span style="FONT-WEIGHT:bold">原图地址：</span><asp:Label ID="lblOriginal" Runat="server" /></td>
					</tr>
					<tr>
						<td colspan="4"><span style="FONT-WEIGHT:bold">缩略图地址：</span><asp:Label ID="lblSmall" Runat="server" /></td>
					</tr>
					<tr><td colspan="4"><span style="FONT-WEIGHT:bold">上传用户：</span><asp:Label ID="lblNickname" Runat="server" /></td></tr>
					<tr>
						<td colspan="4">
						<span style="FONT-WEIGHT:bold">上传日期：</span><asp:Label ID="lblUploadDate" Runat="server" /></td>	
					</tr>
					
					<tr>
						<td align="center" colspan="4"><input type="button" value="关闭" onclick="window.close();" /></td>
					</tr></tbody>
				</table>
 
    </form>
</body>
</html>
