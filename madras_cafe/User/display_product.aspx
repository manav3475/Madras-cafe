<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="display_product.aspx.cs" Inherits="madras_cafe.User.display_product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <asp:Repeater ID="d1" runat="server">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <ItemTemplate> 
          <li class="last">
           <a href="product_desc.aspx?id=<%#Eval("product_id")%>"><img src="../<%#Eval("product_images")%>" alt="" /></a>
            <div class="product-info">
              <h3><%#Eval("product_name") %></h3>
              <div class="product-desc">
                <h4>Stock:<%#Eval("product_qty") %></h4>
                <p><%#Eval("product_desc") %></p>
                <strong class="price"><%#Eval("product_price") %></strong> </div>
            </div>
          </li>
     </ItemTemplate>
     <FooterTemplate>
          </ul>
     </FooterTemplate>
    </asp:Repeater>
</asp:Content>
