<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="Winsoft.Web.admin.main.left" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="Winsoft.Model" %>
<%@ Import Namespace="Winsoft.BLL" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>����ϵͳ </title>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
</head>

<body>
<form id="form1" runat="server">
<%
    string M_Name = "�˵�����";
    //string M_ID = GetID();
    //MenuInfo model = MenuInfoManage.GetInstance().GetModel(M_ID);

    //if (model != null)
    //{
    //    M_Name = model.M_Name;
    //}
     %>
<div <%=M_Name == "�˵�����" ? "" : "style='display:none;'" %> class="left01">�˵�����</div>
        <div class="left02">
        	<div id="Test5study" class="Test5study">
   
    <h2 id="t0"  style='display:none;' runat ="server" onclick="ShHi('t0','h0','a0');"><a class="weidianji"  id="a0">
      <p>����Ա����</p>
      </a></h2>
    <ul runat ="server" class="TxtList" id="h0" >
         <li><a href="htyh/yhgl_ht.aspx" title='����¼��' target="right">- ����¼�� -</a></li>
         <li><a href="htyh/hyxx_tjxg.aspx" title='����ͳ���б�' target="right">-����ͳ���б� -</a></li>
         <%--<li><a href="htyh/hyxx_wdgl.aspx" title='�������' target="right">-������� -</a></li>
         <li><a href="htyh/hyxx_wdbj.aspx" title='�������/�޸�' target="right">-�������/�޸�-</a></li>
         <li><a href="htyh/hyxx_PrizeManage.aspx" title='��Ʒ����' target="right">-��Ʒ���� -</a></li>
         <li><a href="htyh/hyxx_PrizeEdit.aspx" title='��Ʒ���/�޸�' target="right">-��Ʒ���/�޸� -</a></li>--%>
      </ul>
   <h2 id="t2"  style='display:none;' onclick="ShHi('t2','h2','a2');"><a class="weidianji"  id="a2">
      <p>�ҽ�����</p>
      </a></h2>
      <ul class="TxtList" id="h2" style='display:none;'>
        <%--<li><a href='htyh/yhgl_wdj.aspx' title='δ�ҽ�' target="right">- δ�ҽ� -</a></li>
        <li><a href='htyh/yhgl_ywdj.aspx' title='�Ѷҽ�' target="right">- �Ѷҽ� -</a></li>--%>
      </ul>
  </div>
        </div>
</form>
</body>
</html>
<script type="text/javascript">
    function $(d) { return document.getElementById(d); }
    function f(d) { var t = $(d); if (t) { return t.style; } else { return null; } }
    function Hi() { var items = document.getElementsByTagName("ul"); for (var i = 0; i < items.length; i++) { items[i].style.display = 'none'; } }
    function Hl() { var iteml = document.getElementsByTagName("h2"); for (var j = 0; j < iteml.length; j++) { iteml[j].style.fontWeight = 'normal'; } }
    function hb() { var iteml = document.getElementsByTagName("a"); for (var j = 0; j < iteml.length; j++) { if (iteml[j].className == 'dianji') { iteml[j].className = 'weidianji' }; } }
    function h(d) { var s = f(d); var b = s.display; if (b == 'none') { return true; } else { return false; } }
    function ShHi(ii, jj, kk) { if (h(jj)) { Hl(); Hi(); f(jj).display = 'block'; f(ii).fontWeight = 'bold'; hb(); $(kk).className = 'dianji'; } else { Hl(); Hi(); f(jj).display = 'none'; $(kk).className = 'weidianji'; f(ii).fontWeight = 'normal'; } }
</script>

