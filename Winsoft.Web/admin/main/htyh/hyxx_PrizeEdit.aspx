<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hyxx_PrizeEdit.aspx.cs" Inherits="Winsoft.Web.admin.main.htyh.hyxx_PrizeEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>���ÿ��ҽ�ϵͳ </title>
<link href="../../css/style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../../../My97DatePicker/WdatePicker.js"></script>
<script type="text/javascript">
    function CheckSmallImg(fileUpload) {
        var mime = fileUpload.value;
        var m = fileUpload.value;
        mime = mime.toLowerCase().substr(mime.lastIndexOf("."));
        if (mime != ".jpg" && mime != ".png") {
            alert("��֧��JPG��ʽ����PNG��ʽ");
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
            alert("��֧��JPG��ʽ����PNG��ʽ");
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
            	<td colspan="4"><span style="margin-left:5px;font-weight:bold;">����ǰ��λ�ã�</span><asp:HyperLink 
                        ID="lblMenu1" runat="server" ForeColor="#135294"></asp:HyperLink>=>
                <asp:HyperLink ID="lblMenu2" runat="server" ForeColor="#135294"></asp:HyperLink></td>
            </tr>
           
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">��Ʒ����</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input id="PrizeName" runat="server" type="text" class="page03_2"/></td>
                </tr>
                 <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">��Ʒ������</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input id="PrizeAmount" runat="server" type="text" class="page03_2"/></td>
                </tr>
            <tr>     
                <td nowrap="nowrap" class="tab_td_edit_r" width="1%">��Ʒ��Ӧ���֣�</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input id="PrizeScore" runat="server" type="text" class="page03_2"/></td>
            </tr>
             <tr>	
                <td align="center" style="padding-right:10px;" colspan="4">
                    <asp:Button ID="btnSave" runat="server" Text="�� ��" CssClass="page02_4" onclick="btnSave_Click" />&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" Text="��Ʒ����" CssClass="page02_x" 
                        onclick="btnAllocate_Click" Width="84px"/>&nbsp;&nbsp;
                    <%--<asp:Button ID="btnResult" runat="server" Text="�� ��" CssClass="page02_4" onclick="btnResult_Click"  />--%>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
