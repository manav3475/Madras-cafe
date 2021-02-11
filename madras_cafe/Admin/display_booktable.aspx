<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true" CodeBehind="display_booktable.aspx.cs" Inherits="madras_cafe.Admin.display_booktable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
<asp:Repeater ID="r1" runat="server">
    <HeaderTemplate>
        <table border='2'>
            <tr style="background-color:Gray;color:white;">
                <td>Booking ID</td>
                <td>Table Number</td>
                <td>Customer Name</td>
                <td>Total Person</td>
                <td>Date AND Time Start</td>
                <td>Date AND Time End</td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
            <tr>
                <td><%#Eval("bookingid") %></td>
                <td><%#Eval("tableno") %></td>
                <td><%#Eval("customername") %></td>
                <td><%#Eval("totalperson")%></td>
                <td><%#Eval("dtstart")%></td>
                <td><%#Eval("dtend")%></td>
            </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
</asp:Content>
