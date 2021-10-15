<%@ Page Title="" Language="C#" MasterPageFile="~/TestMaster.Master" AutoEventWireup="true" CodeBehind="MerkBarang.aspx.cs" Inherits="TestWeb.MerkBarang" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="GridView.css" />
    <link href="http://code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.min.css"
        rel="stylesheet" type="text/css" />
    <script src="http://code.jquery.com/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script src="http://code.jquery.com/ui/1.10.4/jquery-ui.min.js" type="text/javascript"></script>
    <style type="text/css">
        .Background {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .Popup {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 400px;
            height: 350px;
        }

        .lbl {
            font-size: 16px;
            font-style: italic;
            font-weight: bold;
        }

        .label {
            font-weight: bold;
            font-size: x-large;
        }

        .btn {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctContent" runat="server">
    <asp:UpdatePanel ID="update1" runat="server">
        <ContentTemplate>
            <br />
            <br />
            <br />
            <h1>Merk Barang</h1>
            <asp:Button ID="btn" runat="server" Text="Add" CssClass="btn" />
            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" Width="70" Font-Size="Medium" />
            <br />
            <br />
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <ajaxToolkit:ModalPopupExtender runat="server" ID="mp1" PopupControlID="Panl1" TargetControlID="btn"
               BackgroundCssClass="Background" CancelControlID="btnClose"></ajaxToolkit:ModalPopupExtender>

            <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" Style="display: none">
                <br />
                <asp:Label ID="lblHeader" runat="server" CssClass="label"></asp:Label>
                <br />
                <br />
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblKode" Text="Kode Merk" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtKode" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" Text="Nama Distributor" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtNama" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" Text="Telepon" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtTlp" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" Text="Alamat" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtAlamat" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                <asp:Button ID="btnClose" runat="server" Text="Cancel" />
            </asp:Panel>

            <table>
                <tr>
                    <td>
                        <asp:GridView ID="grdMerk" RowStyle-CssClass="alt" runat="server" CssClass="grid" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:ImageButton ImageUrl="~/Image/edit1.png" runat="server" ID="imgEdit" OnClick="imgEdit_Click" Width="30px" Height="30px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:ImageButton ImageUrl="~/Image/cross.png" runat="server" ID="imgDelete" OnClick="imgDelete_Click" Width="30px" Height="30px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="KODE_MERK" HeaderText="Kode Merk" />
                                <asp:BoundField DataField="NAMA_DISTRIBUTOR" HeaderText="Nama Jenis Barang" />
                                <asp:BoundField DataField="TELEPON" HeaderText="Telepon" />
                                <asp:BoundField DataField="ALAMAT" HeaderText="Alamat" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
