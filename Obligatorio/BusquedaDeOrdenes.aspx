<%@ Page Title="Búsqueda de Órdenes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BusquedaDeOrdenes.aspx.cs" Inherits="Obligatorio.BusquedaDeOrdenes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="color: #004080; border-bottom: 2px solid #004080; padding-bottom: 10px;">Búsqueda de órdenes</h1>

    <div style="margin-bottom: 20px;">
        <h2 style="color: #004080;">Buscar orden por número</h2>
        <label>Número de orden</label>
        <asp:TextBox runat="server" ID="tbBuscarNumOrd" Placeholder="Ingrese número de orden" style="margin-bottom: 10px; padding: 5px; border-radius: 5px; border: 1px solid #ddd;" />
        <br />
        <asp:Button runat="server" Text="Buscar" OnClick="BuscarOrden" ValidationGroup="BusquedaOrdenes" style="background-color: #004080; color: #ffffff; padding: 10px 15px; border: none; border-radius: 5px; cursor: pointer;" />
    </div>

    <div style="margin-top: 20px;" id="resultadoBusqueda">
        <h2 style="color: #004080;">Resultado de la búsqueda</h2>
        <asp:Label ID="lblResultadoBusqueda" runat="server" style="display: block; font-size: 16px; font-weight: bold; margin-bottom: 10px;"></asp:Label>
        <div id="detalleOrden" runat="server" style="background-color: #f9f9f9; padding: 15px; border-radius: 5px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); display: none;">
            <h3 style="color: #004080;">Detalles de la orden</h3>
            <p><strong>Estado:</strong> <asp:Label ID="lblEstado" runat="server" style="display: block; margin-bottom: 8px;"></asp:Label></p>
            <p><strong>Cliente:</strong> <asp:Label ID="lblCliente" runat="server" style="display: block; margin-bottom: 8px;"></asp:Label></p>
            <p><strong>Técnico:</strong> <asp:Label ID="lblTecnico" runat="server" style="display: block; margin-bottom: 8px;"></asp:Label></p>
            <p><strong>Descripción del problema:</strong> <asp:Label ID="lblDescripcion" runat="server" style="display: block; margin-bottom: 8px;"></asp:Label></p>
            <p><strong>Fecha de creación:</strong> <asp:Label ID="lblFecha" runat="server" style="display: block; margin-bottom: 8px;"></asp:Label></p>
            <p><strong>Comentarios:</strong> <asp:Label ID="lblComentarios" runat="server" style="display: block; margin-bottom: 8px;"></asp:Label></p>
            
            <div style="margin-top: 15px;">
                <label>Agregar comentario</label>
                <asp:TextBox runat="server" ID="tbComentario" Placeholder="Ingrese su comentario aquí" style="width: 100%; padding: 5px; border: 1px solid #ddd; border-radius: 5px; margin-bottom: 10px;"></asp:TextBox>
                <asp:Label ID="lblErrorComentario" runat="server" style="display: block; color: red; font-size: 14px; margin-bottom: 10px;"></asp:Label>
                <asp:Button runat="server" ID="btnAgregarComentario" Text="Agregar Comentario" OnClick="AgregarComentario" style="background-color: #28a745; color: #ffffff; padding: 10px 15px; border: none; border-radius: 5px; cursor: pointer;" />
            </div>
        </div>
    </div>
</asp:Content>
