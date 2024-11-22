<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrdenesDeTrabajo.aspx.cs" Inherits="Obligatorio.OrdenesDeTrabajo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label>
    <h1>Ordenes de trabajo</h1>
    <div>
        <h2>Ingreso de ordenes</h2>
    </div>
    <div>
        <label>Numero de orden</label>
        <asp:TextBox runat="server" ID="tbNumOrd" />
        <br />
        <label>Cliente</label>
        <asp:DropDownlist ID="ddlClientes" runat="server"/>
        <br/>
        <label>Tecnico</label>
         <asp:DropDownlist ID="ddlTecnicos" runat="server"/>
        <br/>
        <label>Descripcion del problema</label>
        <asp:TextBox runat="server" Placeholder="Ingrese descripcion del problema" ID="tbDescOrd" />
         <asp:RequiredFieldValidator runat="server" controlToValidate="tbDescOrd" InitialValue="" ErrorMessage="Debe agregar una descripcion del problema" ForeColor="Red"/>
        <br/>
        <label>Fecha</label>
        <asp:TextBox runat="server" ID="tbFechaOrd"/>
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
        <asp:button runat="server" text="Guardar" OnClick="CrearYguardarOrden" />
    </div>

     <h2>Lista de ordenes</h2>
 
     <asp:GridView ID="tablaODT" runat="server" AutoGenerateColumns="false" DataKeyNames="CI" CssClass="styled-gridview">
         <Columns>
             <asp:CommandField showEditButton ="true" ShowDeleteButton="true"/>
             <asp:BoundField DataField="NumeroDeOrden" HeaderText="Numero de orden"/>
             <asp:BoundField DataField="ClienteOrden" HeaderText="Cliente"/>
             <asp:BoundField DataField="TecnicoOrden" HeaderText="Tecnico"/>
             <asp:BoundField DataField="DescripcionOrden" HeaderText="Descripcion del problema"/>
             <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de creacion"/>
             <asp:BoundField DataField="Estado" HeaderText="Estado"/>
             <asp:BoundField DataField="Comentarios" HeaderText="Comentarios del tecnico"/>
         </Columns>
     </asp:GridView>

   
</asp:Content>
