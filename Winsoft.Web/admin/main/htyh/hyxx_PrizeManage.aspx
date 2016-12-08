<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hyxx_PrizeManage.aspx.cs" Inherits="Winsoft.Web.admin.main.htyh.hyxx_PrizeManage" EnableEventValidation="false" %>

<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>信用卡兑奖系统 </title>
<link href="../../css/style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../../../My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
    var highlightcolor = '#c1ebff';
    //此处clickcolor只能用win系统颜色代码才能成功,如果用#xxxxxx的代码就不行,还没搞清楚为什么:(
    var clickcolor = '#51b2f6';
    function changeto(change) {
        change.style.background = "#c1ebff";
    }

    function changeback(change) {
        change.style.background = "#fff";
    }
    function DeletePrizeTableDataRow(id) {
        var context = "Complete";
        AjaxService.DeletePrizeTableDataRow(id, OnComplete, OnFailed, context);
    }
    function OnComplete(args, context) {
        alert(args);
        location.reload();
    }

    function OnFailed(args) {
        alert("删除失败！");
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
    function ViewDetail(guid) {
        var iWidth = window.screen.availWidth-380;                          //弹出窗口的宽度;
        var iHeight = window.screen.availHeight-120;                        //弹出窗口的高度;
        var iTop = (window.screen.availHeight - 30 - iHeight) / 2;       //获得窗口的垂直位置;
        var iLeft = (window.screen.availWidth - 10 - iWidth) / 2;           //获得窗口的水平位置;
        //      
        var agent = navigator.userAgent.toLowerCase();
////        if (agent.indexOf("chrome") > 0)
////        { window.open("hyxx_PrizeLeftAmount.aspx?id=" + guid, "newwindow", "width=" + iWidth + ",height=" + iHeight + ",top=" + iTop + " ,left=" + iLeft + ""); }
////        else {
////            var win = showModalDialog("hyxx_PrizeLeftAmount.aspx?id=" + guid, "newwindow", "edge: Raised;resizable: Yes;dialogwidth:" + iWidth + "px;dialogheight:" + iHeight + "px;dialogtop:" + iTop + "px;dialogleft:" + iLeft + "px;scroll:yes");
////            if (win == 2) { //返回值 .可以修改.如果有值
////                location.href = "hyxx_PrizeLeftAmount.aspx";

////            }
        ////        }
          location.href ="hyxx_PrizeLeftAmount.aspx?id=" + guid;
    }
</script>
</head>
<body style="background:#F5F9FC;">
    <form id="form1" runat="server">

    <table cellpadding="0" cellspacing="1" class="table04">
    <tr style="color:#135294; background:#eef7fd;" align="left">
            	<td colspan="8"><span style="margin-left:5px;font-weight:bold;">您当前的位置：</span><asp:HyperLink 
                        ID="lblMenu1" runat="server" ForeColor="#135294"></asp:HyperLink>=>
                <asp:HyperLink ID="lblMenu2" runat="server" ForeColor="#135294"></asp:HyperLink> </td>
            </tr>
          <tr>
            <th nowrap="nowrap" width="5%" class="table04_1">序号</th>
            <th nowrap="nowrap" width="5%" class="table04_1">奖品名称</th>
            <th nowrap="nowrap" width="5%" class="table04_1">奖品剩余量</th>
            <th nowrap="nowrap" width="5%" class="table04_1">奖品已兑量</th>
            <th nowrap="nowrap" width="5%" class="table04_1">奖品总数</th>
            <th nowrap="nowrap" width="5%" class="table04_1">编辑操作</th>
            <th nowrap="nowrap" width="5%" class="table04_1">删除操作</th>
             <th nowrap="nowrap" width="5%" class="table04_1">查看操作</th>
          </tr>
          <asp:Repeater ID="rtManager" runat="server">
            <ItemTemplate>
          <tr onmouseover="changeto(this)" onmouseout="changeback(this)">
            <td nowrap="nowrap" class="table04_c"><span><%# (Container.ItemIndex + 1 + (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize).ToString("00")%></span></td>
            <td nowrap="nowrap" class="table04_l"><span><%#Eval("PrizeName")%></span></td>

            <%-- <a href='hyxx_PrizeLeftAmount.aspx?id=<%# Eval("PrizeID") %>'><%#Eval("PrizeLeftAmount")%></a>
              <a href='hyxx_PrizeEdit.aspx?id=<%# Eval("PrizeID") %>'><%#Eval("PrizeUsedAmount")%></a>
               <a href='hyxx_PrizeEdit.aspx?id=<%# Eval("PrizeID") %>'><%#Eval("PrizeAmount")%></a>--%>
            <td nowrap="nowrap" class="table04_l"><span><%#Eval("PrizeLeftAmount")%></span></td>
            <td nowrap="nowrap" class="table04_l"><span><%#Eval("PrizeUsedAmount")%></span></td>
            <td nowrap="nowrap" class="table04_l"><span><%#Eval("PrizeAmount")%></span></td>
            <td nowrap="nowrap" class="table04_c" valign="middle"><span class="tab">
            <a href='hyxx_PrizeEdit.aspx?id=<%# Eval("PrizeID") %>'>编辑</a>
            </span></td>
            <td nowrap="nowrap" class="table04_c" valign="middle"><span class="tab">
            <a href='#' onclick='DeletePrizeTableDataRow("<%# Eval("PrizeID")%>")'>删除</a>
            </span></td>
            <td nowrap="nowrap" class="table04_c" valign="middle"><span >
          
            <input id="btn_DJ" type="button" value="查看"  onclick="ViewDetail('<%# Eval("PrizeID") %>');"  style="background-image: url('../../img/p03_1.png'); background-repeat: repeat-x; width: 55px;" />
           
            </span></td>

            <%--<a href='hyxx_xgmm.aspx?code=<%=Request["code"] %>&id=<%#Eval("US_UserID")%>'>修改密码</a>
            <a href='hyxx_xgyx.aspx?code=<%=Request["code"] %>&id=<%#Eval("US_UserID")%>'>修改邮箱</a>--%>
            
          </tr>
            </ItemTemplate>
          </asp:Repeater>
          <%--<%# (Container.ItemIndex + 1 + (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize).ToString("00")%>--%>
          <tr>
            <td nowrap="nowrap" colspan="8"><span>暂时没有找到相关的数据</span></td>
          </tr>
<%--          <%#Eval("US_UserName")%>--%>
            <tr>
            	<td colspan="8" class="table04_1" style="border-right:0px;">
                	<span class="table04_5"><webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" 
        HorizontalAlign="Center" LastPageText="尾页" NextPageText="下一页" 
        PrevPageText="上一页" onpagechanged="AspNetPager1_PageChanged"> </webdiyer:AspNetPager></span>
                </td>
            </tr>
        </table>
    <br />    
    <asp:ScriptManager ID="ScriptManager_wdjl" runat="server">
     <Services>
            <asp:ServiceReference Path="~/Ajax/AjaxService.svc" />
        </Services>
    </asp:ScriptManager>
    </form>
</body>
</html>
