<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="spzb.aspx.cs" Inherits="Winsoft.Web.admin.main.scsp.spzb" %>

<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>逗留网管理系统</title>
<link href="../../css/style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../../../My97DatePicker/WdatePicker.js"></script>
<script>
    var highlightcolor = '#c1ebff';
    //此处clickcolor只能用win系统颜色代码才能成功,如果用#xxxxxx的代码就不行,还没搞清楚为什么:(
    var clickcolor = '#51b2f6';
    function changeto(change) {
        change.style.background = "#c1ebff";
    }

    function changeback(change) {
        change.style.background = "#fff";
    }
    function CheckAll(eee, itemname, ee) {
        var aa = document.getElementsByName(itemname);
        //var check = document.getElementById(ee);
        var e = document.getElementById(eee);
        if (aa == undefined) {
            return;
        } else {
            for (var i = 0; i < aa.length; i++) {
                aa[i].checked = e.checked;
            }

        }
    }
</script>
</head>
<body style="background:#F5F9FC;">
    <form id="form1" runat="server">
    <table cellpadding="0" cellspacing="1" class="table03">
            	<tr style="color:#135294; background:#eef7fd;" align="left">
                	<td><span style="margin-left:5px;font-weight:bold;">您当前的位置：</span><asp:Label ID="lblMenu" runat="server" Text=""></asp:Label> </td>
                </tr>
   			    <tr style="color:#135294;">
                    <td colspan="5" align="left">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="margin-top:10px;">
                        <tr>
                            <td class="dzlc_ttl">
                                <asp:LinkButton ID="btnPre" runat="server" CssClass="dzlc_ttl_a1" Text="上一周" onclick="btnPre_Click" />
                                <asp:LinkButton ID="btnNow" runat="server" CssClass="dzlc_ttl_a1" Text="本周" onclick="btnNow_Click" />
                                <asp:LinkButton ID="btnNext" runat="server" CssClass="dzlc_ttl_a1" Text="下一周" onclick="btnNext_Click" />
                                <asp:LinkButton ID="btnDay1" runat="server" CssClass="dzlc_ttl_a1" Text="星期一" onclick="btnDay1_Click" />
                                <asp:LinkButton ID="btnDay2" runat="server" CssClass="dzlc_ttl_a1" Text="星期二" onclick="btnDay2_Click" />
                                <asp:LinkButton ID="btnDay3" runat="server" CssClass="dzlc_ttl_a1" Text="星期三" onclick="btnDay3_Click" />
                                <asp:LinkButton ID="btnDay4" runat="server" CssClass="dzlc_ttl_a1" Text="星期四" onclick="btnDay4_Click" />
                                <asp:LinkButton ID="btnDay5" runat="server" CssClass="dzlc_ttl_a1" Text="星期五" onclick="btnDay5_Click" />
                                <asp:LinkButton ID="btnDay6" runat="server" CssClass="dzlc_ttl_a1" Text="星期六" onclick="btnDay6_Click" />
                                <asp:LinkButton ID="btnDay7" runat="server" CssClass="dzlc_ttl_a1" Text="星期日" onclick="btnDay7_Click" />
                            </td>
                        </tr>
                    </table>
                    </td>    
                </tr>
                <tr>
                	<td align="left">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="padding-left:5px;">直播时间：</td>
                            <td>
                                <asp:TextBox ID="VL_LiveTime" onclick="WdatePicker();" runat="server" CssClass="page02_2" Width="80"></asp:TextBox>
                            </td>
                            <td class="tab_c">
                                <asp:Button ID="btnCommit" runat="server" Text="查 询" CssClass="page02_4" onclick="btnCommit_Click" />
                            </td>
                        </tr>
                    </table>
                    </td>
                </tr>
        </table>
        <table cellpadding="0" cellspacing="1" class="table04">
          <tr>
            <th width="3%" class="table04_1"><input class="tab_p" type="checkbox" id="checkbox" name="checkbox" value="1" onclick="CheckAll('checkbox','Item','chkall')"/></th>
            <th class="table04_1" colspan="3">
                <span style="font-size:22px; font-weight:bold;font-family:'微软雅黑';float:left;"><asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></span>
                <span style="float:right; margin-top:7px;">
                    <asp:Button ID="btnAdd" runat="server" Text="新 增" CssClass="page02_4" onclick="btnAdd_Click" />
                    <asp:Button ID="btnAllDelete" runat="server" Text="批量删除" CssClass="page02_5" onclick="btnAllDelete_Click" />
                </span>
            </th>
          </tr>
          <asp:Repeater ID="rtManager" runat="server" onitemcommand="rtManager_ItemCommand" onitemcreated="rtManager_ItemCreated">
            <ItemTemplate>
          <tr>
            <td class="table04_c" rowspan="2"><span><input class="tab_p" type="checkbox" name="Item" value="<%# Eval("VL_ID") %>" /></span></td>
            <td class="table04_c" rowspan="2" width="100" height="100"><img id="Img1" runat="server" src='<%#Eval("VL_SmallImg") %>' width="90" height="90" /></td>
             <%#Convert.ToDateTime(Eval("VL_LiveETime").ToString()) < DateTime.Now ? "<td class='table04_l' style='background-color: #FF7256;'>" : ""%>
             <%#Convert.ToDateTime(Eval("VL_LiveSTime").ToString()) <= DateTime.Now && Convert.ToDateTime(Eval("VL_LiveETime").ToString()) >= DateTime.Now ? "<td class='table04_l' style='background-color: #00CD00;'>" : ""%>
             <%#Convert.ToDateTime(Eval("VL_LiveSTime").ToString()) > DateTime.Now ? "<td class='table04_l' style='background-color: #FFD700;'>" : ""%>
                <span  style="font-size:22px; font-weight:bold;font-family:'微软雅黑';float:left;">
                    <%#Eval("VL_Name")%> <%#Convert.ToDateTime(Eval("VL_LiveSTime")).ToString("HH:mm")%>-<%#Convert.ToDateTime(Eval("VL_LiveETime")).ToString("HH:mm")%>
                </span>
                <span style="float:right;margin-top:10px;">
                    <%#Convert.ToDateTime(Eval("VL_LiveETime").ToString()) < DateTime.Now ? "已播放" : ""%>
                    <%#Convert.ToDateTime(Eval("VL_LiveSTime").ToString()) <= DateTime.Now && Convert.ToDateTime(Eval("VL_LiveETime").ToString()) >= DateTime.Now ? "正在播放" : ""%>
                    <%#Convert.ToDateTime(Eval("VL_LiveSTime").ToString()) > DateTime.Now ? "未播放" : ""%>
                </span>
            </td>
            <td class="table04_c" rowspan="2" width="100" height="100"><span class="tab">
                <a href='<%# M_EUrl +"&id="+ Eval("VL_ID") %>'>编辑</a> |
                <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CommandName="delete" CommandArgument='<%#Eval("VL_ID") %>' />
            </span></td>
          </tr>
          <tr>
            <td class="table04_l" style="padding:5px; vertical-align:top; line-height:23px;" ><%#Eval("V_Content").ToString().Length > 100 ? Eval("V_Content").ToString().Substring(0, 100) + "..." : Eval("V_Content")%></td>
          </tr>  
            </ItemTemplate>
          </asp:Repeater>
          <%
              if (this.rtManager.Items.Count == 0)
              {
          %>
          <tr>
            <td colspan="4"><span>暂时没有找到相关的数据</span></td>
          </tr>
          <%        
              }
               %>
        </table>
        <br />
        <!-- 隐藏域 -->
    <asp:HiddenField ID="H_Time" runat="server" />
    </form>
</body>
</html>
