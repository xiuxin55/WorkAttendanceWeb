<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hyxx_xgmm.aspx.cs" Inherits="Winsoft.Web.admin.main.htyh.hyxx_xgmm" %>

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
            	<td colspan="4"><span style="margin-left:5px;font-weight:bold;">����ǰ��λ�ã�</span><asp:Label ID="lblMenu" runat="server" Text=""></asp:Label> </td>
            </tr>
            <tr>	
                <td align="right" style="padding-right:10px;" colspan="4">
                    <asp:Button ID="btnSave" runat="server" Text="�� ��" CssClass="page02_4" onclick="btnSave_Click" />&nbsp;
                    <asp:Button ID="btnResult" runat="server" Text="�� ��" CssClass="page02_4" onclick="btnResult_Click"  />
                </td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">�û��ʺţ�</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input  style="background-color:#C0C0C0; color: #000000;" readonly="readonly" id="US_UserName" runat="server" type="text" class="page03_2"/></td>
                <td nowrap="nowrap" class="tab_td_edit_r" width="1%">�������䣺</td>
                <td nowrap="nowrap" class="tab_td_edit_l">
                <input  style="background-color:#C0C0C0; color: #000000;" readonly="readonly" id="US_Email" runat="server" type="text" class="page03_2"/></td>
            </tr>
            
           
           <tr  >
                <td nowrap="nowrap" class="tab_td_edit_r" width="1%">�����룺</td>
                <td nowrap="nowrap" class="tab_td_edit_l">
                    <input id="US_Password" runat="server" type="password" class="page03_2" /></td>
                <td nowrap="nowrap" class="tab_td_edit_r" width="1%">ȷ�����룺</td>
                <td nowrap="nowrap" class="tab_td_edit_l">
                    <input id="US_Password_qr" runat="server" type="password" class="page03_2" /></td>
            </tr>
        
           
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">�û�������</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input  style="background-color:#C0C0C0; color: #000000;" readonly="readonly" id="US_Name" runat="server" type="text" class="page03_2"/></td>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">��ϵ�绰��</td>
                <td nowrap="nowrap" class="tab_td_edit_l" >
     
                <input  style="background-color:#C0C0C0; color: #000000;" readonly="readonly" id="US_TelPhone" runat="server" type="text" class="page03_2"/>
                </td>
            </tr>
        
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">���֤�ţ�</td>
                 <td nowrap="nowrap" class="tab_td_edit_l">
                 <input  style="background-color:#C0C0C0; color: #000000;" readonly="readonly" id="US_CardId" runat="server" type="text" class="page03_2"/>
           
               </td>
               <td nowrap="nowrap" class="tab_td_edit_r" width="1%">�û��Ա�</td>
                <td nowrap="nowrap" class="tab_td_edit_l" >
                    <asp:DropDownList ID="US_Sex" runat="server" CssClass="page02_1" 
                        BackColor="Silver" Enabled="False">
                        <asp:ListItem>����</asp:ListItem>
                        <asp:ListItem>��</asp:ListItem>
                        <asp:ListItem>Ů</asp:ListItem>
                    </asp:DropDownList>
                 </td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">�������㣺</td>
                <td nowrap="nowrap" class="tab_td_edit_l" >
           
                            <input  style="background-color:#C0C0C0; color: #000000;" readonly="readonly" id="WebsiteDropDownList" runat="server" type="text" class="page03_2"/>
                 </td>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">�û�Ȩ�ޣ�</td>
                <td nowrap="nowrap" class="tab_td_edit_l" >
                    <asp:DropDownList ID="US_Authentication" runat="server" CssClass="page02_1" Enabled="False" BackColor="Silver">
                        <asp:ListItem Value="0">��������Ա</asp:ListItem>
                        <asp:ListItem Value="1">�������Ա</asp:ListItem>
                        <asp:ListItem Value="2">����Ա</asp:ListItem>
                        <asp:ListItem Value="3">����Ա</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
           
        </table>
    </form>
</body>
</html>
