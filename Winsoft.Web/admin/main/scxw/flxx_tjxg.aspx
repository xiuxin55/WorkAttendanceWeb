<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="flxx_tjxg.aspx.cs" Inherits="Winsoft.Web.admin.main.scxw.flxx_tjxg"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>逗留网管理系统</title>
<link href="../../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/jscript" charset="utf-8" src="../../../editor/kindeditor.js"></script>
<script type="text/jscript" charset="utf-8" src="../../../editor/lang/zh_CN.js"></script>
<script type="text/jscript">
    var create;
    KindEditor.ready(function (K) {
        var editor1 = K.create('#N_Content', {
            cssPath: '../../../editor/plugins/code/prettify.css',
            uploadJson: '../../../editor/upload_json.ashx',
            fileManagerJson: '../../../editor/file_manager_json.ashx',
            allowFileManager: true,
            afterCreate: function () {
                var self = this;
                K.ctrl(document, 13, function () {
                    self.sync();
                    K('form[name=form1]')[0].submit();
                });
                K.ctrl(self.edit.doc, 13, function () {
                    self.sync();
                    K('form[name=form1]')[0].submit();
                });
            }
        });
    });
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
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">菜单标题：</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input id="N_Str1" runat="server" type="text" class="page03_1"/></td>
            </tr>
        </table>
    </form>
</body>
</html>
