<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hyxstj.aspx.cs" Inherits="Winsoft.Web.admin.main.scsp.hyxstj" %>

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
                    <td colspan="5" align="right" style="padding-right:10px;">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                       <td class="tab_c"><asp:Button ID="btnCommit" runat="server" Text="查 询" CssClass="page02_4" 
                        onclick="btnCommit_Click" /></td>
                        </tr>
                    </table>
                    </td>    
                </tr>
                <tr>
                	<td align="left">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="padding-left:5px;">视频名称：</td>
                            <td>
                                <input name="" type="text" runat="server" class="page02_2" id="V_Name" />
                            </td>
                        </tr>
                    </table>
                    </td>
                </tr>
        </table>
        <table cellpadding="0" cellspacing="1" class="table04">
          <tr>
            <th nowrap="nowrap" width="5%" class="table04_1">序号</th>
            <th nowrap="nowrap" width="35%" class="table04_1">视频名称</th>
            <th nowrap="nowrap" width="30%" class="table04_1">购买价格</th>
            <th nowrap="nowrap" width="30%" class="table04_1">购买人数</th>
          </tr>
          <asp:Repeater ID="rtManager" runat="server">
            <ItemTemplate>
          <tr onmouseover="changeto(this)" onmouseout="changeback(this)">
            <td nowrap="nowrap" class="table04_c"><span><%#(Container.ItemIndex + 1).ToString("00")%></span></td>
            <td nowrap="nowrap" class="table04_l"><span><%#Eval("V_Name")%></span></td>
            <td nowrap="nowrap" class="table04_r"><span>￥<%#Eval("O_Price")%></span></td>
            <td nowrap="nowrap" class="table04_r"><span><a href='<%# M_EUrl +"&id="+ Eval("V_ID") %>' title='会员信息(<%#Eval("M_Count")%>)'><%#Eval("M_Count")%></a></span></td>
          </tr>
            </ItemTemplate>
          </asp:Repeater>
          <%
              if (this.rtManager.Items.Count == 0)
              {
          %>
          <tr>
            <td nowrap="nowrap" colspan="4"><span>暂时没有找到相关的数据</span></td>
          </tr>
          <%        
              }
              else
              {
          %>
          <tr onmouseover="changeto(this)" onmouseout="changeback(this)">
            <td nowrap="nowrap" class="table04_c" colspan="2"><span>合计</span></td>
            <td nowrap="nowrap" class="table04_r"><asp:Label ID="lblPrice" runat="server" Text=""></asp:Label></td>
            <td nowrap="nowrap" class="table04_r"><asp:Label ID="lblCount" runat="server" Text=""></asp:Label></td>
          </tr>
          <%
              }
               %>
        </table>
        <br />
    </form>
</body>
</html>
