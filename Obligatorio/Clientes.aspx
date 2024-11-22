<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="Obligatorio.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label>
    
    <h1>Clientes</h1>

    <style>
        /*CSS del gridview*/
        .styled-gridview {
            width: 100%;
            border-collapse: collapse;
        }

        .styled-gridview th {
            background-color: #4CAF50;
            color: white;
            padding: 10px;
            text-align: left;
            border: 1px solid #ddd;
        }

        .styled-gridview td {
            padding: 8px;
            border: 1px solid #ddd;
        }

        .styled-gridview tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        .styled-gridview tr:hover {
            background-color: #ddd;
        }
    </style>

    <div>
        <h2>Ingreso de Clientes</h2>
    </div>

    <div class="form-container" style="display: flex; flex-direction: column; align-items: normal;">
        <label>Nombre</label>
        <asp:TextBox runat="server" Placeholder="Ingrese nombre" Type="text" ID="tbNomCli"/>
        <asp:RequiredFieldValidator runat="server" controlToValidate="tbNomCli" InitialValue="" ErrorMessage="Debe agregar un nombre" ForeColor="Red" ValidationGroup="CrearCliente"/>
        <br/>

        <label>Apellido</label>
        <asp:TextBox runat="server" Placeholder="Ingrese apellido" Type="text" ID="tbApCli"/>
        <asp:RequiredFieldValidator runat="server" controlToValidate="tbApCli" InitialValue="" ErrorMessage="Debe agregar un apellido" ForeColor="Red" ValidationGroup="CrearCliente"/>
        <br/>

        <label>CI</label>
        <asp:TextBox runat="server" Placeholder="Ingrese CI" Type="number" ID="tbCiCli"/>
        <asp:RequiredFieldValidator runat="server" controlToValidate="tbCiCli" InitialValue="" ErrorMessage="Debe agregar un CI" ForeColor="Red" ValidationGroup="CrearCliente"/>
        <br/>

        <label>Direccion</label>
        <asp:TextBox runat="server" Placeholder="Ingrese direccion" Type="text" ID="tbDirCli"/>
        <br/>

        <label>Telefono</label>
        <asp:TextBox runat="server" Placeholder="Ingrese numero de telefono" Type="text" ID="tbTelCli"/>
        <br/>

        <label>Email</label>
        <asp:TextBox runat="server" Placeholder="Ingrese email" Type="text" ID="tbEmailCli"/>
        
        <h2>Lista de clientes</h2>
        
            <asp:GridView ID="tablaClientes" runat="server" AutoGenerateColumns="false" OnRowUpdating="RowUpdatingEvent" OnRowCancelingEdit="RowCancelingEditingEvent" OnRowEditing ="RowEditingEvent" OnRowDeleting="RowDeletingEvent" DataKeyNames="CI" CssClass="styled-gridview">
                <Columns>
                    <asp:CommandField showEditButton ="true" ShowDeleteButton="true"/>
                    <asp:BoundField DataField="CI" HeaderText="CI"/>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre"/>
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido"/>
                    <asp:BoundField DataField="Direccion" HeaderText="Dirección"/>
                    <asp:BoundField DataField="Telefono" HeaderText="Teléfono"/>
                    <asp:BoundField DataField="Email" HeaderText="Email"/>
                </Columns>
            </asp:GridView>
    </div>

    <div style="margin-top: 20px;">
        <asp:Button runat="server" ID="btnSaveCli" Text="Guardar" OnClick="CrearYguardarCliente"/>
    </div>
</asp:Content>


