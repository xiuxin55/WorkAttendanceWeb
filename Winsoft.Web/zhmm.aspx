<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zhmm.aspx.cs" Inherits="Winsoft.Web.zhmm" %>

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
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<uc1:top ID="top1" runat="server" />
<div class="dl_login">
	<div class="dll_main">
    	<b>嗨！输入您忘记密码的会员帐号，一分钟找回密码</b>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <div class="dllm_zc">
        	<table width="716" border="0">
  <tr>
    <td align="right"><strong>会员帐号：</strong></td>
    <td><input class="dllm_zc_input" id="M_Uid" runat="server" type="text" /></td>
    <td><font class="#cccccc"></font></td>
  </tr>
  <tr>
    <td height="40">&nbsp;</td>
    <td><asp:Button ID="btnCommit" runat="server" Text="提 交" CssClass="btn_zc" onclick="btnCommit_Click" /></td>
    <td>&nbsp;</td>
  </tr>
</table>

        </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
</div>
<div style="width:100%; overflow:hidden; clear:both;"></div>
<uc1:foot ID="foot1" runat="server" />
</form>
</body>
</html>
