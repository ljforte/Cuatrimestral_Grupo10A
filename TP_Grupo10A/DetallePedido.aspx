<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="DetallePedido.aspx.cs" Inherits="TP_Grupo10A.DetallePedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Gestion" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-center">Detalle del pedido</h2>

    <div class="container mt-3">
        <div class="row justify-content-center">
            <div class="col-md-3 text-right">
                <asp:Label ID="lblNombreCliente" runat="server" Text="Cliente:"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:Label ID="lblNombreClienteCampo" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="row justify-content-center">
            <div class="col-md-3 text-right">
                <asp:Label ID="lblMetodoDePago" runat="server" Text="Metodo de pago:"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:Label ID="lblMetodoDePagoCampo" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="row justify-content-center">
            <div class="col-md-3 text-right">
                <asp:Label ID="lblEstadoPedido" runat="server" Text="Estado:"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:Label ID="lblEstadoPedidoCampo" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="row justify-content-center">
            <div class="col-md-3 text-right">
                <asp:Label ID="lblDireccion" runat="server" Text="Direccion:"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:Label ID="lblDireccionCampo" runat="server" Text=""></asp:Label>
            </div>
        </div>

         <div class="row justify-content-center">
     <div class="col-md-3 text-right">
         <asp:Label ID="lblFecha" runat="server" Text="Fecha de compra:"></asp:Label>
     </div>
     <div class="col-md-6">
         <asp:Label ID="lblFechaCampo" runat="server" Text=""></asp:Label>
     </div>
 </div>

        
        <div class="row justify-content-center mt-3">
            <div class="col-md-9">
                <asp:GridView ID="dgvProductos" CssClass="table" AutoGenerateColumns="false" runat="server">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="PedidoID" />
                        <asp:BoundField HeaderText="Producto" DataField="ProductoNombre" />
                        <asp:BoundField HeaderText="Precio" DataField= "PrecioUnitario" />
                        <asp:CommandField HeaderText="Detalle" ShowSelectButton="true" SelectText="Ver" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <div class="row justify-content-center">
    <div class="col-md-3 text-right">
        <asp:Label ID="lblTotal" runat="server" Text="Total"></asp:Label>
    </div>
    <div class="col-md-6">
        <asp:Label ID="lblTotalCampo" runat="server" Text=""></asp:Label>
    </div>
</div>
    </div>
</asp:Content>
