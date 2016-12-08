<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="left.ascx.cs" Inherits="Winsoft.Web.left" %>
<%
    if (Session["myuser"] == null)
    {
        Response.Redirect("hydl.aspx");
    }
     %>
<link href="css/style.css"  rel="stylesheet"/>
<link href="css/body.css"  rel="stylesheet"/>
<link href="css/page.css"  rel="stylesheet"/>
    <div class="dlm_fwzx_left">
    	<b>我的逗留</b>
        <ul>
        	<li><a href="hyzx_wddd.aspx">我的订单</a> </li>
            <li><a href="hyzx_wdsc.aspx">我的收藏</a></li>
        </ul>
        <b>资料管理</b>
        <ul>
        	<li><a href="hyzx_grzl.aspx">个人资料</a> </li>
            <li><a href="hyzx_mmxg.aspx">密码修改</a></li>
        </ul>
    </div>