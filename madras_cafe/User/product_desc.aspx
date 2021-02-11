<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="product_desc.aspx.cs" Inherits="madras_cafe.User.product_desc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
<link href="css/style.css" rel="stylesheet" type="text/css" />
<link href="css/ie6.css" rel="stylesheet" type="text/css" />
<asp:Repeater ID="d1" runat="server">
    <HeaderTemplate>
    </HeaderTemplate>
    <ItemTemplate> 
    <%--<div style="height:300px; width:450px; border-style:solid; border-width:1px;">--%>

    <div style="height:382px; width:250px; float:left;border-style:solid; border-width:1px;">
        <img src='../<%#Eval("product_images") %>' height="300" width="200" alt=""/>
         <h2>
            <b>
                Product Name=<%#Eval("product_name") %><br />Product Description=<%#Eval("product_desc") %><br />Product Price=<%#Eval("product_price") %><br />Product Quntity Available=<%#Eval("product_qty") %></b></h2>
    </div>
    <%--<div style="height:300px; width:245px; float:left;border-style:solid; border-width:1px;">--%>
       
   <%--</div>--%>
<%-- </div>--%>
     </ItemTemplate>
     <FooterTemplate>
     </FooterTemplate>
    </asp:Repeater>
    <br/>
    <br/>
    <br/>
    <br/>
    <br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/>
    <table>
        <tr>
            <td><asp:Label ID="enq" runat="server" Text="Enter Quantity:-"></asp:Label></td>
            <td><asp:TextBox ID="qty1" runat="server" CssClass="field" Width="206px"></asp:TextBox></td>
            <td><asp:Button ID="b1" runat="server" Text="Add To Cart" onclick="b1_Click" CssClass="search-submit" Width="80px" Height="24px"/></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="l1" runat="server" ForeColor="Red" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    
</asp:Content>
