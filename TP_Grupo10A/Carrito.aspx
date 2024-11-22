<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TP_Grupo10A.Carrito" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
    <asp:Label ID="lblMensaje" runat="server" CssClass="alert alert-info"></asp:Label>

    <!--  Carrito -->
    <div class="accordion" id="accordionCarrito" runat="server">
        <div class="accordion-item">
            <h2 class="accordion-header" id="headingCarrito">
                <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseCarrito" aria-expanded="true" aria-controls="collapseCarrito">
                    Carrito
                </button>
            </h2>
            <div id="collapseCarrito" class="accordion-collapse collapse show" aria-labelledby="headingCarrito" data-bs-parent="#accordionCarrito" runat="server">
                <div class="accordion-body">
                    <asp:Repeater ID="rptCarrito" runat="server">
                        <ItemTemplate>
                            <asp:HiddenField ID="hfCarritoDetalleID" runat="server" Value='<%# Eval("CarritoDetalleID") %>' />
                            <div class="card mb-3">
                                <div class="row g-0">
                                    <div class="col-md-8">
                                        <div class="card-body">
                                            <h5 class="card-title"><%# Eval("Producto.Nombre") %></h5>
                                            <p class="card-text"><%# Eval("Producto.Descripcion") %></p>
                                            <p class="card-text">
                                                Cantidad:
                                                <asp:Button ID="btnAumentar" runat="server" CssClass="btn btn-sm btn-outline-secondary" Text="+" />
                                                <span><%# Eval("Cantidad") %></span>
                                                <asp:Button ID="btnDisminuir" runat="server" CssClass="btn btn-sm btn-outline-secondary" Text="-" /><br />
                                                Precio Unitario: $<%# Eval("PrecioUnitario") %><br />
                                                Subtotal: $<%# Convert.ToInt32(Eval("Cantidad")) * Convert.ToSingle(Eval("PrecioUnitario")) %>
                                            </p>
                                            <asp:Button
                                                ID="btnEliminar"
                                                runat="server"
                                                CssClass="btn btn-danger btn-sm"
                                                Text="Eliminar"
                                                CommandName="Eliminar"
                                                CommandArgument='<%# Eval("CarritoDetalleID") %>'
                                                OnCommand="btnEliminar_Command" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Button ID="btnConfirmarCarrito" runat="server" CssClass="btn btn-primary" Text="Confirmar" OnClick="btnConfirmarCarrito_Click" />
                </div>
            </div>
        </div>
    </div>

    <!--  Entrega -->
    <div class="accordion" id="accordionEntrega" runat="server">
        <div class="accordion-item">
            <h2 class="accordion-header" id="headingEntrega">
                <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseEntrega" aria-expanded="false" aria-controls="collapseEntrega">
                    Entrega
                </button>
            </h2>
            <div id="collapseEntrega" class="accordion-collapse collapse" aria-labelledby="headingEntrega" data-bs-parent="#accordionEntrega" runat="server">
                <div class="accordion-body">
                    <asp:RadioButtonList ID="rblEntrega" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblEntrega_SelectedIndexChanged">
                        <asp:ListItem Value="domicilio" Text="Envío a domicilio"></asp:ListItem>
                        <asp:ListItem Value="retiro" Text="Retiro en tienda"></asp:ListItem>
                    </asp:RadioButtonList>
                    <div id="direccionContainer" runat="server" class="mt-3" visible="false">
                        <asp:DropDownList ID="ddlDirecciones" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>
                    <asp:Button ID="btnVolverCarrito" runat="server" CssClass="btn btn-secondary" Text="Volver al Carrito" OnClick="btnVolverCarrito_Click" />
                    <asp:Button ID="btnConfirmarEntrega" runat="server" CssClass="btn btn-primary" Text="Confirmar" OnClick="btnConfirmarEntrega_Click" />
                </div>
            </div>
        </div>
    </div>

    <!-- Pago -->
    <div class="accordion" id="accordionPago" runat="server">
        <div class="accordion-item">
            <h2 class="accordion-header" id="headingPago">
                <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapsePago" aria-expanded="false" aria-controls="collapsePago">
                    Pago
                </button>
            </h2>
            <div id="collapsePago" class="accordion-collapse collapse" aria-labelledby="headingPago" data-bs-parent="#accordionPago" runat="server">
                <div class="accordion-body">
                    <!-- op pago -->
                <asp:RadioButtonList ID="rblPago" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblPago_SelectedIndexChanged">
                    <asp:ListItem Value="efectivo" Text="Pago en efectivo en tienda"></asp:ListItem>
                    <asp:ListItem Value="tarjeta" Text="Pago con tarjeta"></asp:ListItem>
                </asp:RadioButtonList>
                
                <!-- container pago tj -->
                <div id="tarjetaContainer" runat="server" class="mt-3" visible="false">
                    <!-- numero de tj con validacion de 16 numeros-->
                    <div class="mb-3">
                        <label for="txtNumeroTarjeta" class="form-label">Número de tarjeta:</label>
                        <asp:TextBox ID="txtNumeroTarjeta" runat="server" CssClass="form-control" MaxLength="16"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revNumeroTarjeta" runat="server" 
                            ControlToValidate="txtNumeroTarjeta"
                            ValidationExpression="^\d{16}$" 
                            ErrorMessage="El número de tarjeta debe contener exactamente 16 dígitos."
                            CssClass="text-danger"></asp:RegularExpressionValidator>
                    </div>
                    
                    <!-- nombre -->
                    <div class="mb-3">
                        <label for="txtNombreTarjeta" class="form-label">Nombre como figura en la tarjeta:</label>
                        <asp:TextBox ID="txtNombreTarjeta" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revNombreTarjeta" runat="server" 
                            ControlToValidate="txtNombreTarjeta"
                            ValidationExpression="^[a-zA-Z\s]{1,30}$" 
                            ErrorMessage="Solo se permiten letras y espacios. Máximo 30 caracteres."
                            CssClass="text-danger"></asp:RegularExpressionValidator>
                    </div>
                    
                    <!-- date -->
                    <div class="mb-3">
                        <label for="txtFechaVencimiento" class="form-label">Fecha de vencimiento (MM/AAAA):</label>
                        <asp:TextBox ID="txtFechaVencimiento" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revFechaVencimiento" runat="server" 
                            ControlToValidate="txtFechaVencimiento"
                            ValidationExpression="^(0[1-9]|1[0-2])\/\d{4}$" 
                            ErrorMessage="Formato inválido. Debe ser MM/AAAA y el mes no puede ser mayor a 12."
                            CssClass="text-danger"></asp:RegularExpressionValidator>
                    </div>
                    
                    <!--codigo seg 4 para amex 3 p visa master -->
                    <div class="mb-3">
                        <label for="txtCodigoSeguridad" class="form-label">Código de seguridad:</label>
                        <asp:TextBox ID="txtCodigoSeguridad" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revCodigoSeguridad" runat="server" 
                            ControlToValidate="txtCodigoSeguridad"
                            ValidationExpression="^\d{3,4}$" 
                            ErrorMessage="El código debe ser un número de 3 o 4 dígitos."
                            CssClass="text-danger"></asp:RegularExpressionValidator>
                    </div>
                </div>
                    <!-- btones -->
                    <asp:Button ID="btnVolverEntrega" runat="server" CssClass="btn btn-secondary" Text="Volver a Entrega" OnClick="btnVolverEntrega_Click" />
                    <asp:Button ID="btnConfirmarCompra" runat="server" CssClass="btn btn-success" Text="Confirmar Compra" OnClick="btnConfirmarCompra_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

