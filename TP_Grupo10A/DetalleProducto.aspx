<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="TP_Grupo10A.DetalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid d-flex justify-content-center align-items-center vh-100">
        <div class="card p-4 shadow-lg">
            <div class="row mb-3 text-center">
                <div class="col-md-6 themed-grid-col">
                    <div class="container">
                        <asp:Label ID="lblTitulo" runat="server" CssClass="h5" Text="Detalle de Producto"></asp:Label>
                    </div>

                    <div class="row m-3">
                        <div class="col-md-6 themed-grid-col">
                            <asp:Label ID="lblNombreLabel" runat="server" Text="Nombre:" CssClass="form-label font-weight-bold"></asp:Label>
                        </div>
                        <div class="col-md-6 themed-grid-col">
                            <asp:Label ID="lblNombre" runat="server" CssClass="form-control bg-light"></asp:Label>
                        </div>
                    </div>
                    <div class="row m-3">
                        <div class="col-md-6 themed-grid-col">
                            <asp:Label ID="lblDescripcionLabel" runat="server" Text="Descripcion:" CssClass="form-label font-weight-bold"></asp:Label>
                        </div>
                        <div class="col-md-6 themed-grid-col">
                            <asp:Label ID="lblDescripcion" runat="server" CssClass="form-control bg-light"></asp:Label>
                        </div>
                    </div>
                    <div class="row m-3">
                        <div class="col-md-6 themed-grid-col">
                            <asp:Label ID="lblMarcasLabel" runat="server" Text="Marcas:" CssClass="form-label font-weight-bold"></asp:Label>
                        </div>
                        <div class="col-md-6 themed-grid-col">
                            <asp:Label ID="lblMarcas" runat="server" CssClass="form-control bg-light"></asp:Label>
                        </div>
                    </div>
                    <div class="row m-3">
                        <div class="col-md-6 themed-grid-col">
                            <asp:Label ID="lblPrecioLabel" runat="server" Text="Precio:" CssClass="form-label font-weight-bold"></asp:Label>
                        </div>
                        <div class="col-md-6 themed-grid-col">
                            <asp:Label ID="lblPrecio" runat="server" CssClass="form-control bg-light"></asp:Label>
                        </div>
                    </div>
                    <div class="row m-3">
                        <div class="col-md-6 themed-grid-col">
                            <asp:Label ID="lblStockLabel" runat="server" Text="Stock Disponible:" CssClass="form-label font-weight-bold"></asp:Label>
                        </div>
                        <div class="col-md-6 themed-grid-col">
                            <asp:Label ID="lblStock" runat="server" CssClass="form-control bg-light"></asp:Label>
                        </div>
                    </div>
                    <div class="row mb-3 text-center">
                        <div class="col-4 themed-grid-col">
                            <asp:Label ID="lblCantidad" runat="server" Text="Cantidad: " CssClass="form-label font-weight-bold"></asp:Label>
                            <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" TextMode="Number" value="1" min="1" max="5" />
                        </div>

                        <div class="col-4 themed-grid-col">
                            <asp:Button ID="btnAgregarCarrito" runat="server" Text="Agregar Carrito" OnClick="btnAgregarCarrito_Click" CssClass="btn btn-outline-primary btn-sm" />
                        </div>
                        <div class="col-4 themed-grid-col">
                            <asp:Button ID="btnComprar" runat="server" Text="Comprar Ahora" OnClick="btnComprar_Click" CssClass="btn btn-success btn-sm" />
                        </div>
                    </div>
                </div>
                <%--Carrusel de Imagenes del Producto--%>
                <div class="col-6">
                    <div id="productCarousel" class="carousel slide" data-ride="carousel">
                        <div class="carousel-inner">
                            <asp:Repeater ID="rptImagenes"  runat="server"  >
                                <ItemTemplate>
                                    <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>" data-bs-interval="3000">
                                        <img src='<%# Eval("ImagenUrl") %>' class="d-block w-100 img-fluid rounded" alt='<%# Eval("ImagenUrl") %>'>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <a class="carousel-control-prev" href="#productCarousel" role="button" data-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="sr-only">Previous</span>
                        </a>
                        <a class="carousel-control-next" href="#productCarousel" role="button" data-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="sr-only">Next</span>
                        </a>
                    </div>
                </div>


            </div>
        </div>
    </div>
</asp:Content>
