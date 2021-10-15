<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TestWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Login</h1>
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
                        <asp:Button Text="Login" runat="server" ID="btnLogin" OnClick="btnLogin_Click"/>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
