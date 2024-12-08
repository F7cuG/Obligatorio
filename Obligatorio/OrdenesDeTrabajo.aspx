<%@Page Title="Órdenes de Trabajo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrdenesDeTrabajo.aspx.cs" Inherits="Obligatorio.OrdenesDeTrabajo"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label>
    <h1 class="titulo">Órdenes de trabajo</h1>

    <div style="margin-bottom: 20px;">
        <h2 class="subtitulo">Ingreso de órdenes</h2>
        <label>Numero de orden</label>
        <asp:TextBox runat="server" ReadOnly="true" ID="tbNumOrd" CssClass="input-field"/>
        <br />
        <label>Cliente</label>
        <asp:DropDownList ID="ddlClientes" runat="server" CssClass="input-field"></asp:DropDownList>
        <br/>
        <label>Técnico</label>
        <asp:DropDownList ID="ddlTecnicos" runat="server" CssClass="input-field"></asp:DropDownList>
        <br/>
        <label>Descripción del problema</label>
        <asp:TextBox runat="server" Placeholder="Ingrese descripción del problema" ID="tbDescOrd" CssClass="input-field"/>
        <br/>
        <label>Fecha</label>
        <asp:TextBox runat="server" ReadOnly="true" ID="tbFechaOrd" CssClass="input-field"/>
        <br/>
        <label>Estado</label>
        <asp:DropDownList ID="ddlEstado" Placeholder="Estado" runat="server" Visible="true" CssClass="input-field">
            <asp:ListItem Text="Pendiente" Value="Pendiente"></asp:ListItem>
            <asp:ListItem Text="En progreso" Value="En progreso"></asp:ListItem>
            <asp:ListItem Text="Completada" Value="Completada"></asp:ListItem>
        </asp:DropDownList>
        <br/>
        <label>Comentarios</label>
        <asp:TextBox runat="server" Placeholder="Ingrese comentarios" ID="tbComOrd" CssClass="input-field"/>
        <br/>
        <asp:Button runat="server" Text="Guardar" OnClick="CrearYguardarOrden" ValidationGroup="CrearOrden" CssClass="btn-guardar"/>
    </div>

    <h2 class="subtitulo">Lista de órdenes</h2>
    <asp:GridView ID="tablaODT" runat="server" AutoGenerateColumns="False" CssClass="styled-gridview"
                  OnRowUpdating="RowUpdatingEvent" OnRowCancelingEdit="RowCancelingEditingEvent" 
                  OnRowEditing="RowEditingEvent" OnRowDeleting="RowDeletingEvent" 
                  DataKeyNames="NumeroOrden">
        <Columns>
            <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
            <asp:BoundField DataField="NumeroOrden" HeaderText="Numero de orden" SortExpression="NumeroOrden" ReadOnly="true" />
            <asp:BoundField DataField="ClienteOrden" HeaderText="Cliente" SortExpression="ClienteOrden" ReadOnly="true" />
            <asp:BoundField DataField="TecnicoOrden" HeaderText="Técnico" SortExpression="TecnicoOrden" ReadOnly="true" />
            <asp:BoundField DataField="DescripcionProblema" HeaderText="Descripción del problema" SortExpression="DescripcionProblema" ReadOnly="true" />
            <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de creación" SortExpression="FechaCreacion" ReadOnly="true" />
            <asp:TemplateField HeaderText="Estado" SortExpression="Estado">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlEdicionEstado" runat="server"
                                      DataSource="<%#GetEstadoDataSource()%>"
                                      DataTextField="Nombre"
                                      DataValueField="Id"
                                      SelectedValue='<%#Eval("Estado")%>'
                                      CssClass="input-field">
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <%#Eval("Estado")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Comentarios del técnico">
                <ItemTemplate>
                    <%#Eval("ListaComentarios")%>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <style>
        .titulo 
        {
            color: #004080; 
            border-bottom: 2px solid #004080; 
            padding-bottom: 10px;
            margin-bottom: 20px;
            font-size: 43px; 
        }

        .subtitulo 
        {
            color: #004080; 
            font-size: 30px; 
            margin-bottom: 10px;
        }

        .input-field 
        {
            padding: 8px;
            border: 1px solid #ddd;
            border-radius: 5px;
            width: 100%;
            margin-bottom: 10px; 
        }

        .btn-guardar 
        {
            background-color: #004080; 
            color: white;
            border: none;
            padding: 10px 15px;
            border-radius: 5px;
            cursor: pointer;
        }

        .btn-guardar:hover 
        {
            background-color: #003366; 
        }

        .styled-gridview 
        {
            width: 100%;
            border-collapse: collapse;
            margin-top: 10px;
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
</asp:Content>
