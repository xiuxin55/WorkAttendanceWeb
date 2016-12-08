<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hyzx_grzl.aspx.cs" Inherits="Winsoft.Web.hyzx_grzl" %>

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
    	<div class="dfr_ttl"><b>&nbsp;&nbsp;&nbsp;&nbsp;个人资料</b></div>   
        <div class="dfr_con">
        	<div class="dfrc_grzl">
            	<table width="740" border="0">
  <tr>
    <td width="175" align="right">会员帐号：</td>
    <td width="336"><b><asp:Label ID="M_Username" runat="server" Text=""></asp:Label></b></td>
    <td width="215" rowspan="4" align="center">
        <p><img id="M_Img" runat="server" src="~/images/tx.png" alt="" /></p><p><a href="hyzx_grzl_sctx.aspx">修改头像</a>
        </p>
    </td>
  </tr>
  <tr>
    <td align="right">电子邮箱：</td>
    <td><asp:Label ID="M_EMail" runat="server" Text=""></asp:Label></td>
    <td></td>
  </tr>
  <tr>
    <td align="right">会员昵称：</td>
    <td><input id="M_Nickname" runat="server" type="text"/></td>
    <td></td>
  </tr>
  <tr>
    <td align="right">会员姓名：</td>
    <td><input id="M_Name" runat="server" type="text"/></td>
    <td></td>
  </tr>
  <tr>
    <td align="right">联系电话：</td>
    <td><input id="M_Tel" runat="server" type="text"/></td>
    <td></td>
  </tr>
  <tr>
    <td align="right">联系地址：</td>
    <td><input id="M_Address" runat="server" type="text"/></td>
    <td></td>
  </tr>
  <tr>
    <td align="right">会员性别：</td>
    <td>
        <asp:DropDownList ID="M_Sex" runat="server">
            <asp:ListItem>保密</asp:ListItem>
            <asp:ListItem>男</asp:ListItem>
            <asp:ListItem>女</asp:ListItem>
        </asp:DropDownList>
    </td>
    <td></td>
  </tr>
  <tr>
    <td align="right">个人简介：</td>
    <td colspan="2"><textarea id="M_About" runat="server" style="width:99%; height:100px;" rows="0" cols="0"></textarea></td>
  </tr>
  <tr>
    <td align="right">兴趣爱好：</td>
    <td colspan="2"><textarea id="M_Like" runat="server" style="width:99%; height:100px;" rows="0" cols="0"></textarea></td>
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

