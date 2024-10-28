<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="TP_Grupo10A.Producto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <link href="./Content/styleProducto.css" rel="stylesheet" type="text/css" />
    <div class="container mt-5">
        <div class="productos-grid">
            <asp:Repeater ID="RepeaterProductos" runat="server">
                <ItemTemplate>
                    <div class="producto-item">
                            <asp:Repeater ID="RepeaterImagenes" runat="server" DataSource='<%# Eval("ListImagenes") %>'>
                                <ItemTemplate>
                                    <div class="carousel-ImagenUrl <%# Container.ItemIndex == 0 ? "active" : "" %>" data-bs-interval="3000">
                                        <img src='<%# Eval("ImagenURL") %>'  alt="Imagen del Artículo">
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                <p class="card-text"><%# Eval("Descripcion") %></p>
                                    <small class="text-muted">$<%# Eval("Precio") %></small>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div class="btn-paginacion">
                <asp:Button ID="BtnAnterior" runat="server" Text="Anterior" OnClick="BtnAnterior_Click" />
                <asp:Button ID="BtnSiguiente" runat="server" Text="Siguiente" OnClick="BtnSiguiente_Click" />
            </div>
        </div>
    </div>
</asp:Content>

