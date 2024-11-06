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
                        <button id="btnListarCategorias" type="button" class="list-group-item list-group-item-action btn btn-sm">
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
                        <button id="btnListarMarcas" type="button" class="list-group-item list-group-item-action btn btn-sm">
                            <a class="nav-link" href='<%# "Producto.aspx?marca=" + Eval("Nombre") %>'>
                                <%# Eval("Nombre") %>
                            </a>
                        </button>
                    </div>
                </ItemTemplate>
            </asp:Repeater>


        </aside>
        <%--MAIN--%>
        <main class="col-9 themed-grid-col text-center">
            <div class="productos-grid  text-body-secondary">
                <asp:Repeater ID="RepeaterProductos" runat="server">
                    <ItemTemplate>
                        <div class="producto-item">
                            <div class="card-header py-3">
                                <h4 class="my-0 fw-normal"><%# Eval("Nombre") %></h4>
                            </div>
                            <div class="card-body p-3"  min-height: "700px">
                                <h4 class="card-title"> $ <%# Eval("Precio") %></h4>
                                <h5 class="card-text"><%# Eval("Descripcion") %></h5>
                            </div>
                            <%--Carousel https://getbootstrap.com/docs/5.3/components/carousel/#how-it-works--%>
                            <div class="image-container">
                                <div id="carousel<%# Container.ItemIndex %>" class="carousel slide" data-bs-ride="carousel">
                                    <div class="carousel-inner">
                                        <asp:Repeater ID="RepeaterImagenes" runat="server" DataSource='<%# Eval("ListImagenes") %>'>
                                            <ItemTemplate>
                                                <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>" data-bs-interval="3000">
                                                    <img src='<%# Eval("ImagenURL") %>' alt="Imagen del Artículo" width="200" height="200" class="mx-auto">
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleRide" data-bs-slide="prev">
                                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                        <span class="visually-hidden">Previous</span>
                                    </button>
                                    <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleRide" data-bs-slide="next">
                                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                        <span class="visually-hidden">Next</span>
                                    </button>
                                </div>
                            </div>
                            <div class="card-footer ">
                                <asp:Button ID="btnVerDetalle" runat="server" Text="Ver Detalle" CssClass="btn btn-primary" OnClick="btnVerDetalle_Click" />
                                <asp:Button ID="btnAgregar" runat="server" Text="Comprar" CssClass="btn btn-success" OnClick="btnAgregar_Click" />
                            </div>

                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
            <div class="btn-paginacion">
                <asp:Button ID="BtnAnterior" runat="server" Text="Anterior" OnClick="BtnAnterior_Click" CssClass="btn btn-secondary" />
                <asp:Button ID="BtnSiguiente" runat="server" Text="Siguiente" OnClick="BtnSiguiente_Click" CssClass="btn btn-secondary" />
            </div>

        </main>
        <%--  
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
        </main>--%>
    </div>

</asp:Content>

