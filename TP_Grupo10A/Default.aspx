<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Grupo10A._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="./Content/style.css" rel="stylesheet" type="text/css" />
    <main>
        <div id="carouselPortada" class="carousel slide" data-bs-ride="carousel">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="./Imagenes/fondoFBE.png" class="d-block w-100" alt="Imagen 1">
                </div>
                <div class="carousel-item">
                    <img src="./Imagenes/OfertaPortada.png" class="d-block w-100" alt="Imagen 2">
                </div>
                <div class="carousel-item">
                    <img src="./Imagenes/CorsairBanner.jpg" class="d-block w-100" alt="Imagen 3">
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselPortada" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselPortada" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>
        <div id="carouselProveedores" class="carousel slide" data-bs-ride="carousel">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <div class="row">
                        <div class="col">
                            <img src="./Imagenes/LogosMarcas/amd.png" alt="AMD">
                        </div>
                        <div class="col">
                            <img src="./Imagenes/LogosMarcas/aorus.png" alt="Aourus">
                        </div>
                        <div class="col">
                            <img src="./Imagenes/LogosMarcas/asus.png" alt="ASUS">
                        </div>
                        <div class="col">
                            <img src="./Imagenes/LogosMarcas/coolermaster.png" alt="Cooler Master">
                        </div>
                    </div>
                </div>
                <div class="carousel-item">
                    <div class="row">
                        <div class="col">
                            <img src="./Imagenes/LogosMarcas/corsair.png" alt="Corsair">
                        </div>
                        <div class="col">
                            <img src="./Imagenes/LogosMarcas/gigabyte.png" alt="Gigabyte">
                        </div>
                        <div class="col">
                            <img src="./Imagenes/LogosMarcas/hp.png" alt="HP">
                        </div>
                        <div class="col">
                            <img src="./Imagenes/LogosMarcas/intel.png" alt="Intel">
                        </div>
                    </div>
                </div>
                <div class="carousel-item">
                    <div class="row">
                        <div class="col">
                            <img src="./Imagenes/LogosMarcas/msi.png" alt="MSI">
                        </div>
                        <div class="col">
                            <img src="./Imagenes/LogosMarcas/samsung.png" alt="Samsung">
                        </div>
                        <div class="col">
                            <img src="./Imagenes/LogosMarcas/kingston.png" alt="Kingston">
                        </div>
                        <div class="col">
                            <img src="./Imagenes/LogosMarcas/amd.png" alt="AMD">
                        </div>
                    </div>
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselProveedores" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselProveedores" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>
        <%--IMAGENES DE CATEGORIAS--%>
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater ID="RepeaterCategorias" runat="server">
                <ItemTemplate>

                    <div class="col  text-body-secondary">
                        <a href='<%# "Producto.aspx?CATEGORIA=" + Eval("Nombre") %>' class="text-decoration-none  ">
                            <div class="card h-100">

                                <img src='<%# Eval("ImagenURL") %>' alt="Imagen de Categoria" width="200" height="200" class="mx-auto ">
                                <div class="card-body">
                                    <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                    <p class="card-text"><%# Eval("Descripcion") %></p>
                                </div>

                                    <%--CONVERTIR A BUTTON SERIA LO MEJOR--%>
                                <%--<div class="card-footer">
                                    <p class="btn btn-sm" href='<%# "Producto.aspx?CATEGORIA=" + Eval("Nombre") %>'>Ver mas <%# Eval("Nombre") %>></p>
                                </div>--%>

                            </div>
                        </a>
                    </div>

                </ItemTemplate>
            </asp:Repeater>
        </div>

    </main>

</asp:Content>
