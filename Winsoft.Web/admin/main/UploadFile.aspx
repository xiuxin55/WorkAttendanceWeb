<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadFile.aspx.cs" Inherits="Winsoft.Web.admin.main.UploadFile" %>

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
<body style="width:240;height:100">

    <form action=""   target="win_test" id="form1" runat="server">
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>

 <asp:fileupload ID="FileUpLoad" runat="server"
       style="border: 1px solid #C0C0C0;" Height="21px" Width="276px"></asp:fileupload>
 
         <asp:Button ID="OK"  runat="server" Height="22px" Width="77px" 
        onclick="submmit_Click" Text="上传并导入"    EnableTheming="True"></asp:Button >
       
    </form>


</body>

</html>
