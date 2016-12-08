<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hyzx_wddd.aspx.cs" Inherits="Winsoft.Web.hyzx_wddd" %>
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
    	<div class="dfr_ttl"><b>&nbsp;&nbsp;&nbsp;&nbsp;我的订单</b></div>
        <div class="dfr_con">
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
                        <td width="101" class="ddsp"><a href="spxq.aspx?id=<%#Eval("V_ID")%>" title='<%#Eval("V_Name")%>' target="_blank"><img runat="server" src='<%#Eval("V_SmallImg")%>' width="90" height="100" /></a></td>
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
</body>
</html>

