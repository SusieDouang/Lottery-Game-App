<%@ Page Language="C#"
    Theme="Main" 
    MasterPageFile="~/MasterPages/Site2Column.Master"
    AutoEventWireup="true" 
    CodeBehind="LotteryForm.aspx.cs" 
    Inherits="VelocityCoders.LotteryGame.Webforms.LotteryForm" %>

<%@ Register TagPrefix="CustomVelocityCoders"
             TagName="LotteryNavigation" 
             Src ="~/UserControls/LotteryNavigationControl.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <asp:HiddenField runat="server" ID="hidDrawingId" Value="0" />
                <asp:HiddenField runat="server" ID="hidLotteryId" Value="0" />
                
    <div id="LotteryContainer" class="BorderRadiusBottom">
        <CustomVelocityCoders:LotteryNavigation runat="server" ID="lotteryNavigation" />
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
                <td><label>Lottery Name:</label></td>
                <td>
                    <asp:DropDownList runat="server" ID="drpLotteryName" DataTextField="LotteryName" DataValueField="LotteryId">
                    </asp:DropDownList>
               </td>
            </tr>

            <tr>
                <td><label>Lottery Name Abbreviation:</label></td>
                <td>
                    <asp:TextBox runat="server" ID="txtLotteryNameAbbreviation" MaxLength="50" />
                </td>
            </tr>         
            <tr>
                <td><label>How to Play:</label></td>
                <td>
                    <asp:TextBox runat="server" ID="txtHowToPlay" MaxLength="50" />
                </td>
            </tr>  
             
            <tr>
                <td><label>Description:</label></td>
                <td>
                    <asp:TextBox runat="server" ID="txtDescription" MaxLength="50" />
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
        <br />
        <br />
</asp:Content>