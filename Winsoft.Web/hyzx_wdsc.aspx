<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hyzx_wdsc.aspx.cs" Inherits="Winsoft.Web.hyzx_wdsc" %>
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
<uc1:top ID="top1" runat="server" />
<div class="dlp_ttl">
    	<a href="index.aspx">首页</a>&nbsp;>&nbsp;<a href="hyzx.aspx">会员中心</a>
</div>
<div class="dlp_main">
	<uc1:left ID="left1" runat="server" />
    <div class="dlm_fwzx_right">
    	<div class="dfr_ttl"><b>&nbsp;&nbsp;&nbsp;&nbsp;我的收藏</b></div>
        <div class="dfr_con">
                <div class="dlh_cnxh" id="dlh_cnxh">
                    <div class="right_02_b">
                    <div class="scdj_fl">
                        <em><input id="V_Name" runat="server" type="text" /><asp:Button ID="btnCommit" runat="server" Text="查 询" onclick="btnCommit_Click" /></em>
                    </div>
                <table border="0" cellpadding="0" cellspacing="0" width="791" class="goods_sc">
                    <tbody>
                    <tr>
                        <td height="38" colspan="2" class="ddsp">视频图片/名称</td>
                        <td width="91">优惠价</td>
                        <td width="142">收藏时间</td>
                        <td width="145" class="goods_td">操作</td>
                      </tr>
                      <asp:Repeater ID="rtManage" runat="server" onitemcommand="rtManage_ItemCommand" onitemcreated="rtManage_ItemCreated">
                        <ItemTemplate>
                      <tr>
                        <td height="108" class="ddsp" width="101"><a href="spxq.aspx?id=<%#Eval("V_ID")%>" title='<%#Eval("V_Name")%>' target="_blank"><img runat="server" src='<%#Eval("V_SmallImg")%>' width="90" height="100" /></a></td>
                        <td width="290" class="ddsp">
                        	<p><a href="spxq.aspx?id=<%#Eval("V_ID")%>" title='<%#Eval("V_Name")%>' target="_blank"><%#Eval("V_Name")%></a></p>
                       	<p>&nbsp;</p></td>
                        <td><strong>￥<%#Eval("V_NewPrice")%></strong></td>
                        <td><%#Eval("C_Time").ToString() != string.Empty ? Convert.ToDateTime(Eval("C_Time")).ToString("yyyy-MM-dd HH:mm:ss") : ""%></td>
                        <td class="goods_td">
                        	<asp:LinkButton ID="btnDelete" runat="server" Text="[删除收藏]" CommandName="delete" CommandArgument='<%#Eval("C_ID") %>' />                  
                        </td>
                      </tr>  
                        </ItemTemplate>
                      </asp:Repeater>
                      <%
                          if (this.rtManage.Items.Count == 0)
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
                  <div class="paging"><webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" HorizontalAlign="Center" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" onpagechanged="AspNetPager1_PageChanged"> </webdiyer:AspNetPager></div>  	
              </div>
             </div>
        </div>
    </div>
</div>
<div style="width:100%; overflow:hidden; clear:both;"></div>
<uc1:foot ID="foot1" runat="server" />
</form>
</body>
</html>

