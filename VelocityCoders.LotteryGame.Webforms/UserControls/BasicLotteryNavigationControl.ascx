<%@ Control Language="C#" AutoEventWireup="true" 
    CodeBehind="BasicLotteryNavigationControl.ascx.cs" 
    Inherits="VelocityCoders.LotteryGame.Webforms.UserControls.BasicLotteryNavigationControl" %>

<div id="ContainerSubheader" class="SubheaderNavigation Border RadiusTop">
    <asp:Label runat="server" ID="UC">
    <div class="SmallPadding">
        <asp:ListView runat="server" ID="BasicLotteryNavigationList" ItemPlaceholderID="BasicLotteryNavigationPlaceholder">
            <LayoutTemplate>
                <ul>
                    <asp:PlaceHolder runat="server" ID="BasicLotteryNavigationPlaceholder"></asp:PlaceHolder>
                </ul>
            </LayoutTemplate>
            <ItemTemplate>
                <li>
                    <asp:HyperLink runat='server' ID='BasicLotteryNavigationLink' NavigateUrl ='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>'>

                    <%#Eval("Text") %>

                    </asp:HyperLink>
                </li>
            </ItemTemplate>
        </asp:ListView>
        </div>
    </asp:Label>
</div>

