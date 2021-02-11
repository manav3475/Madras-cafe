<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true" CodeBehind="add_Delete_Category.aspx.cs" Inherits="madras_cafe.Admin.add_Delete_Category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
<center>
    <table>
             <tr>
                <td>Enter Category:-</td>
                <td><asp:TextBox ID="pc" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="req_cat" runat="server" ControlToValidate="pc" 
                        ErrorMessage="Required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                 </td>    
            </tr>
            <tr>
                <td colspan="2" align="center">
                <br>
                <asp:Button ID="addc" runat="server" Text="Add Category" onclick="addc_Click"/>
                </td>
            </tr>
    </table>

    <asp:DataList ID="dc" runat="server">
    <HeaderTemplate>
    <table border="2">
    <h2>Category List</h2>
    </HeaderTemplate>
   
    <ItemTemplate>
    <tr>
    <td><%#Eval("product_category") %></td>
    <td><a href="delete.aspx?category=<%#Eval("product_category") %>">Delete</a></td>
    </tr>
    </ItemTemplate>

    <FooterTemplate>
    </table>
    </FooterTemplate>
    </asp:DataList>
</center>
</asp:Content>
