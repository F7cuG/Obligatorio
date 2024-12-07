<%@ Page Title="Reporte de Actividad" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteDeActividad.aspx.cs" Inherits="Obligatorio.ReporteActividad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <style>
    .styled-gridview 
    {
        width: 100%;
        border-collapse: collapse;
        margin-top: 10px;
    }

    .styled-gridview th 
    {
        background-color: #004080; 
        color: white;
        padding: 10px;
        text-align: left;
        border: 1px solid #ddd;
    }

    .styled-gridview td 
    {
        padding: 8px;
        border: 1px solid #ddd;
    }

    .styled-gridview tr:nth-child(even) 
    {
        background-color: #f2f2f2;
    }

    .styled-gridview tr:hover 
    {
        background-color: #ddd;
    }

   
    #btnFiltrar:hover 
    {
        background-color: #003366; 
        border-radius: 5px;
    }
</style>

    <h1 style="color: #004080; border-bottom: 2px solid #004080; padding-bottom: 10px;">Reporte de Actividad</h1>

    <div style="margin-bottom: 20px;">
        <h2 style="color: #004080;">Seleccionar Período</h2>
        <label for="fechaInicio">Fecha Inicio:</label>
        <asp:TextBox ID="tbFechaInicio" runat="server" TextMode="Date" style="margin-bottom: 10px; padding: 5px; border-radius: 5px; border: 1px solid #ddd;"></asp:TextBox>
        <br />
        <label for="fechaFin">Fecha Fin:</label>
        <asp:TextBox ID="tbFechaFin" runat="server" TextMode="Date" style="margin-bottom: 20px; padding: 5px; border-radius: 5px; border: 1px solid #ddd;"></asp:TextBox>
        <br />
        <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="FiltrarOrdenes" style="background-color: #004080; color: #ffffff; padding: 10px 15px; border: none; border-radius: 5px; cursor: pointer;">
        </asp:Button>
    </div>

    <div style="margin-bottom: 40px;">
        <h2 style="color: #004080;">Resumen por Técnico</h2>
        <asp:GridView ID="gvResumenTecnicos" runat="server" AutoGenerateColumns="False" CssClass="styled-gridview">
            <Columns>
                <asp:BoundField DataField="NombreTecnico" HeaderText="Técnico" SortExpression="NombreTecnico" />
                <asp:BoundField DataField="Pendientes" HeaderText="Pendiente" SortExpression="Pendientes" />
                <asp:BoundField DataField="EnProgreso" HeaderText="En Progreso" SortExpression="EnProgreso" />
                <asp:BoundField DataField="Completadas" HeaderText="Completadas" SortExpression="Completadas" />
            </Columns>
        </asp:GridView>
    </div>

    <div>
        <h2 style="color: #004080;">Órdenes Completadas</h2>
        <asp:GridView ID="gvOrdenesCompletadas" runat="server" AutoGenerateColumns="False" CssClass="styled-gridview">
            <Columns>
                <asp:BoundField DataField="NumeroOrden" HeaderText="Número de Orden" SortExpression="NumeroOrden" />
                <asp:BoundField DataField="Cliente" HeaderText="Cliente" SortExpression="Cliente" />
                <asp:BoundField DataField="Tecnico" HeaderText="Técnico" SortExpression="Tecnico" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha de Creación" SortExpression="Fecha" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
