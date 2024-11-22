
<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tecnicos.aspx.cs" Inherits="Obligatorio.Tecnicos" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label>

    <h1>Tecnicos</h1>
        <style>
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
        <h2>Ingreso de Tecnicos</h2>
    </div>

         <div class="form-container" style="display: flex; flex-direction: column; align-items: normal;">
            <label>Nombre</label>
            <asp:TextBox runat="server" Placeholder="Ingrese nombre" Type="text" ID="tbNomTec"/>
             <asp:RequiredFieldValidator runat="server" controlToValidate="tbNomTec" InitialValue="" ErrorMessage="Debe agregar un nombre" ForeColor="Red" ValidationGroup="CrearTecnico"/>
            <br/>

            <label>Apellido</label>
            <asp:TextBox runat="server" Placeholder="Ingrese apellido" Type="text" ID="tbApTec"/>
              <asp:RequiredFieldValidator runat="server" controlToValidate="tbApTec" InitialValue="" ErrorMessage="Debe agregar un apellido" ForeColor="Red" ValidationGroup="CrearTecnico"/>
            <br/>

            <label>CI</label>
            <asp:TextBox runat="server" Placeholder="Ingrese CI" Type="number" ID="tbCiTec"/>
            <asp:RequiredFieldValidator runat="server" controlToValidate="tbCiTec" InitialValue="" ErrorMessage="Debe agregar un CI" ForeColor="Red" ValidationGroup="CrearTecnico"/>
            <br/>

            <label>Especialidad</label>
           <asp:TextBox runat="server" Placeholder="Ingrese especialidad" Type="text" ID="tbEspTec"/>
            <br/>

        </div>

            <div style="margin-top: 20px;">
               <asp:Button runat="server" ID="btnSaveTec" Text="Guardar" OnClick="CrearYguardarTecnico"/>
            </div>

        <h2>Lista de tecnicos</h2>
        <asp:GridView ID="tablaTecnicos" runat="server" AutoGenerateColumns="false" OnRowUpdating="RowUpdatingEvent" OnRowCancelingEdit="RowCancelingEditingEvent" OnRowEditing ="RowEditingEvent" OnRowDeleting="RowDeletingEvent" DataKeyNames="CI" CssClass="styled-gridview">
             <columns>
                 <asp:commandField showEditButton ="true" ShowDeleteButton ="true"/>
                 <asp:Boundfield Datafield="Nombre" headerText ="Nombre"/>
                 <asp:Boundfield Datafield="Apellido" headerText ="Apellido"/>
                 <asp:Boundfield Datafield="CI" headerText ="CI"/>
                 <asp:Boundfield Datafield="Especialidad" headerText ="Especialidad"/>
             </columns>
        </asp:Gridview>     

    
         


</asp:Content>




  