<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bzzx_xx.aspx.cs" Inherits="Winsoft.Web.bzzx_xx" %>
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
<div class="dlp_ttl">
    	<a href="index.aspx">首页</a>&nbsp;>&nbsp;<a href="bzzx.aspx">帮助中心</a>
</div>
<div class="dlp_main">
	<div class="dlm_fwzx_left">
    	<b>帮助中心</b>
        <ul>
        	<asp:Repeater ID="rtMenu" runat="server">
                <ItemTemplate>
            <li><a href="bzzx.aspx?id=<%#Eval("N_ID") %>" title='<%#Eval("N_Str1")%>'><%#Eval("N_Str1")%></a> &gt;</li>    
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <div class="dlm_fwzx_right">
    	<div class="dfr_ttl"><b>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="N_Str1" runat="server" Text=""></asp:Label></b></div>
        <div class="dfr_con">
        	<div class="dfr_info">
            	<b class="di_ttl"><asp:Label ID="N_Title" runat="server" Text=""></asp:Label></b>
                <asp:Label ID="N_Content" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
</div>
<div style="width:100%; overflow:hidden; clear:both;"></div>
<uc1:foot ID="foot1" runat="server" />
</form>
</body>
</html>
