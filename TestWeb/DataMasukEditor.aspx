<%@ Page Title="" Language="C#" MasterPageFile="~/TestMaster.Master" AutoEventWireup="true" CodeBehind="DataMasukEditor.aspx.cs" Inherits="TestWeb.DataMasukEditor" %>

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

            <table>
                <br />
                <br />
                <br />
                <%--<tr>
                    <td>
                        <asp:Label ID="Label1" Text="Tanggal Transaksi" runat="server"></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtTanggal" runat="server"></asp:TextBox>
                        <asp:ImageButton ID="imgCal" runat="server" ImageUrl="~/Image/calendar.png" Width="30px" Height="30px" OnClick="imgCal_Click" ImageAlign="AbsBottom" />
                        <asp:Calendar ID="cld" runat="server" Height="263px" Width="283px" OnSelectionChanged="cld_SelectionChanged"></asp:Calendar>
                    </td>
                </tr>--%>
                <tr>
                    <td>
                        <asp:Label ID="Label5" Text="Kode Transaksi" runat="server"></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtKode" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label13" Text="Kode Cabang" runat="server"></asp:Label>

                    </td>
                    <td>:</td>
                    <td>
                        <asp:DropDownList ID="cmbKodeCabang" runat="server" Width="190" DataTextField="KODE_CABANG" DataValueField="KODE_CABANG"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" Text="Kode Supplier" runat="server"></asp:Label>

                    </td>
                    <td>:</td>
                    <td>
                        <asp:DropDownList ID="cmbKodeSupplier" runat="server" Width="190" DataTextField="KODE_SUPPLIER" DataValueField="KODE_SUPPLIER"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" Text="Keterangan" runat="server"></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="Keterangan" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btn" runat="server" Text="Add" CssClass="btn" />
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <ajaxToolkit:ModalPopupExtender runat="server" ID="mp1" PopupControlID="Panl1" TargetControlID="btn"
                            BackgroundCssClass="Background" CancelControlID="btnClose">
                        </ajaxToolkit:ModalPopupExtender>
                        <asp:Panel ID="Panl1" runat="server" CssClass="Popup" Height="600" align="center" Style="display: none">
                            <br />
                            <br />
                            <br />
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" Text="Data Barang" runat="server"></asp:Label>

                                    </td>
                                    <td>:</td>
                                    <td>
                                        <asp:DropDownList ID="cmbDataBarang" runat="server" Width="190" DataTextField="KODE_BARANG" DataValueField="KODE_BARANG" OnSelectedIndexChanged="cmbDataBarang_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                        <asp:GridView ID="grdBarang" Visible="true" RowStyle-CssClass="alt" runat="server" CssClass="grid" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:ImageButton ImageUrl="~/Image/cross.png" runat="server" ID="imgDelete" Width="30px" Height="30px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ID" HeaderText="ID" />
                                <asp:BoundField DataField="Merk Barang" HeaderText="NAMA_DISTRIBUTOR" />
                                <asp:BoundField DataField="NAMA_BARANG" HeaderText="Nama Barang" />
                                <asp:BoundField DataField="SERI" HeaderText="Seri" />
                                <asp:BoundField DataField="UKURAN" HeaderText="Ukuran" />
                                <asp:BoundField DataField="JUMLAH_BARANG" HeaderText="Jumlah Barang" />
                                <asp:BoundField DataField="HARGA_JUAL_SUPPLIER" HeaderText="Harga Beli" />
                                <asp:BoundField DataField="STATUS" HeaderText="Status" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
