<%@ Page Title="" Language="C#" MasterPageFile="~/TestMaster.Master" AutoEventWireup="true" CodeBehind="DataMasuk.aspx.cs" Inherits="TestWeb.DataMasuk" %>

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
            <asp:Button ID="btn" runat="server" Text="Add" CssClass="btn" />
            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <ajaxToolkit:ModalPopupExtender runat="server" ID="mp1" PopupControlID="Panl1" TargetControlID="btn"
                BackgroundCssClass="Background" CancelControlID="btnClose">
            </ajaxToolkit:ModalPopupExtender>

            <asp:Panel ID="Panl1" runat="server" CssClass="Popup" Height="600" align="center" Style="display: none">
                <br />
                <asp:Label ID="lblHeader" runat="server" CssClass="label"></asp:Label>
                <br />
                <br />
                <table>
                    <tr>
                        <asp:Label ID="lblPKID" runat="server" Visible="false"></asp:Label>
                        <td>
                            <asp:Label ID="lblKode" Text="Kode Transaksi" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtKode" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" Text="Tanggal Transaksi" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtTanggal" runat="server"></asp:TextBox>
                            <asp:ImageButton ID="imgCal" runat="server" ImageUrl="~/Image/calendar.png" Width="30px" Height="30px" OnClick="imgCal_Click" ImageAlign="AbsBottom" />
                            <asp:Calendar ID="cld" runat="server" Height="263px" Width="283px" OnSelectionChanged="cld_SelectionChanged"></asp:Calendar>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label13" Text="Nama Barang" runat="server"></asp:Label>

                        </td>
                        <td>:</td>
                        <td>
                            <asp:DropDownList ID="cmbNamaBarang" AutoPostBack="true" runat="server" Width="190" DataTextField="NAMA_BARANG" DataValueField="KD_BARANG" OnSelectedIndexChanged="cmbNamaBarang_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" Text="Merk Barang" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtMerk" runat="server" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" Text="Jenis Barang" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtJenis" runat="server" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" Text="Type Barang" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtType" runat="server" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" Text="Ukuran Barang" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtUkuran" runat="server" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" Text="Nama Supplier" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtSupplier" runat="server" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" Text="Harga Beli" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtHargaBeli" runat="server" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label8" Text="Jumlah Barang" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtJumlah" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label9" Text="Status" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtStatus" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label10" Text="Keterangan" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtKet" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                <asp:Button ID="btnClose" runat="server" Text="Cancel" />
            </asp:Panel>

            <table>
                <tr>
                    <td>
                        <asp:GridView ID="grdBarangMasuk" RowStyle-CssClass="alt" runat="server" CssClass="grid" AutoGenerateColumns="false">
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
                                <asp:BoundField DataField="TGL_TRANSAKSI" HeaderText="Tanggal" />
                                <asp:BoundField DataField="KD_TRANSAKSI" HeaderText="Kode Transaksi" />
                                <asp:BoundField DataField="KODE_CABANG" HeaderText="Kode Cabang" />
                                <asp:BoundField DataField="KODE_BARANG" HeaderText="Kode Barang" />
                                <asp:BoundField DataField="ID" HeaderText="Nama Barang" />
                                <asp:BoundField DataField="NAMA_DISTRIBUTOR" HeaderText="Merk Barang" />
                                <asp:BoundField DataField="NAMA_BARANG" HeaderText="Nama Barang" />
                                <asp:BoundField DataField="SERI" HeaderText="Seri" />
                                <asp:BoundField DataField="ITEM" HeaderText="Item" />
                                <asp:BoundField DataField="NAMA_JENIS_BARANG" HeaderText="Jenis Barang" />
                                <asp:BoundField DataField="NAMA_TYPE_BARANG" HeaderText="Type Barang" />
                                <asp:BoundField DataField="UKURAN" HeaderText="Ukuran" />
                                <asp:BoundField DataField="NAMA_SUPPLIER" HeaderText="Nama Supplier" />
                                <asp:BoundField DataField="HARGA_JUAL_SUPPLIER" HeaderText="Harga Beli" />
                                <asp:BoundField DataField="JUMLAH_BARANG" HeaderText="Jumlah Barang" />
                                <asp:BoundField DataField="STATUS" HeaderText="Status" />
                                <asp:BoundField DataField="KETERANGAN" HeaderText="Keterangan" />
                                <asp:BoundField DataField="PKID" HeaderText="PKID" Visible="false" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
