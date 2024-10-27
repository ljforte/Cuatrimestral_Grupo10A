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

    </main>

</asp:Content>
