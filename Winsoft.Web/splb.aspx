<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="splb.aspx.cs" Inherits="Winsoft.Web.splb" %>

<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<%@ Register src="~/top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="~/mid.ascx" tagname="mid" tagprefix="uc1" %>
<%@ Register src="~/foot.ascx" tagname="foot" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>逗留网</title>
<link href="css/style.css"  rel="stylesheet"/>
<link href="css/body.css"  rel="stylesheet"/>
<link href="css/page.css"  rel="stylesheet"/>
<script type="text/javascript" src="js/mootools.js" charset="utf-8"></script>
<script type="text/javascript" src="js/common.js" charset="utf-8"></script>
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js" type="text/javascript"></script>
    <script src="js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="js/archefoucs.js" type="text/javascript"></script>
</head>

<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<uc1:top ID="top1" runat="server" />
<uc1:mid ID="mid1" runat="server" />
<div class="dl_list">
	<div class="dll_ttl"><b><asp:Label ID="V_Title" runat="server" Text=""></asp:Label></b>&nbsp;<i><asp:Label ID="V_ETitle" runat="server" Text=""></asp:Label></i></div>
    <div id="divSearch" runat="server" class="dll_ssjg" visible="false">
    	<div class="dlls_top">
        	<p>&nbsp;&nbsp;以下是符合您的搜索条件：<b><asp:Label ID="name" runat="server" Text=""></asp:Label></b></p>
            <a href="splb.aspx?type=1&id=<%=Request["id"] %>">重新搜索</a>
        </div>
        <div class="dlls_btm">
        	&nbsp;&nbsp;相关搜索：
            <asp:Repeater ID="rtKeyword" runat="server">
                <ItemTemplate>
            <%#Container.ItemIndex != 0 ? "&nbsp;|" : ""%>
            &nbsp;<a href="splb.aspx?type=1&id=<%#Eval("value_str") %>"><%#Eval("value_str") %></a>    
                </ItemTemplate>
            </asp:Repeater>
            <%=this.rtKeyword.Items.Count == 0 ? "&nbsp;无" : ""%>
        </div>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div class="dll_px">
    	<div class="dllp_left">
    	<%=this.orderType.Value.Trim() == "0" ? "<span>" : ""%><asp:LinkButton ID="btnSelectTime" runat="server" Text="按发布时间" onclick="btnSelectTime_Click" /><%=this.orderType.Value.Trim() == "0" ? "</span>" : ""%>
        <%=this.orderType.Value.Trim() == "1" ? "<span>" : ""%><asp:LinkButton ID="btnSelectBrowseCount" runat="server" Text="按浏览排行" onclick="btnSelectBrowseCount_Click" /><%=this.orderType.Value.Trim() == "1" ? "</span>" : ""%>
        <%=this.orderType.Value.Trim() == "2" ? "<span>" : ""%><asp:LinkButton ID="btnSelectCollectionCount" runat="server" Text="按收藏排行" onclick="btnSelectCollectionCount_Click" /><%=this.orderType.Value.Trim() == "2" ? "</span>" : ""%>
        <%=this.orderType.Value.Trim() == "3" ? "<span>" : ""%><asp:LinkButton ID="btnSelectBuyCount" runat="server" Text="按购买数量" onclick="btnSelectBuyCount_Click" /><%=this.orderType.Value.Trim() == "3" ? "</span>" : ""%>
        </div>
        <div class="dllp_right">
        	<webdiyer:AspNetPager ID="AspNetPager2" runat="server" FirstPageText="首页" HorizontalAlign="Center" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" onpagechanged="AspNetPager2_PageChanged"> </webdiyer:AspNetPager>
        </div>
    </div>
    <div class="dll_con">
    	<ul>
        	<asp:Repeater ID="rtManage" runat="server">
                <ItemTemplate>
            <%#(Container.ItemIndex + 1) % 4 == 0 ? "<li style='margin-right:0;'>" : "<li>"%>
            	<a href="spxq.aspx?id=<%#Eval("V_ID") %>" title='<%#Eval("V_Name") %>' target="_blank">
                	<img runat="server" src='<%#Eval("V_SmallImg") %>' />
                </a>
                <p><%#Eval("V_Name").ToString().Length > 15 ? Eval("V_Name").ToString().Substring(0, 15) + "..." : Eval("V_Name")%></p>
                <p>
                    <img src="images/dl_ico_ks.gif" alt="课时数" title="课时数" /><span><%#Eval("V_LessonCount")%></span>
                    <img src="images/dl_ico_xx.gif" alt="购买次数" title="购买次数" /><span><%#Eval("V_BuyCount")%></span>
                    <img src="images/dl_ico_bf.gif" alt="播放次数" title="播放次数" /><span><%#Eval("V_PlayCount")%></span>
                    <img src="images/dl_ico_jg.gif" alt="优惠价" title="优惠价" /><span><b><%#Convert.ToDecimal(Eval("V_NewPrice")).ToString("f2")%></b></span>
                </p>
            </li>    
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <div class="dll_px">
        <div class="dllp_right">
        	<webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" HorizontalAlign="Center" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" onpagechanged="AspNetPager1_PageChanged"> </webdiyer:AspNetPager>
        </div>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
<div style="width:100%; overflow:hidden; clear:both;"></div>
<uc1:foot ID="foot1" runat="server" />
<!-- 隐藏域 -->
<asp:HiddenField ID="orderType" runat="server" Value="0" />
</form>
</body>
</html>

