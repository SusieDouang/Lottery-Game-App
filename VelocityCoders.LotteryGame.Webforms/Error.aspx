<%@ Page Title="Error" 
    Theme="Main" Language="C#" 
    MasterPageFile="~/MasterPages/Site2Column.Master" 
    AutoEventWireup="true" CodeBehind="Error.aspx.cs" 
    Inherits="VelocityCoders.LotteryGame.Webforms.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="GenericNavigationContainer Border Radius BorderRadiusTop">
        <span class="HeaderText">Page Error</span>
    </div>
    <div id="GenericContainer">
        <div class="HeaderText">Error Occurred</div>
        <p>
            An error occured while processing your request. 
            Your request and error information has been logged and the web team has been notified.
            Please click <asp:HyperLink runat="server" ID="PreviousPageLink" Text="HERE" CssClass="HeaderText" /> 
            to go back to our previous page.
        </p>
            <br />
            <div class="HeaderText"> Support Information</div>
            <p>
                If the error continues and you need assistance immediately please contact our support group: 
                contact@velocitycoders.com
            </p>
    </div>
</asp:Content>
