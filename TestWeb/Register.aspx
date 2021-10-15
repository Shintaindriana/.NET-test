<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TestWeb.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Registrasi Form</h1>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label Text="Username" ID="lblUsername" runat="server"></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="valUsername" ControlToValidate="txtUsername" Display="Static"
                            ErrorMessage="Username is required!" runat="server"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Password" ID="lblPassword" runat="server"></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="valPassword" ControlToValidate="txtPassword" Display="Static"
                            ErrorMessage="Password is required!" runat="server"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Konfirmasi Password" ID="lblConfirm" runat="server"></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtKonfirm" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="valKonfirm" ControlToValidate="txtKonfirm" Display="Static"
                            ErrorMessage="Konfirmasi Password is required!" runat="server"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Email" ID="lblEmail" runat="server"></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="valEmail" ControlToValidate="txtEmail" Display="Static"
                            ErrorMessage="Email is required!" runat="server"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Gender" ID="lblGender" runat="server"></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:DropDownList ID="cmbGender" runat="server" OnSelectedIndexChanged="cmbGender_SelectedIndexChanged">
                            <asp:ListItem>
                                Female
                            </asp:ListItem>
                            <asp:ListItem>Male</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click"/>
                    </td>
                    <td></td>
                    <td>
                        <asp:Button ID="btnReset" Text="Reset" runat="server" OnClick="btnReset_Click"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="lblSignin" Text="Already have an account? Sign in" CausesValidation="false" runat="server" OnClick="lblSignin_Click"></asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body> 
</html>
