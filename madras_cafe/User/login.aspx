<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="madras_cafe.User.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
  
   <link href="css/style.css" rel="stylesheet" type="text/css" />
   <link href="css/ie6.css" rel="stylesheet" type="text/css" />
    <center>
   
   
    <div class="box search" style="margin-top:-18px">
    <br />   
    <h2>
    LOGIN
    <span></span>
    </h2>
    <div class="box-content"> 
     <label>Email Id</label>
           <asp:TextBox ID="txt_email" runat="server" CssClass="field" Width="206px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="Rq_un" runat="server" 
            ControlToValidate="txt_email" ErrorMessage="Required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
            <label>Passsword</label>
            <asp:TextBox ID="txt_password" runat="server"  TextMode="Password" CssClass="field" Width="206px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="req_ps" runat="server" 
            ControlToValidate="txt_password" ErrorMessage="Required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
            <asp:Button ID="Submit" runat="server" Text="Login" onclick="Submit_Click" CssClass="search-submit" Width="70px" Height="27px" /> 
                     <asp:Label ID="mess" runat="server" Text="" ForeColor="Red"></asp:Label>
                  <td colspan="2" align="center">
       </div>
         
</div> 
</center>
    
</asp:Content>
