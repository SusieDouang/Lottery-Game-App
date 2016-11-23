<%@ Page Language="C#" 
    Theme="Main2"
    MasterPageFile="~/MasterPages/Basic2Column.Master"
    AutoEventWireup="true" 
    CodeBehind="BasicWinningForm.aspx.cs" 
    Inherits="VelocityCoders.LotteryGame.Webforms.BasicWinningForm" %>

<%@ Register TagPrefix="CustomVelocityCoders"
             TagName="BasicLotteryNavigation" 
             Src ="~/UserControls/BasicLotteryNavigationControl.ascx" %>

                
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder11" runat="server">
                <asp:HiddenField runat="server" ID="hideDrawingId" Value="0" />
                <asp:HiddenField runat="server" ID="hideLotteryId" Value="0" />
                <asp:HiddenField runat="server" ID="hideWinningNumberId" Value="0" />
                
    <div id="BasicLotteryContainer" class="BorderRadiusBottom">
        <CustomVelocityCoders:BasicLotteryNavigation runat="server" ID="basiclotNavigation" />
        <asp:Label runat="server" ID="Label11"/>
    </div>
        <asp:Label runat="server" ID="messageToDisplays" EnableViewState="true" />
        <br />
        <br />
Current Date: <asp:Label runat="server" ID="lblFormMessages" EnableViewState="true" />
        <br />
Current Time: <% Response.Write(DateTime.Now.ToShortTimeString()); %>
        <br />
        <br />

        <table>
            <tr>
                <td><label></label></td>
                <td>
                    <asp:TextBox input type="hidden" runat="server" ID="txtWinningNumId" DataTextField="WinningNumber" DataValueField="WinningNumberId" MaxLength="50">
                    </asp:TextBox>
               </td>
            </tr>
                        <tr>
                <td><label>DrawingId</label></td>
                <td>
                    <asp:TextBox runat="server" ID="txtDrawId" DataTextField="DrawingId" DataValueField="DrawingId" MaxLength="50">
                    </asp:TextBox>
               </td>
            </tr>
            <tr>
                <td><label>BallTypeId:</label></td>
                <td>
                    <asp:DropDownList
                        runat="server" 
                        ID="drpBallTypeId" 
                        DataTextField="BallType"
                        DataValueField="BallTypeId"
                        MaxLength="50" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td><label>Number:</label></td>
                <td>
                    <asp:TextBox runat="server" ID="txtNumbers" MaxLength="50" />
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
    
        <asp:Repeater runat="server" ID="rptWinningNumber">
            <HeaderTemplate>
                <table>
                    <tr>
                        <td>WinningNumberId</td>
                        <td>DrawingId</td>
                        <td>BallType</td>
                        <td>Number</td>
                        <td>Edit</td>
                        <td>&nbsp;</td>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td class="TextCenter"><%# Eval("WinningNumberId") %></td>
                    <td class="TextCenter"><%# Eval("DrawingId") %></td>
                    <td class="TextCenter"><%# Eval("BasicBallType.BallType") %></td>
                    <td class="TextCenter"><%# Eval("Number") %></td>
                    <td><a href ='BasicWinningForm.aspx?WinningNumberId=<%# Eval("WinningNumberId") %>'>Edit</td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <br />
        <br />
 </asp:Content>