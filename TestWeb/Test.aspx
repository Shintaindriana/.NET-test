<%@ Page Title="" Language="C#" MasterPageFile="~/TestMaster.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="TestWeb.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctContent" runat="server">
    
    <table>
        <tr>
            <td>
                <h1> Shinta Indriana </h1>
            </td>
            <td>
                <asp:TextBox ID="txtKode" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtnama" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click"/>
            </td>
        </tr>
    </table>
</asp:Content>
