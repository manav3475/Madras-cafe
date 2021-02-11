<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true" CodeBehind="view_full_order.aspx.cs" Inherits="madras_cafe.Admin.view_full_order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
<asp:Repeater ID="r1" runat="server">
        <HeaderTemplate>
            <table border='2'>
                <tr style="background-color:Gray;color:white;">
                    <td>PRODUCT IMAGE</td>
                    <td>PRODUCT NAME</td>
                    <td>PRODUCT PRICE</td>
                    <td>PRODUCT QUNTITY</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
                <tr>
                    <td><img src="../<%#Eval("product_images")%>" height="100" width="120" alt=""/></td>
                    <td><%#Eval("product_name")%></td>
                    <td><%#Eval("product_price")%></td>
                    <td><%#Eval("product_qty")%></td>
                </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Label ID="l1" runat="server" Text=""></asp:Label>
</asp:Content>
