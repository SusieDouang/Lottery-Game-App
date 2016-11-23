<%@ Page Language="C#" 
    Theme="Main2"
    MasterPageFile="~/MasterPages/Basic2Column.Master"
    AutoEventWireup="true" 
    CodeBehind="BasicLotteryForm.aspx.cs" 
    Inherits="VelocityCoders.LotteryGame.Webforms.BasicLotteryForm" %>

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
                    <asp:TextBox input type="hidden" runat="server" ID="txtLotteryId"  DataValueField="lotteryId" MaxLength="50">
                    </asp:TextBox>
               </td>
            </tr>
            <tr>
                <td><label>Lottery Name:</label></td>
                <td>
                    <asp:TextBox runat="server" ID="txtLotteryName" DataTextField="LotteryName" DataValueField="lotteryId" MaxLength="50">
                    </asp:TextBox>
               </td>
            </tr>
            <tr>
                <td><label>Lottery Name Abbreviation:</label></td>
                <td>
                    <asp:TextBox runat="server" ID="txtLotteryNameAbbreviation" MaxLength="50" />
                </td>
            </tr>
            <tr>
                <td><label>Special Ball:</label></td>
                <td>
                    <asp:DropDownList 
                        runat="server" 
                        ID="drpSpecialBall"
                        DataTextField="SpecialBallDescription"
                        DataValueField="SpecialBall">
                        <asp:ListItem Text="No" Value="0" />
                        <asp:ListItem Text="Yes" Value="1" />
                    </asp:DropDownList>
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
    
        <asp:Repeater runat="server" ID="rptLottery">

            <HeaderTemplate>
                <table>
                    <tr>
                        <td class="TextCenter">Lottery Name</td>
                        <td>Name Abbreviation</td>
                        <td>Special Ball</td>
                        <td>How To Play</td>
                        <td>Description</td>
                        <td>Edit</td>
                        <td>&nbsp;</td>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td class="TextCenter"><%# Eval("LotteryName") %></td>
                    <td class="TextCenter"><%# Eval("LotteryNameAbbreviation") %></td>

                    <td class="TextCenter">
        <%--                <%# ((int)Eval("SpecialBall")).ToString("No")%></td>--%>
                            <%# Eval("SpecialBall") %></td>
                      

                     <td class="TextCenter"><%# Eval("HowToPlay") %></td>
                    <td class="TextCenter"><%# Eval("Description") %></td>
                    <td><a href ='BasicLotteryForm.aspx?LotteryId=<%# Eval("LotteryId") %>'>Edit</td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <br />
        <br />
 </asp:Content>