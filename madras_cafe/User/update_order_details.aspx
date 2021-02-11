<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="update_order_details.aspx.cs" Inherits="madras_cafe.User.update_order_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
<center>
    <table>
        <h1>Update Customer Details</h1>
        <tr>
            <td>
                Name:-
            </td>
            <td style="width: 187px">
                <asp:TextBox ID="txt_name" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
                Address:-
            </td>
            <td style="width: 187px">
                <asp:TextBox ID="txt_add" runat="server" Height="68px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
               Pincode:-
            </td>
            <td style="width: 187px">
                <asp:TextBox ID="txt_pincode" runat="server"></asp:TextBox>
            </td>
         </tr>
         <tr>
            <td>
              Mobile Number:-
            </td>
            <td style="width: 187px">
                <asp:TextBox ID="txt_mn" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td colspan="2" align="center" style="height: 80px">
            <input type="hidden" runat="server" id="key" name="key" value="gtKFFx" />
            <input type="hidden" runat="server" id="salt" name="salt" value="eCwWELxi" />
            <input type="hidden" runat="server" id="hash" name="hash" value=""  />
            <input type="hidden" runat="server" id="txnid" name="txnid" value="" />
                <asp:Button ID="btn_updateandcontinue" runat="server" 
                    Text="Update AND Continue" onclick="btn_updateandcontinue_Click" />
                </td>
         </tr>
        
    
    </table>
    
</center>
</asp:Content>
