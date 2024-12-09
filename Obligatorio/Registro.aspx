<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Obligatorio.Registro" %>

<!DOCTYPE html>
<html>
<head>
    <title>Registro de Usuario</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div class="row justify-content-center">
            <div class="col-md-4">
                <h2 class="text-center">Crear una cuenta</h2>
                <asp:Panel ID="pnlRegistro" runat="server" CssClass="border p-3 shadow rounded">
                    <div class="mb-3">
                        <label for="tbNuevoUsuario" class="form-label">Usuario</label>
                        <asp:TextBox ID="tbNuevoUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="tbNuevaContraseña" class="form-label">Contraseña</label>
                        <asp:TextBox ID="tbNuevaContraseña" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="d-flex justify-content-between align-items-center">
                        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="CrearUsuario" />
                    </div>
                    <asp:Label ID="lblMensaje" runat="server" ForeColor="Green" CssClass="text-center d-block mt-3"></asp:Label>
                </asp:Panel>
            </div>
        </div>
    </form>
</body>
</html>
