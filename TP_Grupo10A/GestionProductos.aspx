<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="GestionProductos.aspx.cs" Inherits="TP_Grupo10A.GestionProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Gestion" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-grid gap-2 col-6 mx-auto">
        <a href="AltaProducto.aspx" class="btn btn-primary" role="button">Cargar Producto</a>
        <button class="btn btn-primary" type="button">Modificar Producto</button>
    </div>
</asp:Content>
