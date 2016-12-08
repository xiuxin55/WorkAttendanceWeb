<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hyxx_wdjinfo.aspx.cs" Inherits="Winsoft.Web.admin.main.htyh.hyxx_wdjinfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>信用卡兑奖系统 </title>
<link href="../../css/style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../../../My97DatePicker/WdatePicker.js"></script>
<script type="text/javascript">
    window.name = "win_test"  
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
    <form id="form1" runat="server" action=""   target="win_test">
        <table cellpadding="0" cellspacing="1" class="table05">
        	<tr style="color:#135294; background:#eef7fd;" align="left">
            	<td colspan="4"><span style="margin-left:5px;font-weight:bold;">您当前的位置：</span><asp:Label ID="lblMenu" runat="server" Text=""></asp:Label> </td>
            </tr>
            
            <tr>
            	<td nowrap="nowrap" class="tab_td_edit_r" width="1%">姓名：</td>
                <td nowrap="nowrap" class="tab_td_edit_l">
                    <input  style="background-color:#C0C0C0; color: #000000;" readonly="readonly" 
                        id="Prize_user" runat="server" type="text" class="page03_2"/></td>
            </tr>
            <tr>     
                <td nowrap="nowrap" class="tab_td_edit_r" width="1%">卡号：</td>
                <td nowrap="nowrap" class="tab_td_edit_l">
                    <input style="background-color:#C0C0C0; color: #000000;" readonly="readonly" 
                        id="Prize_CardNum" runat="server" type="text" class="page03_2"/></td>
                
            </tr>
            <tr>     
                <td nowrap="nowrap" class="tab_td_edit_r" width="1%">身份证号：</td>
                <td nowrap="nowrap" class="tab_td_edit_l">
                    <input style="background-color:#C0C0C0; color: #000000;" readonly="readonly" 
                        id="Prize_IdentifyCard" runat="server" type="text" class="page03_2"/></td>
                
            </tr>
           
             
              <tr>     
                <td nowrap="nowrap" class="tab_td_edit_r" width="1%">推广机构名称：</td>
                <td nowrap="nowrap" class="tab_td_edit_l">
                    <input style="background-color:#C0C0C0; color: #000000;" readonly="readonly" 
                        id="Pize_PushCom" runat="server" type="text" class="page03_2"/></td>
                
            </tr>
            <tr>     
                <td nowrap="nowrap" class="tab_td_edit_r" width="1%">推广人员姓名：</td>
                <td nowrap="nowrap" class="tab_td_edit_l">
                    <input style="background-color:#C0C0C0; color: #000000;" readonly="readonly" 
                        id="Pize_PushPerson" runat="server" type="text" class="page03_2"/></td>
                
            </tr>
             <tr>     
                
                <td nowrap="nowrap" class="tab_td_edit_r" width="1%">可兑换奖品：</td>
                <td nowrap="nowrap" class="tab_td_edit_l" >
                    <asp:DropDownList Width ="200" ID="Prize_NameList" runat="server" CssClass="page02_1">
                    </asp:DropDownList>
                 </td>
            </tr>
             <tr>     
                <td nowrap="nowrap" class="tab_td_edit_r" width="1%">领取人姓名：</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input id="Prize_GetUserName" runat="server" type="text" class="page03_2"/></td>
                
            </tr>
            <tr>     
                <td nowrap="nowrap" class="tab_td_edit_r" width="1%">领取人联系方式：</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input  id="Prize_GetUserContact" runat="server" type="text" class="page03_2"/></td>
                
            </tr>
             <tr>     
                <td nowrap="nowrap" class="tab_td_edit_r" width="1%">领取人身份证号：</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input  id="Prize_GetUserIdentifyCard" runat="server" type="text" class="page03_2"/></td>
                
            </tr>

            <tr>	
                <td align="center"  colspan="4">
                    <asp:Button ID="btnSave" runat="server" Text="确 定" CssClass="page02_4" onclick="btnSave_Click" />&nbsp;
                    <asp:Button ID="btnResult" runat="server" Text="取 消" CssClass="page02_4" onclick="btnResult_Click"  />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
