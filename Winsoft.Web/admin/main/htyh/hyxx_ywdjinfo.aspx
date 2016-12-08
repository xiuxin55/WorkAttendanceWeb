<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hyxx_ywdjinfo.aspx.cs" Inherits="Winsoft.Web.admin.main.htyh.hyxx_ywdjinfo" %>

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
                <td nowrap="nowrap" class="tab_td_edit_r" width="1%">领取人姓名：</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input  style="background-color:#C0C0C0; color: #000000;" readonly="readonly"  id="Prize_GetUserName" runat="server" type="text" class="page03_2"/></td>
                 
            </tr>
            <tr>     
                <td nowrap="nowrap" class="tab_td_edit_r" width="1%">领取人联系方式：</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input  style="background-color:#C0C0C0; color: #000000;" readonly="readonly"   id="Prize_GetUserContact" runat="server" type="text" class="page03_2"/></td>
                
            </tr>
             <tr>     
                <td nowrap="nowrap" class="tab_td_edit_r" width="1%">领取人身份证号：</td>
                <td nowrap="nowrap" class="tab_td_edit_l"><input  style="background-color:#C0C0C0; color: #000000;" readonly="readonly"   id="Prize_GetUserIdentifyCard" runat="server" type="text" class="page03_2"/></td>
                
            </tr>
             <tr>     
                <td nowrap="nowrap" class="tab_td_edit_r" width="1%">已兑换奖品名称：</td>
                <td nowrap="nowrap" class="tab_td_edit_l">
                    <input style="background-color:#C0C0C0; color: #000000;" readonly="readonly" 
                        id="Prize_GetPrizeName" runat="server" type="text" class="page03_2"/></td>

            </tr>
            <tr>     
                <td nowrap="nowrap" class="tab_td_edit_r" width="1%">兑奖日期：</td>
                <td nowrap="nowrap" class="tab_td_edit_l">
                    <input style="background-color:#C0C0C0; color: #000000;" readonly="readonly" 
                        id="Pize_GetPrizeDateTime" runat="server" type="text" class="page03_2"/></td>
                
            </tr>
             <tr>     
                <td nowrap="nowrap" class="tab_td_edit_r" width="1%">兑奖时间：</td>
                <td nowrap="nowrap" class="tab_td_edit_l">
                    <input style="background-color:#C0C0C0; color: #000000;" readonly="readonly" 
                        id="Pize_GetPrizeTime" runat="server" type="text" class="page03_2"/></td>
                
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
             <tr style="height: 0px;display:none; background-color: #FFFFFF;">     
                <td nowrap="nowrap" class="tab_td_edit_r" width="1%">已兑换奖品名称：</td>
                <td nowrap="nowrap" class="tab_td_edit_l">
                    <input style="background-color:#FFFFFF; color: #FFFFFF;" readonly="readonly" 
                        id="PrizeID" runat="server" type="text" class="page03_2"/></td>

            </tr>
                
            <tr>
               <td align="middle"  colspan="4">
               <%  if (IsVisible)
              { %>
                    <asp:Button ID="Button1" runat="server" Text="作 废" CssClass="page02_4" onclick="btnResultRefund_Click"  />
                
                    &nbsp;&nbsp;&nbsp;
                    <%} %>
                    <asp:Button ID="btnResult" runat="server" Text="取 消" CssClass="page02_4" onclick="btnResult_Click"  />
                </td>
            </tr>
        </table>
         <asp:ScriptManager ID="ScriptManager_ywdjinfo" runat="server">
     <Services>
            <asp:ServiceReference Path="~/Ajax/AjaxService.svc" />
        </Services>
    </asp:ScriptManager>
    </form>
</body>
</html>
