<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true" CodeBehind="Display_feedback.aspx.cs" Inherits="madras_cafe.Admin.Display_feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
<asp:Repeater ID="r1" runat="server">
    <HeaderTemplate>
        <table border='2'>
            <tr style="background-color:Gray;color:white;">
                <td>ID</td>
                <td>Description</td>
                <td>Email ID</td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
            <tr>
                <td><%#Eval("id") %></td>
                <td><%#Eval("Description") %></td>
                <td><%#Eval("email") %></td>
            </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
</asp:Content>
