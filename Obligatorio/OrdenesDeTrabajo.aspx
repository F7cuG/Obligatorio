<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrdenesDeTrabajo.aspx.cs" Inherits="Obligatorio.OrdenesDeTrabajo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label>
    <h1>Ordenes de trabajo</h1>
    <div>
        <h2>Ingreso de ordenes</h2>
    </div>
    <div>
        <label>Numero de orden</label>
        <asp:TextBox runat="server" ReadOnly="true" ID="tbNumOrd"/>
        <br />
        <label>Cliente</label>
        <asp:DropDownlist ID="ddlClientes" runat="server"/>
        <br/>
        <label>Tecnico</label>
         <asp:DropDownlist ID="ddlTecnicos" runat="server"/>
        <br/>
        <label>Descripcion del problema</label>
        <asp:TextBox runat="server" Placeholder="Ingrese descripcion del problema" ID="tbDescOrd" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbDescOrd" ErrorMessage="Debe agregar una descripción del problema" ForeColor="Red" ValidationGroup="CrearOrden"/>
        <br/>
        <label>Fecha</label>
        <asp:TextBox runat="server" ReadOnly="true" ID="tbFechaOrd"/>

        <br/>
        <label>Estado</label>
        <asp:DropDownList ID="ddlEstado" Placeholder="Estado" runat="server" Visible="true">
            <asp:ListItem Text="Pendiente" Value="2"></asp:ListItem>
            <asp:ListItem Text="En progreso" Value="3"></asp:ListItem>
            <asp:ListItem Text="Completada" Value="4"></asp:ListItem>
        </asp:DropDownList>
        <br/>
        <label>Comentarios</label>
        <asp:TextBox runat="server" Placeholder="Ingrese comentarios" ID="tbComOrd" />
        <br/>
    </div>

    <div>
        <asp:Button runat="server" Text="Guardar" OnClick="CrearYguardarOrden" ValidationGroup="CrearOrden"/>
    </div>
    <div>
        <asp:Button runat="server" Text="Mostrar Comentarios" OnClick="MostrarComentarios"/>
        <asp:Button runat="server" Text="Agregar Comentario" OnClick="AgregarComentario"/>

    </div>


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

    </div>
</div>


     <h2>Lista de ordenes</h2>
 
   <asp:GridView ID="tablaODT" runat="server" AutoGenerateColumns="False" OnRowUpdating="RowUpdatingEvent" OnRowCancelingEdit="RowCancelingEditingEvent" OnRowEditing ="RowEditingEvent" OnRowDeleting="RowDeletingEvent" DataKeyNames="NumeroOrden">
         <Columns>
             <asp:CommandField showEditButton ="true" ShowDeleteButton="true"/>
             <asp:BoundField DataField="NumeroOrden" HeaderText="Numero de orden"/>
             <asp:BoundField DataField="ClienteOrden.nombre" HeaderText="Cliente"/>
             <asp:BoundField DataField="TecnicoOrden.nombre" HeaderText="Tecnico"/>
             <asp:BoundField DataField="DescripcionProblema" HeaderText="Descripcion del problema"/>
             <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de creacion"/>
             <asp:BoundField DataField="Estado" HeaderText="Estado"/>
             <asp:BoundField DataField="ListaComentarios" HeaderText="Comentarios del tecnico"/>
         </Columns>
     </asp:GridView>

   
</asp:Content>
