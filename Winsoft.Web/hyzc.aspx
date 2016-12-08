<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hyzc.aspx.cs" Inherits="Winsoft.Web.hyzc" %>

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
    	<b>嗨！你可以选择合作网站帐号直接登录逗留网，一分钟完成注册</b>
        <div class="dllm_qt">
       	  <button class="btn_dl_sina">用新浪微博登录</button>
          <button class="btn_dl_db">用豆瓣帐号登录</button>
            <button class="btn_dl_rr">用人人账户微博登录</button>
            <button class="btn_dl_qq">用QQ账户登录</button>
        </div>
        <div class="dllm1">
        	<img src="images/dl_login_i2.gif" />
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <div class="dllm_zc">
 <table width="716" border="0">
  <tr>
    <td colspan="3" align="center"><i style="font-size:14px; font-weight:bold;">免费注册平台新账户&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</i></td>
    </tr>
  <tr>
    <td width="128" align="right"><strong>电子邮箱：</strong></td>
    <td width="272"><input class="dllm_zc_input" id="M_EMail" runat="server" type="text" /></td>
    <td width="302"><font color="#cc0000"></font></td>
  </tr>
  <tr>
    <td align="right"><strong>会员帐号：</strong></td>
    <td><input class="dllm_zc_input" id="M_Username" runat="server" type="text" /></td>
    <td><font class="#cccccc"></font></td>
  </tr>
  <tr>
    <td align="right"><strong>会员密码：</strong></td>
    <td><input class="dllm_zc_input" id="M_Password" runat="server" type="password" /></td>
    <td><font class="#cccccc"></font></td>
  </tr>
  <tr>
    <td align="right"><strong>确认密码：</strong></td>
    <td><input class="dllm_zc_input" id="M_RPassword" runat="server" type="password" /></td>
    <td><font class="#cccccc"></font></td>
  </tr>
  <tr>
    <td height="40">&nbsp;</td>
    <td><asp:Button ID="btnCommit" runat="server" Text="注 册" CssClass="btn_zc" onclick="btnCommit_Click" /></td>
    <td>&nbsp;</td>
  </tr>
    <tr>
    <td height="40">&nbsp;</td>
    <td  height="18" style="line-height:12px; height:12px;"><asp:CheckBox ID="M_Read" runat="server" CssClass="btn_read" oncheckedchanged="M_Read_CheckedChanged" AutoPostBack="true" Checked="true" />
        <asp:Repeater ID="rtZcxy" runat="server">
            <ItemTemplate>
        <a href='<%#Eval("N_Url") %>' target="_blank"><%#Eval("N_Title") %></a>     
            </ItemTemplate>
        </asp:Repeater>
    </td>
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


