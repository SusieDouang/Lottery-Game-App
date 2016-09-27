<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B05-ConditionalLab.aspx.cs" Inherits="VelocityCoders.LotteryGame.Webforms.B05" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
   <asp:Label runat="server" ID="condition1" /> </br>   
   <asp:Label runat="server" ID="condition2" /> </br>
   <asp:Label runat="server" ID="condition3" /> </br>
   <asp:Label runat="server" ID="condition4" /> </br>   
   <asp:Label runat="server" ID="condition5" /> </br>   
        Fast Food Restaurants:&nbsp;&nbsp<asp:Textbox runat="server" ID="txtRestFood" /></br>
        (Burger King, McDonald's, Subway)</br></br>
        <asp:Button runat="server" Text="Submit" /></br>
    </div>
    </form>
</body>
</html>
