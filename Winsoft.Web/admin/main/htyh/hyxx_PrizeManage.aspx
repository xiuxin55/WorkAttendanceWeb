<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hyxx_PrizeManage.aspx.cs" Inherits="Winsoft.Web.admin.main.htyh.hyxx_PrizeManage" EnableEventValidation="false" %>

<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>���ÿ��ҽ�ϵͳ </title>
<link href="../../css/style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../../../My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
    var highlightcolor = '#c1ebff';
    //�˴�clickcolorֻ����winϵͳ��ɫ������ܳɹ�,�����#xxxxxx�Ĵ���Ͳ���,��û�����Ϊʲô:(
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
        alert("ɾ��ʧ�ܣ�");
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
        var iWidth = window.screen.availWidth-380;                          //�������ڵĿ��;
        var iHeight = window.screen.availHeight-120;                        //�������ڵĸ߶�;
        var iTop = (window.screen.availHeight - 30 - iHeight) / 2;       //��ô��ڵĴ�ֱλ��;
        var iLeft = (window.screen.availWidth - 10 - iWidth) / 2;           //��ô��ڵ�ˮƽλ��;
        //      
        var agent = navigator.userAgent.toLowerCase();
////        if (agent.indexOf("chrome") > 0)
////        { window.open("hyxx_PrizeLeftAmount.aspx?id=" + guid, "newwindow", "width=" + iWidth + ",height=" + iHeight + ",top=" + iTop + " ,left=" + iLeft + ""); }
////        else {
////            var win = showModalDialog("hyxx_PrizeLeftAmount.aspx?id=" + guid, "newwindow", "edge: Raised;resizable: Yes;dialogwidth:" + iWidth + "px;dialogheight:" + iHeight + "px;dialogtop:" + iTop + "px;dialogleft:" + iLeft + "px;scroll:yes");
////            if (win == 2) { //����ֵ .�����޸�.�����ֵ
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
            	<td colspan="8"><span style="margin-left:5px;font-weight:bold;">����ǰ��λ�ã�</span><asp:HyperLink 
                        ID="lblMenu1" runat="server" ForeColor="#135294"></asp:HyperLink>=>
                <asp:HyperLink ID="lblMenu2" runat="server" ForeColor="#135294"></asp:HyperLink> </td>
            </tr>
          <tr>
            <th nowrap="nowrap" width="5%" class="table04_1">���</th>
            <th nowrap="nowrap" width="5%" class="table04_1">��Ʒ����</th>
            <th nowrap="nowrap" width="5%" class="table04_1">��Ʒʣ����</th>
            <th nowrap="nowrap" width="5%" class="table04_1">��Ʒ�Ѷ���</th>
            <th nowrap="nowrap" width="5%" class="table04_1">��Ʒ����</th>
            <th nowrap="nowrap" width="5%" class="table04_1">�༭����</th>
            <th nowrap="nowrap" width="5%" class="table04_1">ɾ������</th>
             <th nowrap="nowrap" width="5%" class="table04_1">�鿴����</th>
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
            <a href='hyxx_PrizeEdit.aspx?id=<%# Eval("PrizeID") %>'>�༭</a>
            </span></td>
            <td nowrap="nowrap" class="table04_c" valign="middle"><span class="tab">
            <a href='#' onclick='DeletePrizeTableDataRow("<%# Eval("PrizeID")%>")'>ɾ��</a>
            </span></td>
            <td nowrap="nowrap" class="table04_c" valign="middle"><span >
          
            <input id="btn_DJ" type="button" value="�鿴"  onclick="ViewDetail('<%# Eval("PrizeID") %>');"  style="background-image: url('../../img/p03_1.png'); background-repeat: repeat-x; width: 55px;" />
           
            </span></td>

            <%--<a href='hyxx_xgmm.aspx?code=<%=Request["code"] %>&id=<%#Eval("US_UserID")%>'>�޸�����</a>
            <a href='hyxx_xgyx.aspx?code=<%=Request["code"] %>&id=<%#Eval("US_UserID")%>'>�޸�����</a>--%>
            
          </tr>
            </ItemTemplate>
          </asp:Repeater>
          <%--<%# (Container.ItemIndex + 1 + (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize).ToString("00")%>--%>
          <tr>
            <td nowrap="nowrap" colspan="8"><span>��ʱû���ҵ���ص�����</span></td>
          </tr>
<%--          <%#Eval("US_UserName")%>--%>
            <tr>
            	<td colspan="8" class="table04_1" style="border-right:0px;">
                	<span class="table04_5"><webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="��ҳ" 
        HorizontalAlign="Center" LastPageText="βҳ" NextPageText="��һҳ" 
        PrevPageText="��һҳ" onpagechanged="AspNetPager1_PageChanged"> </webdiyer:AspNetPager></span>
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
