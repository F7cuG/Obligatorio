<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Obligatorio.Login" %>

<!DOCTYPE html>
<html>
<head>
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Inicio de Sesión</h2>
            <label for="tbUsuario">Usuario:</label>
            <asp:TextBox ID="tbUsuario" runat="server"></asp:TextBox><br />
            <label for="tbContraseña">Contraseña:</label>
            <asp:TextBox ID="tbContraseña" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" OnClick="btnLogin_Click" /><br />
            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
