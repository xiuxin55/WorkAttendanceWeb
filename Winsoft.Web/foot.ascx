<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="foot.ascx.cs" Inherits="Winsoft.Web.foot" %>
<link href="css/style.css"  rel="stylesheet"/>
<link href="css/body.css"  rel="stylesheet"/>
<div class="dl_btm">
<div class="dlb_main">
    <asp:Repeater ID="rtBqxx" runat="server">
        <ItemTemplate>
    <%#Eval("N_Content") %>
        </ItemTemplate>
    </asp:Repeater>
</div>
</div>