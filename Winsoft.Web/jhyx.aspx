<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jhyx.aspx.cs" Inherits="Winsoft.Web.jhyx" %>

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
        <p style="margin-top:70px;"><font color="#E45509">亲爱的<asp:Label ID="M_Username" runat="server" Text=""></asp:Label>，您的邮箱已绑定成功，谢谢！</font></p>
        <p>欢迎来到逗留网！逗留网是一个简单易用的平台。</p>
    </div>
</div>
<div style="width:100%; overflow:hidden; clear:both;"></div>
<uc1:foot ID="foot1" runat="server" />
</form>
</body>
</html>
