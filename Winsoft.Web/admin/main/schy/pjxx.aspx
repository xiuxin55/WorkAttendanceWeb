<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pjxx.aspx.cs" Inherits="Winsoft.Web.admin.main.schy.pjxx" %>

<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>����������ϵͳ</title>
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
                       <td class="tab_c"><asp:Button ID="btnCommit" runat="server" Text="�� ѯ" CssClass="page02_4" 
                        onclick="btnCommit_Click" /></td>
                       <td class="tab_c"><asp:Button ID="btnAllDelete" runat="server" Text="����ɾ��" onclick="btnAllDelete_Click" CssClass="page02_5"/></td>  
                        </tr>
                    </table>
                    </td>    
                </tr>
                <tr>
                	<td align="left">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="padding-left:5px;">����ʱ�䣺</td>
                            <td>
                                <asp:TextBox ID="start" onclick="WdatePicker();" runat="server" CssClass="page02_2" Width="80"></asp:TextBox> -
                                <asp:TextBox ID="end" onclick="WdatePicker();" runat="server" CssClass="page02_2" Width="80"></asp:TextBox>
                            </td>
                            <td style="padding-left:5px;">�ظ�ʱ�䣺</td>
                            <td>
                                <asp:TextBox ID="startr" onclick="WdatePicker();" runat="server" CssClass="page02_2" Width="80"></asp:TextBox> -
                                <asp:TextBox ID="endr" onclick="WdatePicker();" runat="server" CssClass="page02_2" Width="80"></asp:TextBox>
                            </td>
                            <td style="padding-left:5px;">��Ա�ʺţ�</td>
                            <td>
                                <input name="" type="text" runat="server" class="page02_2" id="M_Username" />
                            </td>
                            <td style="padding-left:5px;">�ظ��ʺţ�</td>
                            <td>
                                <input name="" type="text" runat="server" class="page02_2" id="A_UserName" />
                            </td>
                        </tr>
                    </table>
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="padding-left:5px;">��Ƶ���ƣ�</td>
                            <td>
                                <input name="" type="text" runat="server" class="page02_2" id="V_Name" />
                            </td>
                            <td style="padding-left:5px;">����״̬��</td>
                            <td>
                                <asp:DropDownList ID="C_Status" runat="server" CssClass="page02_1">
                                    <asp:ListItem>ȫ��</asp:ListItem>
                                    <asp:ListItem>δ���</asp:ListItem>
                                    <asp:ListItem>δͨ��</asp:ListItem>
                                    <asp:ListItem>�����</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    </td>
                </tr>
        </table>
        <table cellpadding="0" cellspacing="1" class="table04">
          <tr>
            <th width="3%" class="table04_1"><input class="tab_p" type="checkbox" id="checkbox" name="checkbox" value="1" onclick="CheckAll('checkbox','Item','chkall')"/></th>
            <th nowrap="nowrap" width="5%" class="table04_1">���</th>
            <th nowrap="nowrap" width="10%" class="table04_1">��Ա�ʺ�</th>
            <th nowrap="nowrap" width="10%" class="table04_1">�ظ��ʺ�</th>
            <th nowrap="nowrap" width="15%" class="table04_1">��Ƶ����</th>
            <th nowrap="nowrap" width="10%" class="table04_1">����״̬</th>
            <th nowrap="nowrap" width="14%" class="table04_1">����ʱ��</th>
            <th nowrap="nowrap" width="14%" class="table04_1">�ظ�ʱ��</th>
            <th nowrap="nowrap" width="20%" class="table04_1">��������</th>
          </tr>
          <asp:Repeater ID="rtManager" runat="server" onitemcommand="rtManager_ItemCommand" onitemcreated="rtManager_ItemCreated" onitemdatabound="rtManager_ItemDataBound">
            <ItemTemplate>
          <tr onmouseover="changeto(this)" onmouseout="changeback(this)">
            <td nowrap="nowrap" class="table04_c"><span><input class="tab_p" type="checkbox" name="Item" value="<%# Eval("C_ID") %>" /></span></td>
            <td nowrap="nowrap" class="table04_c"><span><%# (Container.ItemIndex + 1 + (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize).ToString("00")%></span></td>
            <td nowrap="nowrap" class="table04_l"><span><%#Eval("M_Username")%></span></td>
            <td nowrap="nowrap" class="table04_c"><span><%#Eval("A_UserName")%></span></td>
            <td nowrap="nowrap" class="table04_l"><span><%#Eval("V_Name")%></span></td>
            <td nowrap="nowrap" class="table04_c"><span><%#Eval("C_Status")%></span></td>
            <td nowrap="nowrap" class="table04_c"><span><%#Convert.ToDateTime(Eval("C_Time")).ToString("yyyy-MM-dd HH:mm:ss")%></span></td>
            <td nowrap="nowrap" class="table04_c"><span><%#Eval("C_ReplyTime").ToString() != string.Empty ? Convert.ToDateTime(Eval("C_ReplyTime")).ToString("yyyy-MM-dd HH:mm:ss") : ""%></span></td>
            <td nowrap="nowrap" class="table04_c" valign="middle"><span class="tab">
                <asp:HiddenField ID="hdfID" runat="server" Value='<%#Eval("C_ID")%>' />
                <a href='<%# M_EUrl +"&id="+ Eval("C_ID") %>'>�鿴</a>
                <asp:LinkButton ID="btnTg" runat="server" Text="ͨ��" CommandName="tg" CommandArgument='<%#Eval("C_ID") %>' />
                <asp:LinkButton ID="btnCh" runat="server" Text="����" CommandName="ch" CommandArgument='<%#Eval("C_ID") %>' />
                <asp:LinkButton ID="btnHf" runat="server" Text="�ظ�" CommandName="hf" CommandArgument='<%#Eval("C_ID") %>' />
                <asp:LinkButton ID="btnDelete" runat="server" Text="ɾ��" CommandName="delete" CommandArgument='<%#Eval("C_ID") %>' />
            </span></td>
          </tr>
            </ItemTemplate>
          </asp:Repeater>
          <%
              if (this.rtManager.Items.Count == 0)
              {
          %>
          <tr>
            <td nowrap="nowrap" colspan="9"><span>��ʱû���ҵ���ص�����</span></td>
          </tr>
          <%        
              }
               %>
            <tr>
            	<td colspan="9" class="table04_1" style="border-right:0px;">
                	<span class="table04_5"><webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="��ҳ" 
        HorizontalAlign="Center" LastPageText="βҳ" NextPageText="��һҳ" 
        PrevPageText="��һҳ" onpagechanged="AspNetPager1_PageChanged"> </webdiyer:AspNetPager></span>
                </td>
            </tr>
        </table>
        <br />
    </form>
</body>
</html>
