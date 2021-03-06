﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true" CodeBehind="Display_order.aspx.cs" Inherits="madras_cafe.Admin.Display_order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <asp:Repeater ID="r1" runat="server">
        <HeaderTemplate>
            <table border='1'>
                <tr style="background-color:Gray;color:white;">
                    <td>ORDER ID</td>
                    <td>NAME</td>
                    <td>CITY</td>
                    <td>ADDRESS</td>
                    <td>EMAIL ID</td>
                    <td>PINCODE</td>
                    <td>MOBILE NUMBER</td>
                    <td>VIEW FULL ORDER</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
                <tr>
                    <td><%#Eval("id")%></td>
                    <td><%#Eval("name")%></td>
                    <td><%#Eval("city")%></td>
                    <td><%#Eval("address")%></td>
                    <td><%#Eval("emailid")%></td>
                    <td><%#Eval("pincode")%></td>
                    <td><%#Eval("mnumber")%></td>
                    <td><a href="view_full_order.aspx?id=<%#Eval("id")%>">VIEW FULL ORDER</a></td>
                </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
