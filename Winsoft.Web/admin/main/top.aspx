<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="Winsoft.Web.admin.main.top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>����ϵͳ </title>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    function loginOut() {

        ht = parent.document.getElementsByTagName("html");
        ht[0].style.filter = "progid:dXImagetransform.Microsoft.BasicImage(grayscale=1)";
        if (confirm("��ȷ��Ҫ�˳�ϵͳ��")) {
            //alert("�˳��ɹ�");
            top.location.href = "../login.aspx";
        }
        else {
            ht[0].style.filter = "";
        }
    }


    function ImportData() {

        var iWidth = 400;                          //�������ڵĿ��;
        var iHeight = 200;                        //�������ڵĸ߶�;

        var iTop = (window.screen.availHeight - 30 - iHeight) / 2;       //��ô��ڵĴ�ֱλ��;
        var iLeft = (window.screen.availWidth - 10 - iWidth) / 2;           //��ô��ڵ�ˮƽλ��;

        var agent = navigator.userAgent.toLowerCase();
        if (agent.indexOf("chrome") > 0)
        { window.open("UploadFile.aspx", "newwindow", "width=400,height=200,top=" + iTop + " ,left=" + iLeft + ""); }
        else {
            showModalDialog("UploadFile.aspx","", "dialogWidth=400px;dialogHeight=200px;dialogtop=" + iTop + "px ;dialogleft=" + iLeft + "px");
        }
        
    }

   

    function go(v) {
        window.history.go(v);
    }
</script>
</head>

<body>
<form runat="server">
<div class="header">
	<div class="header01">
    	<%--<div class="logo"><img src="../img/logo.gif" height="68" alt="�й���������" /></div>--%>
          <div class="menu" style="float:right;">
        		<a href="right.aspx" style="width:83px;margin-left:13px" target="right">������ҳ</a>
             
                
                <a href="javascript:void(0);" onClick="loginOut();" style="width:65px;margin-left:48px">ע��</a>
                <a style="width:213px;"> ���ã�<%=username %></a>
                <a href='htyh/hyxx_xgmm.aspx?id=<%=userid %>' style="width:73px;margin-left:55px" target="right">�޸�����</a>
        </div>
        <div class="exit"><!--a href="#"><img src="../img/p02_2.png" width="15" height="31" alt="�˳�" /></a--></div>
    </div>
    <div class="header02">
    	<span class="head2_01">��ǰ�û���<%=username %></span>
        <span class="head2_02">
            <%--<asp:Repeater ID="rtMenu" runat="server">
                <ItemTemplate>
              <a href='left.aspx?code=<%#Eval("M_ID") %>' target="left" title="<%#Eval("M_Name") %>"><%#Eval("M_Name")%></a>   
                </ItemTemplate>
            </asp:Repeater>--%>
             <a href='left.aspx?code=' style="margin-left:10px;display:none;" target="left" title="����ϵͳ">����ϵͳ</a> 
            <%-- <a href='left.aspx?code=' target="left" title="�����û�">�����û�</a> 
            <a href='left.aspx?code=' target="left" title="������Ʒ">������Ʒ</a>
            <a href='left.aspx?code=' target="left" title="���жһ�">���жһ�</a>--%>
            <%--<a href='left.aspx?code=<%#Eval("M_ID") %>' target="left" title="���жһ�">���жһ�</a>--%>
       <%--     &nbsp;&nbsp;&nbsp;--%>
           <a href='#'   id='ImportHref' style="margin-left:20px;display:none;" runat="server" onclick='ImportData()' >��������</a> 
           <a href='../TemplateFile/�ҽ�ϵͳ�����ͷ.xlsx' style="margin-left:20px;width:80px;display:none;"  id='A1' runat="server" >����ģ������</a> 
              
        
        </span>
    </div>
</div>
<asp:ScriptManager ID="ScriptManager_ImportData" runat="server">
     <Services>
            <asp:ServiceReference Path="~/Ajax/AjaxService.svc" />
        </Services>
    </asp:ScriptManager>
   </form> 
</body>
</html>
