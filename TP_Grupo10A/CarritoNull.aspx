<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CarritoNull.aspx.cs" Inherits="TP_Grupo10A.CarritoNull" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="divNoProductos" runat="server" class="text-center py-5">
        <!-- Imagen mejorada -->
        <img src="https://e7.pngegg.com/pngimages/686/914/png-clipart-sad-frog-illustration-pepe-the-frog-sadness-alt-right-meme-sad-leaf-animals-thumbnail.png"
            alt="No productos"
            width="400"
            height="400"
            class="img-fluid rounded-circle mb-4 shadow-sm" />
        <p class="fs-4 text-muted">Tu carrito está vacío, intentemos nuevamente :(</p>
        <asp:Button ID="btnProductos" runat="server"
            CssClass="btn btn-primary btn-lg px-4 py-2 shadow-sm hover-shadow"
            Text="Productos :D" OnClick="btnProductos_Click" />
    </div>
</asp:Content>
