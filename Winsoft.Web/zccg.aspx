<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zccg.aspx.cs" Inherits="Winsoft.Web.zccg" %>

<%@ Register src="~/top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="~/foot.ascx" tagname="foot" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>逗留网</title>
<link href="css/style.css"  rel="stylesheet"/>
<link href="css/body.css"  rel="stylesheet"/>
<link href="css/page.css"  rel="stylesheet"/>
</head>

<body>
<form id="form1" runat="server">
<uc1:top ID="top1" runat="server" />
<div class="dl_login">
	<div class="dll_main" style="height:200px;">
        <p style="margin-top:70px;"><font color="#E45509">亲爱的<asp:Label ID="M_Username" runat="server" Text=""></asp:Label>，恭喜注册成功！</font></p>
        <p>注册信息已发送至<font color="#E45509"><asp:Label ID="M_EMail" runat="server" Text=""></asp:Label></font>，请立即验证邮件！</p>
        <p>验证码注册邮箱，绑定逗留网帐号，轻松取回密码。</p>
    </div>
</div>
<div style="width:100%; overflow:hidden; clear:both;"></div>
<uc1:foot ID="foot1" runat="server" />
</form>
</body>
</html>
