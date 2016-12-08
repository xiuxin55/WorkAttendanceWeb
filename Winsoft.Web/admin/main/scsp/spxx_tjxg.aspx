<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="spxx_tjxg.aspx.cs" Inherits="Winsoft.Web.admin.main.scsp.spxx_tjxg" %>

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
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">视频类型：</td>
                <td nowrap="nowrap" class="tab_td_edit_l">
                    <asp:DropDownList ID="VT_ID" runat="server" CssClass="page02_1">
                    </asp:DropDownList>
                </td>
                <td rowspan="4" class="tab_td_edit_c" width="1%"><asp:Image ID="V_SmallImg" runat="server" ImageUrl="~/images/dl_i3.gif" Width="200" Height="125" ToolTip="视频小图"/></td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">视频名称：</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input id="V_Name" runat="server" type="text" class="page03_1"/></td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">视频原价：</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input id="V_Price" runat="server" type="text" class="page03_1" onkeyup="if(isNaN(value))execCommand('undo');"/>元</td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">视频现价：</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input id="V_NewPrice" runat="server" type="text" class="page03_1" onkeyup="if(isNaN(value))execCommand('undo');"/>元</td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">视频小图：</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><asp:FileUpload ID="fileUploadSmall" onchange="CheckSmallImg(this)" runat="server" class="page03_4" /></td>
                <td rowspan="4" class="tab_td_edit_c" width="1%"><asp:Image ID="V_BigImg" runat="server" ImageUrl="~/images/dl_video2.gif" Width="200" Height="125" ToolTip="视频大图"/></td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">视频大图：</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><asp:FileUpload ID="fileUploadBig" onchange="CheckBigImg(this)" runat="server" class="page03_4" /></td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">课时数：</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input id="V_LessonCount" runat="server" type="text" class="page03_1" onkeyup="this.value=this.value.replace(/\D/g,'');"/></td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">购买次数：</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input id="V_BuyCount" runat="server" type="text" class="page03_1" onkeyup="this.value=this.value.replace(/\D/g,'');"/></td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">播放次数：</td>
                <td nowrap="nowrap" class="tab_td_edit_l" colspan="2"><input id="V_PlayCount" runat="server" type="text" class="page03_1" onkeyup="if(isNaN(value))execCommand('undo')"/></td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">浏览次数：</td>
                <td nowrap="nowrap" class="tab_td_edit_l" colspan="2"><input id="V_BrowseCount" runat="server" type="text" class="page03_1" onkeyup="this.value=this.value.replace(/\D/g,'');"/></td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">收藏次数：</td>
                <td nowrap="nowrap" class="tab_td_edit_l" colspan="2"><input id="V_CollectionCount" runat="server" type="text" class="page03_1" onkeyup="this.value=this.value.replace(/\D/g,'');"/></td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">真实记录：</td>
                <td nowrap="nowrap" class="tab_td_edit_l" colspan="2">
                    购买次数：<asp:Label ID="V_BuyCountReal" runat="server" Text=""></asp:Label>
                    播放次数：<asp:Label ID="V_PlayCountReal" runat="server" Text=""></asp:Label>
                    浏览次数：<asp:Label ID="V_BrowseCountReal" runat="server" Text=""></asp:Label>
                    收藏次数：<asp:Label ID="V_CollectionCountReal" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">关键词：</td>
                <td nowrap="nowrap" class="tab_td_edit_l" colspan="2">
                    <span style="color:Red;">多个关键词用“#”号分隔</span>
                </td>
            </tr>
            <tr>
                <td nowrap="nowrap" class="tab_td_edit_t" colspan="3">
                	<textarea runat="server"  id="V_Keyword" name="content" 
                        style="width:99%;height:50px; border:1px solid #ccc;"></textarea>
                </td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">视频介绍：</td>
                <td nowrap="nowrap" class="tab_td_edit_l" colspan="2">
                    <span style="color:Red;">视频小图：图片宽度为245像素，图片高度为：190像素；视频大图：图片宽度为493像素，图片高度为：243像素</span>
                </td>
            </tr>
            <tr>
                <td nowrap="nowrap" class="tab_td_edit_t" colspan="3">
                	<textarea runat="server"  id="V_Content" name="content" style="width:99%;height:100px; border:1px solid #ccc;"></textarea>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
