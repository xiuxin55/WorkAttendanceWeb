<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hyxx_xgmm.aspx.cs" Inherits="Winsoft.Web.admin.main.htyh.hyxx_xgmm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>信用卡兑奖系统 </title>
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
            	<td colspan="4"><span style="margin-left:5px;font-weight:bold;">您当前的位置：</span><asp:Label ID="lblMenu" runat="server" Text=""></asp:Label> </td>
            </tr>
            <tr>	
                <td align="right" style="padding-right:10px;" colspan="4">
                    <asp:Button ID="btnSave" runat="server" Text="保 存" CssClass="page02_4" onclick="btnSave_Click" />&nbsp;
                    <asp:Button ID="btnResult" runat="server" Text="返 回" CssClass="page02_4" onclick="btnResult_Click"  />
                </td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">用户帐号：</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input  style="background-color:#C0C0C0; color: #000000;" readonly="readonly" id="US_UserName" runat="server" type="text" class="page03_2"/></td>
                <td nowrap="nowrap" class="tab_td_edit_r" width="1%">电子邮箱：</td>
                <td nowrap="nowrap" class="tab_td_edit_l">
                <input  style="background-color:#C0C0C0; color: #000000;" readonly="readonly" id="US_Email" runat="server" type="text" class="page03_2"/></td>
            </tr>
            
           
           <tr  >
                <td nowrap="nowrap" class="tab_td_edit_r" width="1%">新密码：</td>
                <td nowrap="nowrap" class="tab_td_edit_l">
                    <input id="US_Password" runat="server" type="password" class="page03_2" /></td>
                <td nowrap="nowrap" class="tab_td_edit_r" width="1%">确认密码：</td>
                <td nowrap="nowrap" class="tab_td_edit_l">
                    <input id="US_Password_qr" runat="server" type="password" class="page03_2" /></td>
            </tr>
        
           
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">用户姓名：</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input  style="background-color:#C0C0C0; color: #000000;" readonly="readonly" id="US_Name" runat="server" type="text" class="page03_2"/></td>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">联系电话：</td>
                <td nowrap="nowrap" class="tab_td_edit_l" >
     
                <input  style="background-color:#C0C0C0; color: #000000;" readonly="readonly" id="US_TelPhone" runat="server" type="text" class="page03_2"/>
                </td>
            </tr>
        
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">身份证号：</td>
                 <td nowrap="nowrap" class="tab_td_edit_l">
                 <input  style="background-color:#C0C0C0; color: #000000;" readonly="readonly" id="US_CardId" runat="server" type="text" class="page03_2"/>
           
               </td>
               <td nowrap="nowrap" class="tab_td_edit_r" width="1%">用户性别：</td>
                <td nowrap="nowrap" class="tab_td_edit_l" >
                    <asp:DropDownList ID="US_Sex" runat="server" CssClass="page02_1" 
                        BackColor="Silver" Enabled="False">
                        <asp:ListItem>保密</asp:ListItem>
                        <asp:ListItem>男</asp:ListItem>
                        <asp:ListItem>女</asp:ListItem>
                    </asp:DropDownList>
                 </td>
            </tr>
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">所属网点：</td>
                <td nowrap="nowrap" class="tab_td_edit_l" >
           
                            <input  style="background-color:#C0C0C0; color: #000000;" readonly="readonly" id="WebsiteDropDownList" runat="server" type="text" class="page03_2"/>
                 </td>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">用户权限：</td>
                <td nowrap="nowrap" class="tab_td_edit_l" >
                    <asp:DropDownList ID="US_Authentication" runat="server" CssClass="page02_1" Enabled="False" BackColor="Silver">
                        <asp:ListItem Value="0">超级管理员</asp:ListItem>
                        <asp:ListItem Value="1">区域管理员</asp:ListItem>
                        <asp:ListItem Value="2">管理员</asp:ListItem>
                        <asp:ListItem Value="3">操作员</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
           
        </table>
    </form>
</body>
</html>
