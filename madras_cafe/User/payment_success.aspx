    <%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="payment_success.aspx.cs" Inherits="madras_cafe.User.payment_success" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
            <h1><center>Thank You For Shopping</center></h1>
            <h3><center>Your Order Id:-<asp:Label ID="ordervalue" runat="server"/></center></h3>
            <h2><center><a href='display_product.aspx'>Continue shopping</a></center></h2>
</asp:Content>
