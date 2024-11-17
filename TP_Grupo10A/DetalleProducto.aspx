<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="TP_Grupo10A.DetalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid d-flex justify-content-center align-items-center vh-80">
        <div class="card p-1">
            <div class="row mb-3 text-center">
                <%--Datos del Producto--%>
                <div class="col-md-6 themed-grid-col">
                    <div class="container">
                        <asp:Label ID="lblTitulo" runat="server" CssClass="display-4" Text="Detalle de Producto"></asp:Label>
                    </div>
                    <%--Nombre--%>
                    <div class="row m-3">
                        <div class="col-md-6 themed-grid-col">
                            <asp:Label ID="lblNombre" runat="server" Text="Nombre"  cssclass="form-label"></asp:Label>
                        </div>
                        <div class="col-md-6 themed-grid-col">
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <%--DESCRIPCION--%>
                    <div class="row m-3">
                        <div class="col-md-6 themed-grid-col">
                            <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion"  class="form-label"></asp:Label>
                        </div>
                        <div class="col-md-6 themed-grid-col">
                            <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="255" CssClass="form-control" TextMode="MultiLine" Rows="4" Placeholder="Máximo 255 caracteres" />
                        </div>
                    </div>
                    <%--MARCA--%>
                    <div class="row m-3">
                        <div class="col-md-6 themed-grid-col">
                            <asp:Label ID="lblMarcas" runat="server" Text="Marcas"  class="form-label"></asp:Label>
                        </div>
                        <div class="col-md-6 themed-grid-col">
                            <asp:TextBox ID="txtMarcas" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <%--PRECIO--%>
                    <div class="row m-3">
                        <div class="col-md-6 themed-grid-col">
                            <asp:Label ID="lblPrecio" runat="server" Text="Precio"  class="form-label"></asp:Label>
                        </div>
                        <div class="col-md-6 themed-grid-col">
                            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <%--STOCK--%>
                    <div class="row m-3">
                        <div class="col-md-6 themed-grid-col">
                            <asp:Label ID="lblStock" runat="server" Text="Stock Disponible"  class="form-label"></asp:Label>
                        </div>
                        <div class="col-md-6 themed-grid-col">
                            <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <%--comprar--%>
                    <div class="row mb-3 text-center">
                        <div class="col-4 themed-grid-col">
                            <asp:Label ID="lblCantidad" runat="server" Text="Cantidad: "></asp:Label>
                            <input type="number" id="cantidad" value="1" min="1" max="5" />
                        </div>

                        <div class="col-4 themed-grid-col">
                            <asp:Button ID="btnAgregarCarrito" runat="server" Text="Agregar Carrito" OnClick="btnAgregarCarrito_Click" CssClass="btn btn-outline-primary btn-sm" />
                        </div>
                        <div class="col-4 themed-grid-col">

                            <asp:Button ID="btnComprar" runat="server" Text="Comprar Ahora" OnClick="btnComprar_Click" CssClass="btn btn-success btn-sm" />
                        </div>
                    </div>


                </div>
                <%--Imagenes del Producto--%>
                <div class="col-6">
                    <div class="container">
                        <asp:Repeater ID="rptImagenes" runat="server">
                            <HeaderTemplate>
                                <div class="row">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="col-md-6 mb-4">
                                    <img src='<%# Eval("ImagenUrl") %>' class="card-img-top fixed-size-img" alt='<%# Eval("ImagenUrl") %>' width="200" height="200">
                                </div>
                                <%# Container.ItemIndex % 2 == 1 ? "</div><div class='row'>" : "" %>
                            </ItemTemplate>
                            <FooterTemplate>
                                </div>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

