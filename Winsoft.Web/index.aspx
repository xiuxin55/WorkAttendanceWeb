<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Winsoft.Web.index" %>

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
<script type="text/javascript" src="js/mootools.js" charset="utf-8"></script>
<script type="text/javascript" src="js/common.js" charset="utf-8"></script>
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js" type="text/javascript"></script>
    <script src="js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="js/archefoucs.js" type="text/javascript"></script>
</head>

<body>
<form id="form1" runat="server">
<uc1:top ID="top1" runat="server" />
<uc1:mid ID="mid1" runat="server" />
<div class="dl_zhibo">
	<div class="dz_main">
    	<div class="dzm_l">
        	<img style="float:left;" src="images/dl_zb_l.gif" />
            <img style="float:left;" src="images/dl_zb_l2.gif" />
        </div>
        <div class="dzm_r">
        	<ul>
                <asp:Repeater ID="rtSpzb" runat="server">
                    <ItemTemplate>
                <li>
                    <a href='zbxq.aspx' title='<%#Eval("VL_Name") %>' target="_blank">
                        <img runat="server" src='<%#Eval("VL_SmallImg") %>' /><p>
                        <%#Convert.ToDateTime(Eval("VL_LiveSTime").ToString()) <= DateTime.Now && Convert.ToDateTime(Eval("VL_LiveETime").ToString()) >= DateTime.Now ? "<b style='background:#099'>" : "<b>"%>
                            <%#Convert.ToDateTime(Eval("VL_LiveSTime")).ToString("HH:mm")%>
                        </b>
                        <i><%#Eval("VL_Name").ToString().Length > 6 ? Eval("VL_Name").ToString().Substring(0, 6) + "..." : Eval("VL_Name")%></i></p>
                    </a>
                </li>    
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
</div>
<div class="dl_zxsp">
	<img src="images/dl_i_zxsp.gif" />
    <div class="hl_main5_content">
    	<div class="hl_scrool_leftbtn" style="float:left;  margin-top:20px;"><img src="images/dl_zxsp_l.gif" /></div>
        <div class="hl_main5_content1">
        	<ul>
                <asp:Repeater ID="rtZxsp" runat="server">
                    <ItemTemplate>
                <li>
                	<a href='<%#Eval("N_Url") %>' title='<%#Eval("N_Title") %>' target="_blank"><img id="Img10" runat="server" src='<%#Eval("N_Img") %>' />
                    <p><%#Eval("N_Str1") %></b><i><%#Eval("N_Title").ToString().Length > 10 ? Eval("N_Title").ToString().Substring(0, 10) + "..." : Eval("N_Title")%></p></a>
                </li>    
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="hl_scrool_rightbtn" style="float:right;  margin-top:20px;"><img src="images/dl_zxsp_r.gif" /></div>
    </div>
    <div><img src="images/dl_zxsp_btm.gif" /></div>
</div>
<div class="dl_video">
	<img src="images/dl_i_video.gif"/>
    <div class="dlv_con">
    	<ul>
        	<asp:Repeater ID="rt1FA" runat="server">
                <ItemTemplate>
           <li><a href='<%#Eval("N_Url") %>' title='<%#Eval("N_Title") %>' target="_blank"><img runat="server" src='<%#Eval("N_Img") %>' /></a></li>     
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="rt1FB" runat="server">
                <ItemTemplate>
           <li style="width:495px;"><a href='<%#Eval("N_Url") %>' title='<%#Eval("N_Title") %>' target="_blank"><img runat="server" src='<%#Eval("N_Img") %>' /></a><p><b><%#Eval("N_Title").ToString().Length > 15 ? Eval("N_Title").ToString().Substring(0, 15) + "..." : Eval("N_Title")%></b><span><%#Eval("N_Content").ToString().Length > 15 ? Eval("N_Content").ToString().Substring(0, 15) + "..." : Eval("N_Content")%></span></p></li>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="rt1FC" runat="server">
                <ItemTemplate>
           <%#Container.ItemIndex == 0 || Container.ItemIndex == 4 ? "<li style='margin-right:0;'>" : "<li>"%><a href='<%#Eval("N_Url") %>' title='<%#Eval("N_Title") %>' target="_blank"><img runat="server" src='<%#Eval("N_Img") %>' /></a><p><b><%#Eval("N_Title").ToString().Length > 15 ? Eval("N_Title").ToString().Substring(0, 15) + "..." : Eval("N_Title")%></b><span><%#Eval("N_Content").ToString().Length > 15 ? Eval("N_Content").ToString().Substring(0, 15) + "..." : Eval("N_Content")%></span></p></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
        <div class="dlv_con">
    	<ul>
        	<asp:Repeater ID="rt2FA" runat="server">
                <ItemTemplate>
           <li><a href='<%#Eval("N_Url") %>' title='<%#Eval("N_Title") %>' target="_blank"><img id="Img1" runat="server" src='<%#Eval("N_Img") %>' /></a></li>     
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="rt2FB" runat="server">
                <ItemTemplate>
           <li style="width:495px;"><a href='<%#Eval("N_Url") %>' title='<%#Eval("N_Title") %>' target="_blank"><img id="Img2" runat="server" src='<%#Eval("N_Img") %>' /></a><p><b><%#Eval("N_Title").ToString().Length > 15 ? Eval("N_Title").ToString().Substring(0, 15) + "..." : Eval("N_Title")%></b><span><%#Eval("N_Content").ToString().Length > 15 ? Eval("N_Content").ToString().Substring(0, 15) + "..." : Eval("N_Content")%></span></p></li>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="rt2FC" runat="server">
                <ItemTemplate>
           <%#Container.ItemIndex == 0 || Container.ItemIndex == 4 ? "<li style='margin-right:0;'>" : "<li>"%><a href='<%#Eval("N_Url") %>' title='<%#Eval("N_Title") %>' target="_blank"><img id="Img3" runat="server" src='<%#Eval("N_Img") %>' /></a><p><b><%#Eval("N_Title").ToString().Length > 15 ? Eval("N_Title").ToString().Substring(0, 15) + "..." : Eval("N_Title")%></b><span><%#Eval("N_Content").ToString().Length > 15 ? Eval("N_Content").ToString().Substring(0, 15) + "..." : Eval("N_Content")%></span></p></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
        <div class="dlv_con">
    	<ul>
        	<asp:Repeater ID="rt3FA" runat="server">
                <ItemTemplate>
           <li><a href='<%#Eval("N_Url") %>' title='<%#Eval("N_Title") %>' target="_blank"><img id="Img4" runat="server" src='<%#Eval("N_Img") %>' /></a></li>     
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="rt3FB" runat="server">
                <ItemTemplate>
           <li style="width:495px;"><a href='<%#Eval("N_Url") %>' title='<%#Eval("N_Title") %>' target="_blank"><img id="Img5" runat="server" src='<%#Eval("N_Img") %>' /></a><p><b><%#Eval("N_Title").ToString().Length > 15 ? Eval("N_Title").ToString().Substring(0, 15) + "..." : Eval("N_Title")%></b><span><%#Eval("N_Content").ToString().Length > 15 ? Eval("N_Content").ToString().Substring(0, 15) + "..." : Eval("N_Content")%></span></p></li>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="rt3FC" runat="server">
                <ItemTemplate>
           <%#Container.ItemIndex == 0 || Container.ItemIndex == 4 ? "<li style='margin-right:0;'>" : "<li>"%><a href='<%#Eval("N_Url") %>' title='<%#Eval("N_Title") %>' target="_blank"><img id="Img6" runat="server" src='<%#Eval("N_Img") %>' /></a><p><b><%#Eval("N_Title").ToString().Length > 15 ? Eval("N_Title").ToString().Substring(0, 15) + "..." : Eval("N_Title")%></b><span><%#Eval("N_Content").ToString().Length > 15 ? Eval("N_Content").ToString().Substring(0, 15) + "..." : Eval("N_Content")%></span></p></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
        <div class="dlv_con">
    	<ul>
        	<asp:Repeater ID="rt4FA" runat="server">
                <ItemTemplate>
           <li><a href='<%#Eval("N_Url") %>' title='<%#Eval("N_Title") %>' target="_blank"><img id="Img7" runat="server" src='<%#Eval("N_Img") %>' /></a></li>     
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="rt4FB" runat="server">
                <ItemTemplate>
           <li style="width:495px;"><a href='<%#Eval("N_Url") %>' title='<%#Eval("N_Title") %>' target="_blank"><img id="Img8" runat="server" src='<%#Eval("N_Img") %>' /></a><p><b><%#Eval("N_Title").ToString().Length > 15 ? Eval("N_Title").ToString().Substring(0, 15) + "..." : Eval("N_Title")%></b><span><%#Eval("N_Content").ToString().Length > 15 ? Eval("N_Content").ToString().Substring(0, 15) + "..." : Eval("N_Content")%></span></p></li>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="rt4FC" runat="server">
                <ItemTemplate>
           <%#Container.ItemIndex == 0 || Container.ItemIndex == 4 ? "<li style='margin-right:0;'>" : "<li>"%><a href='<%#Eval("N_Url") %>' title='<%#Eval("N_Title") %>' target="_blank"><img id="Img9" runat="server" src='<%#Eval("N_Img") %>' /></a><p><b><%#Eval("N_Title").ToString().Length > 15 ? Eval("N_Title").ToString().Substring(0, 15) + "..." : Eval("N_Title")%></b><span><%#Eval("N_Content").ToString().Length > 15 ? Eval("N_Content").ToString().Substring(0, 15) + "..." : Eval("N_Content")%></span></p></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <div class="clear"></div>
</div>
<div  style="width:1000px; margin:0 auto; padding-bottom:14px;"><a href="splb.aspx" target="_blank"><img src="images/dl_more_video.gif" /></a></div>
<uc1:foot ID="foot1" runat="server" />
</form>
<script type="text/javascript">
    var flag = "left";
    function DY_scroll(wraper, prev, next, img, speed, or) {
        var wraper = $(wraper);
        var prev = $(prev);
        var next = $(next);
        var img = $(img).find('ul');
        var w = img.find('li').outerWidth(true);
        var s = speed;
        next.click(function () {
            img.animate({ 'margin-left': -w}/*,1500,'easeOutBounce'*/, function () {
                img.find('li').eq(0).appendTo(img);
                img.css({ 'margin-left': 0 });
            });
            flag = "left";
        });
        prev.click(function () {
            img.find('li:last').prependTo(img);
            img.css({ 'margin-left': -w });
            img.animate({ 'margin-left': 0}/*,1500,'easeOutBounce'*/);
            flag = "right";
        });
        if (or == true) {
            ad = setInterval(function () { flag == "left" ? next.click() : prev.click() }, s * 1000);
            wraper.hover(function () { clearInterval(ad); }, function () { ad = setInterval(function () { flag == "left" ? next.click() : prev.click() }, s * 1000); });
        }
    }
    DY_scroll('.hl_main5_content', '.hl_scrool_leftbtn', '.hl_scrool_rightbtn', '.hl_main5_content1', 2, true); // true为自动播放，不加此参数或false就默认不自动 
</script> 
</body>
</html>

