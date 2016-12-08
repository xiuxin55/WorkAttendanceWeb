<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pjxx_hf.aspx.cs" Inherits="Winsoft.Web.admin.main.schy.pjxx_hf" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>逗留网管理系统</title>
<link href="../../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    function CheckSmallImg(fileUpload) {
        var mime = fileUpload.value;
        var m = fileUpload.value;
        mime = mime.toLowerCase().substr(mime.lastIndexOf("."));
        if (mime != ".jpg" && mime != ".png") {
            alert("仅支持JPG格式或者PNG格式");
        }
        else {
            document.getElementById("V_SmallImg").src = m;
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
            document.getElementById("V_BigImg").src = m;
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
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">视频名称：</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><asp:Label ID="V_Name" runat="server" Text=""></asp:Label></td>
                <td rowspan="4" class="tab_td_edit_c" width="1%"><asp:Image ID="M_Img" runat="server" ImageUrl="~/images/tx.png" Width="120" Height="120" ToolTip="会员头像"/></td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">评价状态：</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><asp:Label ID="C_Status" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">会员帐号：</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><asp:Label ID="M_Username" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">评价时间：</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><asp:Label ID="C_Time" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">评价内容：</td>
                <td nowrap="nowrap" class="tab_td_edit_l" colspan="2"></td>
            </tr>
            <tr>
                <td nowrap="nowrap" class="tab_td_edit_t" colspan="3">
                	<textarea runat="server"  id="C_Content" name="content" style="width:99%;height:100px; border:1px solid #ccc;" readonly="readonly"></textarea>
                </td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">回复内容：</td>
                <td nowrap="nowrap" class="tab_td_edit_l" colspan="2"></td>
            </tr>
            <tr>
                <td nowrap="nowrap" class="tab_td_edit_t" colspan="3">
                	<textarea runat="server"  id="C_ReplyContent" name="content" style="width:99%;height:100px; border:1px solid #ccc;"></textarea>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
