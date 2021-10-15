<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TestWeb.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Home</h1>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="grdJenis" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="KODE_JENIS" HeaderText="Kode Jenis" />
                                <asp:BoundField DataField="NAMA_JENIS_BARANG" HeaderText="Nama Jenis Barang" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
