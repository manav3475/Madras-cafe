<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="view_cart.aspx.cs" Inherits="madras_cafe.User.view_cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
<asp:DataList ID="d1" runat="server">
    <HeaderTemplate>
    <table border="2">
        <tr style="background-color:Fuchsia ; color:White; font-weight:bold;">
            <td>IMAGE</td>
            <td>NAME</td>
            <td>DESCRIPTION</td>
            <td>PRICE</td>
            <td>QUANTITY</td>
            <td>DELETE PRODUCT</td>
        </tr>
    </HeaderTemplate>
    <ItemTemplate>
    <center>
        <tr>
            <td>
                <img src="../<%#Eval("image")%>" height="100" width="100" alt="" />
            </td>
            <td>
                <%#Eval("name")%>
            </td>
            <td>
                <%#Eval("desc")%>
            </td>
            <td>
                <%#Eval("price")%>
            </td>
            <td>
                <%#Eval("qty")%>
            </td>
             <td>
                <a href="delete_cart.aspx?id=<%#Eval("id")%>">Delete</a>
            </td>
        </tr>
        </center>
    </ItemTemplate>
    <FooterTemplate>
    </table>
    </FooterTemplate>
</asp:DataList>
<br />
<p align="center" style="font-weight:bold;">
<asp:Label ID="mess" runat="server" Text=""></asp:Label><br/>
<asp:Button ID="btn_checkout" runat="server" Text="Checkout" 
        onclick="btn_checkout_Click" />
</p>
</asp:Content>
