<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="book_table.aspx.cs" Inherits="madras_cafe.User.book_table" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <center><h1>Booking Table</h1></center>
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 402px;
            margin-right: 0px;
            background-color: black;
        }
        .style2
        {
            width: 269px;
            background-color: grey;
        }
        .style3
        {
            width: 269px;
            height: 230px;
            background-color: grey;
        }
        .style4
        {
            height: 230px;
            background-color: white;
        }
        .style5
        {
            width: 269px;
            height: 90px;
            background-color: grey;
        }
        .style6
        {
            height: 90px;
            background-color: white;
        }
        .style7
        {
            width: 269px;
            height: 112px;
            background-color:grey ;
        }
        .style8
        {
            height: 112px;
            background-color:white ;
        }
        .style9
        {
            width: 269px;
            height: 62px;
            background-color: grey;
        }
        .style10
        {
            height: 62px;
            background-color: white;
        }
        .style11
        {
            width: 269px;
            height: 49px;
            background-color: grey;
        }
        .style12
        {
            height: 49px;
            background-color: white;
        }
        .style13
        {
            background-color: white;
        }
    </style>
</head>
<body style="height: 890px">
    <form id="form1" runat="server">
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <table class="style1">
        <tr>
            <td class="style11">
                Customer Name:-</td>
            <td class="style12">
                <asp:TextBox ID="txt_cname" runat="server" Width="185px" 
                   ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                Number Of Person:-</td>
            <td class="style6">
                <asp:TextBox ID="txt_nop" runat="server" Width="190px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Select Date:-</td>
            <td class="style4">
                <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            </td>
        </tr>
        <tr>
            <td class="style7">
                Select Time:-</td>
            <td class="style8">
                Start Time:-&nbsp;
                <asp:DropDownList ID="drp_stime" runat="server" Height="27px" Width="136px">
                    <asp:ListItem>10:00 AM</asp:ListItem>
                    <asp:ListItem>10:30 AM</asp:ListItem>
                    <asp:ListItem>11:00 AM</asp:ListItem>
                    <asp:ListItem>11:30 AM</asp:ListItem>
                    <asp:ListItem>12:00 AM</asp:ListItem>
                    <asp:ListItem>12:30 PM</asp:ListItem>
                    <asp:ListItem>01:00 PM</asp:ListItem>
                    <asp:ListItem>01:30 PM</asp:ListItem>
                    <asp:ListItem>02:00 PM</asp:ListItem>
                    <asp:ListItem>02:30 PM</asp:ListItem>
                    <asp:ListItem>03:00 PM</asp:ListItem>
                    <asp:ListItem>03:30 PM</asp:ListItem>
                    <asp:ListItem>04:00 PM</asp:ListItem>
                    <asp:ListItem>04:30 PM</asp:ListItem>
                    <asp:ListItem>05:00 PM</asp:ListItem>
                    <asp:ListItem>05:30 PM</asp:ListItem>
                    <asp:ListItem>06:00 PM</asp:ListItem>
                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Time:-<asp:DropDownList ID="drp_etime" runat="server" 
                    Height="27px" Width="136px">
                    <asp:ListItem>10:00 AM</asp:ListItem>
                    <asp:ListItem>10:30 AM</asp:ListItem>
                    <asp:ListItem>11:00 AM</asp:ListItem>
                    <asp:ListItem>11:30 AM</asp:ListItem>
                    <asp:ListItem>12:00 AM</asp:ListItem>
                    <asp:ListItem>12:30 PM</asp:ListItem>
                    <asp:ListItem>01:00 PM</asp:ListItem>
                    <asp:ListItem>01:30 PM</asp:ListItem>
                    <asp:ListItem>02:00 PM</asp:ListItem>
                    <asp:ListItem>02:30 PM</asp:ListItem>
                    <asp:ListItem>03:00 PM</asp:ListItem>
                    <asp:ListItem>03:30 PM</asp:ListItem>
                    <asp:ListItem>04:00 PM</asp:ListItem>
                    <asp:ListItem>04:30 PM</asp:ListItem>
                    <asp:ListItem>05:00 PM</asp:ListItem>
                    <asp:ListItem>05:30 PM</asp:ListItem>
                    <asp:ListItem>06:00 PM</asp:ListItem>
                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_cava" runat="server" BorderColor="#3366FF" 
                     Text="Check Availability" Width="154px" onclick="btn_cava_Click" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                Select Table:-</td>
            <td class="style13">
                <asp:Label ID="Label1" runat="server"></asp:Label>
                <br />
                <asp:RadioButtonList ID="rdl_selecttable" runat="server" Visible="False">
                    <asp:ListItem>Tabel No 1</asp:ListItem>
                    <asp:ListItem>Table No 2</asp:ListItem>
                    <asp:ListItem>Table No 3</asp:ListItem>
                    <asp:ListItem>Table No 4</asp:ListItem>
                    <asp:ListItem>Table No 5</asp:ListItem>
                    <asp:ListItem>Table No 6</asp:ListItem>
                    <asp:ListItem>Table No 7</asp:ListItem>
                    <asp:ListItem>Table No 8</asp:ListItem>
                    <asp:ListItem>Table No 9</asp:ListItem>
                    <asp:ListItem>Table No 10</asp:ListItem>
                </asp:RadioButtonList>
                <br />
            </td>
        </tr>
        <tr>
            <td class="style9">
            </td>
            <td class="style10">
                <asp:Button ID="btn_btable" runat="server" BorderColor="#3366FF" 
                     Text="Book Table" Width="154px" onclick="btn_btable_Click" />
            </td>
        </tr>
    </table>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="lbl_booktabelname" runat="server"></asp:Label>
    </p>
    </form>
</body>
</html>
