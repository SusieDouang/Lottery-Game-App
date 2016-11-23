<%@ Page Language="C#" 
    Theme="Main2"
    MasterPageFile="~/MasterPages/Basic2Column.Master"
    AutoEventWireup="true" 
    CodeBehind="BasicWinningResults.aspx.cs" 
    Inherits="VelocityCoders.LotteryGame.Webforms.BasicWinningResults" %>

<%@ Register TagPrefix="CustomVelocityCoders"
             TagName="BasicLotteryNavigation" 
             Src ="~/UserControls/BasicLotteryNavigationControl.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder11" runat="server">
                <asp:HiddenField runat="server" ID="hideDrawingId" Value="0" />
                <asp:HiddenField runat="server" ID="hideLotteryId" Value="0" />
                
    <div id="BasicLotteryContainer" class="BorderRadiusBottom">
        <CustomVelocityCoders:BasicLotteryNavigation runat="server" ID="basicLotNavigation" />
        <asp:Label runat="server" ID="Label1"/>
    </div>
        <asp:Label runat="server" ID="messageToDisplay" EnableViewState="true" />
        <br />
        <br />
Current Date: <% Response.Write(DateTime.Now.ToShortDateString()); %>
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
        </table>
        <br />
        <br />
            
        <asp:Repeater runat="server" ID="rptResults" OnItemDataBound="numberList_OnItemDataBound">
            <HeaderTemplate>
                <table class="ListStyle">
                    <tr>
                        <th>LotteryName</th>
                        <th>DrawingDate</th>
                        <th>Number</th>
                        <th>BallType</th>
                        <th>Jackpot</th>
                        <th>&nbsp;</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                        <td class="TextCenter"><%# Eval("BasicLottery.LotteryName") %></td>
                        <td class="TextCenter"><%# Eval("DrawingDate", "{0:d}") %></td>
                        <td class="TextCenter">
  <%--                          <asp:Repeater runat="server" ID="rptNumbers">--%>
                            <%# Eval("BasicWinningNumber.Number") %>
                        </td>
                        <td class="TextCenter"><%# Eval("BasicBallType.BallType") %></td>
                        <td class="TextCenter"><%# Eval("Jackpot") %></td>
       <%--             <td><a href ='BasicDrawingForm.aspx?DrawingId=<%# Eval("DrawingId") %>'>Edit</td>--%>
                    </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr>
                    <td class="ListStyleAlternate"><%# Eval("BasicWinningNumber.Number") %></td>
                </tr>
            </AlternatingItemTemplate>
        <FooterTemplate>
                </table>
        </FooterTemplate>
        </asp:Repeater>
 </asp:Content>


