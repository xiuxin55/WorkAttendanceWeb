<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="Winsoft.Web.admin.main.top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>考勤系统 </title>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    function loginOut() {

        ht = parent.document.getElementsByTagName("html");
        ht[0].style.filter = "progid:dXImagetransform.Microsoft.BasicImage(grayscale=1)";
        if (confirm("您确认要退出系统吗？")) {
            //alert("退出成功");
            top.location.href = "../login.aspx";
        }
        else {
            ht[0].style.filter = "";
        }
    }


    function ImportData() {

        var iWidth = 400;                          //弹出窗口的宽度;
        var iHeight = 200;                        //弹出窗口的高度;

        var iTop = (window.screen.availHeight - 30 - iHeight) / 2;       //获得窗口的垂直位置;
        var iLeft = (window.screen.availWidth - 10 - iWidth) / 2;           //获得窗口的水平位置;

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
    	<%--<div class="logo"><img src="../img/logo.gif" height="68" alt="中国邮政银行" /></div>--%>
          <div class="menu" style="float:right;">
        		<a href="right.aspx" style="width:83px;margin-left:13px" target="right">管理首页</a>
             
                
                <a href="javascript:void(0);" onClick="loginOut();" style="width:65px;margin-left:48px">注销</a>
                <a style="width:213px;"> 您好，<%=username %></a>
                <a href='htyh/hyxx_xgmm.aspx?id=<%=userid %>' style="width:73px;margin-left:55px" target="right">修改密码</a>
        </div>
        <div class="exit"><!--a href="#"><img src="../img/p02_2.png" width="15" height="31" alt="退出" /></a--></div>
    </div>
    <div class="header02">
    	<span class="head2_01">当前用户：<%=username %></span>
        <span class="head2_02">
            <%--<asp:Repeater ID="rtMenu" runat="server">
                <ItemTemplate>
              <a href='left.aspx?code=<%#Eval("M_ID") %>' target="left" title="<%#Eval("M_Name") %>"><%#Eval("M_Name")%></a>   
                </ItemTemplate>
            </asp:Repeater>--%>
             <a href='left.aspx?code=' style="margin-left:10px;display:none;" target="left" title="考勤系统">考勤系统</a> 
            <%-- <a href='left.aspx?code=' target="left" title="服务用户">服务用户</a> 
            <a href='left.aspx?code=' target="left" title="管理礼品">管理礼品</a>
            <a href='left.aspx?code=' target="left" title="进行兑换">进行兑换</a>--%>
            <%--<a href='left.aspx?code=<%#Eval("M_ID") %>' target="left" title="进行兑换">进行兑换</a>--%>
       <%--     &nbsp;&nbsp;&nbsp;--%>
           <a href='#'   id='ImportHref' style="margin-left:20px;display:none;" runat="server" onclick='ImportData()' >导入数据</a> 
           <a href='../TemplateFile/兑奖系统需求表头.xlsx' style="margin-left:20px;width:80px;display:none;"  id='A1' runat="server" >数据模版下载</a> 
              
        
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
