<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="spzb_tjxg.aspx.cs" Inherits="Winsoft.Web.admin.main.scsp.spzb_tjxg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>����������ϵͳ</title>
<link href="../../css/style.css" rel="stylesheet" type="text/css" />
<link href="../../../css/tips.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../../../My97DatePicker/WdatePicker.js"></script>
<script type="text/javascript" src="../../../js/jquery-1.7.2.min.js" charset="utf-8"></script>
<script type="text/javascript" src="../../../js/tipswindown_return.js"></script>
<script type="text/javascript">
    function showBox() {
        tipsWindown("ѡ��γ�", "iframe:spxx_xzks.aspx", "810", "515", "false", "", "true", "leotheme");
    }
</script>
</head>
<body style="background:#F5F9FC;">
    <form id="form1" runat="server">
        <table cellpadding="0" cellspacing="1" class="table05">
        	<tr style="color:#135294; background:#eef7fd;" align="left">
            	<td colspan="3"><span style="margin-left:5px;font-weight:bold;">����ǰ��λ�ã�</span><asp:Label ID="lblMenu" runat="server" Text=""></asp:Label> </td>
            </tr>
            <tr>
                <td align="right" style="padding-right:10px;" colspan="3">
                    <asp:Button ID="btnMem" runat="server" Text="�� ��" CssClass="page02_4" onclick="btnMem_Click"/>&nbsp;
                    <asp:Button ID="btnSave" runat="server" Text="�� ��" CssClass="page02_4" onclick="btnSave_Click" />&nbsp;
                    <asp:Button ID="btnResult" runat="server" Text="�� ��" CssClass="page02_4" onclick="btnResult_Click"  />
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-left:10px;" colspan="3">
                    <span style="font-size:22px; font-weight:bold;font-family:'΢���ź�';float:left;"><asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></span>
                </td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">��Ƶ���ͣ�</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input id="VT_Name" runat="server" type="text" class="page03_1" disabled="disabled"/></td>
                <td rowspan="3" class="tab_td_edit_c" width="1%"><asp:Image ID="VL_SmallImg" runat="server" ImageUrl="~/images/dl_zb_i1.gif" Width="170" Height="100" ToolTip="��ƵСͼ"/></td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">��Ƶ���ƣ�</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input id="V_Name" runat="server" type="text" class="page03_1" disabled="disabled"/></td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">�γ����ƣ�</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input id="VL_Name" runat="server" type="text" class="page03_1" disabled="disabled"/> <a href="javascript:void(0);" onclick="showBox()">+ѡ��γ�</a></td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">��ʼʱ�䣺</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input id="VL_STime" runat="server" type="text" class="page03_1" onclick="WdatePicker({dateFmt:'HH:mm:ss'});"/></td>
                <td rowspan="3" class="tab_td_edit_c" width="1%"><asp:Image ID="VL_BigImg" runat="server" ImageUrl="~/images/dl_radio1.gif" Width="170" Height="100" ToolTip="��Ƶ��ͼ"/></td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">����ʱ�䣺</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input id="VL_LiveETime" runat="server" type="text" class="page03_1" disabled="disabled"/></td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">��Ƶ��ַ��</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input id="VL_Vido" runat="server" type="text" class="page03_1"/></td>
                
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">��Ƶ���ܣ�</td>
                <td nowrap="nowrap" class="tab_td_edit_l" colspan="2">
                    <span style="color:Red;"></span>
                </td>
            </tr>
            <tr>
                <td nowrap="nowrap" class="tab_td_edit_t" colspan="3">
                	<textarea runat="server"  id="V_Content" name="content" style="width:99%;height:100px; border:1px solid #ccc;" readonly="readonly"></textarea>
                </td>
            </tr>
        </table>
     <!-- ������ -->
    <asp:HiddenField ID="H_Time" runat="server" />
    <asp:HiddenField ID="VL_PID" runat="server" />
    </form>
</body>
</html>
