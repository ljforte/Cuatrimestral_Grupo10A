<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="TP_Grupo10A.Producto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="./Content/styleProducto.css" rel="stylesheet" type="text/css" />

    <div class="row mb-3 text-center">
        <%--ASIDE--%>
        <aside class="col-3 themed-grid-col">
           
            <h5>Categorías</h5>
            <asp:Repeater ID="RepeaterCategorias" runat="server">
                <ItemTemplate>
                    <div class="list-group-item list-group-item-action d-flex gap-3 py-3">
                         <div class="d-flex gap-2 w-100 justify-content-between"></div>
                        <button ID="btnListarCategorias" type="button" class="list-group-item list-group-item-action btn btn-sm">
                            <a class="nav-link" href='<%# "Producto.aspx?categoria=" + Eval("Nombre") %>'>
                                <%# Eval("Nombre") %>
                            </a>
                        </button>
                    </div>
                </ItemTemplate>
            </asp:Repeater>


            <h5>Marcas</h5>
                <asp:Repeater ID="RepeaterMarcas" runat="server">
                    <ItemTemplate>
                    <div class="list-group list-group-flush">
                        <button ID="btnListarMarcas" type="button" class="list-group-item list-group-item-action btn btn-sm">
                            <a class="nav-link" href='<%# "Producto.aspx?marca=" + Eval("Nombre") %>'>
                                <%# Eval("Nombre") %>
                            </a>
                        </button>
                    </div>
                </ItemTemplate>
            </asp:Repeater>


        </aside>
    <%--MAIN--%>
        <main class="col-9 themed-grid-col">
            <div class="productos-grid">
                <asp:Repeater ID="RepeaterProductos" runat="server">
                    <ItemTemplate>
                        <div class="producto-item">
                            <asp:Repeater ID="RepeaterImagenes" runat="server" DataSource='<%# Eval("ListImagenes") %>'>
                                <ItemTemplate>
                                    <div class="carousel-ImagenUrl <%# Container.ItemIndex == 0 ? "active" : "" %>" data-bs-interval="3000">
                                        <img src='<%# Eval("ImagenURL") %>' alt="Imagen del Artículo">
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
        </main>
    </div>
    
</asp:Content>

