<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="spxx_xzks.aspx.cs" Inherits="Winsoft.Web.admin.main.scsp.spxx_xzks" %>

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
    function showBoxValue(objid) {
        parent.$("#windown-close").click();
        parent.document.getElementById("VL_PID").value = objid;
        parent.$("#btnMem").click();
    }
</script>
</head>
<body style="background:#F5F9FC;">
    <form id="form1" runat="server">
    <table cellpadding="0" cellspacing="1" class="table03">
            	<tr style="color:#135294; background:#eef7fd;" align="left">
                	<td><span style="margin-left:5px;font-weight:bold;">课程信息</span></td>
                </tr>
   			    <tr style="color:#135294;">
                    <td colspan="5" align="right" style="padding-right:10px;">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="tab_c"><asp:Button ID="btnCommit" runat="server" Text="查 询" CssClass="page02_4" onclick="btnCommit_Click" /></td>
                        </tr>
                    </table>
                    </td>    
                </tr>
                <tr>
                	<td align="left">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="padding-left:5px;">操作时间：</td>
                            <td>
                                <asp:TextBox ID="start" onclick="WdatePicker();" runat="server" CssClass="page02_2" Width="80"></asp:TextBox> -
                                <asp:TextBox ID="end" onclick="WdatePicker();" runat="server" CssClass="page02_2" Width="80"></asp:TextBox>
                            </td>
                            <td style="padding-left:5px;">视频类型：</td>
                            <td>
                                <asp:DropDownList ID="VT_ID" runat="server" CssClass="page02_1">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="padding-left:5px;">视频名称：</td>
                            <td>
                                <input name="" type="text" runat="server" class="page02_2" id="V_Name" />
                            </td>
                            <td style="padding-left:5px;">课时名称：</td>
                            <td>
                                <input name="" type="text" runat="server" class="page02_2" id="VL_Name" />
                            </td>
                        </tr>
                    </table>
                    </td>
                </tr>
        </table>
        <table cellpadding="0" cellspacing="1" class="table04">
          <tr>
            <th nowrap="nowrap" width="5%" class="table04_1">序号</th>
            <th nowrap="nowrap" width="15%" class="table04_1">视频类型</th>
            <th nowrap="nowrap" width="25%" class="table04_1">视频名称</th>
            <th nowrap="nowrap" width="25%" class="table04_1">课时名称</th>
            <th nowrap="nowrap" width="20%" class="table04_1">操作时间</th>
            <th nowrap="nowrap" width="10%" class="table04_1">基本操作</th>
          </tr>
          <asp:Repeater ID="rtManager" runat="server">
            <ItemTemplate>
          <tr onmouseover="changeto(this)" onmouseout="changeback(this)">
            <td nowrap="nowrap" class="table04_c"><span><%# (Container.ItemIndex + 1 + (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize).ToString("00")%></span></td>
            <td nowrap="nowrap" class="table04_l"><span><%#Eval("VT_Name")%></span></td>
            <td nowrap="nowrap" class="table04_l"><span><%#Eval("V_Name")%></span></td>
            <td nowrap="nowrap" class="table04_l"><span><%#Eval("VL_Name")%></span></td>
            <td nowrap="nowrap" class="table04_c"><span><%#Convert.ToDateTime(Eval("V_Time")).ToString("yyyy-MM-dd HH:mm:ss")%></span></td>
            <td nowrap="nowrap" class="table04_c" valign="middle"><span class="tab">
            <a href='javascript:void(0);' onclick="showBoxValue('<%#Eval("VL_ID")%>')">选择</a>
            </span></td>
          </tr>
            </ItemTemplate>
          </asp:Repeater>
          <%
              if (this.rtManager.Items.Count == 0)
              {
          %>
          <tr>
            <td nowrap="nowrap" colspan="6"><span>暂时没有找到相关的数据</span></td>
          </tr>
          <%        
              }
               %>
            <tr>
            	<td colspan="6" class="table04_1" style="border-right:0px;">
                	<span class="table04_5"><webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" 
        HorizontalAlign="Center" LastPageText="尾页" NextPageText="下一页" 
        PrevPageText="上一页" onpagechanged="AspNetPager1_PageChanged"> </webdiyer:AspNetPager></span>
                </td>
            </tr>
        </table>
        <br />
    </form>
</body>
</html>
