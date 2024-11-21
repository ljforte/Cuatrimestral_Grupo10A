<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TP_Grupo10A.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main class="d-flex justify-content-center align-items-center vh-75">

        <div class="container">
            <div class="card w-50">
                <div class="card-header text-center">
                    <h2>Perfil de Juan Pérez</h2>
                </div>
                <div class="card-body">
                    <%--CORREO--%>
                    <div class="form-group">
                        <label for="txtEmail">Email:</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control text-center"  ReadOnly="true"></asp:TextBox>
                    </div>
                    <%--CONTRASEÑA--%>
                    <div class="form-group">
                        <label for="txtContraseña">Contraseña:</label>
                        <asp:TextBox ID="txtContraseña" runat="server" CssClass="form-control text-center" type="text" ></asp:TextBox>
                    </div>
                    <%--NUEVA CONTRASEÑA--%>
                    <div class="form-group">
                        <label for="txtNueva">Nueva Contraseña:</label>
                        <asp:TextBox ID="txtNueva" runat="server" CssClass="form-control text-center" ReadOnly="false" Text="Juan"></asp:TextBox>
                    </div>
                    <%--CONFIRMAR CONSTRASEÑA--%>
                    <div class="form-group">
                        <label for="txtConfirmar">Confirmar Nueva Contraseña :</label>
                        <asp:TextBox ID="txtConfirmar" runat="server" CssClass="form-control text-center" Text="Pérez"></asp:TextBox>
                    </div>+


                    <%--GENERO--%>
                    <%--<div class="form-group">
                        <label for="ddlGenero">Género:</label>
                        <asp:DropDownList ID="ddlGenero" runat="server" CssClass="form-control text-center" Enabled="false">
                            <asp:ListItem Value="Masculino" Selected="True">Masculino</asp:ListItem>
                            <asp:ListItem Value="Femenino">Femenino</asp:ListItem>
                            <asp:ListItem Value="Otros">Otros</asp:ListItem>
                        </asp:DropDownList>
                    </div>--%>
                    <%--DIRECCION--%>
                    <%--<div class="form-group">
                        <label for="txtDireccion">Dirección:</label>
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control text-center" Text="Calle Falsa 123, Ciudad"></asp:TextBox>
                    </div>--%>

                    <%--FECHA DE REG--%>
                    <div class="form-group">
                        <label for="txtFechaRegistro">Fecha de Registro:</label>
                        <asp:TextBox ID="txtFechaRegistro" runat="server" CssClass="form-control text-center"  ReadOnly="true"></asp:TextBox>
                    </div>

                    <%--                    MODIFICAR--%>
                    <div class="form-group right-alignt">
                        <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-primary" Text="Nueva Contraseña" OnClick="btnModificar_Click" />
                    </div>
                    <div class="form-group right-alignt">
                    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                </div>
            </div>
        </div>

    </main>
</asp:Content>
