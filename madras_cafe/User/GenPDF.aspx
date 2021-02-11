<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="GenPDF.aspx.cs" Inherits="madras_cafe.User.GenPDF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
<asp:Panel ID="Report" runat="server">
          <asp:Panel ID="Panel1" runat="server">
          <form id="f1" runat="server">
                <br />
                    <table border="1">
                        <tr align="center">
                            <td>
                                <asp:Label ID="Label2" runat="server" Font-Bold="True"
                                    Text="MADRAS CAFE" Font-Size="20pt"></asp:Label>
                                <br />
                                madrascafe1@gmail.com
                            </td>
                        </tr>
                        <tr align="center">
                            <td>
                               <%-- <asp:Label ID="lblReportTitle" runat="server" Text=""></asp:Label>--%>
                               Payment Recepit
                            </td>
                        </tr>
                        <tr>
                            <td class="align-left">
                                Report Generation Date:<asp:Label ID="lblDate" runat="server" Text=""></asp:Label> <br/>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                 <asp:Label ID="lblDataTitle" runat="server" Text=""></asp:Label>
                                 <asp:GridView ID="gvReport" runat="server"></asp:GridView>
                                 <asp:GridView ID="gvReport1" runat="server"></asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td class="align-left">
                                Total Amount:-<asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                ---
                            </td>
                        </tr>
                        <tr>
                            <td>
                               
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>This is a computer genrated reciept and does not required signature and stamp.<br/>
                            </td>
                        </tr>
                    </table>
                    </form>
                </asp:Panel>
</asp:Panel>
</asp:Content>
