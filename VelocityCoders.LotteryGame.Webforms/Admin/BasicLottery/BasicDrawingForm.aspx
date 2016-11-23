<%@ Page Language="C#" 
    Theme="Main2"
    MasterPageFile="~/MasterPages/Basic2Column.Master"
    AutoEventWireup="true" 
    CodeBehind="BasicDrawingForm.aspx.cs" 
    Inherits="VelocityCoders.LotteryGame.Webforms.BasicDrawingForm" %>

<%@ Register TagPrefix="CustomVelocityCoders"
             TagName="BasicLotteryNavigation" 
             Src ="~/UserControls/BasicLotteryNavigationControl.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder11" runat="server">
                <asp:HiddenField runat="server" ID="hideDrawingId" Value="0" />
                <asp:HiddenField runat="server" ID="hideLotteryId" Value="0" />
                
    <div id="BasicLotteryContainer" class="BorderRadiusBottom">
        <CustomVelocityCoders:BasicLotteryNavigation runat="server" ID="basiclotteryNavigation" />
        <asp:Label runat="server" ID="Label1"/>
    </div>
        <asp:Label runat="server" ID="messageToDisplay" EnableViewState="true" />
        <br />
        <br />
Current Date: <asp:Label runat="server" ID="lblFormMessage" EnableViewState="true" />
        <br />
Current Time: <% Response.Write(DateTime.Now.ToShortTimeString()); %>
        <br />
        <br />

        <table>
            <tr>
                <td><label></label></td>
                <td>
                <asp:TextBox input type="hidden" runat="server" ID="txtDrawingId" DataTextField="DrawingId" DataValueField="DrawingId" MaxLength="50">
                </asp:TextBox>
               </td>
            </tr>
            <tr>
                <td><label>LotteryName:</label></td>
                <td>
                <asp:DropDownList   runat="server" 
                                    ID="drpLotteryId" 
                                    DataTextField="LotteryName" 
                                    DataValueField="LotteryId" MaxLength="50">
                </asp:DropDownList>
               </td>
            </tr>
            <tr>
                <td><label>DrawingDate:</label></td>
                <td>
                <asp:TextBox runat="server" ID="txtDrawingDate" MaxLength="50" >
                </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td><label>Jackpot:</label></td>
                <td>
                <asp:TextBox runat="server" ID="txtJackpot" MaxLength="50" >
                </asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <br />
    <div class="ContainerBar">
        <asp:Button runat="server" Text="Update Lottery Form" OnClick="Save_Click" ID="btnSave" />
        <asp:Button runat="server" Text="Cancel" OnClick="Cancel_Click" ID="btnCancel" /><br /><br />
        <span class="FloatRight">
            <asp:Button runat="server" Text="Delete" ID="btnDelete" OnClick="Delete_Click" Visible="false" />
        </span>
    </div>
        <asp:Repeater runat="server" ID="rptDrawing">

            <HeaderTemplate>
                <table>
                    <tr>
                        <td>DrawingId</td>
                        <td>Lottery</td>
                        <td>DrawingDate</td>
                        <td>Jackpot</td>
                        <td>Edit</td>
                        <td>&nbsp;</td>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td class="TextCenter"><%# Eval("DrawingId") %></td>
                    <td class="TextCenter"><%# Eval("BasicLottery.LotteryName") %></td>
                    <td class="TextCenter"><%# Eval("DrawingDate", "{0:d}") %></td>
                    <td class="TextCenter"><%# Eval("Jackpot") %></td>
                    <td><a href ='BasicDrawingForm.aspx?DrawingId=<%# Eval("DrawingId") %>'>Edit</td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <br />
        <br />
 </asp:Content>