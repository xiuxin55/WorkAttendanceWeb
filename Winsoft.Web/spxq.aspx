<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="spxq.aspx.cs" Inherits="Winsoft.Web.spxq" %>

<%@ Register src="~/top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="~/mid.ascx" tagname="mid" tagprefix="uc1" %>
<%@ Register src="~/foot.ascx" tagname="foot" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>逗留网</title>
<meta name="Keywords" content="<%=this.V_Name.Text.Trim() %>，课程创建人：<%=this.M_Name.Text.Trim()%>">
<meta name="Description" content="<%=this.V_Content.Text.Trim()%>">
<link href="css/style.css"  rel="stylesheet"/>
<link href="css/body.css"  rel="stylesheet"/>
<link href="css/page.css"  rel="stylesheet"/>
<script type="text/javascript" src="js/mootools.js" charset="utf-8"></script>
<script type="text/javascript" src="js/common.js" charset="utf-8"></script>
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js" type="text/javascript"></script>
    <script src="js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="js/archefoucs.js" type="text/javascript"></script>
    <script src="http://api.longtailvideo.com/library/kz3k7jxYEeO01CIACqoGtw.js"></script>
</head>

<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<uc1:top ID="top1" runat="server" />
<uc1:mid ID="mid1" runat="server" />
<%
    if (Session["myuser"]==null)
    {
        this.divPreview.Visible = true;
        this.divWatch.Visible = false;
    }
     %>
<div class="dl_list">
	<div class="dll_ttl"><b><asp:Label ID="V_Title" runat="server" Text=""></asp:Label></b>&nbsp;<i><asp:Label ID="V_ETitle" runat="server" Text=""></asp:Label></i></div>
</div>
<div class="dl_v_info">
    <a id="aVido" name="aVido"> </a>
	<div class="dvi_left">
        <div class="dvil_ttl"><asp:Label ID="V_Name" runat="server" Text=""></asp:Label></div>
        <div id="divPreview" runat="server" class="dvil_v">
        	<div class="dvv_l">
            	<div class="dvvl_m">
                	<img id="V_BigImg" runat="server" src="~/images/dl_video2.gif"/>
                </div>
                <img style="float:left;" src="images/dl_bg_v1.gif" />
            </div>
            <div class="dvv_r">
            	<div class="dvvr_m">
                	<ul>
                    	<li>课时数：<asp:Label ID="V_LessonCount" runat="server" Text=""></asp:Label></li>
                        <li>浏览次数：<asp:Label ID="V_BrowseCount" runat="server" Text=""></asp:Label></li>
                        <li>购买次数：<asp:Label ID="V_BuyCount" runat="server" Text=""></asp:Label></li>
                        <li>创建时间：<asp:Label ID="V_Time" runat="server" Text=""></asp:Label></li>
                        <li>网站价：<del><asp:Label ID="V_Price" runat="server" Text=""></asp:Label></del></li>
                        <li>优惠价：<b style="color:#ff6600;"><asp:Label ID="V_NewPrice" runat="server" Text=""></asp:Label></b></li>
                    </ul>
                    <p><asp:Button ID="btnBuy" runat="server" Text="" CssClass="btn_buy" onclick="btnBuy_Click" /><asp:Button ID="btnCollection" runat="server" Text="" CssClass="btn_sc" onclick="btnCollection_Click" /></p>
                </div>
                <img src="images/dl_bg_v2.gif" />
            </div>
        </div>
        <div id="divWatch" runat="server" class="dvil_v">
        	<div id='playerYBvqOfAeBseP'></div>
            <script type='text/javascript'>
                jwplayer('playerYBvqOfAeBseP').setup({
                    file: '<%=this.VL_Vido.Value.Trim() %>',
                    image: '<%=this.VL_BigImg.Value.Trim() %>',
                    width: '700',
                    height: '362',
                    aspectratio: '16:9',
                    fallback: 'false',
                    primary: 'flash'
                });
            </script>
        </div>
        <div class="dvi_kcjs">
        	<b>课程介绍</b>
            <div class="dvik_c"><asp:Label ID="V_Content" runat="server" Text=""></asp:Label></div>
        </div>
        <div class="dvi_list">
        	<ul>
            	<asp:Repeater ID="rtManage" runat="server" onitemcommand="rtManage_ItemCommand">
                    <ItemTemplate>
                <li>
                <asp:ImageButton ID="btnVLSmallImg" runat="server" CommandName="VLSmallImg" CommandArgument='<%#Eval("VL_ID") %>' ImageUrl='<%#Eval("VL_SmallImg")%>' ToolTip='<%#Eval("VL_Name")%>' />
                <p><i><asp:LinkButton ID="btnVLName" runat="server" CommandName="VLName" CommandArgument='<%#Eval("VL_ID") %>' Text='<%#Eval("VL_Name").ToString().Length > 15 ? Eval("VL_Name").ToString().Substring(0, 15) + "..." : Eval("VL_Name")%>' ToolTip='<%#Eval("VL_Name")%>' /></p>
                <asp:HiddenField ID="hdfVID" runat="server" Value='<%#Eval("V_ID")%>' />
                </li>    
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
        <div class="dvi_pl">
        	<div class="dvip_ttl">我要评论</div>
            <div class="dvip_text">
            	<textarea id="C_Content" runat="server" rows="0" cols="0"></textarea>
            </div>
            <div><asp:Button CssClass="dvip_btn_button" ID="btnComment" runat="server" Text="提 交" onclick="btnComment_Click" /></div>
        </div>
        <div class="dvi_pl_list">
        	<b>&nbsp;&nbsp;&nbsp;&nbsp;评价</b>
            <ul>
            	<asp:Repeater ID="rtComment" runat="server">
                    <ItemTemplate>
                <li>
                    <i><img runat="server" src='<%#Eval("M_Img") %>' /></i>
                    <p><font color="#ff6600"><%#Eval("M_Nickname")%>：</font>&nbsp;&nbsp;<%#Convert.ToDateTime(Eval("C_Time")).ToString("yyyy年MM月dd日 HH:mm")%></p>
                    <em><%#Eval("C_Content")%></em>
                    <%#Eval("A_ID").ToString() != string.Empty ? "<p><font color='#ff6600'>" + Eval("A_Name") + " 回复：</font>&nbsp;&nbsp;" + Convert.ToDateTime(Eval("C_ReplyTime")).ToString("yyyy年MM月dd日 HH:mm") + "</p><em>" + Eval("C_ReplyContent") + "</em>" : ""%>
                </li>    
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <div class="dvipl_sm">&nbsp;&nbsp;&nbsp;网友评论仅供网友发表个人看法，并不表明本站同意其观点或证实其描述。</div>
        </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="dvi_right">
    	<div class="dvir_share">
        <!-- Baidu Button BEGIN -->
<div id="bdshare" class="bdshare_t bds_tools get-codes-bdshare">
<a class="bds_qzone"></a>
<a class="bds_tsina"></a>
<a class="bds_tqq"></a>
<a class="bds_renren"></a>
<a class="bds_t163"></a>
<span class="bds_more">更多</span>
<a class="shareCount"></a>
</div>
<script type="text/javascript" id="bdshare_js" data="type=tools&amp;uid=0" ></script>
<script type="text/javascript" id="bdshell_js"></script>
<script type="text/javascript">
    document.getElementById("bdshell_js").src = "http://bdimg.share.baidu.com/static/js/shell_v2.js?cdnversion=" + Math.ceil(new Date() / 3600000)
</script>
<!-- Baidu Button END -->
		</div>
        <div class="dvir_cjr">
        	<b style="height:40px;display:block; line-height:40px; font:18px '微软雅黑';">&nbsp;&nbsp;课程创建人</b>
            <div class="drc_c">
            	<p><img id="M_Img" runat="server" src="~/images/5546.png" /></p>
                <i><asp:Label ID="M_Name" runat="server" Text=""></asp:Label></i>
                <em><asp:Label ID="M_About" runat="server" Text=""></asp:Label></em>
            </div>
        <div class="dvir_about">
        	<b style="display:block; height:40px; line-height:40px; font:18px '微软雅黑';">相关视频</b>
            <ul>
            	<asp:Repeater ID="rtRelated" runat="server">
                    <ItemTemplate>
                <li>
                	<i><a href="spxq.aspx?id=<%#Eval("V_ID") %>" title='<%#Eval("V_Name") %>'><img runat="server" src='<%#Eval("V_SmallImg") %>' /></a></i>
                    <p><a href="spxq.aspx?id=<%#Eval("V_ID") %>" title='<%#Eval("V_Name") %>'><%#Eval("V_Name").ToString().Length > 10 ? Eval("V_Name").ToString().Substring(0, 10) + "..." : Eval("V_Name")%></a></p>
                    <em>
                        <img src="images/dl_ico_ks2.gif" alt="课时数" title="课时数" /><span><%#Eval("V_LessonCount")%></span>
                        <img src="images/dl_ico_xx2.gif" alt="购买次数" title="购买次数"/><span><%#Eval("V_BuyCount")%></span>
                        <img src="images/dl_ico_bf2.gif" alt="播放次数" title="播放次数"/><span><%#Eval("V_PlayCount")%></span>
                    </em>
                </li>    
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
       </div>
    </div>
</div>
<div style="width:100%; overflow:hidden; clear:both;"></div>
<uc1:foot ID="foot1" runat="server" />
    <!--隐藏域-->
<asp:HiddenField ID="VL_Vido" runat="server" />
<asp:HiddenField ID="VL_BigImg" runat="server" />
</form>
</body>
</html>

