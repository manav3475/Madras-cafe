<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="madras_cafe.User.registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <link href="css/style.css" rel="stylesheet" type="text/css" />
   <link href="css/ie6.css" rel="stylesheet" type="text/css" />
 <center>
<div class="search">
    <div>    <br />   
    <h1>
    Registration
    <span></span>
    </h1></div>

    <div class="box"> 
    Name <asp:TextBox ID="uname" runat="server" CssClass="field"  Width="206px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="Req_txtname" runat="server" 
            ControlToValidate="uname" ErrorMessage="Required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
        <br />
    <label>City</label>
    <asp:TextBox ID="ucity" runat="server" CssClass="field"  Width="206px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="city_txt" runat="server" 
            ControlToValidate="ucity" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
    <label>Address</label>
    <asp:TextBox ID="uadd" TextMode="MultiLine" Columns="10" Rows="5" runat="server"  CssClass="field"  Width="206px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="r_txtadd" runat="server" 
            ControlToValidate="uadd" ErrorMessage="Required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
    <label>Email Id</label>
    <asp:TextBox ID="uemail" runat="server" CssClass="field"  Width="206px"></asp:TextBox>
        <asp:RegularExpressionValidator ID="txt_reg_email" runat="server" 
            ControlToValidate="uemail" ErrorMessage="Invalid Formate" ForeColor="#CC0000" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="Email_req" runat="server" 
            ControlToValidate="uemail" ErrorMessage="Required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
    <label>Pincode</label>
    <asp:TextBox ID="upin" runat="server" MaxLength="6" CssClass="field"  Width="206px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="_pincode" runat="server" 
            ControlToValidate="upin" ErrorMessage="Required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
    <label>Mobile Number </label>
    <asp:TextBox ID="mnumber" runat="server" MaxLength="10" CssClass="field"  Width="206px"></asp:TextBox>
        <asp:RegularExpressionValidator ID="req_mn" runat="server" 
            ControlToValidate="mnumber" ErrorMessage="Enter 10 Digites" ForeColor="#CC0000" 
            ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="txt_pass" runat="server" 
            ControlToValidate="mnumber" ErrorMessage="Required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
    <label>Password</label>
    <asp:TextBox ID="password" runat="server" CssClass="field"  Width="206px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="req_txtpass" runat="server" 
            ControlToValidate="password" ErrorMessage="Required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
    <label>Confirm Password</label>
    <asp:TextBox ID="cpass" runat="server" CssClass="field"  Width="206px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="req_cp" runat="server" 
            ControlToValidate="cpass" ErrorMessage="Required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
    <asp:Button ID="submit" runat="server" Text="SUBMIT" onclick="submit_Click" CssClass="search-submit" Width="70px" Height="27px"/>
    
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </div>
</div>
</center>
</asp:Content>
