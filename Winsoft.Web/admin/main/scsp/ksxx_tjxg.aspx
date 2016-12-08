<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ksxx_tjxg.aspx.cs" Inherits="Winsoft.Web.admin.main.scsp.ksxx_tjxg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>逗留网管理系统</title>
<link href="../../css/style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../../../My97DatePicker/WdatePicker.js"></script>
<script type="text/javascript">
    function CheckSmallImg(fileUpload) {
        var mime = fileUpload.value;
        var m = fileUpload.value;
        mime = mime.toLowerCase().substr(mime.lastIndexOf("."));
        if (mime != ".jpg" && mime != ".png") {
            alert("仅支持JPG格式或者PNG格式");
        }
        else {
            document.getElementById("VL_SmallImg").src = m;
        }
    }
    function CheckBigImg(fileUpload) {
        var mime = fileUpload.value;
        var m = fileUpload.value;
        mime = mime.toLowerCase().substr(mime.lastIndexOf("."));
        if (mime != ".jpg" && mime != ".png") {
            alert("仅支持JPG格式或者PNG格式");
        }
        else {
            document.getElementById("VL_BigImg").src = m;
        }
    }
</script>
</head>
<body style="background:#F5F9FC;">
    <form id="form1" runat="server">
        <table cellpadding="0" cellspacing="1" class="table05">
        	<tr style="color:#135294; background:#eef7fd;" align="left">
            	<td colspan="3"><span style="margin-left:5px;font-weight:bold;">您当前的位置：</span><asp:Label ID="lblMenu" runat="server" Text=""></asp:Label> </td>
            </tr>
            <tr>	
                <td align="right" style="padding-right:10px;" colspan="3">
                    <asp:Button ID="btnSave" runat="server" Text="保 存" CssClass="page02_4" onclick="btnSave_Click" />&nbsp;
                    <asp:Button ID="btnResult" runat="server" Text="返 回" CssClass="page02_4" onclick="btnResult_Click"  />
                </td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">排序号码：</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input id="VL_Order" runat="server" type="text" class="page03_1" onkeyup="this.value=this.value.replace(/\D/g,'');"/></td>
                <td rowspan="3" class="tab_td_edit_c" width="1%"><asp:Image ID="VL_SmallImg" runat="server" ImageUrl="~/images/dl_i_v1.gif" Width="100" Height="72" ToolTip="课时小图"/></td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">课时名称：</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input id="VL_Name" runat="server" type="text" class="page03_1"/></td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">时间长度：</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input id="VL_Length" runat="server" type="text" class="page03_1" onclick="WdatePicker({dateFmt:'HH:mm:ss'});"/></td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">视频地址：</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input id="VL_Vido" runat="server" type="text" class="page03_1"/></td>
                <td rowspan="3" class="tab_td_edit_c" width="1%"><asp:Image ID="VL_BigImg" runat="server" ImageUrl="~/images/dl_i_v1.gif" Width="100" Height="72" ToolTip="课时大图"/></td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">课时小图：</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><asp:FileUpload ID="fileUploadSmall" onchange="CheckSmallImg(this)" runat="server" class="page03_4" /></td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">课时大图：</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><asp:FileUpload ID="fileUploadBig" onchange="CheckBigImg(this)" runat="server" class="page03_4" /></td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">上传说明：</td>
                <td nowrap="nowrap" class="tab_td_edit_l" colspan="2">
                    <span style="color:Red;">课时小图：图片宽度为189像素，图片高度为：112像素；课时大图：建议上传1M以内的图片，图片尺寸不限制</span>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
