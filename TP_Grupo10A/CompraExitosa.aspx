<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompraExitosa.aspx.cs" Inherits="TP_Grupo10A.CompraExitosa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="text-center">
            <h1 class="display-4 text-success">¡Felicidades por tu compra!</h1>
            <p class="lead">Tu pedido ha sido procesado exitosamente.</p>
            <img 
                src="https://e7.pngegg.com/pngimages/755/136/png-clipart-laptop-gaming-computer-video-game-desktop-computers-intel-laptop-television-game.png" 
                alt="Compra Exitosa"
                class="img-fluid mt-3" 
                style="max-width: 150px; height: auto;" />
        </div>

        <hr>

        <div class="card mb-4">
            <div class="card-header bg-info text-white">
                <h3>Resumen de tu Pedido</h3>
            </div>
            <div class="card-body">
                <p><strong>Nombre:</strong> <asp:Label ID="lblNombreUsuario" runat="server" Text="Nombre del Usuario"></asp:Label></p>
                <p><strong>Dirección:</strong> <asp:Label ID="lblDireccionCompleta" runat="server" Text="Dirección Completa"></asp:Label></p>
                <p><strong>Estado del Pedido:</strong> <asp:Label ID="lblEstadoPedido" runat="server" Text="Estado Actual"></asp:Label></p>
            </div>
        </div>

        <h4>Productos Comprados</h4>
        <asp:Repeater ID="rptDetallesPedido" runat="server">
            <ItemTemplate>
                <div class="row mb-3">
                    <div class="col-md-3">
                        <strong><%# Eval("producto.Nombre") %></strong>
                    </div>
                    <div class="col-md-3">
                        <%# Eval("Cantidad") %>
                    </div>

                    <div class="col-md-3">
                        $<%# Eval("PrecioUnitario", "{0:F2}") %>
                    </div>

                    <div class="col-md-3">
                        $<%# 
                    (Convert.ToInt32(Eval("Cantidad")) * Convert.ToSingle(Eval("PrecioUnitario"))).ToString("F2") 
                        %>
                    </div>
                </div>
            </ItemTemplate>
          </asp:Repeater>

        <div class="text-end">
            <h4><strong>Total:</strong> $<asp:Label ID="lblTotalPedido" runat="server" Text="0.00"></asp:Label></h4>
        </div>

        <div class="text-center mt-4">
            <a href="Default.aspx" class="btn btn-primary">Volver al inicio</a>
        </div>
    </div>
</asp:Content>