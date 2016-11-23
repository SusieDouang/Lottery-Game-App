<%@ Language="C#" 
    MasterPageFile="~/MasterPages/Site2Column.Master" 
    Theme="Main"
    AutoEventWireup="true" 
    CodeBehind="WinningNumberForm.aspx.cs" 
    Inherits="VelocityCoders.LotteryGame.Webforms.Admin.Lottery.DrawingIdForm" %>

<%@ Register TagPrefix="CustomVelocityCoders" 
             TagName="LotteryNavigation"
             Src="/UserControls/LotteryNavigationControl.ascx"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <asp:HiddenField runat="server" ID="hidDrawingId" Value="0" />
                <asp:HiddenField runat="server" ID="hidLotteryId" Value="0" />

        <div id="LotteryContainer" class="BorderRadiusBottom">
        <CustomVelocityCoders:LotteryNavigation runat="server" Id="lotteryNavigation" /></div>
        <br /> 
        <asp:Label runat="server" ID="messageToDisplay" EnableViewState="true" />
        <br />
        Current Date: <% Response.Write(DateTime.Now.ToShortDateString()); %>
        <br />
        Current Time: <% Response.Write(DateTime.Now.ToShortTimeString()); %>
        <br />
        <br />

    <table>
        <tr>
            <td><label>LotteryName</label></td>
            <td>
                <asp:DropDownList runat="server" ID="drpLotteryName" DataValueField="LotteryName">
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td><label>DrawingDate</label></td>
            <td>
                <asp:DropDownList runat="server" ID="drpDrawingDate" DataValueField="DrawingDate">
                </asp:DropDownList>
            </td>
        </tr>
     
        <tr>
            <td><label>BallTypeId</label></td>
            <td>
                <asp:DropDownList runat="server" ID="drpBallTypeId" DataValueField="BallTypeId" DataTextField = "Description">
                </asp:DropDownList>
            </td>    
        </tr>
        
        <tr>
            <td><label>Number</label></td>
            <td>
                <asp:Textbox runat="server" ID="txtNumber" DataTextField="txtNumber" DataValueField="Number">
                   </asp:Textbox>
            </td>
        </tr>

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
        <br />
        <br />

        <asp:Repeater runat="server" ID="rptWinningNumber">
            <HeaderTemplate>
                <table>
                    <tr>
                        <td>LotteryName</td>
                        <td>Drawing Date</td>
                        <td>BallTypeId</td>
                        <td>Number</td>
                        <td>&nbsp;</td>
                    </tr>
            </HeaderTemplate
            <ItemTemplate>
               <tr>
                <td><%# Eval("LotteryName") %></td>
                <td><%# Eval("DrawingDate") %></td>
                <td><%# Eval("Description") %></td>
                <td class="TextCenter"><%# Eval("Number") %></td>
                <td class="TextCenter"><a href='WinningNumberForm.aspx?LotteryId=<%# Eval("LotteryId")%>'>Edit</td>
               </tr>
           </ItemTemplate>
                  <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        </div>
</asp:Content>







