<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="GestionProductos.aspx.cs" Inherits="TP_Grupo10A.GestionProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Gestion" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-grid gap-2 col-6 mx-auto">
        <a href="AltaProducto.aspx" class="btn btn-primary" role="button">Cargar Producto</a>
        <div class="input-group mb-3">
            <asp:TextBox ID="TxtNombre" runat="server" CssClass="form-control" placeholder="Buscar por nombre (Aun no me desarrollaron)" />
            <asp:Button ID="BtnBuscar" runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="BtnBuscar_Click" />
        </div>
        <asp:GridView ID="dgvListarProductosSP" runat="server" CssClass="table" DataKeyNames="ProductoID"
            OnSelectedIndexChanged="dgvProductos_SelectedIndexChanged"
            OnPageIndexChanging="dgvProductos_PageIndexChanging"
            AllowPaging="true" PageSize="10" AutoGenerateColumns="false"
            Columns="true">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Categoria" DataField="CategoriaID.Nombre" />
                <asp:BoundField HeaderText="Marca" DataField="MarcaID.Nombre" />
                <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="{0:C}" />
                <asp:BoundField HeaderText="Stock" DataField="Stock" />
                <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="Editar" />
                <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="Eliminar" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
