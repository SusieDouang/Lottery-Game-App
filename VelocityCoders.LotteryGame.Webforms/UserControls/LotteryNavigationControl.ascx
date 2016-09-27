<%@ Control Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="LotteryNavigationControl.ascx.cs" 
    Inherits="VelocityCoders.LotteryGame.Webforms.UserControls.LotteryNavigationControl" %>

<div id="ContainerSubheader" class="SubheaderNavigation Border RadiusTop">
    <asp:Label runat="server" ID="UC">
    <div class="SmallPadding">
        <asp:ListView runat="server" ID="LotteryNavigationList" ItemPlaceholderID="LotteryNavigationPlaceholder">
            <LayoutTemplate>
                <ul>
                    <asp:PlaceHolder runat="server" ID="LotteryNavigationPlaceholder"></asp:PlaceHolder>
                </ul>
            </LayoutTemplate>
            <ItemTemplate>
                <li>
                    <asp:HyperLink runat='server' ID='LotteryNavigationLink' NavigateUrl ='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>'>

                    <%#Eval("Text") %>

                    </asp:HyperLink>
                </li>
            </ItemTemplate>
        </asp:ListView>
    </div>
    </asp:Label>
</div>

