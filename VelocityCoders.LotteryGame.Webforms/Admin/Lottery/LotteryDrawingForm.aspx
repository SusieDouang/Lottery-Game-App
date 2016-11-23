<%@ Page Language="C#" 
    MasterPageFile="~/MasterPages/Site2Column.Master"
    Theme="Main"
    AutoEventWireup="true" 
    CodeBehind="LotteryDrawingForm.aspx.cs" 
    Inherits="VelocityCoders.LotteryGame.Webforms.Admin.Lottery.LotteryDrawingForm" %>

<%@ Register TagPrefix="CustomVelocityCoders" 
             TagName="LotteryNavigation" 
             Src="/UserControls/LotteryNavigationControl.ascx" %>

    <asp:Content ID="Content1" ContentPlaceHolderId="head" runat="server"></asp:Content>

    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">

    <asp:HiddenField runat="server" ID="hidDrawingId" Value="0" />
    <asp:HiddenField runat="server" ID="hidLotteryId" Value="0" />

    <%--    <div id="LotteryContainer" class="BorderRadiusBottom">--%>
        <CustomVelocityCoders:LotteryNavigation runat="server" ID="lotteryNavigation" />
            <div id="LotteryContainer" class="BorderRadiusBottom">
                <asp:Panel
                    runat="server"
                    ID="PageMessageArea"
                    CssClass="PageMessage BorderRadiusAll"
                    Visible="false">
                <asp:Label runat="server" ID="lblPageMessage" />
                    <asp:ListView runat="server" ID="MessageList" ItemPlaceHolderID="MessageListPlaceholder">
                        <LayoutTemplate>
                            <ul>
                                <asp:PlaceHolder runat="server" ID="MessageListPlaceholder" />
                            </ul>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <li><%#Eval("PropertyName") %>: <%#Eval("Message")%></li>
                        </ItemTemplate>
                    </asp:ListView>
                </asp:Panel>
        </div>
        <br />
        <asp:Label runat="server" ID="messageToDisplay" EnableViewState="true" />
        <br />
        Current Date: <asp:Label runat="server" ID="lblFormMessage" EnableViewState="true" />
        <br />
        Current Time: <% Response.Write(DateTime.Now.ToShortTimeString()); %>
        <br />
        <br />
        <table>
             <tr>
                <td><label>Lottery Name:</label></td>
                <td>
                    <asp:DropDownList runat="server" ID="drpGameNameDraw" DataTextField="LotteryName" DataValueField="LotteryId">
                    </asp:DropDownList>
               </td>
            </tr>

            <tr>
                <td><label>Drawing Date:</label></td>
                <td>
                    <asp:Textbox runat="server" ID="txtDrawingDate" DataTextField="txtDrawingDate" DataValueField="DrawingDate">
                    </asp:Textbox>
               </td>
            </tr> 

        <%--    <tr>
                <td><label>Drawing Id:</label></td>
                <td><asp:TextBox runat="server" ID="txtDrawingId" MaxLength="50" /></td>               
            </tr>--%>

            <tr>
                <td><label>Jackpot Amount:</label></td>
                <td><asp:TextBox runat="server" ID="txtJackpotAmount" MaxLength="50" /></td>
            </tr>  
                   
            <tr>
                <td><label>Number:</label></td>
                <td><asp:TextBox runat="server" ID="txtNumber" MaxLength="50" /></td>
            </tr>   
                  
<%--            <tr>
                <td><label>Number:</label></td>
                <td><asp:TextBox runat="server" ID="txtWinningNumber2" MaxLength="50" /></td>
            </tr>  
                   
            <tr>
                <td><label>Number:</label></td>
                <td><asp:TextBox runat="server" ID="txtWinningNumber3" MaxLength="50" /></td>
            </tr>   
                  
            <tr>
                <td><label>Number:</label></td>
                <td><asp:TextBox runat="server" ID="txtWinningNumber4" MaxLength="50" /></td>
            </tr>  
                   
            <tr>
                <td><label>Number:</label></td>
                <td><asp:TextBox runat="server" ID="txtWinningNumber5" MaxLength="50" /></td>
            </tr>    
                 
            <tr>
                <td><label>Special Ball:</label></td>
                <td><asp:TextBox runat="server" ID="txtWinningNumber6" MaxLength="50" /></td>
            </tr> --%>        
<%--             td><label>Cash Option Amount:</label></td>
                <td><asp:TextBox runat="server" ID="txtCashOptionAmount" MaxLength="50" /></td>
            </tr>   
            <tr>--%>
        <%--        <td><label>Multiplier:</label></td>
                <td><asp:TextBox runat="server" ID="txtMultiplier" MaxLength="50" /></td>
            </tr>--%>

        </table>
        
        <br />
        <br />    
    <div class="ContainerBar">
        <asp:Button runat="server" Text="Update Lottery Drawing" OnClick="Save_Click" ID="btnSave" />
        &nbsp;&nbsp;<br /><br />
        <asp:Button runat="server" Text="Cancel" OnClick="Cancel_Click" ID="btnCancel" />
        <span class="FloatRight">
            <asp:Button runat="server" Text="Delete" ID="btnDelete" OnClick="Delete_Click" Visible="false" />
        </span>
    </div>
        <br />
        <br />

        <asp:Repeater runat="server" ID="rptLotteryDrawing">

            <HeaderTemplate>
                <table>
                    <tr>
                        <td>Lottery Name</td>
                        <td>Drawing Date</td>
                        <td>Drawing Id</td>
                        <td>Jackpot Amount</td>
                        <td>Number</td>
                        <td>Edit</td>
                        <td>&nbsp;</td>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td><%# Eval("LotteryName") %></td>
                    <td><%# Eval("DrawingDate") %></td>
                    <td><%# Eval("DrawingId") %></td>
                    <td><%# Eval("Jackpot") %></td>
                    <td class="TextCenter"><%# Eval("WinningNumber.Number") %></td>
                    <td class="TextCenter"><a href ='LotteryDrawingForm.aspx?DrawingId=<%# Eval("DrawingId") %>'>Edit</td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <br />
        <br />
 </asp:Content>