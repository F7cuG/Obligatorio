<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Obligatorio.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="border-bottom: 2px solid #004080; padding-bottom: 10px;">Resumen de Órdenes de Trabajo</h1>
    <div>
        <p><strong>Pendientes:</strong> <asp:Label ID="lblPendiente" runat="server"/></p>
        <p><strong>En Progreso:</strong> <asp:Label ID="lblEnProgreso" runat="server"/></p>
        <p><strong>Completadas:</strong> <asp:Label ID="lblCompletada" runat="server"/></p>
    </div>
</asp:Content>
