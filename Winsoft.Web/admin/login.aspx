<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Winsoft.Web.admin.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>����ϵͳ</title>
<link href="css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    document.onkeydown = function (e) {
        var keycode = document.all ? event.keyCode : e.which;
        if (keycode == 13) Cheak();
    }
    function ChangeImage(obj) {
        obj.src = "ImageCode/Image.aspx?id=" + Math.random();
    }
    function LoadImage() {
        document.getElementById("cheakImag").src = "ImageCode/Image.aspx?id=" + Math.random();
    }
</script>
</head>

<body>
<form id="form1" runat="server">
<div class="login" onload="LoadImage();">
	<%--<div class="login01"><img src="img/logo.png" width="348" height="68" alt="����logo" /></div>--%>
    <div class="login02">
    	<div><h1>����ϵͳ</h1></div>
        <table width="460" height="240" border="0" cellpadding="0" cellspacing="10">
        	<tr>
            	<th align="right" width="75" style="color:#525f63">��&nbsp;&nbsp;�ţ�</th>
                <td align="left" colspan="2"><input name="Uname" id="A_Uid" runat="server" type="text" class="page01_1" /></td>
            </tr>
            <tr>
            	<th align="right" width="75" style="color:#525f63">��&nbsp;&nbsp;�룺</th>
                <td align="left" colspan="2"><input type="password" id="A_Pwd" runat="server" class="page01_1" /></td>
            </tr>
            <tr>
            	<th align="right" width="75" style="color:#525f63">��&nbsp;&nbsp;֤��</th>
                <td align="left" width="235"><input id="A_Yzm" runat="server"  maxlength="4" type="text" class="page01_2" /></td>
                <td align="left"><img alt="" title="�����������һ��" style="cursor:pointer;" src="ImageCode/Image.aspx" id="cheakImag"  width="88" height="38" onclick="ChangeImage(this)" /></td>
            </tr>
            <tr>
            	<th align="center" width="75" style="color:#525f63"></th>
                <td align="left" colspan="2"><asp:Button ID="btnLogin" runat="server" Text="�� ¼" CssClass="page01_3" onclick="btnLogin_Click" /></td>
            </tr>
        </table>
  </div>
    <div class="login03">Copyright 2013  XXXXXXX  All Rights Reserved</div>
</div>
</form>
</body>
</html>
