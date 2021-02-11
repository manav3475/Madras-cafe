<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="feedback.aspx.cs" Inherits="madras_cafe.User.feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <link href="css/style.css" rel="stylesheet" type="text/css" />
   <link href="css/ie6.css" rel="stylesheet" type="text/css" />
 <center>
<div class="search">
    <div>    <br />   
    <h1>
    FEEDBACK
    <span></span>
    </h1></div>

    <div class="box"> 
    <label>Description</label>
    <asp:TextBox ID="fdes" TextMode="MultiLine" Columns="20" Rows="10" runat="server"  CssClass="field"  Width="206px"></asp:TextBox>
     Email ID<asp:TextBox ID="femail" TextMode="Email" runat="server" CssClass="field"  Width="206px"></asp:TextBox><br />
     <asp:Button ID="submit" runat="server" Text="SUBMIT" onclick="submit_Click" CssClass="search-submit" Width="70px" Height="27px"/>
    </div>
</div>
</center>

</asp:Content>
