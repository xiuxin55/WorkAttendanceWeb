<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hyxx_PrizeLeftAmount.aspx.cs" Inherits="Winsoft.Web.admin.main.htyh.PrizeLeftAmount" EnableEventValidation="false" %>

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
    function UsedAmount_Click(id) {

    }
</script>
</head>
<body style="background:#F5F9FC;">
    <form id="form1" runat="server">

    <table cellpadding="0" cellspacing="1" class="table04">
    <tr style="color:#135294; background:#eef7fd;" align="left">
            	<td colspan="6"><span style="margin-left:5px;font-weight:bold;">����ǰ��λ�ã�</span><asp:HyperLink 
                        ID="lblMenu1" runat="server" ForeColor="#135294"></asp:HyperLink>=>
                <asp:HyperLink ID="lblMenu2" runat="server" ForeColor="#135294"></asp:HyperLink>=><asp:HyperLink 
                        ID="lblMenu3" runat="server" ForeColor="#135294"></asp:HyperLink>
                 </td>
            </tr>
          <tr>
            <th nowrap="nowrap" width="5%" class="table04_1">���</th>
            <th nowrap="nowrap" width="15%" class="table04_1">�����</th>
            <th nowrap="nowrap" width="20%" class="table04_1">��������</th>
            <th nowrap="nowrap" width="5%" class="table04_1">ʣ������</th>
            <th nowrap="nowrap" width="5%" class="table04_1">�Ѷһ�����</th>
          <th nowrap="nowrap" width="5%" class="table04_1">������</th>
          </tr>
          <asp:Repeater ID="rtManager" runat="server">
            <ItemTemplate>
          <tr onmouseover="changeto(this)" onmouseout="changeback(this)">
            <td nowrap="nowrap" class="table04_c"><asp:Label  runat="server" id ="order" ><%# Container.ItemIndex + 1 %></asp:Label ></td>
            <td nowrap="nowrap" class="table04_l"><asp:Label runat="server"  id ="WebsiteID" Text='<%#Eval("WebsiteID")%>'></asp:Label ></td>
            <td nowrap="nowrap" class="table04_l"><asp:Label  runat="server" id ="WebsiteName" Text='<%#Eval("WebsiteName")%>'></asp:Label ></td>
            <td nowrap="nowrap" class="table04_c" valign="middle"><asp:Label  runat="server" id="PrizeCount"  Text='<%#Eval("PrizeCount")%>' class="tab" />
            <td nowrap="nowrap" class="table04_c" valign="middle">
            <a href='yhgl_UsedPrize.aspx?prizeid=<%#Eval("PrizeID") %>&websiteid=<%#Eval("WebsiteID") %>' id="Label2"  class="tab"  ><%#Eval("PrizeUsedAmount")%></a></td>
              
             <td nowrap="nowrap" class="table04_c" valign="middle"><span><asp:Label  runat="server" id="Label1"   Text='<%#Eval("PrizeAmount") %>' class="tab" />
            </span></td>
            
            <%--<a href='hyxx_xgmm.aspx?code=<%=Request["code"] %>&id=<%#Eval("US_UserID")%>'>�޸�����</a>
            <a href='hyxx_xgyx.aspx?code=<%=Request["code"] %>&id=<%#Eval("US_UserID")%>'>�޸�����</a>
            
          --%></tr>
            </ItemTemplate>
          </asp:Repeater>
          <%--<%# (Container.ItemIndex + 1 + (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize).ToString("00")%>--%>
          <% if (rtManager.Items.Count == 0)
             { %>
          <tr>
            <td nowrap="nowrap" colspan="6"><span>��ʱû���ҵ���ص�����</span></td>
          </tr>
          <%} %>
          
<%--          <%#Eval("US_UserName")%>--%>
            <tr>
            	<%--<td colspan="5" class="table04_1" style="border-right:0px;">
                	<span class="table04_5"><webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="��ҳ" 
        HorizontalAlign="Center" LastPageText="βҳ" NextPageText="��һҳ" 
        PrevPageText="��һҳ" onpagechanged="AspNetPager1_PageChanged"> </webdiyer:AspNetPager></span>
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
