<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="mid.ascx.cs" Inherits="Winsoft.Web.mid" %>
<link href="css/style.css"  rel="stylesheet"/>
<link href="css/body.css"  rel="stylesheet"/>
<div class="dl_banner">
     <div class="header">
        <div class="gg" id="gg">
            <div class="ggLoading">
                <div class="ggLoading2"><em>图片载入中</em></div>
            </div>
            <div class="ggs">
                <div class="ggBox" id="ggBox">
                    <asp:Repeater ID="rtTpggA" runat="server">
                        <ItemTemplate>
                    <a href='<%#Eval("N_Url") %>' title='<%#Eval("N_Title") %>' target="_blank" <%#Container.ItemIndex == 0 ? "style='z-index: 3; opacity: 4;'" : ""%>>
                        <img id="Img1" runat="server" src='<%#Eval("N_Img") %>' /></a>    
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="ggb">
                <div class="ggBtns" id="ggBtns">
                    <asp:Repeater ID="rtTpggB" runat="server">
                        <ItemTemplate>
                    <a title='<%#Eval("N_Title") %>' href='javascript:void(0)' <%#Container.ItemIndex == 0 ? "class='ggOn'" : ""%>><em></em></a>    
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
    
</div>