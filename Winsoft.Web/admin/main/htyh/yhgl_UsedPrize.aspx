<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yhgl_UsedPrize.aspx.cs" Inherits="Winsoft.Web.admin.main.htyh.yhgl_UsedPrize" EnableEventValidation="false" %>

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
    function DeleteData(id) {
        var context = "Complete";
        AjaxService.RefundDJDataRow(id, OnComplete, OnFailed, context);
    }
    function OnComplete(args, context) {
        alert(args); 
        location.reload();
    }

    function OnFailed(args) {
        alert("����ʧ�ܣ�");
    }
    function DJ_Click(guid) {

        var iWidth = 500;                          //�������ڵĿ��;
        var iHeight = 500;                        //�������ڵĸ߶�;
        var iTop = (window.screen.availHeight - 30 - iHeight) / 2;       //��ô��ڵĴ�ֱλ��;
        var iLeft = (window.screen.availWidth - 10 - iWidth) / 2;           //��ô��ڵ�ˮƽλ��;
        //      
        var agent = navigator.userAgent.toLowerCase();
        if (agent.indexOf("chrome") > 0)
        { window.open("hyxx_ywdjinfo.aspx?id=" + guid , "newwindow", "width=500,height=400,top=" + iTop + " ,left=" + iLeft + ""); }
        else {
            var win=showModalDialog("hyxx_ywdjinfo.aspx?id=" + guid, "newwindow", "dialogwidth=500,dialogheight=400,dialogtop=" + iTop + " ,dialogleft=" + iLeft + "");
            if (win == 2) { //����ֵ .�����޸�.�����ֵ
                location.href = "yhgl_ywdj.aspx";

            }
        }
        

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
            	<td colspan="6"><span style="margin-left:5px;font-weight:bold;">����ǰ��λ�ã�</span><asp:HyperLink 
                        ID="lblMenu1" runat="server" ForeColor="#135294"></asp:HyperLink>=>
                <asp:HyperLink ID="lblMenu2" runat="server" ForeColor="#135294"></asp:HyperLink>=><asp:HyperLink 
                        ID="lblMenu3" runat="server" ForeColor="#135294"></asp:HyperLink>
                        =><asp:HyperLink 
                        ID="lblMenu4" runat="server" ForeColor="#135294"></asp:HyperLink>
                 </td>
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
                            
                            <td style="padding-left:5px;">���п��ţ�</td>
                            <td>
                                <input name="" type="text" runat="server" class="page02_2" id="Prize_CardNum" />
                            </td>
                            <td style="padding-left:5px;">���֤�ţ�</td>
                            <td>
                                <input name="" type="text" runat="server" class="page02_2" id="Prize_IdentifyCard" />
                            </td>
                            <td style="padding-left:5px;">��ʵ������</td>
                            <td>
                                <input name="" type="text" runat="server" class="page02_2" id="Prize_user" />
                            </td>
                        </tr>
                    </table>
                    </td>
                </tr>
        </table>
    <table cellpadding="0" cellspacing="1" class="table04">
          <tr>
            <th nowrap="nowrap" width="5%" class="table04_1">���</th>
            <th nowrap="nowrap" width="15%" class="table04_1">����</th>
            <th nowrap="nowrap" width="15%" class="table04_1">����</th>
            <th nowrap="nowrap" width="20%" class="table04_1">���֤��</th>
            <th nowrap="nowrap" width="10%" class="table04_1">��ȡ������</th>
            <th nowrap="nowrap" width="15%" class="table04_1">��ȡ����ϵ��ʽ</th>
            <th nowrap="nowrap" width="10%" class="table04_1">��ȡ�����֤��</th>
            <th nowrap="nowrap" width="15%" class="table04_1">�Ѷҽ�Ʒ����</th>
            <th nowrap="nowrap" width="15%" class="table04_1">�ҽ�����</th>
            <th nowrap="nowrap" width="10%" class="table04_1">���������</th>
            <th nowrap="nowrap" width="10%" class="table04_1">����</th>
            <th nowrap="nowrap" width="15%" class="table04_1">�ƹ��������</th>
            <th nowrap="nowrap" width="10%" class="table04_1">�ƹ������</th>
             <th nowrap="nowrap" width="10%" class="table04_1">�ƹ���Ա����</th>
            <th nowrap="nowrap" width="10%" class="table04_1">�ƹ��˱��</th>
           
          </tr>
          <asp:Repeater ID="rtManager" runat="server">
            <ItemTemplate>
          <tr onmouseover="changeto(this)" onmouseout="changeback(this)" ondblclick="DJ_Click('<%# Eval("Prize_Guid") %>')">
               <td nowrap="nowrap" class="table04_c"><span><%# (Container.ItemIndex + 1)%>
            <td nowrap="nowrap" class="table04_l"><span><%#Eval("Prize_user")%></span></td>
            <td nowrap="nowrap" class="table04_l"><span><%#Eval("Prize_CardNum")%></span></td>
            <td nowrap="nowrap" class="table04_l"><span><%#Eval("Prize_IdentifyCard")%></span></td>
            <td nowrap="nowrap" class="table04_l"><span><%#Eval("Prize_GetUserName")%></span></td>
            <td nowrap="nowrap" class="table04_l"><span><%#Eval("Prize_GetUserContact")%></span></td>
            <td nowrap="nowrap" class="table04_l"><span><%#Eval("Prize_GetUserIdentifyCard")%></span></td>
            <td nowrap="nowrap" class="table04_l"><span><%#Eval("Prize_GetPrizeName")%></span></td>
            <td nowrap="nowrap" class="table04_l"><span><%#Eval("Pize_GetPrizeDateTime")%></span></td>
            <td nowrap="nowrap" class="table04_l"><span><%#Eval("Pize_WebsiteNum")%></span></td>
            <td nowrap="nowrap" class="table04_l"><span><%#Eval("Pize_UserNum")%></span></td>
            <td nowrap="nowrap" class="table04_l"><span><%#Eval("Pize_PushCom")%></span></td>
            <td nowrap="nowrap" class="table04_l"><span><%#Eval("Pize_PushComNum")%></span></td>
            <td nowrap="nowrap" class="table04_l"><span><%#Eval("Pize_PushPerson")%></span></td>
            <td nowrap="nowrap" class="table04_l"><span><%#Eval("Pize_PushPersonNum")%></span></td>
             
            
          </tr>
            </ItemTemplate>
          </asp:Repeater>
          <%
              if (this.rtManager.Items.Count == 0)
              {
          %>
          <tr>
            <%  if (IsVisible)
              { %>
            <td nowrap="nowrap" colspan="16"><span>��ʱû���ҵ���ص�����</span></td>
            <%}else{ %>
           ;
            <%} %>
          </tr>
          <%        
              }
               %>
            
        </table>
    <br /> 
     <asp:ScriptManager ID="ScriptManager_ywdj" runat="server">
     <Services>
            <asp:ServiceReference Path="~/Ajax/AjaxService.svc" />
        </Services>
    </asp:ScriptManager>   
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
