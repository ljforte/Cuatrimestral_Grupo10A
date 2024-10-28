<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TP_Grupo10A.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <style>
        body {
            background-image: url('/Imagenes/fondoLogin.png');
            background-size: cover;
            background-position: center;
            background-repeat: no-repeat;
        }
    </style>


    <div class="container">
        <div class="row">
            <div class="col-2"></div>

            <div class="col">
                <div>
                    <h3>Inicia Sesion </h3>
                </div>

                <div class="form-floating mt-3">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" type ="email"  ></asp:TextBox>
                    <label for="txtEmail">Email</label>
                </div>
                <div class="form-floating mt-3">
                    <asp:TextBox ID="txtContraseña"  runat="server" CssClass="form-control" type ="password"></asp:TextBox>
                    <label for="txtContraseña">Contraseña</label>
                </div>
                <div>
                    <asp:Label ID="mensajeError" runat="server" Text="Datos incorrectos" ForeColor="Red"></asp:Label>


                </div>
                <div class="mt-3">
                    <asp:Button ID="btnIngresar" CssClass="btn btn primary" OnClick="btnIngresar_Click" runat="server" Text="Ingresar" />
                </div>

            </div>
            <div class="col-2"></div>
        </div>
    </div>



</asp:Content>
