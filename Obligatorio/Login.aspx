<%@ Page Title="Login" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Obligatorio.Login" MasterPageFile="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row justify-content-center">
        <div class="col-md-4">
            <h2 class="text-center">Inicio de Sesión</h2>
            <asp:Panel ID="pnlLogin" runat="server" CssClass="border p-3 shadow rounded">
                <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" CssClass="text-center d-block mb-2"></asp:Label>
                <div class="mb-3">
                    <label for="tbUsuario" class="form-label">Usuario</label>
                    <asp:TextBox ID="tbUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="tbContraseña" class="form-label">Contraseña</label>
                    <asp:TextBox ID="tbContraseña" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </div>
                <div class="d-flex justify-content-between align-items-center">
                    <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" CssClass="btn btn-primary" OnClick="Loguear" />
                    <a href="Registro.aspx" class="btn btn-link">¿No tienes una cuenta? Regístrate</a>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
