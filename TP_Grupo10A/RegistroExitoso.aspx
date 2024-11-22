<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroExitoso.aspx.cs" Inherits="TP_Grupo10A.RegistroExitoso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .welcome-text {
            font-size: 2.5rem;
            font-weight: bold;
            text-align: center;
            margin-top: 20px;
            color: #333;
        }

        .subtext {
            font-size: 1.2rem;
            text-align: center;
            margin-top: 10px;
            color: #555;
        }

        .image-container {
            text-align: center;
            margin-top: 30px;
        }

        .btn-container {
            text-align: center;
            margin-top: 20px;
        }
    </style>

    <div class="welcome-text">¡Registro Exitoso! Bienvenido a FBE Hardware!</div>

    <div class="image-container">
        <img src="/Imagenes/logoFBE.png" alt="Logo FBE Hardware" class="img-fluid" />
    </div>

    <div class="subtext">Vamos a ver qué comprar :)</div>

    <div class="btn-container">
        <asp:Button ID="btnProductos" runat="server"
            CssClass="btn btn-primary btn-lg px-4 py-2 shadow-sm hover-shadow"
            Text="Productos :D" OnClick="btnProductos_Click" />
    </div>
</asp:Content>