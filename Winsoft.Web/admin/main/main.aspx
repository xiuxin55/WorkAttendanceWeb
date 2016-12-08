<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="Winsoft.Web.admin.main.main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>考勤系统 </title>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    if (self != top) { top.location = self.location; }
    function switchSysBar() {
        if (switchPoint.innerText == 3) {
            switchPoint.innerText = 4
            document.getElementById("frmTitle").style.display = "none"
        } else {
            switchPoint.innerText = 3
            document.getElementById("frmTitle").style.display = ""
        }
    } 
</script>
</head>

<body>
<iframe name="top" height="120" width="100%" border="0" frameborder="0" src="top.aspx" frameborder="0" scrolling="no"> 浏览器不支持嵌入式框架，或被配置为不显示嵌入式框架。</iframe>
<table cellpadding="0" cellspacing="0" class="main" border="0">
	<tr>
	<td class="left" id="frmTitle"><iframe style="height:100%;" name="left" height="100%" width="100%" src="left.aspx" border="0" frameborder="0" scrolling="no"> 浏览器不支持嵌入式框架，或被配置为不显示嵌入式框架。</iframe></td>
    <td class="center" onclick="switchSysBar()"><span class="navPoint" id="switchPoint" title="关闭/打开左栏">3</span></td>
    <td class="right" style="background:#F5F9FC;"><iframe name="right" height="100%" width="100%" border="0" frameborder="0" src="right.aspx"> 浏览器不支持嵌入式框架，或被配置为不显示嵌入式框架。</iframe></td>
  </tr>
</table>
</body>
</html>
