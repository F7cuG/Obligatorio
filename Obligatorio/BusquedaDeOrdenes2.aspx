<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BusquedaDeOrdenes2.aspx.cs" Inherits="Obligatorio.BusquedaDeOrdenes2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <h2>Búsqueda de órdenes</h2>
    <div>
        <label>Número de orden:</label>
        <asp:TextBox ID="tbBuscarNumOrd" runat="server" Placeholder="Ingrese número de orden"/>
        <asp:Button runat="server" Text="Buscar" OnClick="BuscarOrden" ValidationGroup="BusquedaOrdenes"/>

    </div>
    <br />

    <div>
        <asp:Label ID="lblResultadoBusqueda" runat="server" ForeColor="Blue"></asp:Label>
        <div id="detalleOrden" runat="server" visible="false">
            <h3>Detalles de la orden:</h3>
            <p><strong>Estado:</strong> <asp:Label ID="lblEstado" runat="server"/></p>
            <p><strong>Cliente:</strong> <asp:Label ID="lblCliente" runat="server"/></p>
            <p><strong>Técnico:</strong> <asp:Label ID="lblTecnico" runat="server"/></p>
            <p><strong>Descripción del problema:</strong> <asp:Label ID="lblDescripcion" runat="server"/></p>
            <p><strong>Fecha de creación:</strong> <asp:Label ID="lblFecha" runat="server"/></p>
            <p><strong>Comentarios:</strong> <asp:Label ID="lblComentarios" runat="server"/></p>
            
            
            <asp:textbox runat="server" ID="tbComentario"/>
            <asp:Label ID="lblErrorComentario" runat="server" ForeColor="Blue"></asp:Label>
            <asp:button runat="server" ID="btnComentario" OnClick="AgregarComentario"/>

        </div>
    </div>
</asp:Content>
