<%@ Page Title="" Language="C#" MasterPageFile="~/TestMaster.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="JenisBarang.aspx.cs" Inherits="TestWeb.test1" %>

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

        .label{
            font-weight:bold;
            font-size:x-large;
        }

        .btn {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctContent" runat="server">
    <asp:UpdatePanel ID="Update1" runat="server">
        <ContentTemplate>
            <br />
            <br />
            <br />
            <asp:Button ID="btn" runat="server" Text="Add" CssClass="btn"/>
            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click"/>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <ajaxToolkit:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="btn"
               BackgroundCssClass="Background" CancelControlID="btnClose">
            </ajaxToolkit:ModalPopupExtender>

            <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" Style="display: none">
                <%--<iframe style="width: 350px; height: 300px;" id="irm1" src="Home.aspx" runat="server"></iframe>--%>
                <br />
                <asp:Label ID="lblHeader" runat="server" CssClass="label" ></asp:Label>
                <br />
                <br />
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblKode" Text="Kode Jenis" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtKode" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" Text="Nama Jenis Barang" runat="server"></asp:Label>
                        </td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtNama" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>

                <asp:Button ID="btn2" runat="server" Text="Save" OnClick="btn2_Click" />
                <asp:Button ID="btnClose" runat="server" Text="Cancel" />            
            </asp:Panel>
            
            <table>
                <tr>
                    <td>

                        <%--<asp:Image ImageUrl="~/Image/edit1.png" runat="server" ID="imgEdit1" />--%>
                        <asp:GridView ID="grdJenis" RowStyle-CssClass="alt" runat="server" CssClass="grid" OnRowEditing="grdJenis_RowEditing" OnDataBinding="grdJenis_DataBinding" OnRowCommand="grdJenis_RowCommand" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:ImageButton ImageUrl="~/Image/edit1.png" runat="server" ID="imgEdit" OnClick="imgEdit_Click1" Width="30px" Height="30px" />
                                        <%--<asp:Button ID="btnPo" runat="server" Text="submit" OnClick="btnPo_Click" />--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:ImageButton ImageUrl="~/Image/cross.png" runat="server" ID="imgDelete" OnClick="imgDelete_Click" Width="30px" Height="30px" />
                                        <%--<asp:Button ID="btnPo" runat="server" Text="submit" OnClick="btnPo_Click" />--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="KODE_JENIS" HeaderText="Kode Jenis" />
                                <asp:BoundField DataField="NAMA_JENIS_BARANG" HeaderText="Nama Jenis Barang" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>


            <br />
            <br />

            <asp:Button Text="submit" ID="btnsubmit" runat="server" OnClientClick="return ShowPopup();return false;" />

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
