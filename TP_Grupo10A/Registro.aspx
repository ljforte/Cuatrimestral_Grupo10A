<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TP_Grupo10A.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .custom-width {
            max-width: 600px;
            width: 100%;
        }

        body {
            background-image: url('/Imagenes/FondoRegistro.jpg');
            background-size: cover;
            background-position: center;
            background-repeat: no-repeat;
            color: black;
        }

        .custom2-width {
            max-width: 400px;
            width: 100%;
        }

        .txt-color {
            background-color: white;
        }

            .txt-color option:checked {
                background-color: white;
                color: black;
            }
    </style>

    <br />
    <div>
        <h3>¡Registrate completando los siguientes datos!</h3>
    </div>
    <br />

    <div class="container">
        <div class="row g-3">
            <div class="col-md-4">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" MaxLength="50" CssClass="form-control custom2-width txt-color" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revNombre" runat="server"
                    ControlToValidate="txtNombre"
                    ValidationExpression="^[a-zA-Z\s]+$"
                    ErrorMessage="El nombre no puede contener números." CssClass="text-danger"></asp:RegularExpressionValidator>
            </div>

            <div class="col-md-4">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" CssClass="form-control custom2-width txt-color" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row g-3">
<div class="col-md-5">
    <label for="txtEmail" class="form-label">Email</label>
    <asp:TextBox ID="txtEmail" MaxLength="100" CssClass="form-control custom-width txt-color" 
                 type="email" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="revEmail" runat="server" 
        ControlToValidate="txtEmail" 
        ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" 
        ErrorMessage="Ingrese un email válido." CssClass="text-danger"></asp:RegularExpressionValidator>
</div>

<script>
    // PAra que el explorador no traiga el autocompletado con el correo que ya tengamos guardado
    document.getElementById('<%= txtEmail.ClientID %>').setAttribute('autocomplete', 'off');
</script>


            <div class="col-md-5">
                <label for="Genero" class="form-label">Género</label>
                <asp:DropDownList ID="DropDownList1" CssClass="form-select txt-color" runat="server">
                    <asp:ListItem Text="Seleccione una opción" Value="0" Selected="True" />
                    <asp:ListItem Text="Hombre" Value="1" />
                    <asp:ListItem Text="Mujer" Value="2" />
                    <asp:ListItem Text="Otro" Value="3" />
                </asp:DropDownList>
            </div>
        </div>
        <br />
        <div class="row g-3">
            <div class="col-12">
                <label for="txtDireccion" class="form-label">Dirección</label>
                <asp:TextBox ID="txtDireccion" MaxLength="100" CssClass="form-control custom-width txt-color" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row g-3">
            <div class="col-md-6">
                <label for="txtCiudad" class="form-label">Ciudad</label>
                <asp:TextBox ID="txtCiudad" CssClass="form-control custom-width txt-color" runat="server"></asp:TextBox>
            </div>

            <div class="col-md-2">
                <label for="txtCP" class="form-label">Código Postal</label>
                <asp:TextBox ID="txtCP" MaxLength="10" CssClass="form-control custom-width txt-color" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row g-3">
            <div class="col-md-6">
                <label for="txtPais" class="form-label">País</label>
                <asp:DropDownList ID="ddlPais" CssClass="form-select txt-color" runat="server">
                    <asp:ListItem Text="Argentina" Value="1" />
                    <asp:ListItem Text="Brasil" Value="2" />
                    <asp:ListItem Text="Uruguay" Value="3" />
                    <asp:ListItem Text="Chile" Value="4" />
                    <asp:ListItem Text="Paraguay" Value="5" />
                </asp:DropDownList>
            </div>

            <div class="col-md-6">
                <label for="txtTelefono" class="form-label">Teléfono</label>
                <asp:TextBox ID="txtTelefono" MaxLength="20" CssClass="form-control custom-width txt-color" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revTelefono" runat="server"
                    ControlToValidate="txtTelefono"
                    ValidationExpression="^\d+$"
                    ErrorMessage="El teléfono solo puede contener números." CssClass="text-danger"></asp:RegularExpressionValidator>
            </div>
        </div>
        <br />
        <div class="row g-3">
            <div class="col-md-6">
                <label for="txtContraseña" class="form-label">Contraseña</label>
                <asp:TextBox ID="txtContraseña" type="password" CssClass="form-control custom-width txt-color" runat="server"></asp:TextBox>
            </div>

            <div class="col-md-6">
                <label for="txtConfirmarContraseña" class="form-label">Confirmar contraseña</label>
                <asp:TextBox ID="txtConfirmarContraseña" type="password" CssClass="form-control custom-width txt-color" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row g-3">
            <div class="col-12">
                <asp:Button ID="btnRegistrarse" runat="server" Text="Registrarse" CssClass="btn btn-primary" OnClick="btnRegistrarse_Click" />
            </div>
        </div>
    </div>

</asp:Content>
