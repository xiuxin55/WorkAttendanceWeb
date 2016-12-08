<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dtgl_zxsp_tjxg.aspx.cs" Inherits="Winsoft.Web.admin.main.scsy.dtgl_zxsp_tjxg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>逗留网管理系统</title>
<link href="../../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    function CheckImg(fileUpload) {
        var mime = fileUpload.value;
        var m = fileUpload.value;
        mime = mime.toLowerCase().substr(mime.lastIndexOf("."));
        if (mime != ".jpg" && mime != ".gif" && mime != ".png") {
            alert("仅支持JPG格式、GIF格式或PNG格式");
        }
        else {
            document.getElementById("N_Img").src = m;
        }
    }
</script>
</head>
<body style="background:#F5F9FC;">
    <form id="form1" runat="server">
        <table cellpadding="0" cellspacing="1" class="table05">
        	<tr style="color:#135294; background:#eef7fd;" align="left">
            	<td colspan="2"><span style="margin-left:5px;font-weight:bold;">您当前的位置：</span><asp:Label ID="lblMenu" runat="server" Text=""></asp:Label> </td>
            </tr>
            <tr>	
                <td align="right" style="padding-right:10px;" colspan="2">
                    <asp:Button ID="btnSave" runat="server" Text="保 存" CssClass="page02_4" onclick="btnSave_Click" />&nbsp;
                    <asp:Button ID="btnResult" runat="server" Text="返 回" CssClass="page02_4" onclick="btnResult_Click"  />
                </td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">排序号码：</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input id="N_Order" runat="server" type="text" class="page03_1" onkeyup="this.value=this.value.replace(/\D/g,'');"/></td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">视频名称：</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input id="N_Title" runat="server" type="text" class="page03_1"/></td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">链接地址：</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input id="N_Url" runat="server" type="text" class="page03_1"/></td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">图片地址：</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><asp:FileUpload ID="fileUploadUser" onchange="CheckImg(this)" runat="server" class="page03_4" /></td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">显示图片：</td>
                <td nowrap="nowrap" class="tab_td_edit_l" ><span style="color:Red;">图片宽度：160像素，图片高度：160像素。</span></td>
            </tr>
            <tr>
                <td nowrap="nowrap" class="tab_td_edit_t" colspan="2"><asp:Image ID="N_Img" runat="server" ImageUrl="~/images/dl_zxsp_i1.gif"  width="160" height="160"/></td>
            </tr>
        </table>
    </form>
</body>
</html>
