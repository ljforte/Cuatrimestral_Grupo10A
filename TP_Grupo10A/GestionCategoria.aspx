<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="GestionCategoria.aspx.cs" Inherits="TP_Grupo10A.GestionCategoria" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Categorias</h3>

    <div class="d-flex flex-column align-items-center" style="margin-top: 20px;">
        <div class="form-group">
            <asp:TextBox ID="txtNombre" runat="server" Placeholder="Nombre" CssClass="form-control mb-2" style="width: 300px;"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:TextBox ID="txtDescripcion" runat="server" Placeholder="Descripcion" TextMode="MultiLine" CssClass="form-control mb-2" style="width: 800px; height: 150px;"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" CssClass="btn btn-success" />
        </div>
        <div>
            <asp:Label ID="lblDato" runat="server" Cssclass="mx-2" Text="" ></asp:Label>
        </div>
    </div>
    <br />
    <div style="display: flex; justify-content: center; align-items: center;">
        <div style="width: 50%;">
            <asp:GridView ID="dgvCategoria" runat="server" CssClass="table" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="ID" DataField="CategoriaID" />

                    <asp:ButtonField HeaderText="Modificar" Text="Modificar" ControlStyle-CssClass="btn btn-light" CommandName="btnModificar" />
                    <asp:ButtonField HeaderText="Eliminar" Text="Eliminar" ControlStyle-CssClass="btn btn-danger" CommandName="btnEliminar" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
