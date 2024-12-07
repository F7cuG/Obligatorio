<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tecnicos.aspx.cs" Inherits="Obligatorio.Tecnicos" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label>

    <h1 class="titulo">Técnicos</h1>

    <style>

        body 
        {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            line-height: 1.6;
            margin: 20px;
        }

        .titulo 
        {
            color: #004080; 
            border-bottom: 2px solid #004080;
            font-size: 43px; 
            margin-bottom: 10px; 
        }

        h2 
        {
            color: #004080; 
            font-size: 30px; 
            margin-bottom: 10px;
        }

        .form-container 
        {
            display: flex;
            flex-direction: column;
            gap: 10px;
            margin-bottom: 20px;
        }

        label 
        {
            font-weight: bold;
        }

        .input-field 
        {
            padding: 8px;
            border: 1px solid #ddd;
            border-radius: 5px;
            width: 100%;
        }

        .btn-guardar 
        {
            background-color: #004080; 
            color: white;
            border: none;
            padding: 10px 15px;
            border-radius: 5px;
            cursor: pointer;
            margin-top: 10px;
        }

        .btn-guardar:hover 
        {
            background-color: #003366; 
        }

        .styled-gridview 
        {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
            border-radius: 8px; 
            overflow: hidden;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
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
    </style>

    <div>
        <h2>Ingreso de Técnicos</h2>
    </div>

    <div class="form-container">
        <label>Nombre</label>
        <asp:TextBox runat="server" Placeholder="Ingrese nombre" Type="text" ID="tbNomTec" CssClass="input-field"/>
        <asp:RequiredFieldValidator runat="server" controlToValidate="tbNomTec" InitialValue="" ErrorMessage="Debe agregar un nombre" ForeColor="Red" ValidationGroup="CrearTecnico"/>

        <label>Apellido</label>
        <asp:TextBox runat="server" Placeholder="Ingrese apellido" Type="text" ID="tbApTec" CssClass="input-field"/>
        <asp:RequiredFieldValidator runat="server" controlToValidate="tbApTec" InitialValue="" ErrorMessage="Debe agregar un apellido" ForeColor="Red" ValidationGroup="CrearTecnico"/>

        <label>CI</label>
        <asp:TextBox runat="server" Placeholder="Ingrese CI" Type="number" ID="tbCiTec" CssClass="input-field"/>
        <asp:RequiredFieldValidator runat="server" controlToValidate="tbCiTec" InitialValue="" ErrorMessage="Debe agregar un CI" ForeColor="Red" ValidationGroup="CrearTecnico"/>

        <label>Especialidad</label>
        <asp:TextBox runat="server" Placeholder="Ingrese especialidad" Type="text" ID="tbEspTec" CssClass="input-field"/>
    </div>

    <div style="margin-top: 20px;">
        <asp:Button runat="server" ID="btnSaveTec" Text="Guardar" OnClick="CrearYguardarTecnico" CssClass="btn-guardar"/>
    </div>

    <h2>Lista de Técnicos</h2>
    <asp:GridView ID="tablaTecnicos" runat="server" AutoGenerateColumns="false" OnRowUpdating="RowUpdatingEvent" OnRowCancelingEdit="RowCancelingEditingEvent" OnRowEditing="RowEditingEvent" OnRowDeleting="RowDeletingEvent" DataKeyNames="CI" CssClass="styled-gridview">
        <Columns>
            <asp:CommandField ShowEditButton="true" ShowDeleteButton="true"/>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre"/>
            <asp:BoundField DataField="Apellido" HeaderText="Apellido"/>
            <asp:BoundField DataField="CI" HeaderText="CI"/>
            <asp:BoundField DataField="Especialidad" HeaderText="Especialidad"/>
        </Columns>
    </asp:GridView>
</asp:Content>


