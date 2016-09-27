<%@ Control Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="DrawingNavigationControl.ascx.cs" 
    Inherits="VelocityCoders.LotteryGame.Webforms.UserControls.DrawingNavigationControl" %>



<div id="ContainerSubheader" class="SubheaderNavigation Border RadiusTop">
    <asp:Label runat="server" ID="UC">
    <div class="SmallPadding">
        <asp:ListView runat="server" ID="DrawingNavigationList" ItemPlaceholderID="DrawingNavigationPlaceholder">
            <LayoutTemplate>
                <ul>
                    <asp:PlaceHolder runat="server" ID="DrawingNavigationPlaceholder"></asp:PlaceHolder>
                </ul>
            </LayoutTemplate>
            <ItemTemplate>
                <li>
                    <asp:HyperLink runat='server' ID='DrawingNavigationLink' NavigateUrl ='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>'>

                    <%#Eval("Text") %>

                    </asp:HyperLink>
                </li>
            </ItemTemplate>
        </asp:ListView>
    </div>
    </asp:Label>
</div>

