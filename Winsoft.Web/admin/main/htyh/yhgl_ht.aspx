<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yhgl_ht.aspx.cs" Inherits="Winsoft.Web.admin.main.htyh.hygl_ht" EnableEventValidation="false" %>

<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>���ÿ��ҽ�ϵͳ </title>
<link href="../../css/style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../../../My97DatePicker/WdatePicker.js"></script>
<script>
    var highlightcolor = '#c1ebff';
    //�˴�clickcolorֻ����winϵͳ��ɫ������ܳɹ�,�����#xxxxxx�Ĵ���Ͳ���,��û�����Ϊʲô:(
    var clickcolor = '#51b2f6';
    function changeto(change) {
        change.style.background = "#c1ebff";
    }

    function changeback(change) {
        change.style.background = "#fff";
    }
    function DeleteUserData(id) {
        var context = "Complete";
        AjaxService.DeleteUserTableDataRow(id, OnComplete, OnFailed, context);
    }
    function OnComplete(args, context) {
    
        alert(args);
        location.reload();
    }

    function OnFailed(args) {
        alert("�û�ɾ��ʧ�ܣ�");
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
                	<td><span style="margin-left:5px;font-weight:bold;">����ǰ��λ�ã�</span><asp:Label ID="lblMenu" runat="server" Text=""></asp:Label> </td>
                </tr>
   			    <tr style="color:#135294;">
                    <td colspan="5" align="right" style="padding-right:10px;">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <%--<td class="tab_c"><asp:Button ID="btndelete" runat="server" Text="ɾ  ��" CssClass="page02_4" 
                        onclick="btndelete_Click" /></td>--%>
                       <td class="tab_c"><asp:Button ID="btnCommit" runat="server" Text="�� ѯ" CssClass="page02_4" 
                        onclick="btnCommit_Click" /></td>
                        </tr>
                    </table>
                    </td>    
                </tr>
                <tr>
                	<td align="left">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="padding-left:5px;">ע��ʱ�䣺</td>
                            <td>
                                <asp:TextBox ID="start" onclick="WdatePicker();" runat="server" CssClass="page02_2" Width="80"></asp:TextBox> -
                                <asp:TextBox ID="end" onclick="WdatePicker();" runat="server" CssClass="page02_2" Width="80"></asp:TextBox>
                            </td>
                            <td style="padding-left:5px;">�û��ʺţ�</td>
                            <td>
                                <input name="" type="text" runat="server" class="page02_2" id="M_Username" />
                            </td>
                            <td style="padding-left:5px;">�������䣺</td>
                            <td>
                                <input name="" type="text" runat="server" class="page02_2" id="M_EMail" />
                            </td>
                            <td style="padding-left:5px;">��ʵ������</td>
                            <td>
                                <input name="" type="text" runat="server" class="page02_2" id="M_Address" />
                            </td>
                        </tr>
                    </table>
                    </td>
                </tr>
        </table>
    <table cellpadding="0" cellspacing="1" class="table04">
          <tr>
            <th nowrap="nowrap" width="5%" class="table04_1">���</th>
            <th nowrap="nowrap" width="15%" class="table04_1">�� �� ��</th>
            <th nowrap="nowrap" width="15%" class="table04_1">��������</th>
            <th nowrap="nowrap" width="15%" class="table04_1">��������</th>
            <th nowrap="nowrap" width="20%" class="table04_1">��ʵ����</th>
            <th nowrap="nowrap" width="10%" class="table04_1">��ϵ�绰</th>
            <th nowrap="nowrap" width="15%" class="table04_1">ע��ʱ��</th>
            <th nowrap="nowrap" width="10%" class="table04_1">�༭����</th>
            <th nowrap="nowrap" width="10%" class="table04_1">ɾ������</th>
          </tr>
          <asp:Repeater ID="rtManager" runat="server">
            <ItemTemplate>
          <tr onmouseover="changeto(this)" onmouseout="changeback(this)">
            <td nowrap="nowrap" class="table04_c"><span><%# (Container.ItemIndex + 1 + (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize).ToString("00")%></span></td>
            <td nowrap="nowrap" class="table04_l"><span><%#Eval("US_UserName")%></span></td>
            <td nowrap="nowrap" class="table04_l"><span><%#Eval("US_WebsiteName")%></span></td>
            <td nowrap="nowrap" class="table04_l"><span><%#Eval("US_EMail")%></span></td>
            <td nowrap="nowrap" class="table04_l"><span><%#Eval("US_Name")%></span></td>
            <td nowrap="nowrap" class="table04_l"><span><%#Eval("US_TelPhone")%></span></td>
            <td nowrap="nowrap" class="table04_c"><span><%#Convert.ToDateTime(Eval("US_RegisterTime")).ToString("yyyy-MM-dd HH:mm:ss")%></span></td>
            <td nowrap="nowrap" class="table04_c" valign="middle"><span class="tab">
            <a href='hyxx_tjxg.aspx?id=<%# Eval("US_UserID") %>'>�༭</a>
            <%--<a href='hyxx_xgmm.aspx?code=<%=Request["code"] %>&id=<%#Eval("US_UserID")%>'>�޸�����</a>
            <a href='hyxx_xgyx.aspx?code=<%=Request["code"] %>&id=<%#Eval("US_UserID")%>'>�޸�����</a>--%>
            </span></td>
             <td nowrap="nowrap" class="table04_c" valign="middle"><span class="tab">
            <a href='#' onclick='DeleteUserData(<%# Eval("US_UserID") %>)'>ɾ��</a>
            </span></td>
          </tr>
            </ItemTemplate>
          </asp:Repeater>
        <%--  <%# (Container.ItemIndex + 1 + (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize).ToString("00")%>--%>
          <tr>
            <td nowrap="nowrap" colspan="9"><span>��ʱû���ҵ���ص�����</span></td>
          </tr>
          <%#Eval("US_UserName")%>
            <tr>
            	<td colspan="9" class="table04_1" style="border-right:0px;">
                	<span class="table04_5"><webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="��ҳ" 
        HorizontalAlign="Center" LastPageText="βҳ" NextPageText="��һҳ" 
        PrevPageText="��һҳ" onpagechanged="AspNetPager1_PageChanged"> </webdiyer:AspNetPager></span>
                </td>
            </tr>
        </table>
    <br />    
    <asp:ScriptManager ID="ScriptManager_ht" runat="server">
        <Services>
            <asp:ServiceReference Path="~/Ajax/AjaxService.svc" />
        </Services>
    </asp:ScriptManager>
    </form>
</body>
</html>
