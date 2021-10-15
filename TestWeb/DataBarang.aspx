<%@ Page Title="" Language="C#" MasterPageFile="~/TestMaster.Master" AutoEventWireup="true" CodeBehind="DataBarang.aspx.cs" Inherits="TestWeb.DataBarang" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="GridView.css" />
    <link href="http://code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.min.css"
        rel="stylesheet" type="text/css" />
    <script src="http://code.jquery.com/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script src="http://code.jquery.com/ui/1.10.4/jquery-ui.min.js" type="text/javascript"></script>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <link href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
    
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
                        <td>
                            <asp:Label ID="lblKode" Text="Kode Barang" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtKode" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" Text="ID" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" Text="Merk Barang" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:DropDownList ID="cmbMerk" runat="server" Width="190" DataTextField="NAMA_DISTRIBUTOR" DataValueField="KODE_MERK"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" Text="Nama Barang" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtNama" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" Text="Seri" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtSeri" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" Text="Jenis Barang" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:DropDownList ID="cmbJenis" runat="server" Width="190" DataTextField="NAMA_JENIS_BARANG" DataValueField="KODE_JENIS"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" Text="Type Barang" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:DropDownList ID="cmbType" runat="server" Width="190" DataTextField="NAMA_TYPE_BARANG" DataValueField="KODE_TYPE"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" Text="Ukuran Barang" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:DropDownList ID="cmbUkuran" runat="server" Width="190" DataTextField="UKURAN" DataValueField="KODE_UKURAN"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label8" Text="Kode Supplier" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:DropDownList ID="cmbSup" runat="server" Width="190" DataTextField="KODE_SUPPLIER" DataValueField="KODE_SUPPLIER"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label9" Text="Harga Supplier" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtHargaSup" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label10" Text="Harga Jual TCG" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtHargaJu" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label13" Text="Harga Jual Supplier" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtJualSup" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label11" Text="Stok Barang" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtStok" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label12" Text="Catatan" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtCat" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                <asp:Button ID="btnClose" runat="server" Text="Cancel" />
            </asp:Panel>

            <table>
                <tr>
                    <td>
                        <asp:GridView ID="grdBarang" RowStyle-CssClass="alt" runat="server" CssClass="grid" AutoGenerateColumns="false">
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
                                
                                <asp:BoundField DataField="KD_BARANG" HeaderText="Kode Barang" />
                                <asp:BoundField DataField="ID" HeaderText="ID" />
                                <asp:BoundField DataField="NAMA_DISTRIBUTOR" HeaderText="Merk Barang" />
                                <asp:BoundField DataField="NAMA_BARANG" HeaderText="Nama Barang" />
                                <asp:BoundField DataField="SERI" HeaderText="Seri" />
                                <asp:BoundField DataField="NAMA_JENIS_BARANG" HeaderText="Jenis Barang" />
                                <asp:BoundField DataField="NAMA_TYPE_BARANG" HeaderText="Type Barang" />
                                <asp:BoundField DataField="UKURAN" HeaderText="Ukuran" />
                                <asp:BoundField DataField="KODE_SUPPLIER" HeaderText="Kode Supplier" />
                                <asp:BoundField DataField="HARGA_SUPPLIER" HeaderText="Harga Supplier" />
                                <asp:BoundField DataField="HARGA_JUAL_TCG" HeaderText="Harga Jual" />
                                <asp:BoundField DataField="STOK_BARANG" HeaderText="Stok Barang" />
                                <asp:BoundField DataField="KETERANGAN" HeaderText="Catatan" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
