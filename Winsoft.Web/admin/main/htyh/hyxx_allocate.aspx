<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hyxx_allocate.aspx.cs" Inherits="Winsoft.Web.admin.main.htyh.hyxx_allocate" EnableEventValidation="false" %>

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
</script>
</head>
<body style="background:#F5F9FC;">
    <form id="form1" runat="server">

    <table cellpadding="0" cellspacing="1" class="table04">
    <tr style="color:#135294; background:#eef7fd;" align="left">
            	<td colspan="4"><span style="margin-left:5px;font-weight:bold;">您当前的位置：</span><asp:HyperLink 
                        ID="lblMenu1" runat="server" ForeColor="#135294"></asp:HyperLink>=>
                <asp:HyperLink ID="lblMenu2" runat="server" ForeColor="#135294"></asp:HyperLink>=><asp:HyperLink 
                        ID="lblMenu3" runat="server" ForeColor="#135294"></asp:HyperLink> </td>
            </tr>
          <tr>
            <th nowrap="nowrap" width="5%" class="table04_1">序号</th>
            <th nowrap="nowrap" width="15%" class="table04_1">网点号</th>
            <th nowrap="nowrap" width="20%" class="table04_1">网点名称</th>
            <th nowrap="nowrap" width="5%" class="table04_1">分配数量</th>
          
          </tr>
          <asp:Repeater ID="rtManager" runat="server">
            <ItemTemplate>
          <tr onmouseover="changeto(this)" onmouseout="changeback(this)">
            <td nowrap="nowrap" class="table04_c"><asp:Label  runat="server" id ="order" ><%# Container.ItemIndex + 1 %></asp:Label ></td>
            <td nowrap="nowrap" class="table04_l"><asp:Label runat="server"  id ="WebsiteID" Text='<%#Eval("WebsiteID")%>'></asp:Label ></td>
            <td nowrap="nowrap" class="table04_l"><asp:Label  runat="server" id ="WebsiteName" Text='<%#Eval("WebsiteName")%>'></asp:Label ></td>
            <td nowrap="nowrap" class="table04_c" valign="middle"><input runat="server" id="PrizeCount" type="text" value='<%#Eval("PrizeAmount")%>' class="tab" />
            
            </span></td>
            
            <%--<a href='hyxx_xgmm.aspx?code=<%=Request["code"] %>&id=<%#Eval("US_UserID")%>'>修改密码</a>
            <a href='hyxx_xgyx.aspx?code=<%=Request["code"] %>&id=<%#Eval("US_UserID")%>'>修改邮箱</a>--%>
            
          </tr>
            </ItemTemplate>
          </asp:Repeater>
          <%--<%# (Container.ItemIndex + 1 + (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize).ToString("00")%>--%>
          <% if (rtManager.Items.Count == 0)
             { %>
          <tr>
            <td nowrap="nowrap" colspan="4"><span>暂时没有找到相关的数据</span></td>
          </tr>
          <%} %>
           <tr>	
                <td align="center" style="padding-right:10px;" colspan="4">
                   
                    <asp:Button ID="Button1" runat="server" Text="分配" CssClass="page02_x" 
                        onclick="btnAllocate_Click" Width="52px"/>&nbsp;&nbsp;
                    <asp:Button ID="btnResult" runat="server" Text="返 回" CssClass="page02_4" onclick="btnResult_Click"  />
                </td>
            </tr>
<%--          <%#Eval("US_UserName")%>--%>
            <tr>
            	<%--<td colspan="5" class="table04_1" style="border-right:0px;">
                	<span class="table04_5"><webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" 
        HorizontalAlign="Center" LastPageText="尾页" NextPageText="下一页" 
        PrevPageText="上一页" onpagechanged="AspNetPager1_PageChanged"> </webdiyer:AspNetPager></span>
                </td>--%>
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
