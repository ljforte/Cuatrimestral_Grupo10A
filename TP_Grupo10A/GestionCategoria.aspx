<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="GestionCategoria.aspx.cs" Inherits="TP_Grupo10A.GestionCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Gestion" runat="server">
</asp:Content>
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
            <asp:Label ID="lblDato" runat="server" Text="" ></asp:Label>
        </div>
    </div>
</asp:Content>
