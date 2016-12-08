<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="top.ascx.cs" Inherits="Winsoft.Web.top" %>
<%@ Import Namespace="Winsoft.Model" %>
<link href="css/style.css"  rel="stylesheet"/>
<link href="css/body.css"  rel="stylesheet"/>
<div class="dl_top" id="float">
	<div class="dl_head">
    	<div class="dl_logo">
        	<a href="index.aspx" title="逗留网"><img src="images/dl_logo.gif" /></a>
            <img src="images/dl_i_head1.gif" />
        </div>
        <div class="dh_main">
        	<div class="dh_search">
            	<input class="dhs_i1" id="name" runat="server" value="请输入搜索关键词" onfocus="if(this.value=='请输入搜索关键词'){this.value=''}" onblur="if(this.value==''){this.value='请输入搜索关键词'}" />
                <asp:Button CssClass="dhs_i2" ID="btnSearch" runat="server"  onclick="btnSearch_Click" />
            </div>
            <div class="dh_nav">
            	<asp:Repeater ID="rtManage" runat="server">
                    <ItemTemplate>
                <a href='splb.aspx?type=0&id=<%#Eval("VT_ID") %>'><%#Eval("VT_Name")%></a>    
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="dh_right">
        	<div class="dh_mmb">
            	<%
                    MemberInfo model = (MemberInfo)Session["myuser"];
                    if (model == null)
                    {
                %>
                [<a href="hydl.aspx">登录</a>]&nbsp;[<a href="hyzc.aspx">免费注册</a>]
                <%        
                    }
                    else
                    {
                %>
               <p> 欢迎[<a href="hyzx_grzl.aspx"><%=model.M_Username%></a>]来到逗留网！</p>
                [<asp:LinkButton ID="btnExit" runat="server" onclick="btnExit_Click">注销</asp:LinkButton>]&nbsp;
                [<a href="hyzx.aspx">会员中心</a>]
                <%
                    }
                %>
            </div>
        </div>
    </div>
</div>