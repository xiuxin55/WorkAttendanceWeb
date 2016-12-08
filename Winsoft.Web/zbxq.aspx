<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zbxq.aspx.cs" Inherits="Winsoft.Web.zbxq" %>

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
<script src="http://api.longtailvideo.com/library/kz3k7jxYEeO01CIACqoGtw.js"></script>
</head>

<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:Timer ID="Timer1" Interval="1000" runat="server" OnTick="Timer1_Tick"></asp:Timer>
<uc1:top ID="top1" runat="server" />
<div class="dl_list" >
	<div class="dll_ttl"><b>直播课程</b>&nbsp;<i>LIVE&nbsp;STREAMING</i></div>
    <div class="dl_zbxq">
    <div id="divPlay" runat="server">
	    <div class="dlz_video">
    	    <div id='playerYBvqOfAeBseP'></div>
            <script type='text/javascript'>
                jwplayer('playerYBvqOfAeBseP').setup({
                    file: '<%=this.VL_Vido.Value.Trim() %>',
                    image: '<%=this.VL_BigImg.Value.Trim() %>',
                    width: '980',
                    height: '464',
                    aspectratio: '16:9',
                    fallback: 'false',
                    primary: 'flash'
                });
            </script>
        </div>
        <div class="dlz_txt">
    	    <div class="dlzt_ttl">视频介绍</div>
            <div class="dlzt_con"><asp:Label ID="V_Content" runat="server" Text=""></asp:Label></div>
        </div>
    </div>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <div style="dl_zb_list">
    	<div class="dzl_top">
            <asp:LinkButton ID="btnPre" runat="server" CssClass="dzlt_l1" Text="上一周" onclick="btnPre_Click" />
            <i style="margin-left:252px;"><asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></i>
            <asp:LinkButton ID="btnNext" runat="server" CssClass="dzlt_r1" Text="下一周" onclick="btnNext_Click" />
        </div>
        <div class="dzl_con">
        	<div class="dzlc_ttl">
                <asp:LinkButton ID="btnDay1" runat="server" CssClass="dzlc_ttl_a1" Text="星期一" onclick="btnDay1_Click" />
                <asp:LinkButton ID="btnDay2" runat="server" CssClass="dzlc_ttl_a1" Text="星期二" onclick="btnDay2_Click" />
                <asp:LinkButton ID="btnDay3" runat="server" CssClass="dzlc_ttl_a1" Text="星期三" onclick="btnDay3_Click" />
                <asp:LinkButton ID="btnDay4" runat="server" CssClass="dzlc_ttl_a1" Text="星期四" onclick="btnDay4_Click" />
                <asp:LinkButton ID="btnDay5" runat="server" CssClass="dzlc_ttl_a1" Text="星期五" onclick="btnDay5_Click" />
                <asp:LinkButton ID="btnDay6" runat="server" CssClass="dzlc_ttl_a1" Text="星期六" onclick="btnDay6_Click" />
                <asp:LinkButton ID="btnDay7" runat="server" CssClass="dzlc_ttl_a1" Text="星期日" onclick="btnDay7_Click" style="margin-right:0px;" />
            </div>
            <div class="dzlc_main">
            	<ul>
                	<asp:Repeater ID="rtManage" runat="server">
                        <ItemTemplate>
                    <li><img runat="server" src='<%#Eval("VL_SmallImg") %>' />
                        <p><b><%#Eval("VL_Name")%></b><em><%#Convert.ToDateTime(Eval("VL_LiveSTime")).ToString("HH:mm")%></em><em style="width:24px; background:none;">-</em><em><%#Convert.ToDateTime(Eval("VL_LiveETime")).ToString("HH:mm")%></em></p>
                        <i>视频介绍：<%#Eval("V_Content").ToString().Length > 120 ? Eval("V_Content").ToString().Substring(0, 120) + "..." : Eval("V_Content")%></i></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="H_Time" runat="server" />
    </ContentTemplate>
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
    </Triggers>
</asp:UpdatePanel>
</div>
</div>
<div style="width:100%; overflow:hidden; clear:both;"></div>
<uc1:foot ID="foot1" runat="server" />
    <!-- 隐藏域 -->
    <asp:HiddenField ID="VL_Vido" runat="server" />
    <asp:HiddenField ID="VL_BigImg" runat="server" />
    <asp:HiddenField ID="VL_LiveSTime" runat="server" />
</form>
</body>
</html>


