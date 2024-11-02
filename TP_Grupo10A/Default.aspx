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

                    <div class="col">
                        <div class="card h-100">

                            <%--<img src="data:image/jpeg;base64,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" class="card-img-top" alt="..." width="200" height="200" fill="#868e96" width="200" height="200">width="200" height="200" fill="#868e96" width="200" height="200">--%>
                            <img src='<%# Eval("ImagenURL") %>' alt="Imagen de Categoria" width="200" height="200">
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                <p class="card-text"><%# Eval("Descripcion") %></p>
                            </div>
                            <div class="card-footer">
                                <a class="nav-link btn btn-sm text-body-secondary" href='<%# "Producto.aspx?CATEGORIA=" + Eval("Nombre") %>'>VER MAS
    </a>
                            </div>
                        </div>
                    </div>

                </ItemTemplate>
            </asp:Repeater>
        </div>

    </main>

</asp:Content>
