<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Obligatorio.Registro" %>

<!DOCTYPE html>
<html>
<head>
    <title>Registro de Usuario</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Crear una cuenta</h2>
            <label for="tbNuevoUsuario">Usuario:</label>
            <asp:TextBox ID="tbNuevoUsuario" runat="server"></asp:TextBox><br/>
            <label for="tbNuevaContraseña">Contraseña:</label>
            <asp:TextBox ID="tbNuevaContraseña" runat="server" TextMode="Password"></asp:TextBox><br/>
            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="CrearUsuario"/><br/>
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label>
        </div>
    </form>
</body>
</html>
