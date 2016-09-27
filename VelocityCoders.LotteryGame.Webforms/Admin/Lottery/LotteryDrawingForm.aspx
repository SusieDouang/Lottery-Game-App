<%@ Page Language="C#" 
    MasterPageFile="~/MasterPages/Site2Column.Master"
    Theme="Main"
    AutoEventWireup="true" 
    CodeBehind="LotteryDrawingForm.aspx.cs" 
    Inherits="VelocityCoders.LotteryGame.Webforms.Admin.Lottery.LotteryDrawingForm" %>

<%@ Register TagPrefix="CustomVelocityCoders" 
             TagName="DrawingNavigation" 
             Src="/UserControls/DrawingNavigationControl.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderId="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    <asp:HiddenField runat="server" ID="hidDrawingId" Value="0" />
    <asp:HiddenField runat="server" ID="hidLotteryId" Value="0" />

    <div id="LotteryContainer" class="BorderRadiusBottom">
        <CustomVelocityCoders:DrawingNavigation runat="server" ID="drawingNavigation" />
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
                    <asp:DropDownList runat="server" ID="drpGameNameDraw" DataTextField="LotteryName" DataValueField="LotteryId">
                    </asp:DropDownList>
               </td>
            </tr>
            <tr>
            <tr>
                <td><label>Drawing Date:</label></td>
                <td>
                    <asp:DropDownList runat="server" ID="drpDrawingDate" DataTextField="DrawingDate" DataValueField="DrawingId">
                    </asp:DropDownList>
                    <input type='date' name='drawingDate' />
               </td>
            </tr> 
            <tr>
                <td><label>Jackpot Amount:</label></td>
                <td><asp:TextBox runat="server" ID="txtJackpotAmount" MaxLength="50" /></td>
            </tr>         
            <tr>
<%--                <td><label>Cash Option Amount:</label></td>
                <td><asp:TextBox runat="server" ID="txtCashOptionAmount" MaxLength="50" /></td>
            </tr>   
            <tr>--%>
        <%--        <td><label>Multiplier:</label></td>
                <td><asp:TextBox runat="server" ID="txtMultiplier" MaxLength="50" /></td>
            </tr>--%>
        </table>
        <br />
        <br />
         <asp:Button runat="server" Text="Update Lottery Drawing" OnClick="Save_Click" ID="btnSave" />
    &nbsp;&nbsp;<br /><br />
   <asp:Button runat="server" Text="Cancel" OnClick="Cancel_Click" ID="btnCancel" />
   
        <br />
        <br />
 </asp:Content>