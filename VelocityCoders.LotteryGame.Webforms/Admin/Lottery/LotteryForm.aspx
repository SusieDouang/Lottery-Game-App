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
                <td><asp:TextBox runat="server" ID="txtLotteryNameAbbreviation" MaxLength="50" /></td></asp>
            </tr>         
            <tr>
                <td><label>How to Play:</label></td>
                <td><asp:TextBox runat="server" ID="txtHowToPlay" MaxLength="50" /></td></asp>
            </tr>   
            <tr>
                <td><label>Description:</label></td>
                <td><asp:TextBox runat="server" ID="txtDescription" MaxLength="50" /></td></asp>
            </tr>
        </table>
        <br />
        <br />
        <asp:Button runat="server" Text="Save" OnClick="Save_Click" />
        <br />
        <br />
</asp:Content>