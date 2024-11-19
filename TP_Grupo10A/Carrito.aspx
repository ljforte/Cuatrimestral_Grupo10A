<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TP_Grupo10A.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="lblMensaje" runat="server" CssClass="alert alert-info"></asp:Label>

    <!--  Carrito -->
    <div class="accordion" id="accordionCarrito">
        <div class="accordion-item">
            <h2 class="accordion-header" id="headingCarrito">
                <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseCarrito" aria-expanded="true" aria-controls="collapseCarrito">
                    Carrito
                </button>
            </h2>
            <div id="collapseCarrito" class="accordion-collapse collapse show" aria-labelledby="headingCarrito" data-bs-parent="#accordionCarrito">
                <div class="accordion-body">
                    <asp:Repeater ID="rptCarrito" runat="server">
                        <ItemTemplate>
                            <div class="card mb-3">
                                <div class="row g-0">
                                    <div class="col-md-4">
                                        <img src='<%# Eval("Producto.ListImagenes.Count > 0 ? Producto.ListImagenes[0].URL : \"/Imagenes/ImagenNoEncontrada.jpeg\"") %>' class="img-fluid rounded-start" alt="Producto">
                                    </div>
                                    <div class="col-md-8">
                                        <div class="card-body">
                                            <h5 class="card-title"><%# Eval("Producto.Nombre") %></h5>
                                            <p class="card-text"><%# Eval("Producto.Descripcion") %></p>
                                            <p class="card-text">
                                                Cantidad: 
                                                <button class="btn btn-sm btn-outline-secondary" onclick='<%# "AjustarCantidad(" + Eval("Producto.ProductoID") + ", 1)" %>'>+</button>
                                                <span><%# Eval("Cantidad") %></span>
                                                <button class="btn btn-sm btn-outline-secondary" onclick='<%# "AjustarCantidad(" + Eval("Producto.ProductoID") + ", -1)" %>'>-</button><br />
                                                Precio Unitario: $<%# Eval("PrecioUnitario") %><br />
                                                Subtotal: $<%# Convert.ToInt32(Eval("Cantidad")) * Convert.ToSingle(Eval("PrecioUnitario")) %>
                        </p>
                       <button class="btn btn-danger btn-sm" OnCommand="EliminarProducto" CommandArgument='<%# Eval("CarritoDetalleID") %>'>Eliminar</button>
                    </div>
                                    </div>
                                </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <button class="btn btn-primary" onclick="ConfirmarCarrito">Confirmar</button>
                </div>
            </div>
        </div>

        <!--  Entrega -->
        <div class="accordion-item">
            <h2 class="accordion-header" id="headingEntrega">
                <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseEntrega" aria-expanded="false" aria-controls="collapseEntrega">
                    Entrega
                </button>
            </h2>
            <div id="collapseEntrega" class="accordion-collapse collapse" aria-labelledby="headingEntrega" data-bs-parent="#accordionCarrito">
                <div class="accordion-body">
                    <!-- Falta completar pero aca va todo lo referido a la entrega -->
                    <p>Formulario de Entrega</p>
                    <button class="btn btn-primary" OnClick="ConfirmarEntrega">Confirmar</button>
                </div>
            </div>
        </div>

        <!-- Pago -->
        <div class="accordion-item">
            <h2 class="accordion-header" id="headingPago">
                <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapsePago" aria-expanded="false" aria-controls="collapsePago">
                    Pago
                </button>
            </h2>
            <div id="collapsePago" class="accordion-collapse collapse" aria-labelledby="headingPago" data-bs-parent="#accordionCarrito">
                <div class="accordion-body">
                    <!-- completar codigo pago-->
                    <p>Formulario de Pago</p>
                    <button class="btn btn-primary" OnClick="ConfirmarPago">Confirmar</button>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
