<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true" CodeBehind="add_product.aspx.cs" Inherits="madras_cafe.Admin.add_product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
<center>
<h3>ADD NEW PRODUCT</h3>
<table>
    <tr>
        <td>Product Name:-</td>
        <td><asp:TextBox ID="txt_pn" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="req_pn" runat="server" 
                ControlToValidate="txt_pn" ErrorMessage="Required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>Product Description:-</td>
        <td><asp:TextBox ID="txt_pd" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="req_pd" runat="server" 
                ControlToValidate="txt_pd" ErrorMessage="Required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>Product Price:-</td>
        <td><asp:TextBox ID="txt_pp" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="req_pp" runat="server" 
                ControlToValidate="txt_pp" ErrorMessage="Required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>Product Quantity:-</td>
        <td><asp:TextBox ID="txt_pqty" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="req_pq" runat="server" 
                ControlToValidate="txt_pqty" ErrorMessage="Required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>Product Images:-</td>
        <td><asp:FileUpload ID="fu_pim" runat="server" />
            <asp:RequiredFieldValidator ID="req_pi" runat="server" 
                ControlToValidate="fu_pim" ErrorMessage="Required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
        </td>
    </tr>

    <tr>
        <td>Select Category:-</td>
        <td><asp:DropDownList ID="sc" runat="server"></asp:DropDownList></td>
    </tr>

    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="b1" runat="server" Text="SAVE" onclick="b1_Click" />
            <br />
            <asp:Label ID="p_mess" runat="server" Text=""></asp:Label>
        </td>
    </tr>
</table> 
</center>   
</asp:Content>
