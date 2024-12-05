<%@ Page Title="Reporte de Actividad" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteDeActividad.aspx.cs" Inherits="Obligatorio.ReporteActividad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Reporte de Actividad</h1>

    <div>
        <h2>Seleccionar Período</h2>
        <label for="fechaInicio">Fecha Inicio:</label>
        <asp:TextBox ID="tbFechaInicio" runat="server" TextMode="Date"></asp:TextBox>
        <br />
        <label for="fechaFin">Fecha Fin:</label>
        <asp:TextBox ID="tbFechaFin" runat="server" TextMode="Date"></asp:TextBox>
        <br />
        <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="FiltrarOrdenes" />
    </div>

    <div>
        <h2>Resumen por Técnico</h2>
        <asp:GridView ID="gvResumenTecnicos" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="NombreTecnico" HeaderText="Técnico" />
                <asp:BoundField DataField="Pendientes" HeaderText="Pendiente" />
                <asp:BoundField DataField="EnProgreso" HeaderText="En Progreso" />
                <asp:BoundField DataField="Completadas" HeaderText="Completadas" />
            </Columns>
        </asp:GridView>
    </div>

    <div>
        <h2>Órdenes Completadas</h2>
        <asp:GridView ID="gvOrdenesCompletadas" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="NumeroOrden" HeaderText="Número de Orden" />
                <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                <asp:BoundField DataField="Tecnico" HeaderText="Técnico" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha de Creación" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
