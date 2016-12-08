<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hyzx_mmxg.aspx.cs" Inherits="Winsoft.Web.hyzx_mmxg" %>

<%@ Register src="~/top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="~/left.ascx" tagname="left" tagprefix="uc1" %>
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
<div class="dlp_ttl">
    	<a href="index.aspx">首页</a>&nbsp;>&nbsp;<a href="hyzx.aspx">会员中心</a>
</div>
<div class="dlp_main">
	<uc1:left ID="left1" runat="server" />
    <div class="dlm_fwzx_right">
    	<div class="dfr_ttl"><b>&nbsp;&nbsp;&nbsp;&nbsp;密码修改</b></div>   
        <div class="dfr_con">
        	<div class="dfrc_grzl">
            	<table width="740" border="0">
  <tr>
    <td width="175" align="right">原密码：</td>
    <td width="336"><input id="M_OPassword" runat="server" type="password"/></td>
    <td width="215"></td>
  </tr>
  <tr>
    <td align="right">新密码：</td>
    <td><input id="M_Password" runat="server" type="password"/></td>
    <td></td>
  </tr>
  <tr>
    <td align="right">确认密码：</td>
    <td><input id="M_RPassword" runat="server" type="password"/></td>
    <td></td>
  </tr>
  <tr>
    <td align="right"></td>
    <td><asp:Button ID="btnCommit" CssClass="btn_red" runat="server" Text="提 交" onclick="btnCommit_Click" /></td>
    <td>&nbsp;</td>
  </tr>
</table>

</div>
        </div>
    </div>
</div>
<div style="width:100%; overflow:hidden; clear:both;"></div>
<uc1:foot ID="foot1" runat="server" />
</form>
</body>
</html>
