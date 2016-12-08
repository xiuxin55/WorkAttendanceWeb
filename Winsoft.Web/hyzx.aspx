<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hyzx.aspx.cs" Inherits="Winsoft.Web.hyzx" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
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
<script type="text/javascript" src="js/jquery-1.9.1.min.js"></script>
</head>

<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<uc1:top ID="top1" runat="server" />
<div class="dlp_ttl">
    	<a href="index.aspx">首页</a>&nbsp;>&nbsp;<a href="hyzx.aspx">会员中心</a>
</div>
<div class="dlp_main">
	<uc1:left ID="left1" runat="server" />
    <div class="dlm_fwzx_right">
    	<div class="dfr_ttl"><b>&nbsp;&nbsp;&nbsp;&nbsp;会员中心</b></div>
        <div class="dfr_con">
            	<div class="dlh_top">
                	<div class="dht_l"><img id="M_Img" runat="server" src="~/images/5546.png" /></div>
					<div class="dht_r">
                    	<em><b><asp:Label ID="M_Username" runat="server" Text=""></asp:Label></b>，欢迎您</em>
                        <i>
                        	<p>订单提醒：<asp:LinkButton ID="btnWfkCount" runat="server" onclick="btnWfkCount_Click" Text="待支付课程（0）"/>&nbsp;&nbsp;&nbsp;&nbsp; </p>
                            <p>我的收藏：<asp:LinkButton ID="btnWdscCount" runat="server" onclick="btnWdscCount_Click" Text="已收藏课程（0）"/></p>
                        </i>
                    </div>
                </div>
           <script type=text/javascript>
               function tabs(tabId, tabNum) {
                   //设置点击后的切换样式
                   $(tabId + " .dhc_t a").attr("id", "");

                   $(tabId + " .dhc_t a").eq(tabNum).attr("id", "dct_a1");
                   //根据参数决定显示内容
                   $(tabId + " .dhc_m").hide();
                   $(tabId + " .dhc_m").eq(tabNum).show();
               }
            </script>
                <div class="dlh_cnxh" id="dlh_cnxh">
                	<div class="dhc_t">
                    	<a href="javascript:void(0);" onclick="tabs('#dlh_cnxh',0)" class="dct_a2" id="dct_a1">我的收藏</a>
                        <a href="javascript:void(0);" onclick="tabs('#dlh_cnxh',1)" class="dct_a2">最近浏览</a>
                    </div>
                    <div class="dhc_m" id="dhcm1">
                    	<div class="dhm_l" id="dhml1"><img src="images/dl_xh_l.gif" /></div>
                        <div class="dhm_c" id="dhmc1">
                        	<ul>
                            	<asp:Repeater ID="rtWdsc" runat="server">
                                    <ItemTemplate>
                                <li><a href="spxq.aspx?id=<%#Eval("V_ID")%>" title='<%#Eval("V_Name")%>' target="_blank"><img runat="server" src='<%#Eval("V_SmallImg")%>' /><p><%#Eval("V_Name").ToString().Length > 10 ? Eval("V_Name").ToString().Substring(0, 10) + "..." : Eval("V_Name")%></p></a></li>    
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <div class="dhm_r" id="dhmr1"><img src="images/dl_xh_r.gif" /></div>
                    </div>   
                    <div class="dhc_m" id="dhcm2" style="display:none;">
                    	<div class="dhm_l" id="dhml2"><img src="images/dl_xh_l.gif" /></div>
                        <div class="dhm_c" id="dhmc2">
                        	<ul>
                            	<asp:Repeater ID="rtZjll" runat="server">
                                    <ItemTemplate>
                                <li><a href="spxq.aspx?id=<%#Eval("V_ID")%>" title='<%#Eval("V_Name")%>' target="_blank"><img id="Img1" runat="server" src='<%#Eval("V_SmallImg")%>' /><p><%#Eval("V_Name").ToString().Length > 10 ? Eval("V_Name").ToString().Substring(0, 10) + "..." : Eval("V_Name")%></p></a></li>    
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <div class="dhm_r" id="dhmr2"><img src="images/dl_xh_r.gif" /></div>
                    </div> 	
                </div>
                <div class="dlh_cnxh" id="Div1">
                	<div class="dhc_t">
                    	<a href="javascript:void(0);" onclick="tabs('#dlh_cnxh',0)" id="A1">猜你喜欢</a>
                        <a href="javascript:void(0);" onclick="tabs('#dlh_cnxh',1)" >最近浏览</a>
                    </div>
                    <div class="dhc_m" id="Div2">
                    
                    <div class="rollBox">
	<div class="scrollcon">
		<div class="LeftBotton" onmousedown="ISL_GoUp()" onmouseup="ISL_StopUp()" onmouseout="ISL_StopUp()"><img src="images/dl_xh_l.gif" /></div>
		<div class="Cont" id="ISL_Cont">
			<div class="ScrCont">
				<div id="List1"  style="margin-left:12px;">
					<!-- 图片列表 begin -->
					<div class="pic"><a href="/"><img src="images/dl_i2.gif" /></a><p>健身时你要注意</p></div> 
					<div class="pic"><a href="/"><img src="images/dl_i2.gif" /></a><p>健身时你要注意</p></div>
					<div class="pic"><a href="/"><img src="images/dl_i2.gif" /></a><p>健身时你要注意</p></div> 
					<div class="pic"><a href="/"><img src="images/dl_i2.gif" /></a><p>健身时你要注意</p></div>
					<!-- 图片列表 end -->
				</div>
				<div id="List2"></div>
			</div>
		</div>
		<div class="RightBotton" onmousedown="ISL_GoDown()" onmouseup="ISL_StopDown()" onmouseout="ISL_StopDown()"><img src="images/dl_xh_r.gif" /></div>
	</div><!--content end-->
</div>
</div>
                       
                    <div class="dhc_m" style="display:none" id="dhcm2">
                    	<div class="dhm_l" id="dhml2"><img src="images/dl_xh_l.gif" /></div>
                        <div class="dhm_c" id="dhmc2">
                        	<ul>
                            	<li><a href="/"><img src="images/dl_i2.gif" /><p>健身时你要注意</p></a></li>
                                <li><a href="/"><img src="images/dl_i3.gif" /><p>健身时你要注意</p></a></li>
                                <li><a href="/"><img src="images/dl_i3.gif" /><p>健身时你要注意</p></a></li>
                            </ul>
                        </div>
                        <div class="dhm_r" id="dhmr2"><img src="images/dl_xh_r.gif" /></div>
                    </div> 	
                </div>
                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
            <div class="dlh_cnxh">
                <div class="dhc_t">
                    <asp:LinkButton ID="btnWfk" runat="server" CssClass="dct_a1" onclick="btnWfk_Click" Text="未付款课程" />
                    <asp:LinkButton ID="btnYgm" runat="server" CssClass="dct_a2" onclick="btnYgm_Click" Text="已购买课程" />
                    <asp:LinkButton ID="btnYqx" runat="server" CssClass="dct_a2" onclick="btnYqx_Click" Text="已取消课程" />
                </div>
                <div id="divWfk" runat="server" class="right_02_b">
                <table border="0" cellpadding="0" cellspacing="0" width="791" class="goods_sc">
                    <tbody>
                      <tr>
                        <td width="108" height="38" >订单编号</td>
                        <td width="391" colspan="2" class="ddsp">视频图片/名称</td>
                        <td width="91">订单金额</td>
                        <td width="91">下单时间</td>
                        <td width="125" class="goods_td">操作</td>
                      </tr>
                      <asp:Repeater ID="rtWfk" runat="server" onitemcommand="rtWfk_ItemCommand" onitemcreated="rtWfk_ItemCreated">
                        <ItemTemplate>
                      <tr>
                        <td width="108" height="108" ><%#Eval("O_Order")%></td>
                        <td width="101" class="ddsp"><a href="spxq.aspx?id=<%#Eval("V_ID")%>" title='<%#Eval("V_Name")%>' target="_blank"><img id="Img2" runat="server" src='<%#Eval("V_SmallImg")%>' width="90" height="100" /></a></td>
                        <td width="290" class="ddsp">
                        	<p><a href="spxq.aspx?id=<%#Eval("V_ID")%>" title='<%#Eval("V_Name")%>' target="_blank"><%#Eval("V_Name")%></a></p>
                       	    <p>&nbsp;</p>
                        </td>
                        <td width="91"><strong>￥<%#Eval("O_Price")%></strong></td>
                        <td width="91"><%#Eval("O_NextTime").ToString() != string.Empty ? Convert.ToDateTime(Eval("O_NextTime")).ToString("yyyy-MM-dd HH:mm:ss") : ""%></td>
                        <td width="125" class="goods_td">
                            <p><asp:LinkButton ID="btnQfk" runat="server" Text="[去付款]" CommandName="qfk" CommandArgument='<%#Eval("O_ID") %>'/></p>
                            <p><asp:LinkButton ID="btnQxdd" runat="server" Text="[取消订单]" CommandName="qxdd" CommandArgument='<%#Eval("O_ID") %>'/></p>                          
                        </td>
                      </tr>  
                        </ItemTemplate>
                      </asp:Repeater>
                      <%
                          if (this.rtWfk.Items.Count == 0)
                          {
                      %>
                      <tr>
                        <td class="ddsp" colspan="6">暂无信息</td>
                      </tr>
                      <%        
                          }
                           %>
                    </tbody>
                </table>
                <div class="paging"><webdiyer:AspNetPager ID="AspNetPagerWfk" runat="server" FirstPageText="首页" HorizontalAlign="Center" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" onpagechanged="AspNetPagerWfk_PageChanged"> </webdiyer:AspNetPager></div>  	
                </div>
                <div id="divYgm" runat="server" class="right_02_b" visible="false">
                <table border="0" cellpadding="0" cellspacing="0" width="791" class="goods_sc">
                    <tbody>
                      <tr>
                        <td width="108" height="38" >订单编号</td>
                        <td width="325" colspan="2" class="ddsp">视频图片/名称</td>
                        <td width="91">订单金额</td>
                        <td width="182" colspan="2">付款时间</td>
                      </tr>
                      <asp:Repeater ID="rtYgm" runat="server">
                        <ItemTemplate>
                      <tr>
                        <td width="108" height="108" ><%#Eval("O_Order")%></td>
                        <td width="101" class="ddsp"><a href="spxq.aspx?id=<%#Eval("V_ID")%>" title='<%#Eval("V_Name")%>' target="_blank"><img id="Img1" runat="server" src='<%#Eval("V_SmallImg")%>' width="90" height="100" /></a></td>
                        <td width="325" class="ddsp">
                        	<p><a href="spxq.aspx?id=<%#Eval("V_ID")%>" title='<%#Eval("V_Name")%>' target="_blank"><%#Eval("V_Name")%></a></p>
                       	    <p>&nbsp;</p>
                        </td>
                        <td width="91"><strong>￥<%#Eval("O_Price")%></strong></td>
                        <td width="182"><%#Eval("O_PaymentTime").ToString() != string.Empty ? Convert.ToDateTime(Eval("O_PaymentTime")).ToString("yyyy-MM-dd HH:mm:ss") : ""%></td>
                      </tr>  
                        </ItemTemplate>
                      </asp:Repeater>
                      <%
                          if (this.rtYgm.Items.Count == 0)
                          {
                      %>
                      <tr>
                        <td class="ddsp" colspan="4">暂无信息</td>
                      </tr>
                      <%        
                          }
                           %>
                    </tbody>
                </table>
                <div class="paging"><webdiyer:AspNetPager ID="AspNetPagerYgm" runat="server" FirstPageText="首页" HorizontalAlign="Center" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" onpagechanged="AspNetPagerYgm_PageChanged"> </webdiyer:AspNetPager></div>  	
                </div>
                <div id="divYqx" runat="server" class="right_02_b" visible="false">
                <table border="0" cellpadding="0" cellspacing="0" width="791" class="goods_sc">
                    <tbody>
                      <tr>
                        <td width="108" height="38" >订单编号</td>
                        <td width="325" colspan="2" class="ddsp">视频图片/名称</td>
                        <td width="91">订单金额</td>
                        <td width="182" colspan="2">下单时间</td>
                      </tr>
                      <asp:Repeater ID="rtYqx" runat="server">
                        <ItemTemplate>
                      <tr>
                        <td width="108" height="108" ><%#Eval("O_Order")%></td>
                        <td width="101" class="ddsp"><a href="spxq.aspx?id=<%#Eval("V_ID")%>" title='<%#Eval("V_Name")%>' target="_blank"><img id="Img1" runat="server" src='<%#Eval("V_SmallImg")%>' width="90" height="100" /></a></td>
                        <td width="325" class="ddsp">
                        	<p><a href="spxq.aspx?id=<%#Eval("V_ID")%>" title='<%#Eval("V_Name")%>' target="_blank"><%#Eval("V_Name")%></a></p>
                       	    <p>&nbsp;</p>
                        </td>
                        <td width="91"><strong>￥<%#Eval("O_Price")%></strong></td>
                        <td width="182"><%#Eval("O_NextTime").ToString() != string.Empty ? Convert.ToDateTime(Eval("O_NextTime")).ToString("yyyy-MM-dd HH:mm:ss") : ""%></td>
                      </tr>  
                        </ItemTemplate>
                      </asp:Repeater>
                      <%
                          if (this.rtYqx.Items.Count == 0)
                          {
                      %>
                      <tr>
                        <td class="ddsp" colspan="5">暂无信息</td>
                      </tr>
                      <%        
                          }
                           %>
                    </tbody>
                </table>
                <div class="paging"><webdiyer:AspNetPager ID="AspNetPagerYqx" runat="server" FirstPageText="首页" HorizontalAlign="Center" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" onpagechanged="AspNetPagerYqx_PageChanged"> </webdiyer:AspNetPager></div>  	
                </div>
            </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
<div style="width:100%; overflow:hidden; clear:both;"></div>
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
    DY_scroll('#dhcm1', '#dhml1', '#dhmr1', '#dhmc1', 2, true); // true为自动播放，不加此参数或false就默认不自动 
</script> 


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
    DY_scroll('#dhcm2', '#dhml2', '#dhmr2', '#dhmc2', 2, true); // true为自动播放，不加此参数或false就默认不自动 
</script> 

</body>
</html>

